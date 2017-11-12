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
    public partial class CobranzaViejoONuevo : Form
    {
        string vendedor = "";
        string cliente = "";
        public CobranzaViejoONuevo()
        {
            InitializeComponent();
        }
        public CobranzaViejoONuevo(string id)
        {
            InitializeComponent();
            vendedor = id;
        }
        public CobranzaViejoONuevo(string vend, string client)
        {
            InitializeComponent();
            vendedor = vend;
            cliente = client;
        }


        private void btnanterior_Click(object sender, EventArgs e)
        {
            if (vendedor == "" && cliente == "")
            {
                Cobranza cob = new Cobranza();
                cob.ShowDialog();
                this.Close();
            }
            else if (vendedor != "" && cliente == "")
            {
                Cobranza cob = new Cobranza(vendedor);
                cob.ShowDialog();
                this.Close();
            }
            else if (vendedor != "" && cliente != "")
            {
                Cobranza cob = new Cobranza(vendedor,cliente);
                cob.ShowDialog();
                this.Close();
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            if (vendedor == "" && cliente == "")
            {
                CobranzaCredito cobcre = new CobranzaCredito();
                cobcre.ShowDialog();
                this.Close();
            }
            else if (vendedor != "" && cliente == "")
            {
                CobranzaCredito cobcre = new CobranzaCredito(vendedor);
                cobcre.ShowDialog();
                this.Close();
            }
            else if (vendedor != "" && cliente != "")
            {
                
                CobranzaCredito cobcre = new CobranzaCredito(vendedor,cliente);
                cobcre.ShowDialog();
                this.Close();
            }
           
        }
    }
}
