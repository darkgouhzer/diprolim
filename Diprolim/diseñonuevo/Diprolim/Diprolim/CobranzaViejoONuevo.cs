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
        UnicaSQL.DBMS_Unico Conexion;
        string vendedor = "";
        string cliente = "";
        public CobranzaViejoONuevo(UnicaSQL.DBMS_Unico sConexion)
        {
            InitializeComponent();
            Conexion = sConexion;
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
                CobranzaCredito cobcre = new CobranzaCredito(Conexion);
                cobcre.ShowDialog();
                this.Close();
            }
            else if (vendedor != "" && cliente == "")
            {
                CobranzaCredito cobcre = new CobranzaCredito(vendedor, Conexion);
                cobcre.ShowDialog();
                this.Close();
            }
            else if (vendedor != "" && cliente != "")
            {
                
                CobranzaCredito cobcre = new CobranzaCredito(vendedor,cliente, Conexion);
                cobcre.ShowDialog();
                this.Close();
            }
           
        }
    }
}
