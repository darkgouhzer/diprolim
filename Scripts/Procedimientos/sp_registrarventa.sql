CREATE PROCEDURE sp_registrarventa(iCodigoArticulo INT,  dCantidad DOUBLE, dPrecioArticulo DOUBLE, dDescuento DOUBLE, 
                                dImporte DOUBLE, iFolioTicket INT)
BEGIN
DECLARE dIVA DOUBLE DEFAULT 0;
DECLARE dCostoProduccion DOUBLE DEFAULT 0;

SELECT precioproduccion FROM articulos WHERE codigo = iCodigoArticulo INTO dCostoProduccion;
SELECT dImporte - (dImporte/1.16) INTO dIVA;

IF iFolioTicket = 0 THEN
SELECT ifnull(max(folioticket)+1,1) FROM ventas INTO iFolioTicket;
END IF;

INSERT INTO ventas (empleados_id_empleado, clientes_idclientes, categorias_idcategorias, articulos_codigo, 
                    precio_art, cantidad, importe, fecha_venta, comision, Costo_Produccion, iva, 
                    tipo_compra, folio, pendiente, Descuento, folioticket )
            VALUES(1, 1, 9, iCodigoArticulo, dPrecioArticulo, dCantidad, dImporte, now(), 0, dCostoProduccion,
                    dIVA, 'contado', 0, 0, 0,iFolioTicket);

UPDATE articulos SET cantidad = cantidad - dCantidad WHERE  codigo = iCodigoArticulo;

SELECT iFolioTicket;
END