CREATE PROCEDURE `sp_validarExisteProductoAGranel` (DescripcionID INT, UnidadMedidaID INT)
BEGIN
	SELECT CODIGO FROM articulos WHERE iddescripcion = DescripcionID AND unidad_medida_id = UnidadMedidaID;
END