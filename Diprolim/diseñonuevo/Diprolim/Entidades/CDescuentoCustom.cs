using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CDescuentoCustom
    {
        private int iCampanaID;
        public int CampanaID{
            get { return iCampanaID; }
            set { iCampanaID = value; }
        }
        private String sNombreCampana;
        public String NombreCampana
        {
            get { return sNombreCampana; }
            set { sNombreCampana = value; }
        }

        private int iNoCompra;
        public int NoCompra
        {
            get { return iNoCompra; }
            set { iNoCompra = value; }
        }
        private String sPresentaciones;
        public String Presentaciones
        {
            get { return sPresentaciones; }
            set { sPresentaciones = value; }
        }
        private int iCantidadMinima;
        public int CantidadMinima
        {
            get { return iCantidadMinima; }
            set { iCantidadMinima = value; }
        }
        private double dPorcentaje;
        public double Porcentaje
        {
            get { return dPorcentaje; }
            set { dPorcentaje = value; }
        }
        private Boolean bActiva;
        public Boolean Activa
        {
            get { return bActiva; }
            set { bActiva = value; }
        }
    }
}
