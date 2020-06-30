using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CPedidos
    {
        private int iPedidoID;

        public int PedidoID
        {
            get { return iPedidoID; }
            set { iPedidoID = value; }
        }

        private DateTime dFechaRegistro;

        public DateTime FechaRegistro
        {
            get { return dFechaRegistro; }
            set { dFechaRegistro = value; }
        }


        private DateTime dFechaPedido;

        public DateTime FechaPedido
        {
            get { return dFechaPedido; }
            set { dFechaPedido = value; }
        }

        private int iClienteID;

        public int ClienteID
        {
            get { return iClienteID; }
            set { iClienteID = value; }
        }

        private Boolean bStatus;

        public Boolean Status
        {
            get { return bStatus; }
            set { bStatus = value; }
        }

        private List<CPedidosDetalle> lPedidosDetalle;

        public List<CPedidosDetalle> PedidosDetalle
        {
            get { return lPedidosDetalle; }
            set { lPedidosDetalle = value; }
        }


    }
}
