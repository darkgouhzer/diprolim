CREATE PROCEDURE `sp_nuevacamapadescuento` (iCampanaID INT, vNombreCampana varchar(50), iNoCompra INT, vPresentaciones VARCHAR(100), iCantidadMinima INT, dPorcentaje DOUBLE, bActiva BOOLEAN )
BEGIN
	IF iCampanaID = 0 THEN
		INSERT INTO descuentos_personalizados (nombre_campana, no_compra, presentaciones, cantidad_minima, porcentaje, activa) 
										VALUES(vNombreCampana, iNoCompra, vPresentaciones, iCantidadMinima, dPorcentaje, bActiva);        
    ELSE
		UPDATE descuentos_personalizados SET nombre_campana = vNombreCampana, no_compra = iNoCompra, presentaciones = vPresentaciones,
										cantidad_minima = iCantidadMinima, porcentaje = dPorcentaje, activa = bActiva WHERE iddescuentos_personalizados = iCampanaID; 
    END IF;
    
END