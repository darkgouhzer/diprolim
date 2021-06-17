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

        public void CalcularDescuentos(ref List<CArticulos> objListArticulos, int ClienteID)
        {
            List<CDescuentoCustom> objListCDescuentoCustom = new List<CDescuentoCustom>();
            DescuentosDAL objDescuentosDAL = new DescuentosDAL();
            VentaBO objVentaBO = new VentaBO();
            int nCompraCliente = 0;

            nCompraCliente = objVentaBO.NoCompraCliente(ClienteID)+1;

            objListCDescuentoCustom = objDescuentosDAL.ObtenerTodosDescuentos(Convert.ToInt32(EnumActivoInactivo.Activas)).
                                        Where( obj => obj.NoCompra <= nCompraCliente).ToList<CDescuentoCustom>();
            
            //Llena las cantidades acumuladas para cada camapaña
            foreach(CDescuentoCustom objCDescuentoCustom in objListCDescuentoCustom)
            {
                foreach(CArticulos objArticulos in objListArticulos)
                {
                    if ( objCDescuentoCustom.Presentaciones.Trim().ToString() != String.Empty)
                    {
                        if (ValidarAplicaPresentacion(objArticulos.ValorMedida, objCDescuentoCustom.Presentaciones))
                        {
                            objCDescuentoCustom.CantidadAcumulada = objCDescuentoCustom.CantidadAcumulada + objArticulos.Cantidad;
                        }
                    }
                }
              
            }

            //Descartar campañas que no cumplen el mínimo de compra
            objListCDescuentoCustom.RemoveAll(x => x.CantidadMinima > x.CantidadAcumulada);

            //Mantener campañas de diferentes presentaciones que tienen el mayor porcentaje
            List<CDescuentoCustom> objListCDescuentoCustomAux = new List<CDescuentoCustom>();
            objListCDescuentoCustomAux = objListCDescuentoCustom;
            objListCDescuentoCustom = new List<CDescuentoCustom>();
            foreach (CDescuentoCustom objCDescuentoCustomAux in objListCDescuentoCustomAux)
            {
                var firstElement = objListCDescuentoCustomAux.Where(d => d.Presentaciones == objCDescuentoCustomAux.Presentaciones).
                                                OrderByDescending(x => x.NoCompra).ThenByDescending( x => x.Porcentaje).First();
                if(objListCDescuentoCustom.Where( x=> x.CampanaID == firstElement.CampanaID).Count() == 0)
                {
                    objListCDescuentoCustom.Add(firstElement);
                }
               
            }

            //Asignar descuentos a productos 

            foreach(CArticulos objArticulos in objListArticulos)
            {
                objArticulos.Descuento = 0;
                try
                {
                    objArticulos.Descuento = objListCDescuentoCustom.Where(x => ObtenerPresentacionesSplit(x.Presentaciones).
                                                                   Contains(objArticulos.ValorMedida.ToString())).First().Porcentaje;
                }catch{}
           
            }


            //return objListArticulos;
        }

        public Boolean ValidarAplicaPresentacion(double ValorPresentacion, String sPresentaciones)
        {
            Boolean bAllOK = false;
            List<String> listPresentaciones = ObtenerPresentacionesSplit(sPresentaciones);
            foreach(String objPresentacion in listPresentaciones)
            {
                if(ValorPresentacion == Convert.ToDouble(objPresentacion))
                {
                    bAllOK = true;
                }
            }

            return bAllOK;
        }
       
    }
}
