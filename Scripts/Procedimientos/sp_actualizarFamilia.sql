CREATE PROCEDURE `sp_actualizarFamilia` (familiaId int, nuevaDescripcion varchar(50))
BEGIN
	UPDATE familias SET descripcion = nuevaDescripcion  WHERE idfamilias = familiaId;
END