CREATE PROCEDURE `sp_validarExisteProductoAGranel` (DescripcionID INT, UnidadMedidaID INT, ValorMedida INT)
BEGIN
	SELECT CODIGO FROM articulos WHERE iddescripcion = DescripcionID AND unidad_medida_id = UnidadMedidaID AND valor_medida = ValorMedida;
END