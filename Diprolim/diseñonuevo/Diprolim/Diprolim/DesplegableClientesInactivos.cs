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
    public partial class DesplegableClientesInactivos : Form
    {
        Inventarios.DBMS_Unico Conexion;
        public string sIDCliente;
        public DesplegableClientesInactivos(Inventarios.DBMS_Unico servidor)
        {
            InitializeComponent();
            Conexion = servidor;
            
        }

        private void DesplegableClientesInactivos_Load(object sender, EventArgs e)
        {
            ObtnerCliente();
            DataTable TablaC = new DataTable();
            Conexion.Conectarse();
            Conexion.Ejecutar("SELECT * FROM articulos order by codigo asc", ref TablaC);
            Conexion.Desconectarse();
            DataTable Tabla = new DataTable();
            if (TablaC.Rows.Count > 0)
            {
                for (int i = 0; i < TablaC.Rows.Count; i++)
                {
                    //a.descripcion, a.valor_medida, um.nombre,a.cantidad," + Categori + ", a.precioproduccion, a.departamento, a.Descuento " +
                               // "from articulos a, unidad_medida um where a.unidad_medida_id=um.id and codigo="
                    Conexion.Conectarse();
                    Conexion.Ejecutar("SELECT MAX(v.idventas),v.articulos_codigo,a.descripcion, a.valor_medida, um.nombre,Max(v.fecha_venta) FROM ventas v, clientes c , articulos a, unidad_medida um where a.unidad_medida_id=um.id AND  v.clientes_idclientes=c.idclientes AND v.articulos_codigo=a.codigo AND v.clientes_idclientes=" + sIDCliente + " AND v.articulos_codigo=" + TablaC.Rows[i][0].ToString(), ref Tabla);
                    Conexion.Desconectarse();
                    if (Tabla.Rows.Count > 0)
                    {
                        if (Tabla.Rows[0][0].ToString() != "")
                        {
                            dtgCrTabla.Rows.Add(Tabla.Rows[0][1].ToString(), Tabla.Rows[0][2].ToString() + " " + Tabla.Rows[0][3].ToString() + " " + Tabla.Rows[0][4].ToString(), Tabla.Rows[0][5].ToString());
                                Tabla.Rows.Clear();
                        }
                    }

                }
            }
        }
        public void ObtnerCliente()
        {

            DataTable Tabla = new DataTable();
           
            Conexion.Conectarse();
            if (Conexion.Ejecutar("select idclientes,nombre,localidad,calle,telefono from clientes where idclientes=" + sIDCliente, ref Tabla))
            {
                if (Tabla.Rows.Count > 0)
                {
                    lblCliente.Text ="Cliente: "+ Tabla.Rows[0][1].ToString();
                    lblDireccion.Text = "Dirección: " + Tabla.Rows[0][3].ToString() + ", " + Tabla.Rows[0][2].ToString() + ", Teléfono: " + Tabla.Rows[0][4].ToString();
                }
                else
                {
                    MessageBox.Show("Código de cliente no existente");
                }
            }
            Conexion.Desconectarse();
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

                oSheet.Cells[1, 2] = "DETALLE DE "+lblCliente.Text;
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
                int Codigo = Convert.ToInt32(dtgCrTabla[0, i].Value);
                string Descripcion = dtgCrTabla[1, i].Value.ToString();
                DateTime fecha = Convert.ToDateTime(dtgCrTabla[2, i].Value);
               

                string comando = "INSERT INTO detallerclientesinactivos values(" + Codigo + ",'" + Descripcion + "','" + fecha.ToString("dd/mm/yyyy") + "')";
                if (Conexion.Ejecutar(comando))
                {
                    Pase = true;
                }
            }
            Conexion.FinalizarTransaccion(Pase);
            Conexion.Desconectarse();

            Conexion.Conectarse();
            Conexion.Ejecutar("SELECT * FROM detallerclientesinactivos", ref Tabla);
            Conexion.Ejecutar("delete from detallerclientesinactivos");
            Conexion.Desconectarse();

            DRCI Reporte = new DRCI();

            Reporte.sNCliente = lblCliente.Text;
            Reporte.sDireccion = lblDireccion.Text;
            Reporte.Tabla = Tabla;


            using (ReportPrintTool printTool = new ReportPrintTool(Reporte))
            {
                printTool.ShowRibbonPreviewDialog();
                printTool.ShowRibbonPreview(UserLookAndFeel.Default);
            }
        }
    }
}
