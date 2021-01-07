CREATE PROCEDURE `sp_obtenerTodasCampanasDescuento` (filtro INT)
BEGIN
	IF filtro = 0 THEN
		SELECT iddescuentos_personalizados, nombre_campana, no_compra, presentaciones, cantidad_minima, porcentaje, activa
		FROM descuentos_personalizados;
    END IF;
    IF filtro =1 THEN
		SELECT iddescuentos_personalizados, nombre_campana, no_compra, presentaciones, cantidad_minima, porcentaje, activa
		FROM descuentos_personalizados WHERE activa = 1;
    END IF;
    
     IF filtro =2 THEN
		SELECT iddescuentos_personalizados, nombre_campana, no_compra, presentaciones, cantidad_minima, porcentaje, activa
		FROM descuentos_personalizados WHERE activa = 0;
    END IF;
END