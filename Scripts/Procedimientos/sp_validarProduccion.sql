CREATE PROCEDURE `sp_validarProduccion` (codigoArticulo int)
BEGIN
		SELECT codigo FROM articulos WHERE codigo = codigoArticulo AND unidad_medida_id = 7;
END