-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE PROCEDURE `sp_obtenercortesucursaltemporal` (dfecha DATETIME)
BEGIN
	DECLARE _idEmpleado		 	INT DEFAULT 0;
	DECLARE _iContCaja			INT DEFAULT 0;
	DECLARE _sNombreEmpleado 	TEXT DEFAULT '';
	DECLARE _dVentasTotales		DOUBLE DEFAULT 0;
	DECLARE _dIva				DOUBLE DEFAULT 0;
	DECLARE _dVSINIVATotal		DOUBLE DEFAULT 0;
	DECLARE _dRecuperado		DOUBLE DEFAULT 0;
	DECLARE _dFiado				DOUBLE DEFAULT 0;
	DECLARE _dGastos			DOUBLE DEFAULT 0;
	DECLARE _dEfectivoEntrega	DOUBLE DEFAULT 0;
	DECLARE _sConcepto			TEXT DEFAULT '';
	DECLARE _dFechaInicial		DATETIME DEFAULT NOW();
	DECLARE exit_loop BOOLEAN DEFAULT FALSE;
	DECLARE _ContEmpleados int default 0;
	


	DECLARE cursorEmpleados	CURSOR FOR 
	SELECT id_empleado FROM empleados order by id_empleado asc;  
	
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET exit_loop = TRUE;
	
drop table if exists tmp_cortedcaja;
CREATE TEMPORARY TABLE `tmp_cortedcaja` (
  `idCorteDCaja` int(11) NOT NULL AUTO_INCREMENT,
  `empleados_id_empleado` int(11) NOT NULL,
  `Ventas_Totales` double DEFAULT NULL,
  `Recuperado` double DEFAULT NULL,
  `Fiado` double DEFAULT NULL,
  `Gastos` double DEFAULT NULL,
  `Concepto` varchar(100) DEFAULT NULL,
  `EfectivoAEntregar` double DEFAULT NULL,
  `Fecha` datetime DEFAULT NULL,
  `Iva` double DEFAULT '0',
  PRIMARY KEY (`idCorteDCaja`));

	-- Validación para saber si es el día actual, no se puede hacer corte de dias anteriores, solo consulta
	IF CAST(dfecha AS DATE) = CAST(NOW() AS DATE) THEN
		SELECT COUNT(id_empleado) FROM empleados INTO _ContEmpleados;	
		OPEN cursorEmpleados;
		WHILE _ContEmpleados > 0 DO
		FETCH cursorEmpleados INTO _idEmpleado;	

		-- Obtener fecha del último corte de caja del empleado
		SELECT if( CAST(fecha AS TIME) > CAST('00:00:00' AS TIME), fecha, CAST(CAST(dfecha AS DATE) AS DATETIME))
		FROM cortedcaja WHERE empleados_id_empleado =_idEmpleado AND CAST(fecha AS DATE) < CAST(dfecha AS DATE)	
		ORDER BY fecha DESC LIMIT 1 INTO _dFechaInicial;
		
		-- Obtener ventas totales desde el último corte al día actual CON IVA
		SELECT COALESCE(SUM(importe)/1.16,0),COALESCE(SUM(importe) - SUM(importe)/1.16, 0) FROM ventas
		WHERE empleados_id_empleado=_idEmpleado AND fecha_venta BETWEEN _dFechaInicial AND dfecha AND iva>0 
		INTO _dVentasTotales, _dIva;

		-- Obtener ventas totales desde el último corte al día actual SIN IVA
		SELECT COALESCE(SUM(importe),0) FROM ventas
		WHERE empleados_id_empleado=_idEmpleado AND fecha_venta BETWEEN _dFechaInicial AND dfecha AND iva=0 
		INTO _dVSINIVATotal;
		SET _dVentasTotales = _dVentasTotales + _dVSINIVATotal;

		-- Obtener ventas totales a crédito desde el último corte al día actual
		SELECT COALESCE(SUM(importe), 0) FROM ventas WHERE empleados_id_empleado= _idEmpleado 
		AND tipo_compra='credito' AND fecha_venta BETWEEN _dFechaInicial AND dfecha INTO _dFiado;

		-- Dinero recuperado de abonos
		SELECT COALESCE(SUM(abono), 0) FROM  abonos  WHERE empleados_id_empleado= _idEmpleado AND fecha BETWEEN
			_dFechaInicial AND dfecha INTO _dRecuperado;

		-- Verificar si ha habido cortes de caja del día actual y obtener gastos.
		SELECT COUNT(idCorteDCaja), COALESCE(SUM(Gastos),0), COALESCE(concepto, '') FROM cortedcaja 
		WHERE empleados_id_empleado=_idEmpleado AND CAST(Fecha AS date)=CAST(dfecha AS date) 
		INTO _iContCaja, _dGastos, _sConcepto;

		SET _dEfectivoEntrega = _dVentasTotales + _dIva - _dFiado + _dRecuperado;
		IF _dVentasTotales > 0 OR _dRecuperado > 0 OR _dFiado > 0 OR _dGastos THEN
			INSERT INTO tmp_cortedcaja (empleados_id_empleado,Ventas_Totales,Recuperado,Fiado,Gastos,Concepto,
								EfectivoAEntregar,Fecha,Iva)
			VALUES(_idEmpleado, _dVentasTotales, _dRecuperado, _dFiado, _dGastos, _sConcepto, _dEfectivoEntrega,
					dfecha, _dIva);
		END IF;
	
		SET _ContEmpleados = _ContEmpleados-1;
		END WHILE;
		
		CLOSE cursorEmpleados;
	END IF;
	SELECT c.empleados_id_empleado, e.nombre, c.Ventas_Totales, c.Recuperado, c.Fiado, c.Gastos, c.Concepto, 
	c.EfectivoAEntregar, c.Fecha, c.Iva FROM tmp_cortedcaja c JOIN empleados e
	ON e.id_empleado = c.empleados_id_empleado WHERE CAST(c.Fecha AS DATE) = CAST(dfecha AS DATE);
END