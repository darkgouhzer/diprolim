using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class VentaDAL
    {
        UnicaSQL.DBMS_Unico objConexion;
        String cmd;
        public VentaDAL()
        {
            cmd = string.Empty;
            objConexion = new UnicaSQL.DBMS_Unico(Conexion.Default.GestorBD, Conexion.Default.Server,
                            Conexion.Default.BaseDatos, Conexion.Default.Usuario, Conexion.Default.Password,
                            Conexion.Default.Puerto);  
        }
        public Boolean aplicaIVA(int iFolioVenta)
        {
            Boolean bAllOK =false;
            DataTable dtDatos = new DataTable();
            cmd = String.Format("SELECT iva FROM ventas WHERE idventas = {0}",iFolioVenta);
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref dtDatos);
            objConexion.Desconectarse();
            if(dtDatos.Rows.Count>0)
            {
                DataRow row = dtDatos.Rows[0];
                if(Convert.ToDouble(row["iva"])>0)
                {
                    bAllOK = true;
                }
            }
            return bAllOK;
        }
        public void ReAsignarDeudas()
        {

            cmd = String.Format("UPDATE ventas SET empleados_id_empleado = 1 WHERE DATEDIFF(now(), fecha_venta )>(SELECT coalesce( sum( dias ) , 0 ) AS dias " +
                " FROM descuentocomision WHERE porcentaje =100) and pendiente>0");
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd);
            objConexion.Desconectarse();
        }
    }
}
