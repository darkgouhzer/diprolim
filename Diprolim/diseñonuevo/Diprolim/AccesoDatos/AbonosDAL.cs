using ConexionConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicaSQL;
namespace AccesoDatos
{
    public class AbonosDAL
    {
        DBMS_Unico objConexion;
        GetConexion objGetConexion;
        String cmd;
        public AbonosDAL()
        {
            cmd = string.Empty;
            objGetConexion = GetConexion.Instance;
            objConexion = new DBMS_Unico(objGetConexion.getObj.Gestor, objGetConexion.getObj.Servidor,
                            objGetConexion.getObj.BaseDeDatos, objGetConexion.getObj.Usuarios, objGetConexion.getObj.Password,
                            objGetConexion.getObj.Puerto);
        }

        public DataTable ConsultarAbonos(DateTime dFecha, String sIDVendedor, String sIDCliente)
        {
            DataTable dt = new DataTable();
            if (sIDVendedor.Trim().Length > 0 && sIDCliente.Trim().Length > 0)
            {
                // Consulta para obtener filtrando por vendedor y cliente para mostrar por articulos
                cmd = String.Format("SELECT a.idAbonos AS IDAbonos, a.clientes_idclientes AS ClienteID, a.Folio, "+
                "art.Descripcion AS Descripcion, a.abono AS Abono, a.fecha AS Fecha FROM abonos a " +
                " LEFT JOIN articulos art ON art.codigo = a.articulos_codigo " +
                    " LEFT JOIN clientes c ON a.clientes_idclientes = c.idclientes WHERE a.empleados_id_empleado = {1} " +
                    " AND a.clientes_idclientes ={2} AND cast(a.fecha AS DATE) = cast('{0}' AS DATE) " +
                    " ORDER BY a.folio DESC;", dFecha.ToString("yyyyMMdd000000"),
                    sIDVendedor, sIDCliente);
            }
            else if (sIDVendedor.Trim().Length > 0 && sIDCliente.Trim().Length == 0)
            {
                // Consulta para obtener Vendedor para mostrar por clientes
                cmd = String.Format("SELECT a.clientes_idclientes AS ClienteID, c.nombre AS Nombre, sum(a.abono) AS Abono, "+
                    " a.fecha AS Fecha FROM abonos a LEFT JOIN articulos art on art.codigo = a.articulos_codigo " +
                    "LEFT JOIN clientes c on a.clientes_idclientes = c.idclientes WHERE a.empleados_id_empleado = {1} " +
                    " AND cast(a.fecha as date) = cast('{0}' AS DATE) GROUP BY a.clientes_idclientes " +
                    " ORDER BY a.folio DESC;", dFecha.ToString("yyyyMMdd000000"),
                    sIDVendedor);
            }
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref dt);
            objConexion.Desconectarse();
            return dt;
        }

        public Boolean CancelarAbono(int IDAbono)
        {
            Boolean bAllOK = false;
            DataTable dtResultados = new DataTable();
            objConexion.Conectarse();
            objConexion.IniciarTransaccion();
            cmd = String.Format("SELECT abono,ventas_idventas FROM abonos where idabonos = {0};",IDAbono);
            bAllOK = objConexion.Ejecutar(cmd,ref dtResultados);
            if(dtResultados.Rows.Count>0)
            {
                DataRow row = dtResultados.Rows[0];
                Double abono = Convert.ToDouble(row["abono"]);
                int IDVenta = Convert.ToInt32(row["ventas_idventas"]);
                cmd = String.Format("UPDATE ventas SET pendiente = pendiente + {0} WHERE idventas= {1};",abono,IDVenta);
                bAllOK = objConexion.Ejecutar(cmd);
                if (bAllOK)
                {
                    cmd = String.Format("DELETE FROM abonos WHERE idabonos = {0};", IDAbono);
                    bAllOK = objConexion.Ejecutar(cmd);
                }                
            }            
            objConexion.FinTransaccion(bAllOK);
            objConexion.Desconectarse();
            return bAllOK;
        }
        public Boolean CancelarAbono(int ClienteID, DateTime Fecha)
        {
            Boolean bAllOK = false;
            DataTable dtResultados = new DataTable();
            int IDAbonos = 0;
            int IDVenta = 0;
            double dAbono = 0;
            objConexion.Conectarse();
            objConexion.IniciarTransaccion();
            cmd = String.Format("SELECT  idAbonos, ventas_idventas, abono  FROM abonos WHERE clientes_idclientes = {0} AND" +
                " Cast(fecha AS DATE) = CAST('{1}' AS DATE);",ClienteID, Fecha.ToString("yyyyMMdd"));
            objConexion.Ejecutar(cmd, ref dtResultados);
            if (dtResultados.Rows.Count > 0)
            {
                foreach (DataRow row in dtResultados.Rows)
                {
                    IDAbonos = Convert.ToInt32(row["idAbonos"]);
                    IDVenta = Convert.ToInt32(row["ventas_idventas"]);
                    dAbono = Convert.ToDouble(row["abono"]);
                    cmd = String.Format("UPDATE ventas SET pendiente = pendiente + {0} WHERE idventas= {1};", dAbono, IDVenta);
                    bAllOK = objConexion.Ejecutar(cmd);
                    if (bAllOK)
                    {
                        cmd = String.Format("DELETE FROM abonos WHERE idabonos = {0};", IDAbonos);
                        bAllOK = objConexion.Ejecutar(cmd);
                    }
                }
            }
            objConexion.FinTransaccion(bAllOK);
            objConexion.Desconectarse();
            return bAllOK;
        }
    }
}
