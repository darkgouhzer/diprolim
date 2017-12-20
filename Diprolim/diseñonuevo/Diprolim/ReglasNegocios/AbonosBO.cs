using AccesoDatos;
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
        public DataTable ConsultarAbonos()
        {
            DataTable dt = new DataTable();
            objAbonosDAL = new AbonosDAL();
            dt = objAbonosDAL.ConsultarAbonos();
            return dt;
        }

        public Boolean CancelarAbono()
        {
            Boolean bAllOK = false;
            objAbonosDAL = new AbonosDAL();
            bAllOK = objAbonosDAL.CancelarAbono();
            return bAllOK;
        }
    }
}
