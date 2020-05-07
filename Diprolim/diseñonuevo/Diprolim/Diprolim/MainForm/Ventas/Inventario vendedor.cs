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


namespace Diprolim
{
    public partial class Salidas : Form
    {
        conexion conn = new conexion();
        UnicaSQL.DBMS_Unico Conexion;
        String cmd;
        int idProducto = 0;
        DialogResult result;
        int cod_articulo = 0, cod_emplea = 0;
        double Limite = 0;
        double sumatoria = 0, TotalLimitado;
        string UsuarioID = "";
        
        public Salidas()
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            btnCambiarVendedor.Enabled = false;
            cbxCSalidas.SelectedIndex = 1;
            CargarFolio();
        }
        public Salidas(string Id, UnicaSQL.DBMS_Unico svr)
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            btnCambiarVendedor.Enabled = false;
            cbxCSalidas.SelectedIndex = 1;
            Conexion = svr;
            UsuarioID = Id;
            CargarFolio();
        }
        public int CargarFolio()
        {
            int Folio = 0;
            string inicial = "";
            DataTable Tabla = new DataTable();
            Conexion.Conectarse();
            Conexion.Ejecutar("select IdFolios from Folios_Entradas", ref Tabla);
            Conexion.Desconectarse();
            if (Tabla.Rows.Count > 0)
            {
                Folio = Convert.ToInt32(Tabla.Rows[Tabla.Rows.Count - 1][0])+1;
                Tabla.Rows.Clear();
            }

            Conexion.Conectarse();
            Conexion.Ejecutar("Select iniciales from almacenes where origen=true", ref Tabla);
            Conexion.Desconectarse();
            if (Tabla.Rows.Count > 0)
            {
                inicial = Tabla.Rows[0][0].ToString();
                Tabla.Rows.Clear();
            }

            if (Folio == 0)
            {
                Folio = 1;
            }
            tbxFolioDE.Text = inicial + "-" + Folio.ToString();
            return Folio;
        }
        private void btnSV_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedor.Text=id.regresar.valXn;
            }
            tbxVendedor.Focus();
            if (tbxVendedor.Text != "1")
            {
                tblSalidas.Rows.Clear();

                obtenerVendedor();

                LLenarDataGriw();
                btnCambiarVendedor.Enabled = true;
                SumaTotal();


            }
        }


        public void Verificar()
        {
            
             MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;
                    comando = new MySqlCommand("select cantidad from inv_vendedor where articulos_codigo="+cod_articulo+" and empleados_id_empleado="+cod_emplea, conectar);   
                    conectar.Open();

                    MySqlDataReader lector;
                    lector = comando.ExecuteReader();

                    string dess = "";
                    while (lector.Read())
                    {
                        dess = lector.GetString(0);
                       

                    }
                    conectar.Close();
                    MessageBox.Show(dess);
                    if (dess == "")
                    {
                        comando = new MySqlCommand("insert into inv_vendedor values(null,0," + cod_emplea + "," + cod_articulo + ")", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();


                    }
                 
        }
        public void Inv_VendedorVerificar()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            MySqlDataReader lector;
           
           

            comando = new MySqlCommand("select count(*) from inv_vendedor where  empleados_id_empleado=" + tbxVendedor.Text + " and articulos_codigo=" + cod_articulo, conectar);
            conectar.Open();

           
            lector = comando.ExecuteReader();

            int i = 0;
            while (lector.Read())
            {
               i = lector.GetInt32(0);

            }
            conectar.Close();
           
            if (i==0)
            {
                comando = new MySqlCommand("insert into inv_vendedor values(null,0," + tbxVendedor.Text + "," + cod_articulo + ")", conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();


            }
        }
        public void LLenarDataGriw()
        {
            if (tbxVendedor.Text != "")
            {
                
                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;
                   // comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + tbxVendedor.Text, conectar);
                    comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre," +
                               " a.cantidad,i.cantidad,a.precio_calle, a.departamento, a.unidad_medida_id From articulos a, unidad_medida u, inv_vendedor i" +
                               " WHERE (a.cantidad>0 or i.cantidad>0) and empleados_id_empleado="+tbxVendedor.Text+
                               " and i.articulos_codigo=a.codigo and a.unidad_medida_id = u.id" +
                               " order by codigo asc", conectar);   
                    conectar.Open();

                    MySqlDataReader lector;
                    lector = comando.ExecuteReader();
                    
                    
                    while (lector.Read())
                    {
                        tblSalidas.Rows.Add(false, lector.GetInt32(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), lector.GetDouble(4), 0, lector.GetDouble(5), lector.GetDouble(5), lector.GetDouble(5) * lector.GetDouble(6), lector.GetDouble(6), lector.GetInt32(7),lector.GetDouble(2),lector.GetInt32(8));
                    }
                    conectar.Close();
                }            
        }
        string nombreV = "";
        public void obtenerVendedor()
        {
            if (tbxVendedor.Text != "")
            {                
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + tbxVendedor.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    tbxNVendedor.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    nombreV = lector.GetString(1);
                    des = lector.GetString(0);
                    Limite=lector.GetDouble(7);
                    tbxLimiteA.Text = lector.GetString(8);
                }
                conectar.Close();
                tbxVendedor.Enabled = false;
                //btnSV.Enabled = false;
                if (des == "")
                {
                    MessageBox.Show("Código de vendedor no existente");
                    tbxVendedor.Text = "";
                    tbxNVendedor.Clear();
                    tbxVendedor.Enabled = true;
                    tbxVendedor.Focus();
                   // btnSV.Enabled = true;

                }
                else
                {
                    comando = new MySqlCommand("select codigo from articulos", conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();                    
                    while (lector.Read())
                    {                        
                        idProducto = lector.GetInt32(0);
                        insertar();

                    }
                    conectar.Close();                   
                   
                   // tbxVendedor.ReadOnly = true;
                    //btnSV.Enabled = false;
                }
            }



        }
        public void insertar()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            MySqlDataReader lector;
                        comando = new MySqlCommand("select count(*) from inv_vendedor where  empleados_id_empleado=" + tbxVendedor.Text + " and articulos_codigo=" + idProducto, conectar);
                        conectar.Open();


                        lector = comando.ExecuteReader();

                        int i = 0;
                        while (lector.Read())
                        {
                            i = lector.GetInt32(0);
                            if (i == 0)
                            {
                                InsertarDeVerdad();


                            }
                        }
                        conectar.Close();

        }
        public void InsertarDeVerdad()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            
            comando = new MySqlCommand("insert into inv_vendedor values(null,0," + tbxVendedor.Text + "," + idProducto+ ")", conectar);
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }

        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxVendedor.Text != "1")
                {
                    tblSalidas.Rows.Clear();
                    
                    obtenerVendedor();
                    
                    LLenarDataGriw();
                    btnCambiarVendedor.Enabled = true;
                    SumaTotal();
                   
                   
                }
                
            }
            
        }
        
       
        

        private void tblSalidas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           tblSalidas.Rows[e.RowIndex].ErrorText = String.Empty;
           SumaTotal();
           r = true;
//            double n= Convert.ToDouble(tblSalidas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
           // tblSalidas.Rows[e.RowIndex].Cells[
        }

        private void tblSalidas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
        tblSalidas.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("Salidas")) return;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                tblSalidas.Rows[e.RowIndex].ErrorText =
                    "No puedes dejar vacia esta celda";
                e.Cancel = true;
            }
        }
        int F = 0, n=0;
        Boolean r = true;
        private void tblSalidas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            n = 0;
                if (tblSalidas.Rows.Count > 0)
                {
                    for (int i = 0; i < tblSalidas[4, e.RowIndex].Value.ToString().Length; i++)
                    {
                        if (tblSalidas[4, e.RowIndex].Value.ToString().Substring(i, 1) == ".")
                        {
                            n++;
                        }

                    }
                    if (n < 2)
                    {
                        if (tblSalidas[4, e.RowIndex].Value.ToString().Equals("."))
                        {
                            tblSalidas[4, e.RowIndex].Value = Convert.ToDouble(0.00);
                        }
                        else
                        {
                            if (Convert.ToDouble(tblSalidas[3, e.RowIndex].Value) >= Convert.ToDouble(tblSalidas[4, e.RowIndex].Value))
                            {

                                if (limitarTotal() || Convert.ToInt32(tblSalidas[9, e.RowIndex].Value) == 2 || Convert.ToInt32(tblSalidas[9, e.RowIndex].Value) == 3 || Convert.ToDouble(tblSalidas[10, e.RowIndex].Value) >= 4 || Convert.ToInt32(tblSalidas[11, e.RowIndex].Value) >= 7)
                                {
                                  
                                        if (Convert.ToDouble(tblSalidas[4, e.RowIndex].Value) >= 0)
                                        {
                                            tblSalidas[6, e.RowIndex].Value = Convert.ToDouble(tblSalidas[4, e.RowIndex].Value) + Convert.ToDouble(tblSalidas[5, e.RowIndex].Value);
                                            tblSalidas[7, e.RowIndex].Value = Convert.ToDouble(tblSalidas[8, e.RowIndex].Value) * Convert.ToDouble(tblSalidas[6, e.RowIndex].Value);
                                            r = true;
                                            especial = 0;
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se puede ingresar números negativos");
                                            tblSalidas[4, e.RowIndex].Value = Convert.ToDouble(0.00);

                                        }
                                   
                                }
                                else
                                {
                                    
                                        tblSalidas[4, e.RowIndex].Value = Convert.ToDouble(0.00);
                                        tblSalidas[6, e.RowIndex].Value = Convert.ToDouble(tblSalidas[4, e.RowIndex].Value) + Convert.ToDouble(tblSalidas[5, e.RowIndex].Value);
                                        tblSalidas[7, e.RowIndex].Value = Convert.ToDouble(tblSalidas[8, e.RowIndex].Value) * Convert.ToDouble(tblSalidas[6, e.RowIndex].Value);

                                        if (r)
                                        {
                                            MessageBox.Show("ha sobrepasado el limite de inventario de vendedor");
                                            r = false;
                                        }
                                  
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se puede dar salida si no hay existencias en sucursal");
                                tblSalidas[4, e.RowIndex].Value = Convert.ToDouble(0.00);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Solo puede agregar 1 punto decimal");
                        tblSalidas[4, e.RowIndex].Value = Convert.ToDouble(0.00);
                    }
                }
           
            //SumaTotal();
        }
        public void SumaTotal()
        {
            sumatoria = 0;
            TotalLimitado = 0;
            foreach (DataGridViewRow row in tblSalidas.Rows)
            {
                sumatoria += Convert.ToDouble(row.Cells[7].Value);
                if (Convert.ToInt32(row.Cells[9].Value) == 1 && Convert.ToInt32(row.Cells[10].Value) < 4 && Convert.ToInt32(row.Cells[11].Value) != 7)
                {
                    TotalLimitado += Convert.ToDouble(row.Cells[7].Value);
                }
            }

            tbxTotal.Text = Convert.ToString(sumatoria);

            tbxTotalLimitado.Text = Convert.ToString(TotalLimitado);
            //if (sumatoria > Limite)
            //{
            //    MessageBox.Show("ha sobrepasado el limite de inventario de vendedor");
            //    tblSalidas.ReadOnly = true;
            //}
        }
        public Boolean limitarTotal()
        {
            try
            {
                Boolean limit = false;
                TotalLimitado = 0;
                foreach (DataGridViewRow row in tblSalidas.Rows)
                {
                    //sumatoria += Convert.ToDouble(row.Cells[7].Value);

                    if (Convert.ToInt32(row.Cells[9].Value) == 1 && Convert.ToInt32(row.Cells[10].Value) < 4 && Convert.ToInt32(row.Cells[11].Value)!=7)
                    {
                        TotalLimitado += Convert.ToDouble(row.Cells[7].Value);
                    }
                }

                tbxTotalLimitado.Text = Convert.ToString(TotalLimitado);
                if (TotalLimitado <= Limite)
                {
                    return true;
                }
                else if (especial == 1)
                {
                    return true;
                }
                else
                {
                    return limit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in tblSalidas.Rows)
            {              
                DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(celdaseleccionada.Value))
                    list.Add(row);
            }
            foreach (DataGridViewRow row in list)	
            {
                tblSalidas.Rows.Remove(row);
            } 
        }
        public void resetControles()
        {
            tbxVendedor.Clear();
            tbxVendedor.ReadOnly = false;
            tbxNVendedor.Clear();
            tbxTotal.Clear();
            tblSalidas.Rows.Clear();
          //  btnSV.Enabled = true;
        }
        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {
            result=MessageBox.Show("Está cambiando de vendedor, todos los cambios no \nguardados se perderán. \n\n ¿Aún así desea continuar?","Cambio de vendedor",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                resetControles();
                tbxVendedor.Enabled = true;
                tbxTotal.Clear();
                tbxLimiteA.Clear();
                sumatoria = 0;
                F = 0;
                r = true;
                tblSalidas.ReadOnly = false;
            }
        }
        double existenciaA = 0;
        string cod_art,desc,cantidad,inv_total,cod_empleado;
        
        public void InsertarHistoricoDMovimientos()
        {
            MySqlCommand comando;
            MySqlConnection conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("INSERT INTO HistoricoDMovimientos  VALUES(null," + cod_art + "," + cantidad + "," + existenciaA + ",'Salida-"+nombreV+"'," + UsuarioID + ",now(),"+cantidad5+")", conectar);
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
       

        
        int col1, col2, col3, col4, col5, col6, col7, i = 0, x, y, L;
        double suma = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            if (tblSalidas.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width / 2;
                int an = 27;
                //int width = 0;
                Font letra = new Font("Arial", 9);
                x = 80;
                y = 125;
                L = 85;
                col1 = tblSalidas.Columns[1].Width - an;
                col2 = tblSalidas.Columns[2].Width - an;
                col3 = tblSalidas.Columns[3].Width - 25;
                col4 = tblSalidas.Columns[4].Width - an;
                col5 = tblSalidas.Columns[5].Width - an;
                col6 = tblSalidas.Columns[6].Width - an;
                col7 = tblSalidas.Columns[7].Width - an;
                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);
                #region titulo
                e.Graphics.DrawString("SALIDAS", new Font("Arial", 16,FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width/2+40, 50, 500, tblSalidas.Rows[0].Height + 15));
                #endregion

                #region NombreVendedor
                e.Graphics.DrawString("Vendedor: " + tbxNVendedor.Text, new Font("Arial", 9), Brushes.Black, new Rectangle(x, 105, 500, tblSalidas.Rows[0].Height + 15));
                #endregion

                #region fecha
                e.Graphics.DrawString(dtpFecha.Value.ToString("dd/MMMM/yyyy"), new Font("Arial", 9), Brushes.Black, new Rectangle(e.MarginBounds.Width+35, 105, 500, tblSalidas.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, tblSalidas.Rows[0].Height + 15));

                #endregion

                #region Descripcion

      //          e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + tblSalidas.Columns[1].Width, 100, tblSalidas.Columns[2].Width+100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, tblSalidas.Rows[0].Height + 15));

                #endregion

                #region Existencias
        //        e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(300 + tblSalidas.Columns[1].Width, 100, tblSalidas.Columns[3].Width, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1+col2, y, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1+col2, y, col3, tblSalidas.Rows[0].Height + 15));


                #endregion

                #region Salidas

     //           e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(400 + tblSalidas.Columns[1].Width, 100, tblSalidas.Columns[4].Width, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2+col3, y, col4, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, tblSalidas.Rows[0].Height + 15));

                #endregion

                #region InventarioVendedor

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[5].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblSalidas.Rows[0].Height + 15));

                #endregion

                #region CantidadTotal

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[6].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblSalidas.Rows[0].Height + 15));

                #endregion

                #region Total

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5+col6, y, col7, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblSalidas.Columns[7].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, tblSalidas.Rows[0].Height + 15));

                #endregion

                height = 145;

                while (i < tblSalidas.Rows.Count)
                {
                    if (height > e.MarginBounds.Height + 100)
                    {
                        height = 145;
                        e.HasMorePages = true;
                        return;
                    }
                    if (cbxCSalidas.Text == "Todas")
                    {
                        if (Convert.ToDouble(tblSalidas.Rows[i].Cells[6].Value) > 0)
                        {
                            height += tblSalidas.Rows[0].Height;

                            //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblSalidas.Columns[1].Width, tblSalidas.Rows[0].Height));
                            e.Graphics.DrawString(tblSalidas.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, tblSalidas.Columns[1].Width, tblSalidas.Rows[0].Height));

                            //            e.Graphics.DrawRectangle(p, new Rectangle(100 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[2].Width, tblSalidas.Rows[0].Height));
                            if (tblSalidas.Rows[i].Cells[2].FormattedValue.ToString().Length > 45)
                            {
                                e.Graphics.DrawString(tblSalidas.Rows[i].Cells[2].FormattedValue.ToString().Substring(0, 40), letra, Brushes.Black, new Rectangle(L + col1, height, tblSalidas.Columns[2].Width, tblSalidas.Rows[0].Height));
                            }
                            else
                            {
                                e.Graphics.DrawString(tblSalidas.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, tblSalidas.Columns[2].Width, tblSalidas.Rows[0].Height));
                            }

                            //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[3].Width, tblSalidas.Rows[0].Height));
                            e.Graphics.DrawString(tblSalidas.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, tblSalidas.Columns[3].Width, tblSalidas.Rows[0].Height));

                            //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[4].Width, tblSalidas.Rows[0].Height));
                            e.Graphics.DrawString(tblSalidas.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblSalidas.Columns[4].Width, tblSalidas.Rows[0].Height));

                            //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[5].Width, tblSalidas.Rows[0].Height));
                            e.Graphics.DrawString(tblSalidas.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblSalidas.Columns[5].Width, tblSalidas.Rows[0].Height));

                            e.Graphics.DrawString(tblSalidas.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, tblSalidas.Columns[6].Width, tblSalidas.Rows[0].Height));


                            e.Graphics.DrawString(tblSalidas.Rows[i].Cells[7].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, tblSalidas.Columns[7].Width, tblSalidas.Rows[0].Height));
                          
                                suma += Convert.ToDouble(tblSalidas.Rows[i].Cells[7].Value);
                            
                        }
                        i++;
                    }
                    else
                    {
                        if (Convert.ToDouble(tblSalidas.Rows[i].Cells[4].Value) > 0)
                        {
                            if (Convert.ToDouble(tblSalidas.Rows[i].Cells[6].Value) > 0)
                            {
                                height += tblSalidas.Rows[0].Height;

                                //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblSalidas.Columns[1].Width, tblSalidas.Rows[0].Height));
                                e.Graphics.DrawString(tblSalidas.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, tblSalidas.Columns[1].Width, tblSalidas.Rows[0].Height));

                                //            e.Graphics.DrawRectangle(p, new Rectangle(100 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[2].Width, tblSalidas.Rows[0].Height));
                                if (tblSalidas.Rows[i].Cells[2].FormattedValue.ToString().Length > 45)
                                {
                                    e.Graphics.DrawString(tblSalidas.Rows[i].Cells[2].FormattedValue.ToString().Substring(0, 40), letra, Brushes.Black, new Rectangle(L + col1, height, tblSalidas.Columns[2].Width, tblSalidas.Rows[0].Height));
                                }
                                else
                                {
                                    e.Graphics.DrawString(tblSalidas.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, tblSalidas.Columns[2].Width, tblSalidas.Rows[0].Height));
                                }

                                //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[3].Width, tblSalidas.Rows[0].Height));
                                e.Graphics.DrawString(tblSalidas.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, tblSalidas.Columns[3].Width, tblSalidas.Rows[0].Height));

                                //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[4].Width, tblSalidas.Rows[0].Height));
                                e.Graphics.DrawString(tblSalidas.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblSalidas.Columns[4].Width, tblSalidas.Rows[0].Height));

                                //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + tblSalidas.Columns[1].Width, height, tblSalidas.Columns[5].Width, tblSalidas.Rows[0].Height));
                                e.Graphics.DrawString(tblSalidas.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblSalidas.Columns[5].Width, tblSalidas.Rows[0].Height));

                                e.Graphics.DrawString(tblSalidas.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, tblSalidas.Columns[6].Width, tblSalidas.Rows[0].Height));


                                e.Graphics.DrawString(tblSalidas.Rows[i].Cells[7].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, tblSalidas.Columns[7].Width, tblSalidas.Rows[0].Height));
                                
                                    suma += Convert.ToDouble(tblSalidas.Rows[i].Cells[7].Value);
                            }
                            
                        }
                        i++;
                    }
                    
                }
               
                    e.Graphics.DrawString("Total", letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height + 20, tblSalidas.Columns[6].Width, tblSalidas.Rows[0].Height));

                    e.Graphics.DrawString("$" + suma, letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height + 20, tblSalidas.Columns[7].Width, tblSalidas.Rows[0].Height));
                    suma = 0;
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tblSalidas_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (tblSalidas.CurrentCell.ColumnIndex == 4)
                {
                    if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
                    {

                        e.Handled = true;

                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
           
        }

        private void tblSalidas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (sumatoria > Limite)
            //{
            //    MessageBox.Show("Ha sobrepasado el límite de inventario.");
            //}
            e.Control.KeyPress += new KeyPressEventHandler(tblSalidas_KeyPress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limite = 1000000;
        }

        private void tblSalidas_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            
            // If the cells are equal, sort based on the ID column.
                if (e.Column.Name == "dgvCodArtS")
                {
                    // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                    //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                    e.SortResult = comparar(Convert.ToInt32(tblSalidas.Rows[e.RowIndex1].Cells["dgvCodArtS"].Value.ToString()),
                        Convert.ToInt32(tblSalidas.Rows[e.RowIndex2].Cells["dgvCodArtS"].Value.ToString()));
                }
                if (e.Column.Name == "tblSalidasN")
                {
                    // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                    //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                    e.SortResult = comparar(Convert.ToDouble(tblSalidas.Rows[e.RowIndex1].Cells["tblSalidasN"].Value.ToString()),
                        Convert.ToDouble(tblSalidas.Rows[e.RowIndex2].Cells["tblSalidasN"].Value.ToString()));
                }

                if (e.Column.Name == "Existencias")
                {
                    // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                    //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                    e.SortResult = comparar(Convert.ToDouble(tblSalidas.Rows[e.RowIndex1].Cells["Existencias"].Value.ToString()),
                        Convert.ToDouble(tblSalidas.Rows[e.RowIndex2].Cells["Existencias"].Value.ToString()));
                }

                if (e.Column.Name == "invVendedor")
                {
                    // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                    //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                    e.SortResult = comparar(Convert.ToDouble(tblSalidas.Rows[e.RowIndex1].Cells["invVendedor"].Value.ToString()),
                        Convert.ToDouble(tblSalidas.Rows[e.RowIndex2].Cells["invVendedor"].Value.ToString()));
                }
                if (e.Column.Name == "cantidadTotal")
                {
                    // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                    //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                    e.SortResult = comparar(Convert.ToDouble(tblSalidas.Rows[e.RowIndex1].Cells["cantidadTotal"].Value.ToString()),
                        Convert.ToDouble(tblSalidas.Rows[e.RowIndex2].Cells["cantidadTotal"].Value.ToString()));
                }
                if (e.Column.Name == "Totall")
                {
                    // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                    //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                    e.SortResult = comparar(Convert.ToDouble(tblSalidas.Rows[e.RowIndex1].Cells["Totall"].Value.ToString()),
                        Convert.ToDouble(tblSalidas.Rows[e.RowIndex2].Cells["Totall"].Value.ToString()));
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
        double[,] arreglo;
        int especial = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {                          
                EntardasAVendedores PE = new EntardasAVendedores(Conexion);
                PE.sIDUsuario = UsuarioID;
                PE.ShowDialog();
                CargarFolio();
            
        }

        public void agregarPedidosEsp()
        {
            for (int i = 0; i <tblSalidas.Rows.Count ; i++)
            {
                especial = 1;
            
                for (int j = 0; j < arreglo.GetLength(0); j++)
                {
                    if (arreglo[j, 0] == Convert.ToDouble(tblSalidas[1, i].Value))
                    {
                        tblSalidas[4, i].Value = Convert.ToDouble(tblSalidas[4, i].Value) + arreglo[j, 1];
                    }
                }
            }
            especial = 0;
        }
        double cantidad5 = 0;
        double inv_vendedor = 0;
        private void btnRegistrarS_Click_1(object sender, EventArgs e)
        {
            if (tblSalidas.Rows.Count <= 0)
            {
                MessageBox.Show("No hay ningún valor para guardar");
            }
            else
            {
                result = MessageBox.Show("Se va a registrar una salida ¿Desea continuar?", "Registrar salida", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;
                    comando = new MySqlCommand("INSERT INTO Folios_Entradas values(null)", conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    for (int i = 0; i < tblSalidas.Rows.Count; i++)
                    {

                        cod_art = tblSalidas[1, i].Value.ToString();
                        desc = tblSalidas[2, i].Value.ToString();
                        cantidad = tblSalidas[4, i].Value.ToString();
                        inv_vendedor = Convert.ToDouble(tblSalidas[5, i].Value);
                        existenciaA = (Convert.ToDouble(tblSalidas[3, i].Value.ToString()) - (Convert.ToDouble(tblSalidas[4, i].Value.ToString())));
                        inv_total = tblSalidas[6, i].Value.ToString();
                        cod_empleado = tbxVendedor.Text;
                        if (Convert.ToDouble(cantidad) > 0)
                        {
                            cantidad5 = Convert.ToDouble(tblSalidas[3, i].Value);
                            comando = new MySqlCommand("INSERT INTO salidas values(null," + cantidad + "," + dtpFecha.Value.ToString("yyyyMMdd") + "," + cod_empleado + "," + cod_art + "," + inv_total + ",'Normal','Sin Comentarios','"+tbxFolioDE.Text+"')", conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();

                            comando = new MySqlCommand("UPDATE inv_vendedor SET cantidad=" + inv_total + " WHERE empleados_id_empleado=" + cod_empleado + " AND articulos_codigo=" + cod_art, conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();

                            comando = new MySqlCommand("UPDATE articulos SET cantidad=cantidad-" + cantidad + " WHERE codigo=" + cod_art, conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();
                            Conexion.Conectarse();
                            cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                              " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                              " VALUES({0},{1},'{2}','{3}',{4},{5},{6},{7})",
                              cod_art, cantidad, "Salidas", dtpFecha.Value.ToString("yyyyMMddHHmmss"),
                              inv_vendedor, inv_total, tbxVendedor.Text, UsuarioID);
                             Conexion.Ejecutar(cmd);
                             Conexion.Desconectarse();
                            InsertarHistoricoDMovimientos();
                        }

                    }
                    resetControles();
                    tbxVendedor.Enabled = true;
                    tblSalidas.ReadOnly = false;
                    btnCambiarVendedor.Enabled = false;
                    tbxLimiteA.Clear();
                    CargarFolio();
                }
            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.5;
            printPreviewDialog1.ShowDialog();
            //  printDocument1.Print();
        }

        private void tblSalidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (sumatoria > Limite)
            //{
            //    MessageBox.Show("Ha sobrepasado el límite de inventario.");
            //}
        }

        private void tbxVendedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                BuscarVendedor id = new BuscarVendedor();
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxVendedor.Text = id.regresar.valXn;
                   // obtenerVendedor();
                }
                tbxVendedor.ReadOnly = true;
                tbxVendedor.Focus();
                if (tbxVendedor.Text != "1")
                {
                    tblSalidas.Rows.Clear();

                    obtenerVendedor();

                    LLenarDataGriw();
                    btnCambiarVendedor.Enabled = true;
                    SumaTotal();


                }
              
            }
        }

        private void Salidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {                
                DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Saliendo de Consignación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }                
            }
        }
         
    }
}
