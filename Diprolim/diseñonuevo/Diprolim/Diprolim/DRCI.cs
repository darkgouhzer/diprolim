using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Diprolim
{
    public partial class DRCI : DevExpress.XtraReports.UI.XtraReport
    {
        public string sDireccion = "";
        public string sNCliente = "";
        public DataTable Tabla = new DataTable();
        public DRCI()
        {
            InitializeComponent();
        }

        private void DRCI_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            lblNCliente.Text = sNCliente;
            lblDireccion.Text = sDireccion;
            if (Tabla.Rows.Count > 0)
            {
                this.DataSource = Tabla;
            }
        }

    }
}
