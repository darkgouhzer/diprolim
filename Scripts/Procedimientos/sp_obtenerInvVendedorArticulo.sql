CREATE PROCEDURE `sp_obtenerInvVendedorArticulo` (EmpleadoID INT , iCodigoArticulo  INT )
BEGIN
		SELECT cantidad FROM inv_vendedor WHERE empleados_id_empleado = EmpleadoID AND articulos_codigo = iCodigoArticulo ;
END