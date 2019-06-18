-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE PROCEDURE `sp_eliminarventaporticket` (numeroTicket INT)
BEGIN	
	DECLARE contador INT DEFAULT 0;
	DECLARE iCodigo INT DEFAULT 0;
	DECLARE iCantidad INT DEFAULT 0;
	DECLARE exit_loop BOOLEAN DEFAULT FALSE;

	DECLARE cursorEliminarTicket CURSOR FOR 
	SELECT articulos_codigo, cantidad FROM ventas WHERE folioticket = numeroTicket;
	
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET exit_loop = TRUE;

	OPEN cursorEliminarTicket;
	SELECT COUNT(cantidad) FROM ventas WHERE folioticket = numeroTicket INTO contador;
	WHILE contador > 0 DO
	FETCH cursorEliminarTicket INTO iCodigo, iCantidad;
		UPDATE articulos SET cantidad = cantidad + iCantidad WHERE codigo = iCodigo;
	SET contador = contador-1;
	END WHILE;
	CLOSE cursorEliminarTicket;
	DELETE FROM ventas WHERE folioticket = numeroTicket;
END