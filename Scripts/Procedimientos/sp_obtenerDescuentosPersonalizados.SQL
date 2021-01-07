CREATE PROCEDURE `sp_obtenerDescuentosPersonalizados` (nCompra INT, iCantMin INT)
BEGIN
SELECT * FROM descuentos_personalizados WHERE no_compra <= nCompra AND cantidad_minima <=iCantMin AND activa =TRUE ORDER BY porcentaje DESC;
END