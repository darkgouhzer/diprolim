using Identidades;
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
    public partial class Impresoras : Form
    {
        ImpresoraBO objImpresoraBO = new ImpresoraBO();
        CImpresora objCImpresora;
        public Impresoras()
        {
            InitializeComponent();
            cbxImpresoras.DataSource = objImpresoraBO.ListarImpresoras();
            objCImpresora = new CImpresora();
            objCImpresora = objImpresoraBO.ObtenerDatosImpresora();
            cbxImpresoras.Text = objCImpresora.Impresora;
            tbxEncabezado2.Text = objCImpresora.Encabezado1;
            tbxEncabezado1.Text = objCImpresora.Encabezado2;
            tbxRFC.Text = objCImpresora.RFC;
            tbxDireccion.Text = objCImpresora.Direccion;
            tbxTelefonos.Text = objCImpresora.Telefonos;
            tbxNotafinal.Text = objCImpresora.NotaFinal;
        }

        private void Impresoras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnGuardar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objCImpresora = new CImpresora();
            objCImpresora.Encabezado1 = tbxEncabezado2.Text;
            objCImpresora.Encabezado2 = tbxEncabezado1.Text;
            objCImpresora.RFC = tbxRFC.Text;
            objCImpresora.Direccion = tbxDireccion.Text;
            objCImpresora.Telefonos = tbxTelefonos.Text;
            objCImpresora.NotaFinal = tbxNotafinal.Text;
            objCImpresora.Impresora = cbxImpresoras.Text;
            objImpresoraBO.GuardarImpresora(objCImpresora);
            MessageBox.Show("Los datos han sido guardados con éxito.");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
