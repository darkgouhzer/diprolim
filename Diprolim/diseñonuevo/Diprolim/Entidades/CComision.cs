using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CComision
    {
        private int idDescuentoComision, iDias, iPorcentaje;
        public int IdDescuentoComision
        {
            get { return idDescuentoComision; }
            set { idDescuentoComision = value; }
        }
        public int Porcentaje
        {
            get { return iPorcentaje; }
            set { iPorcentaje = value; }
        }

        public int Dias
        {
            get { return iDias; }
            set { iDias = value; }
        }
    }
}
