CREATE PROCEDURE `sp_obtenerfamilias` ()
BEGIN
	select idfamilias, descripcion from familias;
END