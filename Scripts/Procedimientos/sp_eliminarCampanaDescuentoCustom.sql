CREATE PROCEDURE `sp_eliminarCampanaDescuentoCustom` (DescuentoID INT)
BEGIN
 DELETE FROM descuentos_personalizados WHERE iddescuentos_personalizados = DescuentoID;
END