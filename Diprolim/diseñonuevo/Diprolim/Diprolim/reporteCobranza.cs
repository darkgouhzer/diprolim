using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace Diprolim
{
    public partial class reporteCobranza : Form
    {
        conexion conn = new conexion();
        MySqlCommand comando;
        MySqlConnection conectar;
        MySqlDataReader lector;
        public reporteCobranza()
        {
            InitializeComponent();           
            dtpInicio.Value = DateTime.Now.AddDays(-15);
            dtpFin.Value = DateTime.Now;
            dtpInicioC.Value = DateTime.Now.AddDays(-15);
            dtpFinC.Value = DateTime.Now;
            actualizarDias();
        }
        public void actualizarDias()
        {

            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("update adeudos set dias=(select to_days(now())-to_days(fecha)+1) where saldo>0", conectar);
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        string idVendedor="",idCliente="";
        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (tbxCliente.Text.Length > 0)
            {
                dtgHistTabla.Rows.Clear();
                if (tbxVendedor.Text.Length > 0)
                {
                    idVendedor = " and empleados_id_empleado=" + tbxVendedor.Text;
                }
                else
                {
                    idVendedor = "";
                }
                if (tbxCliente.Text.Length > 0)
                {
                    idCliente = " and clientes_idclientes=" + tbxCliente.Text;
                }
                
                conectar = conn.ObtenerConexion();
               
                comando = new MySqlCommand("select Fecha,Adeudo,Abono,Fiado_nuevo,Pendiente,Dias from cobranza where fecha BETWEEN '" +
                dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'" + idVendedor + " " + idCliente, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dtgHistTabla.Rows.Add(lector.GetDateTime(0), lector.GetDouble(1), lector.GetDouble(2), lector.GetDouble(3), lector.GetDouble(4), lector.GetInt32(5));
                }
                conectar.Close();
            }
            else
            {
                MessageBox.Show("Primero debe indicar el código de un cliente.");
            }           
        }

        private void rbtnPCliente_CheckedChanged(object sender, EventArgs e)
        {
            tbxCliente.Enabled = true;
            btnB.Enabled = true;
            tbxCliente.ReadOnly = false;
        }

        private void rbtnGeneral_CheckedChanged(object sender, EventArgs e)
        {
            tbxCliente.Enabled = false;
            btnB.Enabled = false;            
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCliente.Text = id.regresar.valXn;
                ObtnerCliente(tbxCliente.Text);
            }
            tbxCliente.Focus();
        }
        public string ObtnerCliente(string cliente)
        {
            string Resultado = "";
            
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("SELECT a.idclientes, a.nombre, a.categorias_idcategorias, u.Vendedor, a.empleados_id_empleado " +
                            "FROM clientes a, categorias u WHERE idclientes =" + cliente + " and a.categorias_idcategorias=u.idcategorias", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {                   
                        Resultado = lector.GetString(1);
                        des = lector.GetString(0);
                        //tbxCliente.ReadOnly = true;
                        //btnB.Enabled = false;
                        //btnReporteHistorial.Focus();
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de cliente no existente");
                    return Resultado;
                    //tbxCliente.Clear();
                    //tbxNCliente.Clear();
                    //tbxCliente.Focus();
                }            
            return Resultado;
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedor.Text = id.regresar.valXn;
                tbxNVendedor.Text=obtenerVendedor(tbxVendedor.Text);
            }
            tbxVendedor.ReadOnly = true;
            btnSP.Enabled = false;
           
            tbxCliente.Focus();
            
        }
        public string obtenerVendedor(string vendedor)
        {
            string resultado="";
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("Select nombre, apellido_paterno, apellido_materno from empleados where id_empleado=" + vendedor, conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            string dess = "";
            while (lector.Read())
            {
                dess = lector.GetString(0);
                resultado = lector.GetString(0) + " " + lector.GetString(1) + " " + lector.GetString(2);               
            }
            conectar.Close();
            if (dess == "")
            {
                MessageBox.Show("Código de vendedor no existente");
                return resultado;
                //tbxVendedor.Clear();
                //tbxNVendedor.Clear();
                //tbxVendedor.Focus();

            }
            return resultado;
        }

        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxVendedor.Text != "")
                {
                   tbxNVendedor.Text= obtenerVendedor(tbxVendedor.Text);
                   tbxVendedor.ReadOnly = true;
                   btnSP.Enabled = false;
                   if (tbxNVendedor.Text.Length > 0) {
                       if (tbxVendedor.Text != "")
                       {
                           tbxCliente.Focus();
                       }
                   }
                   else
                   {
                       tbxVendedor.ReadOnly = false;
                       btnSP.Enabled = true;
                       tbxVendedor.Focus();
                   }
                }
            }
        }

        private void tbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxCliente.Text.Length > 0)
                {
                    tbxNCliente.Text = ObtnerCliente(tbxCliente.Text);
                    btnReporteHistorial.Focus();
                    if (tbxNCliente.Text == "")
                    {
                        tbxCliente.Focus();

                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tbxVendedor.Clear();
            btnSP.Enabled = true;
            tbxNVendedor.Clear();
            tbxCliente.Clear();
            tbxNCliente.Clear();
            
            tbxVendedor.ReadOnly = false;
            dtgHistTabla.Rows.Clear();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            tbxCliente.Clear();
            tbxNCliente.Clear();
            btnB.Enabled = true;
            tbxCliente.ReadOnly = false;
            dtgHistTabla.Rows.Clear();
        }

        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        private void tbxCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        private void tbxCrVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxCrVendedor.Text != "")
                {
                    tbxNCrVendedor.Text = obtenerVendedor(tbxCrVendedor.Text);
                    tbxCrVendedor.ReadOnly = true;
                    btnSCrV.Enabled = false;
                    if (tbxNCrVendedor.Text.Length > 0)
                    {
                        if (tbxCrVendedor.Text != "")
                        {
                            tbxCrCliente.Focus();
                        }
                    }
                    else
                    {
                        tbxCrVendedor.ReadOnly = false;
                        btnSCrV.Enabled = true;
                        tbxCrVendedor.Focus();
                    }
                }
            }
        }

        private void btnCrRVendedor_Click(object sender, EventArgs e)
        {
            tbxCrCliente.Clear();
            tbxNCrCliente.Clear();
            tbxNCrVendedor.Clear();
            tbxCrVendedor.Clear();
            tbxCrVendedor.ReadOnly = false;
            tbxCrVendedor.Enabled = true;
            btnSCrV.Enabled = true;
            btnSPCrC.Enabled = true;
            dtgCrTabla.Rows.Clear();

        }

        private void btnSCrV_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCrVendedor.Text = id.regresar.valXn;
                tbxNCrVendedor.Text = obtenerVendedor(tbxCrVendedor.Text);
            }
            if (tbxCrVendedor.Text.Length > 0)
            {
                tbxCrVendedor.ReadOnly = true;
                btnSCrV.Enabled = false;
            }
            else
            {
                tbxCrVendedor.ReadOnly = false;
                btnSCrV.Enabled = true;
                tbxCrCliente.Focus();
            }

            
        }

        private void btnSPCrC_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes(tbxCrVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCrCliente.Text = id.regresar.valXn;
                tbxNCrCliente.Text = ObtnerCliente(tbxCrCliente.Text);
                tbxNCrCliente.ReadOnly = true;
                btnSPCrC.Enabled = false;
            }
            btnReporteHistorial.Focus();
        }

        private void tbxCrCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxCrCliente.Text.Length > 0)
                {
                    tbxNCrCliente.Text = ObtnerCliente(tbxCrCliente.Text);
                    btnReporteCr.Focus();
                    if (tbxNCrCliente.Text == "")
                    {
                        tbxCrCliente.Focus();
                    }
                }
            }
        }

        private void btnCrRCliente_Click(object sender, EventArgs e)
        {
            tbxCrCliente.Clear();
            tbxNCrCliente.Clear();
            btnSPCrC.Enabled = true;
            tbxCrCliente.ReadOnly = false; 
            dtgCrTabla.Rows.Clear();
        }
        string rbtns;
        private void btnReporteCr_Click(object sender, EventArgs e)
        {
            rbtns = "";
            idVendedor = "";
            idCliente = "";
            string folio="";
            double total = 0;
             
                dtgCrTabla.Rows.Clear();
                if (tbxFolio.Text.Length > 0)
                {
                    folio = " and a.idAdeudos=" + tbxFolio.Text;
                }
                else
                {
                    folio = "";
                }
                if (tbxCrVendedor.Text.Length > 0)
                {
                    idVendedor = " and a.empleados_id_empleado=" + tbxCrVendedor.Text;
                }
                else
                {
                    idVendedor = "";
                }
                if (tbxCrCliente.Text.Length > 0)
                {
                    idCliente = " and a.clientes_idclientes=" + tbxCrCliente.Text;
                }
                else
                {
                    idCliente = "";
                }

                if (rbtActivas.Checked)
                {
                    rbtns = " and a.saldo>0";
                }
                else if (rbtInactivas.Checked)
                {
                    rbtns = " and a.saldo<=0";
                }
                else if (rbtTodas.Checked)
                {
                    rbtns = "";
                }
                double abonos = 0;
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select a.idAdeudos,a.Fecha,c.nombre, a.credito, a.saldo, a.dias from adeudos a, clientes c where a.clientes_idclientes=c.idclientes and a.fecha BETWEEN '" +
                dtpInicioC.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFinC.Value.ToString("yyyyMMdd235959") + "'" + idVendedor + " " + idCliente + rbtns+folio, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    abonos = lector.GetDouble(3) - lector.GetDouble(4);
                    dtgCrTabla.Rows.Add(lector.GetInt32(0), lector.GetDateTime(1), lector.GetString(2),lector.GetDouble(3),abonos, lector.GetDouble(4),lector.GetDouble(5));
                    total += lector.GetDouble(4);
                }
                conectar.Close();
                dtgCrTabla.Rows.Add("","","","", "Total", total, "");
       
        }
        public void AbrirConsultaExcel(DataGridView dgvConsulta)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;
            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;
                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;
                //Add table headers going cell by cell.
                for (int i = 0; i<dgvConsulta.Columns.Count; i++)
                {
                    oSheet.Cells[1, i + 1] = dgvConsulta.Columns[i].HeaderText;
                }
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "I1").Font.Bold = true;
                oSheet.get_Range("A1", "I1").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "I1").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;

                // Create an array to multiple values at once.
                int fila = dgvConsulta.Rows.Count;
                int colum = dgvConsulta.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        oSheet.Cells[i + 2, j + 1] = dgvConsulta[j, i].Value.ToString();
                    }
                }
                //Fill A2:B6 with an array of values (First and Last Names).
                //oSheet.get_Range("A2", "D6").Value2 = saNames;
                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                //oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";
                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                //oRng = oSheet.get_Range("D2", "D6");
                //oRng.Formula = "=RAND()*100000";
                //oRng.NumberFormat = "$0.00";
                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "I1");
                oRng.EntireColumn.AutoFit();
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                // MessageBox.Show(errorMessage, "Error");
            }
        }
        private void btnExcelHistorial_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(dtgHistTabla);
        }

        private void btnExcelCr_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(dtgCrTabla);
        }

        private void btnImprimirHistorial_Click(object sender, EventArgs e)
        {

            (printPreviewHistorial as Form).WindowState = FormWindowState.Maximized;
            printPreviewHistorial.PrintPreviewControl.Zoom = 1.5;
            printPreviewHistorial.ShowDialog();
        }
        int i = 0;
        private void printDocHistorial_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgHistTabla.Rows.Count > 0)
            {                
                int height = 0;
                int an = -5;
                Font letra = new Font("Arial", 9);
                int x = 100;
                int L = 105;
                int y = 140;
                int col1 = dtgHistTabla.Columns[0].Width - an;
                int col2 = dtgHistTabla.Columns[1].Width - an;
                int col3 = dtgHistTabla.Columns[2].Width - an;
                int col4 = dtgHistTabla.Columns[3].Width - an;
                int col5 = dtgHistTabla.Columns[4].Width - an;
                int col6 = dtgHistTabla.Columns[5].Width - an;
                Pen p = new Pen(Brushes.Black, 1.5f);

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(90, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);
                #region titulo
                e.Graphics.DrawString("HISTORIAL DE COBRANZA", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width /5*2, 50, 500, dtgHistTabla.Rows[0].Height + 15));
                #endregion
                
                #region RangosFecha
                e.Graphics.DrawString(dtpInicio.Value.ToString("dd/MMM/yyyy") + " - " + dtpFin.Value.ToString("dd/MMM/yyyy"), new Font("Arial", 11), Brushes.Black, new Rectangle(x, 95, 500, dtgHistTabla.Rows[0].Height + 15));
                #endregion
                
                #region NombreVendedor
                e.Graphics.DrawString("Cliente:" + tbxNCliente.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 115, 500, dtgHistTabla.Rows[0].Height + 15));
                #endregion
                
               

                #region Fecha

                //                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[0].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x, y, col1, dtgHistTabla.Rows[0].Height + 15));

                #endregion
              

                #region Adeudo

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[1].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1, y, col2, dtgHistTabla.Rows[0].Height + 15));

                #endregion

                #region Abono
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[2].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgHistTabla.Rows[0].Height + 15));


                #endregion

                #region FiadoNuevo

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[3].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));

                #endregion

                #region Pendiente

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[4].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgHistTabla.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion 
                
                #region Dias

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4+col5, y, col6, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[5].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4+col5, y, col6, dtgHistTabla.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                height = 155;

                while (i < dtgHistTabla.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 155;
                        e.HasMorePages = true;
                        return;
                    }
                    height += dtgHistTabla.Rows[0].Height;

                    //e.Graphics.DrawRectangle(p, new Rectangle(100, height, dtgHistTabla.Columns[1].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[0].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L, height, dtgHistTabla.Columns[0].Width, dtgHistTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(100 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[2].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[1].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1, height, dtgHistTabla.Columns[1].Width, dtgHistTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(300 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[3].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[2].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgHistTabla.Columns[2].Width, dtgHistTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(400 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[4].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[3].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, dtgHistTabla.Columns[3].Width, dtgHistTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(500 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[5].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[4].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, dtgHistTabla.Columns[4].Width, dtgHistTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(500 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[5].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[5].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 +col5, height, dtgHistTabla.Columns[5].Width, dtgHistTabla.Rows[0].Height));


                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void dtgCrTabla_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "tblFolio" && e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgCrTabla.Rows[e.RowIndex1].Cells["tblFolio"].Value.ToString()),
                    Convert.ToInt32(dtgCrTabla.Rows[e.RowIndex2].Cells["tblFolio"].Value.ToString()));
            }
            if (e.Column.Name == "tblCredito" && e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex1].Cells["tblCredito"].Value.ToString()),
                    Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex2].Cells["tblCredito"].Value.ToString()));
            }

            if (e.Column.Name == "tblAbono" && e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex1].Cells["tblAbono"].Value.ToString()),
                    Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex2].Cells["tblAbono"].Value.ToString()));
            }

            if (e.Column.Name == "tblSaldo" && e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex1].Cells["tblSaldo"].Value.ToString()),
                    Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex2].Cells["tblSaldo"].Value.ToString()));
            }
            if (e.Column.Name == "tblDias" && e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex1].Cells["tblDias"].Value.ToString()),
                    Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex2].Cells["tblDias"].Value.ToString()));
            }

            e.Handled = true;
        }
        public int comparar(int a, int b)
        {
            if (a > b) { return -1; }
            if (a == b) { return 0; }
            if (a < b) { return 1; }
            return 0;
        }
        public int comparar(Double a, Double b)
        {
            if (a > b) { return -1; }
            if (a == b) { return 0; }
            if (a < b) { return 1; }
            return 0;
        }

        private void btnImprimirCr_Click(object sender, EventArgs e)
        {

            (printPreviewCreditos as Form).WindowState = FormWindowState.Maximized;
            printPreviewCreditos.PrintPreviewControl.Zoom = 1;
            printDocCreditos.DefaultPageSettings.Landscape = true;
            printPreviewCreditos.ShowDialog();
        }

        private void printDocCreditos_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgCrTabla.Rows.Count > 0)
            {

                int height = 0;
                //int width = 0;
                int an = -5;
                //int t = 260;
                Font letra = new Font("Arial", 9);
                // int width = 0;
                int x = 130;
                int L = 135;
                int y = 140;
                int col1 = dtgCrTabla.Columns[0].Width - an;
                int col2 = dtgCrTabla.Columns[1].Width - an;
                int col3 = dtgCrTabla.Columns[2].Width - an;
                int col4 = dtgCrTabla.Columns[3].Width - an;
                int col5 = dtgCrTabla.Columns[4].Width - an;
                int col6 = dtgCrTabla.Columns[5].Width - an;
                int col7 = dtgCrTabla.Columns[6].Width - an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);
                #region titulo
                e.Graphics.DrawString("REPORTE DE CRÉDITOS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 5 * 2+50, 50, 500, dtgCrTabla.Rows[0].Height + 15));
                #endregion


                #region Fecha
                e.Graphics.DrawString(dtpInicioC.Value.ToString("dd/MMM/yyyy") + " - " + dtpFinC.Value.ToString("dd/MMM/yyyy"), new Font("Arial", 11), Brushes.Black, new Rectangle(x, 95, 500, dtgCrTabla.Rows[0].Height + 15));
                #endregion

                #region NombreVendedor
                e.Graphics.DrawString("Cliente:" + tbxNCrCliente.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 115, 500, dtgCrTabla.Rows[0].Height + 15));
                #endregion

                #region Folio

                Pen p = new Pen(Brushes.Black, 1.5f);

                //                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[0].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x, y, col1, dtgCrTabla.Rows[0].Height + 15));

                #endregion

                #region Fecha

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[1].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1, y, col2, dtgCrTabla.Rows[0].Height + 15));

                #endregion

                #region NombreCliente
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[2].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgCrTabla.Rows[0].Height + 15));
                
                #endregion

                #region Credito

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[3].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, dtgCrTabla.Rows[0].Height + 15));

                #endregion
                #region Abono

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 +col4, y, col5, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[4].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3+ col4, y, col5, dtgCrTabla.Rows[0].Height + 15));

                #endregion
                #region Saldo

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[5].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgCrTabla.Rows[0].Height + 15));

                #endregion  
                #region Dias

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[6].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgCrTabla.Rows[0].Height + 15));

                #endregion

                height = 155;

                while (i < dtgCrTabla.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 155;
                        e.HasMorePages = true;
                        return;
                    }

                    height += dtgCrTabla.Rows[0].Height;

                    //e.Graphics.DrawRectangle(p, new Rectangle(100, height, dtgHistTabla.Columns[1].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[0].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L, height, dtgCrTabla.Columns[0].Width, dtgCrTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(100 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[2].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[1].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1, height, dtgCrTabla.Columns[1].Width, dtgCrTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(300 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[3].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[2].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgCrTabla.Columns[2].Width, dtgCrTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(400 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[4].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[3].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, dtgCrTabla.Columns[3].Width, dtgCrTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(300 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[3].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[4].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2  + col3 + col4, height, dtgCrTabla.Columns[4].Width, dtgCrTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(400 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[4].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[5].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, dtgCrTabla.Columns[5].Width, dtgCrTabla.Rows[0].Height));
                    
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[6].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, dtgCrTabla.Columns[6].Width, dtgCrTabla.Rows[0].Height));

                    i++;
                }
                i = 0;
                e.HasMorePages = false;
            }
        }

        private void tbxCrVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxCrCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void printPreviewHistorial_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewCreditos_Load(object sender, EventArgs e)
        {

        }
    }
}
