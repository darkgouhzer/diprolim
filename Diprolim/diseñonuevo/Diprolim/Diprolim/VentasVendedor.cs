using Diprolim.MainForm;
using Entidades;
using MySql.Data.MySqlClient;
using ReglasNegocios;
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
    public partial class VentasVendedor : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        String cmd;
        conexion conn = new conexion();
        MySqlCommand comando;
        MySqlConnection conectar;
        MySqlDataReader lector;
        DialogResult result;        
        
        int idCliente = 0;
        int idCategoria = 0;
        double comisionC = 0;
        double ComisionN = 0;
        string Fechaa = "";
        string UsuarioID = "";
        DateTime FFecha;
        Boolean bAutorizacionDescDistribuidor = false, bAutorizar = true;




        public VentasVendedor(UnicaSQL.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
            dtpFecha.Value = DateTime.Now;
            inavilitados();
            cbxCEntradas.SelectedIndex = 0;
        }
        public VentasVendedor(string Id, UnicaSQL.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
            dtpFecha.Value = DateTime.Now;
            inavilitados();
            UsuarioID = Id;
            cbxCEntradas.SelectedIndex = 0;
        }
        recuperarCodigo _ui = new recuperarCodigo();
   
        public recuperarCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }
        private void btnSV_Click_1(object sender, EventArgs e)
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

        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Está cambiando de vendedor, todos los cambios no \nguardados se perderán. \n\n ¿Aún así desea continuar?", "Cambio de vendedor", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                resetControles();
                inavilitados();
                tbxIVA.Clear();
                tbxSubtotal.Clear();
                tbxTotal.Clear();
                tblEntradas.AllowUserToDeleteRows = false;
                tblEntradas.Columns[4].Visible = true;
                tblEntradas.Columns[7].Visible = false;
                tblEntradas.Visible = true;
                tblCredito.Visible = false;
                rbtCredito.Enabled = false;
                rbtContado.Enabled = false;
                rbtCredito.Checked = false;
                rbtContado.Checked = true;
                tbxVendedor.Enabled = true;
                tbxVendedor.Focus();
                bAutorizacionDescDistribuidor = false;
                bAutorizar = true;
            }
        }
        public void resetControles()
        {
            tbxVendedor.Clear();
            tbxExistencias.Clear();
            tbxVendedor.ReadOnly = false;
            tbxNVendedor.Clear();
            tblEntradas.Rows.Clear();
            btnSV.Enabled = true;
            tbxCCliente.Clear();
            tbxNCliente.Clear();
            tbxProducto.Clear();
            tbxNombre.Clear();
            tbxCantidad.Clear();

        }
        public void ObtnerClienteDefaut()
        {
            if (tbxCCliente.Text == "")
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("SELECT a.idclientes, a.nombre, a.categorias_idcategorias, u.Vendedor " +
                            "FROM clientes a, categorias u WHERE idclientes =" + idCliente + " and a.categorias_idcategorias=u.idcategorias", conectar);

                conectar.Open();

                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    idCliente = lector.GetInt32(0);
                    idCategoria = lector.GetInt32(2);
                    comisionC = lector.GetInt32(3);
                    tbxNCliente.Text = lector.GetString(1);
                    des = lector.GetString(0);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de cliente no existente");
                    tbxCCliente.Clear();
                    tbxNCliente.Clear();
                    tbxProducto.Enabled = false;
                    btnSP.Enabled = false;
                    btnAC.Enabled = false;
                    tbxCantidad.Enabled = false;
                    btnEliminar.Enabled = false;
                   
                    tbxCCliente.Focus();

                }
            }

        }
        
        public void ObtenerComision()
        {
            string LOKO = "";
            if (Depa == 2) { LOKO = "Accesorios"; }
            if (Depa == 3) { LOKO = "Papel"; }
            conectar = conn.ObtenerConexion();

            comando = new MySqlCommand("select Vendedor from categorias where nombre='" + LOKO + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                ComisionN = lector.GetDouble(0);
            }
            conectar.Close();
        }
       
        public void verificarYEliminar()
        {
            DataTable Tabla = new DataTable();
            Conexion.Ejecutar("select count(*) from entradas where empleados_id_empleado=" + cod_empleado + " and articulos_codigo=" + cod_art + " and fecha=" + dtpFecha.Value.ToString("yyyyMMdd"),ref Tabla);
            //conectar = conn.ObtenerConexion();            
            //comando = new MySqlCommand("select count(*) from entradas where empleados_id_empleado="+cod_empleado+" and articulos_codigo="+cod_art+" and fecha="+ dtpFecha.Value.ToString("yyyyMMdd"), conectar);

            //conectar.Open();

            //lector = comando.ExecuteReader();
            if(Tabla.Rows.Count>0)
            {
                if( Convert.ToInt32(Tabla.Rows[0][0])==1)
                {
                    Conexion.Ejecutar("delete from entradas where empleados_id_empleado=" + cod_empleado + " and articulos_codigo=" + cod_art + " and fecha=" + dtpFecha.Value.ToString("yyyyMMdd"));
                }
            }
           
                
        }
        string cod_art,  n_entradas, n_venta, importe, inv_anterior,cod_empleado,fecha;
        double precio_A = 0,costoP=0;
        
        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoVendedor();
            }
            if (e.KeyValue == 113)
            {
                Consignacion consig = new Consignacion(Conexion, UsuarioID);
                consig.ShowDialog();
            }
            else if (e.KeyValue == 112)
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
        }
        public void MetodoVendedor()
        {
            if (tbxVendedor.Text != "1")
            {

                obtenerVendedor();//obtiene vendedor y al mismo tiempo rellena datagrid con los productos del vendedor
                if (tbxVendedor.Text != "")
                {
                    tblEntradas.AllowUserToDeleteRows = false;
                    tbxCCliente.Enabled = true;
                    tbxCCliente.Focus();
                    btnSC.Enabled = true;
                    btnCLimpiar.Enabled = true;
                    sumaTotal();
                }
            }
        }
        public void inavilitados()
        {
            tbxProducto.Enabled = false;
            btnSP.Enabled = false;
            btnAC.Enabled = false;
            tbxCantidad.Enabled = false;
            btnEliminar.Enabled = false;
            tbxCCliente.Enabled = false;
            btnSC.Enabled = false;
            btnCLimpiar.Enabled = false;
        }
        public void activos()
        {
            tbxProducto.Enabled = true;
            rbtContado.Enabled = true;
            rbtCredito.Enabled = true;
            btnSP.Enabled = true;
            btnAC.Enabled = true;
            tbxCantidad.Enabled = true;
            btnEliminar.Enabled = true;
           
        }
        public void ObtnerCliente()
        {
            if (tbxCCliente.Text != "")
            {
                conectar = conn.ObtenerConexion();
                //comando = new MySqlCommand("SELECT * FROM clientes WHERE idclientes =" + tbxCCliente.Text, conectar);
                comando = new MySqlCommand("SELECT a.idclientes, a.nombre, a.categorias_idcategorias, u.Vendedor, a.empleados_id_empleado " +
                            "FROM clientes a, categorias u WHERE idclientes =" + tbxCCliente.Text + " and a.categorias_idcategorias=u.idcategorias", conectar);

                conectar.Open();
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    if (lector.GetString(4) == tbxVendedor.Text)
                    {
                        idCliente = lector.GetInt32(0);
                        idCategoria = lector.GetInt32(2);
                        comisionC = lector.GetDouble(3);
                        tbxNCliente.Text = lector.GetString(1);
                        des = lector.GetString(0);
                        tblEntradas.Columns[4].ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("El cliente no pertenece a este vendedor");
                        des = ":p";
                        tbxCCliente.Clear();
                        tbxNCliente.Clear();                        
                        tbxCCliente.Focus();
                    }
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código del cliente no existente");
                    tbxCCliente.Clear();
                    tbxNCliente.Clear();
                    tbxCCliente.Focus();

                }

                if (idCategoria == 9)
                {
                    rbtnGeneral.Checked = true;
                }
                else if (idCategoria == 8)
                {
                    rbtnDistribuidor.Checked = true;
                }
                else if (idCategoria == 7)
                {
                    rbtnAbarrotes.Checked = true;
                }
            }

        }
        double Vende = 0;
        string categoria = "";
        public void obtenerVendedor()
        {
            if (tbxVendedor.Text != "")
            {
                categoria = "";
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("SELECT id_empleado, nombre, apellido_paterno, apellido_materno, limite_credito FROM empleados WHERE id_empleado =" + tbxVendedor.Text, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                string des = "";
                double credito = 0;
                while (lector.Read())
                {
                    tbxNVendedor.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    credito = lector.GetDouble(4);
                    des = lector.GetString(0); 
                }
                conectar.Close();
                comando = new MySqlCommand("select sum(pendiente) from ventas where pendiente>0 and empleados_id_empleado=" + tbxVendedor.Text, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                double fiado = 0;
                while (lector.Read())
                {
                    if (!lector.IsDBNull(0))
                    {
                        fiado = lector.GetDouble(0);
                    }
                    else
                    {
                        fiado = 0;
                    }
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de vendedor no existente");
                    tbxVendedor.Text = "";
                    tbxNVendedor.Clear();
                    tbxCreditoRestante.Clear();

                }

                if (tbxVendedor.Text == "1")
                {
                    comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre," +
                         "a.cantidad,a.precio_calle,a.precioproduccion, a.departamento FROM articulos a, unidad_medida u" +
                         " where a.unidad_medida_id = u.id" +
                         " order by codigo asc", conectar);
                    conectar.Open();

                    lector = comando.ExecuteReader();
                    String dP = "";
                    while (lector.Read())
                    {
                        for (int i = 0; i < tblEntradas.Rows.Count; i++)
                        {
                            if (tblEntradas[1, i].Value.ToString() == lector.GetString(0))
                            {
                                dP = tblEntradas[1, i].Value.ToString();
                            }
                        }
                        if (dP != lector.GetString(0))
                        {
                            if (lector.GetString(7) == "1")
                            {
                                categoria = "9";
                            }
                            else if (lector.GetString(7) == "2")
                            {
                                categoria = "6";
                            }
                            else if (lector.GetString(7) == "3")
                            {
                                categoria = "10";
                            }
                            //tblEntradas.Rows.Add(false, lector.GetString(0), lector.GetString(1) + " " +
                            //    lector.GetString(2) + " " + lector.GetString(3), lector.GetString(4), 0, 0, lector.GetDouble(5), 0, 1, lector.GetString(6), categoria);
                        }
                    }
                    conectar.Close();
                    tblEntradas.Rows.Add(false, "-", "-", "-", "-", "-", "Subtotal", 0.00, "-", "-");
                    tblEntradas.Rows.Add(false, "-", "-", "-", "-", "-", "IVA", 0.00, "-", "-");
                    tblEntradas.Rows.Add(false, "-", "-", "-", "-", "-", "Total", 0.00, "-", "-");
                    tblEntradas[7, tblEntradas.Rows.Count - 3].ReadOnly = true;
                    tblEntradas[7, tblEntradas.Rows.Count - 2].ReadOnly = true;
                    tblEntradas[7, tblEntradas.Rows.Count - 1].ReadOnly = true;
                    tbxVendedor.ReadOnly = true;
                    btnSV.Enabled = false;

                }

                else
                {
                    if (tbxVendedor.Text != "")
                    {
                        tbxCreditoRestante.Text = (credito - fiado).ToString();
                        comando = new MySqlCommand("SELECT i.articulos_codigo, a.descripcion, a.valor_medida, u.nombre," +
                            " i.cantidad,a.precio_calle,a.precioproduccion,a.cantidad, a.departamento FROM inv_vendedor i, articulos a, unidad_medida u" +
                            " WHERE i.cantidad>0 AND empleados_id_empleado =" + tbxVendedor.Text + " " +
                            "AND i.articulos_codigo = a.codigo AND a.unidad_medida_id = u.id" +
                            " order by articulos_codigo asc", conectar);
                        conectar.Open();

                        lector = comando.ExecuteReader();
                        String dP = "";
                        while (lector.Read())
                        {
                            for (int i = 0; i < tblEntradas.Rows.Count; i++)
                            {
                                if (tblEntradas[1, i].Value.ToString() == lector.GetString(0))
                                {
                                    dP = tblEntradas[1, i].Value.ToString();
                                }
                            }
                            if (dP != lector.GetString(0))
                            {
                                if (tbxVendedor.Text == "1")
                                {
                                    if (lector.GetString(8) == "1")
                                    {
                                        categoria = "9";
                                    }
                                    else if (lector.GetString(8) == "2")
                                    {
                                        categoria = "6";
                                    }
                                    else if (lector.GetString(8) == "3")
                                    {
                                        categoria = "10";
                                    }
                                    Vende = lector.GetDouble(7);
                                  //  tblEntradas.Rows.Add(false, lector.GetString(0), lector.GetString(1) + " " +
                                  //lector.GetString(2) + " " + lector.GetString(3), Vende, 0, 0, lector.GetDouble(5), 0, 0, tbxVendedor.Text, lector.GetString(6), categoria);

                                }
                                else
                                {
                                    if (lector.GetString(8) == "1")
                                    {
                                        categoria = "9";
                                    }
                                    else if (lector.GetString(8) == "2")
                                    {
                                        categoria = "6";
                                    }
                                    else if (lector.GetString(8) == "3")
                                    {
                                        categoria = "10";
                                    }
                                    Vende = lector.GetDouble(4);
                                  //  tblEntradas.Rows.Add(false, lector.GetString(0), lector.GetString(1) + " " +
                                  //lector.GetString(2) + " " + lector.GetString(3), Vende, 0, 0, lector.GetDouble(5), 0, 0, tbxVendedor.Text, lector.GetString(6), categoria);
                                }
                            }
                            //des = lector.GetString(0);
                        }
                        conectar.Close();
                        tbxVendedor.ReadOnly = true;
                        tbxVendedor.Enabled = false;
                        btnSV.Enabled = false;
                    }
                }                
            }
        }
        public void Totls()
        {
            if (tblEntradas.Rows.Count > 0)
            {
                List<DataGridViewRow> list = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in tblEntradas.Rows)
                {
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                        list.Add(row);
                }
                foreach (DataGridViewRow row in list)
                {
                    tblEntradas.Rows.Remove(row);
                }
                double Subtotal = 0;
                double totales=0;//Descuento = 0,

             
                
                for (int i = 0; i < tblEntradas.Rows.Count; i++)
                {
                    Subtotal += (Convert.ToDouble(tblEntradas[7, i].Value));
                    // Descuento += (Convert.ToDouble(tblEntradas[8, i].Value));
                    totales += Convert.ToDouble(tblEntradas[9, i].Value);
                }
                tblEntradas.Rows.Add(true, "-", "-", "-", "-", "-", "Totales:", Subtotal, "-",totales);
                tblEntradas[0, tblEntradas.Rows.Count - 1].ReadOnly = true;
            }

            
        }
        public void sumaTotal()
        {
            if (rbtContado.Checked)
            {
                if (tblEntradas.Rows.Count > 0)
                {
                    double total = 0,subtotal=0, descuento=0;
                    for (int i = 0; i < tblEntradas.Rows.Count; i++)
                    {
                        if ((tblEntradas[6, i].Value).ToString() != "Totales:")
                        {
                            if(tblEntradas[8, i].Style.Format.ToString() == "0.00\\%")
                            {
                                subtotal = (Convert.ToDouble(tblEntradas[5, i].Value) * Convert.ToDouble(tblEntradas[6, i].Value));
                                descuento =  (subtotal * (Convert.ToDouble(tblEntradas[8, i].Value) / 100));
                                total += subtotal - descuento;
                            }
                            else
                            {
                                total += (Convert.ToDouble(tblEntradas[5, i].Value) * Convert.ToDouble(tblEntradas[6, i].Value)) - Convert.ToDouble(tblEntradas[8, i].Value);
                            }
                        }
                    }
                    tbxSubtotal.Text = total.ToString();
                    if (chbxIVa.Checked)
                    {
                        total = total / 1.16;
                        tbxSubtotal.Text = Math.Round(total, 2).ToString();
                        tbxIVA.Text = Math.Round(total * .16, 2).ToString();
                        tbxTotal.Text = Math.Round(total * 1.16, 2).ToString();                       
                    }
                    else
                    {
                        tbxIVA.Text = "0";
                        tbxTotal.Text = (Convert.ToDouble(tbxSubtotal.Text) + Convert.ToDouble(tbxIVA.Text)).ToString();
                    }
                   

                }
                else
                {
                    tbxSubtotal.Clear();
                    tbxIVA.Clear();
                    tbxTotal.Clear();
                }
            }
            else if(rbtCredito.Checked)
            {
                if (tblCredito.Rows.Count > 0)
                {
                    double total = 0, abono = 0, pendiente = 0,totaliva=0;
                    for (int i = 0; i < tblCredito.Rows.Count-1; i++)
                    {                        
                            totaliva += (Convert.ToDouble(tblCredito[3, i].Value)*Convert.ToDouble(tblCredito[4, i].Value));
                            total += Convert.ToDouble(tblCredito[5, i].Value);
                            abono += Convert.ToDouble(tblCredito[6, i].Value);
                            pendiente += Convert.ToDouble(tblCredito[7, i].Value);
                    }
                    evitar = true;
                    tblCredito[5, tblCredito.Rows.Count - 1].Value = total;
                    evitar = true;
                    tblCredito[6, tblCredito.Rows.Count - 1].Value = abono;
                    evitar = true;
                    tblCredito[7, tblCredito.Rows.Count - 1].Value = pendiente;

                    tbxSubtotal.Text = totaliva + "";
                    if (chbxIVa.Checked)
                    {

                        totaliva = totaliva / 1.16;
                        tbxSubtotal.Text = Math.Round(totaliva, 2).ToString();
                        tbxIVA.Text = Math.Round(totaliva * .16, 2).ToString();
                        tbxTotal.Text = Math.Round(totaliva * 1.16, 2).ToString(); 

                      
                    }
                    else
                    {
                        tbxIVA.Text = "0";
                        tbxTotal.Text = (Convert.ToDouble(tbxIVA.Text) + totaliva) + "";
                    }
                    

                }
                else
                {
                    tbxSubtotal.Clear();
                    tbxIVA.Clear();
                    tbxTotal.Clear();
                }
            }
        }
        private void tblEntradas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                tblEntradas.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void tblEntradas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
            string headerText = tblEntradas.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("Entradas")) return;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                tblEntradas.Rows[e.RowIndex].ErrorText =
                    "No puedes dejar vacia esta celda";
                e.Cancel = true;
            }
          
        }
        int n = 0;
        private void tblEntradas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                n = 0;
                if (tblEntradas.Rows.Count > 0)
                {

                    for (int i = 0; i < tblEntradas[4, e.RowIndex].Value.ToString().Length; i++)
                    {
                        if (tblEntradas[4, e.RowIndex].Value.ToString().Substring(i, 1) == ".")
                        {
                            n++;
                        }

                    }
                    if (n < 2)
                    {
                        if (tblEntradas[4, e.RowIndex].Value.ToString().Equals("."))
                        {
                            tblEntradas[4, e.RowIndex].Value = Convert.ToDouble(0.00);
                        }
                        else
                        {
                            if (Convert.ToDouble(tblEntradas[3, e.RowIndex].Value) >= Convert.ToDouble(tblEntradas[4, e.RowIndex].Value))
                            {
                                if (Convert.ToDouble(tblEntradas[4, tblEntradas.CurrentRow.Index].Value) >= 0)
                                {
                                    tblEntradas[5, e.RowIndex].Value = Convert.ToDouble(tblEntradas[3, e.RowIndex].Value) - Convert.ToDouble(tblEntradas[4, e.RowIndex].Value);
                                   //tblEntradas[8, e.RowIndex].Value = (Convert.ToDouble(tblEntradas[5, e.RowIndex].Value) * Convert.ToDouble(tblEntradas[6, e.RowIndex].Value)) - Convert.ToDouble(tblEntradas[7, e.RowIndex].Value);

                                }
                                else
                                {
                                    MessageBox.Show("No se puede ingresar numeros negativos");
                                    tblEntradas[4, e.RowIndex].Value = Convert.ToDouble(tblEntradas[3, e.RowIndex].Value);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La cantidad de entrada no puede ser mayor al inventario de vendedor");
                                tblEntradas[4, e.RowIndex].Value = Convert.ToDouble(tblEntradas[3, e.RowIndex].Value);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Solo puede agregar 1 punto decimal");
                        tblEntradas[4, e.RowIndex].Value = Convert.ToDouble(0.00);
                    }
                 
                    //SumaTotal();
                }
                sumaTotal();
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
        }

        private void tblEntradas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(tblEntradas_KeyPress);
        }

        private void tblEntradas_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (tblEntradas.CurrentCell.ColumnIndex == 4)
                {
                    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
                    {

                        e.Handled = true;

                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int i, col1, col2, col3, col4, col5, col6, col7, col8, col9, x, y, L;
        //double suma = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            if (tblEntradas.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width / 2;
                int an = 15;
                //int width = 0;
                Font letra = new Font("Arial", 9);
                x = 30;
                y = 125;
                L = 30;
                col1 = tblEntradas.Columns[1].Width-an;
                col2 = tblEntradas.Columns[2].Width-an;
                col3 = tblEntradas.Columns[3].Width-an;
                col4 = tblEntradas.Columns[4].Width-an;
                col5 = tblEntradas.Columns[5].Width-an;
                col6 = tblEntradas.Columns[6].Width-an;
                col7 = tblEntradas.Columns[7].Width-an;
                col8 = tblEntradas.Columns[8].Width - an;
                col9 = tblEntradas.Columns[9].Width - an;

                #region titulo
                e.Graphics.DrawString("VENTAS VENDEDOR", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 2 + 40, 50, 500, tblEntradas.Rows[0].Height + 15));
                #endregion

                #region NombreVendedor
                e.Graphics.DrawString("Vendedor: " + tbxNVendedor.Text, new Font("Arial", 9), Brushes.Black, new Rectangle(x, 105, 500, tblEntradas.Rows[0].Height + 15));
                #endregion

                #region fecha
                e.Graphics.DrawString(dtpFecha.Value.ToString("dd/MMMM/yyyy"), new Font("Arial", 9), Brushes.Black, new Rectangle(e.MarginBounds.Width + 32, 105, 500, tblEntradas.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60, 100, col1, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, tblEntradas.Rows[0].Height + 15));

                #endregion

                #region Descripcion

                //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1, 100, col2 + 100, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2 + 100, tblEntradas.Rows[0].Height + 15));

                #endregion

                #region Salidas
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2, 100, col3, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, tblEntradas.Rows[0].Height + 15));


                #endregion

                #region InventarioVendedor

                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, tblEntradas.Rows[0].Height + 15));

                #endregion

                #region CantidadTotal

                //           e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4, 100, col5, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[5].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblEntradas.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblEntradas.Rows[1].Height);
                #endregion

                #region precio

                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4 + col5, 100, col6, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[6].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblEntradas.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblEntradas.Rows[1].Height);
                #endregion

                #region SubTotal

                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4 + col5 + col6, 100, col7, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[7].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, tblEntradas.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblEntradas.Rows[1].Height);
                #endregion

                #region Descuento

                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4 + col5 + col6, 100, col7, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[8].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, tblEntradas.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblEntradas.Rows[1].Height);
                #endregion

                #region precioTotal

                //            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3 + col4 + col5 + col6, 100, col7, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7 + col8, y, col9, tblEntradas.Rows[0].Height + 15));
                e.Graphics.DrawString(tblEntradas.Columns[9].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7 + col8, y, col9, tblEntradas.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblEntradas.Rows[1].Height);
                #endregion

                height = 145;

                while (i < tblEntradas.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 145;
                        e.HasMorePages = true;
                        return;
                    }
                    if (cbxCEntradas.Text == "Todas")
                    {

                        height += tblEntradas.Rows[0].Height;

                        //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblEntradas.Columns[1].Width, tblEntradas.Rows[0].Height));
                        e.Graphics.DrawString(tblEntradas.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, tblEntradas.Columns[1].Width, tblEntradas.Rows[0].Height));

                        if (tblEntradas.Rows[i].Cells[2].FormattedValue.ToString().Length > 40)
                        {
                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[2].FormattedValue.ToString().Substring(0, 40), letra, Brushes.Black, new Rectangle(L + col1, height, tblEntradas.Columns[2].Width, tblEntradas.Rows[0].Height));
                        }
                        else
                        {
                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, tblEntradas.Columns[2].Width, tblEntradas.Rows[0].Height));
                        }
                        //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[3].Width, tblEntradas.Rows[0].Height));
                        e.Graphics.DrawString(tblEntradas.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, tblEntradas.Columns[3].Width, tblEntradas.Rows[0].Height));

                        //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[4].Width, tblEntradas.Rows[0].Height));
                        e.Graphics.DrawString(tblEntradas.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblEntradas.Columns[4].Width, tblEntradas.Rows[0].Height));

                        //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[5].Width, tblEntradas.Rows[0].Height));
                        e.Graphics.DrawString(tblEntradas.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblEntradas.Columns[5].Width, tblEntradas.Rows[0].Height));

                        e.Graphics.DrawString(tblEntradas.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, tblEntradas.Columns[6].Width, tblEntradas.Rows[0].Height));

                        e.Graphics.DrawString(tblEntradas.Rows[i].Cells[7].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, tblEntradas.Columns[7].Width, tblEntradas.Rows[0].Height));

                        e.Graphics.DrawString(tblEntradas.Rows[i].Cells[8].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7, height, tblEntradas.Columns[8].Width, tblEntradas.Rows[0].Height));


                        e.Graphics.DrawString(tblEntradas.Rows[i].Cells[9].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7 + col8, height, tblEntradas.Columns[9].Width, tblEntradas.Rows[0].Height));

                        //suma += Convert.ToDouble(tblEntradas.Rows[i].Cells[7].Value);
                        i++;
                    }
                    else if (cbxCEntradas.Text == "Con entradas")
                    {
                        if (Convert.ToDouble(tblEntradas.Rows[i].Cells[4].Value) > 0)
                        {
                            height += tblEntradas.Rows[0].Height;

                            //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblEntradas.Columns[1].Width, tblEntradas.Rows[0].Height));
                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, tblEntradas.Columns[1].Width, tblEntradas.Rows[0].Height));

                            if (tblEntradas.Rows[i].Cells[2].FormattedValue.ToString().Length > 40)
                            {
                                e.Graphics.DrawString(tblEntradas.Rows[i].Cells[2].FormattedValue.ToString().Substring(0, 40), letra, Brushes.Black, new Rectangle(L + col1, height, tblEntradas.Columns[2].Width, tblEntradas.Rows[0].Height));
                            }
                            else
                            {
                                e.Graphics.DrawString(tblEntradas.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, tblEntradas.Columns[2].Width, tblEntradas.Rows[0].Height));
                            }
                            //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[3].Width, tblEntradas.Rows[0].Height));
                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, tblEntradas.Columns[3].Width, tblEntradas.Rows[0].Height));

                            //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[4].Width, tblEntradas.Rows[0].Height));
                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblEntradas.Columns[4].Width, tblEntradas.Rows[0].Height));

                            //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[5].Width, tblEntradas.Rows[0].Height));
                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblEntradas.Columns[5].Width, tblEntradas.Rows[0].Height));

                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, tblEntradas.Columns[6].Width, tblEntradas.Rows[0].Height));

                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[7].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, tblEntradas.Columns[7].Width, tblEntradas.Rows[0].Height));

                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[8].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7, height, tblEntradas.Columns[8].Width, tblEntradas.Rows[0].Height));


                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[9].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7 + col8, height, tblEntradas.Columns[9].Width, tblEntradas.Rows[0].Height));
                            //suma += Convert.ToDouble(tblEntradas.Rows[i].Cells[7].Value);
                        }
                        i++;
                    }
                    else
                    {

                        if (Convert.ToDouble(tblEntradas.Rows[i].Cells[5].Value) > 0)
                        {
                            height += tblEntradas.Rows[0].Height;

                            //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblEntradas.Columns[1].Width, tblEntradas.Rows[0].Height));
                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, tblEntradas.Columns[1].Width, tblEntradas.Rows[0].Height));

                            if (tblEntradas.Rows[i].Cells[2].FormattedValue.ToString().Length > 40)
                            {
                                e.Graphics.DrawString(tblEntradas.Rows[i].Cells[2].FormattedValue.ToString().Substring(0, 40), letra, Brushes.Black, new Rectangle(L + col1, height, tblEntradas.Columns[2].Width, tblEntradas.Rows[0].Height));
                            }
                            else
                            {
                                e.Graphics.DrawString(tblEntradas.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, tblEntradas.Columns[2].Width, tblEntradas.Rows[0].Height));
                            }
                            //          e.Graphics.DrawRectangle(p, new Rectangle(300 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[3].Width, tblEntradas.Rows[0].Height));
                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, tblEntradas.Columns[3].Width, tblEntradas.Rows[0].Height));

                            //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[4].Width, tblEntradas.Rows[0].Height));
                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblEntradas.Columns[4].Width, tblEntradas.Rows[0].Height));

                            //                    e.Graphics.DrawRectangle(p, new Rectangle(500 + tblEntradas.Columns[1].Width, height, tblEntradas.Columns[5].Width, tblEntradas.Rows[0].Height));
                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblEntradas.Columns[5].Width, tblEntradas.Rows[0].Height));

                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, tblEntradas.Columns[6].Width, tblEntradas.Rows[0].Height));

                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[7].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, tblEntradas.Columns[7].Width, tblEntradas.Rows[0].Height));

                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[8].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7, height, tblEntradas.Columns[8].Width, tblEntradas.Rows[0].Height));


                            e.Graphics.DrawString(tblEntradas.Rows[i].Cells[9].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7 + col8, height, tblEntradas.Columns[9].Width, tblEntradas.Rows[0].Height));
                            //suma += Convert.ToDouble(tblEntradas.Rows[i].Cells[7].Value);
                        }
                        i++;
                    }
                }
                //e.Graphics.DrawString("Total", letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height + 20, tblEntradas.Columns[6].Width, tblEntradas.Rows[0].Height));

                //e.Graphics.DrawString("$" + suma, letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height + 20, tblEntradas.Columns[7].Width, tblEntradas.Rows[0].Height));
                i = 0;
                //suma = 0;
                e.HasMorePages = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
            {
                ventaInesperada VI = new ventaInesperada(tbxVendedor.Text,UsuarioID,Conexion);
                VI.ShowDialog();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoCliente();
            }
            else
            if (e.KeyValue == 112)
            {
                BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCCliente.Text = id.regresar.valXn;
                }
                tbxCCliente.Focus();
                MetodoCliente();
            }
        }
        public void MetodoCliente()
        {
            ObtnerCliente();

            if (tbxCCliente.Text != "")
            {
                tblEntradas.Rows.Clear();
                //tblEntradas.AllowUserToDeleteRows = true;
                //tblEntradas.Rows.Add(false, "-", "-", "-", "-", "-", "Subtotal", 0, "-", "-");
                //tblEntradas.Rows.Add(false, "-", "-", "-", "-", "-", "IVA", 0, "-", "-");
                //tblEntradas.Rows.Add(false, "-", "-", "-", "-", "-", "Total", 0, 0, "-", "-");
                //tblEntradas[0, tblEntradas.Rows.Count - 1].ReadOnly = true;
                //tblEntradas.Rows[tblEntradas.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                tblEntradas.Columns[4].Visible = false;
                tblEntradas.Columns[7].Visible = true;
                activos();
                tbxProducto.Focus();
                tbxCCliente.Enabled = false;
                btnSC.Enabled = false;
                // SumaTotal();
                panel1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCCliente.Text = id.regresar.valXn;
            }
            tbxCCliente.Focus();
            MetodoCliente();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarArticulosVendedor id = new BuscarArticulosVendedor(tbxVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxProducto.Text = id.regresar.valXn;
            }
            tbxProducto.Focus();
            MetodoProducto();
        }
        double PProduccion = 0;
        int Depa = 0;

        public void obtenerProducto()
        {
            if (tbxProducto.Text != "")
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre, a.cantidad,a.precioproduccion,a.departamento " +
                            "FROM articulos a, unidad_medida u WHERE codigo =" + tbxProducto.Text + " and a.unidad_medida_id=u.id", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    PProduccion = lector.GetDouble(5);
                    tbxNombre.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    des = lector.GetString(0);
                    
                }
                conectar.Close();
                conectar.Open();
                comando = new MySqlCommand("SELECT cantidad " +
                           "FROM inv_vendedor WHERE articulos_codigo =" + tbxProducto.Text + " and empleados_id_empleado="+tbxVendedor.Text+"", conectar);
                lector = comando.ExecuteReader();
             
                while (lector.Read())
                {
                    
                    tbxExistencias.Text = lector.GetString(0);
                    des = lector.GetString(0);

                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de producto no existente");
                    tbxProducto.Clear();
                    tbxNombre.Clear();
                    tbxProducto.Focus();
                    tbxExistencias.Clear();

                }
            }
        }
        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoProducto();
            }
            else
            if (e.KeyValue == 112)
            {
                BuscarArticulosVendedor id = new BuscarArticulosVendedor(tbxVendedor.Text);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxProducto.Text = id.regresar.valXn;
                }
                tbxProducto.Focus();
                MetodoProducto();
            }
        }
        public void MetodoProducto()
        {
            obtenerProducto();
            if (tbxProducto.Text != "")
            {
                tbxCantidad.Focus();
            }
        }
        public Boolean aplicaDescuento()
        {
            int n = 0;
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select * from clientes where DerechoADescuento=1 and idclientes=" + tbxCCliente.Text, conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                n++;
            }
            conectar.Close();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        double descuento = 0;
        private void btnAC_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (tbxProducto.Text != "" && tbxCantidad.Text != "")
                {
                    if (rbtContado.Checked)
                    {
                        #region contado
                        if (tblEntradas.Rows.Count > 0)
                        {
                            for (int i = 0; i < tblEntradas.Rows.Count-1; i++)
                            {
                                if (tblEntradas[1, i].Value.ToString() == tbxProducto.Text)
                                {

                                    MessageBox.Show("No puede agregar 2 veces un producto");
                                    tbxCantidad.Text = "";
                                    tbxCantidad.Focus();
                                }


                            }
                        }
                        obtenerProducto();
                        if (tbxProducto.Text != "")
                        {
                            string precio_cliente = "";
                            if (rbtnAbarrotes.Checked)
                            {
                                precio_cliente = "a.precio_abarrotes ";
                                descuento = 0;
                                categoria = "7";
                                
                            }
                            else if (rbtnDistribuidor.Checked)
                            {
                                precio_cliente = "a.precio_distribuidor ";
                                descuento = 0;
                                categoria = "8";
                            }
                            else if (rbtnGeneral.Checked)
                            {
                                precio_cliente = "a.precio_calle ";
                                categoria = "9";
                                
                            }
                            if (tbxCCliente.Text.Length > 0 && tbxCantidad.Text.Length>0 )
                            {
                                if (aplicaDescuento() && categoria == "7")
                                {
                                    double precio = 0, descArticulo = 0;
                                    conectar = conn.ObtenerConexion();
                                    comando = new MySqlCommand("select " + precio_cliente + ", a.Descuento from articulos a where codigo=" + tbxProducto.Text, conectar);
                                    conectar.Open();
                                    lector = comando.ExecuteReader();
                                    while (lector.Read())
                                    {
                                        precio = lector.GetDouble(0);
                                        descArticulo = lector.GetDouble(1);
                                    }
                                    conectar.Close();
                                    descuento = Convert.ToDouble(tbxCantidad.Text) * precio * (descArticulo / 100);
                                }
                                else
                                {
                                    descuento = 0;
                                }
                            }
                            conectar = conn.ObtenerConexion();

                            if (tbxVendedor.Text != "1")
                            {
                                comando = new MySqlCommand("SELECT i.articulos_codigo, a.descripcion, a.valor_medida, u.nombre," +
                                    " i.cantidad," + precio_cliente + ", a.departamento FROM inv_vendedor i, articulos a, unidad_medida u" +
                                    " WHERE  i.empleados_id_empleado =" + tbxVendedor.Text + " and i.articulos_codigo=" + tbxProducto.Text +
                                    " AND i.articulos_codigo = a.codigo AND a.unidad_medida_id = u.id" +
                                    " order by articulos_codigo asc", conectar);
                                conectar.Open();

                                lector = comando.ExecuteReader();
                                while (lector.Read())
                                {
                                    if (tbxCantidad.Text != "")
                                    {
                                        if (tbxCantidad.Text == ".")
                                        {
                                            MessageBox.Show("Verifica la cantidad de producto a agregar");
                                            tbxCantidad.Focus();
                                        }
                                        else
                                        {
                                            if (rbtnDistribuidor.Checked)
                                            {
                                                descuento = 0;
                                            }
                                            double entradas = lector.GetDouble(4) - Convert.ToDouble(tbxCantidad.Text);
                                            double cantidadVendida = lector.GetDouble(4) - entradas;
                                            double total = (lector.GetDouble(5) * cantidadVendida)-descuento;
                                            if (entradas >= 0)
                                            {

                                                if (lector.GetString(6) == "2")
                                                {
                                                    categoria = "6";
                                                }
                                                else if (lector.GetString(6) == "3")
                                                {
                                                    categoria = "10";
                                                }
                                                tblEntradas.Rows.Add(false, lector.GetString(0), lector.GetString(1) + " " +
                                                    lector.GetString(2) + " " + lector.GetString(3), lector.GetString(4), entradas, cantidadVendida, lector.GetDouble(5),cantidadVendida*lector.GetDouble(5), descuento, total, tbxVendedor.Text, PProduccion, categoria);
                                                tbxProducto.Clear();
                                                tbxCantidad.Clear();
                                                tbxNombre.Clear();
                                                tbxExistencias.Clear();
                                                tbxProducto.Focus();
                                                
                                            }
                                            else
                                            {
                                                MessageBox.Show("No hay suficiente en el inventario del vendedor para cubrir esa cantidad");
                                                tbxCantidad.Clear();
                                            }
                                        }
                                    }
                                }
                                conectar.Close();
                                
                                tbxCantidad.Clear();
                            }
                            else
                            {
                                //Hay que analizar bien esta seccion de codigo para ver q realiza
                                string prec = "";
                                if (idCategoria == 1) { prec = ",a.precio_calle"; }
                                if (idCategoria == 2) { prec = ",a.precio_abarrotes"; }
                                if (idCategoria == 3) { prec = ",a.precio_distribuidor"; }
                                comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre," +
                                    " a.cantidad" + prec + " FROM articulos a, unidad_medida u" +
                                    " WHERE codigo=" + tbxProducto.Text +
                                    " AND a.unidad_medida_id = u.id" +
                                    " order by codigo asc", conectar);
                                conectar.Open();
                                lector = comando.ExecuteReader();

                                while (lector.Read())
                                {
                                    if (tbxCantidad.Text != "")
                                    {

                                        double entradas = lector.GetDouble(4) - Convert.ToDouble(tbxCantidad.Text);
                                        double cantidadVendida = lector.GetDouble(4) - entradas;
                                        double total = lector.GetDouble(5) * cantidadVendida;
                                        if (entradas >= 0)
                                        {
                                            tblEntradas.Rows.Add(false, lector.GetString(0), lector.GetString(1) + " " +
                                                lector.GetString(2) + " " + lector.GetString(3), lector.GetString(4), entradas, cantidadVendida, lector.GetString(5),0, total, tbxVendedor.Text, PProduccion, dtpFecha.Value.ToString("yyyyMMddHHmmss"));
                                            
                                        }
                                        else
                                        {
                                            MessageBox.Show("No hay suficiente en el inventario del vendedor para cubrir esa cantidad");
                                            tbxCantidad.Clear();
                                        }


                                    }
                                }
                                conectar.Close();
                                tbxCantidad.Clear();
                                tbxProducto.Focus();
                            }
                            if (tblEntradas.Rows.Count > 0)
                            {
                                sumaTotal();
                                Totls();
                                CalcularDescuentosDistribuidor();
                            }
                        }
                        #endregion
                    }
                    else if (rbtCredito.Checked)
                    {
                       
                       
                            #region credito
                            if (tblCredito.Rows.Count > 0)
                            {
                                for (int i = 0; i < tblCredito.Rows.Count; i++)
                                {
                                    if (tblCredito[1, i].Value.ToString() == tbxProducto.Text)
                                    {

                                        MessageBox.Show("No puede agregar 2 veces un producto");
                                        tbxCantidad.Text = "";
                                        tbxCantidad.Focus();
                                    }
                                }

                            }
                            obtenerProducto();
                            if (tbxProducto.Text != "")
                            {
                                string precio_cliente = "";
                                if (rbtnAbarrotes.Checked)
                                {
                                    precio_cliente = "a.precio_abarrotes ";
                                    categoria = "7";
                                }
                                else if (rbtnDistribuidor.Checked)
                                {
                                    precio_cliente = "a.precio_distribuidor ";
                                    categoria = "8";
                                }
                                else if (rbtnGeneral.Checked)
                                {
                                    precio_cliente = "a.precio_calle ";
                                    categoria = "9";
                                }
                                conectar = conn.ObtenerConexion();

                                if (tbxVendedor.Text != "1")
                                {
                                    comando = new MySqlCommand("SELECT i.articulos_codigo, a.descripcion, a.valor_medida, u.nombre," +
                                        " i.cantidad," + precio_cliente + ", a.departamento FROM inv_vendedor i, articulos a, unidad_medida u" +
                                        " WHERE  empleados_id_empleado =" + tbxVendedor.Text + " and articulos_codigo=" + tbxProducto.Text +
                                        " AND i.articulos_codigo = a.codigo AND a.unidad_medida_id = u.id" +
                                        " order by articulos_codigo asc", conectar);
                                    conectar.Open();

                                    lector = comando.ExecuteReader();

                                    while (lector.Read())
                                    {
                                        if (tbxCantidad.Text != "")
                                        {
                                            if (tbxCantidad.Text == ".")
                                            {
                                                MessageBox.Show("Verifica la cantidad de producto a agregar");
                                                tbxCantidad.Focus();
                                            }
                                            else
                                            {
                                                double existVendedor = lector.GetDouble(4) - Convert.ToDouble(tbxCantidad.Text);
                                                double total = lector.GetDouble(5) * Convert.ToDouble(tbxCantidad.Text);
                                                if (existVendedor >= 0)
                                                {
                                                    if (lector.GetString(6) == "2")
                                                    {
                                                        categoria = "6";
                                                    }
                                                    else if (lector.GetString(6) == "3")
                                                    {
                                                        categoria = "10";
                                                    }
                                                    tblCredito.Rows.Insert(tblCredito.Rows.Count - 1, false, lector.GetString(0), lector.GetString(1) + " " +
                                                        lector.GetString(2) + " " + lector.GetString(3), Convert.ToDouble(tbxCantidad.Text), lector.GetDouble(5), total, 0, total, tbxVendedor.Text, PProduccion, lector.GetDouble(4), categoria);
                                                    tbxProducto.Clear();
                                                    tbxCantidad.Clear();
                                                    tbxNombre.Clear();
                                                    tbxExistencias.Clear();
                                                    tbxProducto.Focus();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("El vendedor no tiene suficiente inventario.");
                                                }
                                            }
                                        }
                                    }
                                    conectar.Close();
                                    tbxCantidad.Clear();
                                }
                            }
                            #endregion
                           // actImpuestos();
                            sumaTotal();
                        
                    }
                }

                if (idCategoria == 9)
                {
                    rbtnGeneral.Checked = true;
                }
                else if (idCategoria == 8)
                {
                    rbtnDistribuidor.Checked = true;
                }
                else if (idCategoria == 7)
                {
                    rbtnAbarrotes.Checked = true;
                }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    DescuentosBO objDescuentos = new DescuentosBO();
        //    List<CArticulos> objListArticulos = new List<CArticulos>();
        //    objListArticulos = listaProductos();
        //    int ClienteID = Convert.ToInt32(tbxCCliente.Text);
        //    objDescuentos.CalcularDescuentos(ref objListArticulos, ClienteID);

        //    for (int i = 0; i < tblEntradas.Rows.Count - 1; i++)
        //    {
        //        double descuento = objListArticulos.Where(x => x.Codigo == Convert.ToInt32(tblEntradas.Rows[i].Cells[1].Value)).First().Descuento;
        //        tblEntradas.Rows[i].Cells[8].Value = descuento;
        //    }
        //    tblEntradas.Refresh();
        //}
        public Boolean ValidarHayProductosDistribuidor()
        {
            Boolean bHayProductos = false;
            List<CArticulos> objListArticulos = new List<CArticulos>();
            objListArticulos = listaProductos();

            if (objListArticulos.Count > 0)
            {
                bHayProductos = true;
            }
            return bHayProductos;
        }
        public void CalcularDescuentosDistribuidor()
        {
            DescuentosBO objDescuentos = new DescuentosBO();
            List<CArticulos> objListArticulos = new List<CArticulos>();

            Boolean  bHayProductos = ValidarHayProductosDistribuidor();

            if (!bAutorizacionDescDistribuidor && bAutorizar)
            {
                if (bHayProductos)
                {
                    string Respuesta = "";
                    inicioSesion id = new inicioSesion("", "Autorizar descuentos distribuidor");
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        bAutorizacionDescDistribuidor = true;
                    }
                    bAutorizar = false;
                }             
            }
           

            if (bAutorizacionDescDistribuidor)
            {
                objListArticulos = listaProductos();
                int ClienteID = Convert.ToInt32(tbxCCliente.Text);
                objDescuentos.CalcularDescuentos(ref objListArticulos, ClienteID);
                double total = 0, subtotal = 0;

                for (int i = 0; i < tblEntradas.Rows.Count - 1; i++)
                {
                    try
                    {
                        double descuento = objListArticulos.Where(x => x.Codigo == Convert.ToInt32(tblEntradas.Rows[i].Cells[1].Value)).First().Descuento;
                        tblEntradas.Rows[i].Cells[8].Value = descuento;
                        if (descuento > 0)
                        {
                            tblEntradas.Rows[i].Cells[8].Style.Format = "0.00\\%";
                            subtotal = Convert.ToDouble(tblEntradas.Rows[i].Cells[5].Value) * Convert.ToDouble(tblEntradas.Rows[i].Cells[6].Value);
                            total = subtotal - (subtotal * (descuento / 100));
                            tblEntradas.Rows[i].Cells[9].Value = total;
                        }
                    }
                    catch { }

                }

                sumaTotal();
                Totls();
                tblEntradas.Refresh();
            }          
        }

        public Boolean CreditoPendiente()
        {
            Boolean bAllOk = false;
            double pendiente = 0;
            DataTable Tabla = new DataTable();
            cmd = String.Format("select COALESCE(sum(pendiente),0) as pendiente from ventas where clientes_idclientes = {0} and pendiente>0", tbxCCliente.Text);
            Conexion.Conectarse();
            Conexion.Ejecutar(cmd, ref Tabla);
            Conexion.Desconectarse();
            if(Tabla.Rows.Count>0)
            {
                DataRow row = Tabla.Rows[0];
                pendiente = Convert.ToDouble(row["pendiente"]);
            }
            if(pendiente>0)
            {
                bAllOk = true;
            }
            return bAllOk;
        }

        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                
                if (tbxCantidad.Text != ""&&tbxCantidad.Text!=".")
                {
                    if (Convert.ToDouble(tbxCantidad.Text) > 0)
                    {
                        btnAC.Focus();
                    }
                    
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (rbtContado.Checked)
            {
                List<DataGridViewRow> list = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in tblEntradas.Rows)
                {
                    
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                        list.Add(row);
                }
                foreach (DataGridViewRow row in list)
                {
                    tblEntradas.Rows.Remove(row);
                }
                sumaTotal();
                Totls();
            }
            else if (rbtCredito.Checked)
            {
                List<DataGridViewRow> list = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in tblCredito.Rows)
                {
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                        list.Add(row);
                }
                foreach (DataGridViewRow row in list)
                {
                    tblCredito.Rows.Remove(row);
                }
                sumaTotal();
                
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tblEntradas.AllowUserToDeleteRows = false;
            tblEntradas.Visible = true;
            tblCredito.Visible = false;
            rbtCredito.Enabled = false;
            rbtContado.Enabled = false;
            rbtCredito.Checked = false;
            rbtContado.Checked = true;
            tblEntradas.Columns[4].Visible = true;
            tblEntradas.Columns[7].Visible = false;
            tblEntradas.Columns[4].ReadOnly = false;
            tbxExistencias.Clear();
            tblEntradas.Rows.Clear();
            tbxCCliente.Enabled = true;
            btnSC.Enabled = true;
            tbxProducto.Clear();
            tbxNombre.Clear();
            tbxCantidad.Clear();
            tbxCCliente.Clear();
            tbxNCliente.Clear();
            tbxProducto.Enabled = false;
            btnSP.Enabled = false;
            btnAC.Enabled = false;
            btnEliminar.Enabled = false;
            tbxCantidad.Enabled = false;
            tbxIVA.Clear();
            tbxSubtotal.Clear();
            tbxTotal.Clear();
            obtenerVendedor();
            sumaTotal();
            panel1.Enabled = false;
            tbxCCliente.Focus();
            bAutorizacionDescDistribuidor = false;
            bAutorizar = true;
        }

        private void tbxCCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnReporteDiario_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
            {
                ConsultaCancelaVentas rdv = new ConsultaCancelaVentas(Conexion,tbxVendedor.Text,Convert.ToInt32(UsuarioID));
                rdv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Primero es necesario ingresar un vendedor.");
            }
            
        }

        private void btnConversiones_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
            {
                Conversiones CN = new Conversiones(tbxVendedor.Text,UsuarioID,Conexion);
                CN.ShowDialog();
            }
        }

        private void btnTransferencias_Click(object sender, EventArgs e)
        {
            transferenciasInventario trf = new transferenciasInventario(Conexion,UsuarioID);
            trf.ShowDialog();
        }
        
        private void tblEntradas_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            try
            {
                if (e.RowIndex2 < tblEntradas.Rows.Count - 1 && e.RowIndex1 < tblEntradas.Rows.Count - 1)
                {
                    // Try to sort based on the cells in the current column.
                    e.SortResult = System.String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
                }

                // If the cells are equal, sort based on the ID column.
                if (e.Column.Name == "dgvCodArtS" && e.RowIndex2 < tblEntradas.Rows.Count - 1 && e.RowIndex1 < tblEntradas.Rows.Count - 1)
                {
                    e.SortResult = comparar(Convert.ToInt32(tblEntradas.Rows[e.RowIndex1].Cells["dgvCodArtS"].Value.ToString()),
                        Convert.ToInt32(tblEntradas.Rows[e.RowIndex2].Cells["dgvCodArtS"].Value.ToString()));
                }
                if (e.Column.Name == "invVendedor" && e.RowIndex2 < tblEntradas.Rows.Count - 1 && e.RowIndex1 < tblEntradas.Rows.Count - 1)
                {
                    e.SortResult = comparar(Convert.ToDouble(tblEntradas.Rows[e.RowIndex1].Cells["invVendedor"].Value.ToString()),
                        Convert.ToDouble(tblEntradas.Rows[e.RowIndex2].Cells["invVendedor"].Value.ToString()));
                }

                if (e.Column.Name == "n_Entrada" && e.RowIndex2 < tblEntradas.Rows.Count - 1 && e.RowIndex1 < tblEntradas.Rows.Count - 1)
                {
                    e.SortResult = comparar(Convert.ToDouble(tblEntradas.Rows[e.RowIndex1].Cells["n_Entrada"].Value.ToString()),
                        Convert.ToDouble(tblEntradas.Rows[e.RowIndex2].Cells["n_Entrada"].Value.ToString()));
                }

                if (e.Column.Name == "EVendidas" && e.RowIndex2 < tblEntradas.Rows.Count - 1 && e.RowIndex1 < tblEntradas.Rows.Count - 1)
                {
                    e.SortResult = comparar(Convert.ToDouble(tblEntradas.Rows[e.RowIndex1].Cells["EVendidas"].Value.ToString()),
                        Convert.ToDouble(tblEntradas.Rows[e.RowIndex2].Cells["EVendidas"].Value.ToString()));
                }
                if (e.Column.Name == "EPrecio" && e.RowIndex2 < tblEntradas.Rows.Count - 1 && e.RowIndex1 < tblEntradas.Rows.Count - 1)
                {
                    e.SortResult = comparar(Convert.ToDouble(tblEntradas.Rows[e.RowIndex1].Cells["EPrecio"].Value.ToString()),
                        Convert.ToDouble(tblEntradas.Rows[e.RowIndex2].Cells["EPrecio"].Value.ToString()));
                }
                if (e.Column.Name == "ETotal" && e.RowIndex2 < tblEntradas.Rows.Count - 1 && e.RowIndex1 < tblEntradas.Rows.Count - 1)
                {
                    e.SortResult = comparar(Convert.ToDouble(tblEntradas.Rows[e.RowIndex1].Cells["ETotal"].Value.ToString()),
                        Convert.ToDouble(tblEntradas.Rows[e.RowIndex2].Cells["ETotal"].Value.ToString()));
                }
                e.Handled = true;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (tbxVendedor.Text == "" && tbxCCliente.Text == "")
            {
                CobranzaCredito cobcr = new CobranzaCredito(Conexion);
                cobcr.ShowDialog();
            }
            else if (tbxVendedor.Text != "" && tbxCCliente.Text == "")
            {
                CobranzaCredito cobcr = new CobranzaCredito(tbxVendedor.Text, Conexion);
                cobcr.ShowDialog();
            }
            else if (tbxVendedor.Text != "" && tbxCCliente.Text != "")
            {
                CobranzaCredito cobcr = new CobranzaCredito(tbxVendedor.Text, tbxCCliente.Text, Conexion);
                cobcr.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Corte_de_Caja cort = new Corte_de_Caja(Conexion);
            cort.ShowDialog();
        }
        public int foliosCredito()
        {
            int folio=0;
            conectar=conn.ObtenerConexion();
            comando=new MySqlCommand("insert into Folios_creditos values(null)",conectar);
               conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
            
            comando=new MySqlCommand("select * from Folios_creditos order by idFolios_creditos desc",conectar);
            conectar.Open();
            folio=(Int32)comando.ExecuteScalar();
            conectar.Close();
            return folio;

        }
        public static Boolean aut = false;
        public Boolean AutorizacionCredito()
        {
            Boolean aceptado = false;
            double restoCredito = Convert.ToDouble(tbxCreditoRestante.Text) - Convert.ToDouble(tbxTotal.Text);
            if (restoCredito > 0)
            {
                aceptado = true;
            }
            else
            {
                MessageBox.Show("Ha sobrepasado el límite de crédito permitido, por lo que se requiere autorización especial.");
                Autorizaciones aut = new Autorizaciones("AutorizarCredito", Conexion);
                aut.ShowDialog();
                aceptado = VentasDLocal.aut;

            }
            return aceptado;
        }
        string abono, pendiente;
        int nuevoFolio=0;
        private void btnRegistrarS_Click_1(object sender, EventArgs e)
        {
            Conexion.Conectarse();
            Conexion.IniciarTransaccion();
            Boolean bAllOK = false;
            if (rbtContado.Checked)
            {
                #region RegistroContado
                if (tblEntradas.Rows.Count > 0)
                {
                    result = MessageBox.Show("Se van a registrar las entradas ¿Desea continuar?", "Registrar entradas", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Fechaa = dtpFecha.Value.ToString("yyyyMMddHHmmss");
                        nuevoFolio = foliosCredito();
                        for (int i = 0; i < tblEntradas.Rows.Count-1; i++)
                        {
                            cod_empleado = tbxVendedor.Text;
                            cod_art = tblEntradas[1, i].Value.ToString();
                            inv_anterior = tblEntradas[3, i].Value.ToString();
                            n_entradas = tblEntradas[4, i].Value.ToString();
                            n_venta = tblEntradas[5, i].Value.ToString();                           
                            precio_A = Convert.ToDouble(tblEntradas[6, i].Value);
                            descuento = Convert.ToDouble(tblEntradas[8, i].Value.ToString());
                            importe = tblEntradas[9, i].Value.ToString();
                            costoP = Convert.ToDouble(tblEntradas[11, i].Value);
                            verificarYEliminar();
                          bAllOK=  Conexion.Ejecutar("INSERT INTO entradas values(null," + n_entradas + ",'" + dtpFecha.Value.ToString("yyyyMMdd") + "'," + cod_empleado + "," + cod_art + "," + inv_anterior + ")");
                         
                            if (Convert.ToDouble(n_venta) > 0)
                            {
                                if (tbxVendedor.Text != "1")
                                {
                                   bAllOK= Conexion.Ejecutar("UPDATE inv_vendedor SET cantidad=cantidad-" + n_venta + " WHERE empleados_id_empleado=" + cod_empleado + " AND articulos_codigo=" + cod_art);
                                  
                                    cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                      " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                      " VALUES({0},{1},'{2}','{3}',{4},{5},{6},{7})",
                                      cod_art, n_venta, "Ventas", dtpFecha.Value.ToString("yyyyMMddHHmmss"),
                                      inv_anterior, Convert.ToDouble(inv_anterior)-Convert.ToDouble(n_venta), tbxVendedor.Text, UsuarioID);
                                   bAllOK= Conexion.Ejecutar(cmd);
                                }
                                else
                                {
                                  bAllOK=  Conexion.Ejecutar("UPDATE articulos SET cantidad=cantidad-" + n_venta + " WHERE codigo=" + cod_art);
                                }


                                //obtenerProducto2();
                                DataTable DepaT=new DataTable();
                                bAllOK=Conexion.Ejecutar("SELECT departamento FROM articulos WHERE codigo =" + cod_art, ref DepaT);


                                Depa = Convert.ToInt32(DepaT.Rows[0][0]);
                                DepaT.Rows.Clear();

                                if (tbxCCliente.Text == "")
                                {

                                    idCliente = 1;

                                    DataTable ClientDefau = new DataTable();
                                    bAllOK = Conexion.Ejecutar("SELECT a.idclientes, a.nombre, a.categorias_idcategorias, u.Vendedor " +
                                                "FROM clientes a, categorias u WHERE idclientes =" + idCliente + " and a.categorias_idcategorias=u.idcategorias", ref ClientDefau);

                                    if (ClientDefau.Rows.Count>0)
                                    {
                                        idCliente = Convert.ToInt32(ClientDefau.Rows[0][0]);
                                        idCategoria = Convert.ToInt32(ClientDefau.Rows[0][2]);
                                        comisionC = Convert.ToInt32(ClientDefau.Rows[0][3]);
                                        tbxNCliente.Text = ClientDefau.Rows[0][1].ToString() ;
                                        //des = lector.GetString(0);
                                    }
                                    else     
                                    {
                                        MessageBox.Show("Código de cliente no existente");
                                        tbxCCliente.Clear();
                                        tbxNCliente.Clear();
                                        tbxProducto.Enabled = false;
                                        btnSP.Enabled = false;
                                        btnAC.Enabled = false;
                                        tbxCantidad.Enabled = false;
                                        btnEliminar.Enabled = false;

                                        tbxCCliente.Focus();

                                    }
                                    ClientDefau.Rows.Clear();
                                    //ObtnerClienteDefaut();
                                }

                                if (Depa != 1)
                                {
                                    //ObtenerComision();

                                    string LOKO = "";
                                    if (Depa == 2) { LOKO = "Accesorios"; }
                                    if (Depa == 3) { LOKO = "Papel"; }
                                    DataTable Com = new DataTable();
                                    bAllOK=Conexion.Ejecutar("select Vendedor from categorias where nombre='" + LOKO + "'",ref Com);
                                    if(Com.Rows.Count>0)
                                    {
                                        ComisionN = Convert.ToDouble(Com.Rows[0][0]);
                                    }                                  
                                    comisionC = ComisionN;
                                }

                                double comision = ((comisionC / 100) * Convert.ToDouble(importe));
                                double iva = 0;
                                if (chbxIVa.Checked)
                                {
                                    iva = Convert.ToDouble(importe) - Convert.ToDouble(importe) / 1.16; 
                                }
                               bAllOK= Conexion.Ejecutar("INSERT INTO ventas (empleados_id_empleado,clientes_idclientes,categorias_idcategorias, "+
                                                        " articulos_codigo,precio_art,cantidad,importe,fecha_venta,comision,Costo_Produccion,iva,tipo_compra,"+
                                                        " folio,pendiente,Descuento) values("+ cod_empleado + "," + idCliente + "," + tblEntradas[12, i].Value + 
                                                        "," + cod_art + "," + precio_A + "," + n_venta + "," + importe + "," + Fechaa + "," + comision + 
                                                        "," + costoP + "," + iva + ",'contado'," + nuevoFolio + ",0," + descuento + ")");                          
                            }

                        }
                        //chbxIVa.Checked = false;
                        MessageBox.Show("La entrada ha sido registrada exitosamente");
                        if(objPedidos.FolioPedido != 0)
                        {
                            PedidosBO objPedidosBO = new PedidosBO();
                            objPedidosBO.FinalizarPedido(objPedidos.FolioPedido);
                            objPedidos.FolioPedido = 0;
                        }
                                              
                        tblEntradas.Rows.Clear();
                        tbxSubtotal.Clear();
                        tbxIVA.Clear();
                        tbxTotal.Clear();
                        button5_Click(sender, e);
                        bAutorizacionDescDistribuidor = false;
                        bAutorizar = true;
                    }
                }
                else
                {
                    MessageBox.Show("No hay nada para registrar");
                }
                #endregion RegistroContado
            }
            else if(rbtCredito.Checked)
            {
                #region Credito
                if (tblCredito.Rows.Count > 1)
                {
                    result = MessageBox.Show("Se va registrar una venta a crédito ¿Desea continuar?", "Registro de venta a crédito", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (AutorizacionCredito())
                        {
                            Fechaa = dtpFecha.Value.ToString("yyyyMMddHHmmss");
                            nuevoFolio = foliosCredito();
                            for (int i = 0; i < tblCredito.Rows.Count - 1; i++)
                            {
                                cod_empleado = tbxVendedor.Text;
                                cod_art = tblCredito[1, i].Value.ToString();
                                inv_anterior = tblCredito[10, i].Value.ToString();
                                n_entradas = (Convert.ToDouble(tblCredito[10, i].Value) - Convert.ToDouble(tblCredito[3, i].Value)).ToString();
                                n_venta = tblCredito[3, i].Value.ToString();
                                costoP = Convert.ToDouble(tblCredito[9, i].Value);
                                precio_A = Convert.ToDouble(tblCredito[4, i].Value);
                                importe = (Convert.ToDouble(n_venta) * precio_A).ToString();
                                abono = tblCredito[6, i].Value.ToString();
                                pendiente = tblCredito[7, i].Value.ToString();

                                verificarYEliminar();
                               bAllOK= Conexion.Ejecutar("INSERT INTO entradas values(null," + n_entradas + ",'" + dtpFecha.Value.ToString("yyyyMMdd") + "'," + cod_empleado + "," + cod_art + "," + inv_anterior + ")");
                       
                                if (Convert.ToDouble(n_venta) > 0)
                                {
                                    if (tbxVendedor.Text != "1")
                                    {
                                      bAllOK=  Conexion.Ejecutar("UPDATE inv_vendedor SET cantidad=cantidad-" + n_venta + " WHERE empleados_id_empleado=" + cod_empleado + " AND articulos_codigo=" + cod_art);
                                      cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                          " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                          " VALUES({0},{1},'{2}','{3}',{4},{5},{6},{7})",
                                          cod_art, n_venta, "Ventas", dtpFecha.Value.ToString("yyyyMMddHHmmss"),
                                          inv_anterior, Convert.ToDouble(inv_anterior) - Convert.ToDouble(n_venta), tbxVendedor.Text, UsuarioID);
                                       bAllOK= Conexion.Ejecutar(cmd);
                                    }
                                    else
                                    {
                                        bAllOK=Conexion.Ejecutar("UPDATE articulos SET cantidad=cantidad-" + n_venta + " WHERE codigo=" + cod_art);                                       
                                    }

                                    DataTable DepaT = new DataTable();
                                    bAllOK = Conexion.Ejecutar("SELECT departamento FROM articulos WHERE codigo =" + cod_art, ref DepaT);


                                    Depa = Convert.ToInt32(DepaT.Rows[0][0]);
                                    DepaT.Rows.Clear();

                                    if (tbxCCliente.Text == "")
                                    {
                                        idCliente = 1;

                                        DataTable ClientDefau = new DataTable();
                                        bAllOK = Conexion.Ejecutar("SELECT a.idclientes, a.nombre, a.categorias_idcategorias, u.Vendedor " +
                                                    "FROM clientes a, categorias u WHERE idclientes =" + idCliente + " and a.categorias_idcategorias=u.idcategorias", ref ClientDefau);

                                        if (ClientDefau.Rows.Count > 0)
                                        {
                                            idCliente = Convert.ToInt32(ClientDefau.Rows[0][0]);
                                            idCategoria = Convert.ToInt32(ClientDefau.Rows[0][2]);
                                            comisionC = Convert.ToInt32(ClientDefau.Rows[0][3]);
                                            tbxNCliente.Text = ClientDefau.Rows[0][1].ToString();
                                            //des = lector.GetString(0);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Código de cliente no existente");
                                            tbxCCliente.Clear();
                                            tbxNCliente.Clear();
                                            tbxProducto.Enabled = false;
                                            btnSP.Enabled = false;
                                            btnAC.Enabled = false;
                                            tbxCantidad.Enabled = false;
                                            btnEliminar.Enabled = false;

                                            tbxCCliente.Focus();

                                        }
                                        ClientDefau.Rows.Clear();

                                    }

                                    if (Depa != 1)
                                    {
                                        //ObtenerComision();

                                        string LOKO = "";
                                        if (Depa == 2) { LOKO = "Accesorios"; }
                                        if (Depa == 3) { LOKO = "Papel"; }
                                        DataTable Com = new DataTable();
                                        bAllOK = Conexion.Ejecutar("select Vendedor from categorias where nombre='" + LOKO + "'", ref Com);
                                        if (Com.Rows.Count > 0)
                                        {
                                            ComisionN = Convert.ToDouble(Com.Rows[0][0]);
                                        }
                                        comisionC = ComisionN;
                                    }

                                    double comision = ((comisionC / 100) * Convert.ToDouble(abono));
                                    double iva = 0;
                                    if (chbxIVa.Checked)
                                    {
                                        iva = Convert.ToDouble(importe) -  Convert.ToDouble(importe) / 1.16;
                                    }
                                    else
                                    {
                                        iva = 0;
                                    }
                                    bAllOK=Conexion.Ejecutar("INSERT INTO ventas(empleados_id_empleado,clientes_idclientes,categorias_idcategorias,articulos_codigo,"+
                                        "precio_art,cantidad,importe,fecha_venta,comision,Costo_Produccion,iva,tipo_compra,folio,pendiente,Descuento) values("+
                                        cod_empleado + "," + idCliente + "," + tblCredito[11, i].Value + "," + cod_art + "," + precio_A + "," + n_venta + "," + importe +
                                        "," + Fechaa + "," + comision + "," + costoP + "," + iva + ",'credito'," + nuevoFolio + "," + pendiente + ",0)");

                                    if (Convert.ToDouble(abono) > 0)
                                    {
                                        bAllOK = Conexion.Ejecutar("INSERT INTO abonos values(null," + nuevoFolio + "," + cod_art + "," + idCliente + "," + cod_empleado + "," + importe + "," + Convert.ToDouble(abono) + "," + pendiente + "," + Fechaa + ",LAST_INSERT_ID(),0,0)");

                                    }
                                }

                            }
                            //chbxIVa.Checked = false;
                            MessageBox.Show("La venta a crédito ha sido registrada exitosamente");
                            if (objPedidos.FolioPedido != 0)
                            {
                                PedidosBO objPedidosBO = new PedidosBO();
                                objPedidosBO.FinalizarPedido(objPedidos.FolioPedido);
                                objPedidos.FolioPedido = 0;
                            }
                            tblCredito.Rows.Clear();
                            tblCredito.Rows.Add(false, "-", "-", "-", "Total", 0, 0, 0, 0, 0, 0);
                           // tblCredito[0, tblCredito.Rows.Count - 1].ReadOnly = true;
                            tblCredito.Rows[tblCredito.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                            tbxSubtotal.Clear();
                            tbxIVA.Clear();
                            tbxTotal.Clear();
                            button5_Click(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Autorización cancelada.");
                    }
                }
                else
                {
                    MessageBox.Show("No hay nada para registrar");
                }
                #endregion
            }
            Conexion.FinTransaccion(bAllOK);
            Conexion.Desconectarse();
        }
        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            if (rbtContado.Checked)
            {
                (printPrevContado as Form).WindowState = FormWindowState.Maximized;
                printPrevContado.PrintPreviewControl.Zoom = 1.5;
                printPrevContado.ShowDialog();
            }
            else if (rbtCredito.Checked)
            {
                printDocCredito.DefaultPageSettings.Landscape = true;
                (printPrevCredito as Form).WindowState = FormWindowState.Maximized;
                printPrevCredito.PrintPreviewControl.Zoom = 1;
                printPrevCredito.ShowDialog();
            }
        }

        private void rbtContado_CheckedChanged(object sender, EventArgs e)
        {
            tblCredito.Rows.Clear();
            tblEntradas.Rows.Clear();
            tbxSubtotal.Clear();
            tbxIVA.Clear();
            tbxTotal.Clear();
            
            tblEntradas.Visible = true;
            tblCredito.Visible = false;
            bAutorizacionDescDistribuidor = false;
            bAutorizar = true;
        }
        Boolean CreditoAutorizado = false;
        private void rbtCredito_CheckedChanged(object sender, EventArgs e)
        {

            Boolean bAllOk = false;
            CreditoAutorizado = true;
            bAutorizacionDescDistribuidor = false;
            bAutorizar = true;
            if (rbtCredito.Checked)
            {
                bAllOk = CreditoPendiente();
                if (bAllOk)
                {                    
                    string S = "", Respuesta = "";
                    inicioSesion id = new inicioSesion(S, "Autorización");
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        Respuesta = id.regresar.valXn;
                    }
                    if (Respuesta != "")
                    {
                        DataTable Tabla = new DataTable();
                        string comando = "Select * from PrivilegiosDeUsuario WHERE Usuarios_id_usuarios=" + Respuesta;
                        Conexion.Conectarse();
                        Conexion.Ejecutar(comando, ref Tabla);
                        if (Tabla.Rows.Count > 0)
                        {
                            DataRow row = Tabla.Rows[0];
                            if (row["AutorizarCredito"].ToString() == "1")
                            {
                                bAllOk = false;
                                CreditoAutorizado = true;
                            }
                            else
                            {
                                CreditoAutorizado = false;
                                MessageBox.Show("El usuario no tiene permiso necesario para autorizar venta a crédito.");
                            }
                        }
                        Conexion.Desconectarse();
                    }
                    else
                    {
                        CreditoAutorizado = false;
                    }
                }
            }else
            {
                CreditoAutorizado = false;
            }
           
            if (!bAllOk)
            {
                tblCredito.Rows.Clear();
                tblEntradas.Rows.Clear();
                tbxSubtotal.Clear();
                tbxIVA.Clear();
                tbxTotal.Clear();

                //rbtnDistribuidor.Enabled = false;
                //rbtnGeneral.Checked = true;
                tblCredito.Rows.Add(false, "-", "-", "-", "Total", 0, 0, 0, 0, 0, 0);
                tblCredito[0, tblCredito.Rows.Count - 1].ReadOnly = true;
                tblCredito.Rows[tblCredito.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                tblCredito.Visible = true;
                tblEntradas.Visible = false;
            }
            else
            {
                rbtContado.Checked = true;
            }
            
        }

        private void tblCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tblCredito.CurrentCell.ColumnIndex == 6)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
                {

                    e.Handled = true;

                }
            }

        }

        private void tblCredito_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tblCredito.Rows[e.RowIndex].ErrorText = String.Empty;
            sumaTotal();
        }

        private void tblCredito_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(tblCredito_KeyPress);
        }

        private void tblCredito_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = tblCredito.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("Abono")) return;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                tblCredito.Rows[e.RowIndex].ErrorText =
                    "No puedes dejar vacia esta celda";
                e.Cancel = true;
            }
        }

        private void tblCredito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            n = 0;
            if (tblCredito.Rows.Count > 1)
            {
                if (tblCredito[6, e.RowIndex].Value.ToString().Replace('$', ' ').Trim() == "" || tblCredito[6, e.RowIndex].Value.ToString().Replace('$', ' ').Trim() == ".")
                {                  
                    tblCredito[6, e.RowIndex].Value = 0.00;
                }
                else
                {
                    n = 0;
                    for (int i = 0; i < tblCredito[6, e.RowIndex].Value.ToString().Length; i++)
                    {
                        if (tblCredito[6, e.RowIndex].Value.ToString().Substring(i, 1) == ".")
                        {
                            n++;
                        }

                    }
                    if (n > 1)
                    {
                        tblCredito[6, e.RowIndex].Value = 0.00;
                    }
                    tblCredito[6, e.RowIndex].Value = Convert.ToDouble(tblCredito[6, e.RowIndex].Value.ToString().Replace('$', ' ').Trim());
                }
                 n = 0;
                for (int i = 0; i < tblCredito[6, e.RowIndex].Value.ToString().Length; i++)
                {
                    if (tblCredito[6, e.RowIndex].Value.ToString().Substring(i, 1) == ".")
                    {
                        n++;
                    }

                }
                if (n < 2)
                {
                    if (tblCredito[6, e.RowIndex].Value.ToString().Equals("."))
                    {
                        tblCredito[6, e.RowIndex].Value = Convert.ToDouble(0.00);
                        tblCredito[7, e.RowIndex].Value = tblCredito[5, e.RowIndex].Value;
                    }
                    else
                    {
                        tblCredito[6, e.RowIndex].Value = Convert.ToDouble(tblCredito[6, e.RowIndex].Value);
                        if (e.RowIndex == tblCredito.Rows.Count - 1 && Convert.ToDouble(tblCredito[6, e.RowIndex].Value) <= Convert.ToDouble(tblCredito[5, e.RowIndex].Value))
                        {
                            if (!evitar)
                            {
                                disAbono(Convert.ToDouble(tblCredito[6, e.RowIndex].Value));

                            }
                            //  tblCredito[6, e.RowIndex].Value = 0.00;
                        }
                        if (Convert.ToDouble(tblCredito[5, e.RowIndex].Value) >= Convert.ToDouble(tblCredito[6, e.RowIndex].Value))
                        {
                            if (Convert.ToDouble(tblCredito[6, e.RowIndex].Value) >= 0)
                            {
                                if (tblCredito.Rows[e.RowIndex].Index < tblCredito.Rows.Count - 1)
                                {
                                    if (chbxIVa.Checked)
                                    {
                                        tblCredito[5, e.RowIndex].Value = (Convert.ToDouble(tblCredito[3, e.RowIndex].Value) * Convert.ToDouble(tblCredito[4, e.RowIndex].Value));
                                    }
                                    else
                                    {
                                        tblCredito[5, e.RowIndex].Value = (Convert.ToDouble(tblCredito[3, e.RowIndex].Value) * Convert.ToDouble(tblCredito[4, e.RowIndex].Value));
                                    }
                                    // tblCredito[5, e.RowIndex].Value = Convert.ToDouble(tblCredito[3, e.RowIndex].Value) - Convert.ToDouble(tblCredito[4, e.RowIndex].Value);
                                    tblCredito[7, e.RowIndex].Value = Convert.ToDouble(tblCredito[5, e.RowIndex].Value) - Convert.ToDouble(tblCredito[6, e.RowIndex].Value);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se puede ingresar numeros negativos");
                                tblCredito[6, e.RowIndex].Value = 0.00;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El abono a ingresar no puede ser mayor que el total.");
                            tblCredito[6, e.RowIndex].Value = 0.00;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Solo puede agregar 1 punto decimal");
                    tblCredito[6, e.RowIndex].Value = 0.00;
                }
                //sumaTotal();
            }
            evitar = false;
        }
                
        Pedidos objPedidos = new Pedidos(true);
        private void pedidosPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objPedidos = new Pedidos(true);
            objPedidos.ShowDialog();
            if(objPedidos.FolioPedido > 0)
            {
                resetControles();             
                CargarPedido(objPedidos.FolioPedido, objPedidos.TipoCompra, sender, e);
            }
        }
        
        public void CargarPedido(int iFolioPedido, int iTipoCompra, object sender, EventArgs e)
        {
            PedidosBO objPedidosBO = new PedidosBO();
            ClienteBO objClienteBO = new ClienteBO();
            CClientes objCClientes = new CClientes();
            CPedidos objCPedidos = new CPedidos();
            objCPedidos = objPedidosBO.ObtenerPedido(iFolioPedido);
            objCClientes = objClienteBO.ObtenerDatosCliente(objCPedidos.ClienteID);
            if(objCClientes.IDEmpleado != 1)
            {
                tbxVendedor.Text = objCClientes.IDEmpleado.ToString();
                MetodoVendedor();            
                tbxCCliente.Text = objCPedidos.ClienteID.ToString();
                MetodoCliente();
                if (iTipoCompra == 1)
                {
                    rbtContado.Checked = true;
                    rbtContado_CheckedChanged(sender, e);
                    CargarProductosPedidos(objCPedidos, iTipoCompra);
                    CalcularDescuentosDistribuidor();
                }
                else if (iTipoCompra == 2)
                {
                    rbtCredito.Checked = false;
                    rbtCredito.Checked = true;
                    //   rbtCredito_CheckedChanged(sender, e);
                    if (CreditoAutorizado)
                    {
                        CargarProductosPedidos(objCPedidos, iTipoCompra);
                    }
                }
               
            }
            else
            {
                resetControles();
                inavilitados();
                tbxIVA.Clear();
                tbxSubtotal.Clear();
                tbxTotal.Clear();
                tblEntradas.AllowUserToDeleteRows = false;
                tblEntradas.Columns[4].Visible = true;
                tblEntradas.Columns[7].Visible = false;
                tblEntradas.Visible = true;
                tblCredito.Visible = false;
                rbtCredito.Enabled = false;
                rbtContado.Enabled = false;
                rbtCredito.Checked = false;
                rbtContado.Checked = true;
                tbxVendedor.Enabled = true;
                tbxVendedor.Focus();
                MessageBox.Show("No se permiten cargar pedidos de clientes de vendedor sucursal.");
            }
        }
        List<CArticulos> lCArticulosSinExistencia = new List<CArticulos>();
        public void CargarProductosPedidos(CPedidos objCPedidos, int iTipoCompra)
        {
            ArticuloBO objArticuloBO = new ArticuloBO();
            CArticulos objCArticulos = new CArticulos();
            lCArticulosSinExistencia = new List<CArticulos>();

            foreach (CPedidosDetalle PedidoDetalle in objCPedidos.PedidosDetalle)
            {
                objCArticulos = new CArticulos();
                //PedidoDetalle.TipoPrecio
                objCArticulos = objArticuloBO.ObtenerDatosArticulo(PedidoDetalle.CodigoArticulo);

                Double precio_cliente = 0;
                descuento = 0;
                if (PedidoDetalle.TipoPrecio == TipoPrecio.Abarrotes.ToString())
                {
                    precio_cliente = objCArticulos.PrecioAbarrotes;
                    categoria = "7";

                }
                else if (PedidoDetalle.TipoPrecio == TipoPrecio.Distribuidor.ToString())
                {
                    precio_cliente = objCArticulos.PrecioDistribuidor;
                    categoria = "8";
                }
                else if (PedidoDetalle.TipoPrecio == TipoPrecio.Calle.ToString())
                {
                    precio_cliente = objCArticulos.PrecioCalle;
                    categoria = "9";
                }
                if (aplicaDescuento() && PedidoDetalle.TipoPrecio != TipoPrecio.Distribuidor.ToString())
                {

                    descuento = PedidoDetalle.Cantidad * precio_cliente * (objCArticulos.Descuento / 100);
                }

                EmpleadoBO objEmpleadoBO = new EmpleadoBO();
                Double InvetarioEmpleado = objEmpleadoBO.ObtenerInvVendedorArticulo(Convert.ToInt32(tbxVendedor.Text), objCArticulos.Codigo);

                if (iTipoCompra == 1) //Compras de contado
                {

                  
                    double entradas = InvetarioEmpleado - PedidoDetalle.Cantidad;
                    double cantidadVendida = InvetarioEmpleado - entradas;
                    double total = (precio_cliente * cantidadVendida) - descuento;

                    if (entradas >= 0)
                    {

                        if (objCArticulos.Departamento.ToString() == "2")
                        {
                            categoria = "6";
                        }
                        else if (objCArticulos.Departamento.ToString() == "3")
                        {
                            categoria = "10";
                        }
                        tblEntradas.Rows.Add(false, objCArticulos.Codigo, objCArticulos.Descripcion + " " +
                                            objCArticulos.ValorMedida + " " + objCArticulos.UnidadMedida, InvetarioEmpleado, entradas, cantidadVendida, 
                                            precio_cliente, cantidadVendida * precio_cliente, descuento, total, tbxVendedor.Text,
                                            objCArticulos.PrecioProduccion, categoria);
                        tbxProducto.Clear();
                        tbxCantidad.Clear();
                        tbxNombre.Clear();
                        tbxExistencias.Clear();
                        tbxProducto.Focus();
                        Totls();

                    }
                    else
                    {
                        lCArticulosSinExistencia.Add(objCArticulos);
                    }

                }
                else if (iTipoCompra == 2) //Compras a crédito
                {
                    double existVendedor = InvetarioEmpleado - PedidoDetalle.Cantidad;
                    double total = precio_cliente * PedidoDetalle.Cantidad;

                    if (existVendedor >= 0)
                    {
                        if (objCArticulos.Departamento.ToString() == "2")
                        {
                            categoria = "6";
                        }
                        else if (objCArticulos.Departamento.ToString() == "3")
                        {
                            categoria = "10";
                        }
                        tblCredito.Rows.Insert(tblCredito.Rows.Count - 1, false, objCArticulos.Codigo, objCArticulos.Descripcion + " " +
                                            objCArticulos.ValorMedida + " " + objCArticulos.UnidadMedida, PedidoDetalle.Cantidad, precio_cliente, 
                                           total, 0, total, tbxVendedor.Text, objCArticulos.PrecioProduccion, InvetarioEmpleado, categoria);
                    }
                    else
                    {
                        lCArticulosSinExistencia.Add(objCArticulos);
                    }
                }

            }
            sumaTotal();
            if (lCArticulosSinExistencia.Count > 0)
            {
                String ArticulosSinExistencia = String.Join(", ", lCArticulosSinExistencia.Select(x => x.Codigo.ToString()).ToArray());
                MessageBox.Show("Vendedor con existencias insuficientes de los siguientes códigos de artículos: \n"+ ArticulosSinExistencia);
            }
            if (tblEntradas.Rows.Count > 0)
            {
                
            }

        }
        
        private List<CArticulos> listaProductos()
        {
            List<CArticulos> objListCArticulos = new List<CArticulos>();
            ArticuloBO objArticuloBO = new ArticuloBO();
            for ( int i= 0; i < tblEntradas.Rows.Count-1; i++)
            {
                if(tblEntradas.Rows[i].Cells[12].Value.ToString() == "8"){
                    CArticulos objCArticulos = new CArticulos();
                    objCArticulos = objArticuloBO.ObtenerDatosArticulo(Convert.ToInt32(tblEntradas.Rows[i].Cells[1].Value));
                    objCArticulos.Cantidad = Convert.ToDouble(tblEntradas.Rows[i].Cells[5].Value);
                    objListCArticulos.Add(objCArticulos);
                }
                
            }
            return objListCArticulos;
        }
        Boolean evitar = false;
        //metodo para distribuir abono en diferentes adeudos.
        public void disAbono(double abono)
        {
            double resto = abono;

            for (int i = 0; i < tblCredito.Rows.Count - 1; i++)
            {

                if (resto >= Convert.ToDouble(tblCredito[5, i].Value))
                {
                    resto = resto - Convert.ToDouble(tblCredito[5, i].Value);
                    tblCredito[6, i].Value = Convert.ToDouble(tblCredito[5, i].Value);
                    tblCredito[7, i].Value = Convert.ToDouble(tblCredito[5, i].Value) - Convert.ToDouble(tblCredito[6, i].Value);
                }
                else if (resto > 0 && resto < Convert.ToDouble(tblCredito[5, i].Value))
                {
                    tblCredito[6, i].Value = resto;
                    tblCredito[7, i].Value = Convert.ToDouble(tblCredito[5, i].Value) - Convert.ToDouble(tblCredito[6, i].Value);
                    resto = 0;
                }
                else
                {
                    tblCredito[6, i].Value = 0.00;
                    tblCredito[7, i].Value = Convert.ToDouble(tblCredito[5, i].Value) - Convert.ToDouble(tblCredito[6, i].Value);
                }
            }
        }
        public void actImpuestos()
        {
            if (tblCredito.Rows.Count > 1 && rbtCredito.Checked)
            {
                for (int i = 0; i < tblCredito.Rows.Count - 1; i++)
                {
                    if (chbxIVa.Checked)
                    {
                        tblCredito[5, i].Value = Convert.ToDouble(tblCredito[3, i].Value) * Convert.ToDouble(tblCredito[4, i].Value)*1.16;
                    }
                    else
                    {
                        tblCredito[5, i].Value = Convert.ToDouble(tblCredito[3, i].Value) * Convert.ToDouble(tblCredito[4, i].Value);
                    }
                }
            }
        }
        private void tblCredito_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.RowIndex2 < tblCredito.Rows.Count - 1 && e.RowIndex1 < tblCredito.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "tblCrCodArt" && e.RowIndex2 < tblCredito.Rows.Count - 1 && e.RowIndex1 < tblCredito.Rows.Count - 1)
            {
                // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(tblCredito.Rows[e.RowIndex1].Cells["tblCrCodArt"].Value.ToString()),
                    Convert.ToInt32(tblCredito.Rows[e.RowIndex2].Cells["tblCrCodArt"].Value.ToString()));
            }
            if (e.Column.Name == "tblCrCantidad" && e.RowIndex2 < tblCredito.Rows.Count - 1 && e.RowIndex1 < tblCredito.Rows.Count - 1)
            {
                // e.SortResult = Tabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  Tabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(tblCredito.Rows[e.RowIndex1].Cells["tblCrCantidad"].Value.ToString()),
                    Convert.ToDouble(tblCredito.Rows[e.RowIndex2].Cells["tblCrCantidad"].Value.ToString()));
            }

            if (e.Column.Name == "tblCrPrecio" && e.RowIndex2 < tblCredito.Rows.Count - 1 && e.RowIndex1 < tblCredito.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(tblCredito.Rows[e.RowIndex1].Cells["tblCrPrecio"].Value.ToString()),
                    Convert.ToDouble(tblCredito.Rows[e.RowIndex2].Cells["tblCrPrecio"].Value.ToString()));
            }

            if (e.Column.Name == "tblCrTotal" && e.RowIndex2 < tblCredito.Rows.Count - 1 && e.RowIndex1 < tblCredito.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(tblCredito.Rows[e.RowIndex1].Cells["tblCrTotal"].Value.ToString()),
                    Convert.ToDouble(tblCredito.Rows[e.RowIndex2].Cells["tblCrTotal"].Value.ToString()));
            }
            if (e.Column.Name == "tblCrAbono" && e.RowIndex2 < tblCredito.Rows.Count - 1 && e.RowIndex1 < tblCredito.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(tblCredito.Rows[e.RowIndex1].Cells["tblCrAbono"].Value.ToString()),
                    Convert.ToDouble(tblCredito.Rows[e.RowIndex2].Cells["tblCrAbono"].Value.ToString()));
            }
            if (e.Column.Name == "tblCrPendiente" && e.RowIndex2 < tblCredito.Rows.Count - 1 && e.RowIndex1 < tblCredito.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(tblCredito.Rows[e.RowIndex1].Cells["tblCrPendiente"].Value.ToString()),
                    Convert.ToDouble(tblCredito.Rows[e.RowIndex2].Cells["tblCrPendiente"].Value.ToString()));
            }

            e.Handled = true;
        }

        private void chbxIVa_CheckedChanged(object sender, EventArgs e)
        {
            if (tblEntradas.Rows.Count > 0&&rbtContado.Checked)
            {
                sumaTotal();
            }
            else if (tblCredito.Rows.Count > 1 && rbtCredito.Checked)
            {
                //actImpuestos();
                sumaTotal();
            }
        }

        private void printDocCredito_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (tblCredito.Rows.Count > 0)
            {
                int height = 0;
                int an = -10;
                Font letra = new Font("Arial", 9);
                int x = 155;
                int L = 160;
                int y = 140;
                int col1 = tblCredito.Columns[1].Width - an;
                int col2 = tblCredito.Columns[2].Width - an;
                int col3 = tblCredito.Columns[3].Width - an;
                int col4 = tblCredito.Columns[4].Width - an;
                int col5 = tblCredito.Columns[5].Width - an;
                int col6 = tblCredito.Columns[6].Width - an;
                int col7 = tblCredito.Columns[7].Width - an;
                Pen p = new Pen(Brushes.Black, 1.5f);

                #region titulo
                e.Graphics.DrawString("VENTA A CRÉDITO", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 6 * 3, 50, 500, tblCredito.Rows[0].Height + 15));
                #endregion

                #region NombreCliente
                e.Graphics.DrawString("Cliente:" + tbxNCliente.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 115, 500, tblCredito.Rows[0].Height + 15));
                #endregion
                
                #region CodigodeArticulo

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, tblCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(tblCredito.Columns[1].HeaderText.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(x, y, col1, tblCredito.Rows[0].Height + 15));

                #endregion

                #region descripcion
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, tblCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(tblCredito.Columns[2].HeaderText.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(x + col1, y, col2, tblCredito.Rows[0].Height + 15));


                #endregion

                #region Cantidad

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, tblCredito.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, tblCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(tblCredito.Columns[3].HeaderText.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, tblCredito.Rows[0].Height + 15));

                #endregion

                #region Precio

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, tblCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(tblCredito.Columns[4].HeaderText.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, tblCredito.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                #region Saldo

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(tblCredito.Columns[5].HeaderText.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, tblCredito.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                #region Abono
                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(tblCredito.Columns[6].HeaderText.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, tblCredito.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                #region Pendiente
                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, tblCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(tblCredito.Columns[7].HeaderText.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, tblCredito.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                height = 155;

                while (i < tblCredito.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 155;
                        e.HasMorePages = true;
                        return;
                    }
                    height += tblCredito.Rows[0].Height;

                    e.Graphics.DrawString(tblCredito.Rows[i].Cells[1].FormattedValue.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(L, height, tblCredito.Columns[1].Width, tblCredito.Rows[0].Height));

                    e.Graphics.DrawString(tblCredito.Rows[i].Cells[2].FormattedValue.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(L + col1, height, tblCredito.Columns[2].Width, tblCredito.Rows[0].Height));

                    e.Graphics.DrawString(tblCredito.Rows[i].Cells[3].FormattedValue.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, tblCredito.Columns[3].Width, tblCredito.Rows[0].Height));

                    e.Graphics.DrawString(tblCredito.Rows[i].Cells[4].FormattedValue.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, tblCredito.Columns[4].Width, tblCredito.Rows[0].Height));

                    e.Graphics.DrawString(tblCredito.Rows[i].Cells[5].FormattedValue.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, tblCredito.Columns[5].Width, tblCredito.Rows[0].Height));

                    e.Graphics.DrawString(tblCredito.Rows[i].Cells[6].FormattedValue.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, tblCredito.Columns[6].Width, tblCredito.Rows[0].Height));

                    e.Graphics.DrawString(tblCredito.Rows[i].Cells[7].FormattedValue.ToString(), tblCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, tblCredito.Columns[7].Width, tblCredito.Rows[0].Height));

                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void btnConsignacion_Click(object sender, EventArgs e)
        {
            Consignacion consig = new Consignacion(Conexion,UsuarioID);
            consig.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consignacion consig = new Consignacion(Conexion, UsuarioID);
            consig.ShowDialog();
        }

        private void corteCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Corte_de_Caja cort = new Corte_de_Caja(Conexion);
            cort.ShowDialog();
        }

        private void conversionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
            {
                Conversiones CN = new Conversiones(tbxVendedor.Text, UsuarioID, Conexion);
                CN.ShowDialog();
            }
            else
            {
                Conversiones CN = new Conversiones(UsuarioID, Conexion);
                CN.ShowDialog();
            }
        }

        private void transferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transferenciasInventario trf = new transferenciasInventario(Conexion, UsuarioID);
            trf.ShowDialog();
        }

        private void invInesperadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
            {
                ventaInesperada VI = new ventaInesperada(tbxVendedor.Text, UsuarioID, Conexion);
                VI.ShowDialog();
            }
        }

        private void cobranzaCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text == "" && tbxCCliente.Text == "")
            {
                CobranzaCredito cobcr = new CobranzaCredito(Conexion);
                cobcr.ShowDialog();
            }
            else if (tbxVendedor.Text != "" && tbxCCliente.Text == "")
            {
                CobranzaCredito cobcr = new CobranzaCredito(tbxVendedor.Text, Conexion);
                cobcr.ShowDialog();
            }
            else if (tbxVendedor.Text != "" && tbxCCliente.Text != "")
            {
                CobranzaCredito cobcr = new CobranzaCredito(tbxVendedor.Text, tbxCCliente.Text, Conexion);
                cobcr.ShowDialog();
            }
        }

        private void cancelacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
            {
                ConsultaCancelaVentas rdv = new ConsultaCancelaVentas(Conexion, tbxVendedor.Text, Convert.ToInt32(UsuarioID));
                rdv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Primero es necesario ingresar un vendedor.");
            }
        }

        private void tbxCCliente_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void tbxProducto_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void tblEntradas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VentasVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (tblEntradas.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Hay datos sin guardar ¿seguro que desea salir?","Saliendo de Ventas Vendedor",MessageBoxButtons.YesNo);
                    if(result==DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void cancelaAbonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
            {
                CancelarAbonos rdv = new CancelarAbonos(tbxVendedor.Text, Convert.ToInt32(UsuarioID));
                rdv.ShowDialog();
            }
            else
            {
                CancelarAbonos rdv = new CancelarAbonos("1", Convert.ToInt32(UsuarioID));
                rdv.ShowDialog();
            }
        }    
    }
}