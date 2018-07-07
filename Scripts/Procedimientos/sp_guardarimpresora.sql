-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE PROCEDURE `sp_guardarimpresora` (sEncabezado1 TEXT, sEncabezado2 TEXT, sRFC VARCHAR(45), sDireccion TEXT, 
 sTelefonos TEXT, sNotaFinal TEXT, sImpresora TEXT)
BEGIN	
	DELETE FROM datosticket;
	INSERT INTO datosticket (id,Encabezado,Encabezado2, RFC,Direccion,Telefonos,notafinal,ImpresoraTicket)
	VALUES(1, sEncabezado1, sEncabezado2, sRFC, sDireccion, sTelefonos, sNotaFinal, sImpresora);
END