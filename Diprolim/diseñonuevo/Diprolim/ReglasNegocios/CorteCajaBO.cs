using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Identidades;
namespace ReglasNegocios
{
    public class CorteCajaBO
    {
        public CorteCajaBO()
        {

        }
        public DataTable GenerarCorteGeneral(DateTime dFecha)
        {
            CortesCajaDAL objCortesCajaDAL = new CortesCajaDAL();
            return objCortesCajaDAL.GenerarCorteGeneral(dFecha);
        }

        public Boolean GenerarCorteIndividual(CCorteIndividual objCCorteIndividual)
        {
            CortesCajaDAL objCortesCajaDAL = new CortesCajaDAL();
            return objCortesCajaDAL.GenerarCorteIndividual(objCCorteIndividual);
        }
        public CCorteIndividual ObtenerTotalesCorte(int iEmpleado, DateTime dtFecha)
        {
            CCorteIndividual objCCorteIndividual = new CCorteIndividual();
            CortesCajaDAL objCortesCajaDAL = new CortesCajaDAL();
            DataTable tblResultado = new DataTable();
            objCortesCajaDAL.ObtenerTotalesCorte(iEmpleado, dtFecha, ref tblResultado);

            if (tblResultado.Rows.Count > 0)
            {
                DataRow row = tblResultado.Rows[0];
                objCCorteIndividual.NombreVendedor = row["_NombreEmpleado"].ToString();
                objCCorteIndividual.VentasTotales = Convert.ToDouble(row["_VentasTotales"]);
                objCCorteIndividual.IVA = Convert.ToDouble(row["_IVA"]);
                objCCorteIndividual.Recuperado = Convert.ToDouble(row["_Recuperado"]);
                objCCorteIndividual.Fiado = Convert.ToDouble(row["_Fiado"]);
                objCCorteIndividual.Gastos = Convert.ToDouble(row["_Gastos"]);
                objCCorteIndividual.Concepto = row["_Concepto"].ToString();
                objCCorteIndividual.NombreVendedor = row["_NombreEmpleado"].ToString();
            }
            return objCCorteIndividual;
        }
    }
}
