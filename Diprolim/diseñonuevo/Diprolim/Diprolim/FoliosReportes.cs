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
    public partial class FoliosReportes : Form
    {
        conexion conn = new conexion();
        string tipo = "";
        public FoliosReportes()
        {
            InitializeComponent();
        }
        public FoliosReportes(string Tipo)
        {
            InitializeComponent();
            tipo = Tipo;
        }
        recuperarCodigo _ui = new recuperarCodigo();
        public recuperarCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }
        private void BuscarFoliosSalidas()
        {
            dtgFolios.Rows.Clear();
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select  Folio, fecha from salidas where Folio is not null group by folio order by fecha asc", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                dtgFolios.Rows.Add(lector.GetString(0), lector.GetString(1));
            }
            conectar.Close();
        }
        private void BuscarFoliosEntradas()
        {
            dtgFolios.Rows.Clear();
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select folio,fecha from Entradasdp where Folio is not null group by folio order by fecha asc", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                dtgFolios.Rows.Add(lector.GetString(0), lector.GetString(1));
            }
            conectar.Close();
        }
        private void FoliosReportes_Load(object sender, EventArgs e)
        {
            if(tipo=="Salidas")
            {
                BuscarFoliosSalidas();
            }
            else if (tipo == "Entradas")
            {
                BuscarFoliosEntradas();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgFolios.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dtgFolios.CurrentRow.Cells[0].Value.ToString();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }
    }
}
