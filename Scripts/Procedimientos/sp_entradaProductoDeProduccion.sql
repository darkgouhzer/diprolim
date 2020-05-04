CREATE PROCEDURE `sp_entradaProductoDeProduccion` (codigoProducto int, dCantidad double)
BEGIN
	DECLARE iCodigoAGranel int DEFAULT 0;
    DECLARE dValorMedida double DEFAULT 0;
    DECLARE dCantidadGranel double DEFAULT 0;
    
    -- Se obtiene el producto a granel y valor de medida de codigo de producto para saber cuanto restar de a granel
	SELECT codigo FROM articulos WHERE iddescripcion  = (SELECT iddescripcion from articulos WHERE codigo = codigoProducto) AND unidad_medida_id = 7 INTO iCodigoAGranel;
    SELECT valor_medida FROM articulos WHERE codigo = codigoProducto INTO dValorMedida;
	SELECT (dValorMedida * dCantidad) INTO  dCantidadGranel;
	UPDATE articulos SET cantidad = cantidad - dCantidadGranel WHERE codigo = iCodigoAGranel;
    -- Se suma la entrada al inventario del producto
	UPDATE articulos SET cantidad = cantidad + dCantidad WHERE codigo = codigoProducto;
END