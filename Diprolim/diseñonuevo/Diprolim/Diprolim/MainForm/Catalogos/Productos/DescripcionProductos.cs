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
    public partial class DescripcionProductos : Form
    {
        public DescripcionProductos()
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
                if (objArticuloBO.AgregarDescripcionProducto(tbxDescripcion.Text))
                {
                    MessageBox.Show("Descripción guardada con éxito.");
                    updateDataToGridView();
                    tbxDescripcion.Clear();
                }
                else
                {
                    MessageBox.Show("La descripción no se pudo guardar.");
                }
            }
            
        }

        private void updateDataToGridView()
        {
            ArticuloBO objArticuloBO = new ArticuloBO();

            DataTable tbl = objArticuloBO.ObtenerDescripcionesProductos(String.Empty);

            if (tbl.Rows.Count > 0)
            {
                tblDescripciones.Rows.Clear();
                foreach (DataRow row in tbl.Rows)
                {                    
                    tblDescripciones.Rows.Add(false, Convert.ToInt32(row["iddescripcion"]), row["descripcion"].ToString());
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

       
            DialogResult result = MessageBox.Show("Sé eliminarán las Descripciones marcadas, ¿desea continuar?", "Eliminación de Descripciones", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ArticuloBO objArticuloBO = new ArticuloBO();
                List<DataGridViewRow> list = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in tblDescripciones.Rows)
                {
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                    {
                        list.Add(row);                        
                    }
                }

                int cont = 0;
                int[] iEliminarDescripciones = new int[list.Count];
                foreach (DataGridViewRow row in list)
                {
                    
                    DataGridViewTextBoxCell codigo = row.Cells[1] as DataGridViewTextBoxCell;
                    iEliminarDescripciones[cont] = Convert.ToInt32(codigo.Value);
                    cont++;
                    tblDescripciones.Rows.Remove(row);
                }

                objArticuloBO.EliminarDescripcionProducto(iEliminarDescripciones);
                updateDataToGridView();
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Sé actulizarán datos de filas marcadas, ¿desea continuar?", "Actualización de descripciones", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                List<CFamilia> list = new List<CFamilia>();
                ArticuloBO objArticuloBO = new ArticuloBO();


                foreach (DataGridViewRow row in tblDescripciones.Rows)
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

                if (objArticuloBO.actualizarDescripcionProducto(list))
                {
                    MessageBox.Show("Descripciones actualizadas con éxito.");
                }
                else
                {
                    MessageBox.Show("Las descripciones no pudieron ser actualizadas.");
                }
                updateDataToGridView();
            }
            
        }
    }
}
