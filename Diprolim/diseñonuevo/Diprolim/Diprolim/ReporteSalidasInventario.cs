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
using System.IO;

namespace Diprolim
{
    public partial class ReporteSalidasInventario : Form
    {
        conexion conn = new conexion();
        MySqlCommand comando;
        public ReporteSalidasInventario()
        {
            InitializeComponent();
            cbxMotivo.SelectedIndex = 0;
            unidadesMedida();
            cbxUnMedida.SelectedIndex = 0;
            dtpInicio.Value = DateTime.Today;
            dtpFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
        }
        public void unidadesMedida()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand("select distinct a.valor_medida, um.nombre from articulos a, unidad_medida um where a.unidad_medida_id=um.id;", conectar);
            conectar.Open();
            MySqlDataReader lector = comando.ExecuteReader();
            cbxUnMedida.Items.Add("Todos");
            while (lector.Read())
            {
                cbxUnMedida.Items.Add(lector.GetString(0) + " - " + lector.GetString(1));
            }
            conectar.Close();

        }
        String[] unimedida;
        String unime = "";
        private void btnReporte_Click(object sender, EventArgs e)
        {
            MetodoBuscar();
        }
        public void MetodoBuscar()
        {
            String tipomedida = "";
            String codigoArt = "";
            string folio = "";

            if (cbxMotivo.Text != "Todas")
            {
                tipomedida = "AND i.Motivo='" + cbxMotivo.Text + "'";
            }
            else
            {
                tipomedida = "";
            }
            if (tbxProducto.Text.Length > 0)
            {
                codigoArt = "AND a.codigo=" + tbxProducto.Text;
            }

            if (cbxUnMedida.Text == "Todos")
            {
                unime = "";
            }
            else
            {
                unimedida = cbxUnMedida.Text.Split('-');
                unime = " AND a.valor_medida=" + unimedida[0].Trim() + " AND um.nombre='" + unimedida[1].Trim() + "'";
            }
            string Fechass = "";
            Fechass = " and i.fecha BETWEEN '" + dtpInicio.Value.ToString("yyyyMMddHHmmss") + "' AND '" + dtpFin.Value.ToString("yyyyMMddHHmmss") + "'";


            if (tbxFolio.Text != "")
            {
                folio += " AND i.Folio='" + tbxFolio.Text + "'";
                Fechass = "";
            }

            MySqlConnection conectar = conn.ObtenerConexion();
            tblReporteE.Rows.Clear();
            comando = new MySqlCommand("select i.articulos_codigo, a.descripcion, a.valor_medida, um.nombre, i.n_salida, i.fecha,i.Motivo,i.Comentarios " +
                "from salidas i, articulos a, unidad_medida um where i.articulos_codigo=a.codigo  AND a.unidad_medida_id=um.id" + unime + " " + Fechass + " " + tipomedida + " " + codigoArt + " " + folio + " order by i.id_salidas asc", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {

                tblReporteE.Rows.Add(lector.GetString(0), lector.GetString(1) + " " + lector.GetString(2) + "" + lector.GetString(3), lector.GetString(4), lector.GetString(5), lector.GetString(6), lector.GetString(7));

            }
            conectar.Close();
        }
        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarArticulos id = new BuscarArticulos();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxProducto.Text = id.regresar.valXn;
            }
            tbxProducto.Focus();
            MetodoProducto();  
        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoProducto();            
            }
        }
        public void MetodoProducto()
        {
            if (tbxProducto.Text != "")
            {

                MySqlConnection conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select a.descripcion, a.valor_medida, um.nombre,a.cantidad from articulos a, unidad_medida um where a.unidad_medida_id=um.id and a.codigo=" + tbxProducto.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";

                while (lector.Read())
                {
                    tbxNombre.Text = lector.GetString(0).ToString() + " " + lector.GetString(1) + " " + lector.GetString(2);


                    des = lector.GetString(0);
                }

                conectar.Close();

                if (des == "")
                {
                    MessageBox.Show("Ese producto no existe");
                    tbxProducto.Clear();
                }
                MetodoBuscar();
            }
        }
        private void tblReporteE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbxProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(tblReporteE);
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

                oSheet.Cells[1, 2] = "REPORTE DE SALIDAS DE INVENTARIO";
                oSheet.get_Range("A1", "F1").Merge(true);
                oSheet.get_Range("A1", "F1").Font.Bold = true;
                oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "F1").Font.Size = 18;

                oSheet.Cells[2, 1] = dtArticulo.HeaderText;
                oSheet.Cells[2, 2] = dtgNombreArt.HeaderText;
                oSheet.Cells[2, 3] = tblCantidad.HeaderText;
                oSheet.Cells[2, 4] = tblFecha.HeaderText;
                oSheet.Cells[2, 5] = tblMotivo.HeaderText;
                oSheet.Cells[2, 6] = tblComentarios.HeaderText;
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A2", "I2").Font.Bold = true;
                oSheet.get_Range("A2", "I2").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A2", "I2").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;
                // Create an array to multiple values at once.
                int fila = tblReporteE.Rows.Count;
                int colum = tblReporteE.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        oSheet.Cells[i + 3, j + 1] = tblReporteE[j, i].Value.ToString();
                    }
                }
                //Fill A2:B6 with an array of values (First and Last Names).
                //oSheet.get_Range("A2", "D6").Value2 = saNames;
                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                // oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";
                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                oRng = oSheet.get_Range("F:F");
                oRng.NumberFormat = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \" - \"??_-;_-@_-";
                //oRng.Formula = "=RAND()*100000";
                oRng = oSheet.get_Range("H:I");
                oRng.NumberFormat = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \" - \"??_-;_-@_-";
                //AutoFit columns A:D
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
        int col1, col2, col3, col4, col5, col6, y, i = 0, x, L;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (tblReporteE.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width / 2 - 100;
                int an = 0;
                int al = 15;
                x = 80;
                y = 125;
                L = 85;
                Font letra = new Font("Arial", 9);
                col1 = tblReporteE.Columns[0].Width - an;
                col2 = tblReporteE.Columns[1].Width - an;
                col3 = tblReporteE.Columns[2].Width - an;
                col4 = tblReporteE.Columns[3].Width - an;
                col5 = tblReporteE.Columns[4].Width - an;
                col6 = tblReporteE.Columns[5].Width - an;
                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);
                #region titulo
                e.Graphics.DrawString("REPORTE DE SALIDAS DE SUCURSAL", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, tblReporteE.Rows[0].Height + 15));
                #endregion

                if (tbxFolio.Text != "")
                {
                    e.Graphics.DrawString("Folio: " + tbxFolio.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(e.MarginBounds.Width - 110, 105, 500, tblReporteE.Rows[0].Height + 15));

                }
                else
                {
                    #region fecha
                    e.Graphics.DrawString(dtpInicio.Value.ToString("dd/MMMM/yyyy") + " - " + dtpFin.Value.ToString("dd/MMMM/yyyy"), new Font("Arial", 10), Brushes.Black, new Rectangle(e.MarginBounds.Width - 110, 105, 500, tblReporteE.Rows[0].Height + 15));
                    #endregion
                }

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                //           e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60, 100, col1, tblReporteE.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, tblReporteE.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteE.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, tblReporteE.Rows[0].Height + al));

                #endregion

                #region Descripción

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1, 100, col2 + 100, tblReporteE.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, tblReporteE.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteE.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, tblReporteE.Rows[0].Height + al));

                #endregion

                #region Cantidad
                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2, 100, col3, tblReporteE.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, tblReporteE.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteE.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, tblReporteE.Rows[0].Height + al));


                #endregion

                #region Fecha

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, tblReporteE.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, tblReporteE.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteE.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, tblReporteE.Rows[0].Height + al));

                #endregion

                #region motivo

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4, 100, col5, tblReporteE.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblReporteE.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteE.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblReporteE.Rows[0].Height + al));
                //   MessageBox.Show("" + tblReporteE.Rows[1].Height);
                #endregion

                #region comentarios

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4 + col5, 100, col6, tblReporteE.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblReporteE.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteE.Columns[5].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblReporteE.Rows[0].Height + al));
                //   MessageBox.Show("" + tblReporteE.Rows[1].Height);
                #endregion

                height = 125 + al;

                while (i < tblReporteE.Rows.Count)
                {
                    if (height > e.MarginBounds.Height + 100)
                    {
                        height = 125 + al;
                        e.HasMorePages = true;
                        return;
                    }


                    height += tblReporteE.Rows[0].Height;

                    //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblReporteE.Columns[1].Width, tblReporteE.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteE.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, tblReporteE.Columns[0].Width, tblReporteE.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + tblReporteE.Columns[1].Width, height, tblReporteE.Columns[2].Width, tblReporteE.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteE.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, tblReporteE.Columns[1].Width, tblReporteE.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblReporteE.Columns[1].Width, height, tblReporteE.Columns[3].Width, tblReporteE.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteE.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, tblReporteE.Columns[2].Width, tblReporteE.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblReporteE.Columns[1].Width, height, tblReporteE.Columns[4].Width, tblReporteE.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteE.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblReporteE.Columns[3].Width, tblReporteE.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + tblReporteE.Columns[1].Width, height, tblReporteE.Columns[5].Width, tblReporteE.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteE.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblReporteE.Columns[4].Width, tblReporteE.Rows[0].Height));

                    e.Graphics.DrawString(tblReporteE.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, tblReporteE.Columns[5].Width, tblReporteE.Rows[0].Height));

                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void tblReporteE_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "dtArticulo")
            {
                // e.SortResult = tblEntradas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblEntradas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(tblReporteE.Rows[e.RowIndex1].Cells["dtArticulo"].Value.ToString()),
                    Convert.ToInt32(tblReporteE.Rows[e.RowIndex2].Cells["dtArticulo"].Value.ToString()));
            }
            if (e.Column.Name == "tblCantidad")
            {
                // e.SortResult = tblEntradas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblEntradas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblReporteE.Rows[e.RowIndex1].Cells["tblCantidad"].Value.ToString()),
                    Convert.ToDouble(tblReporteE.Rows[e.RowIndex2].Cells["tblCantidad"].Value.ToString()));
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

        private void button1_Click(object sender, EventArgs e)
        {
            string S = "Salidas";
            FoliosReportes id = new FoliosReportes(S);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxFolio.Text = id.regresar.valXn;
            }
            tbxFolio.Focus();
            MetodoBuscar();
        }

    }
}
