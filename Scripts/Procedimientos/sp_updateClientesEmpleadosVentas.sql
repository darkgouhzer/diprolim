CREATE PROCEDURE `sp_updateClientesEmpleadosVentas` ()
BEGIN
	DECLARE ClienteID INT;
    DECLARE EmpleadoID INT;
    DECLARE done INT DEFAULT FALSE;
	DECLARE curClientes CURSOR FOR SELECT idclientes, empleados_id_empleado FROM clientes;
   DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = TRUE;
    
    OPEN curClientes;
     c1_loop: LOOP
		FETCH curClientes
		INTO ClienteID, EmpleadoID;
		IF `done` THEN LEAVE c1_loop; END IF; 
		UPDATE ventas SET empleados_id_empleado = EmpleadoID WHERE clientes_idclientes = ClienteID;
    END LOOP c1_loop;
    CLOSE curClientes;
    
END