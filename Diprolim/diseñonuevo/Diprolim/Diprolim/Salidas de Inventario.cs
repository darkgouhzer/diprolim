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
    public partial class Salidas_de_Inventario : Form
    {
        conexion conn = new conexion();
        MySqlCommand comando;
        string ID = "";
        string Operacion = "";
        public Salidas_de_Inventario()
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            CargarFolio();
        }
     public Salidas_de_Inventario(string Id)
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            ID = Id;
            CargarFolio();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarArticulos id = new BuscarArticulos();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxProducto.Text = id.regresar.valXn;
            }
            tbxProducto.Focus();
            BuscarProducto();
        }
        public void BuscarProducto()
        {
            if (tbxProducto.Text != "")
            {
                
                    MySqlConnection conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("select a.descripcion, a.valor_medida, um.nombre,a.cantidad from articulos a, unidad_medida um where a.unidad_medida_id=um.id and a.codigo=" + tbxProducto.Text, conectar);
                    conectar.Open();

                    MySqlDataReader lector;
                    lector = comando.ExecuteReader();
                    string des = "";

                    while (lector.Read())
                    {
                        tbxNombre.Text = lector.GetString(0).ToString() + " " + lector.GetString(1) + " " + lector.GetString(2);
                        tbxExistencias.Text = lector.GetString(3);

                        des = lector.GetString(0);
                    }

                    conectar.Close();

                    if (des == "")
                    {
                        MessageBox.Show("Ese producto no existe");
                        tbxProducto.Clear();
                    }

                    else
                    {
                           tbxCantidad.Focus();
                    }
            }
        }
        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                BuscarProducto();
            }
        }
        double cantidad = 0, existenciaA=0;
        int codigo = 0;
       
        public void InsertarHistoricoDMovimientos()
        {
            MySqlCommand comando;
            MySqlConnection conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("INSERT INTO HistoricoDMovimientos  VALUES(null," + codigo + "," + cantidad + "," + existenciaA + ",'" +Operacion + "'," + ID + ",now(),"+exitencia+")", conectar);
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        public void Reset()
        {
            tbxCantidad.Clear();
            tbxComentarios.Clear();
            tbxProducto.Clear();
            tbxNombre.Clear();
            tbxExistencias.Clear();
            cbxMotivo.Text = "";
            tbxFolio.Clear();
            Tabla.Rows.Clear();
            cbxMotivo.SelectedIndex = -1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (e.KeyChar == 46 && tbxCantidad.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxExistencias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        private void tbxComentarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 92)
            {

                e.Handled = true;

            }
        }

        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxCantidad.Text.Length > 0)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    button2.Focus();
                }
            }
        }

        private void cbxMotivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbxComentarios.Focus();
            }
        }

        private void tbxComentarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnAC.Focus();
            }
        }

        private void cbxMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMotivo.Text == "Transferencia")
            {
                //  tbxFolio.Visible = true;
                //  label6.Visible = true;
                cbxAlmacen.Visible = true;
                label7.Visible = true;
                unidades();

                MySqlConnection conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("Select nombre,iniciales from almacenes where origen=true", conectar);
                conectar.Open();
                MySqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    sucursalOrigen = lector.GetString(1) + "-" + lector.GetString(0);
                }
                conectar.Close();
            }
            else
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("Select nombre,iniciales from almacenes where origen=true", conectar);
                conectar.Open();
                MySqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tbxFolio.Text = lector.GetString(1)+"-"+CargarFolio().ToString();
                }
                conectar.Close();
                
                cbxAlmacen.Visible = false;
                label7.Visible = false;
            }
        }
        int Folio = 0;
        string inicial;
        public int CargarFolio()
        {
            Folio = 0;
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand("select IdFolios from Folios_Salidas", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Folio = (lector.GetInt32(0)) + 1;
            }
            conectar.Close();
            comando = new MySqlCommand("Select iniciales from almacenes where origen=true", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                inicial = lector.GetString(0);
            }
            conectar.Close();
            if (Folio == 0)
            {
                Folio = 1;
            }
            tbxFolio.Text =inicial+"-"+ Folio.ToString();
            return Folio;
        }
        String sucursalDestino = "", sucursalOrigen="";
        
        public void unidades()
        {
            List<sourceUnidadesMedida> lista = new List<sourceUnidadesMedida>();
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand("select idalmacen, iniciales, nombre from almacenes", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                sourceUnidadesMedida datos = new sourceUnidadesMedida();
                datos.ID = lector.GetInt32(0);
                datos.nombre = lector.GetString(1);
                lista.Add(datos);
                
            }
            conectar.Close();
            cbxAlmacen.DataSource = lista;
            cbxAlmacen.DisplayMember = "nombre";
            cbxAlmacen.ValueMember = "ID";

        }

        private void cbxAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMotivo.Text == "Transferencia")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("Select nombre,iniciales from almacenes where origen=true", conectar);
                conectar.Open();
                MySqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tbxFolio.Text = lector.GetString(1) + "-" + CargarFolio();
                }
                conectar.Close();

                comando = new MySqlCommand("Select nombre,iniciales from almacenes where idalmacen=" + cbxAlmacen.SelectedValue, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    sucursalDestino = lector.GetString(1) + "-" + lector.GetString(0);
                }
                conectar.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in Tabla.Rows)
            {
                DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(celdaseleccionada.Value))
                    list.Add(row);
            }
            foreach (DataGridViewRow row in list)
            {
                Tabla.Rows.Remove(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbxProducto.Text != "" && tbxCantidad.Text != "")
            {
                if (Tabla.Rows.Count > 0)
                {
                    for (int i = 0; i < Tabla.Rows.Count; i++)
                    {
                        if (Tabla[1, i].Value.ToString() == tbxProducto.Text)
                        {

                            MessageBox.Show("No puede agregar 2 veces un producto");
                            tbxCantidad.Text = "";
                            tbxProducto.Focus();
                        }
                    }
                }

                if (tbxProducto.Text != "" && tbxCantidad.Text != "")
                {
                    if (tbxCantidad.Text == ".")
                    {
                        MessageBox.Show("Verifique la cantidad de entrada");
                        tbxCantidad.Focus();
                    }
                    else
                    {
                        if(Convert.ToDouble(tbxCantidad.Text)<=Convert.ToDouble(tbxExistencias.Text))
                        {
                            if (Convert.ToDouble(tbxCantidad.Text) != 0)
                            {
                                double cantidad = 0;
                                try
                                {
                                    MySqlConnection conectar1 = conn.ObtenerConexion();
                                    MySqlCommand comando1;
                                    conectar1.Open();
                                    comando1 = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre, a.cantidad " +
                                        "FROM articulos a, unidad_medida u WHERE codigo =" + tbxProducto.Text + " and a.unidad_medida_id=u.id", conectar1);
                                    MySqlDataReader lector1;
                                    lector1 = comando1.ExecuteReader();

                                    while (lector1.Read())
                                    {
                                        cantidad = Convert.ToDouble(lector1.GetString(4));

                                        Tabla.Rows.Add(false, lector1.GetString(0), lector1.GetString(1) + " " + lector1.GetString(2) + " " + lector1.GetString(3), tbxCantidad.Text, tbxExistencias.Text);

                                        tbxCantidad.Clear();
                                        tbxExistencias.Clear();
                                        tbxNombre.Clear();
                                        tbxProducto.Clear();
                                        tbxProducto.Focus();
                                    }
                                }
                                catch (MySqlException Ex)
                                {
                                    MessageBox.Show(Ex.Message);
                                    throw;
                                }
                            }
                            else
                            {
                                MessageBox.Show("La cantidad es 0");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La existencia no cubre esa cantidad");
                        }
                    }
                }
            }
        }

        private void Tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Salidas_de_Inventario_Load(object sender, EventArgs e)
        {

        }
        int col1, col2, col3, col4, y, i = 0, x, L;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (Tabla.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width / 6 * 3;
                int an = 0;
                int al = 15;
                x = e.MarginBounds.Width / 7 * 2;
                y = 125;
                L = e.MarginBounds.Width / 7 * 2+5;
                Font letra = new Font("Arial", 9);
                col1 = Tabla.Columns[1].Width - an;
                col2 = Tabla.Columns[2].Width - an;
                col3 = Tabla.Columns[3].Width - an;
                //col4 = Tabla.Columns[3].Width - an;
                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(100, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);
                #region titulo
                e.Graphics.DrawString("SALIDA DE ALMACÉN", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, Tabla.Rows[0].Height + 15));
                #endregion

                #region Folio
                e.Graphics.DrawString("Folio: " + tbxFolio.Text, new Font("Arial", 10,FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 7 * 6, 85, 500, Tabla.Rows[0].Height + 15));
                #endregion
                if (cbxMotivo.Text == "Transferencia")
                {
                    #region Origen
                    e.Graphics.DrawString("Origen: " + sucursalOrigen, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 85, 500, Tabla.Rows[0].Height + 15));
                    #endregion
                    #region Destino
                    e.Graphics.DrawString("Destino: " + sucursalDestino, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 105, 500, Tabla.Rows[0].Height + 15));
                    #endregion
                }

                #region fecha
                e.Graphics.DrawString(DateTime.Now.ToString("dd/MMMM/yyyy"), new Font("Arial", 10), Brushes.Black, new Rectangle(e.MarginBounds.Width / 7 * 6, 105, 500, Tabla.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                //           e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60, 100, col1, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, Tabla.Rows[0].Height + al));

                #endregion

                #region Producto

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1, 100, col2 + 100, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, Tabla.Rows[0].Height + al));

                #endregion

                #region UnidadesVendidas
                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2, 100, col3, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, Tabla.Rows[0].Height + al));


                #endregion

               /* #region Total

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, Tabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, Tabla.Rows[0].Height + al));
                e.Graphics.DrawString(Tabla.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, Tabla.Rows[0].Height + al));

                #endregion*/


                height = 125 + al;

                while (i < Tabla.Rows.Count)
                {
                    if (height > e.MarginBounds.Height + 50)
                    {
                        height = 125 + al;
                        e.HasMorePages = true;
                        return;
                    }


                    height += Tabla.Rows[0].Height;

                    //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, Tabla.Columns[1].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, col1, Tabla.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + Tabla.Columns[1].Width, height, Tabla.Columns[2].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, col2, Tabla.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + Tabla.Columns[1].Width, height, Tabla.Columns[3].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, col3, Tabla.Rows[0].Height));

                    //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + Tabla.Columns[1].Width, height, Tabla.Columns[4].Width, Tabla.Rows[0].Height));
                    //e.Graphics.DrawString(Tabla.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, Tabla.Columns[3].Width, Tabla.Rows[0].Height));

                    i++;
                }

                #region lineafirma
                e.Graphics.DrawString("__________________________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width/10*4, height+50, 500, Tabla.Rows[0].Height + 15));
                #endregion
                #region firma
                e.Graphics.DrawString("FIRMA", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width/20*13 , height + 70, 50, Tabla.Rows[0].Height + 15));
                #endregion

                i = 0;
                e.HasMorePages = false;

            }
        }

     

        private void tbxProducto_Leave(object sender, EventArgs e)
        {
            BuscarProducto();
        }
        double exitencia = 0;
        private void btnAC_Click_1(object sender, EventArgs e)
        {
            BuscarProducto();

            if (cbxMotivo.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {


                    codigo = Convert.ToInt32(Tabla[1, i].Value.ToString());
                    cantidad = Convert.ToDouble(Tabla[3, i].Value.ToString());
                    exitencia = Convert.ToDouble(Tabla[4, i].Value);
                    existenciaA = (Convert.ToDouble(Tabla[4, i].Value.ToString()) - (cantidad));


                    comando = new MySqlCommand("INSERT INTO salidas values(null," + cantidad + "," + dtpFecha.Value.ToString("yyyyMMddHHmmss") + ",1," + Tabla[1, i].Value.ToString() + "," + cantidad + ",'" + cbxMotivo.Text + "','" + tbxComentarios.Text + "','" + tbxFolio.Text + "')", conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();

                    comando = new MySqlCommand("UPDATE articulos SET cantidad=cantidad-" + cantidad + " WHERE codigo=" + codigo.ToString(), conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    if (cbxMotivo.Text == "Transferencia")
                    {

                        Operacion = "SI-Trans-"+cbxAlmacen.Text;

                    }
                    else  
                    {

                        Operacion = "SI-"+cbxMotivo.Text;

                    }
                    
                   
                    InsertarHistoricoDMovimientos();
                    


                }
                comando = new MySqlCommand("INSERT INTO Folios_Salidas values(null)", conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();
                if (Tabla.Rows.Count > 0)
                {
                    (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.PrintPreviewControl.Zoom = 1.5;
                    printPreviewDialog1.ShowDialog();
                    MessageBox.Show("Guardado");
                    Reset();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un motivo para la salida");
            }
                
        }

    }
}
