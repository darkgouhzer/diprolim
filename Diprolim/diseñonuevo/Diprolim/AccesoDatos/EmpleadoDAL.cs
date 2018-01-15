using Identidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class EmpleadoDAL
    {
        UnicaSQL.DBMS_Unico objConexion;
        String cmd;
        public EmpleadoDAL()
        {
            cmd = string.Empty;
            objConexion = new UnicaSQL.DBMS_Unico(Conexion.Default.GestorBD, Conexion.Default.Server,
                            Conexion.Default.BaseDatos, Conexion.Default.Usuario, Conexion.Default.Password,
                            Conexion.Default.Puerto);  
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
    }
}
