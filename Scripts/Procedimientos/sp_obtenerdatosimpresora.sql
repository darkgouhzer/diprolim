-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE PROCEDURE `sp_obtenerdatosimpresora` ()
BEGIN
	SELECT id, Encabezado, Encabezado2, RFC, Direccion, Telefonos, notafinal, ImpresoraTicket FROM datosticket limit 1;
END