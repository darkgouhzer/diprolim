using ConexionConfig;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicaSQL;

namespace AccesoDatos
{
    public class ClienteDAL
    {
        DBMS_Unico objConexion;
        GetConexion objGetConexion;
        String cmd;
        public ClienteDAL()
        {
            cmd = string.Empty;
            objGetConexion = GetConexion.Instance;
            objConexion = new DBMS_Unico(objGetConexion.getObj.Gestor, objGetConexion.getObj.Servidor,
                            objGetConexion.getObj.BaseDeDatos, objGetConexion.getObj.Usuarios, objGetConexion.getObj.Password,
                            objGetConexion.getObj.Puerto);
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

