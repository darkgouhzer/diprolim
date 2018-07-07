using Identidades;
using MySql.Data.MySqlClient;
using ReglasNegocios;
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
        CorteCajaBO objCorteCajaBO;
        String ImpresoraTicket = "";
        public Corte_de_Caja(UnicaSQL.DBMS_Unico sConexion)
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            CargarDatosTicket();
        }
        public Corte_de_Caja(UnicaSQL.DBMS_Unico sConexion, String sVendedor)
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            tbxVendedor.Text = sVendedor;
            btnCambiarVendedor.Enabled = false;
            btnBuscar.Enabled = false;
            tbxVendedor.ReadOnly = true;
            obtenerVendedor();
            CargarDatosTicket();
        }  
        public void obtenerVendedor()
        {
            if (tbxVendedor.Text != "")
            {
                objCorteCajaBO = new CorteCajaBO();
                CCorteIndividual objCCorteIndividual = new CCorteIndividual();
                objCCorteIndividual = objCorteCajaBO.ObtenerTotalesCorte(Convert.ToInt32(tbxVendedor.Text.Trim()), dtpFecha.Value);
                tbxNVendedor.Text = objCCorteIndividual.NombreVendedor;                
                tbxGastos.Text = objCCorteIndividual.Gastos.ToString();
                tbxConcepto.Text = objCCorteIndividual.Concepto;                
                tbxFiado.Text = Math.Round(objCCorteIndividual.Fiado, 2).ToString();
                tbxRecuperado.Text = Math.Round(objCCorteIndividual.Recuperado, 2).ToString();
                tbxVT.Text = Math.Round(objCCorteIndividual.VentasTotales, 2).ToString();
                tbxIva.Text = Math.Round(objCCorteIndividual.IVA, 2).ToString();
                tbxGastos.Focus();
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
                btnBuscar.Enabled = false;
            }
            else
            {
                tbxVendedor.ReadOnly = false;
                btnBuscar.Enabled = true;
            }
        }

        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {
            tbxVendedor.Clear();
            tbxVendedor.ReadOnly = false;
            tbxNVendedor.Clear();
            btnBuscar.Enabled = true;
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
                btnBuscar.Enabled = false;
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

        private void Corte_de_Caja_Load(object sender, EventArgs e)
        {
            tbxVendedor.Focus();
        }

        private void tbxVT_KeyDown(object sender, KeyEventArgs e)
        {

        }
        
        private void btnRegistrarS_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "")
            {
                if (dtpFecha.Value.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"))
                {
                    CorteCajaBO objCorteCajaBO = new CorteCajaBO();
                    CCorteIndividual objCCorteIndividual = new CCorteIndividual();
                    objCCorteIndividual.IDEmpleado = Convert.ToInt32(tbxVendedor.Text);
                    objCCorteIndividual.VentasTotales = Convert.ToDouble(tbxVT.Text);
                    objCCorteIndividual.IVA = Convert.ToDouble(tbxIva.Text);
                    objCCorteIndividual.Recuperado = Convert.ToDouble(tbxRecuperado.Text);
                    objCCorteIndividual.Fiado = Convert.ToDouble(tbxFiado.Text);
                    objCCorteIndividual.Gastos = Convert.ToDouble(tbxGastos.Text);
                    objCCorteIndividual.EfectivoEntrega = Convert.ToDouble(lblEfectivo.Text);
                    objCCorteIndividual.Concepto = tbxConcepto.Text;
                    objCCorteIndividual.Fecha = dtpFecha.Value;
                    if(objCorteCajaBO.GenerarCorteIndividual(objCCorteIndividual))
                    {
                        MessageBox.Show("Guardado con éxito");
                    }                    
                }
                else
                {
                    MessageBox.Show("No puede guardar de días anteriores");
                }
              
            }
        }     

        private void tbxGastos_Leave(object sender, EventArgs e)
        {            
            if (tbxGastos.Text.Trim() == "" || tbxGastos.Text.Trim() == ".")
            {
                tbxGastos.Text = "0";
            }
            sumar();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font letraTi = new Font("Arial", 11, FontStyle.Bold);
            Font letraTi2 = new Font("Arial", 8, FontStyle.Bold);
            Font letra = new Font("Arial", 8);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            int y = 2;
            int x = 2;

            #region titulo
            e.Graphics.DrawString("CORTE DE CAJA INDIVIDUAL", letraTi, Brushes.Black, new Rectangle(0, y, 290, 50), stringFormat);
            #endregion
            y += 38;
            #region Fecha
            e.Graphics.DrawString("Fecha: " + dtpFecha.Value.ToString("dd/MMMM/yyyy"), letraTi2, Brushes.Black, new Rectangle(x, y, 290, 50));
            #endregion
            y += 25;
            e.Graphics.DrawString(tbxNVendedor.Text, letra, Brushes.Black, new Rectangle(x, y, 290, 75));
            y += 40;
            #region VentasTotales

            Pen p = new Pen(Brushes.Black, 1.5f);

            e.Graphics.DrawString("Ventas totales: ", letra, Brushes.Black, new Rectangle(x, y, 290, 50));
            e.Graphics.DrawString("$ " + tbxVT.Text, letra, Brushes.Black, new Rectangle(140, y, 290, 50));
            y += 25;
            #endregion
            #region Recuperado

            e.Graphics.DrawString("IVA: ", letra, Brushes.Black, new Rectangle(x, y, 290, 50));
            e.Graphics.DrawString("$ " + tbxIva.Text, letra, Brushes.Black, new Rectangle(140, y, 290, 50));
            y += 25;
            #endregion

            #region Recuperado

            e.Graphics.DrawString("Recuperado: ", letra, Brushes.Black, new Rectangle(x, y, 290, 50));
            e.Graphics.DrawString("$ " + tbxRecuperado.Text, letra, Brushes.Black, new Rectangle(140, y, 290, 50));
            y += 25;
            #endregion

            #region Fiado

            e.Graphics.DrawString("Fiado:", letra, Brushes.Black, new Rectangle(x, y, 290, 50));
            e.Graphics.DrawString("$ " + tbxFiado.Text, letra, Brushes.Black, new Rectangle(140, y, 290, 50));
            y += 25;
            #endregion

            #region Gastos

            e.Graphics.DrawString("Gastos:", letra, Brushes.Black, new Rectangle(x, y, 290, 50));
            e.Graphics.DrawString("$ " + tbxGastos.Text , letra, Brushes.Black, new Rectangle(140, y, 290, 50));
            y += 25;
            #endregion

            #region Efectivo
            e.Graphics.DrawString("Efectivo a entregar:", letra, Brushes.Black, new Rectangle(x, y, 290, 50));
            e.Graphics.DrawString("$ " + lblEfectivo.Text, letra, Brushes.Black, new Rectangle(140, y, 290, 50));
            y += 25;
            #endregion
        }

       // private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
       // {
       //     Font letra = new Font("Arial", 12);
       //     Font letra2 = new Font("Arial", 12,FontStyle.Bold);
       //     int x = 120;
       //     //int L = 105;
       //     int y = 25;

       //     #region titulo
       //     e.Graphics.DrawString("CORTE DE CAJA POR VENDEDOR", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 5*2, 50, 500, tbxNVendedor.Height + 15));
       //     #endregion
       //     #region Fecha
       //     e.Graphics.DrawString(dtpFecha.Value.ToString("dd/MMMM/yyyy"), letra2, Brushes.Black, new Rectangle(e.MarginBounds.Width/10*9, y * 4, 500, tbxNVendedor.Height + 15));
       //#endregion

       //     #region NombreVendedor
       //     e.Graphics.DrawString("Vendedor: ", letra2, Brushes.Black, new Rectangle(x, y * 4, 500, tbxNVendedor.Height + 15));
       //     e.Graphics.DrawString(tbxNVendedor.Text, letra, Brushes.Black, new Rectangle(x+100, y * 4, 500, tbxNVendedor.Height + 15));
       //     #endregion

       //     #region VentasTotales

       //     Pen p = new Pen(Brushes.Black, 1.5f);

       //     e.Graphics.DrawString("Ventas totales: ", letra2, Brushes.Black, new Rectangle(x, y*5, 500, tbxVT.Height + 15));
       //     e.Graphics.DrawString("$ "+tbxVT.Text, letra, Brushes.Black, new Rectangle(x+160, y * 5, 500, tbxVT.Height + 15));

       //     #endregion

       //     #region Recuperado

       //     e.Graphics.DrawString("Recuperado: ", letra2, Brushes.Black, new Rectangle(x, y*6, 500, tbxRecuperado.Height + 15));
       //     e.Graphics.DrawString("$ " + tbxRecuperado.Text, letra, Brushes.Black, new Rectangle(x + 160, y * 6, 500, tbxRecuperado.Height + 15));

       //     #endregion

       //     #region Fiado
                
       //     e.Graphics.DrawString("Fiado:", letra2, Brushes.Black, new Rectangle(x, y*7, 500, tbxFiado.Height + 15));
       //     e.Graphics.DrawString("$ " + tbxFiado.Text, letra, Brushes.Black, new Rectangle(x + 160, y * 7, 500, tbxFiado.Height + 15));
                
       //     #endregion

       //     #region Gastos
                
       //     e.Graphics.DrawString("Gastos:", letra2, Brushes.Black, new Rectangle(x, y*8, 500, tbxConcepto.Height + 15));
       //     e.Graphics.DrawString("$ " + tbxGastos.Text + "          " + tbxConcepto.Text, letra, Brushes.Black, new Rectangle(x + 160, y * 8, 500, tbxConcepto.Height + 15));

       //     #endregion

       //     #region Efectivo
       //     Pen pl = new Pen(Brushes.Black, 2.0f);
       //     e.Graphics.DrawLine(pl, 210.0f, 220.0f,350.0f, 220.0f);
       //     e.Graphics.DrawString("Efectivo a entregar:", letra2, Brushes.Black, new Rectangle(x , y*9, 500, tbxConcepto.Height + 15));
       //     e.Graphics.DrawString("$ " + lblEfectivo.Text, letra, Brushes.Black, new Rectangle(x+160, y * 9, 500, tbxConcepto.Height + 15));

       //     #endregion             
            
       // }

        private void btnImprimirCr_Click(object sender, EventArgs e)
        {
            printDocument1.PrinterSettings.PrinterName = ImpresoraTicket;
            printDocument1.Print();
        }
        public void CargarDatosTicket()
        {
            CImpresora objCImpresora = new CImpresora();
            ImpresoraBO objImpresoraBO = new ImpresoraBO();
            objCImpresora = objImpresoraBO.ObtenerDatosImpresora();
            ImpresoraTicket = objCImpresora.Impresora;
        }
        private void tbxVendedor_Leave(object sender, EventArgs e)
        {
            if (tbxVendedor.Text.Length > 0)
            {
                obtenerVendedor();

                tbxVendedor.ReadOnly = true;
                btnBuscar.Enabled = false;
            }
        }

        private void Corte_de_Caja_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
