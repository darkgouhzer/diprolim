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
    public partial class BuscarArticulos : Form
    {
        conexion conn = new conexion();
        string tipoBusc;
        public BuscarArticulos()
        {
            InitializeComponent();
            BuscarArticulosF();
        }
        
        public BuscarArticulos(string especial)
        {
            InitializeComponent();
            tipoBusc = especial;
            BuscarArticulosEspecial();
        }
        recuperarCodigo _ui = new recuperarCodigo();
        public recuperarCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }
        private void BuscarArticulosF()
        {
            dtgArticulos.Rows.Clear();
            
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select a.codigo, a.descripcion, a.valor_medida, c.nombre,a.cantidad from articulos a, "+
                "unidad_medida c where a.unidad_medida_id=c.id", conectar);


            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                dtgArticulos.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3),lector.GetString(4));

            }
            conectar.Close();

        }

        public void BuscarArticulosEspecial()
        {
            dtgArticulos.Rows.Clear();

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select a.codigo, a.descripcion, a.valor_medida, c.nombre,a.cantidad from articulos a,"+
                "unidad_medida c where a.unidad_medida_id=c.id and (a.valor_medida>=4 or a.unidad_medida_id=7)", conectar);


            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                dtgArticulos.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3), lector.GetString(4));

            }
            conectar.Close();

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgArticulos.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dtgArticulos.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void dtgArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
                dtgArticulos.Rows.Clear();
            
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            if (tipoBusc == "Especial")
            {
                comando = new MySqlCommand("select a.codigo, a.descripcion, a.valor_medida, c.nombre,a.cantidad from articulos a, " +
                   "unidad_medida c where a.unidad_medida_id=c.id and (a.valor_medida>=4 or a.unidad_medida_id=7) and descripcion like '%" + tbxFiltro.Text.Trim() + "%'", conectar);
            
            }
            else
            {
                comando = new MySqlCommand("select a.codigo, a.descripcion, a.valor_medida, c.nombre,a.cantidad from articulos a, " +
                    "unidad_medida c where a.unidad_medida_id=c.id and descripcion like '%" + tbxFiltro.Text.Trim() + "%'", conectar);
            }

            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                dtgArticulos.Rows.Add(lector.GetString(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3),lector.GetString(4));

            }
            conectar.Close();
          
        }

        private void dtgArticulos_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "Codigo")
            {
                // e.SortResult = tblSalidas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblSalidas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgArticulos.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString()),
                    Convert.ToInt32(dtgArticulos.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
            }
            if (e.Column.Name == "Existencias")
            {
                // e.SortResult = tblSalidas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblSalidas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgArticulos.Rows[e.RowIndex1].Cells["Existencias"].Value.ToString()),
                    Convert.ToDouble(dtgArticulos.Rows[e.RowIndex2].Cells["Existencias"].Value.ToString()));
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

        private void BuscarArticulos_Load(object sender, EventArgs e)
        {

        }

        private void dtgArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (dtgArticulos.Rows.Count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    _ui.valXn = dtgArticulos.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No hay datos para seleccionar");
                }
            }
        }

        private void dtgArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgArticulos.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dtgArticulos.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void BuscarArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        
    }
}
