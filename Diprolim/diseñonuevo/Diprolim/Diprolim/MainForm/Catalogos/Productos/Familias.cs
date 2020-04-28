using Entidades;
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
    public partial class Familias : Form
    {
        public Familias()
        {
            InitializeComponent();
            updateDataToGridView();
        }

        private void Familias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloBO objArticuloBO = new ArticuloBO();
            if (tbxDescripcion.Text.Length > 0)
            {
                if (objArticuloBO.AgregarFamilia(tbxDescripcion.Text))
                {
                    MessageBox.Show("Familia guardada con éxito.");
                    updateDataToGridView();
                    tbxDescripcion.Clear();
                }
                else
                {
                    MessageBox.Show("La familia no se pudo guardar.");
                }
            }
            
        }

        private void updateDataToGridView()
        {
            ArticuloBO objArticuloBO = new ArticuloBO();

            DataTable tbl = objArticuloBO.ObtenerFamilias();

            if (tbl.Rows.Count > 0)
            {
                tblFamilias.Rows.Clear();
                foreach (DataRow row in tbl.Rows)
                {                    
                    tblFamilias.Rows.Add(false, Convert.ToInt32(row["idfamilias"]), row["descripcion"].ToString());
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

       
            DialogResult result = MessageBox.Show("Sé eliminarán las familias marcadas, ¿desea continuar?", "Eliminación de familias", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ArticuloBO objArticuloBO = new ArticuloBO();
                List<DataGridViewRow> list = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in tblFamilias.Rows)
                {
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                    {
                        list.Add(row);                        
                    }
                }

                int cont = 0;
                int[] iEliminarFamilias = new int[list.Count];
                foreach (DataGridViewRow row in list)
                {
                    
                    DataGridViewTextBoxCell codigo = row.Cells[1] as DataGridViewTextBoxCell;
                    iEliminarFamilias[cont] = Convert.ToInt32(codigo.Value);
                    cont++;
                    tblFamilias.Rows.Remove(row);
                }

                objArticuloBO.EliminarFamilias(iEliminarFamilias);
                updateDataToGridView();
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Sé actulizarán datos de filas marcadas, ¿desea continuar?", "Actualización de familias", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                List<CFamilia> list = new List<CFamilia>();
                ArticuloBO objArticuloBO = new ArticuloBO();


                foreach (DataGridViewRow row in tblFamilias.Rows)
                {                

                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                    {
                        CFamilia objCFamilia = new CFamilia();
                        objCFamilia.IDFamilia = Convert.ToInt32(row.Cells[1].Value);
                        objCFamilia.Descripcion = row.Cells[2].Value.ToString();
                        list.Add(objCFamilia);
                    }
                }

                if (objArticuloBO.actualizarFamilias(list))
                {
                    MessageBox.Show("Familias actualizadas con éxito.");
                }
                else
                {
                    MessageBox.Show("Las familias no pudieron ser actualizadas.");
                }
                updateDataToGridView();
            }
            
        }
    }
}
