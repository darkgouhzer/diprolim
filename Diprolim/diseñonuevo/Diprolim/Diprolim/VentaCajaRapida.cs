using Entidades;
using ReglasNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicaSQL;

namespace Diprolim
{
    public partial class VentaCajaRapida : Form
    {
        ArticuloBO objArticuloBO;
        CArticulos objCArticulos;
        VentaBO objVentaBO = new VentaBO();
        int iFolioTicket = 0;
        String encabezado1 = "";
        String encabezado2 = "";
        String RFC = "";
        String Direccion = "";
        String Telefonos = "";
        String notafinal = "";
        String ImpresoraTicket = "";
        String sSuPago = "";
        String sSuCambio = "";
        DBMS_Unico Conexion;
        String UsuarioID;
        public VentaCajaRapida(DBMS_Unico Conexion, String UsuarioID)
        {
            InitializeComponent();
            panelContainer.Paint += pnlPanel_Paint;
            objArticuloBO = new ArticuloBO();
            CargarDatosTicket();
            this.Conexion = Conexion;
            this.UsuarioID = UsuarioID;
        } 
        public void CargarDatosTicket()
        {
            CImpresora objCImpresora = new CImpresora();
            ImpresoraBO objImpresoraBO = new ImpresoraBO();
            objCImpresora = objImpresoraBO.ObtenerDatosImpresora();
            encabezado1 = objCImpresora.Encabezado1;
            encabezado2 = objCImpresora.Encabezado2;
            RFC = objCImpresora.RFC;
            Direccion = objCImpresora.Direccion;
            Telefonos = objCImpresora.Telefonos;
            notafinal = objCImpresora.NotaFinal;
            ImpresoraTicket = objCImpresora.Impresora;
        }
        private Double CalcularDescuentoEnvase()
        {
            Double dDescuento = 0;
            if (chbxCambioEnvase.Checked)
            {
                dDescuento = (Convert.ToDouble(tbxCantidad.Text) * objCArticulos.PrecioCalle) * (objCArticulos.DescuentoEnvase / 100);
            }            
            return dDescuento;
        }
        private void VentaCajaRapida_KeyDown(object sender, KeyEventArgs e)
        {            
            if(e.KeyCode == Keys.F1)
            {
                if(tbxCodigo.Focused)
                {
                    BuscarArticulos objBuscarArticulos = new BuscarArticulos();
                    DialogResult dlg = objBuscarArticulos.ShowDialog();
                    if (dlg == DialogResult.OK)
                    {
                        tbxCodigo.Text = objBuscarArticulos.regresar.valXn;
                        obtenerProducto();
                       
                    }
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnNuevaVenta_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (tbxCodigo.Focused && tbxCodigo.Text.Length > 0)
                {
                    obtenerProducto();
                }
                else if (tbxCantidad.Focused)
                {
                    if (Convert.ToInt32(tbxCantidad.Text) > 0 && ValidarExistenciaArticulo())
                    {
                        int index = dtgVenta.Rows.Add();
                        DataGridViewRow row = (DataGridViewRow)dtgVenta.Rows[index];
                        row.Cells[0].Value = objCArticulos.Codigo;
                        row.Cells[1].Value = objCArticulos.Descripcion;
                        row.Cells[2].Value = tbxCantidad.Text;
                        row.Cells[3].Value = objCArticulos.PrecioCalle;
                        row.Cells[4].Value = CalcularDescuentoEnvase();//objCArticulos.Descuento;
                        row.Cells[5].Value = (Convert.ToDouble(row.Cells[2].Value) * objCArticulos.PrecioCalle) - Convert.ToDouble(row.Cells[4].Value);
                        row.Cells[6].Value = chbxCambioEnvase.Checked;
                    }
                    tbxCodigo.Clear();
                    tbxDescripcion.Clear();
                    tbxExistencias.Clear();
                    tbxCantidad.Clear();
                    tbxCodigo.Focus();
                    chbxCambioEnvase.Visible = false;
                    chbxCambioEnvase.Checked = false;
                }
            }
            else if (e.KeyCode == Keys.F5)
            {

                btnCobrar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {

                if (dtgVenta.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de querer salir de Caja rápida?", "Saliendo de Caja rápida", MessageBoxButtons.OKCancel);
                    if (DialogResult.OK == result)
                    {
                        this.Close();
                    }                    
                }
                else
                {
                    this.Close();
                }
                
            }
        }
        public void SumarTotales()
        {
            if (dtgVenta.Rows.Count > 0)
            {
                double sumar = 0;
                for (int i = 0; i < dtgVenta.Rows.Count; i++)
                {
                    sumar += Double.Parse(dtgVenta.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                }
                tbxSubtotal.Text = (sumar / 1.16).ToString("C2");
                tbxIVA.Text = (sumar - Double.Parse(tbxSubtotal.Text, NumberStyles.Currency)).ToString("C2");
                tbxTotal.Text = sumar.ToString("C2");
            }
            else
            {
                tbxSubtotal.Text = (0).ToString("C2");
                tbxIVA.Text = (0).ToString("C2");
                tbxTotal.Text = (0).ToString("C2");
            }
        }
        public Boolean ValidarExistenciaArticulo()
        {
            Boolean bAllOK = false;
            double dCantidad = 0;
            for (int i = 0; i < dtgVenta.Rows.Count; i++)
            {
                if (tbxCodigo.Text == dtgVenta.Rows[i].Cells[0].Value.ToString())
                {
                    dCantidad += Convert.ToDouble(dtgVenta.Rows[i].Cells[2].Value);
                }               
            }

            if ((Convert.ToDouble(tbxExistencias.Text) - dCantidad) >= Convert.ToDouble(tbxCantidad.Text))
            {
                bAllOK = true;
            }
            return bAllOK;
        }
        public void obtenerProducto()
        {
            try
            {
                objCArticulos = new CArticulos();
                objCArticulos = objArticuloBO.ObtenerDatosArticulo(Convert.ToInt32(tbxCodigo.Text));
                if (objCArticulos.Codigo > 0)
                {
                    tbxDescripcion.Text = objCArticulos.Descripcion + " " + objCArticulos.ValorMedida + objCArticulos.UnidadMedida;
                    tbxExistencias.Text = objCArticulos.Cantidad.ToString();
                    if (objCArticulos.Cantidad > 0)
                    {
                        tbxCantidad.Text = "1";
                    }
                    else
                    {
                        tbxCantidad.Text = "0";
                    }

                    
                    chbxCambioEnvase.Visible = objCArticulos.CodigoEnvase == 0 ? false : true;

                    if(objCArticulos.CodigoEnvase > 0)
                    {
                        DialogResult dlg = MessageBox.Show("¿La compra será con cambio de envase?", "Cambio de envase", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dlg)
                        {
                            chbxCambioEnvase.Checked = true;
                        }else
                        {
                            chbxCambioEnvase.Checked = false;
                        }
                    }

                    tbxCantidad.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dtgVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void pnlPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, this.panelContainer.Width - 1, this.panelContainer.Height - 1);
            //Pen p = new Pen(Color.Firebrick, 3);
            //e.Graphics.DrawRectangle(p, r);
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (dtgVenta.Rows.Count > 0)
            {
                Cobrar objCobrar = new Cobrar(Double.Parse(tbxTotal.Text, NumberStyles.Currency));
                objCobrar.ShowDialog();
             
                if (objCobrar.bResult)
                {
                   
                    objVentaBO = new VentaBO();
                    iFolioTicket = objVentaBO.RegistrarVenta(dtgVenta);
                    sSuPago = objCobrar.sSuPago;
                    sSuCambio = objCobrar.sSuCambio;
                    try
                    {
                        printDocument1.PrinterSettings.PrinterName = ImpresoraTicket;
                        printDocument1.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    dtgVenta.Rows.Clear();
                    SumarTotales();
                    MessageBox.Show("La venta ha sido realizada con éxito.");                    
                   
                }
             
            }
        }

        private void tbxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void tbxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void VentaCajaRapida_Load(object sender, EventArgs e)
        {

        }

        private void VentaCajaRapida_KeyUp(object sender, KeyEventArgs e)
        {
            SumarTotales();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font letraTi = new Font("Arial", 11, FontStyle.Bold);
            Font letraTi2 = new Font("Arial", 8, FontStyle.Bold);
            Font letra = new Font("Arial", 8);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            int y = 2;

            Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512; 
            Rectangle destRect1 = new Rectangle(2, y, 270,85);
            GraphicsUnit units = GraphicsUnit.Pixel;
            e.Graphics.DrawImage(newImage, destRect1, 0, 0, newImage.Width, newImage.Height, units);

            y = 43;

            y += 38;
            e.Graphics.DrawString(encabezado2, letraTi2, Brushes.Black, new Rectangle(0, y, 290, 50), stringFormat);
            y += 25;
            e.Graphics.DrawString(encabezado1 + " \nRFC: "+ RFC + " \n" + Direccion + " \n" + Telefonos, letra, Brushes.Black, new Rectangle(0, y, 290, 75), stringFormat);
            y += 25;
            y += 25;

            y += 12;
            e.Graphics.DrawString("Folio # " + iFolioTicket, letraTi2, Brushes.Black, new Rectangle(2, y, 290, 50));
            y += 12;
            e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"), letraTi, Brushes.Black, new Rectangle(2, y, 290, 50));
            y += 12;
            e.Graphics.DrawString("==============================", letraTi, Brushes.Black, new Rectangle(2, y, 290, 50));
            y += 12;
            e.Graphics.DrawString("CANT      DESCRIPCIÓN         PRECIO U       IMPORTE", new Font("Arial", 7, FontStyle.Bold), Brushes.Black, new Rectangle(2, y, 290, 50));
            y += 12;
            e.Graphics.DrawString("==============================", letraTi, Brushes.Black, new Rectangle(2, y, 290, 50));
            y += 12;

            for (int i = 0; i < dtgVenta.Rows.Count; i++)
            {
                e.Graphics.DrawString(dtgVenta.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(2, y, 28, 15));
                e.Graphics.DrawString(dtgVenta.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(30, y, 115, 15));
                e.Graphics.DrawString(dtgVenta.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(140, y, 290, 15));
                e.Graphics.DrawString((Convert.ToDouble(dtgVenta.Rows[i].Cells[4].Value) + Convert.ToDouble(dtgVenta.Rows[i].Cells[5].Value)).ToString("C2"), letra, Brushes.Black, new Rectangle(200, y, 290, 15));

                y += 12;

                if (Convert.ToDouble(dtgVenta.Rows[i].Cells[4].Value) > 0) {
                    e.Graphics.DrawString("Descuento", letra, Brushes.Black, new Rectangle(30, y, 115, 15));
                    e.Graphics.DrawString("-"+dtgVenta.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(200, y, 290, 15));
                    y += 12;
                }
              
            }


            e.Graphics.DrawString("==============================", letraTi, Brushes.Black, new Rectangle(2, y, 290, 50));

            y += 12;
            e.Graphics.DrawString("Subtotal:", letra, Brushes.Black, new Rectangle(150, y, 100, 15));
            e.Graphics.DrawString(tbxSubtotal.Text, letra, Brushes.Black, new Rectangle(200, y, 290, 15));

            y += 12;
            e.Graphics.DrawString("Iva:", letra, Brushes.Black, new Rectangle(150, y, 100, 15));
            e.Graphics.DrawString(tbxIVA.Text, letra, Brushes.Black, new Rectangle(200, y, 290, 15));

            y += 12;
            e.Graphics.DrawString("Total:", letra, Brushes.Black, new Rectangle(150, y, 100, 15));
            e.Graphics.DrawString(tbxTotal.Text, letra, Brushes.Black, new Rectangle(200, y, 280, 15));

            y += 12;
            //if (tipoTicket == "Reimpresion")
            //{
            //    e.Graphics.DrawString("Efectivo:", letra, Brushes.Black, new Rectangle(150, y, 100, 15));
            //    e.Graphics.DrawString(tbxTotal.Text, letra, Brushes.Black, new Rectangle(200, y, 290, 15));
            //    suCambio = "0";
            //}
            //else
            //{
                e.Graphics.DrawString("Efectivo:", letra, Brushes.Black, new Rectangle(150, y, 100, 15));
                e.Graphics.DrawString(Convert.ToDouble(sSuPago).ToString("C2"), letra, Brushes.Black, new Rectangle(200, y, 290, 15));
            //}
            y += 12;

            e.Graphics.DrawString("Cambio:", letra, Brushes.Black, new Rectangle(150, y, 100, 15));
            e.Graphics.DrawString(Convert.ToDouble(sSuCambio).ToString("C2"), letra, Brushes.Black, new Rectangle(200, y, 290, 15));
            
            y += 20;                        
            e.Graphics.DrawString(notafinal, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, y, 290, 75), stringFormat);

        }

        private void btnCancelaVenta_Click(object sender, EventArgs e)
        {
            ConsultaCancelaVentas rdv = new ConsultaCancelaVentas("1", true, Conexion, Convert.ToInt32(UsuarioID));
            rdv.ShowDialog();

            //CancelarVentasCajaRapida objCancelarVentasCajaRapida = new CancelarVentasCajaRapida();
            //objCancelarVentasCajaRapida.ShowDialog();
        
        }

        private void btnCorteCaja_Click(object sender, EventArgs e)
        {
            Corte_de_Caja cort = new Corte_de_Caja(Conexion, "1");
            cort.ShowDialog();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea iniciar una nueva venta?", "Nueva venta", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
            {
                tbxCodigo.Clear();
                tbxDescripcion.Clear();
                tbxExistencias.Clear();
                tbxCantidad.Clear();
                tbxCodigo.Focus();
                dtgVenta.Rows.Clear();
            }          
        }
    }
}
