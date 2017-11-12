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
    public partial class ReporteSalidaV : Form
    {
        conexion conn = new conexion();
        Inventarios.DBMS_Unico Conexion;
        public ReporteSalidaV(Inventarios.DBMS_Unico sConexion)
        {
            InitializeComponent();
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
            unidadesMedida();
            cbxUnMedida.SelectedIndex = 0;
            Conexion = sConexion;
                   
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
        private void tbxCV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
                   // btnReporte.Focus();
                }
            }



        }
        DateTime fecha;
        String[] unimedida;
        String unime = "";
        private void btnReporte_Click(object sender, EventArgs e)
        {
            tblSalidas.Rows.Clear();
            
        string ssfecha=" AND s.fecha BETWEEN '" +
               dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'";
                obtenerVendedor();
                tblSalidas.Rows.Clear();
                if (cbxUnMedida.Text == "Todos")
                {
                    unime = "";
                }
                else
                {
                    unimedida = cbxUnMedida.Text.Split('-');
                    unime = " AND a.valor_medida=" + unimedida[0].Trim() + " AND um.nombre='" + unimedida[1].Trim() + "'";
                }
                string SSFolio = "";
                if(tbxFolio.Text!="")
                {
                    ssfecha = "";
                    SSFolio ="s.folio='" +tbxFolio.Text+"' AND ";
                    Conexion.Conectarse();
                    DataTable Tabla = new DataTable();
                    Conexion.Ejecutar("SELECT empleados_id_empleado FROM salidas WHERE folio='"+tbxFolio.Text+"'", ref Tabla);
                    Conexion.Desconectarse();
                    if(Tabla.Rows.Count>0)
                    {
                        tbxCV.Text=Tabla.Rows[0][0].ToString();
                        obtenerVendedor();
                    }

                }
                else
                {
                    SSFolio="";
                }
                if (tbxCV.Text != "")
                {


                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;
                    MySqlDataReader lector;
                    comando = new MySqlCommand("SELECT s.articulos_codigo, a.descripcion,a.valor_medida,um.nombre, " +
                        "s.n_salida, s.inventario_total, s.fecha, S.empleados_id_empleado FROM salidas s, articulos a, unidad_medida um WHERE " +
                        " s.articulos_codigo = a.codigo AND " + SSFolio + " s.empleados_id_empleado =" + tbxCV.Text + unime + " " +
                        " AND a.unidad_medida_id=um.id " + ssfecha, conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        fecha = Convert.ToDateTime(lector.GetString(6).ToString());

                        tblSalidas.Rows.Add(lector.GetString(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3)
                            , lector.GetString(4), lector.GetString(5), fecha.ToString("dd/MM/yyyy"));

                    }
                    conectar.Close();
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

                oSheet.Cells[1, 2] = "REPORTE DE SALIDAS DE VENDEDORES";
                oSheet.get_Range("A1", "E1").Merge(true);
                oSheet.get_Range("A1", "E1").Font.Bold = true;
                oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "E1").Font.Size = 18;

                oSheet.Cells[2, 1] = codigArt.HeaderText;
                oSheet.Cells[2, 2] = rSdescripcion.HeaderText;
                oSheet.Cells[2, 3] = NSalida.HeaderText;
                oSheet.Cells[2, 4] = repSInvT.HeaderText;
                oSheet.Cells[2, 5] = repSFecha.HeaderText;
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A2", "I2").Font.Bold = true;
                oSheet.get_Range("A2", "I2").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A2", "I2").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;

                // Create an array to multiple values at once.
                int fila = tblSalidas.Rows.Count;
                int colum = tblSalidas.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        oSheet.Cells[i + 3, j + 1] = tblSalidas[j, i].Value.ToString();
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
            AbrirConsultaExcel(tblSalidas);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (tblSalidas.Rows.Count > 0)
            {
                (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1.5;
                printPreviewDialog1.ShowDialog();
            }
        }
        int col1, col2, col3, col4, col5, i=0,x,L;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (tblSalidas.Rows.Count > 0)
            {
                int height = 0;
                //int width = 0;
                int an = -5;
                //int t = 260;
                Font letra = new Font("Arial", 9);
                // int width = 0;
                x = 100;
                L = 105;
                col1 = tblSalidas.Columns[0].Width-an;
                col2 = tblSalidas.Columns[1].Width-an;
                col3 = tblSalidas.Columns[2].Width-an;
                col4 = tblSalidas.Columns[3].Width-an;
                col5 = tblSalidas.Columns[4].Width-an;
                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);
                #region titulo
                e.Graphics.DrawString("SALIDAS", new Font("Arial", 14,FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 2+50, 50, 500, tblSalidas.Rows[0].Height + 15));
                #endregion

                #region NombreVendedor
                e.Graphics.DrawString("Vendedor:" + tbxNombre.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 75, 500, tblSalidas.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                //                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, 100, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[0].HeaderText.ToString(), tblSalidas.Font, Brushes.Black, new Rectangle(x, 100, col1, tblSalidas.Rows[0].Height + 15));

                #endregion

                #region Descripcion

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, 100, col2, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[1].HeaderText.ToString(), tblSalidas.Font, Brushes.Black, new Rectangle(x + col1, 100, col2, tblSalidas.Rows[0].Height + 15));

                #endregion

                #region Salidas
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[2].HeaderText.ToString(), tblSalidas.Font, Brushes.Black, new Rectangle(x + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));


                #endregion

                #region InventarioVendedor

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, 100, col4, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, 100, col4, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[3].HeaderText.ToString(), tblSalidas.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, 100, col4, tblSalidas.Rows[0].Height + 15));

                #endregion

                #region fecha

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[4].HeaderText.ToString(), tblSalidas.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

               

                height = 115;

                while (i < tblSalidas.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 115;
                        e.HasMorePages = true;
                        return;
                    }


                    height += tblSalidas.Rows[0].Height;

                    //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblSalidas.Columns[1].Width, tblSalidas.Rows[0].Height));
                    e.Graphics.DrawString(tblSalidas.Rows[i].Cells[0].FormattedValue.ToString(), tblSalidas.Font, Brushes.Black, new Rectangle( L, height, tblSalidas.Columns[0].Width, tblSalidas.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[2].Width, tblSalidas.Rows[0].Height));
                    e.Graphics.DrawString(tblSalidas.Rows[i].Cells[1].FormattedValue.ToString(), tblSalidas.Font, Brushes.Black, new Rectangle(L + col1, height, tblSalidas.Columns[1].Width, tblSalidas.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[3].Width, tblSalidas.Rows[0].Height));
                    e.Graphics.DrawString(tblSalidas.Rows[i].Cells[2].FormattedValue.ToString(), tblSalidas.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, tblSalidas.Columns[2].Width, tblSalidas.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[4].Width, tblSalidas.Rows[0].Height));
                    e.Graphics.DrawString(tblSalidas.Rows[i].Cells[3].FormattedValue.ToString(), tblSalidas.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblSalidas.Columns[3].Width, tblSalidas.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[5].Width, tblSalidas.Rows[0].Height));
                    e.Graphics.DrawString(tblSalidas.Rows[i].Cells[4].FormattedValue.ToString(), tblSalidas.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblSalidas.Columns[4].Width, tblSalidas.Rows[0].Height));


                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void tblSalidas_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            
            // If the cells are equal, sort based on the ID column.
                if (e.Column.Name == "codigArt")
            {
                // e.SortResult = tblSalidas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblSalidas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(tblSalidas.Rows[e.RowIndex1].Cells["codigArt"].Value.ToString()),
                    Convert.ToInt32(tblSalidas.Rows[e.RowIndex2].Cells["codigArt"].Value.ToString()));
            }
                if (e.Column.Name == "NSalida")
            {
                // e.SortResult = tblSalidas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblSalidas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblSalidas.Rows[e.RowIndex1].Cells["NSalida"].Value.ToString()),
                    Convert.ToDouble(tblSalidas.Rows[e.RowIndex2].Cells["NSalida"].Value.ToString()));
            }

                if (e.Column.Name == "repSInvT")
            {
                // e.SortResult = tblSalidas.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblSalidas.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblSalidas.Rows[e.RowIndex1].Cells["repSInvT"].Value.ToString()),
                    Convert.ToDouble(tblSalidas.Rows[e.RowIndex2].Cells["repSInvT"].Value.ToString()));
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

        private void tbxCV_Leave(object sender, EventArgs e)
        {
            obtenerVendedor();
        }

        private void tbxFolio_Leave(object sender, EventArgs e)
        {
            btnReporte_Click(sender, e);
        }

        private void tbxFolio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbxFolio_Leave(sender,e);

            }
        }

        private void tbxFolio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                FolioSalidas B = new FolioSalidas(Conexion);
                B.ShowDialog();
                if (B.ID.Length > 0)
                {
                    tbxFolio.Text = B.ID;
                    btnReporte_Click(sender, e);
                }

            }
        }
        
    }
}
