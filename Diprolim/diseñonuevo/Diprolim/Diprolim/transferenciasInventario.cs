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
    public partial class transferenciasInventario : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        String cmd,UsuarioID,VendedorO,VendedorD;
        conexion conn = new conexion();
        MySqlCommand comando;
        MySqlConnection conectar;
        MySqlDataReader lector;
        Boolean validacion = false;
        public transferenciasInventario(UnicaSQL.DBMS_Unico svr, String ID)
        {
            InitializeComponent();
            Conexion = svr;
            UsuarioID = ID;
        }

        public void obtenerVendedor()
        {
            validacion = false;

            if (tbxVendedor.Text != "1")
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select count(*) from empleados where id_empleado=" + tbxVendedor.Text, conectar);
                conectar.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    if (Convert.ToInt32(lector.GetString(0)) > 0)
                    {
                        validacion = true;
                    }
                    else
                    {
                        MessageBox.Show("Código de vendedor no existe");
                        tbxVendedor.Clear();
                        tbxNVendedor.Clear();
                    }
                }

                conectar.Close();
                if (validacion)
                {

                    comando = new MySqlCommand("select nombre, apellido_paterno, apellido_materno from empleados where id_empleado=" + tbxVendedor.Text, conectar);
                    conectar.Open();

                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        VendedorO = lector.GetString(0).ToString();
                        tbxNVendedor.Text = lector.GetString(0).ToString() + " " + lector.GetString(1).ToString() + " " + lector.GetString(2).ToString();
                        tbxProducto.Focus();
                    }
                    conectar.Close();
                    tbxVendedor.Enabled = false;
                    btnSV.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Código de vendedor incorrecto");
            }
            
        }
        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxVendedor.Text != "1")
                {
                    obtenerVendedor();
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

        private void btnSV_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedor.Text = id.regresar.valXn;
            }
            tbxVendedor.Focus();
        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                obtenerProducto();
            }
        }

        public void obtenerProducto()
        {
            if (tbxProducto.Text != "")
            {
                if (tbxVendedor.Text.Length > 0)
                {

                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre, iv.cantidad " +
                        "FROM inv_vendedor iv, articulos a, unidad_medida u WHERE iv.empleados_id_empleado=" + tbxVendedor.Text + " and iv.articulos_codigo =" + tbxProducto.Text + " and a.unidad_medida_id=u.id and a.codigo=iv.articulos_codigo", conectar);
                    conectar.Open();

                    lector = comando.ExecuteReader();
                    string des = "";
                    while (lector.Read())
                    {
                        tbxNProducto.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                        tbxExistencias.Text = lector.GetString(4);
                        des = lector.GetString(0);
                        tbxCantidad.Focus();
                    }
                    conectar.Close();
                    if (des == "")
                    {
                        MessageBox.Show("El código de producto no existe");
                        tbxNProducto.Clear();
                        tbxProducto.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Debe indicar un código de vendedor");
                }
            }
            else
            {
                MessageBox.Show("Debe indicar un código de producto");
            }
        }

        private void tbxProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text.Length > 0)
            {
                obtenerVendedor();
                BuscarArticulosVendedor id = new BuscarArticulosVendedor(tbxVendedor.Text);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxProducto.Text = id.regresar.valXn;
                    tbxProducto.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe indicar un código de vendedor");
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

        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {
            tbxVendedor.Enabled = true;
            tbxVendedor.Clear();
            btnSV.Enabled = true;
            tbxNVendedor.Clear();
            tbxNVendedorD.Clear();
            tbxVendedorD.Clear();
            tbxNProducto.Clear();
            tbxProducto.Clear();
            tbxCantidad.Clear();
            tbxExistencias.Clear();

        }

        public void obtenerVendedorDestino()
        {
            validacion = false;

            
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select count(*) from empleados where id_empleado=" + tbxVendedorD.Text, conectar);
                conectar.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    if (Convert.ToInt32(lector.GetString(0)) > 0)
                    {
                        validacion = true;
                    }
                    else
                    {
                        MessageBox.Show("Código de vendedor no existe");
                        tbxVendedorD.Clear();
                        tbxNVendedorD.Clear();
                    }
                }

                conectar.Close();
                if (validacion)
                {

                    comando = new MySqlCommand("select nombre, apellido_paterno, apellido_materno, id_empleado from empleados where id_empleado=" + tbxVendedorD.Text, conectar);
                    conectar.Open();

                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        if (tbxVendedor.Text == lector.GetString(3))
                        {
                            MessageBox.Show("No se puede transferir productos al mismo vendedor");
                            tbxVendedorD.Clear();
                            tbxNVendedorD.Clear();
                        }
                        else
                        {
                            VendedorD = lector.GetString(0).ToString();
                            tbxNVendedorD.Text = lector.GetString(0).ToString() + " " + lector.GetString(1).ToString() + " " + lector.GetString(2).ToString();
                            btnTransferencias.Focus();
                        }
                    }
                    conectar.Close();
                }
            
        }
        private void tbxVendedorD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                obtenerVendedorDestino();
            }
            
        }

        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxCantidad.Text.Length > 0)
                {
                    tbxVendedorD.Focus();
                }
            }
        }

        private void tbxVendedorD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        double cantidad = 0;
        int reg = 0;
        private void btnTransferencias_Click(object sender, EventArgs e)
        {
            cantidad = 0;
            if (tbxVendedor.Text.Length > 0 && tbxVendedorD.Text.Length > 0)
            {
                if (tbxVendedor.Text == tbxVendedorD.Text)
                {
                    MessageBox.Show("No se puede transferir al mismo vendedor");
                    tbxVendedorD.Focus();
                }
                else
                {
                    obtenerVendedor();
                    obtenerVendedorDestino();
                    if (tbxVendedor.Text != "1"&&tbxVendedorD.Text!="1")
                    {
                        if (tbxProducto.Text.Length > 0)
                        {

                            obtenerProducto();
                            if (tbxCantidad.Text.Length > 0)
                            {
                                conectar = conn.ObtenerConexion();
                                comando = new MySqlCommand("select cantidad from inv_vendedor where articulos_codigo=" + tbxProducto.Text + " and" +
                                    " empleados_id_empleado=" + tbxVendedor.Text + "", conectar);
                                conectar.Open();
                                lector = comando.ExecuteReader();
                                while (lector.Read())
                                {
                                    cantidad = lector.GetDouble(0);
                                }
                                conectar.Close();
                                if (tbxCantidad.Text == ".")
                                {
                                    MessageBox.Show("Verifique la cantidad");
                                }
                                else
                                {
                                    if (Convert.ToDouble(tbxCantidad.Text) <= cantidad)
                                    {
                                        //verifica si existe un registro del vendedor relacionado con el producto
                                        comando = new MySqlCommand("select count(*) from inv_vendedor where articulos_codigo=" + tbxProducto.Text + " and" +
                                            " empleados_id_empleado=" + tbxVendedorD.Text + "", conectar);
                                        conectar.Open();
                                        lector = comando.ExecuteReader();
                                        while (lector.Read())
                                        {
                                            reg = lector.GetInt32(0);
                                        }
                                        conectar.Close();
                                        if (reg > 0)
                                        {
                                            DataTable tbl = new DataTable();
                                            cmd = String.Format("SELECT Cantidad FROM inv_vendedor where articulos_codigo={0} and empleados_id_empleado={1}",
                                                tbxProducto.Text,
                                                tbxVendedorD.Text);
                                            Conexion.Conectarse();
                                            Conexion.Ejecutar(cmd, ref tbl);
                                            DataRow row = tbl.Rows[0];
                                            String invDestino = row["Cantidad"].ToString();
                                            cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                              " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                              " VALUES({0},{1},'{2}',now(),{3},{4},{5},{6})",
                                              tbxProducto.Text, tbxCantidad.Text, "Trans. " + VendedorO + "-" + VendedorD,
                                              invDestino, Convert.ToDouble(invDestino) + Convert.ToDouble(tbxCantidad.Text), tbxVendedorD.Text, UsuarioID);
                                            Conexion.Ejecutar(cmd);

                                            cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                            " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                            " VALUES({0},{1},'{2}',now(),{3},{4},{5},{6})",
                                            tbxProducto.Text, tbxCantidad.Text, "Trans. " + VendedorO + "-" + VendedorD,
                                            tbxExistencias.Text, Convert.ToDouble(tbxExistencias.Text) - Convert.ToDouble(tbxCantidad.Text), tbxVendedor.Text, UsuarioID);
                                            Conexion.Ejecutar(cmd);
                                            Conexion.Desconectarse();
                                            //actualiza inventario del vendedor destino
                                            comando = new MySqlCommand("Update inv_vendedor set cantidad=cantidad+" + tbxCantidad.Text + " where articulos_codigo=" + tbxProducto.Text + " and" +
                                           " empleados_id_empleado=" + tbxVendedorD.Text + "", conectar);
                                            conectar.Open();
                                            comando.ExecuteNonQuery();
                                            conectar.Close();

                                            //actualiza inventario de vendedor origen
                                            comando = new MySqlCommand("Update inv_vendedor set cantidad=cantidad-" + tbxCantidad.Text + " where articulos_codigo=" + tbxProducto.Text + " and" +
                                       " empleados_id_empleado=" + tbxVendedor.Text + "", conectar);
                                            conectar.Open();
                                            comando.ExecuteNonQuery();
                                            conectar.Close();

                                            tbxProducto.Clear();
                                            tbxNProducto.Clear();
                                            tbxCantidad.Clear();
                                            tbxExistencias.Clear();
                                            tbxProducto.Focus();
                                            MessageBox.Show("Transferencia realizada");
                                        }
                                        else
                                        {
                                            Conexion.Conectarse();
                                            cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                              " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                              " VALUES({0},{1},'{2}',now(),{3},{4},{5},{6})",
                                              tbxProducto.Text, tbxCantidad.Text, "Trans.  " + VendedorO + "-" + VendedorD,
                                              "0", tbxCantidad.Text, tbxVendedorD.Text, UsuarioID);
                                            Conexion.Ejecutar(cmd);

                                            cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                            " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                            " VALUES({0},{1},'{2}',now(),{3},{4},{5},{6})",
                                            tbxProducto.Text, tbxCantidad.Text, "Trans. " + VendedorO + "-" + VendedorD,
                                            tbxExistencias.Text, Convert.ToDouble(tbxExistencias.Text) - Convert.ToDouble(tbxCantidad.Text), tbxVendedor.Text, UsuarioID);
                                            Conexion.Ejecutar(cmd);
                                            Conexion.Desconectarse();

                                            //actualiza inventario del vendedor destino
                                            comando = new MySqlCommand("insert into inv_vendedor values (null," + tbxCantidad.Text + "," + tbxVendedorD.Text + "," + tbxProducto.Text + ") ", conectar);
                                            conectar.Open();
                                            comando.ExecuteNonQuery();
                                            conectar.Close();

                                            //actualiza inventario de vendedor origen
                                            comando = new MySqlCommand("Update inv_vendedor set cantidad=cantidad-" + tbxCantidad.Text + " where articulos_codigo=" + tbxProducto.Text + " and" +
                                       " empleados_id_empleado=" + tbxVendedor.Text + "", conectar);
                                            conectar.Open();
                                            comando.ExecuteNonQuery();
                                            conectar.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("La cantidad a transferir no puede ser mayor a las existencias del vendedor");
                                        tbxCantidad.Focus();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Indique una cantidad a transferir");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe indicar un código de producto");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No está permitido transferencias a sucursal.");
                    }
                }
            }
        }

        private void btnSPD_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedorD.Text = id.regresar.valXn;
            }
            tbxVendedorD.Focus();
        }
    }

}

