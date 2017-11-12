using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Diprolim
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public string sCodigoVendedor = "";
        public string sNVendedor = "";
        public DataGridView Tabla = new DataGridView();
        public XtraReport1()
        {
            InitializeComponent();
            
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          
        }

        private void XtraReport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblNVendedor.Text = sNVendedor;
            if (Tabla.Rows.Count > 0)
            {
                this.DataSource = Tabla;
            }
        }

    }
}
