using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CPedidosDetalle
    {
        private int iPedidosDetalleID;

        public int PedidosDetalleID
        {
            get { return iPedidosDetalleID; }
            set { iPedidosDetalleID = value; }
        }

        private int iPedidosID;

        public int PedidosID
        {
            get { return iPedidosID; }
            set { iPedidosID = value; }
        }

        private int iCodigoArticulo;

        public int CodigoArticulo
        {
            get { return iCodigoArticulo; }
            set { iCodigoArticulo = value; }
        }

        private String sTipoPrecio;

        public String TipoPrecio
        {
            get { return sTipoPrecio; }
            set { sTipoPrecio = value; }
        }

        private double iCantidad;

        public double Cantidad
        {
            get { return iCantidad; }
            set { iCantidad = value; }
        }
    }
}
