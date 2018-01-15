using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasNegocios
{
    public class VentaBO
    {
        public VentaBO()
        {

        }
        public Boolean AplicaIVA(int iFolioVenta)
        {
            Boolean bAllOK = false;
            VentaDAL objVentaDAL = new VentaDAL();
            bAllOK = objVentaDAL.aplicaIVA(iFolioVenta);
            return bAllOK;
        }
        public void ReAsignarDeudas()
        {
            VentaDAL objVentaDAL = new VentaDAL();
            objVentaDAL.ReAsignarDeudas();
        }
    }
}
