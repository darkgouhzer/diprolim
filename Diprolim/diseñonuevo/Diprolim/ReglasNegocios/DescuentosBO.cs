using AccesoDatos;
using Entidades;
using Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasNegocios
{
    public class DescuentosBO
    {
        public DescuentosBO()
        {

        }


        public Boolean GuardarDescuentoCustom(CDescuentoCustom objDescuentoCustom)
        {
            DescuentosDAL objDescuentodsDAL = new DescuentosDAL();
            return objDescuentodsDAL.GuardarDescuentoCustom(objDescuentoCustom);
        }

        public Boolean EliminarDescuentoCustom(int DescuentoID)
        {
            DescuentosDAL objDescuentodsDAL = new DescuentosDAL();
            return objDescuentodsDAL.EliminarDescuentoCustom(DescuentoID);
        }

        public List<CDescuentoCustom> ObtenerTodosDescuentos(int filtro)
        {
            DescuentosDAL objDescuentosDAL = new DescuentosDAL();
            return objDescuentosDAL.ObtenerTodosDescuentos(filtro);
        }

        public CDescuentoCustom ObtenerDescuentoPorID(int CampanaID)
        {
            DescuentosDAL objDescuentosDAL = new DescuentosDAL();
            return objDescuentosDAL.ObtenerDescuentoPorID(CampanaID);
        }

        public List<String> ObtenerPresentacionesSplit(String Presentaciones)
        {
            List<String> listPresentaciones = new List<string>();
            var presentaciones = Presentaciones.Split('|');
            foreach(String obj in presentaciones)
            {
                listPresentaciones.Add(obj);
            }

            return listPresentaciones;
        }

        public List<CDescuentoCustom> ObtenerDescuentosACalcular(int nCompra, int iCantMin)
        {
            DescuentosDAL objDescuentosDAL = new DescuentosDAL();
            return objDescuentosDAL.ObtenerDescuentosACalcular(nCompra, iCantMin);
        }

        public List<CArticulos> CalcularDescuentos(List<CArticulos> objListArticulos, int ClienteID)
        {
            List<CDescuentoCustom> objListCDescuentoCustom = new List<CDescuentoCustom>();
            DescuentosDAL objDescuentosDAL = new DescuentosDAL();
            VentaBO objVentaBO = new VentaBO();
            int nCompraCliente = 0;

            nCompraCliente = objVentaBO.NoCompraCliente(ClienteID)+1;

            objListCDescuentoCustom = objDescuentosDAL.ObtenerTodosDescuentos(Convert.ToInt32(EnumActivoInactivo.Activas)).
                                        Where( obj => obj.NoCompra <= nCompraCliente).ToList<CDescuentoCustom>();


            
            return objListArticulos;
        }

       
    }
}
