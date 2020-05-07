CREATE PROCEDURE `sp_obtenerDescripcionProdById` (DescripcionID int)
BEGIN
	SELECT iddescripcion, descripcion from articulosdescripciones WHERE iddescripcion = DescripcionID;
END