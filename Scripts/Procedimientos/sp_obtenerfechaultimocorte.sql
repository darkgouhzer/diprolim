-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE PROCEDURE sp_obtenerfechaultimocorte()
BEGIN

	SELECT Fecha FROM cortedcaja ORDER BY fecha DESC LIMIT 1 

END