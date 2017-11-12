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
    public partial class ReporteEntradaV : Form
    {
        conexion conn = new conexion();

        public ReporteEntradaV()
        {
            InitializeComponent();
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
            unidadesMedida();
            cbxUnMedida.SelectedIndex = 0;
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
        private void btnSV_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCV.Text = id.regresar.valXn;
            }
            tbxCV.Focus();
            obtenerVendedor();

        }
        DateTime fecha;
        String[] unimedida;
        String unime = "";
        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (tbxCV.Text != "")
            {
                obtenerVendedor();
                tblEntradas.Rows.Clear();
                if (cbxUnMedida.Text == "Todos")
                {
                    unime = "";
                }
                else
                {
                    unimedida = cbxUnMedida.Text.Split('-');
                    unime = " AND a.valor_medida=" + unimedida[0].Trim() + " AND um.nombre='" + unimedida[1].Trim() + "'";
                }

                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                MySqlDataReader lector;
                comando = new MySqlCommand("SELECT en.articulos_codigo, a.descripcion,a.valor_medida,um.nombre, " +
                    "en.n_entrada, en.inventario_anterior, en.fecha FROM entradas en, articulos a, unidad_medida um WHERE " +
                    " en.articulos_codigo = a.codigo AND en.empleados_id_empleado =" + tbxCV.Text + unime + " " +
                    " AND a.unidad_medida_id=um.id AND en.fecha BETWEEN '" +
            dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    fecha = Convert.ToDateTime(lector.GetString(6).ToString());
                    tblEntradas.Rows.Add(lector.GetString(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3)
                        , lector.GetString(4), lector.GetString(5), fecha.ToString("dd/MM/yyyy"));

                }
                conectar.Close();
            }
            else
            {
                MessageBox.Show("Indique un código de vendedor");
            }
        }
       
        private void tbxCV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxCV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                obtenerVendedor();

            }
        }

        public void obtenerVendedor()
        {
            if (tbxCV.Text != "")
            {

                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + tbxCV.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    tbxNombre.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    des = lector.GetString(0);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de vendedor no existente");
                    tbxCV.Text = "";
                    tbxNombre.Clear();

                }
                else
                {
                    btnReporte.Focus();
                }
                
            }
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

                oSheet.Cells[1, 2] = "REPORTE DE ENTRADAS DE VENDEDORES";
                oSheet.get_Range("A1", "E1").Merge(true);
                oSheet.get_Range("A1", "E1").Font.Bold = true;
                oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "E1").Font.Size = 18;

                oSheet.Cells[2, 1] = codigArt.HeaderText;
                oSheet.Cells[2, 2] = rSdescripcion.HeaderText;
                oSheet.Cells[2, 3] = NEntrada.HeaderText;
                oSheet.Cells[2, 4] = REInv_anterior.HeaderText;
                oSheet.Cells[2, 5] = repSFecha.HeaderText;
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A2", "I2").Font.Bold = true;
                oSheet.get_Range("A2", "I2").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A2", "I2").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;
                // Create an array to multiple values at once.
                int fila = tblEntradas.Rows.Count;
                int colum = tblEntradas.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        oSheet.Cells[i + 3, j + 1] = tblEntradas[j, i].Value.ToString();
                    }
                }
                //Fill A2:B6 with an array of values (First and Last Names).
                //oSheet.get_Range("A2", "D6").Value2 = saNames;
                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                // oRng = oSheet.get_Range("C2", "C6");
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
            AbrirConsultaExcel(tblEntradas);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.5; 
            printPreviewDialog1.ShowDialog();
        }
        int col1, col2, col3, col4, col5, i = 0,L,x;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (tblEntradas.Rows.Count > 0)
            {
                int height = 0;
                //int width = 0;
                int an = 0;
                //int t = 260;
                Font letra = new Font("Arial", 9);
                // int width = 0;
                x = 100;
                L = 105;
                col1 = tblEntradas.Columns[0].Width-an;
                col2 = tblEntradas.Columns[1].Width-an;
                col3 = tblEntradas.Columns[2].Width-an;
                col4 = tblEntradas.Columns[3].Width-an;
                col5 = tblEntradas.Columns[4].Width-an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);
                #region titulo
                e.Graphics.DrawString("ENTRADAS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 2 + 50, 50, 500, tblEntradas.Rows[0].Height + 15));
                #endregion

                #region NombreVendedor
                e.Graphics.DrawString("Vendedor:" + tbxNombre.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 75, 500, tblEntradas.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, col1, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, 100, col1, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[0].HeaderText.ToString(), tblEntradas.Font, Brushes.Black, new Rectangle(x, 100, col1, tblEntradas.Rows[0].Height + 15));

                #endregion

                #region Descripcion

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, 100, col2, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[1].HeaderText.ToString(), tblEntradas.Font, Brushes.Black, new Rectangle(x + col1, 100, col2, tblEntradas.Rows[0].Height + 15));

                #endregion

                #region Salidas
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, 100, col3, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[2].HeaderText.ToString(), tblEntradas.Font, Brushes.Black, new Rectangle(x + col1 + col2, 100, col3, tblEntradas.Rows[0].Height + 15));


                #endregion

                #region InventarioVendedor

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, 100, col4, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, 100, col4, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[3].HeaderText.ToString(), tblEntradas.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, 100, col4, tblEntradas.Rows[0].Height + 15));

                #endregion

                #region fecha

                //                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, 100, col5, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[4].HeaderText.ToString(), tblEntradas.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, 100, col5, tblEntradas.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblEntradas.Rows[1].Height);
                #endregion



                height = 115;

                while (i < tblEntradas.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 115;
                        e.HasMorePages = true;
                        return;
                    }


                    height += tblEntradas.Rows[0].Height;

                    //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblEntradas.Columns[1].Width, tblEntradas.Rows[0].Height));
                    e.Graphics.DrawString(tblEntradas.Rows[i].Cells[0].FormattedValue.ToString(), tblEntradas.Font, Brushes.Black, new Rectangle(L, height, tblEntradas.Columns[0].Width, tblEntradas.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[2].Width, tblEntradas.Rows[0].Height));
                    e.Graphics.DrawString(tblEntradas.Rows[i].Cells[1].FormattedValue.ToString(), tblEntradas.Font, Brushes.Black, new Rectangle(L + col1, height, tblEntradas.Columns[1].Width, tblEntradas.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[3].Width, tblEntradas.Rows[0].Height));
                    e.Graphics.DrawString(tblEntradas.Rows[i].Cells[2].FormattedValue.ToString(), tblEntradas.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, tblEntradas.Columns[2].Width, tblEntradas.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[4].Width, tblEntradas.Rows[0].Height));
                    e.Graphics.DrawString(tblEntradas.Rows[i].Cells[3].FormattedValue.ToString(), tblEntradas.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblEntradas.Columns[3].Width, tblEntradas.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[5].Width, tblEntradas.Rows[0].Height));
                    e.Graphics.DrawString(tblEntradas.Rows[i].Cells[4].FormattedValue.ToString(), tblEntradas.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblEntradas.Columns[4].Width, tblEntradas.Rows[0].Height));


                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void tblEntradas_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "codigArt")
            {
                // e.SortResult = tblEntradas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblEntradas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(tblEntradas.Rows[e.RowIndex1].Cells["codigArt"].Value.ToString()),
                    Convert.ToInt32(tblEntradas.Rows[e.RowIndex2].Cells["codigArt"].Value.ToString()));
            }
            if (e.Column.Name == "NEntrada")
            {
                // e.SortResult = tblEntradas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblEntradas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblEntradas.Rows[e.RowIndex1].Cells["NEntrada"].Value.ToString()),
                    Convert.ToDouble(tblEntradas.Rows[e.RowIndex2].Cells["NEntrada"].Value.ToString()));
            }

            if (e.Column.Name == "REInv_anterior")
            {
                // e.SortResult = tblEntradas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblEntradas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblEntradas.Rows[e.RowIndex1].Cells["REInv_anterior"].Value.ToString()),
                    Convert.ToDouble(tblEntradas.Rows[e.RowIndex2].Cells["REInv_anterior"].Value.ToString()));
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

    }
}
