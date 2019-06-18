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

namespace Diprolim
{
    public partial class CancelarVentasCajaRapida : Form
    {
        public CancelarVentasCajaRapida()
        {
            InitializeComponent();
        }

        private void CancelarVentasCajaRapida_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Realmente deseas cancelar el ticket número " + tbxFolioTicket.Text + "?", "Cancelando ticket", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
            {
                VentaBO objVentaBO = new VentaBO();
                objVentaBO.CancelarTicket(Convert.ToInt32(tbxFolioTicket.Text));

                MessageBox.Show("Venta con el número de ticket " + tbxFolioTicket.Text + " eliminada con éxito.");
                tbxFolioTicket.Clear();
                dtgTicket.Rows.Clear();
            }
        }

        private void tbxFolioTicket_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CancelarVentasCajaRapida_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (tbxFolioTicket.Focused)
                {
                    if (tbxFolioTicket.Text.Length > 0)
                    {
                        VentaBO objVentaBO = new VentaBO();
                        DataTable tbl = objVentaBO.ObtenerVentasPorTicket(Convert.ToInt32(tbxFolioTicket.Text));

                        if (tbl.Rows.Count > 0)
                        {
                            dtgTicket.Rows.Clear();
                            foreach (DataRow row in tbl.Rows)
                            {
                                dtgTicket.Rows.Add(Convert.ToInt32(row["articulos_codigo"]),
                                    row["descripcion"].ToString() + " " + row["valor_medida"].ToString() + " " + row["nombremedida"].ToString(),
                                    Convert.ToDouble(row["precio_art"]),
                                    Convert.ToDouble(row["cantidad"]),
                                    Convert.ToDouble(row["importe"]),
                                    Convert.ToDateTime(row["fecha_venta"]));
                            }


                        }
                    }
                }
            }

        }

        private void tbxFolioTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar)
            {
                e.Handled = true;
            }
        }
    }
}
