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
    public partial class Autorizaciones : Form
    {
        string tipo;
        Inventarios.DBMS_Unico Conexion;
        public Autorizaciones(string tipoAutorizacion,Inventarios.DBMS_Unico svr)
        {
            InitializeComponent();
            tipo = tipoAutorizacion;
            Conexion = svr;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MD5 hashm = MD5.Create();
            DataTable tbl = new DataTable();
            string pass = tbxContraseña.Text;
            Conexion.Ejecutar("select nombre, contrasena, " + tipo + " from usuarios where nombre='"+tbxID.Text+"' and contrasena='" + GetMd5Hash(hashm, tbxContraseña.Text) + "'", ref tbl);
            if (tbl.Rows.Count > 0)
            {
                DataRow row=tbl.Rows[0];
                VentasDLocal.aut = Convert.ToBoolean(row[2]);
                MessageBox.Show("Autorización concedida.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Verifique los datos");
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

        private void tbxID_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                tbxContraseña.Focus();
            }
        }

        private void tbxContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                btnAceptar.Focus();
            }
        }
    }
}
