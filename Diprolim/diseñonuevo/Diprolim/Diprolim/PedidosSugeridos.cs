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
    public partial class PedidosSugeridos : Form
    {
        Inventarios.DBMS_Unico Conexion;
        public PedidosSugeridos(Inventarios.DBMS_Unico svr)
        {
            InitializeComponent();
            dtpActual.Value = DateTime.Now.AddDays(1);
            Conexion = svr;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbl = new DataTable();
                Conexion.Conectarse();
                Conexion.Ejecutar("",ref tbl);
                Conexion.Desconectarse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
