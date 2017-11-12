using MySql.Data.MySqlClient;
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
    public partial class BuscarVendedor : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        public BuscarVendedor()
        {
            InitializeComponent();
            buscar();
        }
        recuperarCodigo _ui = new recuperarCodigo();
        public recuperarCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgEmpleados.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dtgEmpleados.CurrentRow.Cells[0].Value.ToString();
                
                this.Close();

            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        public void buscar()
        {
            dtgEmpleados.Rows.Clear();
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select e.id_empleado, e.nombre, e.apellido_paterno, e.apellido_materno, p.nombre"+
                " from empleados e, puestos p where e.Puestos_idPuestos=p.idPuestos and (e.nombre like '%" + tbxBuscar.Text + "%'" +
                " or e.apellido_paterno like '%" + tbxBuscar.Text + "%' or e.apellido_materno like '%" + tbxBuscar.Text + "%' or p.nombre like '%" + tbxBuscar.Text + "%' )", conectar);
            conectar.Open();             
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            
            while (lector.Read())
            {
                dtgEmpleados.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), lector.GetString(3),lector.GetString(4));
                

            }
            conectar.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgEmpleados_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "Codigo")
            {
                // e.SortResult = tblSalidas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblSalidas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgEmpleados.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString()),
                    Convert.ToInt32(dtgEmpleados.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
            }
            e.Handled = true;
        }

        public int comparar(int a, int b)
        {
            if (a > b) { return -1; }
            if (a == b) { return 0; }
            if (a < b) { return 1; }
            return 0;
        }
        public int comparar(Double a, Double b)
        {
            if (a > b) { return -1; }
            if (a == b) { return 0; }
            if (a < b) { return 1; }
            return 0;
        }

        private void tbxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            buscar();
        }

        private void dtgEmpleados_Enter(object sender, EventArgs e)
        {
            
           
            
        }

        private void dtgEmpleados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (dtgEmpleados.Rows.Count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    _ui.valXn = dtgEmpleados.CurrentRow.Cells[0].Value.ToString();

                    this.Close();

                }
                else
                {
                    MessageBox.Show("No hay datos para seleccionar");
                }
            }
        }

        private void dtgEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgEmpleados.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dtgEmpleados.CurrentRow.Cells[0].Value.ToString();

                this.Close();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void BuscarVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }     

    }
}
