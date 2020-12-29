using Entidades;
using Enumeradores;
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

namespace Diprolim.MainForm.Catalogos.Descuentos
{
    public partial class Consulta_descuentos_personalizados : Form
    {
        public Consulta_descuentos_personalizados()
        {
            InitializeComponent();
            CargarCampanasDescuento(Convert.ToInt32(EnumActivoInactivo.Activas));
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            DescuentosPersonalizados objDescuentosPersonalizados = new DescuentosPersonalizados(0);
            objDescuentosPersonalizados.ShowDialog();
            rbtnActivas.Checked = true;
            CargarCampanasDescuento(Convert.ToInt32(EnumActivoInactivo.Activas));
        }

        private void Consulta_descuentos_personalizados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CargarCampanasDescuento(int Estatus)
        {
            DescuentosBO objDescuentosBO = new DescuentosBO();
            List<CDescuentoCustom> objListCDescuentoCustom = new List<CDescuentoCustom>();
            objListCDescuentoCustom = objDescuentosBO.ObtenerTodosDescuentos(Estatus);
            dtgCampana.Rows.Clear();
            if (objListCDescuentoCustom.Count > 0)
            {
                dtgCampana.Rows.Clear();
                foreach (CDescuentoCustom obj in objListCDescuentoCustom)
                {
                    dtgCampana.Rows.Add(obj.CampanaID, obj.NombreCampana);
                }
               
            }
           
        }

        private void rbtnActivas_Click(object sender, EventArgs e)
        {
            CargarCampanasDescuento(Convert.ToInt32(EnumActivoInactivo.Activas));
        }

        private void rbtnTodas_Click(object sender, EventArgs e)
        {
            CargarCampanasDescuento(Convert.ToInt32(EnumActivoInactivo.Todas));
        }

        private void rbtnInactivas_Click(object sender, EventArgs e)
        {
            CargarCampanasDescuento(Convert.ToInt32(EnumActivoInactivo.Inactivas));
        }

        private void dtgCampana_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgCampana.Rows.Count > 0)
            {
                Int32 RowIndex = dtgCampana.SelectedCells[0].RowIndex;
                if (RowIndex > -1)
                {
                    DescuentosPersonalizados objDescuentosPersonalizados = new DescuentosPersonalizados(Convert.ToInt32(dtgCampana.Rows[RowIndex].Cells[0].Value));
                    objDescuentosPersonalizados.ShowDialog();
                    rbtnActivas.Checked = true;
                    CargarCampanasDescuento(Convert.ToInt32(EnumActivoInactivo.Activas));
                }
            }
        }
    }
}
