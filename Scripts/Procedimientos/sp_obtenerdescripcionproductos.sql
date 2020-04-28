CREATE PROCEDURE `sp_obtenerdescripcionproductos`  (filtro varchar(50))
BEGIN
	SELECT iddescripcion, descripcion from articulosdescripciones WHERE descripcion LIKE CONCAT('%', TRIM(filtro) , '%');
END