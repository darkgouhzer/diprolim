CREATE PROCEDURE `sp_actualizarDescripcionProducto` (descripcionId int, nuevaDescripcion varchar(50))
BEGIN
	UPDATE articulosdescripciones SET descripcion = nuevaDescripcion  WHERE iddescripcion = descripcionId;
END