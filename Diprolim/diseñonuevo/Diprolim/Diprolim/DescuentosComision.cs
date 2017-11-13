using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReglasNegocios;
namespace Diprolim
{
    public partial class DescuentosComision : Form
    {
        DescuentoComisionBO objDescuentoComisionBO;
        public DescuentosComision()
        {            
            InitializeComponent();
            objDescuentoComisionBO = new DescuentoComisionBO();
            llenarGrid();
        }
        public void llenarGrid()
        {
            dtgDescuentoComision.Rows.Clear();
            foreach(DataRow row in objDescuentoComisionBO.ObtenerDescuentosComision().Rows)
            {
                dtgDescuentoComision.Rows.Add(row[0], row[1], row[2]);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objDescuentoComisionBO = new DescuentoComisionBO();
            if(objDescuentoComisionBO.Guardar(dtgDescuentoComision))
            {
                MessageBox.Show("Datos guardados con éxito");
                llenarGrid();
            }
        }

        private void DescuentosComision_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }else if(e.KeyCode==Keys.F5)
            {
                btnGuardar_Click(sender, e);
            }
        }
    }
}
