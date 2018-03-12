-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE PROCEDURE `sp_corteindividual`(_idEmpleado INT, _dVentasTotales Double,
	_dIVA double, _dRecuperado Double, _dFiado Double, _dGastos Double, _dEfectivoEntrega double,
	_sConcepto TEXT, _dtFecha DATETIME)
BEGIN
	
		DELETE FROM cortedcaja WHERE empleados_id_empleado = _idEmpleado and
			CAST(fecha AS DATE ) = CAST(_dtFecha AS DATE);
		INSERT INTO cortedcaja (empleados_id_empleado, Ventas_Totales, Recuperado, Fiado, Gastos, 
															Concepto, EfectivoAEntregar, Fecha, Iva)
			VALUES(_idEmpleado, _dVentasTotales, _dRecuperado, _dFiado, _dGastos, _sConcepto, _dEfectivoEntrega,
						_dtFecha, _dIVA);

END