CREATE PROCEDURE `sp_guardarPedido` (PedidosID INT, FechaPedido DATETIME, ClienteID INT)
BEGIN	
	IF PedidosID = 0 THEN
    	INSERT INTO `pedidos` (`fecha_registro`, `fechapedido`, `idclientes`, `status`) VALUES (now(), FechaPedido, ClienteID, 0);    
		SET PedidosID = LAST_INSERT_ID();
    ELSE
		UPDATE pedidos SET fechapedido = FechaPedido, idclientes = ClienteID WHERE idpedidos = PedidosID;
    END IF;
    DELETE FROM pedidosdetalle where idpedidos = PedidosID;
    SELECT PedidosID;	
END