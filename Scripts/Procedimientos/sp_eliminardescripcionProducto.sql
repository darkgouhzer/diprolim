CREATE PROCEDURE `sp_eliminardescripcionProducto`  (iDescripcionId int)
BEGIN
	delete from articulosdescripciones where iddescripcion = iDescripcionId;
END