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
    public class AbonosBO
    {
        AbonosDAL objAbonosDAL;
        public AbonosBO()
        {

        }
        public DataTable ConsultarAbonos(DateTime dFecha, String sIDVendedor, String sIDCliente)
        {
            DataTable dt = new DataTable();
            objAbonosDAL = new AbonosDAL();
            dt = objAbonosDAL.ConsultarAbonos(dFecha, sIDVendedor, sIDCliente);
            return dt;
        }

        public Boolean CancelarAbono(List<CCancelaAbonos> lsCCancelaAbonos)
        {
            Boolean bAllOK = false;
            CorteCajaBO objCorteCajaBO = new CorteCajaBO();

            foreach(CCancelaAbonos obj in lsCCancelaAbonos)
            {
                if(obj.IDAbonos>0)
                {
                    bAllOK = objAbonosDAL.CancelarAbono(obj.IDAbonos);
                }
                else
                {
                    bAllOK = objAbonosDAL.CancelarAbono(obj.ClienteID, obj.Fecha);
                }               
            }            
            return bAllOK;
        }
    }
}
