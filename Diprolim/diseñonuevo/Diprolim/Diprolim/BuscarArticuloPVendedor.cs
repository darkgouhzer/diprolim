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
    public partial class BuscarArticuloPVendedor : Form
    {
        recuperarCodigo _ui = new recuperarCodigo();
        conexion conn = new conexion();
        string Nombre = "";
        string LIKE = "";
        
        
       
        public BuscarArticuloPVendedor()
        {
            InitializeComponent();
        }
        public BuscarArticuloPVendedor(string s)
        {
            InitializeComponent();
            Nombre=s;
        }
       
        public recuperarCodigo regresar
        {
            get
            {
                return (_ui);
            }
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

        private void BuscarArticuloPVendedor_Load(object sender, EventArgs e)
        {
            dtgArticulos.Rows.Clear();

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select a.codigo, a.descripcion, a.valor_medida, c.nombre, i.cantidad from articulos a, unidad_medida c, inv_vendedor i where a.unidad_medida_id=c.id and i.cantidad>0 and empleados_id_empleado=" + Nombre+ " and i.articulos_codigo=a.codigo order by codigo asc", conectar);


            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                if (lector.GetDouble(2) > 3||lector.GetString(3)=="A granel")
                {
                    dtgArticulos.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3), lector.GetInt32(4));
                }
            }
            conectar.Close();
        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            
                dtgArticulos.Rows.Clear();

                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("select i.articulos_codigo, a.descripcion, a.valor_medida, c.nombre from inv_vendedor i, articulos a, unidad_medida c where a.unidad_medida_id=c.id and i.articulos_codigo=a.codigo and empleados_id_empleado=" + Nombre + " and descripcion like '%" + tbxFiltro.Text.Trim() + "%'", conectar);


                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dtgArticulos.Rows.Add(lector.GetString(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3));

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
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void BuscarArticuloPVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
        
    }
}
