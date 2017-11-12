using MySql.Data.MySqlClient;
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
    public partial class RepCobranzaN : Form
    {
        conexion conn = new conexion();
        MySqlCommand comando;
        MySqlConnection conectar;
        MySqlDataReader lector;
        Inventarios.DBMS_Unico Conexion;
        public RepCobranzaN(Inventarios.DBMS_Unico server)
        {
            InitializeComponent();
            cbxDias.SelectedIndex = 0;
            dtpFin.Value = DateTime.Now;
            dtpInicio.Value = DateTime.Now.AddDays(-30);
            Conexion = server;

        }

        private void tbxCrVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoVendedor();
            }
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
        }
        public void limpiarCreditos()
        {
            tbxFolio.Clear();
            tbxCrVendedor.Clear();
            tbxNCrVendedor.Clear();
            tbxCrCliente.Clear();
            tbxNCrCliente.Clear();
            dtgCrTabla.Rows.Clear();
            tbxDias.Clear();
            rbtPendientes.Checked = true;
            cbxDias.SelectedIndex = 0;

        }
        public void limpiarHistorial()
        {
            tbxVendedor.Clear();
            tbxNVendedor.Clear();
            tbxCliente.Clear();
            tbxNCliente.Clear();
            dtgCrTabla.Rows.Clear();
        }
        public string obtenerVendedor(string vendedor)
        {
            string resultado = "";
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("Select nombre, apellido_paterno, apellido_materno from empleados where id_empleado=" + vendedor, conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            string dess = "";
            while (lector.Read())
            {
                dess = lector.GetString(0);
                resultado = lector.GetString(0) + " " + lector.GetString(1) + " " + lector.GetString(2);
            }
            conectar.Close();
            if (dess == "")
            {
                MessageBox.Show("Código de vendedor no existente");
                return resultado;
            }
            return resultado;
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
            tbxFolio.Clear();
        }

        private void cbxDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgCrTabla.Rows.Clear();
            if (cbxDias.Text == "Todos")
            {
                tbxDias.Enabled = false;
                tbxDias.Clear();
            }
            else
            {
                tbxDias.Enabled = true;
                tbxDias.Clear();
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

        private void tbxFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
            }
        }

        public void obtenerVendedor()
        {
            string vendedor = "";
            if (tabControl1.SelectedIndex == 0)
            {
                vendedor = tbxCrVendedor.Text;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                vendedor = tbxVendedor.Text;
            }
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + vendedor, conectar);
            conectar.Open();

            lector = comando.ExecuteReader();
            string des = "";
            while (lector.Read())
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    tbxNCrVendedor.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    tbxNVendedor.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                }

                des = lector.GetString(0);
            }
            conectar.Close();
            if (des == "")
            {
                MessageBox.Show("Código de vendedor no existente");
                tbxVendedor.Text = "";
                tbxNVendedor.Clear();

            }
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
            btnReporteHistorial.Focus();
        }

        private void btnCrRCliente_Click(object sender, EventArgs e)
        {
            tbxCrCliente.Clear();
            tbxNCrCliente.Clear();
            btnSPCrC.Enabled = true;
            tbxCrCliente.ReadOnly = false;
            dtgCrTabla.Rows.Clear();
            cbxDias.SelectedIndex = 0;
            tbxFolio.Clear();
        }
        public void ObtnerCliente(int cliente)
        {
            Boolean existe = false;
            string vendedor = "";
            if (tbxCliente.Text != "")
            {
                dtgCrTabla.Rows.Clear();
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select idclientes,nombre,empleados_id_empleado from clientes where idclientes=" + cliente, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tbxNCliente.Text = lector.GetString(1);
                    vendedor = lector.GetString(2);
                    existe = true;
                }
                conectar.Close();
                if (existe)
                {
                    tbxVendedor.Text = vendedor;
                    obtenerVendedor();
                }
                else
                {
                    MessageBox.Show("El código de cliente no existe.");
                }

            }

        }
        public void ObtnerCliente(string cliente)
        {
            string vendedor = "";
            Boolean existe = false;
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select idclientes,nombre,empleados_id_empleado from clientes where idclientes=" + cliente, conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    tbxNCrCliente.Text = lector.GetString(1);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    tbxNCliente.Text = lector.GetString(1);
                }
                vendedor = lector.GetString(2);
                existe = true;
            }
            conectar.Close();
            if (existe)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    tbxCrVendedor.Text = vendedor;
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    tbxVendedor.Text = vendedor;
                }
                obtenerVendedor();
            }
            else
            {
                MessageBox.Show("Código de cliente no existente");
            }
        }
   
        
        private void btnReporteCr_Click(object sender, EventArgs e)
        {
            //try
            //{
                double credito = 0, abonado = 0, sumCredito = 0, sumAbonado = 0, sumSaldo = 0;
                string status = "", folio = "", cliente = "";
                if (tbxFolio.Text != "")
                {
                    folio = " and v.folio=" + tbxFolio.Text;
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("select clientes_idclientes from ventas where tipo_compra='credito' and folio=" + tbxFolio.Text, conectar);
                    tbxDias.Text="";
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        cliente = lector.GetString(0);
                    }
                    conectar.Close();
                    if (cliente != "")
                    {
                        tbxCrCliente.Text = cliente;
                        ObtnerCliente(cliente);
                    }
                    else
                    {
                        MessageBox.Show("Folio no existente.");
                        tbxVendedor.Clear();
                        tbxCliente.Clear();
                        tbxFolio.Clear();
                    }
                }
                else
                {
                    folio = "";
                }
                //if (tbxCrCliente.Text.Length > 0)
                //{

                    dtgCrTabla.Rows.Clear();
                    string vendCliente = "";
                    if (rbtPendientes.Checked)
                    {
                        status = " and v.pendiente>0";
                    }
                    else if (rbtPagadas.Checked)
                    {
                        status = " and v.pendiente=0";
                    }
                    else if (rbtTodas.Checked)
                    {
                        status = "";
                    }
                    
                    conectar = conn.ObtenerConexion();

                    if (tbxCrCliente.Text.Length > 0&&tbxCrVendedor.Text.Length>0)
                    {
                        vendCliente = " and v.empleados_id_empleado="+tbxCrVendedor.Text+" and v.clientes_idclientes=" + tbxCrCliente.Text;

                        comando = new MySqlCommand("select v.folio,v.fecha_venta,a.descripcion,a.valor_medida,u.nombre,v.importe," +
                       "v.iva,v.pendiente from articulos a, ventas v, unidad_medida u where a.codigo=v.articulos_codigo and " +
                       " u.id=a.unidad_medida_id and tipo_compra='credito' " + vendCliente + status + folio + " order by v.folio asc", conectar);
                        tblFecha.HeaderText = "Fecha";
                        tblFecha.DefaultCellStyle.Format = "d";
                    }
                    else if (tbxCrVendedor.Text.Length > 0 && tbxCrCliente.Text == "")
                    {
                        vendCliente = " and v.empleados_id_empleado=" + tbxCrVendedor.Text;

                        comando = new MySqlCommand("select v.folio, e.nombre, c.nombre, a.valor_medida,u.nombre,SUM(v.importe),SUM( v.iva)," +
                            " SUM(v.pendiente), v.fecha_venta,v.clientes_idclientes from empleados e, articulos a, ventas v, unidad_medida u, clientes c " +
                            " where c.empleados_id_empleado=e.id_empleado and c.idclientes=v.clientes_idclientes and " +
                            "a.codigo=v.articulos_codigo and u.id=a.unidad_medida_id and tipo_compra='credito'  " +
                       vendCliente + status + folio + " group by v.folio order by v.folio asc", conectar);
                        tblFecha.HeaderText = "Vendedor";
                        tblFecha.DefaultCellStyle.Format = "";
                    }
                    else
                    {                       
                        comando = new MySqlCommand("select v.folio, e.nombre, c.nombre, a.valor_medida,u.nombre,SUM(v.importe),SUM( v.iva),"+
                            " SUM(v.pendiente), v.fecha_venta,v.clientes_idclientes from empleados e, articulos a, ventas v, unidad_medida u, clientes c " +
                            " where c.empleados_id_empleado=e.id_empleado and c.idclientes=v.clientes_idclientes and "+
                            "a.codigo=v.articulos_codigo and u.id=a.unidad_medida_id and tipo_compra='credito' "+ status + folio +
                            " group by v.folio order by v.folio asc", conectar);
                        tblFecha.HeaderText = "Vendedor";
                        tblFecha.DefaultCellStyle.Format = "";
                    
                    }
                  
                   conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        if (cbxDias.Text == "Todos")
                        {
                            credito = lector.GetDouble(5);
                            double D7 = lector.GetDouble(7);
                            if(D7>0)
                            {
                                abonado = credito - lector.GetDouble(7);
                            }
                            else
                            {
                                abonado = D7;
                            }
                           
                          
                            TimeSpan ts;
                            if (tbxCrVendedor.Text.Length > 0 && tbxCrCliente.Text=="")
                            {
                                ts = DateTime.Now.AddDays(1) - lector.GetDateTime(8);
                            }
                            else if (tbxCrVendedor.Text.Length == 0 && tbxCrCliente.Text.Length == 0)
                            {
                                ts = DateTime.Now.AddDays(1) - lector.GetDateTime(8);
                            }
                            else
                            {
                                ts = DateTime.Now.AddDays(1) - lector.GetDateTime(1);
                            }
                            sumCredito += credito;
                            sumAbonado += abonado;
                            sumSaldo += lector.GetDouble(7);
                            if (tbxCrCliente.Text.Length > 0 && tbxCrVendedor.Text.Length > 0)
                            {
                                dtgCrTabla.Rows.Add(lector.GetInt32(0), lector.GetDateTime(1).ToString("dd/MM/yyyy"), lector.GetString(2) + " " + lector.GetString(3) + " " + lector.GetString(4), credito, abonado, lector.GetDouble(7), ts.Days);
                            }
                            else if (tbxCrVendedor.Text.Length > 0 && tbxCrCliente.Text == "")
                            {
                                dtgCrTabla.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), credito, abonado, lector.GetDouble(7), ts.Days,lector.GetString(9));
                            }
                            else
                            {
                                dtgCrTabla.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), credito, abonado, lector.GetDouble(7), ts.Days,lector.GetString(9));                           
                         
                            }
                        }
                        else if (cbxDias.Text == "Días menor que")
                        {
                            credito = lector.GetDouble(5) + lector.GetDouble(6);
                            abonado = credito - lector.GetDouble(7);
                            TimeSpan ts;
                            if (tbxCrVendedor.Text.Length > 0 && tbxCrCliente.Text == "")
                            {
                                ts = DateTime.Now.AddDays(1) - lector.GetDateTime(8);
                            }
                            else if (tbxCrVendedor.Text.Length == 0 && tbxCrCliente.Text.Length == 0)
                            {
                                ts = DateTime.Now.AddDays(1) - lector.GetDateTime(8);
                            }
                            else
                            {
                                ts = DateTime.Now.AddDays(1) - lector.GetDateTime(1);
                            }
                            if (tbxDias.Text == "")
                            {
                                tbxDias.Text = "0";
                            }
                            if (ts.Days < Convert.ToInt32(tbxDias.Text))
                            {
                                sumCredito += credito;
                                sumAbonado += abonado;
                                sumSaldo += lector.GetDouble(7);
                                if (tbxCrCliente.Text.Length > 0 && tbxCrVendedor.Text.Length > 0)
                                {
                                    dtgCrTabla.Rows.Add(lector.GetInt32(0), lector.GetDateTime(1).ToString("dd/MM/yyyy"), lector.GetString(2) + " " + lector.GetString(3) + " " + lector.GetString(4), credito, abonado, lector.GetDouble(7), ts.Days);
                                }
                                else if (tbxCrVendedor.Text.Length > 0 && tbxCrCliente.Text == "")
                                {
                                    dtgCrTabla.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), credito, abonado, lector.GetDouble(7), ts.Days);
                                }
                                else
                                {
                                    dtgCrTabla.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), credito, abonado, lector.GetDouble(7), ts.Days);

                                }
                            }

                        }
                        else if (cbxDias.Text == "Días mayor que")
                        {
                            credito = lector.GetDouble(5) + lector.GetDouble(6);
                            abonado = credito - lector.GetDouble(7); 
                            TimeSpan ts;
                            if (tbxCrVendedor.Text.Length > 0 && tbxCrCliente.Text == "")
                            {
                                ts = DateTime.Now.AddDays(1) - lector.GetDateTime(8);
                            }
                            else if (tbxCrVendedor.Text.Length == 0 && tbxCrCliente.Text.Length == 0)
                            {
                                ts = DateTime.Now.AddDays(1) - lector.GetDateTime(8);
                            }
                            else
                            {
                                ts = DateTime.Now.AddDays(1) - lector.GetDateTime(1);
                            }
                            if (tbxDias.Text == "")
                            {
                                tbxDias.Text = "0";
                            }
                            if (ts.Days > Convert.ToInt32(tbxDias.Text))
                            {
                                sumCredito += credito;
                                sumAbonado += abonado;
                                sumSaldo += lector.GetDouble(7);
                                if (tbxCrCliente.Text.Length > 0 && tbxCrVendedor.Text.Length > 0)
                                {
                                    dtgCrTabla.Rows.Add(lector.GetInt32(0), lector.GetDateTime(1).ToString("dd/MM/yyyy"), lector.GetString(2) + " " + lector.GetString(3) + " " + lector.GetString(4), credito, abonado, lector.GetDouble(7), ts.Days);
                                }
                                else if (tbxCrVendedor.Text.Length > 0 && tbxCrCliente.Text == "")
                                {
                                    dtgCrTabla.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), credito, abonado, lector.GetDouble(7), ts.Days);
                                }
                                else
                                {
                                    dtgCrTabla.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), credito, abonado, lector.GetDouble(7), ts.Days);

                                }
                            }

                        }
                    }
                    conectar.Close();
                    dtgCrTabla.Rows.Add("", "", "", sumCredito, sumAbonado, sumSaldo, "");
                    dtgCrTabla.Rows[dtgCrTabla.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                //}
                //else if (tbxCrVendedor.Text.Length > 0)
                //{

                //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxVendedor.Text != "")
                {
                    tbxNVendedor.Text = obtenerVendedor(tbxVendedor.Text);
                    //tbxVendedor.ReadOnly = true;
                    //btnSP.Enabled = false;
                    if (tbxNVendedor.Text.Length > 0)
                    {
                        if (tbxVendedor.Text != "")
                        {
                            tbxCliente.Focus();
                        }
                    }
                    else
                    {
                        tbxVendedor.ReadOnly = false;
                        btnSP.Enabled = true;
                        tbxVendedor.Focus();
                    }
                }
            }
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedor.Text = id.regresar.valXn;
                tbxNVendedor.Text = obtenerVendedor(tbxVendedor.Text);
            }
            tbxVendedor.ReadOnly = true;
            btnSP.Enabled = false;

            tbxCliente.Focus();
        }
        private void btnRVendedor_Click(object sender, EventArgs e)
        {
            tbxVendedor.Clear();
            btnSP.Enabled = true;
            tbxNVendedor.Clear();
            tbxCliente.Clear();
            tbxNCliente.Clear();

            tbxVendedor.ReadOnly = false;
            dtgHistTotales.Rows.Clear();
            dtgHistTabla.Rows.Clear();
        }

        private void tbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxCliente.Text.Length > 0)
                {
                    ObtnerCliente(tbxCliente.Text);
                    btnReporteHistorial.Focus();
                    if (tbxNCliente.Text == "")
                    {
                        tbxCliente.Focus();

                    }
                }
            }
        }
        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }
        private void tbxCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }
        private void btnB_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCliente.Text = id.regresar.valXn;
                ObtnerCliente(tbxCliente.Text);
            }
            tbxCliente.Focus();
        }
        private void btnRCliente_Click(object sender, EventArgs e)
        {
            tbxCliente.Clear();
            tbxNCliente.Clear();
            btnB.Enabled = true;
            tbxCliente.ReadOnly = false;
            dtgHistTabla.Rows.Clear();
            dtgHistTotales.Rows.Clear();
        }
        
        private void btnReporteHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                double abono = 0;
               
                    dtgHistTabla.Rows.Clear();
                    dtgHistTotales.Rows.Clear();
                    conectar = conn.ObtenerConexion();
                    if (tbxCliente.Text != "" && tbxVendedor.Text != "")
                    {
                        comando = new MySqlCommand("select b.folio, b.articulos_codigo, a.descripcion, a.valor_medida, u.nombre, b.SaldoAnterior," +
                            " b.abono, b.SaldoDespues, b.fecha from articulos a, abonos b, unidad_medida u where b.clientes_idclientes=" + tbxCliente.Text +
                            " and b.empleados_id_empleado=" + tbxVendedor.Text + " and a.unidad_medida_id=u.id and b.articulos_codigo=a.codigo" +
                            " and b.fecha between " + dtpInicio.Value.ToString("yyyyMMdd000000") + " and " + dtpFin.Value.ToString("yyyyMMdd235959") + " order by b.fecha asc", conectar);
                        dtgHistTotales.Visible = false;
                        dtgHistTabla.Visible = true;
                    }
                    else if (tbxCliente.Text == "" && tbxVendedor.Text != "")
                    {
                        comando = new MySqlCommand("select a.clientes_idclientes,c.nombre, sum(a.abono), a.fecha "+
                            "from clientes c, abonos a where a.empleados_id_empleado="+tbxVendedor.Text+" and a.clientes_idclientes=c.idclientes and "+
                            "a.fecha between " + dtpInicio.Value.ToString("yyyyMMdd000000") + " and " + dtpFin.Value.ToString("yyyyMMdd235959") + " group by day(a.fecha),c.nombre order by a.fecha asc;", conectar);
                        dtgHistTotales.Visible = true;
                        dtgHistTabla.Visible = false;
                    }
                    else if (tbxCliente.Text == "" && tbxVendedor.Text == "")
                    {
                        comando = new MySqlCommand("select a.clientes_idclientes,c.nombre, sum(a.abono), a.fecha " +
                            "from clientes c, abonos a where a.clientes_idclientes=c.idclientes and " +
                            "a.fecha between " + dtpInicio.Value.ToString("yyyyMMdd000000") + " and " + dtpFin.Value.ToString("yyyyMMdd235959") + " group by day(a.fecha),c.nombre order by a.fecha asc;", conectar);
                        dtgHistTotales.Visible = true;
                        dtgHistTabla.Visible = false;
                    }
                    conectar.Open();
                    
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        if (tbxCliente.Text != "" && tbxVendedor.Text != "")
                        {
                            dtgHistTabla.Rows.Add(lector.GetInt32(0), lector.GetInt32(1), lector.GetString(2) + " " + lector.GetString(3) +
                                " " + lector.GetString(4), lector.GetDouble(5), lector.GetDouble(6), lector.GetDouble(7), lector.GetDateTime(8));
                            abono += lector.GetDouble(6);
                        }
                        else if (tbxCliente.Text == "" && tbxVendedor.Text != "")
                        {
                            dtgHistTotales.Rows.Add(lector.GetString(0), lector.GetString(1),lector.GetDouble(2),lector.GetDateTime(3));
                                abono += lector.GetDouble(2);
                        }
                        else if (tbxCliente.Text == "" && tbxVendedor.Text == "")
                        {
                            dtgHistTotales.Rows.Add(lector.GetString(0), lector.GetString(1),lector.GetDouble(2), lector.GetDateTime(3));
                            abono += lector.GetDouble(2);
                        }
                        
                    }
                    conectar.Close();
                    if (tbxCliente.Text != "" && tbxVendedor.Text != "")
                    {
                        dtgHistTabla.Rows.Add("", "", "", "", abono, "", "");
                    }
                    else if (tbxCliente.Text == "" && tbxVendedor.Text != "")
                    {
                        dtgHistTotales.Rows.Add("", "", abono, "");
                    }
                    else if (tbxCliente.Text == "" && tbxVendedor.Text == "")
                    {

                        dtgHistTotales.Rows.Add("", "", abono, "");
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcelHistorial_Click(object sender, EventArgs e)
        {
            if (tbxCliente.Text != "" && tbxVendedor.Text != "")
            {
                AbrirConsultaExcel(dtgHistTabla);
            }
            else if (tbxCliente.Text == "" && tbxVendedor.Text != "")
            {
                AbrirConsultaExcel(dtgHistTotales); 
            }
            else if (tbxCliente.Text == "" && tbxVendedor.Text == "")
            {
                AbrirConsultaExcel(dtgHistTotales); 
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
                if (tabControl1.SelectedIndex == 0)
                {
                    oSheet.Cells[1, 2] = "REPORTE DE COBRANZA CRÉDITO";
                    oSheet.get_Range("A1", "G1").Merge(true);
                    oSheet.get_Range("A1", "G1").Font.Bold = true;
                    oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", "G1").Font.Size = 14;
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    oSheet.Cells[1, 2] = "REPORTE DEL HISTORIAL DE COBRANZA";
                    if (dtgHistTotales.Visible == true)
                    {
                        oSheet.get_Range("A1", "D1").Merge(true);
                    }
                    else if (dtgHistTotales.Visible == false)
                    {
                        oSheet.get_Range("A1", "G1").Merge(true);
                    }
                    
                    oSheet.get_Range("A1", "G1").Font.Bold = true;
                    oSheet.get_Range("A1", Type.Missing).VerticalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", Type.Missing).HorizontalAlignment =
                        Excel.XlVAlign.xlVAlignCenter;
                    oSheet.get_Range("A1", "G1").Font.Size = 14;

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
        int i = 0;
        private void printDocHistorial_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgHistTabla.Rows.Count > 0)
            {
                int height = 0;
                int an = -10;
                Font letra = new Font("Arial", 9);
                int x = 100;
                int L = 105;
                int y = 140;
                int col1 = dtgHistTabla.Columns[0].Width - an;
                int col2 = dtgHistTabla.Columns[1].Width - an;
                int col3 = dtgHistTabla.Columns[2].Width - an;
                int col4 = dtgHistTabla.Columns[3].Width - an;
                int col5 = dtgHistTabla.Columns[4].Width - an;
                int col6 = dtgHistTabla.Columns[5].Width - an;
                int col7 = dtgHistTabla.Columns[6].Width - an;
                Pen p = new Pen(Brushes.Black, 1.5f);

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("HISTORIAL DE COBRANZA", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 6 * 3, 50, 500, dtgHistTabla.Rows[0].Height + 15));
                #endregion

                #region RangosFecha
                e.Graphics.DrawString(dtpInicio.Value.ToString("dd/MMM/yyyy") + " - " + dtpFin.Value.ToString("dd/MMM/yyyy"), new Font("Arial", 11), Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, 115, 500, dtgHistTabla.Rows[0].Height + 15));
                #endregion

                if (tbxNVendedor.Text.Length > 0)
                {
                    #region NombreVendedor
                    e.Graphics.DrawString("Vendedor:" + tbxNVendedor.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 95, 500, dtgHistTabla.Rows[0].Height + 15));
                    #endregion
                }
                if (tbxNCliente.Text.Length > 0)
                {
                    #region Cliente
                    e.Graphics.DrawString("Cliente:" + tbxNCliente.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 115, 500, dtgHistTabla.Rows[0].Height + 15));
                    #endregion
                }
                #region Folios

                //                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[0].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x, y, col1, dtgHistTabla.Rows[0].Height + 15));

                #endregion


                #region CodigodeArticulo

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[1].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1, y, col2, dtgHistTabla.Rows[0].Height + 15));

                #endregion

                #region descripcion
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[2].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgHistTabla.Rows[0].Height + 15));


                #endregion

                #region SaldoAnterior

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[3].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));

                #endregion

                #region Abono

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[4].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgHistTabla.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                #region Pendiente

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[5].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgHistTabla.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion
                #region fechas

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTabla.Columns[6].HeaderText.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgHistTabla.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                height = 155;

                while (i < dtgHistTabla.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 155;
                        e.HasMorePages = true;
                        return;
                    }
                    height += dtgHistTabla.Rows[0].Height;

                    //e.Graphics.DrawRectangle(p, new Rectangle(100, height, dtgHistTabla.Columns[1].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[0].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L, height, dtgHistTabla.Columns[0].Width, dtgHistTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(100 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[2].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[1].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1, height, dtgHistTabla.Columns[1].Width, dtgHistTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(300 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[3].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[2].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgHistTabla.Columns[2].Width, dtgHistTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(400 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[4].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[3].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, dtgHistTabla.Columns[3].Width, dtgHistTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(500 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[5].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[4].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, dtgHistTabla.Columns[4].Width, dtgHistTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(500 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[5].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[5].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, dtgHistTabla.Columns[5].Width, dtgHistTabla.Rows[0].Height));
                    
                    e.Graphics.DrawString(dtgHistTabla.Rows[i].Cells[6].FormattedValue.ToString(), dtgHistTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, dtgHistTabla.Columns[6].Width, dtgHistTabla.Rows[0].Height));

                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void printDocCreditos_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgCrTabla.Rows.Count > 0)
            {

                int height = 0;
                //int width = 0;
                int an = -5;
                //int t = 260;
                Font letra = new Font("Arial", 9);
                // int width = 0;
                int x = 130;
                int L = 135;
                int y = 140;
                int col1 = dtgCrTabla.Columns[0].Width - an;
                int col2 = dtgCrTabla.Columns[1].Width - an;
                int col3 = dtgCrTabla.Columns[2].Width - an;
                int col4 = dtgCrTabla.Columns[3].Width - an;
                int col5 = dtgCrTabla.Columns[4].Width - an;
                int col6 = dtgCrTabla.Columns[5].Width - an;
                int col7 = dtgCrTabla.Columns[6].Width - an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("REPORTE DE CRÉDITOS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 5 * 2 + 50, 50, 500, dtgCrTabla.Rows[0].Height + 15));
                #endregion

                #region PendientesPagadasTotales
                if (rbtPendientes.Checked)
                {
                    e.Graphics.DrawString(rbtPendientes.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(e.MarginBounds.Width / 9 * 8, 95, 500, dtgCrTabla.Rows[0].Height + 15));
                }
                else if (rbtPagadas.Checked)
                {
                    e.Graphics.DrawString(rbtPagadas.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(e.MarginBounds.Width / 9 * 8, 95, 500, dtgCrTabla.Rows[0].Height + 15));
                }
                else if (rbtTodas.Checked)
                {
                    e.Graphics.DrawString(rbtTodas.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(e.MarginBounds.Width / 9 * 8, 95, 500, dtgCrTabla.Rows[0].Height + 15));
                }
                #endregion

                #region DiasMayorMenorque
                if (cbxDias.Text == "Días menor que")
                {
                    e.Graphics.DrawString("Menor que " + tbxDias.Text+" dias", new Font("Arial", 11), Brushes.Black, new Rectangle(e.MarginBounds.Width / 9 * 8, 115, 500, dtgCrTabla.Rows[0].Height + 15));
                }
                else if (cbxDias.Text == "Días mayor que")
                {
                    e.Graphics.DrawString("Mayor que " + tbxDias.Text +" dias", new Font("Arial", 11), Brushes.Black, new Rectangle(e.MarginBounds.Width / 9 * 8, 115, 500, dtgCrTabla.Rows[0].Height + 15));
                }
                #endregion

                //#region Fecha
                //e.Graphics.DrawString(dtpInicioC.Value.ToString("dd/MMM/yyyy") + " - " + dtpFinC.Value.ToString("dd/MMM/yyyy"), new Font("Arial", 11), Brushes.Black, new Rectangle(x, 95, 500, dtgCrTabla.Rows[0].Height + 15));
                //#endregion
                if (tbxNCrVendedor.Text.Length > 0)
                {
                    #region NombreVendedor
                    e.Graphics.DrawString("Vendedor:" + tbxNCrVendedor.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 95, 500, dtgCrTabla.Rows[0].Height + 15));
                    #endregion
                }
                if (tbxNCrCliente.Text.Length > 0)
                {
                    #region Cliente
                    e.Graphics.DrawString("Cliente:" + tbxNCrCliente.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 115, 500, dtgCrTabla.Rows[0].Height + 15));
                    #endregion
                }
                #region Folio

                Pen p = new Pen(Brushes.Black, 1.5f);

                //                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[0].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x, y, col1, dtgCrTabla.Rows[0].Height + 15));

                #endregion

                #region Fecha

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[1].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1, y, col2, dtgCrTabla.Rows[0].Height + 15));

                #endregion

                #region NombreCliente
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[2].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgCrTabla.Rows[0].Height + 15));

                #endregion

                #region Credito

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[3].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, dtgCrTabla.Rows[0].Height + 15));

                #endregion
                #region Abono

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[4].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgCrTabla.Rows[0].Height + 15));

                #endregion
                #region Saldo

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[5].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgCrTabla.Rows[0].Height + 15));

                #endregion
                #region Dias

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTabla.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgCrTabla.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCrTabla.Columns[6].HeaderText.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgCrTabla.Rows[0].Height + 15));

                #endregion

                height = 155;

                while (i < dtgCrTabla.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 155;
                        e.HasMorePages = true;
                        return;
                    }

                    height += dtgCrTabla.Rows[0].Height;

                    //e.Graphics.DrawRectangle(p, new Rectangle(100, height, dtgHistTabla.Columns[1].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[0].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L, height, dtgCrTabla.Columns[0].Width, dtgCrTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(100 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[2].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[1].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1, height, dtgCrTabla.Columns[1].Width, dtgCrTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(300 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[3].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[2].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgCrTabla.Columns[2].Width, dtgCrTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(400 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[4].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[3].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, dtgCrTabla.Columns[3].Width, dtgCrTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(300 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[3].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[4].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, dtgCrTabla.Columns[4].Width, dtgCrTabla.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(400 + dtgHistTabla.Columns[1].Width, height, dtgHistTabla.Columns[4].Width, dtgHistTabla.Rows[0].Height));
                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[5].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, dtgCrTabla.Columns[5].Width, dtgCrTabla.Rows[0].Height));

                    e.Graphics.DrawString(dtgCrTabla.Rows[i].Cells[6].FormattedValue.ToString(), dtgCrTabla.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, dtgCrTabla.Columns[6].Width, dtgCrTabla.Rows[0].Height));

                    i++;
                }
                i = 0;
                e.HasMorePages = false;
            }
        }

        private void btnImprimirCr_Click(object sender, EventArgs e)
        {

            (printPreviewCreditos as Form).WindowState = FormWindowState.Maximized;
            printPreviewCreditos.PrintPreviewControl.Zoom = 1;
            printDocCreditos.DefaultPageSettings.Landscape = true;
            printPreviewCreditos.ShowDialog();
        }

        private void btnImprimirHistorial_Click(object sender, EventArgs e)
        {
            if (tbxCliente.Text != "" && tbxVendedor.Text != "")
            {
                (printPreviewHistorial as Form).WindowState = FormWindowState.Maximized;
                printPreviewHistorial.PrintPreviewControl.Zoom = 1;
                printDocHistorial.DefaultPageSettings.Landscape = true;
                printPreviewHistorial.ShowDialog();
            }
            else if (tbxCliente.Text == "" && tbxVendedor.Text != "")
            {
                (printPreviewTotales as Form).WindowState = FormWindowState.Maximized;
                printPreviewTotales.PrintPreviewControl.Zoom = 1;
                printPreviewTotales.ShowDialog();
            }
            else if (tbxCliente.Text == "" && tbxVendedor.Text == "")
            {
                (printPreviewTotales as Form).WindowState = FormWindowState.Maximized;
                printPreviewTotales.PrintPreviewControl.Zoom = 1;
                printPreviewTotales.ShowDialog();
            }
        }

        private void tbxCliente_Leave(object sender, EventArgs e)
        {
            if (tbxCliente.Text.Length > 0)
            {
                ObtnerCliente(tbxCliente.Text);
                //btnReporteHistorial.Focus();
                
            }
        }

        private void tbxVendedor_Leave(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "")
            {
                tbxNVendedor.Text = obtenerVendedor(tbxVendedor.Text);
                //tbxVendedor.ReadOnly = true;
                btnSP.Enabled = false;
                if (tbxNVendedor.Text.Length > 0)
                {
                    if (tbxVendedor.Text != "")
                    {
                        tbxCliente.Focus();
                    }
                }
                else
                {
                    tbxVendedor.ReadOnly = false;
                    btnSP.Enabled = true;
                    tbxVendedor.Focus();
                }
            }
        }

        private void dtgCrTabla_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            if (e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "tblFolio" && e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // e.SortResult = dtgCrTabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgCrTabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgCrTabla.Rows[e.RowIndex1].Cells["tblFolio"].Value.ToString()),
                    Convert.ToInt32(dtgCrTabla.Rows[e.RowIndex2].Cells["tblFolio"].Value.ToString()));
            }    
            if (e.Column.Name == "tblCredito" && e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // e.SortResult = dtgCrTabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgCrTabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex1].Cells["tblCredito"].Value.ToString()),
                    Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex2].Cells["tblCredito"].Value.ToString()));
            }
            if (e.Column.Name == "tblAbono" && e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // e.SortResult = dtgCrTabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgCrTabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex1].Cells["tblAbono"].Value.ToString()),
                    Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex2].Cells["tblAbono"].Value.ToString()));
            }
            if (e.Column.Name == "tblSaldo" && e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex1].Cells["tblSaldo"].Value.ToString()),
                    Convert.ToDouble(dtgCrTabla.Rows[e.RowIndex2].Cells["tblSaldo"].Value.ToString()));
            }
            if (e.Column.Name == "tblDias" && e.RowIndex2 < dtgCrTabla.Rows.Count - 1 && e.RowIndex1 < dtgCrTabla.Rows.Count - 1)
            {
                // e.SortResult = dtgCrTabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgCrTabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgCrTabla.Rows[e.RowIndex1].Cells["tblDias"].Value.ToString()),
                    Convert.ToInt32(dtgCrTabla.Rows[e.RowIndex2].Cells["tblDias"].Value.ToString()));
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

        private void dtgHistTabla_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.RowIndex2 < dtgHistTabla.Rows.Count - 1 && e.RowIndex1 < dtgHistTabla.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "HistFolios" && e.RowIndex2 < dtgHistTabla.Rows.Count - 1 && e.RowIndex1 < dtgHistTabla.Rows.Count - 1)
            {
                // e.SortResult = dtgHistTabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgHistTabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgHistTabla.Rows[e.RowIndex1].Cells["HistFolios"].Value.ToString()),
                    Convert.ToInt32(dtgHistTabla.Rows[e.RowIndex2].Cells["HistFolios"].Value.ToString()));
            }
            if (e.Column.Name == "HistCodArt" && e.RowIndex2 < dtgHistTabla.Rows.Count - 1 && e.RowIndex1 < dtgHistTabla.Rows.Count - 1)
            {
                // e.SortResult = dtgHistTabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgHistTabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgHistTabla.Rows[e.RowIndex1].Cells["HistCodArt"].Value.ToString()),
                    Convert.ToInt32(dtgHistTabla.Rows[e.RowIndex2].Cells["HistCodArt"].Value.ToString()));
            }
            if (e.Column.Name == "HistSaldoAn" && e.RowIndex2 < dtgHistTabla.Rows.Count - 1 && e.RowIndex1 < dtgHistTabla.Rows.Count - 1)
            {
                // e.SortResult = dtgHistTabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgHistTabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgHistTabla.Rows[e.RowIndex1].Cells["HistSaldoAn"].Value.ToString()),
                    Convert.ToDouble(dtgHistTabla.Rows[e.RowIndex2].Cells["HistSaldoAn"].Value.ToString()));
            }
            if (e.Column.Name == "HistAbonos" && e.RowIndex2 < dtgHistTabla.Rows.Count - 1 && e.RowIndex1 < dtgHistTabla.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgHistTabla.Rows[e.RowIndex1].Cells["HistAbonos"].Value.ToString()),
                    Convert.ToDouble(dtgHistTabla.Rows[e.RowIndex2].Cells["HistAbonos"].Value.ToString()));
            }

            if (e.Column.Name == "HistSaldoDesp" && e.RowIndex2 < dtgHistTabla.Rows.Count - 1 && e.RowIndex1 < dtgHistTabla.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgHistTabla.Rows[e.RowIndex1].Cells["HistSaldoDesp"].Value.ToString()),
                    Convert.ToDouble(dtgHistTabla.Rows[e.RowIndex2].Cells["HistSaldoDesp"].Value.ToString()));
            }
            e.Handled = true;
        }

        private void printDocTotales_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgHistTotales.Rows.Count > 0)
            {
                int height = 0;
                int an = -10;
                Font letra = new Font("Arial", 9);
                int x = 100;
                int L = 105;
                int y = 140;
                int col1 = dtgHistTotales.Columns[0].Width - an;
                int col2 = dtgHistTotales.Columns[1].Width - an;
                int col3 = dtgHistTotales.Columns[2].Width - an;
                int col4 = dtgHistTotales.Columns[3].Width - an;
                Pen p = new Pen(Brushes.Black, 1.5f);

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("HISTORIAL DE COBRANZA", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 9 * 4, 50, 500, dtgHistTotales.Rows[0].Height + 15));
                #endregion

                #region RangosFecha
                e.Graphics.DrawString(dtpInicio.Value.ToString("dd/MMM/yyyy") + " - " + dtpFin.Value.ToString("dd/MMM/yyyy"), new Font("Arial", 11), Brushes.Black, new Rectangle(L + col1 + col2, 115, 500, dtgHistTotales.Rows[0].Height + 15));
                #endregion

                if (tbxNVendedor.Text.Length > 0)
                {
                    #region NombreVendedor

                    e.Graphics.DrawString("Vendedor:" + tbxNVendedor.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 95, 500, dtgHistTotales.Rows[0].Height + 15));
                    #endregion
                }
                if (tbxNCliente.Text.Length > 0)
                {
                    #region Cliente
                    e.Graphics.DrawString("Cliente:" + tbxNCliente.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 115, 500, dtgHistTotales.Rows[0].Height + 15));
                    #endregion
                }
              
                #region Folios

                //                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgHistTotales.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTotales.Columns[0].HeaderText.ToString(), dtgHistTotales.Font, Brushes.Black, new Rectangle(x, y, col1, dtgHistTotales.Rows[0].Height + 15));

                #endregion


                #region CodigodeArticulo

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgHistTotales.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTotales.Columns[1].HeaderText.ToString(), dtgHistTotales.Font, Brushes.Black, new Rectangle(x + col1, y, col2, dtgHistTotales.Rows[0].Height + 15));

                #endregion

                #region descripcion
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgHistTotales.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTotales.Columns[2].HeaderText.ToString(), dtgHistTotales.Font, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgHistTotales.Rows[0].Height + 15));


                #endregion

                #region SaldoAnterior

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, dtgHistTotales.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, dtgHistTotales.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgHistTotales.Columns[3].HeaderText.ToString(), dtgHistTotales.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, dtgHistTotales.Rows[0].Height + 15));

                #endregion            

                height = 155;

                while (i < dtgHistTotales.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 155;
                        e.HasMorePages = true;
                        return;
                    }
                    height += dtgHistTotales.Rows[0].Height;

                    //e.Graphics.DrawRectangle(p, new Rectangle(100, height, dtgHistTotales.Columns[1].Width, dtgHistTotales.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTotales.Rows[i].Cells[0].FormattedValue.ToString(), dtgHistTotales.Font, Brushes.Black, new Rectangle(L, height, dtgHistTotales.Columns[0].Width, dtgHistTotales.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(100 + dtgHistTotales.Columns[1].Width, height, dtgHistTotales.Columns[2].Width, dtgHistTotales.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTotales.Rows[i].Cells[1].FormattedValue.ToString(), dtgHistTotales.Font, Brushes.Black, new Rectangle(L + col1, height, dtgHistTotales.Columns[1].Width, dtgHistTotales.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(300 + dtgHistTotales.Columns[1].Width, height, dtgHistTotales.Columns[3].Width, dtgHistTotales.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTotales.Rows[i].Cells[2].FormattedValue.ToString(), dtgHistTotales.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgHistTotales.Columns[2].Width, dtgHistTotales.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(400 + dtgHistTotales.Columns[1].Width, height, dtgHistTotales.Columns[4].Width, dtgHistTotales.Rows[0].Height));
                    e.Graphics.DrawString(dtgHistTotales.Rows[i].Cells[3].FormattedValue.ToString(), dtgHistTotales.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, dtgHistTotales.Columns[3].Width, dtgHistTotales.Rows[0].Height));


                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void dtgHistTotales_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.RowIndex2 < dtgHistTotales.Rows.Count - 1 && e.RowIndex1 < dtgHistTotales.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "tblCodCliente" && e.RowIndex2 < dtgHistTotales.Rows.Count - 1 && e.RowIndex1 < dtgHistTotales.Rows.Count - 1)
            {
                // e.SortResult = dtgHistTabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgHistTabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgHistTotales.Rows[e.RowIndex1].Cells["tblCodCliente"].Value.ToString()),
                    Convert.ToInt32(dtgHistTotales.Rows[e.RowIndex2].Cells["tblCodCliente"].Value.ToString()));
            }
            if (e.Column.Name == "totabono" && e.RowIndex2 < dtgHistTotales.Rows.Count - 1 && e.RowIndex1 < dtgHistTotales.Rows.Count - 1)
            {
                // e.SortResult = dtgHistTabla.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgHistTabla.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgHistTotales.Rows[e.RowIndex1].Cells["totabono"].Value.ToString()),
                    Convert.ToDouble(dtgHistTotales.Rows[e.RowIndex2].Cells["totabono"].Value.ToString()));
            }
            e.Handled = true;
        }

        private void printPreviewTotales_Load(object sender, EventArgs e)
        {

        }

        private void rbtPendientes_CheckedChanged(object sender, EventArgs e)
        {
            dtgCrTabla.Rows.Clear();
        }

        private void rbtPagadas_CheckedChanged(object sender, EventArgs e)
        {
            dtgCrTabla.Rows.Clear();
        }

        private void rbtTodas_CheckedChanged(object sender, EventArgs e)
        {
            dtgCrTabla.Rows.Clear();
        }

        private void dtgCrTabla_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tbxCrCliente.Text == "")
            {
                if (dtgCrTabla.CurrentRow.Index < dtgCrTabla.Rows.Count - 1)
                {
                    DesplegableCreditoDetalle detalleProductos = new DesplegableCreditoDetalle(Conexion);
                    detalleProductos.ClienteID = dtgCrTabla[7, dtgCrTabla.CurrentRow.Index].Value.ToString();
                    detalleProductos.sFolio=dtgCrTabla[0, dtgCrTabla.CurrentRow.Index].Value.ToString();
                    if (rbtPendientes.Checked)
                    {
                        detalleProductos.EstadoCredito = " and v.pendiente>0";
                    }
                    else if (rbtPagadas.Checked)
                    {
                        detalleProductos.EstadoCredito = " and v.pendiente=0";
                    }
                    else if (rbtTodas.Checked)
                    {
                        detalleProductos.EstadoCredito = "";
                    }
                    detalleProductos.ShowDialog();
                }
            }
        }

       


    }
}
