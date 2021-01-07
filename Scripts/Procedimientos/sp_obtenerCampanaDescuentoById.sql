CREATE PROCEDURE `sp_obtenerCampanaDescuentoById` (DescuentoID INT)
BEGIN
	SELECT iddescuentos_personalizados, nombre_campana, no_compra, presentaciones, cantidad_minima, porcentaje, activa
    FROM descuentos_personalizados WHERE iddescuentos_personalizados = DescuentoID;
END