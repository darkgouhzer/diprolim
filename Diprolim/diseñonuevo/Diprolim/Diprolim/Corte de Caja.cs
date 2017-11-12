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
    public partial class Corte_de_Caja : Form
    {
        conexion conn = new conexion();
        MySqlCommand comando;
        Inventarios.DBMS_Unico Conexion;
        
        public Corte_de_Caja(Inventarios.DBMS_Unico sConexion)
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            Conexion=sConexion;
            
        }
        
        public void obtenerVendedor()
        {
            if (tbxVendedor.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("Select nombre, apellido_paterno, apellido_materno from empleados where id_empleado=" + tbxVendedor.Text, conectar);
                conectar.Open();
                MySqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tbxNVendedor.Text = lector.GetString(0) + " " + lector.GetString(1) + " " + lector.GetString(2);
                    
                }
                tbxGastos.Focus();
                conectar.Close();
                checar();
                if(i>0)
                {
                    comando = new MySqlCommand("Select Gastos,Concepto from cortedcaja where empleados_id_empleado=" + tbxVendedor.Text + " and Fecha='" + dtpFecha.Value.ToString("yyyyMMdd") + "'", conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                       
                        tbxGastos.Text = lector.GetString(0);
                        tbxConcepto.Text = lector.GetString(1);
                    }
                    tbxGastos.Focus();
                    conectar.Close();
                }
                CargarTodo();
                GV();
                sumar();
            }

        }
        double sumaaa = 0;
        public void sumar()
        {
            if (tbxGastos.Text == "")
            {
                sumaaa = ((Convert.ToDouble(tbxVT.Text)) + Convert.ToDouble(tbxIva.Text) + (Convert.ToDouble(tbxRecuperado.Text))) - (Convert.ToDouble(tbxFiado.Text));
               
            }
            else
            {
                sumaaa = ((Convert.ToDouble(tbxVT.Text)) + Convert.ToDouble(tbxIva.Text) + (Convert.ToDouble(tbxRecuperado.Text))) - (Convert.ToDouble(tbxFiado.Text))-Convert.ToDouble(tbxGastos.Text);
                
            }
            lblEfectivo.Text = sumaaa.ToString();
        }
        public void GV()
        {
            
                MySqlConnection conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("Select importe, iva from ventas where empleados_id_empleado=" + tbxVendedor.Text + " and fecha_venta BETWEEN '" +
            dtpFecha.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFecha.Value.ToString("yyyyMMdd235959") + "'", conectar);
                conectar.Open();
                MySqlDataReader lector = comando.ExecuteReader();
                double sumaVentaTotal = 0;
                double sumaIva = 0;         
                
                while (lector.Read())
                {
                    if(Convert.ToDouble(lector.GetDouble(1))>0)
                    {
                        sumaVentaTotal += lector.GetDouble(0)/1.16;
                        sumaIva += lector.GetDouble(0) - (lector.GetDouble(0)/1.16);
                    }
                    else
                    {
                        sumaVentaTotal += lector.GetDouble(0);
                    }
                    
                }
                tbxVT.Text =Math.Round(sumaVentaTotal, 2).ToString();
                tbxGastos.Focus();
          //      conectar.Close();
          //      comando = new MySqlCommand("Select iva from ventas where tipo_compra='contado' and empleados_id_empleado=" + tbxVendedor.Text + " and fecha_venta BETWEEN '" +
          //dtpFecha.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFecha.Value.ToString("yyyyMMdd235959") + "'", conectar);
          //      conectar.Open();
          //      lector = comando.ExecuteReader();
                
          //      double sumaIva = 0;
          //      while (lector.Read())
          //      {
          //          sumaIva += lector.GetDouble(0);
          //      }
                tbxIva.Text = Math.Round(sumaIva, 2).ToString(); 
                tbxGastos.Focus();
                conectar.Close();            
        }
       
        
        public void CargarTodo()
        {            
                MySqlConnection conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("Select importe, Iva from  ventas  where empleados_id_empleado=" + tbxVendedor.Text + " and tipo_compra='credito' and fecha_venta BETWEEN '" +
            dtpFecha.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFecha.Value.ToString("yyyyMMdd235959") + "'", conectar);
                conectar.Open();
                MySqlDataReader lector = comando.ExecuteReader();
                double sumaVentaCredito = 0;
                while (lector.Read())
                {                   
                        sumaVentaCredito += lector.GetDouble(0);
                }

                tbxFiado.Text = Math.Round(sumaVentaCredito, 2).ToString(); 
                conectar.Close();
                
                double sumaAbono = 0;         
                //---------------------
            //Total Abonos
                
                comando = new MySqlCommand("select abono  from abonos where "+
                    " empleados_id_empleado=" + tbxVendedor.Text + " AND fecha between '" + dtpFecha.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFecha.Value.ToString("yyyyMMdd235959") + "'", conectar);
                conectar.Open();
                //DataTable Tabla23= new DataTable();
                //Tabla23.Load(comando.ExecuteReader());
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    sumaAbono += lector.GetDouble(0);
                }
        
                conectar.Close();
                tbxRecuperado.Text =Math.Round(sumaAbono, 2).ToString();
            //---------------------

        }
        private void btnB_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (id.regresar.valXn != "1")
                {
                    tbxVendedor.Text = id.regresar.valXn;
                    obtenerVendedor();
                }
            }
            if (id.regresar.valXn != "1" && tbxVendedor.Text != "")
            {
                tbxVendedor.ReadOnly = true;
                btnB.Enabled = false;
            }
            else
            {
                tbxVendedor.ReadOnly = false;
                btnB.Enabled = true;
            }
        }

        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {
            tbxVendedor.Clear();
            tbxVendedor.ReadOnly = false;
            tbxNVendedor.Clear();
            btnB.Enabled = true;
            tbxVT.Clear();
            tbxIva.Clear();
            tbxRecuperado.Clear();
            
            tbxGastos.Clear();
            tbxFiado.Clear();
            
            lblEfectivo.Text = "";
        }

        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                obtenerVendedor();
                
                tbxVendedor.ReadOnly = true;
                btnB.Enabled = false;
            }
        }
        
        private void tbxGastos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxGastos.Text == ".")
                {
                    MessageBox.Show("Verifica la cantidad de gastos");
                    tbxGastos.Focus();

                }
                else
                {
                    if (tbxGastos.Text != "")
                    {
                        sumar();
                        tbxConcepto.Focus();
                    }
                }
            }
        }

        private void tbxGastos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxGastos.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxVendedor_KeyDown_1(object sender, KeyEventArgs e)
        {
           
        }

        private void tbxVendedor_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void Corte_de_Caja_Load(object sender, EventArgs e)
        {
            tbxVendedor.Focus();
        }

        private void tbxVT_KeyDown(object sender, KeyEventArgs e)
        {

        }
        int i = 0;
        private void btnRegistrarS_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "")
            {
                if (dtpFecha.Value.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"))
                {
                    sumar();
                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;

                    checar();
                    double gastos = 0;
                    if (tbxGastos.Text != "")
                    {
                        gastos = Convert.ToDouble(tbxGastos.Text);
                    }
                    if (i == 0)
                    {

                        comando = new MySqlCommand("INSERT INTO cortedcaja values(null," + tbxVendedor.Text + "," + tbxVT.Text + "," + tbxRecuperado.Text + "," + tbxFiado.Text + "," + gastos + ",'" + tbxConcepto.Text + "'," + lblEfectivo.Text + ",'" + dtpFecha.Value.ToString("yyyyMMdd") + "'," + tbxIva.Text + ")", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();
                        MessageBox.Show("Guardado con éxito");
                    }
                    else
                    {
                        comando = new MySqlCommand("UPDATE cortedcaja SET Ventas_Totales=" + tbxVT.Text + ",iva=" + tbxIva.Text + " ,Recuperado=" + tbxRecuperado.Text + ", Fiado=" + tbxFiado.Text + ", Gastos=" + tbxGastos.Text + ", Concepto='" + tbxConcepto.Text + "', EfectivoAEntregar=" + lblEfectivo.Text + " WHERE empleados_id_empleado=" + tbxVendedor.Text + " AND Fecha='" + dtpFecha.Value.ToString("yyyyMMdd") + "'", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();
                        MessageBox.Show("Cambios guardados con éxito");
                    }
                }
                else
                {
                    MessageBox.Show("No puede guardar días anteriores");
                }
              
            }
        }
        public void checar()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("SELECT count(*) FROM cortedcaja where empleados_id_empleado="+tbxVendedor.Text+" and Fecha='"+ dtpFecha.Value.ToString("yyyyMMdd") +"'", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
           
            while (lector.Read())
            {
                i = lector.GetInt32(0);

            }
            conectar.Close();
        }

        private void tbxGastos_Leave(object sender, EventArgs e)
        {
            if (tbxGastos.Text == ".")
            {
                MessageBox.Show("Verifica la cantidad de gastos");
                tbxGastos.Focus();
            }
            else
            {
                if (tbxGastos.Text != "")
                {
                    sumar();
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font letra = new Font("Arial", 12);
            Font letra2 = new Font("Arial", 12,FontStyle.Bold);
            int x = 120;
            //int L = 105;
            int y = 25;

            #region titulo
            e.Graphics.DrawString("CORTE DE CAJA POR VENDEDOR", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 5*2, 50, 500, tbxNVendedor.Height + 15));
            #endregion
            #region Fecha
            e.Graphics.DrawString(dtpFecha.Value.ToString("dd/MMMM/yyyy"), letra2, Brushes.Black, new Rectangle(e.MarginBounds.Width/10*9, y * 4, 500, tbxNVendedor.Height + 15));
       #endregion

            #region NombreVendedor
            e.Graphics.DrawString("Vendedor: ", letra2, Brushes.Black, new Rectangle(x, y * 4, 500, tbxNVendedor.Height + 15));
            e.Graphics.DrawString(tbxNVendedor.Text, letra, Brushes.Black, new Rectangle(x+100, y * 4, 500, tbxNVendedor.Height + 15));
            #endregion

            #region VentasTotales

            Pen p = new Pen(Brushes.Black, 1.5f);

            e.Graphics.DrawString("Ventas totales: ", letra2, Brushes.Black, new Rectangle(x, y*5, 500, tbxVT.Height + 15));
            e.Graphics.DrawString("$ "+tbxVT.Text, letra, Brushes.Black, new Rectangle(x+160, y * 5, 500, tbxVT.Height + 15));

            #endregion

            #region Recuperado

            e.Graphics.DrawString("Recuperado: ", letra2, Brushes.Black, new Rectangle(x, y*6, 500, tbxRecuperado.Height + 15));
            e.Graphics.DrawString("$ " + tbxRecuperado.Text, letra, Brushes.Black, new Rectangle(x + 160, y * 6, 500, tbxRecuperado.Height + 15));

            #endregion

            #region Fiado
                
            e.Graphics.DrawString("Fiado:", letra2, Brushes.Black, new Rectangle(x, y*7, 500, tbxFiado.Height + 15));
            e.Graphics.DrawString("$ " + tbxFiado.Text, letra, Brushes.Black, new Rectangle(x + 160, y * 7, 500, tbxFiado.Height + 15));
                
            #endregion

            #region Gastos
                
            e.Graphics.DrawString("Gastos:", letra2, Brushes.Black, new Rectangle(x, y*8, 500, tbxConcepto.Height + 15));
            e.Graphics.DrawString("$ " + tbxGastos.Text + "          " + tbxConcepto.Text, letra, Brushes.Black, new Rectangle(x + 160, y * 8, 500, tbxConcepto.Height + 15));

            #endregion

            #region Efectivo
            Pen pl = new Pen(Brushes.Black, 2.0f);
            e.Graphics.DrawLine(pl, 210.0f, 220.0f,350.0f, 220.0f);
            e.Graphics.DrawString("Efectivo a entregar:", letra2, Brushes.Black, new Rectangle(x , y*9, 500, tbxConcepto.Height + 15));
            e.Graphics.DrawString("$ " + lblEfectivo.Text, letra, Brushes.Black, new Rectangle(x+160, y * 9, 500, tbxConcepto.Height + 15));

            #endregion             
            
        }

        private void btnImprimirCr_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
