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
    public class PedidosDAL
    {
        DBMS_Unico objConexion;
        GetConexion objGetConexion;
        String cmd;
        public PedidosDAL()
        {
            cmd = string.Empty;
            objGetConexion = GetConexion.Instance;
            objConexion = new DBMS_Unico(objGetConexion.getObj.Gestor, objGetConexion.getObj.Servidor,
                            objGetConexion.getObj.BaseDeDatos, objGetConexion.getObj.Usuarios, objGetConexion.getObj.Password,
                            objGetConexion.getObj.Puerto);
        }

        public Boolean GuardarPedido(CPedidos objCPedidos)
        {
            Boolean bAllOk = false;
            DataTable tblPedido = new DataTable();
            int PedidoID = 0;
            objConexion.Conectarse();
            objConexion.IniciarTransaccion();

            cmd = String.Format("call sp_guardarPedido ({0}, '{1}', {2})",
                    objCPedidos.PedidoID, objCPedidos.FechaPedido.ToString("yyyyMMddhhmmss"), objCPedidos.ClienteID);
            objConexion.Ejecutar(cmd, ref tblPedido);

            PedidoID = Convert.ToInt32(tblPedido.Rows[0][0]);

            foreach (CPedidosDetalle pedidodetalle in objCPedidos.PedidosDetalle)
            {
                cmd = String.Format("call sp_guardarPedidoDetalle ({0}, {1}, '{2}', {3})",
                    PedidoID, pedidodetalle.CodigoArticulo, pedidodetalle.TipoPrecio, pedidodetalle.Cantidad);
                objConexion.Ejecutar(cmd);
            }
            bAllOk = true;
            objConexion.FinTransaccion(bAllOk);
            objConexion.Desconectarse();

            return bAllOk;
        }

        public DataTable ObtenerPedidos(String Status, int EmpleadoID, int ClienteID)
        {
            DataTable dtRespuesta = new DataTable();
           
            objConexion.Conectarse();

            cmd = String.Format("call sp_obtenerPedidos('{0}', {1}, {2})", Status, EmpleadoID, ClienteID);
            objConexion.Ejecutar(cmd, ref dtRespuesta);
            objConexion.Desconectarse();
            return dtRespuesta;
        }

        public DataTable ObtenerPedido(int PedidoID)
        {
            DataTable dtRespuesta = new DataTable();

            objConexion.Conectarse();

            cmd = String.Format("call sp_obtenerPedido({0})", PedidoID);
            objConexion.Ejecutar(cmd, ref dtRespuesta);
            objConexion.Desconectarse();
            return dtRespuesta;
        }
        public DataTable ObtenerPedidoDetalle(int PedidoID)
        {
            DataTable dtRespuesta = new DataTable();

            objConexion.Conectarse();

            cmd = String.Format("call sp_obtenerPedidoDetalle({0})", PedidoID);
            objConexion.Ejecutar(cmd, ref dtRespuesta);
            objConexion.Desconectarse();
            return dtRespuesta;
        }

        public Boolean FinalizarPedido(int PedidoID)
        {
            Boolean bAllOk = false;

            objConexion.Conectarse();
            cmd = String.Format("call sp_finalizarPedido({0})", PedidoID);
            bAllOk = objConexion.Ejecutar(cmd);
            objConexion.Desconectarse();
            return bAllOk;
        }

        
    }
}
