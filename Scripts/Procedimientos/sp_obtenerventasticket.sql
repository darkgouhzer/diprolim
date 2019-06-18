-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE PROCEDURE `sp_obtenerventasticket` (numeroTicket INT)
BEGIN
SELECT v.folioticket, v.articulos_codigo, a.descripcion, a.valor_medida,um.nombre AS nombremedida, 
		v.precio_art,v.cantidad, v.importe, v.fecha_venta 
		FROM ventas v,categorias c, articulos a, unidad_medida um WHERE v.categorias_idcategorias=c.idcategorias 
		AND v.articulos_codigo = a.codigo AND a.unidad_medida_id=um.id and v.folioticket = numeroTicket;
END