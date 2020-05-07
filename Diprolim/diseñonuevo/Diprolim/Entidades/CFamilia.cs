using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CFamilia
    {
        private int idfamilia;
        public int IDFamilia
        {
            get { return idfamilia; }
            set { idfamilia = value; }
        }
        private String descripcion;
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
