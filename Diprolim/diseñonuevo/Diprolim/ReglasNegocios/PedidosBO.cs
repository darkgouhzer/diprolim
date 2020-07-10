using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasNegocios
{
    public class PedidosBO
    {
        public PedidosBO()
        {

        }

        public Boolean GuardarPedido(CPedidos objCPedidos)
        {
            Boolean bAllOk = false;
            PedidosDAL objPedidosDAL = new PedidosDAL();
            objPedidosDAL.GuardarPedido(objCPedidos);
            return bAllOk;
        }

        public DataTable ObtenerPedidos(String Status, int EmpleadoID, int ClienteID)
        {
            PedidosDAL objPedidosDAL = new PedidosDAL();
            return objPedidosDAL.ObtenerPedidos(Status, EmpleadoID, ClienteID);
        }

        public CPedidos ObtenerPedido(int PedidoID)
        {
            CPedidos objCPedidos = new CPedidos();
            DataTable dtPedido = new DataTable();
            DataTable dtPedidoDetalle = new DataTable();
            PedidosDAL objPedidosDAL = new PedidosDAL();
            List<CPedidosDetalle> objLPedidoDetalle = new List<CPedidosDetalle>();

            dtPedido = objPedidosDAL.ObtenerPedido(PedidoID);

            foreach(DataRow row in dtPedido.Rows)
            {                
                objCPedidos.PedidoID = Convert.ToInt32(row["idpedidos"]);
                objCPedidos.FechaRegistro = Convert.ToDateTime(row["fecha_registro"]);
                objCPedidos.FechaPedido = Convert.ToDateTime(row["fechapedido"]);
                objCPedidos.ClienteID = Convert.ToInt32(row["idclientes"]);
                objCPedidos.Status = Convert.ToBoolean(row["status"]); 
            }
                        
            dtPedidoDetalle = objPedidosDAL.ObtenerPedidoDetalle(PedidoID);
            foreach (DataRow row in dtPedidoDetalle.Rows)
            {
                CPedidosDetalle objCPedidosDetalle = new CPedidosDetalle();

                objCPedidosDetalle.PedidosDetalleID = Convert.ToInt32(row["idpedidosdetalle"]);
                objCPedidosDetalle.PedidosID = Convert.ToInt32(row["idpedidos"]);
                objCPedidosDetalle.CodigoArticulo = Convert.ToInt32(row["articulos_codigo"]);
                objCPedidosDetalle.TipoPrecio = row["tipo_precio"].ToString();
                objCPedidosDetalle.Cantidad = Convert.ToDouble(row["cantidad"]);

                objLPedidoDetalle.Add(objCPedidosDetalle);
            }
            objCPedidos.PedidosDetalle = objLPedidoDetalle;

            return objCPedidos;

        }

        public Boolean FinalizarPedido(int PedidoID)
        {
            PedidosDAL objPedidosDAL = new PedidosDAL();
            return objPedidosDAL.FinalizarPedido(PedidoID);
        }

    }
}
