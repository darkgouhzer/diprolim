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
    public partial class historicos_de_movimientos : Form
    {
        conexion conn = new conexion();
        String cmd;
        Inventarios.DBMS_Unico Conexion;
        MySqlCommand comando;
        public historicos_de_movimientos(Inventarios.DBMS_Unico svr)
        {
            InitializeComponent();
            //fecha sobre sucursal
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
            //fecha sobre vendedores
            dtpInicioV.Value = DateTime.Now;
            dtpFinV.Value = DateTime.Now;
            Conexion = svr;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Tabla.Rows.Clear();
            string Resto = "";
            if (tbxProducto.Text != "")
            {
                Resto = " and i.articulos_codigo=" + tbxProducto.Text;
            }
            else
            {
                Resto = "";
            }
            MySqlConnection conectar = conn.ObtenerConexion();
            conectar = conn.ObtenerConexion();
            MySqlDataReader lector;
            comando = new MySqlCommand("select i.fecha,a.descripcion, a.valor_medida, u.nombre,i.movimiento,i.cantidad,i.existencia_inicial,i.existencia_final from HistoricoDMovimientos i, articulos a, unidad_medida u where i.fecha BETWEEN '" +
            dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'" + Resto + " and a.unidad_medida_id = u.id and i.articulos_codigo=a.codigo", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Tabla.Rows.Add(lector.GetDateTime(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), lector.GetString(4), lector.GetString(5), lector.GetString(6),lector.GetString(7));
            }
            conectar.Close();           
        }

        private void historicos_de_movimientos_Load(object sender, EventArgs e)
        {

        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarArticulos id = new BuscarArticulos();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxProducto.Text = id.regresar.valXn;
                obtenerProducto();
            }
            tbxProducto.Focus();
        }
        public void obtenerProducto()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select a.descripcion, a.valor_medida, um.nombre,a.cantidad from articulos a, unidad_medida um where a.unidad_medida_id=um.id and a.codigo=" + tbxProducto.Text, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            string des = "";

            while (lector.Read())
            {
                tbxNProducto.Text = lector.GetString(0).ToString() + " " + lector.GetString(1) + " " + lector.GetString(2);
                

                des = lector.GetString(0);
            }

            conectar.Close();

            if (des == "")
            {
                MessageBox.Show("Ese producto no existe");
                tbxProducto.Clear();
            }

        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxProducto.Text != "")
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    obtenerProducto();
                    btnReporte.Focus();
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tbxProducto.Clear();
            tbxNProducto.Clear();
            Tabla.Rows.Clear();
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
                if (tabControl1.SelectedIndex == 0)
                {
                    oSheet.Cells[1, 2] = "HISTÓRICO DE MOVIMIENTOS DE SUCURSAL";
                    oSheet.get_Range("A1", "F1").Merge(true);
                    oSheet.get_Range("A1", "F1").Font.Bold = true;
                    oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", "F1").Font.Size = 18;
                }
                else
                {
                    oSheet.Cells[1, 2] = "HISTÓRICO DE MOVIMIENTOS POR VENDEDOR";
                    oSheet.get_Range("A1", "H1").Merge(true);
                    oSheet.get_Range("A1", "H1").Font.Bold = true;
                    oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", "H1").Font.Size = 18;
                }
                for (int i = 0; i < dgvConsulta.Columns.Count; i++)
                {
                    oSheet.Cells[2, i + 1] = dgvConsulta.Columns[i].HeaderText;
                }
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A2", "I2").Font.Bold = true;
                oSheet.get_Range("A2", "I2").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A2", "I2").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;

                // Create an array to multiple values at once.
                int fila = dgvConsulta.Rows.Count;
                int colum = dgvConsulta.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        oSheet.Cells[i + 3, j + 1] = dgvConsulta[j, i].Value.ToString();
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(Tabla);
        }

        private void tbxProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            (printPreviewDSuc as Form).WindowState = FormWindowState.Maximized;
            printPreviewDSuc.PrintPreviewControl.Zoom = 1;
            printDocSucursal.DefaultPageSettings.Landscape = true;
            printPreviewDSuc.ShowDialog();
        }
        int i = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (Tabla.Rows.Count > 0)
            {
                int height = 0;
                //int width = 0;
                int an = -5;
                //int t = 260;
                Font letra = new Font("Arial", 9);
                // int width = 0;
                int x = 100;
                int L = 105;
                int y = 120;
                int col1 = Tabla.Columns[0].Width - an;
                int col2 = Tabla.Columns[1].Width - an;
                int col3 = Tabla.Columns[2].Width - an;
                int col4 = Tabla.Columns[3].Width - an;
                int col5 = Tabla.Columns[4].Width - an;
                int col6 = Tabla.Columns[5].Width - an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("HISTORICO DE MOVIMIENTOS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 5 * 2+50, 50, 500, Tabla.Rows[0].Height + 15));
                #endregion

                //#region NombreVendedor
                //e.Graphics.DrawString("Cliente:" + tbxNCliente.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 95, 500, Tabla.Rows[0].Height + 15));
                //#endregion

                #region Fecha

                Pen p = new Pen(Brushes.Black, 1.5f);

                //                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[0].HeaderText.ToString(), Tabla.Font, Brushes.Black, new Rectangle(x, y, col1, Tabla.Rows[0].Height + 15));

                #endregion

                #region Adeudo

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[1].HeaderText.ToString(), Tabla.Font, Brushes.Black, new Rectangle(x + col1, y, col2, Tabla.Rows[0].Height + 15));

                #endregion

                #region Abono
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[2].HeaderText.ToString(), Tabla.Font, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, Tabla.Rows[0].Height + 15));


                #endregion

                #region FiadoNuevo

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[3].HeaderText.ToString(), Tabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, Tabla.Rows[0].Height + 15));

                #endregion

                #region Pendiente

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[4].HeaderText.ToString(), Tabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, Tabla.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                #region Dias

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[5].HeaderText.ToString(), Tabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, Tabla.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                height = 135;

                while (i < Tabla.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 135;
                        e.HasMorePages = true;
                        return;
                    }
                    height += Tabla.Rows[0].Height;

                    //e.Graphics.DrawRectangle(p, new Rectangle(100, height, Tabla.Columns[1].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[0].FormattedValue.ToString(), Tabla.Font, Brushes.Black, new Rectangle(L, height, Tabla.Columns[0].Width, Tabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(100 + Tabla.Columns[1].Width, height, Tabla.Columns[2].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[1].FormattedValue.ToString(), Tabla.Font, Brushes.Black, new Rectangle(L + col1, height, Tabla.Columns[1].Width, Tabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(300 + Tabla.Columns[1].Width, height, Tabla.Columns[3].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[2].FormattedValue.ToString(), Tabla.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, Tabla.Columns[2].Width, Tabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(400 + Tabla.Columns[1].Width, height, Tabla.Columns[4].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[3].FormattedValue.ToString(), Tabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, Tabla.Columns[3].Width, Tabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(500 + Tabla.Columns[1].Width, height, Tabla.Columns[5].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[4].FormattedValue.ToString(), Tabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, Tabla.Columns[4].Width, Tabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(500 + Tabla.Columns[1].Width, height, Tabla.Columns[5].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[5].FormattedValue.ToString(), Tabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, Tabla.Columns[5].Width, Tabla.Rows[0].Height));


                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void btnReporteV_Click(object sender, EventArgs e)
        {
            try
            {
                String PorVendedor = "";
                String PorProducto = "";
                if (tbxVendedor.Text != "")
                {
                    PorVendedor = " and  hv.empleados_id_empleado=" + tbxVendedor.Text;
                }
                if (tbxProductoV.Text != "")
                {
                    PorProducto = " and  hv.articulos_codigo=" + tbxProductoV.Text;

                }
                cmd = String.Format("select hv.Fecha, a.codigo, a.descripcion, a.valor_medida, u.nombre as nombremedida, hv.Movimiento, hv.cantidad, "+
                    " hv.Existencia_inicial, hv.Existencia_Final,e.nombre FROM historicovendedores hv, articulos a, unidad_medida u, empleados e"+
                    " WHERE a.codigo=hv.articulos_codigo and a.unidad_medida_id=u.id and e.id_empleado=hv.empleados_id_empleado "+
                    " {0} {1} and hv.Fecha BETWEEN '{2}' AND '{3}' order by fecha asc;",
                    PorVendedor,
                    PorProducto,
                    dtpInicioV.Value.ToString("yyyyMMdd000000"),
                    dtpFinV.Value.ToString("yyyyMMdd235959"));
                DataTable tbl = new DataTable();
                Conexion.Conectarse();
                Conexion.Ejecutar(cmd, ref tbl);
                Conexion.Desconectarse();
                dtgVendedores.Rows.Clear();
                if (tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        DataRow row = tbl.Rows[i];
                        dtgVendedores.Rows.Add(row["Fecha"], row["codigo"], row["descripcion"] + " " + row["valor_medida"] + " " + row["nombremedida"],
                            row["Movimiento"], row["cantidad"], row["Existencia_inicial"], row["Existencia_Final"], row["nombre"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcelV_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(dtgVendedores);
        }

        private void printDocVendedores_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgVendedores.Rows.Count > 0)
            {
                int height = 0;
                //int width = 0;
                int an = 5;
                //int t = 260;
                Font letra = new Font("Arial", 9);
                // int width = 0;
                int x = 70;
                int L = 75;
                int y = 120;
                int col1 = dtgVendedores.Columns[0].Width - an;
                int col2 = dtgVendedores.Columns[1].Width - an;
                int col3 = dtgVendedores.Columns[2].Width - an;
                int col4 = dtgVendedores.Columns[3].Width - an;
                int col5 = dtgVendedores.Columns[4].Width - an;
                int col6 = dtgVendedores.Columns[5].Width - an;
                int col7 = dtgVendedores.Columns[6].Width - an;
                int col8 = dtgVendedores.Columns[7].Width - an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("HISTORICO DE MOVIMIENTOS VENDEDORES", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 6 * 2 + 50, 50, 500, dtgVendedores.Rows[0].Height + 15));
                #endregion

                //#region NombreVendedor
                //e.Graphics.DrawString("Cliente:" + tbxNCliente.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 95, 500, dtgVendedores.Rows[0].Height + 15));
                //#endregion

                #region Fecha

                Pen p = new Pen(Brushes.Black, 1.5f);

                //                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgVendedores.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgVendedores.Columns[0].HeaderText.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(x, y, col1, dtgVendedores.Rows[0].Height + 15));

                #endregion

                #region Codigo

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgVendedores.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgVendedores.Columns[1].HeaderText.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(x + col1, y, col2, dtgVendedores.Rows[0].Height + 15));

                #endregion

                #region Descripcion
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgVendedores.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgVendedores.Columns[2].HeaderText.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgVendedores.Rows[0].Height + 15));


                #endregion

                #region Operacion

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgVendedores.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, dtgVendedores.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgVendedores.Columns[3].HeaderText.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, dtgVendedores.Rows[0].Height + 15));

                #endregion

                #region Cantidad

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgVendedores.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgVendedores.Columns[4].HeaderText.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgVendedores.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                #region ExistenciaAntes

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgVendedores.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgVendedores.Columns[5].HeaderText.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgVendedores.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion
                #region ExistenciaDespues

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgVendedores.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgVendedores.Columns[6].HeaderText.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgVendedores.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion
                #region NombreVendedor

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, dtgVendedores.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgVendedores.Columns[7].HeaderText.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, dtgVendedores.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                height = 135;

                while (i < dtgVendedores.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 135;
                        e.HasMorePages = true;
                        return;
                    }
                    height += dtgVendedores.Rows[0].Height;

                    //e.Graphics.DrawRectangle(p, new Rectangle(100, height, dtgVendedores.Columns[1].Width, dtgVendedores.Rows[0].Height));
                    e.Graphics.DrawString(dtgVendedores.Rows[i].Cells[0].FormattedValue.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(L, height, dtgVendedores.Columns[0].Width, dtgVendedores.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(100 + dtgVendedores.Columns[1].Width, height, dtgVendedores.Columns[2].Width, dtgVendedores.Rows[0].Height));
                    e.Graphics.DrawString(dtgVendedores.Rows[i].Cells[1].FormattedValue.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(L + col1, height, dtgVendedores.Columns[1].Width, dtgVendedores.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(300 + dtgVendedores.Columns[1].Width, height, dtgVendedores.Columns[3].Width, dtgVendedores.Rows[0].Height));
                    e.Graphics.DrawString(dtgVendedores.Rows[i].Cells[2].FormattedValue.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgVendedores.Columns[2].Width, dtgVendedores.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(400 + dtgVendedores.Columns[1].Width, height, dtgVendedores.Columns[4].Width, dtgVendedores.Rows[0].Height));
                    e.Graphics.DrawString(dtgVendedores.Rows[i].Cells[3].FormattedValue.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, dtgVendedores.Columns[3].Width, dtgVendedores.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(500 + dtgVendedores.Columns[1].Width, height, dtgVendedores.Columns[5].Width, dtgVendedores.Rows[0].Height));
                    e.Graphics.DrawString(dtgVendedores.Rows[i].Cells[4].FormattedValue.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, dtgVendedores.Columns[4].Width, dtgVendedores.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(500 + dtgVendedores.Columns[1].Width, height, dtgVendedores.Columns[5].Width, dtgVendedores.Rows[0].Height));
                    e.Graphics.DrawString(dtgVendedores.Rows[i].Cells[5].FormattedValue.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, dtgVendedores.Columns[5].Width, dtgVendedores.Rows[0].Height));

                    e.Graphics.DrawString(dtgVendedores.Rows[i].Cells[6].FormattedValue.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, dtgVendedores.Columns[6].Width, dtgVendedores.Rows[0].Height));

                    e.Graphics.DrawString(dtgVendedores.Rows[i].Cells[7].FormattedValue.ToString(), dtgVendedores.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7, height, dtgVendedores.Columns[7].Width, dtgVendedores.Rows[0].Height));


                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void btnImprimirV_Click(object sender, EventArgs e)
        {
            (printPreviewDVend as Form).WindowState = FormWindowState.Maximized;
            printPreviewDVend.PrintPreviewControl.Zoom = 1;
            printDocVendedores.DefaultPageSettings.Landscape = true;
            printPreviewDVend.ShowDialog();
        }

        private void btnSPV_Click(object sender, EventArgs e)
        {

            BuscarArticulos id = new BuscarArticulos();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxProductoV.Text = id.regresar.valXn;
                tbxProductoV_Leave(sender, e);
            }
            tbxProductoV.Focus();
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedor.Text = id.regresar.valXn;
            }
            tbxVendedor_Leave(sender, e);
            tbxVendedor.Focus();
        }

        private void tbxVendedor_Leave(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "")
            {
                DataTable tbl = new DataTable();
                cmd = "SELECT id_empleado, nombre, apellido_paterno, apellido_materno, limite_credito FROM empleados WHERE id_empleado =" +
                    tbxVendedor.Text;
                Conexion.Conectarse();
                Conexion.Ejecutar(cmd, ref tbl);
                Conexion.Desconectarse();
                if (tbxVendedor.Text != "1")
                {
                    if (tbl.Rows.Count > 0)
                    {
                        DataRow row = tbl.Rows[0];
                        tbxNVendedor.Text = row["nombre"].ToString() + " " + row["apellido_paterno"].ToString() + " " + row["apellido_materno"].ToString();

                    }
                    else
                    {
                        tbxNVendedor.Clear();
                        tbxVendedor.Clear();
                    }
                }
                else
                {
                    tbxVendedor.Clear();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbxVendedor.Clear();
            tbxNVendedor.Clear();
            tbxProducto.Clear();
            tbxNProductoV.Clear();
            dtgVendedores.Rows.Clear();

        }

        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxVendedor_Leave(sender, e);
            }
        }

        private void tbxProductoV_Leave(object sender, EventArgs e)
        {
            if (tbxProductoV.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select a.descripcion, a.valor_medida, um.nombre,a.cantidad from articulos a, unidad_medida um where a.unidad_medida_id=um.id and a.codigo=" + tbxProductoV.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";

                while (lector.Read())
                {
                    tbxNProductoV.Text = lector.GetString(0).ToString() + " " + lector.GetString(1) + " " + lector.GetString(2);


                    des = lector.GetString(0);
                }

                conectar.Close();

                if (des == "")
                {
                    MessageBox.Show("Ese producto no existe");
                    tbxProductoV.Clear();
                }
            }
        }

        private void tbxProductoV_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                tbxProductoV_Leave(sender, e);
            }
        }
    }
}
