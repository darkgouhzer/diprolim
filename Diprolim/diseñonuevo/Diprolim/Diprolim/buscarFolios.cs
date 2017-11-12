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
    public partial class buscarFolios : Form
    {
        conexion conn = new conexion();
        MySqlCommand comando;
        MySqlConnection conectar;
        MySqlDataReader lector;
        DialogResult result;
        public buscarFolios()
        {
            InitializeComponent();
            buscarFolio();
        }
        recuperarCodigo _ui = new recuperarCodigo();
        public recuperarCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }
        public void buscarFolio()
        {
            tblFolios.Rows.Clear();
            string cliente = "";
            if (tbxBuscar.Text.Length > 0)
            {
                cliente = " and c.nombre like '%"+tbxBuscar.Text+"%'";
            }
            else
            {
                cliente = "";
            }
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select distinct v.folio, c.nombre from ventas v, clientes c where v.clientes_idclientes=c.idclientes and tipo_compra='credito'"+cliente,conectar);
            conectar.Open();
            lector=comando.ExecuteReader();
            while (lector.Read())
            {
                tblFolios.Rows.Add(lector.GetString(0),lector.GetString(1));
            }
            conectar.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tblFolios.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = tblFolios.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void tbxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            buscarFolio();
        }

        private void tblFolios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblFolios.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = tblFolios.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }
    }
}
