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
    public partial class Prenomina : Form
    {
        conexion conn = new conexion();
        MySqlCommand comando;
        MySqlConnection conectar;
        MySqlDataReader lector;
        Inventarios.DBMS_Unico Conexion;

        public Prenomina(Inventarios.DBMS_Unico sConexion)
        {
            InitializeComponent();
            dtpInicio.Value = DateTime.Now.AddDays(-14);
            dtpFin.Value = DateTime.Now;
            Conexion = sConexion;
        }

        Boolean validacion = false;
        
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
                    obtenerVendedor();     
                if (validacion)
                {                    
                        btnReporte.Focus();                    
                }
            }
        }
        string tipoComision = "";
        public void obtenerVendedor()
        {
            string vendedor = "", puesto = "";
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
                    tbxNVendedor.Clear();
                    tbxVendedor.Clear();
                    tbxPuesto.Clear();
                }
            }
            conectar.Close();
            if (validacion)
            {
                Int32 codigo = 0;
                comando = new MySqlCommand("select e.nombre, e.apellido_paterno, e.apellido_materno, e.Puestos_idPuestos, p.nombre from empleados e, puestos p where e.Puestos_idPuestos=p.idpuestos and e.id_empleado=" + tbxVendedor.Text, conectar);
                conectar.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    codigo = lector.GetInt32(3);
                    vendedor = lector.GetString(0).ToString() + " " + lector.GetString(1).ToString() + " " + lector.GetString(2).ToString();
                    puesto = lector.GetString(4);
                }
                conectar.Close();
                if (aplicaComision(codigo))
                {
                    tbxNVendedor.Text = vendedor;
                    tbxPuesto.Text = puesto;
                }
                else
                {
                    MessageBox.Show("Este empleado no aplica para comisión");
                }
            }
          
        }
        public Boolean aplicaComision(Int32 codigoPuesto)
        {
            Boolean aplica = false;
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select aplicacomision,nombre from Puestos where idPuestos=" + codigoPuesto, conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                if (lector.GetBoolean(0))
                {
                    aplica = true;
                    tipoComision = lector.GetString(1);
                }
                else
                {
                    aplica = false;
                }
            }
            conectar.Close();
            return aplica;
        }
        double Totales, totalComision;
        private void btnReporte_Click(object sender, EventArgs e)
        {
            totalComision = 0;
            Totales = 0;
            tblComisiones.Rows.Clear();
            string cmd = "";
            string vendedor = "";
            if (tbxVendedor.Text.Length > 0)
            {
                obtenerVendedor();
                conectar = conn.ObtenerConexion();
                if (tipoComision != "Gerente")
                {
                    vendedor = "v.empleados_id_empleado=" + tbxVendedor.Text + " and ";
                }
                else if (tipoComision == "Gerente")
                {
                    vendedor = "";
                }
                //Categorias
                comando = new MySqlCommand("SELECT nombre, "+tipoComision+" from categorias", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tblComisiones.Rows.Add(lector.GetString(0), 0, 0, 0, 0, 0, 0, 0, lector.GetDouble(1));
                }
                conectar.Close();
                tblComisiones.Rows.Add("Total", 0, 0, 0, 0, 0, 0, 0, "");

                //Total venta
                Totales = 0;
                cmd = string.Format("select c.nombre, sum(v.importe) from ventas v, categorias c where c.idcategorias="+
                    "v.categorias_idcategorias and "+vendedor+"v.fecha_venta between  '" + dtpInicio.Value.ToString("yyyyMMdd000000") +
                    "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "' AND v.articulos_codigo IN "+
                    "(SELECT codigo FROM articulos WHERE aplicacomision=1) GROUP BY c.nombre;");
                comando = new MySqlCommand(cmd, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    for (int i = 0; i < tblComisiones.Rows.Count; i++)
                    {
                        if (tblComisiones[0, i].Value.ToString() == lector.GetString(0))
                        {
                            tblComisiones[1, i].Value = lector.GetDouble(1);
                        }
                    }
                    Totales += lector.GetDouble(1);
                    tblComisiones[1, tblComisiones.Rows.Count-1].Value = Totales;
                }
                conectar.Close();

                //Total contado
                Totales = 0;
                cmd = string.Format("select c.nombre, v.importe,v.iva from ventas v, categorias c where v.tipo_compra='contado' and "+
                    "c.idcategorias=v.categorias_idcategorias and " + vendedor + "v.fecha_venta between  '" +
                    dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "' AND "+
                    "v.articulos_codigo IN (SELECT codigo FROM articulos WHERE aplicacomision=1);");
                comando = new MySqlCommand(cmd, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                double SinIva = 0;
                string sCategoriaa = "";
                double ConIva = 0;
                DataTable Tabla = new DataTable();
                //Tabla.Load(comando.ExecuteReader());
                while (lector.Read())
                {
                    ConIva = 0;
                    SinIva = 0;
                    sCategoriaa = lector.GetString(0);
                    if (Convert.ToDouble(lector.GetString(2)) > 0)
                    {
                        ConIva += lector.GetDouble(1)/1.16;
                    }
                    else
                    {
                        SinIva += lector.GetDouble(1);
                    }

                    for (int i = 0; i < tblComisiones.Rows.Count; i++)
                    {
                        if (tblComisiones[0, i].Value.ToString() == sCategoriaa)
                        {
                            tblComisiones[2, i].Value = Convert.ToDouble(tblComisiones[2, i].Value)+ ConIva + SinIva;
                        }
                    }
                    
                }
                conectar.Close();
                for (int i = 0; i < tblComisiones.Rows.Count; i++)
                {
                    Totales += Convert.ToDouble(tblComisiones[2, i].Value);
                }
                tblComisiones[2, tblComisiones.Rows.Count - 1].Value = Totales;
                //------------------------
               
                
                //------------------------

                //Total Credito
                Totales = 0;
                cmd = string.Format("select c.nombre, sum(v.importe) from ventas v, categorias c where v.tipo_compra='credito' and "+
                    "c.idcategorias=v.categorias_idcategorias and " + vendedor + "v.fecha_venta between  '" +
                    dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") +
                    "' AND v.articulos_codigo IN (SELECT codigo FROM articulos WHERE aplicacomision=1) group by c.nombre;");
                comando = new MySqlCommand(cmd, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    for (int i = 0; i < tblComisiones.Rows.Count; i++)
                    {
                        if (tblComisiones[0, i].Value.ToString() == lector.GetString(0))
                        {
                            tblComisiones[3, i].Value = lector.GetDouble(1);
                        }
                    }
                    Totales += lector.GetDouble(1);
                    tblComisiones[3, tblComisiones.Rows.Count - 1].Value = Totales;
                }
                conectar.Close();

                //Total Consignacion
                Totales = 0;
                cmd = string.Format("SELECT c.nombre, sum(v.importe) from ventas v, categorias c where v.tipo_compra='consignacion'"+
                    " and c.idcategorias=v.categorias_idcategorias and " + vendedor + "v.fecha_venta between  '" + 
                    dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") +
                    "' AND v.articulos_codigo IN (SELECT codigo FROM articulos WHERE aplicacomision=1) group by c.nombre;");
                comando = new MySqlCommand(cmd, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    for (int i = 0; i < tblComisiones.Rows.Count; i++)
                    {
                        if (tblComisiones[0, i].Value.ToString() == lector.GetString(0))
                        {
                            tblComisiones[4, i].Value = lector.GetDouble(1);
                        }
                    }
                    Totales += lector.GetDouble(1);
                    tblComisiones[4, tblComisiones.Rows.Count - 1].Value = Totales;
                }
                conectar.Close();

                //Total Abonos
                Totales = 0;
                cmd = string.Format("select c.nombre, a.abono, a.folio  from abonos a, categorias c, ventas v where "+
                    "" + vendedor + "a.ventas_idventas=v.idventas and v.categorias_idcategorias=c.idcategorias " +
                    "and a.fecha between '" + dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" +
                    dtpFin.Value.ToString("yyyyMMdd235959") + "' AND v.articulos_codigo IN "+
                    "(SELECT codigo FROM articulos WHERE aplicacomision=1)");
                comando = new MySqlCommand(cmd, conectar);
                conectar.Open();
                //DataTable Tabla23= new DataTable();
                //Tabla23.Load(comando.ExecuteReader());
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    DataTable Tabla2 = new DataTable();
                    Conexion.Conectarse();
                    Conexion.Ejecutar("SELECT iva FROM ventas WHERE folio="+lector.GetString(2),ref Tabla2);
                    Conexion.Desconectarse();
                    if(Tabla2.Rows.Count>0)
                    {                       
                        if(Convert.ToDouble(Tabla2.Rows[0][0])>0)
                        {
                            for (int i = 0; i < tblComisiones.Rows.Count; i++)
                            {
                                if (tblComisiones[0, i].Value.ToString() == lector.GetString(0))
                                {
                                    double abonoo = lector.GetDouble(1);
                                    tblComisiones[5, i].Value = Convert.ToDouble(tblComisiones[5, i].Value)+ (lector.GetDouble(1)/1.16);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < tblComisiones.Rows.Count; i++)
                            {
                                if (tblComisiones[0, i].Value.ToString() == lector.GetString(0))
                                {
                                    double abonoo = lector.GetDouble(1);
                                    tblComisiones[5, i].Value = Convert.ToDouble(tblComisiones[5, i].Value) + (lector.GetDouble(1));
                                }
                            }
                        }
                    }
                    Totales = 0;
                    for (int i = 0; i < tblComisiones.Rows.Count-1; i++)
                    {
                        Totales += Convert.ToDouble(tblComisiones[5, i].Value);
                    }
                    
                    tblComisiones[5, tblComisiones.Rows.Count - 1].Value = Totales;
                }
                conectar.Close();
                //Total efectivo
                Totales = 0;
                totalComision = 0;
                for (int i = 0; i < tblComisiones.Rows.Count - 1; i++)
                {
                    tblComisiones[6, i].Value = Convert.ToDouble(tblComisiones[2, i].Value) + Convert.ToDouble(tblComisiones[4, i].Value)+ Convert.ToDouble(tblComisiones[5, i].Value);
                    tblComisiones[7, i].Value = Convert.ToDouble(tblComisiones[6, i].Value) * (Convert.ToDouble(tblComisiones[8, i].Value)/100);
                    Totales += Convert.ToDouble(tblComisiones[6, i].Value);
                    totalComision += Convert.ToDouble(tblComisiones[7, i].Value);
                }
                tblComisiones[6, tblComisiones.Rows.Count - 1].Value = Totales;
                tblComisiones[7, tblComisiones.Rows.Count - 1].Value = totalComision;
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(tblComisiones);
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

                oSheet.Cells[1, 2] = "REPORTE DE PRENOMINA";
                oSheet.get_Range("A1", "I1").Merge(true);
                oSheet.get_Range("A1", "I1").Font.Bold = true;
                oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "I1").Font.Size = 18;
                //vENDEDOR
                oSheet.Cells[3, 1] = tbxNVendedor.Text;
                oSheet.get_Range("A1", "E1").Font.Size = 14;
                for (int i = 0; i < dgvConsulta.ColumnCount; i++)
                {
                    oSheet.Cells[4, i + 1] = dgvConsulta.Columns[i].HeaderText;
                }
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A4", "I4").Font.Bold = true;
                oSheet.get_Range("A4", "I4").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A4", "I4").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;
                // Create an array to multiple values at once.
                int fila = dgvConsulta.Rows.Count;
                int colum = dgvConsulta.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        oSheet.Cells[i + 5, j + 1] = dgvConsulta[j, i].Value.ToString();
                    }
                }
                //Fill A2:B6 with an array of values (First and Last Names).
                //oSheet.get_Range("A2", "D6").Value2 = saNames;
                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                // oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";
                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                oRng = oSheet.get_Range("B:H");
                oRng.NumberFormat = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \" - \"??_-;_-@_-";
                //oRng.Formula = "=RAND()*100000";
                //oRng = oSheet.get_Range("H:I");
                //oRng.NumberFormat = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \" - \"??_-;_-@_-";
                //AutoFit columns A:D
                oRng = oSheet.get_Range("A1", "I1");
                //oRng.EntireColumn.AutoFit();
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
            if (tblComisiones.Rows.Count > 0)
            {
                (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1.5;
                printPreviewDialog1.ShowDialog();
            }
        }
        int col1, col2, col3, col4, col5, col6, col7, col8, col9, y, i = 0, x, L;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
              if (tblComisiones.Rows.Count > 0)
            {
                int height = 0;
                int al = 15;
                int t = 300;
                int an = 10;
                //int width = 0;
                x = 70;
                y = 145;
                L = x+10;
                Font letra = new Font("Arial", 8);

                col1 = tblComisiones.Columns[0].Width-an;
                col2 = tblComisiones.Columns[1].Width-an;
                col3 = tblComisiones.Columns[2].Width-an;
                col4 = tblComisiones.Columns[3].Width - an;
                col5 = tblComisiones.Columns[4].Width - an;
                col6 = tblComisiones.Columns[5].Width - an;
                col7 = tblComisiones.Columns[6].Width - an;
                col8 = tblComisiones.Columns[7].Width - an;
                col9 = tblComisiones.Columns[8].Width - an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(100, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("REPORTE DE COMISIONES", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, tblComisiones.Rows[0].Height + 15));
                #endregion

                #region NombreVendedor
                e.Graphics.DrawString("Vendedor: " + tbxNVendedor.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 105, 500, tblComisiones.Rows[0].Height + 15));
                #endregion
                #region Puesto
                e.Graphics.DrawString("Puesto: " + tbxPuesto.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 120, 500, tblComisiones.Rows[0].Height + 15));
                #endregion

                #region fecha
                e.Graphics.DrawString(dtpInicio.Value.ToString("dd/MMMM/yyyy")+" - "+dtpFin.Value.ToString("dd/MMMM/yyyy"), new Font("Arial", 10), Brushes.Black, new Rectangle(x, 90, 500, tblComisiones.Rows[0].Height + 15));
                #endregion

                #region Categoria

                Pen p = new Pen(Brushes.Black, 1.5f);

                //           e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60, 100, col1, tblComisiones.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, tblComisiones.Rows[0].Height+al));
                e.Graphics.DrawString(tblComisiones.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, tblComisiones.Rows[0].Height+al));

                #endregion

                #region TotalVenta

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1, 100, col2 + 100, tblComisiones.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, tblComisiones.Rows[0].Height+al));
                e.Graphics.DrawString(tblComisiones.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, tblComisiones.Rows[0].Height+al));

                #endregion

                #region totalContado
                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2, 100, col3, tblComisiones.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, tblComisiones.Rows[0].Height+al));
                e.Graphics.DrawString(tblComisiones.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, tblComisiones.Rows[0].Height+al));


                #endregion

                #region TotalCredito

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, tblComisiones.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, tblComisiones.Rows[0].Height + al));
                e.Graphics.DrawString(tblComisiones.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, tblComisiones.Rows[0].Height + al));

                #endregion
                #region consignacion

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, tblComisiones.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblComisiones.Rows[0].Height + al));
                e.Graphics.DrawString(tblComisiones.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblComisiones.Rows[0].Height + al));

                #endregion
                #region abonos

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, tblComisiones.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblComisiones.Rows[0].Height + al));
                e.Graphics.DrawString(tblComisiones.Columns[5].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblComisiones.Rows[0].Height + al));

                #endregion
                #region TotalEfectivo

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, tblComisiones.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, tblComisiones.Rows[0].Height + al));
                e.Graphics.DrawString(tblComisiones.Columns[6].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, tblComisiones.Rows[0].Height + al));

                #endregion
                #region comision

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, tblComisiones.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, tblComisiones.Rows[0].Height + al));
                e.Graphics.DrawString(tblComisiones.Columns[7].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, tblComisiones.Rows[0].Height + al));

                #endregion
                #region Porcentaje

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, tblComisiones.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7 + col8, y, col9, tblComisiones.Rows[0].Height + al));
                e.Graphics.DrawString(tblComisiones.Columns[8].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7 + col8, y, col9, tblComisiones.Rows[0].Height + al));

                #endregion
                  
                height = 160;

                while (i < tblComisiones.Rows.Count)
                {
                    if (height > e.MarginBounds.Height+100)
                    {
                        height = 160;
                        e.HasMorePages = true;
                        return;
                    }


                    height += tblComisiones.Rows[0].Height;

                    //                     e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblComisiones.Columns[1].Width, tblComisiones.Rows[0].Height));
                    e.Graphics.DrawString(tblComisiones.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, tblComisiones.Columns[0].Width, tblComisiones.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + tblComisiones.Columns[1].Width, height, tblComisiones.Columns[2].Width, tblComisiones.Rows[0].Height));
                    e.Graphics.DrawString(tblComisiones.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, tblComisiones.Columns[1].Width, tblComisiones.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblComisiones.Columns[1].Width, height, tblComisiones.Columns[3].Width, tblComisiones.Rows[0].Height));
                    e.Graphics.DrawString(tblComisiones.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, tblComisiones.Columns[2].Width, tblComisiones.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblComisiones.Columns[1].Width, height, tblComisiones.Columns[4].Width, tblComisiones.Rows[0].Height));
                    e.Graphics.DrawString(tblComisiones.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblComisiones.Columns[3].Width, tblComisiones.Rows[0].Height));
                    //                     e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblComisiones.Columns[1].Width, tblComisiones.Rows[0].Height));
                    e.Graphics.DrawString(tblComisiones.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblComisiones.Columns[4].Width, tblComisiones.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + tblComisiones.Columns[1].Width, height, tblComisiones.Columns[2].Width, tblComisiones.Rows[0].Height));
                    e.Graphics.DrawString(tblComisiones.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, tblComisiones.Columns[5].Width, tblComisiones.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblComisiones.Columns[1].Width, height, tblComisiones.Columns[3].Width, tblComisiones.Rows[0].Height));
                    e.Graphics.DrawString(tblComisiones.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, tblComisiones.Columns[6].Width, tblComisiones.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblComisiones.Columns[1].Width, height, tblComisiones.Columns[4].Width, tblComisiones.Rows[0].Height));
                    e.Graphics.DrawString(tblComisiones.Rows[i].Cells[7].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7, height, tblComisiones.Columns[7].Width, tblComisiones.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblComisiones.Columns[1].Width, height, tblComisiones.Columns[4].Width, tblComisiones.Rows[0].Height));
                    e.Graphics.DrawString(tblComisiones.Rows[i].Cells[8].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7 + col8, height, tblComisiones.Columns[8].Width, tblComisiones.Rows[0].Height));

                    i++;
                }

                #region lineafirma
                e.Graphics.DrawString("______________________________________________", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 16 * 7, height + 100, 500, tblComisiones.Rows[0].Height + 15));
                #endregion
                #region firma
                e.Graphics.DrawString("FIRMA DE RECIBIDO", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 20 * 12, height + 120, 200, tblComisiones.Rows[0].Height + 15));
                #endregion
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tblComisiones.Rows.Clear();
            tbxVendedor.Clear();
            tbxNVendedor.Clear();

        }
    }
}
