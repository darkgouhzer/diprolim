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
using System.Security.Cryptography;

namespace Diprolim
{
    public partial class inicioSesion : Form
    {
        conexion conn = new conexion();
        string s = "";
        public inicioSesion()
        {
            InitializeComponent();
        }
        public inicioSesion(string S)
        {
            InitializeComponent();
            s = S;
        }

        public inicioSesion(string S, string sAutorizacion)
        {
            InitializeComponent();
            s = S;
            this.Text = sAutorizacion;
        }
        recuperarCodigo _ui = new recuperarCodigo();
        public recuperarCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreacionUsuarios CU = new CreacionUsuarios();
            CU.Show();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

           
                if (tbxID.Text != "" && tbxContraseña.Text != "")
                {
                    MD5 hashm = MD5.Create();
                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;
                    comando = new MySqlCommand("select * from usuarios where nombre='" + tbxID.Text + "'", conectar);
                    conectar.Open();
                    MySqlDataReader lector;
                    lector = comando.ExecuteReader();
                    string ID = "";
                    string Nombre = "";
                    string contrasena = "";
                    string privilegio = "";

                    while (lector.Read())
                    {
                        ID = lector.GetString(0).ToString();
                        Nombre = lector.GetString(1).ToString();
                        contrasena = lector.GetString(2).ToString();
                        privilegio = lector.GetString(4);

                    }
                    if (Nombre != tbxID.Text || contrasena != GetMd5Hash(hashm, tbxContraseña.Text))
                    {
                        MessageBox.Show("Los datos son incorrectos");
                    }
                    else
                    {
                        if (s != ".")
                        {
                            this.DialogResult = DialogResult.OK;
                            _ui.valXn = ID;
                            this.Close();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                            _ui.valXn = privilegio;
                            this.Close();
                        }


                    }

                    conectar.Close();

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

        private void tbxID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxContraseña.Focus();
            }
        }

        private void tbxContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }
    }
}
