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

namespace Diprolim
{
    public partial class Cobrar : Form
    {
        public Boolean bResult = false;
        public String sSuPago = "";
        public String sSuCambio = "";
        public Cobrar(Double dTotal)
        {
            InitializeComponent();
            lblTotalVenta.Text = dTotal.ToString("C2");
        }
        private void btnTerminarVenta_Click(object sender, EventArgs e)
        {
            if (tbxEfectivo.Text.Length == 0)
            {
                tbxEfectivo.Text = "0";
            }
            if (Double.Parse(lblTotalVenta.Text, NumberStyles.Currency) <= Convert.ToDouble(tbxEfectivo.Text))
            {
                bResult = true;
                sSuPago = tbxEfectivo.Text;
                sSuCambio = tbxCambio.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor de capturar suficiente efectivo.");
            }
            
        }

        private void tbxEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < tbxEfectivo.Text.Length; i++)
            {
                if (tbxEfectivo.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void Cobrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnTerminarVenta_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tbxEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void tbxEfectivo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var dTotal = Double.Parse(lblTotalVenta.Text, NumberStyles.Currency);
                var dEfectivo = Convert.ToDouble(tbxEfectivo.Text.Trim() =="" ? "0" :tbxEfectivo.Text);
                var dSuCambio = dEfectivo - dTotal;
                tbxCambio.Text = (dSuCambio < 0 ? 0 : dSuCambio).ToString();
            }
            catch (Exception)
            {
           
            }
            
        }
        
    }
}
