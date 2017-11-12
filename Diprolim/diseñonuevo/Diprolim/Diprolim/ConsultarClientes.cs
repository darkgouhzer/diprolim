using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace Diprolim
{
    public partial class ConsultarClientes : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        public ConsultarClientes(UnicaSQL.DBMS_Unico sConexion)
        {
            InitializeComponent();
            Conexion = sConexion;
            //generarTabla();
            Ruta();
            RefrescarRutas();
        }
        public void RefrescarRutas()
        {
            Conexion.Conectarse();
            DataTable tabla = new DataTable();
            Conexion.Ejecutar("SELECT idLocalidades, Localidad FROM Localidades  WHERE Rutas_IdRuta='" + cbxRutas.SelectedValue + "' ", ref tabla);
            Conexion.Desconectarse();

            
            if (tabla.Rows.Count > 0)
            {
                DataRow nuevaFila = tabla.NewRow();
                nuevaFila["idLocalidades"] = "0";
                nuevaFila["Localidad"] = "Todas";
                tabla.Rows.InsertAt(nuevaFila,0);
                cbxLocalidades.DataSource = tabla;
                cbxLocalidades.DisplayMember = "Localidad";
                cbxLocalidades.ValueMember = "idLocalidades";
            }
            else
            {
                cbxLocalidades.DataSource = tabla;
            }
        }
        public void Ruta()
        {
            try
            {
                Conexion.Conectarse();
                DataTable tabla = new DataTable();
                string comando = "SELECT idRuta, Ruta FROM Rutas";
                Conexion.Ejecutar(comando, ref tabla);
                Conexion.Desconectarse();
                cbxRutas.DataSource = tabla;
                cbxRutas.DisplayMember = "Ruta";
                cbxRutas.ValueMember = "idRuta";

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        String cmd = "";
        private void button2_Click(object sender, EventArgs e)
        {
            string vendedor = "", Rutas = "";
            dtgClientes.Rows.Clear();
            DataTable tbl=new DataTable();
            if (tbxVendedor.Text.Length > 0)
            {
                vendedor = " AND a.empleados_id_empleado=" + tbxVendedor.Text;
            }
            if (cbxLocalidades.Text != "Todas")
            {
                Rutas = " AND L.Rutas_IdRuta= " + cbxRutas.SelectedValue + " AND a.Localidades_idLocalidades=" + cbxLocalidades.SelectedValue;
            }
            else
            {
                Rutas = " AND L.Rutas_IdRuta= " + cbxRutas.SelectedValue;
            }
            if (checkBox1.Checked == false)
            {
                cmd = "select a.idclientes,a.nombre,a.calle,a.telefono,i.nombre,i.apellido_paterno,i.apellido_materno, L.localidad from clientes a,"+
                    " empleados i, Localidades L, Rutas r  where  a.empleados_id_empleado=i.id_empleado " + vendedor + " AND " +
                    "a.Localidades_idLocalidades=L.idLocalidades AND L.Rutas_IdRuta= r.IdRuta order by a.idclientes asc";
            }
            else
            {
                cmd = "select a.idclientes,a.nombre,a.calle,a.telefono,i.nombre,i.apellido_paterno,i.apellido_materno, L.localidad from clientes a, " +
                    "empleados i, Localidades L, Rutas r where a.empleados_id_empleado=i.id_empleado  " + vendedor + " " + Rutas + " "+
                    "AND a.Localidades_idLocalidades=L.idLocalidades AND L.Rutas_IdRuta= r.IdRuta order by a.idclientes asc";
            }
            Conexion.Conectarse();
            Conexion.Ejecutar(cmd, ref tbl);
            Conexion.Desconectarse();
            if (tbl.Rows.Count > 0)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    DataRow row = tbl.Rows[i];
                    dtgClientes.Rows.Add(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString() + " " + row[5].ToString() + " " + row[6].ToString(), row[7].ToString());
                }
            }
        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void dtgClientes_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "codigo")
            {
                // e.SortResult = tablaEmpleados.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tablaEmpleados.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgClientes.Rows[e.RowIndex1].Cells["codigo"].Value.ToString()),
                    Convert.ToInt32(dtgClientes.Rows[e.RowIndex2].Cells["codigo"].Value.ToString()));
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                cbxRutas.Enabled = true;
                cbxLocalidades.Enabled = true;
                label4.Enabled = true;
                label6.Enabled = true;
            }
            else
            {
                cbxRutas.Enabled = false;
                cbxLocalidades.Enabled = false;
                label4.Enabled = false;
                label6.Enabled = false;
            }
        }

        private void cbxLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbxRutas_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarRutas();
        }

        private void tbxVendedor_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxVendedor.Text != "")
                {
                    DataTable Tabla = new DataTable();
                    Conexion.Conectarse();
                    string comando = "Select * from Empleados WHERE ID_Empleado=" + tbxVendedor.Text;
                    Conexion.Ejecutar(comando, ref Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        DataRow row = Tabla.Rows[0];
                        tbxNVendedor.Text = row["Nombre"].ToString() + " " + row["Apellido_Paterno"].ToString() + " " + row["Apellido_Materno"].ToString();
                    }
                    Conexion.Desconectarse();
                }
                else
                {
                    tbxNVendedor.Clear();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ConsultarClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbxVendedor.Clear();
            tbxNVendedor.Clear();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(dtgClientes);
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
                int Columnas = dgvConsulta.ColumnCount;

                    oSheet.Cells[1, 2] = "Reporte de clientes";
                    oSheet.get_Range("A1", "F1").Merge(true);
                    oSheet.get_Range("A1", "F1").Font.Bold = true;
                    oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", "F1").Font.Size = 18;
                    Columnas = dgvConsulta.Columns.Count - 1;


                for (int i = 0; i < Columnas; i++)
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
                string[,] saNames = new string[fila, Columnas];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < Columnas; j++)
                    {
                        oSheet.Cells[i + 3, j + 1] = dgvConsulta[j, i].Value.ToString();
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }
        
        int col1, col2, col3, col4, col5, col6,y, i = 0, x, L;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgClientes.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width/2;
                int an = 0;
                int al = 15;
                x = 80;
                y = 125;
                L = 85;
                Font letra = new Font("Arial", 9);
                col1 = dtgClientes.Columns[0].Width-an;
                col2 = dtgClientes.Columns[1].Width-an;
                col3 = dtgClientes.Columns[2].Width-an;
                col4 = dtgClientes.Columns[3].Width-an;
                col5 = dtgClientes.Columns[4].Width-an;
                col6 = dtgClientes.Columns[5].Width-an;
                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("REPORTE DE CLIENTES", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, dtgClientes.Rows[0].Height + 15));
                #endregion

                #region NombreVendedor
                if (tbxVendedor.Text != "")
                {
                    e.Graphics.DrawString("Vendedor: " + tbxNVendedor.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 85, 500, dtgClientes.Rows[0].Height + 15));
                }
                if (cbxRutas.Enabled)
                {
                    e.Graphics.DrawString("Ruta: " + cbxRutas.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 100, 500, dtgClientes.Rows[0].Height + 15));
                }
                #endregion
                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                //           e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60, 100, col1, dtgClientes.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgClientes.Rows[0].Height+al));
                e.Graphics.DrawString(dtgClientes.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, dtgClientes.Rows[0].Height+al));

                #endregion

                #region fechaventa

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1, 100, col2 + 100, dtgClientes.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgClientes.Rows[0].Height+al));
                e.Graphics.DrawString(dtgClientes.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, dtgClientes.Rows[0].Height+al));

                #endregion

                #region vendedor
                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2, 100, col3, dtgClientes.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgClientes.Rows[0].Height+al));
                e.Graphics.DrawString(dtgClientes.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgClientes.Rows[0].Height+al));


                #endregion

                #region tipocliente

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, dtgClientes.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, dtgClientes.Rows[0].Height+al));
                e.Graphics.DrawString(dtgClientes.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, dtgClientes.Rows[0].Height+al));

                #endregion

                #region producto

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4, 100, col5, dtgClientes.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgClientes.Rows[0].Height+al));
                e.Graphics.DrawString(dtgClientes.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgClientes.Rows[0].Height+al));
                //   MessageBox.Show("" + dtgClientes.Rows[1].Height);
                #endregion

                #region precioVenta

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4 + col5, 100, col6, dtgClientes.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgClientes.Rows[0].Height + al));
                e.Graphics.DrawString(dtgClientes.Columns[5].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgClientes.Rows[0].Height + al));
                //   MessageBox.Show("" + dtgClientes.Rows[1].Height);
                #endregion

              

                height = 125+al;

                while (i < dtgClientes.Rows.Count)
                {
                    if (height > e.MarginBounds.Height+100)
                    {
                        height = 125+al;
                        e.HasMorePages = true;
                        return;
                    }


                    height += dtgClientes.Rows[0].Height;

                    //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, dtgClientes.Columns[1].Width, dtgClientes.Rows[0].Height));
                    e.Graphics.DrawString(dtgClientes.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, dtgClientes.Columns[0].Width, dtgClientes.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + dtgClientes.Columns[1].Width, height, dtgClientes.Columns[2].Width, dtgClientes.Rows[0].Height));
                    e.Graphics.DrawString(dtgClientes.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, dtgClientes.Columns[1].Width, dtgClientes.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + dtgClientes.Columns[1].Width, height, dtgClientes.Columns[3].Width, dtgClientes.Rows[0].Height));
                    e.Graphics.DrawString(dtgClientes.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgClientes.Columns[2].Width, dtgClientes.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + dtgClientes.Columns[1].Width, height, dtgClientes.Columns[4].Width, dtgClientes.Rows[0].Height));
                    e.Graphics.DrawString(dtgClientes.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, dtgClientes.Columns[3].Width, dtgClientes.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + dtgClientes.Columns[1].Width, height, dtgClientes.Columns[5].Width, dtgClientes.Rows[0].Height));
                    e.Graphics.DrawString(dtgClientes.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, dtgClientes.Columns[4].Width, dtgClientes.Rows[0].Height));

                    e.Graphics.DrawString(dtgClientes.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, dtgClientes.Columns[5].Width, dtgClientes.Rows[0].Height));
                    //e.Graphics.DrawString(dtgClientes.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5+col6, height, dtgClientes.Columns[6].Width, dtgClientes.Rows[0].Height));

                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            dtgClientes.Rows.Clear();
            cmd = "select a.idclientes,a.nombre,a.calle,a.telefono,i.nombre,i.apellido_paterno,i.apellido_materno, L.localidad " +
            "from clientes a, empleados i, Localidades L, Rutas r where  a.nombre LIKE '%" + tbxFiltro.Text + "%' and " +
            "a.empleados_id_empleado = i.id_empleado AND a.Localidades_idLocalidades=L.idLocalidades AND L.Rutas_IdRuta= r.IdRuta order by a.idclientes asc";
            Conexion.Conectarse();
            Conexion.Ejecutar(cmd, ref tbl);
            Conexion.Desconectarse();
            if (tbl.Rows.Count > 0)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    DataRow row = tbl.Rows[i];
                    dtgClientes.Rows.Add(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString() + " " + row[5].ToString() + " " + row[6].ToString(), row[7].ToString());
                }
            }
        }

    }
}
