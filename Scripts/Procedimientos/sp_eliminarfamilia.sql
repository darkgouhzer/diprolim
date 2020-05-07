CREATE PROCEDURE `sp_eliminarfamilia` (iFamiliaId int)
BEGIN
	delete from familias where idfamilias = iFamiliaId;
END