using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Diprolim
{
    public partial class Capturar_Entrada : Form
    {
        Inventarios.DBMS_Unico Conexion;
        String cmd;
        conexion conn = new conexion();
        String motivo;
        MySqlCommand comando;
        double CT = 0;
        double cantidad = 0;
        double total2 = 0;
        int codigo = 0;
        string UsuarioID = "";
        DialogResult result;
        string Operacion = "";
        String NOMBREVENDEDOR = "";

        public Capturar_Entrada()
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            cbxMotivo.SelectedIndex = 0;
            motivo = cbxMotivo.Text;
            CargarFolio();
        }
        public Capturar_Entrada(string usuarioId, Inventarios.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
            dtpFecha.Value = DateTime.Now;
            cbxMotivo.SelectedIndex = 0;
            UsuarioID = usuarioId;
            motivo = cbxMotivo.Text;
            CargarFolio();
        }
        public void checarInventarioVendedor()
        {
            
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand(" select count(*) from inv_vendedor where cantidad>0 and articulos_codigo=" + tbxProducto.Text + " and empleados_id_empleado=" + tbxVendedor.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                int des = 0;
                while (lector.Read())
                {
                    des = lector.GetInt32(0);

                }
                conectar.Close();
                if (des == 0)
                {
                    tbxProducto.Clear();
                    tbxNProducto.Clear();
                    MessageBox.Show("Articulo incorreco");
                    tbxExistencias.Clear();
                }          
           
        }
        public void obtenerCantidad()
        {
            if (tbxProducto.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand(" select cantidad from inv_vendedor where articulos_codigo=" + tbxProducto.Text + " and empleados_id_empleado=" + tbxVendedor.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    CT = lector.GetDouble(0);

                }
                conectar.Close();
                tbxExistencias.Text = CT.ToString();
            }
        }
           
            
        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoProducto();
            }
        }
        public void MetodoProducto()
        {
            if (cbxMotivo.Text == "Devolución por consignación")
            {
                if (tbxProducto.Text != "")
                {
                    DataTable tbl = new DataTable();
                    cmd = String.Format("SELECT a.codigo, a.descripcion, a.valor_medida, c.nombre, sum(i.cantidad) as Cantidad,i.Fecha " +
                             "from articulos a, unidad_medida c, inv_clientes i where i.cantidad>0 and a.unidad_medida_id=c.id and " +
                             "i.clientes_idclientes={0} and i.articulos_codigo = {1} and i.articulos_codigo=a.codigo GROUP BY a.codigo",
                             tbxVendedor.Text, tbxProducto.Text);
                    Conexion.Conectarse();
                    Conexion.Ejecutar(cmd, ref tbl);
                    Conexion.Desconectarse();
                    if (tbl.Rows.Count > 0)
                    {
                        DataRow row = tbl.Rows[0];
                        tbxExistencias.Text = row["Cantidad"].ToString();
                        tbxNProducto.Text = row["descripcion"].ToString() + " " + row["valor_medida"].ToString() + " " + row["nombre"].ToString();
                        FechaConsignacion = row["Fecha"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("El producto no se encuentra en consignación");
                        tbxProducto.Clear();
                        tbxNProducto.Clear();
                        tbxExistencias.Clear();
                    }
                }
                if (tbxProducto.Text != "" && tbxNProducto.Text != "")
                {

                    tbxCantidad.Focus();
                }
            }
            else
            {
                #region noconsignacion
                if (tbxVendedor.Text.Length > 0 && cbxMotivo.Text == "Devolución de Vendedor")
                {
                    if (tbxProducto.Text != "")
                    {
                        if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
                        {
                            checarInventarioVendedor();
                            obtenerCantidad();
                        }
                        if (tbxProducto.Text != "")
                        {
                            ObtenerP();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Primero es necesario indicar un código de artículo");
                    }
                }
                else if (cbxMotivo.Text != "Devolución de Vendedor")
                {
                    if (tbxProducto.Text != "")
                    {
                        ObtenerP();
                    }
                }
                else
                {
                    MessageBox.Show("Primero es necesario indicar un código de artículo");
                    tbxVendedor.Focus();
                }
                #endregion

            }
        }
        string FechaConsignacion = "";
    
        double CantidadInicial = 0;
        public void ObtenerP()
        {
            if (tbxProducto.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre, a.cantidad " +
                        "FROM articulos a, unidad_medida u WHERE codigo =" + tbxProducto.Text + " and a.unidad_medida_id=u.id", conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    tbxNProducto.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    des = lector.GetString(1);
                   

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
        
        private void button1_Click(object sender, EventArgs e)
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
                        if (cbxMotivo.Text != "Entradas a vendedores" && cbxMotivo.Text != "Devolución de Vendedor")
                        {
                            double cantidad = 0;
                            if (cbxMotivo.Text != "Devolución por consignación")
                            {
                                FechaConsignacion = DateTime.Now.ToString();
                            }
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

                                Tabla.Rows.Add(false, lector1.GetString(0), lector1.GetString(1) + " " + lector1.GetString(2) + " " + lector1.GetString(3), tbxCantidad.Text, cantidad + Convert.ToDouble(tbxCantidad.Text), cantidad, FechaConsignacion);

                                tbxCantidad.Clear();
                                tbxProducto.Clear();
                                tbxNProducto.Clear();
                                tbxExistencias.Clear();
                                tbxProducto.Focus();
                            }
                            conectar1.Close();
                        }
                        else if (cbxMotivo.Text == "Devolución de Vendedor")
                        {
                            DataTable tbl = new DataTable();
                            cmd = String.Format("SELECT a.codigo, a.cantidad,i.cantidad as cantv FROM articulos a, inv_vendedor i "+
                                " WHERE a.codigo ={0} and a.codigo=i.articulos_codigo and i.empleados_id_empleado={1};",
                                tbxProducto.Text,tbxVendedor.Text);
                            Conexion.Conectarse();
                            Conexion.Ejecutar(cmd, ref tbl);
                            Conexion.Desconectarse();
                            if (tbl.Rows.Count > 0)
                            {
                                DataRow row = tbl.Rows[0];
                                Tabla.Rows.Add(false, row["codigo"], tbxNProducto.Text, tbxCantidad.Text,
                                    Convert.ToDouble(row["cantidad"]) + Convert.ToDouble(tbxCantidad.Text), Convert.ToDouble(row["cantidad"]),
                                    dtpFecha.Value, Convert.ToDouble(row["cantv"]));

                                tbxCantidad.Clear();
                                tbxProducto.Clear();
                                tbxNProducto.Clear();
                                tbxExistencias.Clear();
                                tbxProducto.Focus();
                            }

                        }
                        else
                        {
                            DataTable tbl = new DataTable();
                            cmd = String.Format("SELECT Cantidad FROM inv_vendedor WHERE"+
                                " empleados_id_empleado={0} AND articulos_codigo={1}",
                                tbxVendedor.Text,tbxProducto.Text);
                            Conexion.Conectarse();
                            Conexion.Ejecutar(cmd, ref tbl);
                            Conexion.Desconectarse();
                            if (tbl.Rows.Count > 0)
                            {
                                DataRow row = tbl.Rows[0];
                                Tabla.Rows.Add(false, tbxProducto.Text, tbxNProducto.Text, tbxCantidad.Text,
                                    Convert.ToDouble(row["Cantidad"]) + Convert.ToDouble(tbxCantidad.Text), row["Cantidad"],
                                    dtpFecha.Value);
                            }
                            else
                            {
                                cmd = String.Format("INSERT INTO inv_vendedor VALUES(null,{0},{1},{2})",
                                0,tbxVendedor.Text, tbxProducto.Text);
                                Conexion.Conectarse();
                                Conexion.Ejecutar(cmd, ref tbl);
                                Conexion.Desconectarse();

                                Tabla.Rows.Add(false, tbxProducto.Text, tbxNProducto.Text, tbxCantidad.Text,
                                    0 + Convert.ToDouble(tbxCantidad.Text), 0,
                                    dtpFecha.Value);
                            }
                            tbxCantidad.Clear();
                            tbxProducto.Clear();
                            tbxNProducto.Clear();
                            tbxExistencias.Clear();
                            tbxProducto.Focus();
                        }
                    }
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxCantidad.Text != "")
            {
                 if (tbxCantidad.Text != ".")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (tbxExistencias.Text != ""&&tbxExistencias.Visible==true)
                    {
                        if (Convert.ToDouble(tbxCantidad.Text) <= Convert.ToDouble(tbxExistencias.Text))
                        {

                            button1.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No puede devolver más de lo que tiene el vendedor");
                        }
                    }
                    else
                    {
                        button1.Focus();
                    }
                }
                    
                    
                }
            }
        }

        private void Capturar_Entrada_Load(object sender, EventArgs e)
        {
            CargarFolio();
        }
        int Folio = 0;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
        int vendedor = 0;
       

        private void btnSP_Click(object sender, EventArgs e)
        {
            if (cbxMotivo.Text == "Devolución por consignación")
            {
                if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
                {
                    BuscarArticuloss id = new BuscarArticuloss(tbxVendedor.Text);
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxProducto.Text = id.regresar.valXn;
                    }
                    tbxProducto.Focus();
                    MetodoProducto();
                }
            }
            else
            {
                if (tbxVendedor.Text != "" && tbxNVendedor.Text != ""&&cbxMotivo.Text != "Devolucion de Cliente")
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
                else
                {
                    BuscarArticulos id = new BuscarArticulos();
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxProducto.Text = id.regresar.valXn;
                    }
                    tbxProducto.Focus();
                    MetodoProducto();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
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

        private void tbxComentarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 92)
            {

                e.Handled = true;

            }
        }
        string inicial;
        public int CargarFolio()
        {
            Folio = 0;
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand("select IdFolios from Folios_Entradas", conectar);
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
            tbxFolioDE.Text =inicial+"-"+ Folio.ToString();
            return Folio;
        }

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
        String sucursalOrigen = "", sucursalDestino="",Prefijo="";
        int ini = 0;
        private void cbxMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = "Vendedor:";
            if (ini == 0)
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("Select nombre,iniciales from almacenes where origen=true", conectar);
                conectar.Open();
                MySqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Prefijo = lector.GetString(1);
                    sucursalDestino = lector.GetString(1) + "-" + lector.GetString(0);
                    tbxFolioDE.Text = Prefijo + "-" + CargarFolio();
                }
                conectar.Close();
                if (Tabla.Rows.Count > 0)
                {
                   

                    result = MessageBox.Show("Está cambiando de motivo y hay información sin guardar ¿Desea continuar?", "Registrar entrada a inventario", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        lblExistencias.Visible = false;
                        Tabla.Rows.Clear();
                        tbxExistencias.Visible = false;
                        tbxExistencias.Clear();
                        tbxVendedor.Enabled = false;
                        tbxVendedor.Clear();
                        tbxNVendedor.Clear();
                        btnSV.Enabled = false;
                        tbxNVendedor.Enabled = false;
                        btnCambiarVendedor.Enabled = false;
                        tbxProducto.Clear();
                        tbxNProducto.Clear();
                        tbxCantidad.Clear();
                        //tbxFolioDE.Text = CargarFolio().ToString();
                        if (cbxMotivo.Text == "Devolución de Vendedor")
                        {
                            btnCambiarVendedor.Enabled = false;
                            tbxVendedor.Enabled = true;
                            btnSV.Enabled = true;
                            btnCambiarVendedor.Enabled = true;
                            lblExistencias.Visible = true;
                            tbxExistencias.Visible = true;
                            tbxExistencias.Clear();
                        }

                    }
                    else
                    {
                        ini = 1;
                        cbxMotivo.Text = motivo;
                        
                    }
                }
                else if (cbxMotivo.Text == "Normal")
                {
                    label7.Visible = false;
                    cbxAlmacen.Visible = false;
                    lblExistencias.Visible = false;
                    Tabla.Rows.Clear();
                    tbxExistencias.Visible = false;
                    tbxExistencias.Clear();
                    tbxVendedor.Enabled = false;
                    tbxVendedor.Clear();
                    tbxNVendedor.Clear();
                    btnSV.Enabled = false;
                    tbxNVendedor.Enabled = false;
                    btnCambiarVendedor.Enabled = false;
                    tbxProducto.Clear();
                    tbxNProducto.Clear();
                    tbxCantidad.Clear();
                  //  tbxFolioDE.Text = CargarFolio().ToString();
                    Operacion = "EI-Normal";
                }
                else if (cbxMotivo.Text == "Transferencia")
                {
                    tbxExistencias.Clear();
                    unidades();
                    label7.Visible = true;
                    cbxAlmacen.Visible = true;
                    lblExistencias.Visible = false;

                    Tabla.Rows.Clear();
                    tbxVendedor.Enabled = false;
                    btnSV.Enabled = false;
                    tbxNVendedor.Enabled = false;
                    btnCambiarVendedor.Enabled = false;
                    tbxVendedor.Clear();
                    tbxNVendedor.Clear();
                    tbxExistencias.Visible = false;
                    tbxProducto.Clear();
                    tbxNProducto.Clear();
                    tbxCantidad.Clear();
                    Operacion = "EI-Trans-" + cbxAlmacen.Text;

                }
                else if (cbxMotivo.Text == "Devolución de Vendedor")
                {
                    label7.Visible = false;
                    cbxAlmacen.Visible = false;
                    tbxExistencias.Clear();
                    Tabla.Rows.Clear();
                    tbxVendedor.Clear();
                    tbxNVendedor.Clear();
                    tbxVendedor.ReadOnly = false;
                    lblExistencias.Visible = true;
                    tbxExistencias.Visible = true;
                    tbxVendedor.Enabled = true;
                    btnSV.Enabled = true;
                    tbxNVendedor.Enabled = true;
                    btnCambiarVendedor.Enabled = true;
                    tbxProducto.Clear();
                    tbxNProducto.Clear();
                    tbxCantidad.Clear();
             //       tbxFolioDE.Text = CargarFolio().ToString();
                    Operacion = "EI-Devolu-" + NOMBREVENDEDOR;
                }
                else if (cbxMotivo.Text == "Devolución por consignación")
                {
                    label3.Text = "Cliente:";
                    label7.Visible = false;
                    cbxAlmacen.Visible = false;
                    tbxExistencias.Clear();
                    Tabla.Rows.Clear();
                    tbxVendedor.Clear();
                    tbxNVendedor.Clear();
                    tbxVendedor.ReadOnly = false;
                    lblExistencias.Visible = true;
                    tbxExistencias.Visible = true;
                    tbxVendedor.Enabled = true;
                    btnSV.Enabled = true;
                    tbxNVendedor.Enabled = true;
                    btnCambiarVendedor.Enabled = true;
                    tbxProducto.Clear();
                    tbxNProducto.Clear();
                    tbxCantidad.Clear();
                    //       tbxFolioDE.Text = CargarFolio().ToString();
                    Operacion = "EI-Devolución por consignación";
                }
                else if (cbxMotivo.Text == "Devolucion de Cliente")
                {
                    label3.Text = "Cliente:";
                    label7.Visible = false;
                    cbxAlmacen.Visible = false;
                    tbxExistencias.Clear();
                    tbxVendedor.Clear();
                    tbxNVendedor.Clear();
                    lblExistencias.Visible = false;
                    tbxExistencias.Visible = false;
                    tbxVendedor.Enabled = true;
                    btnSV.Enabled = true;
                    tbxNVendedor.Enabled = true;
                    btnCambiarVendedor.Enabled = false;
                    Tabla.Rows.Clear();
                    tbxProducto.Clear();
                    tbxNProducto.Clear();
                    tbxCantidad.Clear();
                    //   tbxFolioDE.Text = CargarFolio().ToString();
                    Operacion = "EI-Devolución de cliente";

                }
                else if (cbxMotivo.Text == "Otros")
                {
                    label7.Visible = false;
                    cbxAlmacen.Visible = false;
                    tbxExistencias.Clear();
                    tbxVendedor.Clear();
                    tbxNVendedor.Clear();
                    lblExistencias.Visible = false;
                    Tabla.Rows.Clear();
                    tbxExistencias.Visible = false;
                    tbxVendedor.Enabled = false;
                    btnSV.Enabled = false;
                    tbxNVendedor.Enabled = false;
                    btnCambiarVendedor.Enabled = false;
                    tbxProducto.Clear();
                    tbxNProducto.Clear();
                    tbxCantidad.Clear();
                    //    tbxFolioDE.Text = CargarFolio().ToString();
                    Operacion = "EI-Otros";
                }
                else if (cbxMotivo.Text == "Entradas a vendedores")
                {
                    label7.Visible = false;
                    cbxAlmacen.Visible = false;
                    tbxExistencias.Clear();
                    tbxExistencias.Visible = false;
                    Tabla.Rows.Clear();
                    tbxVendedor.Clear();
                    tbxNVendedor.Clear();
                    tbxVendedor.ReadOnly = false;
                    lblExistencias.Visible = false;
                    tbxVendedor.Enabled = true;
                    btnSV.Enabled = true;
                    tbxNVendedor.Enabled = true;
                    btnCambiarVendedor.Enabled = true;
                    tbxProducto.Clear();
                    tbxNProducto.Clear();
                    tbxCantidad.Clear();
                    //       tbxFolioDE.Text = CargarFolio().ToString();
                    Operacion = "Entrada a vendedor " + NOMBREVENDEDOR;
                }
            }
            else
            {
                ini = 0;
            }
                    motivo = cbxMotivo.Text;
        }
        public void obtenervendedor()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            
            comando = new MySqlCommand("SELECT * from empleados where id_empleado=" + tbxVendedor.Text, conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            string des = "";
            while (lector.Read())
            {
                NOMBREVENDEDOR = lector.GetString(1);
                tbxNVendedor.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                des = lector.GetString(1);
                tbxVendedor.ReadOnly = true;
                btnSV.Enabled = false;

            }
            
            conectar.Close();
            if (des == "")
            {
                MessageBox.Show("Código de vendedor no existente.");
                tbxVendedor.Clear();
            }
        }
        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MetodoVendedor();
            }
        }
        public void MetodoVendedor()
        {
            if (cbxMotivo.Text == "Devolución por consignación" || cbxMotivo.Text == "Devolucion de Cliente")
            {
                if (tbxVendedor.Text != "")
                {
                    if (tbxVendedor.Text != "1")
                    {
                        ObtnerCliente();
                        if (tbxVendedor.Text != "")
                        {
                            tbxProducto.Focus();
                        }
                    }
                }
            }
            else
            {
                if (tbxVendedor.Text != "")
                {
                    if (tbxVendedor.Text != "1")
                    {
                        obtenervendedor();

                        if (tbxVendedor.Text != "")
                        {
                            tbxProducto.Focus();
                        }
                    }
                }
            }
        }
        private void btnSV_Click(object sender, EventArgs e)
        {
            if (cbxMotivo.Text == "Devolución por consignación" || cbxMotivo.Text == "Devolucion de Cliente")
            {
                string S = "";
                BuscarClientes id = new BuscarClientes(S);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxVendedor.Text = id.regresar.valXn;
                }
                tbxVendedor.Focus();
                MetodoVendedor();
            }
            else
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
        public void ObtnerCliente()
        {
            if (tbxVendedor.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
               
                //comando = new MySqlCommand("SELECT * FROM clientes WHERE idclientes =" + tbxCCliente.Text, conectar);
                comando = new MySqlCommand("SELECT a.idclientes, a.nombre, a.categorias_idcategorias, u.Vendedor, a.empleados_id_empleado " +
                            "FROM clientes a, categorias u WHERE idclientes =" + tbxVendedor.Text + " and a.categorias_idcategorias=u.idcategorias", conectar);
                MySqlDataReader lector;
                conectar.Open();
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    des = lector.GetString(0);
                    tbxVendedor.Text = lector.GetString(0);
                    tbxNVendedor.Text = lector.GetString(1);
                        
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código del cliente no existente");
                    tbxVendedor.Clear();
                    tbxNVendedor.Clear();
                    tbxProducto.Focus();

                }
            }

        }
        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {
            tbxVendedor.Clear();
            tbxNVendedor.Clear();
            tbxVendedor.ReadOnly = false;
            tbxCantidad.Clear();
            tbxExistencias.Clear();
            tbxProducto.Clear();
            tbxNProducto.Clear();
            Tabla.Rows.Clear();
            btnSV.Enabled = true;
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
                y = 125;
                Font letra = new Font("Arial", 9);

                if (!chkImprimir.Checked)
                {
                    x = e.MarginBounds.Width / 9 * 2;
                    L = e.MarginBounds.Width / 9 * 2 + 5;
                    col4 = Tabla.Columns[4].Width - an;
                }
                else
                {
                    x = e.MarginBounds.Width / 7 * 2;
                    L = e.MarginBounds.Width / 7 * 2 + 5;
                }
                col1 = Tabla.Columns[1].Width - an;
                col2 = Tabla.Columns[2].Width - an;
                col3 = Tabla.Columns[3].Width - an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(e.MarginBounds.Width / 9 * 2, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                if (cbxMotivo.Text == "Entradas a vendedores")
                {
                    e.Graphics.DrawString("ENTRADA A VENDEDOR", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, Tabla.Rows[0].Height + 15));
                    #region Vendedor
                    e.Graphics.DrawString(tbxNVendedor.Text, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 105, 500, Tabla.Rows[0].Height + 15));
                    #endregion
                }
                else
                {
                    e.Graphics.DrawString("ENTRADA A ALMACÉN", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, Tabla.Rows[0].Height + 15));
                }
                #endregion
                if (cbxMotivo.Text == "Entradas a vendedores")
                {
        
                }
                else if (cbxMotivo.Text == "Transferencia")
                {
                    #region Folio
                    e.Graphics.DrawString("Folio: " + tbxFolioDE.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 7 * 6, 85, 500, Tabla.Rows[0].Height + 15));
                    #endregion
                    #region Origen
                    e.Graphics.DrawString("Origen: " + sucursalOrigen, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 85, 500, Tabla.Rows[0].Height + 15));
                    #endregion
                    #region Destino
                    e.Graphics.DrawString("Destino: " + sucursalDestino, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 105, 500, Tabla.Rows[0].Height + 15));
                    #endregion
                }
                else
                {

                    #region Folio
                    e.Graphics.DrawString("Folio: " + tbxFolioDE.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Rectangle(e.MarginBounds.Width / 7 * 6, 85, 500, Tabla.Rows[0].Height + 15));
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
                if (!chkImprimir.Checked)
                {
                    #region Total

                    //             e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(60 + col1 + col2 + col3, 100, col4, Tabla.Rows[0].Height + 15));
                    e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, Tabla.Rows[0].Height + al));
                    e.Graphics.DrawString(Tabla.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, Tabla.Rows[0].Height + al));

                    #endregion
                }

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

                    //              e.Graphics.DrawRectangle(p, new Rectangle(100, height, Tabla.Columns[1].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, col1, Tabla.Rows[0].Height));

                    //            e.Graphics.DrawRectangle(p, new Rectangle(100 + Tabla.Columns[1].Width, height, Tabla.Columns[2].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, col2, Tabla.Rows[0].Height));

                    //          e.Graphics.DrawRectangle(p, new Rectangle(300 + Tabla.Columns[1].Width, height, Tabla.Columns[3].Width, Tabla.Rows[0].Height));
                    e.Graphics.DrawString(Tabla.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, col3, Tabla.Rows[0].Height));
                    if (!chkImprimir.Checked)
                    {
                        //                    e.Graphics.DrawRectangle(p, new Rectangle(400 + Tabla.Columns[1].Width, height, Tabla.Columns[4].Width, Tabla.Rows[0].Height));
                        e.Graphics.DrawString(Tabla.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, Tabla.Columns[3].Width, Tabla.Rows[0].Height));
                    }
                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void cbxAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select iniciales, nombre from almacenes where iniciales='"+cbxAlmacen.Text+"'",conectar);
            conectar.Open();
            MySqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                sucursalOrigen = lector.GetString(0) + " - " + lector.GetString(1);
            }
            conectar.Close();
            //sucursalOrigen = cbxAlmacen.Text;
        }
        
        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        double CantVendedorIni = 0;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Tabla.Rows.Count <= 0)
            {
                MessageBox.Show("No hay ningún valor para guardar");
            }
            else
            {
                result = MessageBox.Show("Se van a registrar entradas al inventario ¿Desea continuar?", "Registrar entrada a inventario", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (cbxMotivo.Text == "Devolución de Vendedor" && cbxMotivo.Text == "Entradas a vendedores")
                    {
                        vendedor = Convert.ToInt32(tbxVendedor.Text);
                        
                    }
                    else
                    {
                        vendedor = 1;
                    }

                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;
                    Boolean bAllOk = false;
                    Conexion.Conectarse();
                    Conexion.IniciarTransaccion();
                    for (int i = 0; i < Tabla.Rows.Count; i++)
                    {

                        DataTable tbl = new DataTable();
                        codigo = Convert.ToInt32(Tabla[1, i].Value.ToString());
                        cantidad = Convert.ToDouble(Tabla[3, i].Value.ToString());
                        total2 = Convert.ToDouble(Tabla[4, i].Value.ToString());
                        CantidadInicial = Convert.ToDouble(Tabla[5, i].Value.ToString());
                        DateTime FechaCon = Convert.ToDateTime(Tabla[6, i].Value);
                        CantVendedorIni = Convert.ToDouble(Tabla[7, i].Value);

                        if (cbxMotivo.Text != "Entradas a vendedores")
                        {
                            comando = new MySqlCommand("UPDATE articulos SET cantidad=cantidad+" + cantidad + " where codigo=" + codigo, conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();

                            comando = new MySqlCommand("INSERT INTO entradasDP (fecha,cantidad,articulos_codigo,Motivo,Comentarios,empleados_id_empleado,folio)" +
                                                    "VALUES('" + dtpFecha.Value.ToString("yyyyMMddHHmmss") + "'," + cantidad + "," + codigo + ",'" + cbxMotivo.Text + "','" + tbxComentarios.Text + "'," + vendedor + ",'" + tbxFolioDE.Text + "') ", conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();
                        }
                        else
                        {
                            cmd = String.Format("UPDATE inv_vendedor SET Cantidad=Cantidad+{0} WHERE "+
                                " empleados_id_empleado={1} AND articulos_codigo={2}", 
                                cantidad, 
                                tbxVendedor.Text,
                                codigo);
                            bAllOk = Conexion.Ejecutar(cmd);
                            
                        }

                        if (cbxMotivo.Text == "Devolución de Vendedor")
                        {
                            comando = new MySqlCommand("UPDATE inv_vendedor SET cantidad=cantidad-" + cantidad + " WHERE empleados_id_empleado=" + tbxVendedor.Text + " AND articulos_codigo=" + codigo, conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();
                        }
                        else if (cbxMotivo.Text == "Devolución por consignación")
                        {
                            cmd = String.Format("SELECT idinv_Abarrote, cantidad, Fecha FROM inv_clientes WHERE cantidad>0 AND " +
                                "clientes_idclientes={0} AND articulos_codigo = {1} ORDER BY idinv_Abarrote ASC",
                    tbxVendedor.Text, codigo);
                            double resto = cantidad;
                            //Conexion.Conectarse();
                            bAllOk = Conexion.Ejecutar(cmd, ref tbl);
                            //Conexion.Desconectarse();
                            for (int j = 0; j < tbl.Rows.Count; j++)
                            {
                                DataRow row = tbl.Rows[j];

                                if (resto >= Convert.ToDouble(row["cantidad"]))
                                {
                                    resto = resto - Convert.ToDouble(row["cantidad"]);
                                    cmd = String.Format("UPDATE inv_clientes SET cantidad=0 WHERE idinv_Abarrote={0}",
                                        row["idinv_Abarrote"].ToString());
                                }
                                else
                                {
                                    cmd = String.Format("UPDATE inv_clientes SET cantidad=cantidad-{1} WHERE idinv_Abarrote={0}",
                                      row["idinv_Abarrote"].ToString(),resto);
                                    resto = 0;
                                }
                             
                                //Conexion.Conectarse();
                                bAllOk = Conexion.Ejecutar(cmd);
                                //Conexion.Desconectarse();
                                
                            }
                                
                            Operacion = "EI-Devolución por consignación";
                        }
                        if (cbxMotivo.Text == "Normal")
                        {

                            Operacion = "EI-Normal";
                        }
                        else if (cbxMotivo.Text == "Transferencia")
                        {

                            Operacion = "EI-Trans-" + cbxAlmacen.Text;

                        }
                        else if (cbxMotivo.Text == "Devolución de Vendedor")
                        {

                            Operacion = "EI-Devolu-" + NOMBREVENDEDOR;
                        }
                        else if (cbxMotivo.Text == "Devolucion de Cliente")
                        {

                            Operacion = "EI-Devolución de cliente";

                        }
                        else if (cbxMotivo.Text == "Otros")
                        {

                            Operacion = "EI-Otros";
                        }

                        if (cbxMotivo.Text == "Entradas a vendedores")
                        {
                            cmd =String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha,"+
                                " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) "+
                                " VALUES({0},{1},'{2}','{3}',{4},{5},{6},{7})",
                                codigo, cantidad, "Entrada a vendedores", dtpFecha.Value.ToString("yyyyMMddHHmmss"),
                                CantidadInicial,total2,tbxVendedor.Text,UsuarioID);
                            bAllOk = Conexion.Ejecutar(cmd);
                            comando = new MySqlCommand("INSERT INTO salidas values(null," + cantidad + "," +
                                dtpFecha.Value.ToString("yyyyMMdd") + "," + tbxVendedor.Text + "," + codigo + "," +
                                total2 + ",'Entrada a vendedor','"+tbxComentarios.Text+"','"+tbxFolioDE.Text+"')", conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();

                        }
                        else
                        {
                            comando = new MySqlCommand("INSERT INTO HistoricoDMovimientos  VALUES(null," + codigo + "," + 
                                cantidad + "," + total2 + ",'" + Operacion + "'," + UsuarioID + ",now()," + CantidadInicial + 
                                ")", conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();
                            if (cbxMotivo.Text == "Devolución de Vendedor")
                            {

                                cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                            " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                            " VALUES({0},{1},'{2}','{3}',{4},{5},{6},{7})",
                            codigo, cantidad, "Devolución de Vendedor", dtpFecha.Value.ToString("yyyyMMddHHmmss"),
                            CantVendedorIni, CantVendedorIni-cantidad, tbxVendedor.Text, UsuarioID);
                                bAllOk = Conexion.Ejecutar(cmd);
                            }
                        }
                    }
                    Conexion.FinalizarTransaccion(bAllOk);
                    Conexion.Desconectarse();
                   
                        comando = new MySqlCommand("INSERT INTO Folios_Entradas values(null)", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();
                    

                    tbxProducto.Clear();
                    
                    tbxVendedor.Clear();
                    tbxCantidad.Clear();
                    tbxExistencias.Clear();
                    tbxNProducto.Clear();
                    tbxComentarios.Clear();
                    tbxVendedor.ReadOnly = false;
                    btnSV.Enabled = true;

                    (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.PrintPreviewControl.Zoom = 1.5;
                    printPreviewDialog1.ShowDialog();
                    tbxFolioDE.Text = Prefijo + "-" + CargarFolio().ToString();
                    Tabla.Rows.Clear();
                    
                    tbxNVendedor.Clear();
                    MessageBox.Show("Entrada guardada con éxito.");
                }
            } 
        }
    }
}
