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
using System.Security.Cryptography;

namespace Diprolim
{
    public partial class CreacionUsuarios : Form
    {
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        conexion conn = new conexion();
        public CreacionUsuarios()
        {
            InitializeComponent();
        }
        string contrasena;
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxUsuario.Text != "" && tbxContrasena.Text != "")
            {
                int usernum=0;
                conectar = conn.ObtenerConexion();
                try
                {
                    comando = new MySqlCommand("select count(*) from usuarios where nombre='" + tbxUsuario.Text+"'", conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        usernum = lector.GetInt32(0);
                    }
                    conectar.Close();
                }
                catch (MySqlException er)
                {
                    MessageBox.Show(er+"Error");
                }

                if (usernum < 1)
                {
                    try
                    {

                        MD5 hashm = MD5.Create();
                        contrasena = GetMd5Hash(hashm, tbxContrasena.Text);
                        comando = new MySqlCommand("INSERT INTO USUARIOS (nombre,contrasena,status) VALUES('" +
                             tbxUsuario.Text + "','" + contrasena + "','" + "Activo" + "')", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();
                    }
                    catch (MySqlException Ex)
                    {
                        MessageBox.Show(Ex.Message);
                        throw;
                    }

                    MessageBox.Show("Usuario Creado");
                }
                else
                {
                    MessageBox.Show("Es nombre de usuario ya existe");
                }
               
            }
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxContrasena.Focus();
            }
        }

        private void tbxContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

       
    }
}
