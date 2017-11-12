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
    public partial class DesplegableReporteConsignacion : Form
    {

        UnicaSQL.DBMS_Unico Conexion;
        public String sPalabra="";
        public Int32 Diass=0;
        public string sIDCliente="";
        public string sNombreCliente = "";
        public DateTime FechaaV;

        public DesplegableReporteConsignacion(UnicaSQL.DBMS_Unico server)
        {
            InitializeComponent();

            Conexion = server;
        }
        private void DesplegableReporteConsignacion_Load(object sender, EventArgs e)
        {

            lblCliente.Text ="Cliente: "+ sNombreCliente;
            DataTable Tabla = new DataTable();
            Conexion.Conectarse();
            Conexion.Ejecutar("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre," +
                          " i.cantidad,i.precio,a.comision,i.fecha From articulos a, unidad_medida u, inv_clientes i" +
                          " WHERE  i.cantidad>0 and i.fecha BETWEEN '" +
                FechaaV.ToString("yyyyMMdd000000") + "' AND '" + FechaaV.ToString("yyyyMMdd235959") + "' AND  clientes_idclientes=" + sIDCliente +
                          " and i.articulos_codigo=a.codigo AND a.unidad_medida_id = u.id" +
                          " order by i.fecha asc", ref Tabla);
            Conexion.Desconectarse();
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {

                    if (sPalabra == "Días mayor que")
                    {

                        // DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);

                        TimeSpan ts;
                        DateTime fecha = Convert.ToDateTime(Tabla.Rows[i][7]);
                        ts = DateTime.Now.AddDays(1) - fecha;



                        if (ts.Days > (Diass + 1))
                        {
                            dtgConsignacion.Rows.Add(Tabla.Rows[i][0].ToString(), Tabla.Rows[i][1].ToString() + " " + Tabla.Rows[i][2].ToString() + " " + Tabla.Rows[i][3].ToString(), Convert.ToDouble(Tabla.Rows[i][4].ToString()), Convert.ToDouble(Tabla.Rows[i][5].ToString()), Convert.ToDouble(Tabla.Rows[i][4].ToString()) * Convert.ToDouble(Tabla.Rows[i][5].ToString()), (((Convert.ToDouble(Tabla.Rows[i][4].ToString()) * Convert.ToDouble(Tabla.Rows[i][5].ToString()))) * (Convert.ToDouble(Tabla.Rows[i][6].ToString()) / 100)), (Convert.ToDouble(Tabla.Rows[i][4].ToString()) * Convert.ToDouble(Tabla.Rows[i][5].ToString())) - (((Convert.ToDouble(Tabla.Rows[i][4].ToString()) * Convert.ToDouble(Tabla.Rows[i][5].ToString())) * (Convert.ToDouble(Tabla.Rows[i][6].ToString()) / 100))), Convert.ToDateTime(Tabla.Rows[i][7]).ToString("dd/MM/yyyy"), ts.Days);

                        }
                        
                    }
                    else if (sPalabra == "Días menor que")
                    {

                        // DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);

                        TimeSpan ts;
                        DateTime fecha = Convert.ToDateTime(Tabla.Rows[i][7]);
                        ts = DateTime.Now.AddDays(1) - fecha;

                        if (ts.Days < (Diass + 1))
                        {
                            dtgConsignacion.Rows.Add(Tabla.Rows[i][0].ToString(), Tabla.Rows[i][1].ToString() + " " + Tabla.Rows[i][2].ToString() + " " + Tabla.Rows[i][3].ToString(), Convert.ToDouble(Tabla.Rows[i][4].ToString()), Convert.ToDouble(Tabla.Rows[i][5].ToString()), Convert.ToDouble(Tabla.Rows[i][4].ToString()) * Convert.ToDouble(Tabla.Rows[i][5].ToString()), (((Convert.ToDouble(Tabla.Rows[i][4].ToString()) * Convert.ToDouble(Tabla.Rows[i][5].ToString()))) * (Convert.ToDouble(Tabla.Rows[i][6].ToString()) / 100)), (Convert.ToDouble(Tabla.Rows[i][4].ToString()) * Convert.ToDouble(Tabla.Rows[i][5].ToString())) - (((Convert.ToDouble(Tabla.Rows[i][4].ToString()) * Convert.ToDouble(Tabla.Rows[i][5].ToString())) * (Convert.ToDouble(Tabla.Rows[i][6].ToString()) / 100))), Convert.ToDateTime(Tabla.Rows[i][7]).ToString("dd/MM/yyyy"), ts.Days);

                        }
                      
                    }
                }
            }



            if (dtgConsignacion.Rows.Count > 0)
            {
                double PrecioTotal=0, Comision=0, Pendientee=0;
                for (int i = 0; i < dtgConsignacion.Rows.Count; i++)
                {
                    PrecioTotal += Convert.ToDouble(dtgConsignacion[4, i].Value);
                    Comision += Convert.ToDouble(dtgConsignacion[5, i].Value);
                    Pendientee += Convert.ToDouble(dtgConsignacion[6, i].Value);
                }
                dtgConsignacion.Rows.Add(" ", " ", " ", "Totales", PrecioTotal, Comision, Pendientee, "", "");
            }
         
              
        }

        private void btnExcelCr_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(dtgConsignacion);
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
                for (int i = 0; i < dgvConsulta.ColumnCount; i++)
                {
                    oSheet.Cells[1, i + 1] = dgvConsulta.Columns[i].HeaderText;
                }
                //    oSheet.Cells[1, 1] = dgvConsulta.Columns[0].HeaderText;
                //oSheet.Cells[1, 2] = fecha.HeaderText;
                //oSheet.Cells[1, 3] = tblVendedor.HeaderText;
                //oSheet.Cells[1, 4] = tbltipoCliente.HeaderText;
                //oSheet.Cells[1, 5] = tblProducto.HeaderText;
                //oSheet.Cells[1, 6] = tblPrecio.HeaderText;
                //oSheet.Cells[1, 7] = tblCantidad.HeaderText;
                //oSheet.Cells[1, 8] = tblTotal.HeaderText;
                //oSheet.Cells[1, 9] = tblComision.HeaderText;
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "I1").Font.Bold = true;
                oSheet.get_Range("A1", "I1").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "I1").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;
                // Create an array to multiple values at once.
                int fila = dgvConsulta.Rows.Count;
                int colum = dgvConsulta.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        oSheet.Cells[i + 2, j + 1] = dgvConsulta[j, i].Value.ToString();
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

        private void btnImprimirCr_Click(object sender, EventArgs e)
        {

        }
    }
}
       