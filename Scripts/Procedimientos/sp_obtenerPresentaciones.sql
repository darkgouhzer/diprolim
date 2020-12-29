CREATE PROCEDURE `sp_obtenerPresentaciones`(iUnidadMedidaID INT)
BEGIN
	SELECT a.valor_medida, um.nombre, um.simbolo FROM articulos a 
	JOIN unidad_medida um ON um.id = a.unidad_medida_id
    WHERE a.unidad_medida_id= iUnidadMedidaID AND a.valor_medida>0 GROUP BY a.valor_medida;
END