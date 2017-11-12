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
    public partial class consultaEmpleado : Form
    {
        conexion conn = new conexion();
        public consultaEmpleado()
        {
            InitializeComponent();
            consultar();
        }
        DateTime fechanac;
        public void consultar()
        {
            tablaEmpleados.Rows.Clear();


            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("SELECT * FROM empleados WHERE nombre LIKE '%" + tbxFiltro.Text + "%' OR "
        + " apellido_paterno LIKE '%" + tbxFiltro.Text + "%' OR apellido_materno LIKE '%" + tbxFiltro.Text + "%'", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                fechanac = Convert.ToDateTime(lector.GetString(6));
                tablaEmpleados.Rows.Add(lector.GetString(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), lector.GetString(4), fechanac.ToString("dd-MM-yyyy"), lector.GetString(8));
            }
            conectar.Close();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            consultar();  
        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.Focus();
            }
        }      
    }
}
