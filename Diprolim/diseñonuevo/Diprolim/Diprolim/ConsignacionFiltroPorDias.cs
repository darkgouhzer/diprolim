using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Data;

namespace Diprolim
{
    public partial class ConsignacionFiltroPorDias : DevExpress.XtraReports.UI.XtraReport
    {
       public DataTable Tabla = new DataTable();
       public string sMotivo = "";
        public ConsignacionFiltroPorDias()
        {
            InitializeComponent();
        }

        private void ConsignacionFiltroPorDias_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblMotivo.Text = sMotivo;
            this.DataSource = Tabla;
        }

    }
}
