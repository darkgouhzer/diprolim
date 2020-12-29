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

namespace Diprolim
{
    public partial class DescuentosPersonalizados : Form
    {
        private int CampanaID;
        
        public DescuentosPersonalizados(int CampanaID = 0)
        {
            InitializeComponent();
            CargarPresentaciones();
            this.CampanaID = CampanaID;
            if(this.CampanaID > 0)
            {
                CargarCampanaEditar();
            }          
        }

        private void CargarCampanaEditar()
        {
            DescuentosBO objDescuentosBO = new DescuentosBO();
            CDescuentoCustom objCDescuentoCustom = new CDescuentoCustom();
            List<String> Presentaciones = new List<string>();
            objCDescuentoCustom = objDescuentosBO.ObtenerDescuentoPorID(this.CampanaID);
            tbxNombre.Text = objCDescuentoCustom.NombreCampana;
            tbxNoCompraInicial.Text = objCDescuentoCustom.NoCompra.ToString();
            tbxMinCompra.Text = objCDescuentoCustom.CantidadMinima.ToString();
            tbxDescuento.Text = objCDescuentoCustom.Porcentaje.ToString();
            chbxActiva.Checked = objCDescuentoCustom.Activa;
            Presentaciones = objDescuentosBO.ObtenerPresentacionesSplit(objCDescuentoCustom.Presentaciones);
            foreach( String obj in Presentaciones)
            {
                for (int i = 0; i < dtgPresentaciones.Rows.Count; i++)
                {
                    if (dtgPresentaciones.Rows[i].Cells[2].Value.ToString().Trim() == obj.Trim())
                    {
                        dtgPresentaciones.Rows[i].Cells[0].Value = true;
                    }

                }
            }

        }

        private void CargarPresentaciones()
        {
            ArticuloBO objArticuloBO = new ArticuloBO();
            List<CPresentaciones> objListPresentaciones = new List<CPresentaciones>();

            objListPresentaciones = objArticuloBO.ObtenerPresentaciones(Convert.ToInt32(EnumUnidadesMedida.Litros));
            dtgPresentaciones.Rows.Clear();
            foreach (CPresentaciones obj in objListPresentaciones)
            {
                dtgPresentaciones.Rows.Add(false, obj.ValorMedida+" "+obj.Simbolo, obj.ValorMedida, obj.Nombre , obj.Simbolo);
            }
        }

        private String ObtenerPresentacionesSeleccionadas()
        {
            String sPresentaciones = String.Empty;
            if (dtgPresentaciones.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dtgPresentaciones.Rows)
                {
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                    {
                        sPresentaciones += sPresentaciones == String.Empty ? row.Cells[2].Value.ToString(): "|" + row.Cells[2].Value.ToString();
                    }
                }
            }

            return sPresentaciones;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DescuentosBO objDescuentosBO = new DescuentosBO();
            CDescuentoCustom objCDescuentoCustom = new CDescuentoCustom();
            if (tbxNombre.Text != "" && tbxNoCompraInicial.Text !="" && tbxMinCompra.Text !="" && tbxDescuento.Text !="")
            {
                objCDescuentoCustom.CampanaID = CampanaID;
                objCDescuentoCustom.NombreCampana = tbxNombre.Text;
                objCDescuentoCustom.NoCompra = Convert.ToInt32(tbxNoCompraInicial.Text);
                objCDescuentoCustom.CantidadMinima = Convert.ToInt32(tbxMinCompra.Text);
                objCDescuentoCustom.Presentaciones = ObtenerPresentacionesSeleccionadas();
                objCDescuentoCustom.Porcentaje = Convert.ToDouble(tbxDescuento.Text);
                objCDescuentoCustom.Activa = chbxActiva.Checked;

                try
                {
                    if (objDescuentosBO.GuardarDescuentoCustom(objCDescuentoCustom))
                    {
                        MessageBox.Show("La campaña se ha guardado con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al guardar.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos de texto son obligatorios.");
            }
        }

        private void tbxNoCompraInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        private void tbxMinCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxDescuento.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DescuentosBO objDescuentosBO = new DescuentosBO();
            try
            {
                if(CampanaID > 0)
                {
                    objDescuentosBO.EliminarDescuentoCustom(CampanaID);
                    MessageBox.Show("Campaña eliminada con éxito.");
                    this.Close();
                }else
                {
                    MessageBox.Show("No es posible eliminar campaña no guardada.");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void DescuentosPersonalizados_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void DescuentosPersonalizados_Load(object sender, EventArgs e)
        {

        }

        private void tbxDescuento_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
