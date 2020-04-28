using ReglasNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diprolim.MainForm.Catalogos.Productos
{
    public partial class BuscarDescripcion : Form
    {

        public int iCodigo = 0;
        public BuscarDescripcion()
        {
            InitializeComponent();
            llenarGridView();
        }

        public void llenarGridView()
        {
            ArticuloBO objArticuloBO = new ArticuloBO();
            DataTable tbl = objArticuloBO.ObtenerDescripcionesProductos(tbxFiltro.Text);
            dtgDescripciones.Rows.Clear();
            if (tbl.Rows.Count > 0)
            {
               
                foreach (DataRow row in tbl.Rows)
                {
                    dtgDescripciones.Rows.Add(Convert.ToInt32(row["iddescripcion"]), row["descripcion"].ToString());
                }
            }
        }

        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            llenarGridView();
        }

        private void BuscarDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgDescripciones.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                iCodigo = Convert.ToInt32(dtgDescripciones.CurrentRow.Cells[0].Value);
                this.Close();
            }
        }

        private void dtgDescripciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDescripciones.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                iCodigo = Convert.ToInt32(dtgDescripciones.CurrentRow.Cells[0].Value);
                this.Close();

            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }
    }


}
