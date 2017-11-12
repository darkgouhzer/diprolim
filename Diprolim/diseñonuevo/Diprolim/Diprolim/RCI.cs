using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Data;

namespace Diprolim
{
    public partial class RCI : DevExpress.XtraReports.UI.XtraReport
    {
        public string sCodigoVendedor = "";
        public string sNVendedor = "";
        public DataTable Tabla = new DataTable();
       
        public RCI()
        {
            InitializeComponent();
        }

        private void RCI_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
            lblNVendedor.Text = sNVendedor;
            if (Tabla.Rows.Count > 0)
            {
                this.DataSource = Tabla;
            }
        }

    }
}
