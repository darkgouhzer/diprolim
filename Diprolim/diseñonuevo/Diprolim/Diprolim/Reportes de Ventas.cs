using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;


namespace Diprolim
{
    public partial class Reportes_de_Ventas : Form
    {
        conexion conn = new conexion();
        MySqlCommand comando;
        MySqlConnection conectar;
        MySqlDataReader lector;
        Boolean validacion;
        Inventarios.DBMS_Unico Conexion;
        public Reportes_de_Ventas(Inventarios.DBMS_Unico sConexion)
        {
            InitializeComponent();
            Conexion = sConexion;
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
            categorias();
            unidadesMedida();
            cbxDepto.SelectedIndex = 0;
            cbxUnMedida.SelectedIndex = 0;
            cbxTipoVenta.SelectedIndex = 0;
        }
        public void unidadesMedida()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select distinct a.valor_medida, um.nombre from articulos a, unidad_medida um where a.unidad_medida_id=um.id;", conectar);
            conectar.Open();
            MySqlDataReader lector = comando.ExecuteReader();
            cbxUnMedida.Items.Add("Todos");
            while (lector.Read())
            {
                cbxUnMedida.Items.Add(lector.GetString(0)+" - "+lector.GetString(1));
            }
            conectar.Close();

        }
        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoVendedor();
            }
            
        }
        public void MetodoVendedor()
        {
            validacion = false;

            if (tbxVendedor.Text.Length == 0)
            {

                btnReporte.Focus();

                tbxNVendedor.Text = "";
            }
            else
            {

                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select count(*) from empleados where id_empleado=" + tbxVendedor.Text, conectar);
                conectar.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    if (Convert.ToInt32(lector.GetString(0)) > 0)
                    {
                        validacion = true;
                    }
                    else
                    {
                        MessageBox.Show("Código de vendedor no existe");
                        tbxVendedor.Clear();
                        tbxNVendedor.Clear();
                    }
                }

                conectar.Close();
                if (validacion)
                {

                    comando = new MySqlCommand("select nombre, apellido_paterno, apellido_materno from empleados where id_empleado=" + tbxVendedor.Text, conectar);
                    conectar.Open();

                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        tbxNVendedor.Text = lector.GetString(0).ToString() + " " + lector.GetString(1).ToString() + " " + lector.GetString(2).ToString();

                    }
                    conectar.Close();
                }
            }
            if (validacion)
            {

                btnReporte.Focus();

            }
        }
        double sumaTotal=0,totalComision=0;
        String[] unimedida;
        String vendedor, cliente, productos, tipocliente, str_depto = "", unime = "", str_tipventa="";
        int Cod_Empleado = 0;
        private void btnReporte_Click(object sender, EventArgs e)
        {
            sumaTotal = 0;
            totalComision = 0;
            vendedor = "";
            cliente = "";
            productos = "";
            tipocliente = "";

            if (cbxTipoVenta.Text == "Todos")
            {
                str_tipventa = "";
            }
            else if (cbxTipoVenta.Text == "Contado")
            {
                str_tipventa = " and v.tipo_compra='contado'";
            }
            else if (cbxTipoVenta.Text == "Crédito")
            {
                str_tipventa = " and v.tipo_compra='credito'";
            }
            else if (cbxTipoVenta.Text == "Consignación")
            {
                str_tipventa = " and v.tipo_compra='consignacion'";
            }
            if (cbxDepto.Text == "Todos")
            {
                str_depto = "";
            }
            else if (cbxDepto.Text == "Productos")
            {
                str_depto = " and a.departamento=1";
            }
            else if (cbxDepto.Text == "Accesorios")
            {
                str_depto = " and a.departamento=2";
            }
            else if (cbxDepto.Text == "Papel")
            {
                str_depto = " and a.departamento=3";
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

            if (tbxVendedor.Text.Length > 0)
            {
                vendedor = " AND v.empleados_id_empleado=" + tbxVendedor.Text;
            }
            else
            {
                tbxNVendedor.Text = "";
            }
            if (tbxCliente.Text.Length > 0)
            {
                cliente = " AND v.clientes_idclientes=" + tbxCliente.Text;
            }
            else
            {
                tbxNCliente.Text = "";
            }
            if (tbxProducto.Text.Length > 0)
            {
                productos = " AND v.articulos_codigo=" + tbxProducto.Text;
            }
            else
            {
                tbxNProducto.Text = "";
            }
            if (cbxCategoria.Text != "Todos")
            {
                tipocliente = " AND v.categorias_idcategorias=" + cbxCategoria.SelectedValue;
            }
            tblReporteV.Rows.Clear();
            tblReporteV2.Rows.Clear();
            DateTime fecha;
            conectar = conn.ObtenerConexion();
            if (rdbTodo.Checked == true)
            {
                tblReporteV.Visible = true;
                tblReporteV2.Visible = false;
                tblReporteV3.Visible = false;
                comando = new MySqlCommand("SELECT v.articulos_codigo,v.fecha_venta, e.nombre,c.nombre, a.descripcion,a.valor_medida,um.nombre, v.precio_art,v.cantidad, v.importe, v.comision " +
                "FROM ventas v,categorias c, articulos a, empleados e, unidad_medida um WHERE v.categorias_idcategorias=c.idcategorias and v.articulos_codigo = a.codigo AND " +
                "v.empleados_id_empleado = e.id_empleado AND a.unidad_medida_id=um.id  AND v.fecha_venta BETWEEN '" +
                dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "' " + str_depto + vendedor + cliente + productos + tipocliente + unime + str_tipventa + "  ORDER BY v.fecha_venta ASC;", conectar);

                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    fecha = Convert.ToDateTime(lector.GetString(1));

                    tblReporteV.Rows.Add(lector.GetString(0), fecha.ToString("dd/MM/yyyy"), lector.GetString(2), lector.GetString(3), lector.GetString(4) + " " + lector.GetString(5) + lector.GetString(6),
                        lector.GetDouble(7), lector.GetDouble(8), lector.GetDouble(9), lector.GetDouble(10));
                    sumaTotal += Convert.ToDouble(lector.GetString(9));
                    totalComision += Convert.ToDouble(lector.GetString(10));

                }

                conectar.Close();
                tblReporteV.Rows.Add("", "", "", "", "", "", "Total:", sumaTotal, totalComision);
            }
            else if (rdbSoloT.Checked == true)
            {
                tblReporteV.Visible = false;
                tblReporteV2.Visible = true;
                tblReporteV3.Visible = false;
                comando = new MySqlCommand("SELECT * FROM empleados", conectar);
                 Cod_Empleado = 0;
                conectar.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Cod_Empleado = lector.GetInt32(0);
                    LLebar();
                }
                tblReporteV2.Rows.Add("", "", "Total:", totall, "","", "", "", "");
                totall = 0;
                conectar.Close();
            }
            else if (rdbClientes.Checked == true)
            {
                tblReporteV.Visible = false;
                tblReporteV2.Visible = false;
                tblReporteV3.Visible = true;
                tblReporteV3.Rows.Clear();
                comando = new MySqlCommand("SELECT * FROM Ventas v WHERE v.fecha_venta BETWEEN '" +
                dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "' " + vendedor + " ", conectar);
                Cod_Empleado = 0;
                conectar.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    if (!VerSiExiste(lector.GetInt32(2)))
                    {
                        Cod_Empleado = lector.GetInt32(2);
                        LLenar();
                    }
                }
                tblReporteV3.Rows.Add("", "Total:", totall);
                totall = 0;
                conectar.Close();

         
            }
        }
        public Boolean VerSiExiste(Int32 Cliente)
        {
            Boolean bALLOk = false;

            if(tblReporteV3.Rows.Count>0)
            {
                for(int i=0; i<tblReporteV3.Rows.Count;i++)
                {
                    if(Cliente.ToString()==tblReporteV3[3, i].Value.ToString()&&!bALLOk)
                    {
                        bALLOk = true;
                    }
                }
            }
            else
            {
                bALLOk = false;
            }

            return bALLOk;
        }
        double totall = 0;
               // tblReporteV2.Rows.Add(lector.GetString(0), dtpInicio.Value.ToString("dd/MM/yyyy"), lector.GetString(2), sumaTotal);
        public void LLebar()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("SELECT e.id_empleado,v.articulos_codigo,v.fecha_venta, e.nombre,c.nombre, a.descripcion,a.valor_medida,um.nombre, v.precio_art,v.cantidad, v.importe, v.comision " +
                "FROM ventas v,categorias c, articulos a, empleados e, unidad_medida um WHERE v.empleados_id_empleado="+Cod_Empleado+" and v.categorias_idcategorias=c.idcategorias and v.articulos_codigo = a.codigo AND " +
                "v.empleados_id_empleado = e.id_empleado AND a.unidad_medida_id=um.id  AND v.fecha_venta BETWEEN '" +
                dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "' " + str_depto + vendedor + cliente + productos + tipocliente + unime + str_tipventa + "  ORDER BY v.fecha_venta ASC;", conectar);

            conectar.Open();
            int Pase = 0;
            string NombreVendedor = "";
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Pase = 1;
                Cod_Empleado = lector.GetInt32(0);
                NombreVendedor = lector.GetString(3);
                sumaTotal += lector.GetDouble(10);
            }
            if(Pase==1)
            {
                totall += sumaTotal;
                tblReporteV2.Rows.Add(Cod_Empleado, dtpInicio.Value.ToString("dd/MM/yy") + " - " + dtpFin.Value.ToString("dd/MM/yy"), NombreVendedor, sumaTotal, "", "", "", "", "");
                sumaTotal = 0;
            }
            

            conectar.Close();
        }
        public void LLenar()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("SELECT e.nombre,c.idclientes, c.nombre, v.importe " +
                "FROM ventas v,clientes c, empleados e WHERE v.clientes_idclientes=" + Cod_Empleado + " AND " +
                "v.clientes_idclientes = c.idclientes AND v.empleados_id_empleado=e.id_empleado  AND v.fecha_venta BETWEEN '" +
                dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "' " + str_depto + vendedor + cliente + productos + tipocliente + unime + str_tipventa + "  ORDER BY v.fecha_venta ASC;", conectar);

            conectar.Open();
            int Pase = 0;
            string NombreVendedor = "";
            string NombreCliente = "";
            int CodCliente = 0;
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Pase = 1;
                CodCliente = lector.GetInt32(1);
                NombreVendedor = lector.GetString(0);
                NombreCliente = lector.GetString(2);
                sumaTotal += lector.GetDouble(3);
            }
            if (Pase == 1)
            {
                totall += sumaTotal;
                tblReporteV3.Rows.Add(NombreVendedor, NombreCliente, sumaTotal, CodCliente);
                sumaTotal = 0;
            }


            conectar.Close();
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


                if (rdbTodo.Checked)
                {
                    oSheet.Cells[1, 2] = "REPORTE DE VENTAS";
                    oSheet.get_Range("A1", "I1").Merge(true);
                    oSheet.get_Range("A1", "I1").Font.Bold = true;
                    oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", "I1").Font.Size = 18;
                }
                else if (rdbSoloT.Checked)
                {
                    oSheet.Cells[1, 2] = "REPORTE DE VENTAS";
                    oSheet.get_Range("A1", "I1").Merge(true);
                    oSheet.get_Range("A1", "I1").Font.Bold = true;
                    oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", "I1").Font.Size = 18;
                }
                else if (rdbClientes.Checked)
                {
                    oSheet.Cells[1, 2] = "REPORTE DE VENTAS";
                    oSheet.get_Range("A1", "C1").Merge(true);
                    oSheet.get_Range("A1", "C1").Font.Bold = true;
                    oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", "C1").Font.Size = 18;
                    Columnas = dgvConsulta.Columns.Count - 1;

                }           

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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (rdbTodo.Checked)
            {
                AbrirConsultaExcel(tblReporteV);
            }
            else if (rdbSoloT.Checked)
            {
                AbrirConsultaExcel(tblReporteV2);
            }
            else if (rdbClientes.Checked)
            {
                AbrirConsultaExcel(tblReporteV3);
            }
        }

        private void cbxTipoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnReporte.Focus();
            }
        }

        private void tbxCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (rdbTodo.Checked)
            {
                (printPreviewDialogTodo as Form).WindowState = FormWindowState.Maximized;
                printPreviewDialogTodo.PrintPreviewControl.Zoom = 1;
                printDocTodo.DefaultPageSettings.Landscape = true;
                printPreviewDialogTodo.ShowDialog();
            }
            else if (rdbSoloT.Checked)
            {
                (printPreviewDialogTotales as Form).WindowState = FormWindowState.Maximized;
                printPreviewDialogTotales.PrintPreviewControl.Zoom = 1.5;
                printPreviewDialogTotales.ShowDialog();
            }
            else if (rdbClientes.Checked)
            {
                (printPreviewDialogClientes as Form).WindowState = FormWindowState.Maximized;
                printPreviewDialogClientes.PrintPreviewControl.Zoom = 1.5;
                printPreviewDialogClientes.ShowDialog();

            }
        }
        int col1, col2, col3, col4, col5, col6, col7,col8,col9,y, i = 0, x, L;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (tblReporteV.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width/2;
                int an = 0;
                int al = 15;
                x = 80;
                y = 125;
                L = 85;
                Font letra = new Font("Arial", 9);
                col1 = tblReporteV.Columns[0].Width-an;
                col2 = tblReporteV.Columns[1].Width-an;
                col3 = tblReporteV.Columns[2].Width-an;
                col4 = tblReporteV.Columns[3].Width-an;
                col5 = tblReporteV.Columns[4].Width-an;
                col6 = tblReporteV.Columns[5].Width-an;
                col7 = tblReporteV.Columns[6].Width-an;
                col8 = tblReporteV.Columns[7].Width-an;
                col9 = tblReporteV.Columns[7].Width - an;
                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("REPORTE DE VENTAS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, tblReporteV.Rows[0].Height + 15));
                #endregion

                #region NombreVendedor
                e.Graphics.DrawString("Vendedor: " + tbxNVendedor.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 85, 500, tblReporteV.Rows[0].Height + 15));
                #endregion
                #region NombreCliente
                e.Graphics.DrawString("Cliente: " + tbxNCliente.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 105, 500, tblReporteV.Rows[0].Height + 15));
                #endregion

                #region fecha
                e.Graphics.DrawString(dtpInicio.Value.ToString("dd/MMMM/yyyy")+" - "+dtpFin.Value.ToString("dd/MMMM/yyyy"), new Font("Arial", 10), Brushes.Black, new Rectangle(e.MarginBounds.Width-60, 105, 500, tblReporteV.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                //           e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60, 100, col1, tblReporteV.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, tblReporteV.Rows[0].Height+al));
                e.Graphics.DrawString(tblReporteV.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, tblReporteV.Rows[0].Height+al));

                #endregion

                #region fechaventa

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1, 100, col2 + 100, tblReporteV.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, tblReporteV.Rows[0].Height+al));
                e.Graphics.DrawString(tblReporteV.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, tblReporteV.Rows[0].Height+al));

                #endregion

                #region vendedor
                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2, 100, col3, tblReporteV.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, tblReporteV.Rows[0].Height+al));
                e.Graphics.DrawString(tblReporteV.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, tblReporteV.Rows[0].Height+al));


                #endregion

                #region tipocliente

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, tblReporteV.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, tblReporteV.Rows[0].Height+al));
                e.Graphics.DrawString(tblReporteV.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, tblReporteV.Rows[0].Height+al));

                #endregion

                #region producto

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4, 100, col5, tblReporteV.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblReporteV.Rows[0].Height+al));
                e.Graphics.DrawString(tblReporteV.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblReporteV.Rows[0].Height+al));
                //   MessageBox.Show("" + tblReporteV.Rows[1].Height);
                #endregion

                #region precioVenta

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4 + col5, 100, col6, tblReporteV.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblReporteV.Rows[0].Height+al));
                e.Graphics.DrawString(tblReporteV.Columns[5].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblReporteV.Rows[0].Height+al));
                //   MessageBox.Show("" + tblReporteV.Rows[1].Height);
                #endregion

                #region unidadesVendidas

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4 + col5, 100, col6, tblReporteV.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5+col6, y, col7, tblReporteV.Rows[0].Height+al));
                e.Graphics.DrawString(tblReporteV.Columns[6].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5+col6, y, col7, tblReporteV.Rows[0].Height+al));
                //   MessageBox.Show("" + tblReporteV.Rows[1].Height);
                #endregion

                #region Total

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4 + col5, 100, col6, tblReporteV.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5+col6+col7, y, col8, tblReporteV.Rows[0].Height+al));
                e.Graphics.DrawString(tblReporteV.Columns[7].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5+col6+col7, y, col8, tblReporteV.Rows[0].Height+al));
                //   MessageBox.Show("" + tblReporteV.Rows[1].Height);
                #endregion

                #region Comision

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4 + col5, 100, col6, tblReporteV.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7+col8, y, col9, tblReporteV.Rows[0].Height+al));
                e.Graphics.DrawString(tblReporteV.Columns[8].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7+col8, y, col9, tblReporteV.Rows[0].Height+al));
                //   MessageBox.Show("" + tblReporteV.Rows[1].Height);
                #endregion

                height = 125+al;

                while (i < tblReporteV.Rows.Count)
                {
                    if (height > e.MarginBounds.Height+100)
                    {
                        height = 125+al;
                        e.HasMorePages = true;
                        return;
                    }


                    height += tblReporteV.Rows[0].Height;

                    //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblReporteV.Columns[1].Width, tblReporteV.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, tblReporteV.Columns[0].Width, tblReporteV.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + tblReporteV.Columns[1].Width, height, tblReporteV.Columns[2].Width, tblReporteV.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, tblReporteV.Columns[1].Width, tblReporteV.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblReporteV.Columns[1].Width, height, tblReporteV.Columns[3].Width, tblReporteV.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, tblReporteV.Columns[2].Width, tblReporteV.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblReporteV.Columns[1].Width, height, tblReporteV.Columns[4].Width, tblReporteV.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblReporteV.Columns[3].Width, tblReporteV.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + tblReporteV.Columns[1].Width, height, tblReporteV.Columns[5].Width, tblReporteV.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblReporteV.Columns[4].Width, tblReporteV.Rows[0].Height));

                    e.Graphics.DrawString(tblReporteV.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, tblReporteV.Columns[5].Width, tblReporteV.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5+col6, height, tblReporteV.Columns[6].Width, tblReporteV.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV.Rows[i].Cells[7].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7, height, tblReporteV.Columns[7].Width, tblReporteV.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV.Rows[i].Cells[8].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7+col8, height, tblReporteV.Columns[8].Width, tblReporteV.Rows[0].Height));

                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedor.Text = id.regresar.valXn;
            }
            tbxVendedor.Focus();
            MetodoVendedor();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarArticulos id = new BuscarArticulos();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxProducto.Text = id.regresar.valXn;
                tbxProducto.Focus();
            }
            obtenerProducto();
        }

        private void btnSC_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes("");
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCliente.Text = id.regresar.valXn;
            }
            tbxCliente.Focus();
            MetodoCliente();
        }

        public void categorias()
        {
            List<sourceUnidadesMedida> lista = new List<sourceUnidadesMedida>();
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand("select idcategorias, nombre from categorias where clase='a'", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            sourceUnidadesMedida datos = new sourceUnidadesMedida();
            datos.ID = 0;
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
            cbxCategoria.DataSource = lista;
            cbxCategoria.DisplayMember = "nombre";
            cbxCategoria.ValueMember = "ID";

        }

        private void tbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoCliente();
            }
        }
        public void MetodoCliente()
        {
            if (tbxCliente.Text != "")
            {

                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT nombre FROM clientes WHERE idclientes =" + tbxCliente.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    tbxNCliente.Text = lector.GetString(0);


                    des = lector.GetString(0);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Ese cliente no existe");
                    tbxCliente.Clear();
                    tbxNCliente.Clear();
                }
                else
                {
                    tbxProducto.Focus();
                }
            }
        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                obtenerProducto();
            } 
        }

        public void obtenerProducto()
        {
            if (tbxProducto.Text != "")
            {

                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre FROM articulos a, unidad_medida u WHERE codigo =" + tbxProducto.Text + " and a.unidad_medida_id=u.id", conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    tbxNProducto.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);

                    des = lector.GetString(0);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("El código de producto no existe");
                    tbxNProducto.Clear();
                    tbxProducto.Clear();

                }
            }



        }

        private void tbxCliente_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tblReporteV_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.RowIndex2 < tblReporteV.Rows.Count - 1 && e.RowIndex1 < tblReporteV.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "tblCodigo" && e.RowIndex2 < tblReporteV.Rows.Count - 1 && e.RowIndex1 < tblReporteV.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(tblReporteV.Rows[e.RowIndex1].Cells["tblCodigo"].Value.ToString()),
                    Convert.ToInt32(tblReporteV.Rows[e.RowIndex2].Cells["tblCodigo"].Value.ToString()));
            }
            if (e.Column.Name == "tblPrecio" && e.RowIndex2 < tblReporteV.Rows.Count - 1 && e.RowIndex1 < tblReporteV.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblReporteV.Rows[e.RowIndex1].Cells["tblPrecio"].Value.ToString()),
                    Convert.ToDouble(tblReporteV.Rows[e.RowIndex2].Cells["tblPrecio"].Value.ToString()));
            }

            if (e.Column.Name == "tblCantidad" && e.RowIndex2 < tblReporteV.Rows.Count - 1 && e.RowIndex1 < tblReporteV.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblReporteV.Rows[e.RowIndex1].Cells["tblCantidad"].Value.ToString()),
                    Convert.ToDouble(tblReporteV.Rows[e.RowIndex2].Cells["tblCantidad"].Value.ToString()));
            }

            if (e.Column.Name == "tblTotal" && e.RowIndex2 < tblReporteV.Rows.Count - 1 && e.RowIndex1 < tblReporteV.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblReporteV.Rows[e.RowIndex1].Cells["tblTotal"].Value.ToString()),
                    Convert.ToDouble(tblReporteV.Rows[e.RowIndex2].Cells["tblTotal"].Value.ToString()));
            }
            if (e.Column.Name == "tblComision" && e.RowIndex2 < tblReporteV.Rows.Count - 1 && e.RowIndex1 < tblReporteV.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblReporteV.Rows[e.RowIndex1].Cells["tblComision"].Value.ToString()),
                    Convert.ToDouble(tblReporteV.Rows[e.RowIndex2].Cells["tblComision"].Value.ToString()));
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

        private void tblReporteV2_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.RowIndex2 < tblReporteV2.Rows.Count - 1 && e.RowIndex1 < tblReporteV2.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "tblCodigo" && e.RowIndex2 < tblReporteV2.Rows.Count - 1 && e.RowIndex1 < tblReporteV2.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(tblReporteV2.Rows[e.RowIndex1].Cells["tblCodigo"].Value.ToString()),
                    Convert.ToInt32(tblReporteV2.Rows[e.RowIndex2].Cells["tblCodigo"].Value.ToString()));
            }
            if (e.Column.Name == "tblPrecio" && e.RowIndex2 < tblReporteV2.Rows.Count - 1 && e.RowIndex1 < tblReporteV2.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblReporteV2.Rows[e.RowIndex1].Cells["tblPrecio"].Value.ToString()),
                    Convert.ToDouble(tblReporteV2.Rows[e.RowIndex2].Cells["tblPrecio"].Value.ToString()));
            }

            if (e.Column.Name == "tblCantidad" && e.RowIndex2 < tblReporteV2.Rows.Count - 1 && e.RowIndex1 < tblReporteV2.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblReporteV2.Rows[e.RowIndex1].Cells["tblCantidad"].Value.ToString()),
                    Convert.ToDouble(tblReporteV2.Rows[e.RowIndex2].Cells["tblCantidad"].Value.ToString()));
            }

            if (e.Column.Name == "tblTotal" && e.RowIndex2 < tblReporteV2.Rows.Count - 1 && e.RowIndex1 < tblReporteV2.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblReporteV2.Rows[e.RowIndex1].Cells["tblTotal"].Value.ToString()),
                    Convert.ToDouble(tblReporteV2.Rows[e.RowIndex2].Cells["tblTotal"].Value.ToString()));
            }
            if (e.Column.Name == "tblComision" && e.RowIndex2 < tblReporteV2.Rows.Count - 1 && e.RowIndex1 < tblReporteV2.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblReporteV2.Rows[e.RowIndex1].Cells["tblComision"].Value.ToString()),
                    Convert.ToDouble(tblReporteV2.Rows[e.RowIndex2].Cells["tblComision"].Value.ToString()));
            }

            e.Handled = true;
        }

        private void printDocumentTotales_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (tblReporteV2.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width / 2;
                int an = 0;
                int al = 15;
                x = 150;
                y = 125;
                L = x+5;
                Font letra = new Font("Arial", 9);
                col1 = tblReporteV2.Columns[0].Width - an;
                col2 = tblReporteV2.Columns[1].Width - an;
                col3 = tblReporteV2.Columns[2].Width - an+100;
                col4 = tblReporteV2.Columns[3].Width - an;
                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(100, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("REPORTE DE VENTAS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, tblReporteV2.Rows[0].Height + 15));
                #endregion

                #region NombreVendedor
                e.Graphics.DrawString("Vendedor: " + tbxNVendedor.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 85, 500, tblReporteV2.Rows[0].Height + 15));
                #endregion
                #region NombreCliente
                e.Graphics.DrawString("Cliente: " + tbxNCliente.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 105, 500, tblReporteV2.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                //           e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60, 100, col1, tblReporteV2.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, tblReporteV2.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteV2.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, tblReporteV2.Rows[0].Height + al));

                #endregion

                #region fechaventa

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1, 100, col2 + 100, tblReporteV2.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, tblReporteV2.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteV2.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, tblReporteV2.Rows[0].Height + al));

                #endregion

                #region vendedor
                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2, 100, col3, tblReporteV2.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, tblReporteV2.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteV2.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, tblReporteV2.Rows[0].Height + al));


                #endregion

                #region tipocliente

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, tblReporteV2.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, tblReporteV2.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteV2.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, tblReporteV2.Rows[0].Height + al));

                #endregion

                height = 125 + al;

                while (i < tblReporteV2.Rows.Count)
                {
                    if (height > e.MarginBounds.Height + 100)
                    {
                        height = 125 + al;
                        e.HasMorePages = true;
                        return;
                    }


                    height += tblReporteV2.Rows[0].Height;
                                       
                    e.Graphics.DrawString(tblReporteV2.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, tblReporteV2.Columns[0].Width, tblReporteV2.Rows[0].Height));

                    e.Graphics.DrawString(tblReporteV2.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, tblReporteV2.Columns[1].Width, tblReporteV2.Rows[0].Height));

                    e.Graphics.DrawString(tblReporteV2.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, tblReporteV2.Columns[2].Width+100, tblReporteV2.Rows[0].Height));

                    e.Graphics.DrawString(tblReporteV2.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblReporteV2.Columns[3].Width, tblReporteV2.Rows[0].Height));
                    
                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void rdbTodo_CheckedChanged(object sender, EventArgs e)
        {
            tblReporteV.Rows.Clear();
            tblReporteV.Visible=true;
            tblReporteV2.Rows.Clear();
            tblReporteV2.Visible = false;
            tblReporteV3.Rows.Clear();
            tblReporteV3.Visible = false;
        }

        private void rdbSoloT_CheckedChanged(object sender, EventArgs e)
        {
            tblReporteV.Rows.Clear();
            tblReporteV.Visible = false;
            tblReporteV2.Rows.Clear();
            tblReporteV2.Visible = true;
            tblReporteV3.Rows.Clear();
            tblReporteV3.Visible = false;
        }

        private void rdbSoloC_CheckedChanged(object sender, EventArgs e)
        {
            tblReporteV.Rows.Clear();
            tblReporteV.Visible = false;
            tblReporteV2.Rows.Clear();
            tblReporteV2.Visible = false;

            tblReporteV3.Rows.Clear();
            tblReporteV3.Visible = true;
        }

        private void tblReporteV3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (tblReporteV3.Rows.Count-1 > e.RowIndex && e.RowIndex>=0)
            {
                string ID = tblReporteV3.Rows[e.RowIndex].Cells[3].Value.ToString();
                VentasProductosClientesDetalle Abrir = new VentasProductosClientesDetalle(Conexion, ID, dtpInicio, dtpFin);
                Abrir.ShowDialog();
            }
        }

        private void printDocClientes_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (tblReporteV3.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width / 2;
                int an = 0;
                int al = 15;
                x = 80;
                y = 125;
                L = 85;
                Font letra = new Font("Arial", 9);
                col1 = tblReporteV3.Columns[0].Width - an;
                col2 = tblReporteV3.Columns[1].Width - an;
                col3 = tblReporteV3.Columns[2].Width - an;
                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("REPORTE DE VENTAS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, tblReporteV3.Rows[0].Height + 15));
                #endregion

                #region NombreVendedor
                e.Graphics.DrawString("Vendedor: " + tbxNVendedor.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 85, 500, tblReporteV3.Rows[0].Height + 15));
                #endregion
                #region NombreCliente
                e.Graphics.DrawString("Cliente: " + tbxNCliente.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 105, 500, tblReporteV3.Rows[0].Height + 15));
                #endregion

                #region fecha
                e.Graphics.DrawString(dtpInicio.Value.ToString("dd/MMMM/yyyy") + " - " + dtpFin.Value.ToString("dd/MMMM/yyyy"), new Font("Arial", 10), Brushes.Black, new Rectangle(e.MarginBounds.Width - 60, 105, 500, tblReporteV3.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                //           e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60, 100, col1, tblReporteV3.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, tblReporteV3.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteV3.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, tblReporteV3.Rows[0].Height + al));

                #endregion

                #region fechaventa

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1, 100, col2 + 100, tblReporteV3.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, tblReporteV3.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteV3.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, tblReporteV3.Rows[0].Height + al));

                #endregion

                #region vendedor
                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2, 100, col3, tblReporteV3.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, tblReporteV3.Rows[0].Height + al));
                e.Graphics.DrawString(tblReporteV3.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, tblReporteV3.Rows[0].Height + al));


                #endregion

                height = 125 + al;

                while (i < tblReporteV3.Rows.Count)
                {
                    if (height > e.MarginBounds.Height + 100)
                    {
                        height = 125 + al;
                        e.HasMorePages = true;
                        return;
                    }


                    height += tblReporteV3.Rows[0].Height;

                    //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblReporteV3.Columns[1].Width, tblReporteV3.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV3.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, tblReporteV3.Columns[0].Width, tblReporteV3.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + tblReporteV3.Columns[1].Width, height, tblReporteV3.Columns[2].Width, tblReporteV3.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV3.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, tblReporteV3.Columns[1].Width, tblReporteV3.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblReporteV3.Columns[1].Width, height, tblReporteV3.Columns[3].Width, tblReporteV3.Rows[0].Height));
                    e.Graphics.DrawString(tblReporteV3.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, tblReporteV3.Columns[2].Width, tblReporteV3.Rows[0].Height));
                                   
                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void tblReporteV3_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.RowIndex2 < tblReporteV3.Rows.Count - 1 && e.RowIndex1 < tblReporteV3.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }          
            if (e.Column.Name == "colTotal" && e.RowIndex2 < tblReporteV3.Rows.Count - 1 && e.RowIndex1 < tblReporteV3.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblReporteV3.Rows[e.RowIndex1].Cells["colTotal"].Value.ToString()),
                    Convert.ToDouble(tblReporteV3.Rows[e.RowIndex2].Cells["colTotal"].Value.ToString()));
            }
            e.Handled = true;
        }


    }
}
