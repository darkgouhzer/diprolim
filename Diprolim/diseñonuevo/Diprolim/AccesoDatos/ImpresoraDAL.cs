using Identidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicaSQL;

namespace AccesoDatos
{
    public class ImpresoraDAL
    {
        DBMS_Unico objConexion;
        String cmd;
        public ImpresoraDAL()
        {
            cmd = string.Empty;
            objConexion = new DBMS_Unico(Conexion.Default.GestorBD, Conexion.Default.Server,
                            Conexion.Default.BaseDatos, Conexion.Default.Usuario, Conexion.Default.Password,
                            Conexion.Default.Puerto); 
        }
        public Boolean GuardarImpresora(CImpresora objCImpresora)
        {
            Boolean bAllOk = false;
           
                objConexion.Conectarse();
                objConexion.IniciarTransaccion();

                cmd = String.Format("call sp_guardarimpresora ('{0}', '{1}', '{2}', '{3}', "+
                                    " '{4}', '{5}', '{6}')", objCImpresora.Encabezado1, objCImpresora.Encabezado2,objCImpresora.RFC,
                                    objCImpresora.Direccion, objCImpresora.Telefonos, objCImpresora.NotaFinal, objCImpresora.Impresora);
                bAllOk = objConexion.Ejecutar(cmd);
                objConexion.FinTransaccion(bAllOk);
                objConexion.Desconectarse();
           
            return bAllOk;
        }

        public CImpresora ObtenerDatosImpresoras()
        {
            CImpresora objCImpresora = new CImpresora();
            Boolean bAllOk = false;
            DataTable dtDatos = new DataTable();
            objConexion.Conectarse();
            objConexion.IniciarTransaccion();
            cmd = String.Format("call sp_obtenerdatosimpresora()");
            bAllOk = objConexion.Ejecutar(cmd, ref dtDatos);
            objConexion.FinTransaccion(bAllOk);
            objConexion.Desconectarse();
            if (dtDatos.Rows.Count > 0)
            {
                DataRow row = dtDatos.Rows[0];
                objCImpresora.ID = Convert.ToInt32(row["id"]);
                objCImpresora.Encabezado1 = row["Encabezado"].ToString();
                objCImpresora.Encabezado2 = row["Encabezado2"].ToString();
                objCImpresora.RFC = row["RFC"].ToString();
                objCImpresora.Direccion = row["Direccion"].ToString();
                objCImpresora.Telefonos = row["Telefonos"].ToString();
                objCImpresora.NotaFinal = row["notafinal"].ToString();
                objCImpresora.Impresora = row["ImpresoraTicket"].ToString();
            }
            return objCImpresora;
        }
        
    }
}
