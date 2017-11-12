using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Diprolim
{
    public partial class consultaVendedores : Form
    {
        conexion conn = new conexion();
        public consultaVendedores()
        {
            InitializeComponent();
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tablaEmpleados.Rows.Clear();
          
           
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT * FROM empleados WHERE nombre LIKE '%"+ tbxFiltro.Text+"%' OR "
            +" apellido_paterno LIKE '%"+tbxFiltro.Text+"%' OR apellido_materno LIKE '%"+tbxFiltro.Text+"%'", conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tablaEmpleados.Rows.Add(lector.GetString(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3));
                }
                conectar.Close();
        }

        private void busquedaEmpleado_Load(object sender, EventArgs e)
        {

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("SELECT * FROM empleados WHERE nombre LIKE '%" + tbxFiltro.Text + "%' OR "
        + " apellido_paterno LIKE '%" + tbxFiltro.Text + "%' OR apellido_materno LIKE '%" + tbxFiltro.Text + "%'", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                tablaEmpleados.Rows.Add(lector.GetInt32(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3),lector.GetString(4));
            }
            conectar.Close();
        }

        private void tablaEmpleados_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "ClaveEmpleado")
            {
                // e.SortResult = tablaEmpleados.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tablaEmpleados.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(tablaEmpleados.Rows[e.RowIndex1].Cells["ClaveEmpleado"].Value.ToString()),
                    Convert.ToInt32(tablaEmpleados.Rows[e.RowIndex2].Cells["ClaveEmpleado"].Value.ToString()));
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

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxFiltro.Text != "")
                {
                    btnBuscar.Focus();
                }

            }
        }

    }
}
