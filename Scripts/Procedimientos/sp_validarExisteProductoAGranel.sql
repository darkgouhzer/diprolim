CREATE PROCEDURE `sp_validarExisteProductoAGranel` (DescripcionID INT)
BEGIN
	SELECT CODIGO FROM articulos WHERE iddescripcion = DescripcionID AND unidad_medida_id = 7;
END