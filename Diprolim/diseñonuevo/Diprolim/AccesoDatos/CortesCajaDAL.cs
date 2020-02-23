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
    public class CortesCajaDAL
    {
        UnicaSQL.DBMS_Unico objConexion;
        GetConexion objGetConexion;
        String cmd;
        public CortesCajaDAL()
        {
            cmd = string.Empty;
            objGetConexion = GetConexion.Instance;
            objConexion = new DBMS_Unico(objGetConexion.getObj.Gestor, objGetConexion.getObj.Servidor,
                            objGetConexion.getObj.BaseDeDatos, objGetConexion.getObj.Usuarios, objGetConexion.getObj.Password,
                            objGetConexion.getObj.Puerto);    
        }
        public DataTable PreGenerarCorteGeneral(DateTime dFecha)
        {
            DataTable dt = new DataTable();
            cmd = String.Format("call sp_obtenercortesucursaltemporal( CAST('{0}' AS DATETIME));", dFecha.ToString("yyyyMMddHHmmss"));
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref dt);
            objConexion.Desconectarse();
            return dt;
        }
        public DataTable GenerarCorteGeneral(DateTime dFecha)
        {
            DataTable dt = new DataTable();
            cmd = String.Format("call sp_cortesucursal( CAST('{0}' AS DATETIME));", dFecha.ToString("yyyyMMddHHmmss"));            
            objConexion.Conectarse();            
            objConexion.Ejecutar(cmd, ref dt);
            objConexion.Desconectarse();
            return dt;
        }

        public Boolean GenerarCorteIndividual(CCorteIndividual objCCorteIndividual)
        {
            Boolean bAllOK = false;
            cmd = String.Format("call sp_corteindividual( {0}, {1}, {2}, {3}, {4}, {5}, {6}, '{7}', CAST('{8}' AS DATETIME));",objCCorteIndividual.IDEmpleado, 
                                objCCorteIndividual.VentasTotales, objCCorteIndividual.IVA, objCCorteIndividual.Recuperado, objCCorteIndividual.Fiado,
                                objCCorteIndividual.Gastos, objCCorteIndividual.EfectivoEntrega, objCCorteIndividual.Concepto, objCCorteIndividual.Fecha.ToString("yyyyMMddHHmmss"));
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd);
            objConexion.Desconectarse();
            bAllOK = true;
            return bAllOK;
        }

        public Boolean ObtenerTotalesCorte(int iEmpleado, DateTime dtFecha ,ref DataTable tblResultado)
        {
            Boolean bAllOK = false;

            cmd = String.Format("call sp_totalescorteindividual( {0}, CAST('{1}' AS DATETIME));", iEmpleado, dtFecha.ToString("yyyyMMddHHmmss"));
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref tblResultado);
            objConexion.Desconectarse();
            bAllOK = true;
            return bAllOK;
        }

        public DateTime ObtenerFechaUltimoCorte()
        {
            Boolean bAllOK = false;
            DateTime dtUltimoCorte = new DateTime();
            DataTable dtResultados = new DataTable();

            objConexion.Conectarse();
            objConexion.IniciarTransaccion();
            cmd = String.Format("call sp_obtenerfechaultimocorte();");
            objConexion.Ejecutar(cmd, ref dtResultados);
            if (dtResultados.Rows.Count > 0)
            {
                DataRow row = dtResultados.Rows[0];
                dtUltimoCorte = Convert.ToDateTime(row[0]);
                bAllOK = true;
               
            }
            objConexion.FinTransaccion(bAllOK);
            objConexion.Desconectarse();

            return dtUltimoCorte;
        }
    }
}
