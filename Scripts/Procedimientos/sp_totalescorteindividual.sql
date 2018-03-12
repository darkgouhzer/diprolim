-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE PROCEDURE sp_totalescorteindividual(_iEmpleado INT, _dFecha DATETIME)
BEGIN
	DECLARE _NombreEmpleado	TEXT DEFAULT '';
	DECLARE _VentasTotales 	DOUBLE DEFAULT 0;
	DECLARE _IVA			DOUBLE DEFAULT 0;
	DECLARE _Recuperado		DOUBLE DEFAULT 0;
	DECLARE _Fiado			DOUBLE DEFAULT 0;
	DECLARE _ivaFiado		DOUBLE DEFAULT 0;
	DECLARE _Gastos			DOUBLE DEFAULT 0;
	DECLARE _Concepto		TEXT  DEFAULT '';
	DECLARE _Fecha			DATETIME  DEFAULT NOW();
	DECLARE _FechaAnterior	DATETIME DEFAULT NOW();
	
	-- Obtener datos del empleado
	Select CONCAT(nombre, " " , apellido_paterno," ",apellido_materno) from empleados where id_empleado=_iEmpleado 
			INTO _NombreEmpleado;
	
	-- Validar si Empleado ya hizo corte de caja
	SELECT Fecha FROM cortedcaja where empleados_id_empleado=_iEmpleado ORDER BY Fecha DESC LIMIT 1 INTO _Fecha;
		
	-- Si ya hizo corte se obtiene gastos y concepto
 --	IF CAST(_Fecha AS DATE)=CAST( NOW() AS DATE) THEN
		SELECT COALESCE(Gastos, 0),COALESCE(Concepto,0) FROM cortedcaja WHERE empleados_id_empleado=_iEmpleado AND 
		CAST(Fecha AS DATE)=CAST( _dFecha AS DATE) INTO _Gastos, _Concepto;
--	END IF;

	-- Obtener último corte de días anteriores
	SELECT Fecha FROM cortedcaja where empleados_id_empleado=_iEmpleado AND CAST(Fecha AS DATE)<CAST( NOW() AS DATE)
	  ORDER BY Fecha DESC LIMIT 1 INTO _FechaAnterior;
	-- Obtener ventas a crédito
	SELECT COALESCE(sum(importe),0), COALESCE(sum(importe)-sum(importe)/1.16,0) FROM  ventas  WHERE empleados_id_empleado=_iEmpleado AND 
		tipo_compra='credito' AND fecha_venta > _FechaAnterior INTO _Fiado, _ivaFiado;

	-- Obtener abonos
	SELECT COALESCE(sum(abono),0)  FROM abonos WHERE empleados_id_empleado=_iEmpleado AND fecha > _FechaAnterior 
	INTO _Recuperado;

	-- Obtener total de ventas
	SELECT COALESCE(sum(importe)/1.16,0), COALESCE(sum(importe)-sum(importe)/1.16,0) FROM ventas WHERE empleados_id_empleado=_iEmpleado AND 
		fecha_venta > _FechaAnterior INTO _VentasTotales, _IVA;
	
	SELECT _NombreEmpleado, _VentasTotales, _IVA, _Recuperado, _Fiado, _ivaFiado, _Gastos, _Concepto, _Fecha,
			 _FechaAnterior;

END