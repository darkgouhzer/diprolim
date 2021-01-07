CREATE PROCEDURE `sp_obtenerNumeroCompra` (ClienteID INT)
BEGIN
	SELECT COUNT(*) AS compras FROM (SELECT clientes_idclientes FROM ventas WHERE clientes_idclientes = ClienteID GROUP BY folio) AS nCompras;
END