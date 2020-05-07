CREATE PROCEDURE `sp_agregarproductodescripcion` (sDescripcion varchar(50))
BEGIN	
    INSERT INTO articulosdescripciones(descripcion) values(sDescripcion);    
END