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
    public partial class ventaInesperada : Form
    {
        conexion conn = new conexion();
        Inventarios.DBMS_Unico Conexion;
        String cmd;
        MySqlConnection conectar;
        MySqlDataReader lector;
        MySqlCommand comando;
        double cantidad =0;
        string UsuarioID = "";
        public ventaInesperada()
        {
            InitializeComponent();
        }
        public ventaInesperada(string Codigo,string id,Inventarios.DBMS_Unico svr)
        {
            InitializeComponent();
            tbxVendedor.Text = Codigo;
            UsuarioID = id;
            obtenervendedor();
            tbxProducto.Focus();
            Conexion = svr;
        }

        public void obtenervendedor()
        {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("SELECT * from empleados where id_empleado=" + tbxVendedor.Text, conectar);
                conectar.Open();

                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    tbxNVendedor.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    des = lector.GetString(1);

                }

                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Ese vendedor no existe");
                    

                }
            
        }
        public void obtenerProductos()
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
                   tbxDisponible.Text= lector.GetString(4);
                    tbxNombre.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    des = lector.GetString(0);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de producto no existente");
                    tbxProducto.Clear();
                    tbxNombre.Clear();
                    tbxProducto.Focus();
                    tbxDisponible.Clear();

                }
            }
        }
        

        private void btnSV_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedor.Text = id.regresar.valXn;
            }
            
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
        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxProducto.Text != "")
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    tbxCantidad.Focus();
                    obtenerProductos();

                }
            }
        }

        public Boolean verificarLimites(){
            Boolean aceptado = false;
            double totalCantidad = 0;
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select "+tbxCantidad.Text+"*precio_calle from articulos where codigo="+tbxProducto.Text+"", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                totalCantidad = lector.GetDouble(0);
            }
            conectar.Close();
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select sum(i.cantidad*a.precio_calle), e.limite_inv from inv_vendedor i, articulos a, empleados e "+
                "where i.empleados_id_empleado=e.id_empleado and i.articulos_codigo=a.codigo and i.empleados_id_empleado="+tbxVendedor.Text+" and "+
                "a.departamento=1 and a.valor_medida<4 and a.unidad_medida_id<>7", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                if ((lector.GetDouble(0) + totalCantidad) < lector.GetDouble(1))
                {
                    aceptado = true;
                }
                else
                {
                    aceptado = false;
                }
            }
            conectar.Close();
            if (!aceptado)
            {
                comando = new MySqlCommand(" select valor_medida, departamento, unidad_medida_id from articulos where codigo=" + tbxProducto.Text + " ", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    if (lector.GetDouble(0) >= 4 || lector.GetInt32(1) == 2 || lector.GetInt32(1) == 3 || lector.GetInt32(2) == 7)
                    {
                        aceptado = true;
                    }
                    else
                    {
                        aceptado = false;
                    }
                }

                conectar.Close();
            }
            return aceptado;
        }
        double Total = 0, nv;
        private void btnAC_Click(object sender, EventArgs e)
        {
            if (tbxProducto.Text != "" && tbxCantidad.Text != "")
            {
                if (tbxCantidad.Text.Length > 0)
                {
                    if (verificarLimites())
                    {
                        comando = new MySqlCommand("SELECT cantidad " +
                                    "FROM articulos WHERE codigo =" + tbxProducto.Text, conectar);
                        conectar.Open();

                        MySqlDataReader lector;
                        lector = comando.ExecuteReader();

                        while (lector.Read())
                        {
                            cantidad = lector.GetDouble(0);
                        }
                        conectar.Close();
                        if (tbxCantidad.Text == ".")
                        {
                            MessageBox.Show("Verifique la cantidad ingresada");
                            tbxCantidad.Focus();
                        }
                        else
                        {
                            Total = cantidad - (Convert.ToDouble(tbxCantidad.Text));
                            if (Total >= 0)
                            {
                                comando = new MySqlCommand("UPDATE articulos SET cantidad=" + Total + " where codigo=" + tbxProducto.Text, conectar);
                                conectar.Open();
                                comando.ExecuteNonQuery();
                                conectar.Close();

                                comando = new MySqlCommand("select count(*) from inv_vendedor where articulos_codigo=" + tbxProducto.Text + " and empleados_id_empleado=" + tbxVendedor.Text, conectar);
                                conectar.Open();
                                lector = comando.ExecuteReader();
                                while (lector.Read())
                                {
                                    nv += lector.GetInt32(0);
                                }
                                conectar.Close();
                                if (nv > 0)
                                {
                                    Conexion.Conectarse();
                                    DataTable tbl = new DataTable();
                                    cmd = String.Format("SELECT Cantidad FROM inv_vendedor where articulos_codigo={0} and empleados_id_empleado={1}",
                                        tbxProducto.Text,
                                        tbxVendedor.Text);
                                    Conexion.Ejecutar(cmd, ref tbl);
                                    DataRow row = tbl.Rows[0];
                                    String InventarioVendedor = row["Cantidad"].ToString();
                                    cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                      " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                      " VALUES({0},{1},'{2}',{3},{4},{5},{6},{7})",
                                      tbxProducto.Text, tbxCantidad.Text, "Inventario inesperado", "now()",
                                      InventarioVendedor, 
                                      Convert.ToDouble(InventarioVendedor) + Convert.ToDouble(tbxCantidad.Text),
                                      tbxVendedor.Text, UsuarioID);
                                    Conexion.Ejecutar(cmd);
                                    Conexion.Desconectarse();
                                    comando = new MySqlCommand("UPDATE inv_vendedor SET cantidad=cantidad+" + tbxCantidad.Text + " where articulos_codigo=" + tbxProducto.Text + " and empleados_id_empleado=" + tbxVendedor.Text, conectar);
                                    conectar.Open();
                                    comando.ExecuteNonQuery();
                                    conectar.Close();

                                    MessageBox.Show("Producto agregado al inventario del vendedor");

                                }
                                else
                                {
                                    Conexion.Conectarse();
                                    cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                      " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                      " VALUES({0},{1},'{2}',{3},{4},{5},{6},{7})",
                                      tbxProducto.Text, tbxCantidad.Text, "Inventario inesperado", "now()",
                                      0,Convert.ToDouble(tbxCantidad.Text),
                                      tbxVendedor.Text, UsuarioID);
                                    Conexion.Ejecutar(cmd);
                                    Conexion.Desconectarse();
                                    comando = new MySqlCommand("insert into inv_vendedor values(null," + tbxCantidad.Text + "," + tbxVendedor.Text + "," + tbxProducto.Text + ")", conectar);
                                    conectar.Open();
                                    comando.ExecuteNonQuery();
                                    conectar.Close();

                                    MessageBox.Show("Producto agregado al inventario del vendedor");


                                }
                                comando = new MySqlCommand("INSERT INTO salidas values(null," + tbxCantidad.Text + "," + DateTime.Now.ToString("yyyyMMdd") + "," + tbxVendedor.Text + "," + tbxProducto.Text + "," + tbxCantidad.Text + ",'Normal','Sin Comentarios',null)", conectar);
                                conectar.Open();
                                comando.ExecuteNonQuery();
                                conectar.Close();

                                comando = new MySqlCommand("INSERT INTO HistoricoDMovimientos  VALUES(null," + tbxProducto.Text + "," + tbxCantidad.Text + "," + (cantidad - Convert.ToDouble(tbxCantidad.Text)) + ",'InvInesperado-" + tbxNVendedor.Text + "'," + UsuarioID + ",'" + DateTime.Now.ToString("yyyyMMdd") + "'," + cantidad + ")", conectar);
                                conectar.Open();
                                comando.ExecuteNonQuery();
                                conectar.Close();
                                tbxCantidad.Clear();
                                tbxDisponible.Clear();
                                obtenerProductos();
                            }
                            else
                            {
                                MessageBox.Show("No puede dar más de lo que hay en sucursal");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede dar mas inventario de este producto.");
                    }
                }
                else
                {
                    MessageBox.Show("Debe indicar una cantidad");
                }
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

        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxCantidad.Text != "")
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    obtenerProductos();
                    btnAC.Focus();
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

        private void tbxProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        private void btnSV_Click_1(object sender, EventArgs e)
        {

        }

        
    }
}
