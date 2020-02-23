using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasNegocios
{
    public class ArticuloBO
    {
        public ArticuloBO()
        {

        }
        public CArticulos ObtenerDatosArticulo(int iArticulo)
        {
            CArticulos objCArticulos = new CArticulos();
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            objCArticulos = objArticuloDAL.ObtenerDatosArticulo(iArticulo);
            return objCArticulos;
        }
    }
}
