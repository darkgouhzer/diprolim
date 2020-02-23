using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CCancelaAbonos
    {
        private int clienteID;
        public int ClienteID
        {
            get { return clienteID; }
            set { clienteID = value; }
        }
        private int iDAbonos;
        public int IDAbonos
        {
            get { return iDAbonos; }
            set { iDAbonos = value; }
        }
        private DateTime dtFecha;
        public DateTime Fecha
        {
            get { return dtFecha; }
            set { dtFecha = value; }
        }
	    
    }
}
