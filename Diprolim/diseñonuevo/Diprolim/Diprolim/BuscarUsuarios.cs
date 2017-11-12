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
    public partial class BuscarUsuarios : Form
    {
        conexion conn = new conexion();
        public BuscarUsuarios()
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (tblUsuarios.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = tblUsuarios.CurrentRow.Cells[0].Value.ToString();
                this.Close();

            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }
        public void buscar()
        {
        MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select id_usuarios,nombre,status from usuarios", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            
            while (lector.Read())
            {
                tblUsuarios.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2));
                

            }
            conectar.Close();
    }

        private void BuscarUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tblUsuarios_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "codigo")
            {
                // e.SortResult = tblSalidas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblSalidas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(tblUsuarios.Rows[e.RowIndex1].Cells["codigo"].Value.ToString()),
                    Convert.ToInt32(tblUsuarios.Rows[e.RowIndex2].Cells["codigo"].Value.ToString()));
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

        private void tblUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblUsuarios.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = tblUsuarios.CurrentRow.Cells[0].Value.ToString();
                this.Close();

            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }      
    }
}
