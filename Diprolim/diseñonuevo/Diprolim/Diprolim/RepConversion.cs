using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Diprolim
{
    public partial class RepConversion : DevExpress.XtraReports.UI.XtraReport
    {
        public string sFuente = "", sFecha = "", sCodigo1 = "", sDescripcion1 = "", sCantidad1 = "", sCodigo2 = "", sDescripcion2 = "", sCantidad2 = "";
        public RepConversion()
        {
            InitializeComponent();
        }

        private void RepConversion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblFuente.Text = sFuente;
            lblFecha.Text = sFecha;
            lblCodigo1.Text = sCodigo1;
            lblDescripcion1.Text = sDescripcion1;
            lblCantidad1.Text = sCantidad1;
            lblCodigo2.Text = sCodigo2;
            lblDescripcion2.Text = sDescripcion2;
            lblCantidad2.Text = sCantidad2;
        }

    }
}
