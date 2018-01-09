select * from abonos where idAbonos in(17530,17529,17528,17527,17526,17428,17427,17426,17425,17273,17272,17271,17270,
17130,17129,17128,17127,17074,16999,16998,16868,16867,16866,16865,16864,16773,16772,16771,16770,16658,16657,16656,16655,
16570,16569,16568,16567,16486,16442,16441,16440,16439,16380,16379,16378,16377,16317,16316,16315,16191,16190,16189,16188,
16051,16050,16049,16048,16047,15934,15933,15932,15931,15930,15929,15840,15839,15838,15837) order by folio desc limit 10
describe clientes
select * from ventas where idventas= 98876
select * from articulos limit 1
-- Consulta para obtener filtrando por vendedor y cliente para mostrar por articulos
select a.idAbonos, a.Folio, art.descripcion, a.abono, a.fecha,a.clientes_idclientes from abonos a 
left join articulos art on art.codigo = a.articulos_codigo 
left join clientes c on a.clientes_idclientes = c.idclientes where a.empleados_id_empleado = 16 and
 a.clientes_idclientes =1267 and cast(a.fecha as date) = cast('20171103235959' as Date) order by a.folio desc 
-- ----------
-- Consulta para obtener Vendedor para mostrar por clientes
select a.clientes_idclientes, c.nombre, sum(a.abono) as abono , a.fecha from abonos a 
left join articulos art on art.codigo = a.articulos_codigo 
left join clientes c on a.clientes_idclientes = c.idclientes where a.empleados_id_empleado = 16
 and cast(a.fecha as date) = cast('20171103235959' as Date) group by a.clientes_idclientes order by a.folio desc 
-- 
limit 10

USE diprolim
select * from ventas where idventas = 13175
SELECT abono,ventas_idventas FROM abonos where idabonos = [idabono]
UPDATE ventas SET pendiente = [abono] WHERE idventas= [ventas_idventas]
DELETE FROM abonos WHERE idabonos = [idabono]

SELECT  idAbonos, abono, ventas_idventas* FROM abonos WHERE Cast(fecha AS DATE) = CAST('20171103'AS DATE) AND clientes_idclientes = 1078;
select * from ventas where idventas = 96275
SELECT  idAbonos, ventas_idventas, abono  FROM abonos WHERE clientes_idclientes = 1267 AND Cast(fecha AS DATE) = CAST('20171103' AS DATE);
96274
96276
96273
96272
select * from usuarios
Select * from PrivilegiosDeUsuario
SELECT * FROM abonos limit 1
idventas
empleados_id_empleado
clientes_idclientes
categorias_idcategorias
articulos_codigo
precio_art
cantidad
importe
fecha_venta
comision
Costo_Produccion
iva
tipo_compra
folio
pendiente
Descuento