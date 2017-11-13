using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
namespace ReglasNegocios
{
    public class DescuentoComisionBO
    {
        DescuentoComisionDAL objDescuentoComisionDAL;
        public DescuentoComisionBO()
        {
            objDescuentoComisionDAL = new DescuentoComisionDAL();
        }
        public DataTable ObtenerDescuentosComision()
        {
            DataTable dtDatos = new DataTable();
            dtDatos = objDescuentoComisionDAL.ObtenerDescuentosComision();
            return dtDatos;
        }
        public Boolean Guardar(DataGridView dgDatos)
        {
            Boolean bAllOk = false;
            DataTable dtDatos = new DataTable();
            dtDatos.Columns.Add("ID", typeof(Int32));
            dtDatos.Columns.Add("Dias", typeof(Int32));
            dtDatos.Columns.Add("Porcentaje", typeof(Int32));

            foreach (DataGridViewRow rowGrid in dgDatos.Rows)
            {
                DataRow row = dtDatos.NewRow();
                row["ID"] = Convert.ToDouble(rowGrid.Cells[0].Value);
                row["Dias"] = Convert.ToDouble(rowGrid.Cells[1].Value);
                row["Porcentaje"] = Convert.ToDouble(rowGrid.Cells[2].Value);
                dtDatos.Rows.Add(row);
            }
            dtDatos.Rows.RemoveAt(dtDatos.Rows.Count-1);
            objDescuentoComisionDAL = new DescuentoComisionDAL();
            bAllOk = objDescuentoComisionDAL.Guardar(dtDatos);

            return bAllOk;
        }
    }
}
