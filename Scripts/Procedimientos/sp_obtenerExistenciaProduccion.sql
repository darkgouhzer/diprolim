CREATE PROCEDURE `sp_obtenerExistenciaProduccion` (idDescripcionProd int)
BEGIN
	SELECT cantidad FROM articulos WHERE iddescripcion = idDescripcionProd AND unidad_medida_id = 7;
END