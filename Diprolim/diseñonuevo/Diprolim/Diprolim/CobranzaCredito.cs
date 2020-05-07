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
using Entidades;

namespace Diprolim
{
    public partial class CobranzaCredito : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        String cmd;
        conexion conn = new conexion();
        MySqlCommand comando;
        MySqlConnection conectar;
        MySqlDataReader lector;
        DialogResult result;
        VentaBO objVentaBO;
        public CobranzaCredito(UnicaSQL.DBMS_Unico sConexion)
        {
            InitializeComponent();
            Conexion = sConexion;
            cmd = String.Empty;
            //objVentaBO = new VentaBO();
            //objVentaBO.ReAsignarDeudas();
        }       
        public CobranzaCredito(string id, UnicaSQL.DBMS_Unico sConexion)
        {

            InitializeComponent();
            Conexion = sConexion;
            cmd = String.Empty;
            //objVentaBO = new VentaBO();
            //objVentaBO.ReAsignarDeudas();

            tbxVendedor.Text = id;
            if (tbxVendedor.Text != "1")
            {
                obtenerVendedor();
                tbxCliente.Focus();
            }

        }
        public CobranzaCredito(string vend, string client, UnicaSQL.DBMS_Unico sConexion)
        {

            InitializeComponent();
            Conexion = sConexion;
            cmd = String.Empty;
            //objVentaBO = new VentaBO();
            //objVentaBO.ReAsignarDeudas();
            tbxVendedor.Text = vend;
            tbxCliente.Text = client;
            verificarAdeudos(client);
            if (tbxVendedor.Text != "1")
            {
                obtenerVendedor();
                ObtenerCliente();
            }
        }
        public void verificarAdeudos(string cliente)
        {

            cmd = String.Format("UPDATE ventas SET pendiente=0 WHERE pendiente<0.01 AND clientes_idclientes={0}", cliente);
            Conexion.Conectarse();
            Conexion.Ejecutar(cmd);
            Conexion.Desconectarse();
        }
        private void tbxFolio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ConsultarPorFolio();
            }
        }
        public void ConsultarPorFolio()
        {
            if (tbxFolio.Text.Length > 0)
            {
                string pendient = "";
                if (rbtTodos.Checked)
                {
                    pendient = "";
                }
                else if (rbtPendientes.Checked)
                {
                    pendient = " and v.pendiente>0";
                }
                else if (rbtPagados.Checked)
                {
                    pendient = " and v.pendiente=0";
                }
                double saldo = 0, pendiente = 0;
                dtgCredito.Rows.Clear();
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select v.folio, v.articulos_codigo,a.descripcion, a.valor_medida, um.nombre, v.cantidad," +
                    " v.precio_art, v.pendiente, v.idventas,v.clientes_idclientes,v.importe, DATEDIFF(now(), v.fecha_venta ) from ventas v, articulos a, unidad_medida um where v.tipo_compra='credito' and " +
                    "v.articulos_codigo=a.codigo and um.id=a.unidad_medida_id and v.folio=" + tbxFolio.Text + pendient, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dtgCredito.Rows.Add(lector.GetString(0), lector.GetString(1), lector.GetString(2) + " " + lector.GetString(3) + lector.GetString(4),
                        lector.GetString(5), lector.GetDouble(6), lector.GetDouble(7), 0, lector.GetDouble(7), lector.GetString(8), lector.GetDouble(10),
                        lector.GetDouble(11));
                    tbxCliente.Text = lector.GetString(9);
                    saldo += lector.GetDouble(7);
                    pendiente += lector.GetDouble(7);
                }
                conectar.Close();
                dtgCredito.Rows.Add("", "", "", "", "", saldo, 0, pendiente);
                dtgCredito.Rows[dtgCredito.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                //tblCredito[6, tblCredito.Rows.Count - 1].ReadOnly = true;
                ObtenerCliente2();
            }
        }

        private void btnSP_Click(object sender, EventArgs e)
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

        private void btnB_Click(object sender, EventArgs e)
        {
                BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCliente.Text = id.regresar.valXn;
                }
                tbxCliente.Focus();
                ObtenerCliente();
            
        }

        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoVendedor();
            }
        }
        public void MetodoVendedor()
        {
         //   if (tbxVendedor.Text != "1")
            {
                obtenerVendedor();
            }
        }
        public void obtenerVendedor()
        {
            if (tbxVendedor.Text != "")
            {

                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + tbxVendedor.Text, conectar);
                conectar.Open();

                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    tbxNVendedor.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    des = lector.GetString(0);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de vendedor no existente");
                    tbxVendedor.Text = "";
                    tbxNVendedor.Clear();

                }
                else
                {
                    tbxCliente.Focus();
                }

            }
        }
        public void obtenerVendedor2()
        {
            if (tbxVendedor.Text != "")
            {

                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + tbxVendedor.Text, conectar);
                conectar.Open();

                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    tbxNVendedor.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
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
        }
        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ObtenerCliente();
            }
        }
        public void ObtenerCliente()
        {
            Boolean existe = false;
            string vendedor = "";
            if (tbxCliente.Text != "")
            {
                dtgCredito.Rows.Clear();
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select idclientes,nombre,empleados_id_empleado from clientes where idclientes=" + tbxCliente.Text, conectar);                
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
                    if (tbxVendedor.Text != "1")
                    {
                        tbxVendedor.Text = vendedor;
                        obtenerVendedor();
                    }                   

                    desactivarControles();
                    verificarAdeudos(tbxCliente.Text);
                    obtenerCreditos();
                }
                else
                {
                    MessageBox.Show("El código de cliente no existe.");
                }

            }

        }
        public void ObtenerCliente2()
        {
            Boolean existe = false;
            string vendedor = "";
            if (tbxCliente.Text != "")
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select idclientes,nombre,empleados_id_empleado from clientes where idclientes=" + tbxCliente.Text, conectar);
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
                    if (tbxVendedor.Text != "1")
                    {
                        tbxVendedor.Text = vendedor;
                        obtenerVendedor2();
                    }
                    
                    desactivarControles();
                }
                else
                {
                    MessageBox.Show("El código de cliente no existe.");
                }

            }

        }
        public void desactivarControles()
        {
            tbxVendedor.ReadOnly = true;
            tbxCliente.ReadOnly = true;
            btnSV.Enabled = false;
            btnSC.Enabled = false;
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            btnSC.Enabled = true;
            tbxCliente.ReadOnly = false;
            tbxCliente.Clear();
            tbxNCliente.Clear();
            dtgCredito.Rows.Clear();
            tbxFolio.Clear();
        }
        public void obtenerCreditos()
        {
            verificarAdeudos(tbxCliente.Text);
            string pendient = "";
            if (rbtTodos.Checked)
            {
                pendient = "";
            }
            else if (rbtPendientes.Checked)
            {
                 pendient=" and v.pendiente>0";
            }
            else if (rbtPagados.Checked)
            {
                 pendient=" and v.pendiente=0";
            }
            double saldo = 0,pendiente = 0;
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select v.folio, v.articulos_codigo,a.descripcion, a.valor_medida, um.nombre, v.cantidad,"+
                " v.precio_art, v.pendiente, v.idventas,v.importe,DATEDIFF(now(), v.fecha_venta ) from ventas v, articulos a, "+
                "unidad_medida um where clientes_idclientes=" + tbxCliente.Text + " and v.tipo_compra='credito' and " +
                "v.articulos_codigo=a.codigo and um.id=a.unidad_medida_id" + pendient + " and v.empleados_id_empleado="+tbxVendedor.Text+" order by folio asc", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                dtgCredito.Rows.Add(lector.GetString(0),lector.GetString(1), lector.GetString(2)+" "+lector.GetString(3)+lector.GetString(4),
                    lector.GetString(5), lector.GetDouble(6), lector.GetDouble(7), 0, lector.GetDouble(7), lector.GetString(8), lector.GetDouble(9), 
                    lector.GetDouble(10));
                saldo += lector.GetDouble(7);
                pendiente += lector.GetDouble(7);
            }
            conectar.Close();
            dtgCredito.Rows.Add("","","","","",saldo,0,pendiente);
            dtgCredito.Rows[dtgCredito.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;

          //  tblCredito[6, tblCredito.Rows.Count - 1].ReadOnly = true;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnSC.Enabled = true;
            btnSV.Enabled = true;
            tbxVendedor.ReadOnly = false;
            tbxCliente.ReadOnly = false;
            tbxVendedor.Clear();
            tbxNVendedor.Clear();
            tbxCliente.Clear();
            tbxNCliente.Clear();
            dtgCredito.Rows.Clear();
            tbxFolio.Clear();
        }

        private void tbxCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnFolio_Click(object sender, EventArgs e)
        {
            buscarFolios id = new buscarFolios();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxFolio.Text = id.regresar.valXn;
            }
            tbxFolio.Focus();
            ConsultarPorFolio();
        }

        private void tblCredito_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtgCredito.Rows[e.RowIndex].ErrorText = String.Empty;
                sumaTotal();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void tblCredito_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dtgCredito.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("Abono")) return;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dtgCredito.Rows[e.RowIndex].ErrorText =
                    "No puedes dejar vacia esta celda";
                e.Cancel = true;
            }
        }

        private void tblCredito_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(tblCredito_KeyPress);
        
        }

        private void tblCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgCredito.CurrentCell.ColumnIndex == 6)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
                {

                    e.Handled = true;

                }
            }
        }

        private void tblCredito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int n = 0;
                if (dtgCredito.Rows.Count > 1)
                {

                    for (int i = 0; i < dtgCredito[6, e.RowIndex].Value.ToString().Length; i++)
                    {
                        if (dtgCredito[6, e.RowIndex].Value.ToString().Substring(i, 1) == ".")
                        {
                            n++;
                        }

                    }
                    if (n < 2)
                    {
                        dtgCredito[6, e.RowIndex].Value = Convert.ToDouble(dtgCredito[6, e.RowIndex].Value);
                        if (e.RowIndex == dtgCredito.Rows.Count - 1 && Convert.ToDouble(dtgCredito[6, e.RowIndex].Value) <= Convert.ToDouble(dtgCredito[5, e.RowIndex].Value))
                        {
                            if (!evitar)
                            {
                                disAbono(Convert.ToDouble(dtgCredito[6, e.RowIndex].Value));

                            }
                            //  tblCredito[6, e.RowIndex].Value = 0.00;
                        }
                        else if (Convert.ToDouble(dtgCredito[5, e.RowIndex].Value) >= Convert.ToDouble(dtgCredito[6, e.RowIndex].Value))
                        {
                            dtgCredito[7, e.RowIndex].Value = Convert.ToDouble(dtgCredito[5, e.RowIndex].Value) - Convert.ToDouble(dtgCredito[6, e.RowIndex].Value);

                        }
                        else
                        {
                            MessageBox.Show("No puede abonar una cantidad mayor al saldo.");
                            dtgCredito[6, e.RowIndex].Value = 0.00;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No puede ingresar mas de un punto decinal.");
                        dtgCredito[6, e.RowIndex].Value = 0.00;
                    }

                }
                evitar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                                                                                                               
            }
        }
        Boolean evitar = false;
        //metodo para distribuir abono en diferentes adeudos.
        public void disAbono(double abono)
        {
            double resto = abono;
          
            for (int i = 0; i < dtgCredito.Rows.Count - 1; i++)
            {
                
                if (resto >= Convert.ToDouble(dtgCredito[5, i].Value))
                {                    
                    resto = resto - Convert.ToDouble(dtgCredito[5, i].Value);
                    dtgCredito[6, i].Value = Convert.ToDouble(dtgCredito[5, i].Value);
                    dtgCredito[7, i].Value = Convert.ToDouble(dtgCredito[5, i].Value) - Convert.ToDouble(dtgCredito[6, i].Value);
                }
                else if (resto > 0 && resto < Convert.ToDouble(dtgCredito[5, i].Value))
                {                 
                    dtgCredito[6, i].Value = resto;
                    dtgCredito[7, i].Value = Convert.ToDouble(dtgCredito[5, i].Value) - Convert.ToDouble(dtgCredito[6, i].Value);
                    resto = 0;
                }
                else
                {
                    dtgCredito[6, i].Value = 0.00;
                    dtgCredito[7, i].Value = Convert.ToDouble(dtgCredito[5, i].Value) - Convert.ToDouble(dtgCredito[6, i].Value);
                }
            }
        }
        public void sumaTotal()
        {
            try
            {
                if (dtgCredito.Rows.Count > 0)
                {
                    double abono = 0;
                    double pendiente = 0;
                    double k=0;
                    for (int i = 0; i < dtgCredito.Rows.Count - 1; i++)
                    {
                        if (double.TryParse(dtgCredito[6, i].Value.ToString(),out k))
                        {
                            abono += Convert.ToDouble(dtgCredito[6, i].Value);
                            pendiente += Convert.ToDouble(dtgCredito[7, i].Value);
                        }
                        else
                        {
                            dtgCredito[6, i].Value = Convert.ToDouble(0);
                        }
                    }
                    evitar = true;
                    dtgCredito[6, dtgCredito.Rows.Count - 1].Value = abono;
                    evitar = true;
                    dtgCredito[7, dtgCredito.Rows.Count - 1].Value = pendiente;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void tblCredito_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.RowIndex2 < dtgCredito.Rows.Count - 1 && e.RowIndex1 < dtgCredito.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "tblCrCodArt" && e.RowIndex2 < dtgCredito.Rows.Count - 1 && e.RowIndex1 < dtgCredito.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToInt32(dtgCredito.Rows[e.RowIndex1].Cells["tblCrCodArt"].Value.ToString()),
                    Convert.ToInt32(dtgCredito.Rows[e.RowIndex2].Cells["tblCrCodArt"].Value.ToString()));
            }
            if (e.Column.Name == "tblCrCantidad" && e.RowIndex2 < dtgCredito.Rows.Count - 1 && e.RowIndex1 < dtgCredito.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgCredito.Rows[e.RowIndex1].Cells["tblCrCantidad"].Value.ToString()),
                    Convert.ToDouble(dtgCredito.Rows[e.RowIndex2].Cells["tblCrCantidad"].Value.ToString()));
            }

            if (e.Column.Name == "tblCrPrecio" && e.RowIndex2 < dtgCredito.Rows.Count - 1 && e.RowIndex1 < dtgCredito.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgCredito.Rows[e.RowIndex1].Cells["tblCrPrecio"].Value.ToString()),
                    Convert.ToDouble(dtgCredito.Rows[e.RowIndex2].Cells["tblCrPrecio"].Value.ToString()));
            }

            if (e.Column.Name == "tblCrSaldo" && e.RowIndex2 < dtgCredito.Rows.Count - 1 && e.RowIndex1 < dtgCredito.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgCredito.Rows[e.RowIndex1].Cells["tblCrSaldo"].Value.ToString()),
                    Convert.ToDouble(dtgCredito.Rows[e.RowIndex2].Cells["tblCrSaldo"].Value.ToString()));
            }
            if (e.Column.Name == "tblCrAbono" && e.RowIndex2 < dtgCredito.Rows.Count - 1 && e.RowIndex1 < dtgCredito.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgCredito.Rows[e.RowIndex1].Cells["tblCrAbono"].Value.ToString()),
                    Convert.ToDouble(dtgCredito.Rows[e.RowIndex2].Cells["tblCrAbono"].Value.ToString()));
            }
            if (e.Column.Name == "tblCrPendiente" && e.RowIndex2 < dtgCredito.Rows.Count - 1 && e.RowIndex1 < dtgCredito.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgCredito.Rows[e.RowIndex1].Cells["tblCrPendiente"].Value.ToString()),
                    Convert.ToDouble(dtgCredito.Rows[e.RowIndex2].Cells["tblCrPendiente"].Value.ToString()));
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
        int Depa = 0;
        public void obtenerDepartamento(string cod_art)
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("SELECT departamento FROM articulos WHERE codigo =" + cod_art, conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Depa = lector.GetInt32(0);

            }
            conectar.Close();


        }
        Double ComisionN = 0;
        public void ObtenerComision()
        {
            string sTipoCategoria = "";
            if (Depa == 2) { sTipoCategoria = "Accesorios"; }
            if (Depa == 3) { sTipoCategoria = "Papel"; }
            conectar = conn.ObtenerConexion();

            comando = new MySqlCommand("SELECT Vendedor FROM categorias WHERE nombre='" + sTipoCategoria + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                ComisionN = lector.GetDouble(0);
            }
            conectar.Close();
        }
        int idCategoria;
        double comisionC;
        public void ObtenerClienteComision()
        {
            if (tbxCliente.Text != "")
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("SELECT a.idclientes, a.nombre, a.categorias_idcategorias, u.Vendedor " +
                            "FROM clientes a, categorias u WHERE idclientes =" + tbxCliente.Text + " AND a.categorias_idcategorias=u.idcategorias", conectar);

                conectar.Open();

                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {

                    idCategoria = lector.GetInt32(2);
                    comisionC = lector.GetInt32(3);
                    tbxNCliente.Text = lector.GetString(1);
                    des = lector.GetString(0);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de cliente no existente");
                }
            }

        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Boolean bAllOK = false;
            ComisionBO objComisionBO = new ComisionBO();
            int iDias = 0;
            try
            {
                
                if (dtgCredito.Rows.Count > 0)
                {
                    if (ValidarFoliosCompletos())
                    {
                        result = MessageBox.Show("Se va registrar un abono ¿Desea continuar?", "Registro de abonos", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            conectar = conn.ObtenerConexion();
                            for (int i = 0; i < dtgCredito.Rows.Count - 1; i++)
                            {
                                if (Convert.ToDouble(dtgCredito[6, i].Value) > 0)
                                {
                                    iDias =Convert.ToInt32(dtgCredito[10, i].Value);
                                    obtenerDepartamento(dtgCredito[1, i].Value.ToString());
                                    ObtenerClienteComision();
                                    if (Depa != 1)
                                    {
                                        ObtenerComision();
                                        comisionC = ComisionN;
                                    }
                                    double comision = (Convert.ToDouble(dtgCredito[9, i].Value) - Convert.ToDouble(dtgCredito[7, i].Value)) * (comisionC / 100);
                                    
                                    cmd = String.Format("UPDATE ventas SET comision=" + comision + ", pendiente=" + Convert.ToDouble(dtgCredito[7, i].Value) + 
                                        " WHERE idventas=" + Convert.ToInt32(dtgCredito[8, i].Value) + "", conectar);
                                    Conexion.Conectarse();
                                    Conexion.IniciarTransaccion();
                                    Conexion.Ejecutar(cmd);
                                    bAllOK = true;
                                    if (Convert.ToDouble(dtgCredito[6, i].Value) > 0)
                                    {
                                        comision = objComisionBO.CalcularComisionAbonos(iDias, Convert.ToInt32(tbxVendedor.Text),
                                            Convert.ToDouble(dtgCredito[6, i].Value), Convert.ToInt32(dtgCredito[1, i].Value),
                                            Convert.ToInt32(tbxCliente.Text), Convert.ToInt32(dtgCredito[8, i].Value));
                                        bAllOK = false;
                                        cmd = String.Format("INSERT INTO abonos values(null," + Convert.ToDouble(dtgCredito[0, i].Value) + "," +
                                            Convert.ToDouble(dtgCredito[1, i].Value) + "," + tbxCliente.Text + "," + tbxVendedor.Text + ","
                                            + Convert.ToDouble(dtgCredito[5, i].Value) + "," + Convert.ToDouble(dtgCredito[6, i].Value) + "," +
                                            Convert.ToDouble(dtgCredito[7, i].Value) + "," + DateTime.Now.ToString("yyyyMMddHHmmss") + "," +
                                            Convert.ToInt32(dtgCredito[8, i].Value) + "," + comision + "," + iDias + ")", conectar);
                                        Conexion.Ejecutar(cmd);
                                        bAllOK = true;
                                    }
                                    Conexion.FinTransaccion(bAllOK);
                                    Conexion.Desconectarse();
                                }
                            }
                            dtgCredito.Rows.Clear();
                            tbxCliente.ReadOnly = false;
                            btnSC.Enabled = true;
                            MessageBox.Show("Registro realizado con éxito.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Es necesario capturar el abono completo por folio.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Boolean ValidarFoliosCompletos()
        {
            Boolean bAllOK = false;
            int folio;
            double sumaAdeudo = 0, sumaAbono = 0;
            if(dtgCredito.Rows.Count>0)
            {
                for(int i=0;i<dtgCredito.Rows.Count-1;i++)
                {
                    folio = Convert.ToInt32(dtgCredito[0, i].Value);
                    sumaAbono=0;
                    sumaAdeudo = 0;
                    for(int j=0;j<dtgCredito.Rows.Count-1;j++)
                    {
                        if (folio == Convert.ToInt32(dtgCredito[0, j].Value))
                        {
                            sumaAdeudo += Convert.ToDouble(dtgCredito[5, j].Value);
                            sumaAbono += Convert.ToDouble(dtgCredito[6, j].Value);
                        }
                    }
                    if(sumaAdeudo==sumaAbono || sumaAbono==0)
                    {
                        bAllOK = true;
                    }
                    else
                    {                        
                        bAllOK = false;
                        break;
                    }
                }
            }
            return bAllOK;
        }
        private void rbtPendientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPendientes.Checked)
            {
                if (tbxCliente.Text.Length > 0)
                {
                    dtgCredito.Rows.Clear();
                    obtenerCreditos();
                }
            }
        }

        private void rbtTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtTodos.Checked)
            {
                if (tbxCliente.Text.Length > 0)
                {
                    dtgCredito.Rows.Clear();
                    obtenerCreditos();
                }
            }
        }

        private void rbtPagados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPagados.Checked)
            {
                if (tbxCliente.Text.Length > 0)
                {
                    dtgCredito.Rows.Clear();
                    obtenerCreditos();
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }
        int i = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgCredito.Rows.Count > 0)
            {
                int height = 0;
                int an = -10;
                Font letra = new Font("Arial", 9);
                int x = 100;
                int L = 105;
                int y = 140;
                int col1 = dtgCredito.Columns[0].Width - an;
                int col2 = dtgCredito.Columns[1].Width - an;
                int col3 = dtgCredito.Columns[2].Width - an;
                int col4 = dtgCredito.Columns[3].Width - an;
                int col5 = dtgCredito.Columns[4].Width - an;
                int col6 = dtgCredito.Columns[5].Width - an;
                int col7 = dtgCredito.Columns[6].Width - an;
                int col8 = dtgCredito.Columns[7].Width - an;
                Pen p = new Pen(Brushes.Black, 1.5f);

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("COBRANZA CRÉDITO", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 6 * 3, 50, 500, dtgCredito.Rows[0].Height + 15));
                #endregion

                #region NombreCliente
                e.Graphics.DrawString("Cliente:" + tbxNCliente.Text, new Font("Arial", 11), Brushes.Black, new Rectangle(x, 115, 500, dtgCredito.Rows[0].Height + 15));
                #endregion

                #region Folios

                //                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, col1, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCredito.Columns[0].HeaderText.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(x, y, col1, dtgCredito.Rows[0].Height + 15));

                #endregion


                #region CodigodeArticulo

                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1, 100, col2 + 100, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCredito.Columns[1].HeaderText.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(x + col1, y, col2, dtgCredito.Rows[0].Height + 15));

                #endregion

                #region descripcion
                //               e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2, 100, col3, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCredito.Columns[2].HeaderText.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgCredito.Rows[0].Height + 15));


                #endregion

                #region Cantidad

                //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3, y, col4, tblCredito.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, dtgCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCredito.Columns[3].HeaderText.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, dtgCredito.Rows[0].Height + 15));

                #endregion

                #region Precio

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCredito.Columns[4].HeaderText.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgCredito.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                #region Saldo

                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCredito.Columns[5].HeaderText.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgCredito.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                #region Abono
                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCredito.Columns[6].HeaderText.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgCredito.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                #region Pendiente
                //              e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100 + col1 + col2 + col3 + col4, 100, col5, tblSalidas.Rows[0].Height + 15));
                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, dtgCredito.Rows[0].Height + 15));
                e.Graphics.DrawString(dtgCredito.Columns[7].HeaderText.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, dtgCredito.Rows[0].Height + 15));
                //   MessageBox.Show("" + tblSalidas.Rows[1].Height);
                #endregion

                height = 155;

                while (i < dtgCredito.Rows.Count)
                {
                    if (height > e.MarginBounds.Height)
                    {
                        height = 155;
                        e.HasMorePages = true;
                        return;
                    }
                    height += dtgCredito.Rows[0].Height;

                    //e.Graphics.DrawRectangle(p, new Rectangle(100, height, tblCredito.Columns[1].Width, tblCredito.Rows[0].Height));
                    e.Graphics.DrawString(dtgCredito.Rows[i].Cells[0].FormattedValue.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(L, height, dtgCredito.Columns[0].Width, dtgCredito.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(100 + tblCredito.Columns[1].Width, height, tblCredito.Columns[2].Width, tblCredito.Rows[0].Height));
                    e.Graphics.DrawString(dtgCredito.Rows[i].Cells[1].FormattedValue.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(L + col1, height, dtgCredito.Columns[1].Width, dtgCredito.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(300 + tblCredito.Columns[1].Width, height, tblCredito.Columns[3].Width, tblCredito.Rows[0].Height));
                    e.Graphics.DrawString(dtgCredito.Rows[i].Cells[2].FormattedValue.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgCredito.Columns[2].Width, dtgCredito.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(400 + tblCredito.Columns[1].Width, height, tblCredito.Columns[4].Width, tblCredito.Rows[0].Height));
                    e.Graphics.DrawString(dtgCredito.Rows[i].Cells[3].FormattedValue.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, dtgCredito.Columns[3].Width, dtgCredito.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(500 + tblCredito.Columns[1].Width, height, tblCredito.Columns[5].Width, tblCredito.Rows[0].Height));
                    e.Graphics.DrawString(dtgCredito.Rows[i].Cells[4].FormattedValue.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, dtgCredito.Columns[4].Width, dtgCredito.Rows[0].Height));

                    //e.Graphics.DrawRectangle(p, new Rectangle(500 + tblCredito.Columns[1].Width, height, tblCredito.Columns[5].Width, tblCredito.Rows[0].Height));
                    e.Graphics.DrawString(dtgCredito.Rows[i].Cells[5].FormattedValue.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, dtgCredito.Columns[5].Width, dtgCredito.Rows[0].Height));

                    e.Graphics.DrawString(dtgCredito.Rows[i].Cells[6].FormattedValue.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, dtgCredito.Columns[6].Width, dtgCredito.Rows[0].Height));
                    
                    e.Graphics.DrawString(dtgCredito.Rows[i].Cells[7].FormattedValue.ToString(), dtgCredito.Font, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7, height, dtgCredito.Columns[7].Width, dtgCredito.Rows[0].Height));


                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
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
                }
                tbxVendedor.Focus();
                MetodoVendedor();
            }
        }

        private void tbxCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCliente.Text = id.regresar.valXn;
                }
                tbxCliente.Focus();
                ObtenerCliente();
            }
        }
        private Double CalcularComision(int iDias)
        {
            Double descuentoComision = 0;
            DataTable dtDatos = new DataTable();
            ComisionBO objComisionBO = new ComisionBO();
            dtDatos = objComisionBO.ObtenerDescuentosComision();
            CEmpleados objCEmpleados = new CEmpleados();
            EmpleadoBO objEmpleadoBO = new EmpleadoBO();
            objCEmpleados=objEmpleadoBO.ObtenerDatosVendedor(12);
            return descuentoComision;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcularComision(15);
        }

        private void CobranzaCredito_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Saliendo de Cobranza crédito", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    this.Close();
                }
            }
        }
    }
}
