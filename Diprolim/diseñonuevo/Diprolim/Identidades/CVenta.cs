using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identidades
{
    public class CVenta
    {
        private int idVentas;
        public int IDVentas
        {
            get { return idVentas; }
            set { idVentas = value; }
        }

        private int idEmpleado;
        public int IDEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }


        private int idClientes;
        public int IDClientes
        {
            get { return idClientes; }
            set { idClientes = value; }
        }
        private int idCategorias;
        public int IDCategorias
        {
            get { return idCategorias; }
            set { idCategorias = value; }
        }
        private int iCodigo;
        public int CodigoArticulo
        {
            get { return iCodigo; }
            set { iCodigo = value; }
        }
        private double precioArticulo;
        public double PrecioArticulo
        {
            get { return precioArticulo; }
            set { precioArticulo = value; }
        }
        private double iCantidad;
        public double Cantidad
        {
            get { return iCantidad; }
            set { iCantidad = value; }
        }

        private double dImporte;
        public double Importe
        {
            get { return dImporte; }
            set { dImporte = value; }
        }

        private DateTime fechaVenta;
        public DateTime FechaVenta
        {
            get { return fechaVenta; }
            set { fechaVenta = value; }
        }
        private double dComision;
        public double Comision
        {
            get { return dComision; }
            set { dComision = value; }
        }

        private double dCostoProduccion;
        public double CostoProduccion
        {
            get { return dCostoProduccion; }
            set { dCostoProduccion = value; }
        }

        private double iva;
        public double IVA
        {
            get { return iva; }
            set { iva = value; }
        }

        private string sTipoCompra;
        public string TipoCompra
        {
            get { return sTipoCompra; }
            set { sTipoCompra = value; }
        }

        private int iFolio;
        public int Folio
        {
            get { return iFolio; }
            set { iFolio = value; }
        }

        private double dPendiente;
        public double Pendiente
        {
            get { return dPendiente; }
            set { dPendiente = value; }
        }

        private double dDescuento;
        public double Descuento
        {
            get { return dDescuento; }
            set { dDescuento = value; }
        }
    }
}
