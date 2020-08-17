CREATE PROCEDURE `sp_historicoMovimientos` (iCodigoArticulo INT, dCantidad Double, sMovimiento VARCHAR(45), dExistenciaInicial	DOUBLE, dExistenciaFinal DOUBLE, iEmpleadoID INT, iUsuarioID INT, bVendedorSucursal BOOLEAN)
BEGIN

	IF bVendedorSucursal = TRUE THEN
        INSERT INTO historicodmovimientos( articulos_codigo, cantidad, Movimiento, Fecha, Existencia_inicial, Existencia_Final, Usuarios_id_usuarios)
							   VALUES(iCodigoArticulo,   dCantidad,sMovimiento,now(), dExistenciaInicial,dExistenciaFinal,  iUsuarioID);
    ELSE
    	INSERT INTO historicovendedores (articulos_codigo,cantidad, Movimiento, Fecha,Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) 
							  VALUES(iCodigoArticulo, dCantidad,sMovimiento,now(),dExistenciaInicial,dExistenciaFinal,iEmpleadoID,           iUsuarioID);
    END IF;
END