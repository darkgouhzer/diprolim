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
    DECLARE _COUNT			INT DEFAULT 0;
	
	-- Obtener datos del empleado
	Select CONCAT(nombre, " " , apellido_paterno," ",apellido_materno) from empleados where id_empleado=_iEmpleado 
			INTO _NombreEmpleado;
	
	-- Validar si Empleado ya hizo corte de caja
	SELECT Fecha FROM cortedcaja where empleados_id_empleado=_iEmpleado ORDER BY Fecha DESC LIMIT 1 INTO _Fecha;
		
	-- Si ya hizo corte se obtiene gastos y concepto
 	IF CAST(_Fecha AS DATE)=CAST( NOW() AS DATE) AND CAST(_dFecha AS DATE)=CAST( NOW() AS DATE) THEN
		SELECT COALESCE(Gastos, 0),COALESCE(Concepto,0) FROM cortedcaja WHERE empleados_id_empleado=_iEmpleado AND 
		CAST(Fecha AS DATE)=CAST( _dFecha AS DATE) INTO _Gastos, _Concepto;
	ELSE IF CAST(_dFecha AS DATE)<CAST( NOW() AS DATE) THEN
			SELECT COALESCE(Gastos, 0),COALESCE(Concepto,0) FROM cortedcaja WHERE empleados_id_empleado=_iEmpleado AND 
			CAST(Fecha AS DATE)=CAST( _dFecha AS DATE) INTO _Gastos, _Concepto;
		END IF;
	END IF;

	IF CAST(_dFecha AS DATE)=CAST( NOW() AS DATE) THEN
		-- Obtener último corte de días anteriores
        
        SELECT count(*) FROM cortedcaja where empleados_id_empleado=_iEmpleado INTO _COUNT;
        IF _COUNT > 1 THEN
        SELECT Fecha FROM cortedcaja where empleados_id_empleado=_iEmpleado AND CAST(Fecha AS DATE)<CAST( _dFecha AS DATE)
		ORDER BY Fecha DESC LIMIT 1 INTO _FechaAnterior;
        ELSE
			SELECT CAST(fecha_venta as date) FROM ventas WHERE empleados_id_empleado=_iEmpleado ORDER BY fecha_venta ASC LIMIT 1 INTO _FechaAnterior;
        END IF;
		
		-- Obtener ventas a crédito
		SELECT COALESCE(sum(importe),0), COALESCE(sum(importe)-sum(importe)/1.16,0) FROM  ventas  WHERE empleados_id_empleado=_iEmpleado AND 
			tipo_compra='credito' AND fecha_venta > _FechaAnterior INTO _Fiado, _ivaFiado;

		-- Obtener abonos
		SELECT COALESCE(sum(abono),0)  FROM abonos WHERE empleados_id_empleado=_iEmpleado AND fecha > _FechaAnterior 
		INTO _Recuperado;

		-- Obtener total de ventas
		SELECT COALESCE(sum(importe)/1.16,0), COALESCE(sum(importe)-sum(importe)/1.16,0) FROM ventas WHERE empleados_id_empleado=_iEmpleado AND 
			fecha_venta > _FechaAnterior INTO _VentasTotales, _IVA;
	ELSE 
		SELECT concat(date(_dFecha),' 23:59:59') INTO _Fecha;
         SELECT count(Fecha) FROM cortedcaja where empleados_id_empleado=_iEmpleado AND CAST(Fecha AS DATE) = CAST( _Fecha  AS DATE)
										 ORDER BY Fecha DESC LIMIT 1 into _COUNT;
		IF _COUNT > 0 THEN  
			SELECT Fecha FROM cortedcaja where empleados_id_empleado=_iEmpleado AND CAST(Fecha AS DATE) = CAST( _dFecha AS DATE)
										 ORDER BY Fecha DESC LIMIT 1 INTO _Fecha;	
        
		-- Obtener último corte de días anteriores
         SELECT count(*) FROM cortedcaja where empleados_id_empleado=_iEmpleado AND CAST(Fecha AS DATE)<CAST( _dFecha AS DATE) ORDER BY Fecha DESC INTO _COUNT;
		IF _COUNT > 0 THEN
			 SELECT Fecha FROM cortedcaja where empleados_id_empleado=_iEmpleado AND CAST(Fecha AS DATE)<CAST( _dFecha AS DATE)
			ORDER BY Fecha DESC LIMIT 1 INTO _FechaAnterior; 
		ELSE
            select cast(fecha_venta as date) from ventas where empleados_id_empleado=_iEmpleado AND
            CAST(fecha_venta AS DATE)<CAST( _dFecha AS DATE) order by fecha_venta asc limit 1 INTO _FechaAnterior;
		END IF;
		
		-- Obtener ventas a crédito
		SELECT COALESCE(sum(importe),0), COALESCE(sum(importe)-sum(importe)/1.16,0) FROM  ventas  WHERE empleados_id_empleado=_iEmpleado AND 
			tipo_compra='credito' AND fecha_venta BETWEEN _FechaAnterior AND _Fecha INTO _Fiado, _ivaFiado;

		-- Obtener abonos
		SELECT COALESCE(sum(abono),0)  FROM abonos WHERE empleados_id_empleado=_iEmpleado AND fecha BETWEEN _FechaAnterior AND _Fecha
		INTO _Recuperado;

		-- Obtener total de ventas
		SELECT COALESCE(sum(importe)/1.16,0), COALESCE(sum(importe)-sum(importe)/1.16,0) FROM ventas WHERE empleados_id_empleado=_iEmpleado AND 
			fecha_venta BETWEEN _FechaAnterior AND _Fecha INTO _VentasTotales, _IVA;
		END IF;
	END IF;

	SELECT _NombreEmpleado, _VentasTotales, _IVA, _Recuperado, _Fiado, _ivaFiado, _Gastos, _Concepto, _Fecha,
			 _FechaAnterior;

END