using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CCorteIndividual
    {
        private int idEmpleado;
        private double dVentasTotales;
        private double dIVA;
        private double dRecuperado;
        private double dFiado;
        private double dGastos;
        private double dEfectivoEntrega;
        private String sConcepto;
        private String sNombreVendedor;
        private DateTime dtFecha;

        public int IDEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }
             
        public double VentasTotales
        {
            get { return dVentasTotales; }
            set { dVentasTotales = value; }
        }
        
        public double IVA
        {
            get { return dIVA; }
            set { dIVA = value; }
        }
        
        public double Recuperado
        {
            get { return dRecuperado; }
            set { dRecuperado = value; }
        }
        
        public double Fiado
        {
            get { return dFiado; }
            set { dFiado = value; }
        }
        
        public double Gastos
        {
            get { return dGastos; }
            set { dGastos = value; }
        }        
        
        public double EfectivoEntrega
        {
            get { return dEfectivoEntrega; }
            set { dEfectivoEntrega = value; }
        }
      
        public String Concepto
        {
            get { return sConcepto; }
            set { sConcepto = value; }
        }

        public String NombreVendedor
        {
            get { return sNombreVendedor; }
            set { sNombreVendedor = value; }
        }       
       
        public DateTime Fecha
        {
            get { return dtFecha; }
            set { dtFecha = value; }
        }
    }
}
