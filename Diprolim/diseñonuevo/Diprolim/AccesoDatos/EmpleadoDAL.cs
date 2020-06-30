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
    public class EmpleadoDAL
    {
        DBMS_Unico objConexion;
        GetConexion objGetConexion;
        String cmd;
        public EmpleadoDAL()
        {
            cmd = string.Empty;
            objGetConexion = GetConexion.Instance;
            objConexion = new DBMS_Unico(objGetConexion.getObj.Gestor, objGetConexion.getObj.Servidor,
                            objGetConexion.getObj.BaseDeDatos, objGetConexion.getObj.Usuarios, objGetConexion.getObj.Password,
                            objGetConexion.getObj.Puerto);   
        }

        public CEmpleados ObtenerDatosVendedor(int iVendedor)
        {
            CEmpleados objCEmpleados = new CEmpleados();
            DataTable dtDatos =new DataTable();
            cmd = String.Format("SELECT e.id_empleado, e.nombre, e.apellido_paterno, e.apellido_materno, e.fecha_nacimiento, " +
                                "e.Puestos_idPuestos, e.limite_inv, e.limite_credito, e.Status, p.nombre as NombrePuesto " +
                                "FROM empleados e, puestos p where id_empleado={0}  AND e.Puestos_idPuestos=p.idPuestos;",iVendedor);
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref dtDatos);
            objConexion.Desconectarse();
            if(dtDatos.Rows.Count>0)
            {
                DataRow row = dtDatos.Rows[0];
                objCEmpleados.IDEmpleado = Convert.ToInt32(row["id_empleado"]);
                objCEmpleados.Nombre = row["nombre"].ToString();
                objCEmpleados.ApellidoPaterno = row["apellido_paterno"].ToString();
                objCEmpleados.ApellidoMaterno = row["apellido_materno"].ToString();
                objCEmpleados.FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]);
                objCEmpleados.IDPuestos = Convert.ToInt32(row["Puestos_idPuestos"]);
                objCEmpleados.LimiteInventario = Convert.ToDouble(row["limite_inv"]);
                objCEmpleados.LimiteCredito = Convert.ToDouble(row["limite_credito"]);
                objCEmpleados.Status = row["Status"].ToString();
                objCEmpleados.TipoVendedor = row["NombrePuesto"].ToString();
            }
            return objCEmpleados;
        }

        public Double ObtenerInvVendedorArticulo(int iEmpleadoID, int iCodigoArticulo)
        {
            DataTable tblCantidad = new DataTable();
            Double CantidadInventario = 0;
            objConexion.Conectarse();
            cmd = String.Format("call sp_obtenerInvVendedorArticulo({0},{1});", iEmpleadoID, iCodigoArticulo);
            objConexion.Ejecutar(cmd, ref tblCantidad);
            objConexion.Desconectarse();
            if(tblCantidad.Rows.Count > 0)
            {
                DataRow row = tblCantidad.Rows[0];
                CantidadInventario = Convert.ToDouble(row[0]);
            }
            else
            {
                CantidadInventario = 0;
            }

            return CantidadInventario;
        }
        
    }
}
