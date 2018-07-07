-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE PROCEDURE `sp_guardardescuentoenvase` (_id INT, _Litros DOUBLE, _Porcentaje INT)
BEGIN
	DECLARE cont INT DEFAULT 0;
	SELECT count(id) FROM DescuentoCambioEnvase WHERE id = _id INTO cont;
	
	IF cont>0 THEN
		UPDATE DescuentoCambioEnvase SET Litros = _Litros, Porcentaje = _Porcentaje WHERE id = _id;
	ELSE
		INSERT INTO DescuentoCambioEnvase (Litros, Porcentaje)
		VALUES(_Litros, _Porcentaje);
	END IF;          
END