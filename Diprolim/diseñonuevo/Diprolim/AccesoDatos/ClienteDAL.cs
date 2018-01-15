using Identidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ClienteDAL
    {
        UnicaSQL.DBMS_Unico objConexion;
        String cmd;
        public ClienteDAL()
        {
            cmd = string.Empty;
            objConexion = new UnicaSQL.DBMS_Unico(Conexion.Default.GestorBD, Conexion.Default.Server,
                            Conexion.Default.BaseDatos, Conexion.Default.Usuario, Conexion.Default.Password,
                            Conexion.Default.Puerto);
        }
        public CClientes ObtenerDatosCliente(int iCliente)
        {
            CClientes objCClientes = new CClientes();
            DataTable dtDatos = new DataTable();
            cmd = String.Format("SELECT idclientes, nombre, empleados_id_empleado, categorias_idcategorias, Telefono, FechaIngreso " +
                                 " FROM clientes WHERE idclientes = {0};", iCliente);
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref dtDatos);
            objConexion.Desconectarse();
            if (dtDatos.Rows.Count > 0)
            {
                DataRow row = dtDatos.Rows[0];
                objCClientes.IDClientes = Convert.ToInt32(row["idclientes"]);
                objCClientes.Nombre = row["nombre"].ToString();
                objCClientes.IDEmpleado = Convert.ToInt32(row["empleados_id_empleado"]);
                objCClientes.IDcategorias = Convert.ToInt32(row["categorias_idcategorias"]);
                objCClientes.Telefono = row["Telefono"].ToString();
                objCClientes.FechaIngreso = Convert.ToDateTime(row["FechaIngreso"]);
            }
            return objCClientes;
        }
    }
}

