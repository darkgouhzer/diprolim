using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diprolim
{
    public partial class BajasDeVendedores : Form
    {
        conexion conn = new conexion();

        public BajasDeVendedores()
        {
            InitializeComponent();
        }

        private void tbxID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoVendedor();
            }
        }
        public void MetodoVendedor()
        {
            if (tbxID.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + tbxID.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {

                    tbxNombre.Text = (lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3));
                    des = lector.GetString(1);
                }
                if (des == "")
                {
                    MessageBox.Show("Ese vendedor no existe");
                    tbxID.Clear();
                }
            }
        }

        private void tbxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {

                e.Handled = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxID.Text = id.regresar.valXn;
            }
            tbxID.Focus();
            MetodoVendedor();
        }
        int i;
        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            if (tbxID.Text != "")
            {
                if (tbxID.Text != "1")
                {

                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;

                    comando = new MySqlCommand("SELECT count(*) FROM empleados WHERE id_empleado =" + tbxID.Text, conectar);
                    conectar.Open();
                    MySqlDataReader lector;
                    lector=comando.ExecuteReader();
                    while (lector.Read())
                    {
                        i=Convert.ToInt32(lector.GetString(0));
                    }
                    conectar.Close();
                    if (i > 0)
                    {
                        comando = new MySqlCommand("delete from empleados where id_empleado=" + tbxID.Text, conectar);
                        try
                        {
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            MessageBox.Show("Dado de baja correctamente");

                            conectar.Close();
                        }
                        catch (MySqlException)
                        {
                            MessageBox.Show("Imposible eliminar");

                        }
                    }
                    else
                    {
                        MessageBox.Show("El código de vendedor no existe");
                    }
                }
                else
                {
                    MessageBox.Show("No se puede eliminar a la sucursal");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
