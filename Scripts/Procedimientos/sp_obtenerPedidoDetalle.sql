CREATE PROCEDURE `sp_obtenerPedidoDetalle` (PedidoID INT)
BEGIN
	SELECT idpedidosdetalle, idpedidos, articulos_codigo, tipo_precio, cantidad FROM pedidosdetalle WHERE idpedidos = PedidoID;
END