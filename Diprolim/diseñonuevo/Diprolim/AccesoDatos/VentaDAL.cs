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
    public class VentaDAL
    {
        DBMS_Unico objConexion;
        GetConexion objGetConexion;
        String cmd;
        public VentaDAL()
        {
            cmd = string.Empty;
            objGetConexion = GetConexion.Instance;
            objConexion = new DBMS_Unico(objGetConexion.getObj.Gestor, objGetConexion.getObj.Servidor,
                            objGetConexion.getObj.BaseDeDatos, objGetConexion.getObj.Usuarios, objGetConexion.getObj.Password,
                            objGetConexion.getObj.Puerto);   
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
        public int RegistrarVenta(DataTable dtDatos)
        {
            int iFolioTicket = 0;
            DataTable dtRespuesta = new DataTable();
            Boolean bAllOk = false;
            if (dtDatos.Rows.Count > 0)
            {
                objConexion.Conectarse();
                objConexion.IniciarTransaccion();
                foreach (DataRow row in dtDatos.Rows)
                {
                    cmd = String.Format("call sp_registrarventa({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                        row[0], row[2], row[3], row[4], row[5],  iFolioTicket, row[6]);
                    objConexion.Ejecutar(cmd, ref dtRespuesta);
                  iFolioTicket =  Convert.ToInt32(dtRespuesta.Rows[0][0]);
                }
                bAllOk = true;
                objConexion.FinTransaccion(bAllOk);
                objConexion.Desconectarse();
            }
            return iFolioTicket;

        }

        public DataTable ObtenerVentasPorTicket(int iFolioTicket)
        {
            DataTable dtRespuesta = new DataTable();
            if (iFolioTicket > 0)
            {
                objConexion.Conectarse();

                cmd = String.Format("call sp_obtenerventasticket({0});",iFolioTicket);
                objConexion.Ejecutar(cmd, ref dtRespuesta);
                objConexion.Desconectarse();
            }
            return dtRespuesta;
        }

        public Boolean CancelarTicket(int iFolioTicket)
        {
            DataTable dtRespuesta = new DataTable();
            Boolean bAllOk = false;
            if (iFolioTicket > 0)
            {
                objConexion.Conectarse();
                cmd = String.Format("call sp_eliminarventaporticket({0})", iFolioTicket);
                bAllOk = objConexion.Ejecutar(cmd);   
                objConexion.Desconectarse();
            }

            return bAllOk;
        }
    }
}
