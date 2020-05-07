CREATE PROCEDURE `sp_validarTransfProduccion` (codigoArticulo int)
BEGIN
	SELECT codigo FROM articulos WHERE codigo = codigoArticulo AND unidad_medida_id = 1 AND 
    iddescripcion IN (SELECT iddescripcion FROM articulos WHERE unidad_medida_id = 7 and iddescripcion >0);
END