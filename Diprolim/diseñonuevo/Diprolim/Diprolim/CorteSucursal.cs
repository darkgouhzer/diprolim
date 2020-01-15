using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReglasNegocios;

namespace Diprolim
{
    public partial class CorteSucursal : Form
    {
        conexion conn=new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        public CorteSucursal()
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            PrevisualizarCorteGeneral();
           
        }
        public void SumarDatosGrid()
        {
            try
            {
                List<DataGridViewRow> list = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in Tabla.Rows)
                {
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[8] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                        list.Add(row);
                }
                foreach (DataGridViewRow row in list)
                {
                    Tabla.Rows.Remove(row);
                }
                double ventasT = 0, gastosT = 0, fiadoT = 0, RecupT = 0, iva = 0,efectivoaentregar=0;
               
               if(Tabla.Rows.Count>0)
               {
                   for(int i=0;i<Tabla.Rows.Count;i++)
                   {
                       ventasT +=Convert.ToDouble( Tabla[1, i].Value);
                       iva += Convert.ToDouble(Tabla[2, i].Value);
                       RecupT += Convert.ToDouble(Tabla[3, i].Value);
                       fiadoT += Convert.ToDouble(Tabla[4, i].Value);
                       gastosT += Convert.ToDouble(Tabla[5, i].Value);
                       efectivoaentregar += Convert.ToDouble(Tabla[6, i].Value);
                   }
                   Tabla.Rows.Add("TOTAL", ventasT, iva, RecupT, fiadoT, gastosT, efectivoaentregar, "", true);
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
        private void btnImprimirCr_Click(object sender, EventArgs e)
        {
            LLenarDataGrid();
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        public void PrevisualizarCorteGeneral()
        {
            Tabla.Rows.Clear();
            DataTable tblCorteSucursal = new DataTable();
            CorteCajaBO objCorteCajaBO = new CorteCajaBO();
            tblCorteSucursal = objCorteCajaBO.PreGenerarCorteGeneral(dtpFecha.Value);
            foreach (DataRow row in tblCorteSucursal.Rows)
            {
                //row = row; c.empleados_id_empleado, e.nombre, c.Ventas_Totales, c.Recuperado, c.Fiado, c.Gastos, c.Concepto, 	c.EfectivoAEntregar, c.Fecha, c.Iva
                Tabla.Rows.Add(row["nombre"].ToString(), Convert.ToDouble(row["Ventas_Totales"]), Convert.ToDouble(row["Iva"]), Convert.ToDouble(row["Recuperado"]),
                               Convert.ToDouble(row["Fiado"]), Convert.ToDouble(row["Gastos"]), Convert.ToDouble(row["EfectivoAEntregar"]),
                               row["Concepto"].ToString(), false, Convert.ToInt32(row["empleados_id_empleado"]));
            }

            SumarDatosGrid();
        }
        public void LLenarDataGrid()
        {
            Tabla.Rows.Clear();
            DataTable tblCorteSucursal = new DataTable();
            CorteCajaBO objCorteCajaBO = new CorteCajaBO();
            tblCorteSucursal = objCorteCajaBO.GenerarCorteGeneral(dtpFecha.Value);
            foreach(DataRow row in tblCorteSucursal.Rows)
            {
                //row = row; c.empleados_id_empleado, e.nombre, c.Ventas_Totales, c.Recuperado, c.Fiado, c.Gastos, c.Concepto, 	c.EfectivoAEntregar, c.Fecha, c.Iva
                Tabla.Rows.Add(row["nombre"].ToString(), Convert.ToDouble(row["Ventas_Totales"]), Convert.ToDouble(row["Iva"]), Convert.ToDouble(row["Recuperado"]),
                               Convert.ToDouble(row["Fiado"]), Convert.ToDouble(row["Gastos"]), Convert.ToDouble(row["EfectivoAEntregar"]),
                               row["Concepto"].ToString(), false, Convert.ToInt32(row["empleados_id_empleado"]));
            }
           
            SumarDatosGrid();
        }
        double FiadoActual = 0, RecuperadoActual = 0, VentasTotales = 0, iva = 0;
    
        private void dtpFecha_Leave(object sender, EventArgs e)
        {
            LLenarDataGrid();
        }
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                LLenarDataGrid();
            }
        }

        private void Tabla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Tabla.CurrentCell.ColumnIndex == 5)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }
        }

        private void Tabla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int n = 0;
             try
            {
                n = 0;
                if (Tabla.Rows.Count > 0)
                {
                    for (int i = 0; i < Tabla[5, e.RowIndex].Value.ToString().Length; i++)
                    {
                        if (Tabla[5, e.RowIndex].Value.ToString().Substring(i, 1) == ".")
                        {
                            n++;
                        }
                    }
                    if (n < 2)
                    {
                        Tabla[5, e.RowIndex].Value=Convert.ToDouble(Tabla[5, e.RowIndex].Value);
                        if (Tabla[5, e.RowIndex].Value.ToString().Equals("."))
                        {
                            Tabla[5, e.RowIndex].Value = Convert.ToDouble(0.00);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Solo puede agregar 1 punto decimal");
                        Tabla[5, e.RowIndex].Value = Convert.ToDouble(0.00);
                    }                  
                }
            }
             catch (Exception)
             {
                   //MessageBox.Show(ex.Message);
             }
        }
        public void Guardar()
        {
            int i = 0;
            if (dtpFecha.Value.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"))
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT idcortedcaja FROM cortedcaja WHERE empleados_id_empleado=1 AND Fecha BETWEEN '" +
               dtpFecha.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFecha.Value.ToString("yyyyMMdd235959") + "'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    i = lector.GetInt32(0);
                }
                conectar.Close();
                comando = new MySqlCommand("UPDATE cortedcaja SET gastos=" + Tabla[5, 0].Value + ", Concepto='" + Tabla[7, 0].Value + "',EfectivoAentregar=" +
                                            Tabla[6, 0].Value + " WHERE idcortedcaja=" + i, conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();
            }
        }
        private void Tabla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Tabla.Rows[e.RowIndex].ErrorText = String.Empty;
            try
            {
                double C = Convert.ToDouble(Tabla[5, 0].Value);
                double T = Convert.ToDouble(Tabla[9, 0].Value);               
                Tabla[6, 0].Value = T - C;
            }
            catch
            {

            }
            SumarDatosGrid();
            Guardar();
        }
        int col1, col2, col3, col4, col5, col6, col7, col8, x, y, L, i;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (Tabla.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width / 20*10;
                int an = 5;
                int al = 15;
                x = 140;
                y = 125;
                L = x+5;
                Font letra = new Font("Arial", 9);
                col1 = Tabla.Columns[0].Width - an;
                col2 = Tabla.Columns[1].Width - an;
                col3 = Tabla.Columns[2].Width - an;
                col4 = Tabla.Columns[3].Width - an;
                col5 = Tabla.Columns[4].Width - an;
                col6 = Tabla.Columns[5].Width - an;
                col7 = Tabla.Columns[5].Width - an;
                col8 = Tabla.Columns[5].Width - an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("CORTE DE SUCURSAL", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, Tabla.Rows[0].Height + 15));
                #endregion

                #region fecha
                e.Graphics.DrawString(dtpFecha.Value.ToString("dd/MMMM/yyyy"), new Font("Arial", 10), Brushes.Black, new Rectangle(e.MarginBounds.Width - 110, 105, 500, Tabla.Rows[0].Height + 15));
                #endregion


                #region Empleados

                Pen p = new Pen(Brushes.Black, 1.5f);

                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, Tabla.Rows[0].Height + al));

                #endregion

                #region Ventas Totales

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, Tabla.Rows[0].Height + al));

                #endregion

                #region Iva

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, Tabla.Rows[0].Height + al));


                #endregion

                #region Recuperado

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, Tabla.Rows[0].Height + al));

                #endregion

                #region Fiado
                
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, Tabla.Rows[0].Height + al));
                #endregion

                #region Gastos

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[5].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, Tabla.Rows[0].Height + al));
                #endregion

                #region Efectivo a entregar
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[6].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, Tabla.Rows[0].Height + al));
                #endregion

                #region Comentarios
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[7].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, Tabla.Rows[0].Height + al));
                #endregion
                height = 125 + al;

                while (i < Tabla.Rows.Count)
                {
                    if (height > e.MarginBounds.Height + 100)
                    {
                        height = 125 + al;
                        e.HasMorePages = true;
                        return;
                    }


                    height += Tabla.Rows[0].Height;

                    e.Graphics.DrawString(Tabla.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, Tabla.Columns[0].Width, Tabla.Rows[0].Height));

                    e.Graphics.DrawString(Tabla.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, Tabla.Columns[1].Width, Tabla.Rows[0].Height));

                    e.Graphics.DrawString(Tabla.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, Tabla.Columns[2].Width, Tabla.Rows[0].Height));

                    e.Graphics.DrawString(Tabla.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, Tabla.Columns[3].Width, Tabla.Rows[0].Height));

                    e.Graphics.DrawString(Tabla.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, Tabla.Columns[4].Width, Tabla.Rows[0].Height));

                    e.Graphics.DrawString(Tabla.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, Tabla.Columns[5].Width, Tabla.Rows[0].Height));

                    e.Graphics.DrawString(Tabla.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, Tabla.Columns[6].Width, Tabla.Rows[0].Height));

                    e.Graphics.DrawString(Tabla.Rows[i].Cells[7].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7, height, Tabla.Columns[7].Width, Tabla.Rows[0].Height));

                    i++;
                }

                #region lineafirma
                e.Graphics.DrawString("__________________________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 20 * 9, height + 50, 500, Tabla.Rows[0].Height + 15));
                #endregion
                #region firma
                e.Graphics.DrawString("FIRMA", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 20 * 12, height + 70, 50, Tabla.Rows[0].Height + 15));
                #endregion

                i = 0;
                e.HasMorePages = false;

            }
        }

        private void Tabla_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Tabla_KeyPress);
        }

        private void CorteSucursal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnRealizarCorte_Click(object sender, EventArgs e)
        {
            LLenarDataGrid();
        }
    }
}
