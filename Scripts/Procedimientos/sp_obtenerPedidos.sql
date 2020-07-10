CREATE PROCEDURE `sp_obtenerPedidos` (StatusPedido varchar(1), EmpleadoID INT, ClienteID INT)
BEGIN
	declare statusP INT;
	SET @sqlQuery = 'SELECT p.idpedidos, p.fecha_registro as fecharegistro, p.fechapedido, p.idclientes, p.status, c.nombre as nombrecliente FROM pedidos p
		INNER JOIN clientes c ON p.idclientes = c.idclientes 
		INNER JOIN empleados e ON e.id_empleado = c.empleados_id_empleado';
	IF StatusPedido = 'P' THEN		
		SET @sqlQuery = CONCAT(@sqlQuery , ' WHERE p.status = 0');
	ELSE IF StatusPedido = 'F' THEN
			SET @sqlQuery = CONCAT(@sqlQuery, ' WHERE p.status = 1');
		END IF;
    END IF;
    
	IF StatusPedido = 'T' THEN	
		IF EmpleadoID <> 0 THEN
			SET @sqlQuery = CONCAT(@sqlQuery, CONCAT(' WHERE c.empleados_id_empleado = ', EmpleadoID));
		END IF;
	ELSE IF EmpleadoID <> 0 THEN
			SET @sqlQuery = CONCAT(@sqlQuery, CONCAT(' AND c.empleados_id_empleado = ', EmpleadoID));
		END IF;
    END IF;
    
    IF StatusPedido = 'T' AND EmpleadoID = 0 THEN	
		IF ClienteID <> 0 THEN
			SET @sqlQuery = CONCAT(@sqlQuery, CONCAT(' WHERE p.idclientes = ', ClienteID));
		END IF;
	ELSE IF ClienteID <> 0 THEN
			SET @sqlQuery = CONCAT(@sqlQuery, CONCAT(' AND  p.idclientes = ', ClienteID));
		END IF;
    END IF; 
        
	PREPARE myquery FROM @sqlQuery;
	EXECUTE myquery;
         
END