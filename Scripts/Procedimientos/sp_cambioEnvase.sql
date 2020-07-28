CREATE PROCEDURE `sp_cambioEnvase` (iCodigArticulo INT, dCantidad Double, iEmpleadoID INT, iUsuarioID INT, bVendedorSucursal BOOLEAN)
BEGIN
-- iCodigoArticulo es el código del producto vendido del cual hay que obtener el código de envase
	declare iCodigoEnvase INT default 0;
    declare dCantidadActual DOUBLE default 0;
    
    -- Obtienes el código de envase del articulo
    SELECT codigo_envase FROM articulos WHERE codigo = iCodigArticulo INTO iCodigoEnvase;
    
    -- Obtiene el inventario de el envase
    SELECT cantidad FROM articulos WHERE codigo = iCodigoEnvase INTO  dCantidadActual;
    
	UPDATE articulos SET cantidad = cantidad + dCantidad WHERE codigo = iCodigoEnvase;
	call sp_historicoMovimientos(iCodigoEnvase, dCantidad , 'Cambio-Envase' , dCantidadActual, dCantidadActual + dCantidad , iEmpleadoID, iUsuarioID, bVendedorSucursal);
END