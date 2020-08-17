using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CArticulos
    {
        private int sCodigo;
        public int Codigo
        {
            get { return sCodigo; }
            set { sCodigo = value; }
        }

        string sDescripcion;
        public string Descripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
        }
        private double dPrecioProduccion;
        public double PrecioProduccion
        {
            get { return dPrecioProduccion; }
            set { dPrecioProduccion = value; }
        }
        private double dCantidad;
        public double Cantidad
        {
            get { return dCantidad; }
            set { dCantidad = value; }
        }
        private double dPrecioCalle;
        public double PrecioCalle
        {
            get { return dPrecioCalle; }
            set { dPrecioCalle = value; }
        }
        private double dPrecioAbarrotes;
        public double PrecioAbarrotes
        {
            get { return dPrecioAbarrotes; }
            set { dPrecioAbarrotes = value; }
        }
        private double dPrecioDistribuidor;
        public double PrecioDistribuidor
        {
            get { return dPrecioDistribuidor; }
            set { dPrecioDistribuidor = value; }
        }
        private int iDepartamento;
        public int Departamento
        {
            get { return iDepartamento; }
            set { iDepartamento = value; }
        }
        private double dDescuento;
        public double Descuento
        {
            get { return dDescuento; }
            set { dDescuento = value; }
        }
        private double dComision;
        public double Comision
        {
            get { return dComision; }
            set { dComision = value; }
        }
        private short iAplicaComision;
        public short AplicaComision
        {
            get { return iAplicaComision; }
            set { iAplicaComision = value; }
        }
        private double iValorMedida;
        public double ValorMedida
        {
            get { return iValorMedida; }
            set { iValorMedida = value; }
        }
        string sUnidadMedida;
        public string UnidadMedida
        {
            get { return sUnidadMedida; }
            set { sUnidadMedida = value; }
        }

        int iIdDescripcion;
        public int IdDescripcion
        {
            get { return iIdDescripcion; }
            set { iIdDescripcion = value; }
        }

        double iPrecioConEnvase;
        public double PrecioConEnvase
        {
            get { return iPrecioConEnvase; }
            set { iPrecioConEnvase = value; }
        }

        int iCodigoEnvase;
        public int CodigoEnvase
        {
            get { return iCodigoEnvase; }
            set { iCodigoEnvase = value; }
        }
    }
}
