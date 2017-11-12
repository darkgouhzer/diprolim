using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;
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
    public partial class Clientes_inactivos : Form
    {
        Inventarios.DBMS_Unico Conexion;
        public Clientes_inactivos(Inventarios.DBMS_Unico server)
        {
            InitializeComponent();
            Conexion = server;
            cbxDias.SelectedIndex = 0;
        }
        public void MetodoVendedor()
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
            else
            {
                tbxCrCliente.Focus();
            }
        }
        public string obtenerVendedor(string vendedor)
        {
            string resultado = "";
            DataTable Tabla = new DataTable();
            Conexion.Conectarse();
            if(Conexion.Ejecutar("Select nombre, apellido_paterno, apellido_materno from empleados where id_empleado=" + vendedor, ref Tabla))
            {
                if(Tabla.Rows.Count>0)
                {
                    resultado=Tabla.Rows[0][0].ToString()+" "+Tabla.Rows[0][1].ToString()+" "+Tabla.Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("Código de vendedor no existente");
                }
            }
            Conexion.Desconectarse();
            return resultado;
        }

        private void tbxCrVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoVendedor();
            }
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

        private void tbxCrVendedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
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
                    tbxCrCliente.Focus();

                }
                else
                {
                    tbxCrVendedor.ReadOnly = false;
                    btnSCrV.Enabled = true;
                    tbxCrCliente.Focus();
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
            cbxDias.SelectedIndex = 0;
            
        }

        private void btnCrRCliente_Click(object sender, EventArgs e)
        {
            tbxCrCliente.Clear();
            tbxNCrCliente.Clear();
            btnSPCrC.Enabled = true;
            tbxCrCliente.ReadOnly = false;
            dtgCrTabla.Rows.Clear();
            cbxDias.SelectedIndex = 0;
            
        }

       
        private void tbxCrCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxCrCliente.Text.Length > 0)
                {
                    ObtnerCliente(tbxCrCliente.Text);
                    btnReporteCr.Focus();
                    if (tbxNCrCliente.Text == "")
                    {
                        tbxCrCliente.Focus();
                    }
                }
                else
                {
                    btnReporteCr.Focus();
                }
            }
        }
        public void ObtnerCliente(string cliente)
        {
           
            DataTable Tabla = new DataTable();
            Boolean existe = false;
            Conexion.Conectarse();
            if(Conexion.Ejecutar("select idclientes,nombre,empleados_id_empleado from clientes where idclientes=" + cliente,ref Tabla))
            {
                if(Tabla.Rows.Count>0)
                {
                    tbxNCrCliente.Text=Tabla.Rows[0][1].ToString();
                }
                else
                {
                    MessageBox.Show("Código de cliente no existente");
                }
            }
            Conexion.Desconectarse();
           

          
                   
            
        }

        private void btnSPCrC_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes(tbxCrVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCrCliente.Text = id.regresar.valXn;
                ObtnerCliente(tbxCrCliente.Text);
                tbxNCrCliente.ReadOnly = true;
                btnSPCrC.Enabled = false;
            }
            btnReporteCr.Focus();
        }

        private void tbxCrCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                BuscarClientes id = new BuscarClientes(tbxCrVendedor.Text);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCrCliente.Text = id.regresar.valXn;
                    ObtnerCliente(tbxCrCliente.Text);
                    tbxNCrCliente.ReadOnly = true;
                    btnSPCrC.Enabled = false;
                }
                btnReporteCr.Focus();
            }
        }

        private void btnReporteCr_Click(object sender, EventArgs e)
        {
            //try
            //{
            string vendCliente = "";
            dtgCrTabla.Rows.Clear();
            if (tbxCrCliente.Text.Length > 0 && tbxCrVendedor.Text.Length > 0)
            {
                DataTable Tabla = new DataTable();
                vendCliente = " AND v.empleados_id_empleado=" + tbxCrVendedor.Text + " and v.clientes_idclientes=" + tbxCrCliente.Text;
                
                Conexion.Conectarse();
                Conexion.Ejecutar("SELECT MAX(v.idventas),v.clientes_idclientes,c.nombre,Max(v.fecha_venta) FROM ventas v, clientes c where v.clientes_idclientes=c.idclientes  " + vendCliente, ref Tabla);
                Conexion.Desconectarse();
                if (Tabla.Rows.Count > 0)
                {
                    if (Tabla.Rows[0][0].ToString() != "")
                    {
                        if (cbxDias.Text == "Todos")
                        {
                            double ts;
                            DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);
                            ts = DateTime.Now.Day - fecha.Day;
                            string[] C = ts.ToString().Split('.');
                            dtgCrTabla.Rows.Add( Tabla.Rows[0][1].ToString(), Tabla.Rows[0][2].ToString(), Tabla.Rows[0][3].ToString(),C[0]);
                            Tabla.Rows.Clear();

                        }
                        else if (cbxDias.Text == "Días mayor que")
                        {
                            
                           // DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);
                           

                            TimeSpan ts;
                            DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);
                            ts = DateTime.Now.AddDays(1) - Convert.ToDateTime(Tabla.Rows[0][3]);
                            string[] C = ts.ToString().Split('.');
                            if (tbxDias.Text == "")
                            {
                                tbxDias.Text = "0";
                            }
                            if (ts.Days > Convert.ToInt32(tbxDias.Text) + 1)
                            {
                                dtgCrTabla.Rows.Add(Tabla.Rows[0][1].ToString(), Tabla.Rows[0][2].ToString(), Tabla.Rows[0][3].ToString(), C[0]);

                            }

                        }
                       
                    }
                }
            }
            else if (tbxCrVendedor.Text.Length > 0 && tbxCrCliente.Text == "")
            {
                vendCliente = " AND v.empleados_id_empleado=" + tbxCrVendedor.Text;
                DataTable TablaC = new DataTable();
                Conexion.Conectarse();
                Conexion.Ejecutar("SELECT idclientes FROM clientes WHERE empleados_id_empleado="+tbxCrVendedor.Text +" order by idclientes asc", ref TablaC);
                Conexion.Desconectarse();
                DataTable Tabla = new DataTable();
                if (TablaC.Rows.Count > 0)
                {
                    for (int i = 0; i < TablaC.Rows.Count; i++)
                    {
                        Conexion.Conectarse();
                        Conexion.Ejecutar("SELECT MAX(v.idventas),v.clientes_idclientes,c.nombre,Max(v.fecha_venta) FROM ventas v, clientes c where v.clientes_idclientes=c.idclientes  AND v.clientes_idclientes=" + TablaC.Rows[i][0].ToString(), ref Tabla);
                        Conexion.Desconectarse();
                        if (Tabla.Rows.Count > 0)
                        {
                            if (Tabla.Rows[0][0].ToString() != "")
                            {
                                if (cbxDias.Text == "Todos")
                                {
                                    double ts;
                                    DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);
                                    ts = DateTime.Now.Day - fecha.Day;
                                    string[] C = ts.ToString().Split('.');
                                    dtgCrTabla.Rows.Add(Tabla.Rows[0][1].ToString(), Tabla.Rows[0][2].ToString(), Tabla.Rows[0][3].ToString(), C[0]);
                                    Tabla.Rows.Clear();

                                }
                                else if (cbxDias.Text == "Días mayor que")
                                {

                                    TimeSpan ts;
                                    DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);
                                    ts = DateTime.Now.AddDays(1) - Convert.ToDateTime(Tabla.Rows[0][3]);
                                    string[] C = ts.ToString().Split('.');
                                    if (tbxDias.Text == "")
                                    {
                                        tbxDias.Text = "0";
                                    }
                                    if (ts.Days > Convert.ToInt32(tbxDias.Text) + 1)
                                    {
                                        dtgCrTabla.Rows.Add(Tabla.Rows[0][1].ToString(), Tabla.Rows[0][2].ToString(), Tabla.Rows[0][3].ToString(), C[0]);
                                    }

                                }
                               
                            }
                        }

                    }
                }
            }

            if (tbxCrVendedor.Text.Length == 0 && tbxCrCliente.Text == "")
            {

                DataTable TablaC = new DataTable();
                Conexion.Conectarse();
                Conexion.Ejecutar("SELECT idclientes FROM clientes order by idclientes asc", ref TablaC);
                Conexion.Desconectarse();
                DataTable Tabla = new DataTable();
                if (TablaC.Rows.Count > 0)
                {
                    for (int i = 0; i < TablaC.Rows.Count; i++)
                    {
                        Conexion.Conectarse();
                        Conexion.Ejecutar("SELECT MAX(v.idventas),v.clientes_idclientes,c.nombre,Max(v.fecha_venta) FROM ventas v, clientes c where v.clientes_idclientes=c.idclientes  AND v.clientes_idclientes=" + TablaC.Rows[i][0].ToString(), ref Tabla);
                        Conexion.Desconectarse();
                        if (Tabla.Rows.Count > 0)
                        {
                            if (Tabla.Rows[0][0].ToString() != "")
                            {

                                if (cbxDias.Text == "Todos")
                                {
                                    double ts;
                                    DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);
                                    ts = DateTime.Now.Day - fecha.Day;
                                    string[] C = ts.ToString().Split('.');
                                    dtgCrTabla.Rows.Add(Tabla.Rows[0][1].ToString(), Tabla.Rows[0][2].ToString(), Tabla.Rows[0][3].ToString(), C[0]);
                                    Tabla.Rows.Clear();

                                }
                                else if (cbxDias.Text == "Días mayor que")
                                {

                                    TimeSpan ts;
                                    DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);
                                    ts = DateTime.Now.AddDays(1) - Convert.ToDateTime(Tabla.Rows[0][3]);
                                    string[] C = ts.ToString().Split('.');
                                    if (tbxDias.Text == "")
                                    {
                                        tbxDias.Text = "0";
                                    }
                                    if (ts.Days > Convert.ToInt32(tbxDias.Text) + 1)
                                    {
                                        dtgCrTabla.Rows.Add(Tabla.Rows[0][1].ToString(), Tabla.Rows[0][2].ToString(), Tabla.Rows[0][3].ToString(), C[0]);
                                    }

                                }
                                
                            }
                        }

                    }
                }
            }

           
            
            
        }

        private void dtgCrTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                if (dtgCrTabla.CurrentRow.Index <= dtgCrTabla.Rows.Count - 1)
                {
                    DesplegableClientesInactivos detalleClientes = new DesplegableClientesInactivos(Conexion);
                    detalleClientes.sIDCliente = dtgCrTabla[0, dtgCrTabla.CurrentRow.Index].Value.ToString();
                    detalleClientes.ShowDialog();
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

        private void tbxDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbxDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxDias.Text=="Todos")
            {
                tbxDias.ReadOnly = true;
            }
            else
            {
                tbxDias.ReadOnly = false;
            }
        }

        private void btnExcelCr_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(dtgCrTabla);
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
                
                    oSheet.Cells[1, 2] = "REPORTE DE CLIENTES INACTIVOS";
                    oSheet.get_Range("A1", "G1").Merge(true);
                    oSheet.get_Range("A1", "G1").Font.Bold = true;
                    oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", "G1").Font.Size = 14;
               

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
                for (int i = 0; i < dgvConsulta.Columns.Count; i++)
                {
                    oSheet.Cells[2, i + 1] = dgvConsulta.Columns[i].HeaderText;

                }
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

        private void btnImprimirCr_Click(object sender, EventArgs e)
        {
            DataTable Tabla = new DataTable();
            Conexion.Conectarse();
            Conexion.IniciarTransaccion();
            Boolean Pase = false;
            for (int i = 0; i < dtgCrTabla.Rows.Count; i++)
            {
                int ClienteID = Convert.ToInt32(dtgCrTabla[0, i].Value);
                string Nombre = dtgCrTabla[1, i].Value.ToString(); 
                DateTime fecha = Convert.ToDateTime(dtgCrTabla[2, i].Value);
                string Diast = dtgCrTabla[3, i].Value.ToString(); 

                string comando = "INSERT INTO rclientesinactivos values(" + ClienteID + ",'" + Nombre + "','" + fecha.ToString("dd/mm/yyyy") + "','"+Diast+"')";
                if (Conexion.Ejecutar(comando))
                {
                    Pase = true;
                }
            }
            Conexion.FinalizarTransaccion(Pase);
            Conexion.Desconectarse();

            Conexion.Conectarse();
            Conexion.Ejecutar("SELECT * FROM rclientesinactivos", ref Tabla);
            Conexion.Ejecutar("delete from rclientesinactivos");
            Conexion.Desconectarse();

            RCI Reporte = new RCI();

            Reporte.sCodigoVendedor = tbxCrVendedor.Text;
            Reporte.sNVendedor = tbxNCrVendedor.Text;
            Reporte.Tabla = Tabla;
           
            
            using (ReportPrintTool printTool = new ReportPrintTool(Reporte))
            {
                printTool.ShowRibbonPreviewDialog();
                printTool.ShowRibbonPreview(UserLookAndFeel.Default);
            }
        }
    

    }
}
