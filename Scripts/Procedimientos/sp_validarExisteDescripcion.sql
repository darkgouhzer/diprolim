CREATE PROCEDURE `sp_validarExisteDescripcion` (sDescripcion VARCHAR(50), DescripcionID INT)
BEGIN
	select descripcion from articulosdescripciones WHERE TRIM(descripcion) = TRIM(sDescripcion) AND  iddescripcion <> DescripcionID;
END