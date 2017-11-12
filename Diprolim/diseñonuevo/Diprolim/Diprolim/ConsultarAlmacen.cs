
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
    public partial class ConsultarAlmacen : Form
    {
        Inventarios.DBMS_Unico Conexion;
        public String valorCodigo="";
        string cmd="";
        public ConsultarAlmacen(Inventarios.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
            
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgArticulos.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                valorCodigo = dtgArticulos.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void ConsultarAlmacen_Load(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            cmd = "select idAlmacen, Nombre, Iniciales, Calle, Telefono, E_Mail from almacenes";
            Conexion.Conectarse();
            Conexion.Ejecutar(cmd, ref tbl);
            Conexion.Desconectarse();
            dtgArticulos.DataSource = tbl;
        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            DataTable tbl=new DataTable();
            cmd = "select  idAlmacen, Nombre, Iniciales, Calle, Telefono, E_Mail from almacenes where Nombre like '%" + tbxFiltro.Text.Trim() + "%'";
            Conexion.Conectarse();
            Conexion.Ejecutar(cmd, ref tbl);
            Conexion.Desconectarse();
            dtgArticulos.DataSource = tbl;
            
        }

        private void dtgArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgArticulos.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                valorCodigo = dtgArticulos.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }
    }
}
