using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CPresentaciones
    {
        private double dValorMedida;

        public double ValorMedida
        {
            get { return dValorMedida; }
            set { dValorMedida = value; }
        }

        private String sNombre;

        public String Nombre
        {
            get { return sNombre; }
            set { sNombre = value; }
        }

        private String sSimbolo;

        public String Simbolo
        {
            get { return sSimbolo; }
            set { sSimbolo = value; }
        }
    }
}
