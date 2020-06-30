CREATE PROCEDURE `sp_obtenerPedido` (PedidoID INT)
BEGIN
	SELECT idpedidos, fecha_registro, fechapedido, idclientes, status FROM pedidos WHERE idpedidos = PedidoID;
END