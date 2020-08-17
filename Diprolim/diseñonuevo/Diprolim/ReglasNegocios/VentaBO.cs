using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public int RegistrarVenta(DataGridView dgDatos)
        {
            VentaDAL objVentaDAL = new VentaDAL();
            DataTable dtDatos = new DataTable();

            dtDatos.Columns.Add(dgDatos.Columns[0].HeaderText, typeof(Int32));
            dtDatos.Columns.Add(dgDatos.Columns[1].HeaderText, typeof(String));
            dtDatos.Columns.Add(dgDatos.Columns[2].HeaderText, typeof(Double));
            dtDatos.Columns.Add(dgDatos.Columns[3].HeaderText, typeof(Double));
            dtDatos.Columns.Add(dgDatos.Columns[4].HeaderText, typeof(Double));
            dtDatos.Columns.Add(dgDatos.Columns[5].HeaderText, typeof(Double));
            dtDatos.Columns.Add(dgDatos.Columns[6].HeaderText, typeof(Boolean));

            foreach (DataGridViewRow rowGrid in dgDatos.Rows)
            {
                DataRow row = dtDatos.NewRow();
                row[0] = Convert.ToInt32(rowGrid.Cells[0].Value);
                row[1] = rowGrid.Cells[1].Value.ToString();
                row[2] = Convert.ToDouble(rowGrid.Cells[2].Value);
                row[3] = Double.Parse(rowGrid.Cells[3].Value.ToString(), NumberStyles.Currency);
                row[4] = Double.Parse(rowGrid.Cells[4].Value.ToString(), NumberStyles.Currency);
                row[5] = Double.Parse(rowGrid.Cells[5].Value.ToString(), NumberStyles.Currency);
                row[6] = Convert.ToBoolean(rowGrid.Cells[6].Value);
                dtDatos.Rows.Add(row);
            }
            
            return objVentaDAL.RegistrarVenta(dtDatos);
        }
        public DataTable ObtenerVentasPorTicket(int iFolioTicket){
            return new VentaDAL().ObtenerVentasPorTicket(iFolioTicket);
        }

        public Boolean CancelarTicket(int iFolioTicket)
        {
            return new VentaDAL().CancelarTicket(iFolioTicket);
        }
    }
}
