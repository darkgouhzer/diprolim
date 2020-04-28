using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace Diprolim
{
    public partial class consultaProductosCosto : Form
    {
        string line = "";
        conexion conn = new conexion();
        public consultaProductosCosto()
        {
            InitializeComponent();
            unidades();
            cbxDepto.SelectedIndex = 0;
            cbxUMedida.SelectedIndex = 0;
        }

        public void unidades()
        {
            List<sourceUnidadesMedida> lista = new List<sourceUnidadesMedida>();
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand("select id, nombre from unidad_medida", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            sourceUnidadesMedida datos = new sourceUnidadesMedida();
            datos.ID =0;
            datos.nombre = "Todos";
            lista.Add(datos);
            while (lector.Read())
            {
                datos = new sourceUnidadesMedida();
                datos.ID = lector.GetInt32(0);
                datos.nombre = lector.GetString(1);
                lista.Add(datos);

            }
            conectar.Close();
            cbxUMedida.DataSource = lista;
            cbxUMedida.DisplayMember = "nombre";
            cbxUMedida.ValueMember = "ID";



        }
        string depto="";
        private void Catalagos_Load(object sender, EventArgs e)
        {
            Tabla.Rows.Clear();

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select a.codigo,a.descripcion,a.valor_medida, c.nombre,a.precioproduccion,"+
                " a.precio_calle, a.precio_abarrotes, a.precio_distribuidor, a.departamento from articulos a, "+
                "unidad_medida c where a.unidad_medida_id=c.id order by a.codigo asc", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                if(lector.GetInt32(8)==1){
                    depto="Productos";
                }else if(lector.GetInt32(8)==2){
                    depto="Accesorios";
                }else if(lector.GetInt32(8)==3){
                    depto="Papel";
                }
                
                Tabla.Rows.Add(lector.GetString(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3), lector.GetDouble(4), lector.GetDouble(5),lector.GetDouble(6),lector.GetDouble(7),depto);
            }
            
        }
        string str_depto = "", str_um="";
        private void button2_Click(object sender, EventArgs e)
        {
            Tabla.Rows.Clear();
            if (cbxDepto.Text == "Todos")
            {
                str_depto = "";
            }else if(cbxDepto.Text=="Productos")
            {
                str_depto = " and departamento=1";
            }else if(cbxDepto.Text=="Accesorios")
            {
                str_depto = " and departamento=2";
            }
            else if (cbxDepto.Text == "Papel")
            {
                str_depto=" and departamento=3";
            }

            if (cbxUMedida.SelectedIndex == 0)
            {
                str_um = "";
            }
            else
            {
                str_um = " and unidad_medida_id=" + cbxUMedida.SelectedValue;
            }

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select a.codigo,a.descripcion,a.valor_medida, c.nombre,a.precioproduccion," +
                " a.precio_calle, a.precio_abarrotes, a.precio_distribuidor, a.departamento from articulos a, " +
                "unidad_medida c where a.unidad_medida_id=c.id " + str_depto + " and descripcion like '%" + tbxFiltro.Text.Trim() + "%'" + str_um + " order by a.codigo asc", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                if (lector.GetInt32(8) == 1)
                {
                    depto = "Productos";
                }
                else if (lector.GetInt32(8) == 2)
                {
                    depto = "Accesorios";
                }
                else if (lector.GetInt32(8) == 3)
                {
                    depto = "Papel";
                }

                Tabla.Rows.Add(lector.GetString(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3), lector.GetDouble(4), lector.GetDouble(5), lector.GetDouble(6), lector.GetDouble(7), depto);
            }
            
            
        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxFiltro.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button2.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                oSheet.Cells[1, 2] = "LISTA DE PRODUCTOS";
                oSheet.get_Range("A1", "H1").Merge(true);
                oSheet.get_Range("A1", "H1").Font.Bold = true;
                oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "H1").Font.Size = 18;

                oSheet.Cells[2, 1] = codigo.HeaderText;
                oSheet.Cells[2, 2] = Descripcion.HeaderText;
                oSheet.Cells[2, 3] = UM.HeaderText;
                oSheet.Cells[2, 4] = catCostoProd.HeaderText;
                oSheet.Cells[2, 5] = precioCalle.HeaderText;
                oSheet.Cells[2, 6] = precioAbarrote.HeaderText;
                oSheet.Cells[2, 7] = precioDistribuidor.HeaderText;
                oSheet.Cells[2, 8] = Departamento.HeaderText;
               
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A2", "H2").Font.Bold = true;
                oSheet.get_Range("A2", "H2").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;

                // Create an array to multiple values at once.
                int fila = Tabla.Rows.Count;
                int colum = Tabla.Columns.Count;
                string[,] saNames = new string[fila, colum];
                int f = 3;
                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        oSheet.Cells[i + 3, j + 1] = Tabla[j, i].Value.ToString();
                        
                    }
                    oRng = oSheet.get_Range("D" + f, "G" + f);
                    //oRng.Formula = "=RAND()*100000";
                    oRng.NumberFormat = "$0.00";
                    f++;
                }

               
                //Fill A2:B6 with an array of values (First and Last Names).
                //oSheet.get_Range("A2", "D6").Value2 = saNames;
                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                // oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";
                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
               // oRng = oSheet.get_Range("E2", "D6");
                //oRng.Formula = "=RAND()*100000";
             //   oRng.NumberFormat = "$0.00";
                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "D1");
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.5;
            printPreviewDialog1.ShowDialog();
        }
        int i,col1, col2, col3, col4, col5, col6, col7, col8, x, L;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (Tabla.Rows.Count > 0)
            {

                Font letra = new Font("Arial", 8);               

                int height = 0;
                int an = 20;
                int t = 280;
                // int width = 0;
                L = 90;
                x = 80;
                col1 = Tabla.Columns[0].Width - an;
                col2 = Tabla.Columns[1].Width - an;
                col3 = Tabla.Columns[2].Width - an;
                col4 = Tabla.Columns[3].Width - an;
                col5 = Tabla.Columns[4].Width - an;
                col6 = Tabla.Columns[5].Width - an;
                col7 = Tabla.Columns[6].Width - an;
                col8 = Tabla.Columns[7].Width - an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("CATALOGO DE PRODUCTOS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, Tabla.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 2.5f);

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, Tabla.Columns[0].Width, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, 100, col1, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, 100, col1, Tabla.Rows[0].Height + 15));

                #endregion

                #region Descripcion

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + Tabla.Columns[0].Width, 100, Tabla.Columns[1].Width + 100, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x+col1, 100, col2, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, 100, col2, Tabla.Rows[0].Height + 15));

                #endregion

                #region UnidadMedida
                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(300 + Tabla.Columns[0].Width, 100, Tabla.Columns[2].Width, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, 100, col3, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, 100, col3, Tabla.Rows[0].Height + 15));


                #endregion

                #region CostoProduccion
                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(300 + Tabla.Columns[0].Width, 100, Tabla.Columns[2].Width, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, 100, col4, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, 100, col4, Tabla.Rows[0].Height + 15));


                #endregion                                

                #region PrecioNormal
                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(300 + Tabla.Columns[0].Width, 100, Tabla.Columns[2].Width, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, 100, col5, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, 100, col5, Tabla.Rows[0].Height + 15));


                #endregion

                #region PrecioAbarrotes
                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(300 + Tabla.Columns[0].Width, 100, Tabla.Columns[2].Width, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, 100, col6, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[5].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, 100, col6, Tabla.Rows[0].Height + 15));


                #endregion

                #region PrecioDistribuidor
                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(300 + Tabla.Columns[0].Width, 100, Tabla.Columns[2].Width, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, 100, col7, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[6].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, 100, col7, Tabla.Rows[0].Height + 15));
                
                #endregion

                #region Departamento
                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(300 + Tabla.Columns[0].Width, 100, Tabla.Columns[2].Width, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, 100, col8, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawString(Tabla.Columns[7].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, 100, col8, Tabla.Rows[0].Height + 15));
                
                #endregion


                height = 115;
                while (i < Tabla.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 115;
                        e.HasMorePages = true;
                        return;
                    }


                    height += Tabla.Rows[0].Height;


                    //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, Tabla.Columns[1].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, col1, Tabla.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + Tabla.Columns[1].Width, height, Tabla.Columns[2].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, col2, Tabla.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + Tabla.Columns[1].Width, height, Tabla.Columns[3].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, col3, Tabla.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + Tabla.Columns[1].Width, height, Tabla.Columns[4].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, col4, Tabla.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + Tabla.Columns[1].Width, height, Tabla.Columns[5].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, col5, Tabla.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + Tabla.Columns[1].Width, height, Tabla.Columns[5].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, col6, Tabla.Rows[0].Height));

                    e.Graphics.DrawString(Tabla.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, col7, Tabla.Rows[0].Height));

                    e.Graphics.DrawString(Tabla.Rows[i].Cells[7].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7, height, col8, Tabla.Rows[0].Height));
                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void Tabla_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            
            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "codigo")
            {
                // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(Tabla.Rows[e.RowIndex1].Cells["codigo"].Value.ToString()),
                    Convert.ToInt32(Tabla.Rows[e.RowIndex2].Cells["codigo"].Value.ToString()));
            }
            if (e.Column.Name == "catCostoProd")
            {
                // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(Tabla.Rows[e.RowIndex1].Cells["catCostoProd"].Value.ToString()),
                    Convert.ToDouble(Tabla.Rows[e.RowIndex2].Cells["catCostoProd"].Value.ToString()));
            }

            if (e.Column.Name == "precioCalle")
            {
                // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(Tabla.Rows[e.RowIndex1].Cells["precioCalle"].Value.ToString()),
                    Convert.ToDouble(Tabla.Rows[e.RowIndex2].Cells["precioCalle"].Value.ToString()));
            }

            if (e.Column.Name == "precioAbarrote")
            {
                // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(Tabla.Rows[e.RowIndex1].Cells["precioAbarrote"].Value.ToString()),
                    Convert.ToDouble(Tabla.Rows[e.RowIndex2].Cells["precioAbarrote"].Value.ToString()));
            }
            if (e.Column.Name == "precioDistribuidor")
            {
                // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(Tabla.Rows[e.RowIndex1].Cells["precioDistribuidor"].Value.ToString()),
                    Convert.ToDouble(Tabla.Rows[e.RowIndex2].Cells["precioDistribuidor"].Value.ToString()));
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
