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
    public partial class BuscarProveedores : Form
    {

        Inventarios.DBMS_Unico Conexion;
        public BuscarProveedores(Inventarios.DBMS_Unico Conexion)
        {
            InitializeComponent();
            this.Conexion = Conexion;
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

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            dtgArticulos.Rows.Clear();
            DataTable Tabla = new DataTable();
            string Comando = String.Format("SELECT * FROM Proveedores Where NombreComercial like '%{0}%' ", tbxFiltro.Text);
            Conexion.Conectarse();
            Conexion.Ejecutar(Comando,ref Tabla);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dtgArticulos.Rows.Add(Tabla.Rows[i][0].ToString(), Tabla.Rows[i][1].ToString());
                }
            }
            Conexion.Desconectarse();
           
        }

        private void BuscarProveedores_Load(object sender, EventArgs e)
        {
            dtgArticulos.Rows.Clear();
            DataTable Tabla = new DataTable();
            string Comando = "SELECT * FROM Proveedores";
            Conexion.Conectarse();
            Conexion.Ejecutar(Comando, ref Tabla);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dtgArticulos.Rows.Add(Tabla.Rows[i][0].ToString(), Tabla.Rows[i][1].ToString());
                }
            }
            Conexion.Desconectarse();
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
    }
}
