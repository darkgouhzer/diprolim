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
    public partial class BuscarClientes : Form
    {
        string nombre = "";
        conexion conn = new conexion();
        public BuscarClientes(string vendedor)
        {
            InitializeComponent();
            nombre = vendedor;
            buscar(vendedor);
        }


        public BuscarClientes()
        {
            InitializeComponent();
            buscar("");
        }
        recuperarCodigo _ui = new recuperarCodigo();
        public recuperarCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }
        public void buscar(string vendedor)
        {
            dtgClientes.Rows.Clear();

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            if (nombre == "1")
            {
                comando = new MySqlCommand("select idclientes, nombre from clientes where empleados_id_empleado=" + vendedor, conectar);
            }
            else if (vendedor.Length > 0)
            {
                comando = new MySqlCommand("select idclientes, nombre from clientes where empleados_id_empleado=" + vendedor, conectar);
            }
            else
            {
                comando = new MySqlCommand("select idclientes, nombre from clientes", conectar);
            }

            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                dtgClientes.Rows.Add(lector.GetInt32(0), lector.GetString(1));

            }
            conectar.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgClientes.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dtgClientes.CurrentRow.Cells[0].Value.ToString();
                this.Close();

            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
              dtgClientes.Rows.Clear();

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            if (nombre == "1" || nombre == "")
            {
                comando = new MySqlCommand("select idclientes, nombre from clientes where nombre like '%" + tbxFiltro.Text.Trim() + "%'", conectar);
            }
            else
            {
                comando = new MySqlCommand("select idclientes, nombre from clientes where empleados_id_empleado='" + nombre + "' and nombre like '%" + tbxFiltro.Text.Trim() + "%'", conectar);
            }
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                dtgClientes.Rows.Add(lector.GetString(0), lector.GetString(1));

            }
            conectar.Close();
        }

        private void dtgClientes_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "Codigo")
            {
                // e.SortResult = tblSalidas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblSalidas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgClientes.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString()),
                    Convert.ToInt32(dtgClientes.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
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

        private void dtgClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (dtgClientes.Rows.Count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    _ui.valXn = dtgClientes.CurrentRow.Cells[0].Value.ToString();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("No hay datos para seleccionar");
                }
            }
        }

        private void dtgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgClientes.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dtgClientes.CurrentRow.Cells[0].Value.ToString();
                this.Close();

            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void BuscarClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }       

    }
}
