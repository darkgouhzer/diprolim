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
    public partial class Ingreso_de_Efectivo : Form
    {
        
        conexion conn = new conexion();
        MySqlCommand comando;
        MySqlConnection conectar;
        MySqlDataReader lector;
        public Ingreso_de_Efectivo()
        {
            InitializeComponent();
            cbxIm.SelectedIndex = 0;
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
        }

        private void btnReporteHistorial_Click(object sender, EventArgs e)
        {
            dtgIEfectivo.Rows.Clear();
            if (cbxIm.Text == "Todo")
            {
                Total = 0;
                if (rdbSucursal.Checked == true)
                {
                    BuscarEmpleados();
                }
                else if (rdbVendedor.Checked == true)
                {
                    if (tbxCodigo.Text != "")
                    {
                        BuscarEmpleadosporCodigo();
                    }
                    else
                    {
                        MessageBox.Show("Inserte código");
                    }
                }
                else if (rdbCLiente.Checked == true)
                {
                    
                    if (tbxCodigo.Text != "")
                    {
                        BuscarCantidadesenVentasPorClientes();
                    }
                    else
                    {
                        MessageBox.Show("Inserte código");
                    }
                }
            }
            else
            {
                Total = 0;
                if (rdbSucursal.Checked == true)
                {
                    BuscarEmpleados2();
                }
                else if (rdbVendedor.Checked == true)
                {
                    if (tbxCodigo.Text != "")
                    {
                        BuscarEmpleadosporCodigo2();
                    }
                    else
                    {
                        MessageBox.Show("Inserte código");
                    }
                }
                else if (rdbCLiente.Checked == true)
                {
                    BuscarCantidadesenVentasPorClientes2();
                }
            }
            
        }
        int Cod_Vendedor = 0;
        public void BuscarEmpleados()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from empleados", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cod_Vendedor = lector.GetInt32(0);

                    if (BuscarCantidadesenVentas2())
                    {
                        dtgIEfectivo.Rows.Add(Cod_Vendedor, lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), "Vendedor");
                        BuscarCantidadesenVentas();
                    }
            }
            dtgIEfectivo.Rows.Add("", "","$" + Total);
            conectar.Close();
        }
        public void BuscarEmpleados2()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from empleados", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cod_Vendedor = lector.GetInt32(0);
                
                    if (BuscarCantidadesenVentas2())
                    {
                            BuscarCantidadesenVentass2();
                            dtgIEfectivo.Rows.Add(Cod_Vendedor, lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), "$"+CCantidad);
                    }
                
            }
            dtgIEfectivo.Rows.Add("", "", "$" + Total);
            conectar.Close();
        }
        double CCantidad = 0;
        public void BuscarCantidadesenVentass2()
        {
            conectar = conn.ObtenerConexion();

            comando = new MySqlCommand("SELECT importe FROM ventas WHERE tipo_compra='contado' and empleados_id_empleado=" + Cod_Vendedor + " and fecha_venta BETWEEN '" +
            dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            CCantidad = 0;
            while (lector.Read())
            {
                CCantidad += lector.GetDouble(0);
            }
            conectar.Close();
            comando = new MySqlCommand("SELECT importe FROM ventas WHERE tipo_compra='consignacion' and empleados_id_empleado=" + Cod_Vendedor + " and fecha_venta BETWEEN '" +
           dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                CCantidad += lector.GetDouble(0);
            }
            conectar.Close();
            comando = new MySqlCommand("Select abono FROM  abonos  WHERE empleados_id_empleado=" + Cod_Vendedor + "  and fecha BETWEEN '" +
          dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            double RA1 = 0;
            while (lector.Read())
            {
                CCantidad += lector.GetDouble(0);
            }

            conectar.Close();

            comando = new MySqlCommand("Select abono FROM  cobranza  WHERE empleados_id_empleado=" + Cod_Vendedor + "  and fecha BETWEEN '" +
           dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                CCantidad += lector.GetDouble(0);
            }

            conectar.Close();
           // comando = new MySqlCommand("SELECT importe,pendiente FROM ventas WHERE tipo_compra='credito' and empleados_id_empleado=" + Cod_Vendedor + " and fecha_venta BETWEEN '" +
           //dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
           // conectar.Open();
           // lector = comando.ExecuteReader();

           // while (lector.Read())
           // {
           //     CCantidad += lector.GetDouble(0) - lector.GetDouble(1);
           // }
           // conectar.Close();
            Total += CCantidad;
            //dtgIEfectivo.Rows.Add(dtpInicio.Value.ToString("dd/MM/yy") + "-" + dtpFin.Value.ToString("dd/MM/yy"), "$" + Cantidad);
        }
        public void BuscarEmpleadosporCodigo()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from empleados where id_empleado="+tbxCodigo.Text, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cod_Vendedor = Convert.ToInt32(tbxCodigo.Text);
               
                    if (BuscarCantidadesenVentas2())
                    {
                        dtgIEfectivo.Rows.Add(Cod_Vendedor, lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), "Vendedor");
                        BuscarCantidadesenVentas();
                    }
            }
            conectar.Close();
        }
        public void BuscarEmpleadosporCodigo2()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from empleados where id_empleado=" + tbxCodigo.Text, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cod_Vendedor = Convert.ToInt32(tbxCodigo.Text);
                BuscarCantidadesenVentass2();
                dtgIEfectivo.Rows.Add(Cod_Vendedor, lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), "$"+CCantidad);
                    
            }
            
            conectar.Close();
        }
        public void BuscarCantidadesenVentas()
        {
            conectar = conn.ObtenerConexion();

            comando = new MySqlCommand("SELECT importe FROM ventas WHERE tipo_compra='contado' and empleados_id_empleado="+Cod_Vendedor+" and fecha_venta BETWEEN '" +
            dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            double Cantidad = 0;
            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }
            conectar.Close();
            comando = new MySqlCommand("SELECT importe FROM ventas WHERE tipo_compra='consignacion' and empleados_id_empleado=" + Cod_Vendedor + " and fecha_venta BETWEEN '" +
            dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }
            conectar.Close();
            comando = new MySqlCommand("Select abono FROM  abonos  WHERE empleados_id_empleado=" + Cod_Vendedor + "  and fecha BETWEEN '" +
           dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            double RA1 = 0;
            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }

            conectar.Close();

            comando = new MySqlCommand("Select abono FROM  cobranza  WHERE empleados_id_empleado=" + Cod_Vendedor + "  and fecha BETWEEN '" +
           dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }
           
            conectar.Close();
           // comando = new MySqlCommand("SELECT importe,pendiente FROM ventas WHERE tipo_compra='credito' and empleados_id_empleado=" + Cod_Vendedor + " and fecha_venta BETWEEN '" +
           //dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
           // conectar.Open();
           // lector = comando.ExecuteReader();

           // while (lector.Read())
           // {
           //     Cantidad += lector.GetDouble(0) - lector.GetDouble(1);
           // }
           // conectar.Close();
            Total += Cantidad;
            dtgIEfectivo.Rows.Add(dtpInicio.Value.ToString("dd/MM/yy")+"-"+dtpFin.Value.ToString("dd/MM/yy"), "$"+Cantidad,"");
        }
        double Total = 0;
        public void BuscarCantidadesenVentasPorClientes()
        {
            conectar = conn.ObtenerConexion();

            comando = new MySqlCommand("SELECT importe FROM ventas WHERE tipo_compra='contado' and clientes_idclientes=" + tbxCodigo.Text + " and fecha_venta BETWEEN '" +
            dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            double Cantidad = 0;
            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }
            conectar.Close();
            comando = new MySqlCommand("SELECT importe FROM ventas WHERE tipo_compra='consignacion' and clientes_idclientes=" + tbxCodigo.Text + " and fecha_venta BETWEEN '" +
           dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }
            conectar.Close();
            comando = new MySqlCommand("Select abono FROM  abonos  WHERE clientes_idclientes=" + tbxCodigo.Text + "  and fecha BETWEEN '" +
          dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            
            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }

            conectar.Close();

            comando = new MySqlCommand("Select abono FROM  cobranza  WHERE clientes_idclientes=" + tbxCodigo.Text + "  and fecha BETWEEN '" +
           dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }

            conectar.Close();
           // comando = new MySqlCommand("SELECT importe,pendiente FROM ventas WHERE tipo_compra='credito' and clientes_idclientes=" + tbxCodigo.Text + " and fecha_venta BETWEEN '" +
           //dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
           // conectar.Open();
           // lector = comando.ExecuteReader();

           // while (lector.Read())
           // {
           //     Cantidad += lector.GetDouble(0) - lector.GetDouble(1);
           // }
           // conectar.Close();
            dtgIEfectivo.Rows.Add(tbxCodigo.Text, tbxNombre.Text,"");
            dtgIEfectivo.Rows.Add(dtpInicio.Value.ToString("dd/MM/yy") + "-" + dtpFin.Value.ToString("dd/MM/yy"), "$" + Cantidad,"");
        }
        public void BuscarCantidadesenVentasPorClientes2()
        {
            conectar = conn.ObtenerConexion();

            comando = new MySqlCommand("SELECT importe FROM ventas WHERE tipo_compra='contado' and clientes_idclientes=" + tbxCodigo.Text + " and fecha_venta BETWEEN '" +
            dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            double Cantidad = 0;
            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }
            conectar.Close();
            comando = new MySqlCommand("SELECT importe FROM ventas WHERE tipo_compra='consignacion' and clientes_idclientes=" + tbxCodigo.Text + " and fecha_venta BETWEEN '" +
           dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }
            conectar.Close();
            comando = new MySqlCommand("Select abono FROM  abonos  WHERE clientes_idclientes=" + tbxCodigo.Text + "  and fecha BETWEEN '" +
          dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            double RA1 = 0;
            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }

            conectar.Close();

            comando = new MySqlCommand("Select abono FROM  cobranza  WHERE clientes_idclientes=" + tbxCodigo.Text + "  and fecha BETWEEN '" +
           dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }

            conectar.Close();
           // comando = new MySqlCommand("SELECT importe,pendiente FROM ventas WHERE tipo_compra='credito' and clientes_idclientes=" + tbxCodigo.Text + " and fecha_venta BETWEEN '" +
           //dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
           // conectar.Open();
           // lector = comando.ExecuteReader();

           // while (lector.Read())
           // {
           //     Cantidad += lector.GetDouble(0) - lector.GetDouble(1);
           // }
           // conectar.Close();
            dtgIEfectivo.Rows.Add(tbxCodigo.Text, tbxNombre.Text, "$" + Cantidad);
            //dtgIEfectivo.Rows.Add(dtpInicio.Value.ToString("dd/MM/yy") + "-" + dtpFin.Value.ToString("dd/MM/yy"), "$" + Cantidad);
        }
        Boolean BuscarCantidadesenVentas2()
        {
            conectar = conn.ObtenerConexion();

            comando = new MySqlCommand("SELECT importe FROM ventas WHERE tipo_compra='contado' and empleados_id_empleado=" + Cod_Vendedor + " and fecha_venta BETWEEN '" +
            dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            double Cantidad = 0;
            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0);
            }
            conectar.Close();
            comando = new MySqlCommand("SELECT importe,pendiente FROM ventas WHERE tipo_compra='credito' and empleados_id_empleado=" + Cod_Vendedor + " and fecha_venta BETWEEN '" +
           dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cantidad += lector.GetDouble(0) - lector.GetDouble(1);
            }
            conectar.Close();
            if(Cantidad>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void tbxCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxCodigo.Text != "")
                {
                    if (rdbVendedor.Checked == true)
                    {
                        obtenerVendedor();
                        if (tbxCodigo.Text != "")
                        {
                            btnReporteHistorial.Focus();
                        }
                    }
                    else if (rdbCLiente.Checked == true)
                    {
                        ObtnerCliente();
                        if (tbxCodigo.Text != "")
                        {
                            btnReporteHistorial.Focus();
                        }
                    }
                }
            }
        }
        public void ObtnerCliente()
        {
            if (tbxCodigo.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                //comando = new MySqlCommand("SELECT * FROM clientes WHERE idclientes =" + tbxCCliente.Text, conectar);
                comando = new MySqlCommand("SELECT * from clientes where idclientes=" + tbxCodigo.Text, conectar);

                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    des = lector.GetString(0);
                    tbxNombre.Text = lector.GetString(1);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código del cliente no existente");
                    tbxCodigo.Clear();
                    tbxNombre.Clear();

                }
            }
        }
        public void obtenerVendedor()
        {
            if (tbxCodigo.Text != "")
            {

                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + tbxCodigo.Text, conectar);
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
                    tbxCodigo.Text = "";
                    tbxNombre.Clear();

                }
            }
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            if (rdbVendedor.Checked == true)
            {
                BuscarVendedor id = new BuscarVendedor();
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCodigo.Text = id.regresar.valXn;
                }
                obtenerVendedor();
                btnReporteHistorial.Focus();
            }
            else if (rdbCLiente.Checked == true)
            {
                string S = "";
                BuscarClientes id = new BuscarClientes(S);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCodigo.Text = id.regresar.valXn;
                }
                ObtnerCliente();
                btnReporteHistorial.Focus();
            }
        }

        private void rdbVendedor_CheckedChanged(object sender, EventArgs e)
        {
            tbxCodigo.Clear();
            tbxNombre.Clear();
            dtgIEfectivo.Rows.Clear();
            tbxCodigo.ReadOnly = false;
        }

        private void rdbCLiente_CheckedChanged(object sender, EventArgs e)
        {
            tbxCodigo.Clear();
            tbxNombre.Clear();
            dtgIEfectivo.Rows.Clear();
            tbxCodigo.ReadOnly = false;
        }

        private void rdbSucursal_CheckedChanged(object sender, EventArgs e)
        {
            tbxCodigo.Clear();
            tbxNombre.Clear();
            dtgIEfectivo.Rows.Clear();
            tbxCodigo.ReadOnly = true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(dtgIEfectivo);
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

                oSheet.Cells[1, 2] = "REPORTE DE INGRESO DE EFECTIVO";
                oSheet.get_Range("A1", "C1").Merge(true);
                oSheet.get_Range("A1", "C1").Font.Bold = true;
                oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "C1").Font.Size = 14;
                
                for (int i = 0; i < dgvConsulta.ColumnCount; i++)
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
                // oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";
                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                //oRng = oSheet.get_Range("F:F");
                //oRng.NumberFormat = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \" - \"??_-;_-@_-";
                ////oRng.Formula = "=RAND()*100000";
                //oRng = oSheet.get_Range("H:I");
                //oRng.NumberFormat = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \" - \"??_-;_-@_-";
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
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.5;
            printPreviewDialog1.ShowDialog();
        }
        int col1, col2, col3, col4, col5, col6, col7, y, i = 0, x, L;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgIEfectivo.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width / 10 * 5;
                int an = 0;
                int al = 15;
                x = 150;
                y = 125;
                L = x + 5;
                Font letra = new Font("Arial", 9);
                col1 = dtgIEfectivo.Columns[0].Width - an;
                col2 = dtgIEfectivo.Columns[1].Width - an;
                col3 = dtgIEfectivo.Columns[2].Width - an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(120, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("INGRESO DE EFECTIVO", new Font("Arial", 13, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, dtgIEfectivo.Rows[0].Height + 15));
                #endregion
                string tiposeleccion = "";
                if (rdbCLiente.Checked)
                {
                    tiposeleccion = "Todo por: " + rdbCLiente.Text;
                }
                else if (rdbSucursal.Checked)
                {
                    tiposeleccion = "Todo por: " + rdbSucursal.Text;
                }
                else if (rdbVendedor.Checked)
                {
                    tiposeleccion = "Todo por: " + rdbVendedor.Text;
                }
                #region NombreVendedor
                e.Graphics.DrawString(tiposeleccion, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 95, 500, dtgIEfectivo.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgIEfectivo.Rows[0].Height + al));
                e.Graphics.DrawString(dtgIEfectivo.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, dtgIEfectivo.Rows[0].Height + al));

                #endregion

                #region fechaventa

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgIEfectivo.Rows[0].Height + al));
                e.Graphics.DrawString(dtgIEfectivo.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, dtgIEfectivo.Rows[0].Height + al));

                #endregion

                #region vendedor

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgIEfectivo.Rows[0].Height + al));
                e.Graphics.DrawString(dtgIEfectivo.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgIEfectivo.Rows[0].Height + al));
                
                #endregion

                height = 125 + al;

                while (i < dtgIEfectivo.Rows.Count)
                {
                    if (height > e.MarginBounds.Height + 100)
                    {
                        height = 125 + al;
                        e.HasMorePages = true;
                        return;
                    }


                    height += dtgIEfectivo.Rows[0].Height;

                    e.Graphics.DrawString(dtgIEfectivo.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, dtgIEfectivo.Columns[0].Width, dtgIEfectivo.Rows[0].Height));

                    e.Graphics.DrawString(dtgIEfectivo.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, dtgIEfectivo.Columns[1].Width, dtgIEfectivo.Rows[0].Height));

                    e.Graphics.DrawString(dtgIEfectivo.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgIEfectivo.Columns[2].Width, dtgIEfectivo.Rows[0].Height));
                                        
                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void tbxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }

    }
}
