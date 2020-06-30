CREATE PROCEDURE `sp_guardarPedidoDetalle` (PedidosID INT, CodigoProducto INT, TipoPrecio VARCHAR(15), Cantidad double)
BEGIN
	INSERT INTO `pedidosdetalle` (`idpedidos`, `articulos_codigo`, `tipo_precio`, `cantidad`) VALUES (PedidosID, CodigoProducto, TipoPrecio, Cantidad);
END