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
    public partial class bajasEmpleados : Form
    {
        public bajasEmpleados()
        {
            InitializeComponent();
        }
        String line = "";
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxID.Text != "")
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    try
                    {
                        StreamReader sr = new StreamReader("configc.txt");
                        line = sr.ReadToEnd();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("El archivo de configuración de servidor no puede ser leido");
                        MessageBox.Show(err.Message);
                    }
                    MySqlConnection conectar = new MySqlConnection(line);
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
                        MessageBox.Show("Ese Empleado no Existe");
                        tbxID.Clear();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {

                e.Handled = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxID.Text != "")
            {

                try
                {
                    StreamReader sr = new StreamReader("configc.txt");
                    line = sr.ReadToEnd();
                }
                catch (Exception err)
                {
                    MessageBox.Show("El archivo de configuración de servidor no puede ser leido");
                    MessageBox.Show(err.Message);
                }
                MySqlConnection conectar = new MySqlConnection(line);
                MySqlCommand comando;
                comando = new MySqlCommand("delete from empleados where id_empleado=" + tbxID.Text, conectar);
                
                conectar.Open();
                comando.ExecuteNonQuery();

                conectar.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            busquedaEmpleado BE = new busquedaEmpleado();
            BE.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuscarEmpleado id = new BuscarEmpleado();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxID.Text = id.regresar.valXn;
            }
            tbxID.Focus();
        }

        private void bajasEmpleados_Load(object sender, EventArgs e)
        {

        }
    }

}

