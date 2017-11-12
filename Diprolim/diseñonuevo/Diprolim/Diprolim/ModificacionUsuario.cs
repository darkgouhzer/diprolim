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
    public partial class ModificacionUsuario : Form
    {
        conexion conn = new conexion();

        public ModificacionUsuario()
        {
            InitializeComponent();
        }

       

        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarUsuarios id = new BuscarUsuarios();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCodigo.Text = id.regresar.valXn;
            }
            tbxCodigo.Focus();
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
         string contrasena;
        private void button4_Click(object sender, EventArgs e)
        {
            if (tbxCodigo.Text != "" && tbxUsuario.Text != "" && tbxContrasena.Text != "")
            {

                try
                {
                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;
                    if (tbxContrasena.Text == "**********")
                    {
                        contrasena = contraseña;
                    }
                    else
                    {
                        MD5 hashm = MD5.Create();
                        contrasena = GetMd5Hash(hashm, tbxContrasena.Text);
                    }
                    conectar.Open();
                    comando = new MySqlCommand("UPDATE usuarios SET nombre='" + tbxUsuario.Text
                        + "', contrasena='" + contrasena+"' where id_usuarios="+tbxCodigo.Text, conectar);
                    comando.ExecuteNonQuery();


                    MessageBox.Show("Nuevos datos de usuario guardados");
                    conectar.Close();
                }
                catch (MySqlException Ex)
                {
                    MessageBox.Show(Ex.Message);
                    throw;
                }




            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }
        
           
        }
        string contraseña = "";
        private void tbxCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if(tbxCodigo.Text!="")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;
                    comando = new MySqlCommand("select * from usuarios where id_usuarios=" + Convert.ToInt32(tbxCodigo.Text), conectar);
                    conectar.Open();

                    MySqlDataReader lector;
                    lector = comando.ExecuteReader();
                    string des = "";
                    while (lector.Read())
                    {
                        des = lector.GetString(1);
                        tbxUsuario.Text = lector.GetString(1);
                        contraseña = lector.GetString(2);
                        tbxContrasena.Text = "**********";
                        
                    }
                    conectar.Close();
                    if (des != "")
                    {
                        tbxCodigo.ReadOnly = true;
                        btnSP.Enabled = false;
                        tbxUsuario.Focus();
                    }
                    else 
                    { 
                        MessageBox.Show("Código incorrecto");
                        tbxCodigo.Clear();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxUsuario.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbxContrasena.Focus();
                }
            }
        }

        private void tbxContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxContrasena.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnGuardar.Focus();
                }
            }
        }

       

        private void btnCambiarP_Click(object sender, EventArgs e)
        {
            tbxCodigo.Clear();
            tbxCodigo.ReadOnly = false;
            btnSP.Enabled = true;
            tbxUsuario.Clear();
            tbxContrasena.Clear();

        }

       
        

    }
}
