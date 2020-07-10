using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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

        public Boolean AgregarFamilia(String sDescripcion)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.AgregarFamilia(sDescripcion);
        }

        public DataTable ObtenerFamilias()
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.ObtenerFamilias();
        }

        public Boolean EliminarFamilias(int[] aFamiliasID)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.EliminarFamilias(aFamiliasID);            
        }

        public Boolean actualizarFamilias(List<CFamilia> listFamilias)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.actualizarFamilias(listFamilias);
        }

        public Boolean ValidarProductoProduccion(int codigoProducto)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.ValidarProductoProduccion(codigoProducto);
        }

        public Boolean AgregarDescripcionProducto(String sDescripcion)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.AgregarDescripcionProducto(sDescripcion);
        }

        public DataTable ObtenerDescripcionesProductos(String filtro)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.ObtenerDescripcionesProductos(filtro);
        }

        public Boolean EliminarDescripcionProducto(int[] aDescripcionID)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.EliminarDescripcionProducto(aDescripcionID);
        }

        public Boolean actualizarDescripcionProducto(List<CFamilia> listDescProducto)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.actualizarDescripcionProducto(listDescProducto);
        }

        public DataTable ObtenerDescripcionesProductosById(int iDescripcionId)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.ObtenerDescripcionesProductosById(iDescripcionId);
        }

        public Boolean ValidarTransfProduccion(int iDescripcionId)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.ValidarTransfProduccion(iDescripcionId);
        }

        public Double ObtenerExistenciasProduccion(int DescripcionID)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            return objArticuloDAL.ObtenerExistenciasProduccion(DescripcionID);
        }

        public Boolean ValidarExisteDescripcionAGranel(int DescripcionID, int UnidadMedidaID, double ValorMedida, String tipoGuardado)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            Boolean bAllOk = false;
            if( tipoGuardado == "UPDATE")
            {
                if(objArticuloDAL.ValidarExisteDescripcionAGranel(DescripcionID, UnidadMedidaID, ValorMedida) > 1)
                {
                    bAllOk = true;
                }
                
            }
            else
            {
                if (objArticuloDAL.ValidarExisteDescripcionAGranel(DescripcionID, UnidadMedidaID, ValorMedida) > 0)
                {
                    bAllOk = true;
                }
            }
            return bAllOk;
        }

        public Boolean ValidarExisteDescripcionProducto(String Descripcion, Int32 DescripcionID)
        {
            ArticuloDAL objArticuloDAL = new ArticuloDAL();
            Boolean bAllOk = false;
        
            if (objArticuloDAL.ValidarExisteDescripcionProducto(Descripcion, DescripcionID) > 0)
            {
                bAllOk = true;
            }
           
            return bAllOk;
        }
    }
}
