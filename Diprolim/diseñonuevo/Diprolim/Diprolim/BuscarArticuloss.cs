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
    public partial class BuscarArticuloss : Form
    {
        conexion conn = new conexion();
        string Cliente = "";
        public BuscarArticuloss()
        {
            InitializeComponent();
        }
        public BuscarArticuloss(String Cliente)
        {
            InitializeComponent();
            this.Cliente = Cliente;
        }
        recuperarCodigo _ui = new recuperarCodigo();
        public recuperarCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }

        private void BuscarArticuloss_Load(object sender, EventArgs e)
        {
            if(Cliente!="")
            {
                BuscarProductoEntrada();
            }else
            {
                BuscarProductoSimple();
            }
        }
        public void BuscarProductoEntrada()
        {
            dtgArticulos.Rows.Clear();

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select a.codigo, a.descripcion, a.valor_medida, c.nombre, sum(i.cantidad) "+
                "from articulos a, unidad_medida c, inv_clientes i where i.cantidad>0 and a.unidad_medida_id=c.id and "+
                "i.clientes_idclientes="+Cliente+" and i.articulos_codigo=a.codigo GROUP BY a.codigo", conectar);


            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {

                dtgArticulos.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3), lector.GetInt32(4));

            }
            conectar.Close();
        }
        public void BuscarProductoSimple()
        {
            dtgArticulos.Rows.Clear();

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select a.codigo, a.descripcion, a.valor_medida, c.nombre, a.cantidad from articulos a, unidad_medida c where a.cantidad>0 and a.unidad_medida_id=c.id and departamento=1", conectar);


            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                dtgArticulos.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3), lector.GetInt32(4));

            }
            conectar.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgArticulos.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dtgArticulos.CurrentRow.Cells[0].Value.ToString();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
                dtgArticulos.Rows.Clear();

                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("select a.codigo, a.descripcion, a.valor_medida, c.nombre,a.cantidad from articulos a, " +
                    "unidad_medida c where a.unidad_medida_id=c.id and descripcion like '%" + tbxFiltro.Text.Trim() + "%'", conectar);


                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dtgArticulos.Rows.Add(lector.GetString(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3), lector.GetString(4));

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
            if (e.Column.Name == "Cantidad")
            {
                // e.SortResult = tblSalidas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblSalidas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgArticulos.Rows[e.RowIndex1].Cells["Cantidad"].Value.ToString()),
                    Convert.ToDouble(dtgArticulos.Rows[e.RowIndex2].Cells["Cantidad"].Value.ToString()));
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

        private void dtgArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgArticulos.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dtgArticulos.CurrentRow.Cells[0].Value.ToString();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void BuscarArticuloss_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        
    }
}
