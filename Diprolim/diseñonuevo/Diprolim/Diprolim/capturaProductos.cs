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
    public partial class capturaProductos : Form
    {
        conexion conn = new conexion();
        public capturaProductos()
        {
            InitializeComponent();
            unidades();

        }
        int dept=1;
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tbxVMedida.Text == "." || tbxPrecioProduccion.Text == "." || tbxPCalle.Text == "." || tbxPDistribuidor.Text == "." || tbxPAbarrotes.Text == ".")
            {
                MessageBox.Show("Verifique datos de valor de medida y precios");
            }
            else
            {
                if (cbxUMedida.Text != "")
                {
                    if (tbxDesc.Text != "" && tbxPrecioProduccion.Text != "" && cbxUMedida.Text != "" && tbxPrecioProduccion.Text != "" && tbxPCalle.Text != "" && tbxPAbarrotes.Text != "" && tbxPDistribuidor.Text != "")
                    {
                        MySqlConnection conectar = conn.ObtenerConexion();
                        MySqlCommand comando;
                        if (rbProductos.Checked)
                        {
                            dept = 1;
                        }
                        else if (rbAccesorios.Checked)
                        {
                            dept = 2;
                        }
                        else if (rbPapel.Checked)
                        {
                            dept = 3;
                        }
                        string comisionConsig, descuentoCont;
                        if (tbxDescuento.Text == "")
                        {
                            descuentoCont = "0";
                        }
                        else
                        {
                            descuentoCont = tbxDescuento.Text;
                        }
                        if (tbxComision.Text == "")
                        {
                            comisionConsig = "0";
                        }
                        else
                        {
                            comisionConsig = tbxComision.Text;
                        }
                        comando = new MySqlCommand("INSERT INTO articulos values(null,'" + tbxDesc.Text +
                            "'," + tbxPrecioProduccion.Text +
                            ",0, " + tbxVMedida.Text + ", " + cbxUMedida.SelectedValue + " ," + tbxPCalle.Text +
                            " , " + tbxPAbarrotes.Text + ", " + tbxPDistribuidor.Text + " , " + dept + ", " + descuentoCont + " , " + comisionConsig + ")", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();
                        MessageBox.Show("Producto agregado con éxito");
                        tbxDesc.Clear();

                        tbxPrecioProduccion.Clear();
                        tbxVMedida.Clear();
                        tbxPDistribuidor.Clear();
                        tbxPCalle.Clear();
                        tbxPAbarrotes.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario agregar una unidad de medida");
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxDesc.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbxVMedida.Focus();
                }
            }
        }

     

        private void tbxVMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxVMedida.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbxUMedida.Focus();
                }
            }
        }

        private void cbxUMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbxUMedida.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbxPrecioProduccion.Focus();
                }
            }
        }

        private void tbxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {

                e.Handled = true;

            }
        }

       

        private void tbxDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
        public void unidades()
        {
            List<sourceUnidadesMedida> lista = new List<sourceUnidadesMedida>();
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand("select id, nombre from unidad_medida", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                sourceUnidadesMedida datos = new sourceUnidadesMedida();
                datos.ID = lector.GetInt32(0);
                datos.nombre = lector.GetString(1);
                lista.Add(datos);
            }
            conectar.Close();
            cbxUMedida.DataSource = lista;
            cbxUMedida.DisplayMember = "nombre";
            cbxUMedida.ValueMember = "ID";

        }
        private void capturaProductos_Load(object sender, EventArgs e)
        {

        }

        private void tbxVMedida_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (tbxVMedida.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbxUMedida.Focus();
                }
            }
        }

        private void tbxPrecioProduccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxPrecioProduccion.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbxPCalle.Focus();
                }
            }
        }

        private void tbxPCalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxPCalle.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbxPAbarrotes.Focus();
                }
            }
        }

        private void tbxPAbarrotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxPAbarrotes.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbxPDistribuidor.Focus();
                }
            }
        }

        private void tbxPDistribuidor_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxPDistribuidor.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbxDescuento.Focus();
                }
            }
        }

        private void tbxPCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxPCalle.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxPAbarrotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxPAbarrotes.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxPDistribuidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxPDistribuidor.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxPrecioProduccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar==46 && tbxPrecioProduccion.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar)&&!Char.IsControl(e.KeyChar)&&e.KeyChar!=46)
            {

                e.Handled = true;

            }
        }

        private void tbxVMedida_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxVMedida.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxDescuento.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbxComision.Focus();
                }
            }
        }

        private void tbxComision_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbxComision_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxComision.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnGuardar.Focus();
                }
            }
        }

    }
}
