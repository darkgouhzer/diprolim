using ReglasNegocios;
//using MySql.Data.MySqlClient;
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
    public partial class ConsultaCancelaVentas : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        String cmd = "";
        DateTime formato_fecha;
        string EmpleadoID = "";
        String UsuarioID;
        Boolean sucursal = false;
        public ConsultaCancelaVentas(UnicaSQL.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
            dtpFecha.Value = DateTime.Now;
            categorias();
            cbxDepto.SelectedIndex = 0;
            cbxTipoVenta.SelectedIndex = 0;
        }
        public ConsultaCancelaVentas(UnicaSQL.DBMS_Unico svr, string s, int id)
        {

            InitializeComponent();
            UsuarioID = id.ToString();
            Conexion = svr;
            EmpleadoID = s;
            obtenerVendedor();
            dtpFecha.Value = DateTime.Now;
            categorias();
            cbxDepto.SelectedIndex = 0;
            cbxTipoVenta.SelectedIndex = 0;

        }
        public ConsultaCancelaVentas(string s, Boolean suc, UnicaSQL.DBMS_Unico svr, int id)
        {
            InitializeComponent();
            Conexion = svr;
            UsuarioID = id.ToString();
            sucursal = suc;
            EmpleadoID = s;
            obtenerVendedor();
            dtpFecha.Value = DateTime.Now;
            categorias();
            cbxDepto.SelectedIndex = 0;
            cbxTipoVenta.SelectedIndex = 0;


        }
        public void obtenerVendedor()
        {
            DataTable tbl = new DataTable();
            Conexion.Conectarse();
            cmd = "SELECT id_empleado,nombre, apellido_paterno, apellido_materno FROM empleados WHERE id_empleado =" + EmpleadoID;
            Conexion.Ejecutar(cmd, ref tbl);
            Conexion.Desconectarse();
            if (tbl.Rows.Count > 0)
            {
                DataRow row = tbl.Rows[0];
                tbxVendedor.Text = row["id_empleado"].ToString();
                tbxNVendedor.Text = row["nombre"].ToString() + " " + row["apellido_paterno"].ToString() + " " + row["apellido_materno"].ToString();
            }
            else
            {
                MessageBox.Show("Código de vendedor no existe.");
            }
        }

        public void categorias()
        {
            DataTable tbl = new DataTable();
            cmd = "select idcategorias, nombre from categorias where clase='a'";
            Conexion.Conectarse();
            Conexion.Ejecutar(cmd, ref tbl);
            Conexion.Desconectarse();
            DataRow row = tbl.NewRow();
            row[0] = 0;
            row[1] = "Todos";
            tbl.Rows.InsertAt(row, 0);
            cbxCategoria.DataSource = tbl;
            cbxCategoria.DisplayMember = "nombre";
            cbxCategoria.ValueMember = "idcategorias";

        }
        //private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        //{
        //    validacion = false;

        //    if (tbxVendedor.Text.Length == 0)
        //    {
        //        if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
        //        {
        //            btnReporte.Focus();
        //        }
        //        tbxNVendedor.Text = "";
        //    }
        //    else
        //    {
        //        if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
        //        {
        //            conectar = conn.ObtenerConexion();
        //            comando = new MySqlCommand("select count(*) from empleados where id_empleado=" + tbxVendedor.Text, conectar);
        //            conectar.Open();

        //            lector = comando.ExecuteReader();

        //            while (lector.Read())
        //            {
        //                if (Convert.ToInt32(lector.GetString(0)) > 0)
        //                {
        //                    validacion = true;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Código de vendedor no existe");
        //                    tbxVendedor.Clear();
        //                    tbxNVendedor.Clear();
        //                }
        //            }

        //            conectar.Close();
        //            if (validacion)
        //            {

        //                comando = new MySqlCommand("select nombre, apellido_paterno, apellido_materno from empleados where id_empleado=" + tbxVendedor.Text, conectar);
        //                conectar.Open();

        //                lector = comando.ExecuteReader();

        //                while (lector.Read())
        //                {
        //                    tbxNVendedor.Text = lector.GetString(0).ToString() + " " + lector.GetString(1).ToString() + " " + lector.GetString(2).ToString();

        //                }
        //                conectar.Close();
        //            }
        //        }
        //        if (validacion)
        //        {
        //            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
        //            {
        //                btnReporte.Focus();
        //            }
        //        }
        //    }
        //}

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

        private void tbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxCliente.Text.Length == 0)
            {
                tbxNCliente.Text = "";
            }
            if (tbxCliente.Text != "")
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    DataTable tbl = new DataTable();
                    cmd = String.Format("SELECT idclientes, nombre FROM clientes WHERE idclientes={0} and empleados_id_empleado={1}",
                        tbxCliente.Text,
                        tbxVendedor.Text);
                    Conexion.Conectarse();
                    Conexion.Ejecutar(cmd, ref tbl);
                    Conexion.Desconectarse();
                    if (tbl.Rows.Count > 0)
                    {
                        DataRow row = tbl.Rows[0];
                        tbxNCliente.Text = row["nombre"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("El cliente no existe ó no pertenece a este vendedor.");
                    }
                }

            }
        }

        private void tbxCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSC_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCliente.Text = id.regresar.valXn;
            }
            tbxCliente.Focus();
        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {

            if (tbxCliente.Text.Length == 0)
            {
                tbxNProducto.Text = "";
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                obtenerProducto();
            }
        }
        public void obtenerProducto()
        {
            if (tbxProducto.Text != "")
            {
                DataTable tbl = new DataTable();
                cmd = String.Format("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre FROM articulos a, unidad_medida u " +
                    "WHERE codigo ={0} and a.unidad_medida_id=u.id",
                    tbxProducto.Text);
                Conexion.Conectarse();
                Conexion.Ejecutar(cmd, ref tbl);
                Conexion.Desconectarse();
                if (tbl.Rows.Count > 0)
                {
                    DataRow row = tbl.Rows[0];
                    tbxNProducto.Text = row["descripcion"].ToString() + " " + row["valor_medida"].ToString() + " " + row["nombre"].ToString();
                }
                else
                {
                    MessageBox.Show("El código de producto es incorrecto.");
                }
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
            BuscarArticulos id = new BuscarArticulos();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxProducto.Text = id.regresar.valXn;
                tbxProducto.Focus();
            }
        }

        double sumaTotal = 0, totalComision = 0;
        String vendedor, cliente, productos, tipocliente, str_depto, str_tipventa;
        private void btnReporte_Click(object sender, EventArgs e)
        {
            sumaTotal = 0;
            totalComision = 0;
            vendedor = "";
            cliente = "";
            productos = "";
            tipocliente = "";
            str_tipventa = "";
            str_depto = "";

            if (cbxDepto.Text == "Productos")
            {
                str_depto = " and a.departamento=1";
            }
            else if (cbxDepto.Text == "Accesorios")
            {
                str_depto = " and a.departamento=2";
            }
            else if (cbxDepto.Text == "Papel")
            {
                str_depto = " and a.departamento=3";
            }

            if (cbxTipoVenta.Text == "Contado")
            {
                str_tipventa = " and v.tipo_compra='contado'";
            }
            else if (cbxTipoVenta.Text == "Crédito")
            {
                str_tipventa = " and v.tipo_compra='credito'";
            }
            else if (cbxTipoVenta.Text == "Consignación")
            {
                str_tipventa = " and v.tipo_compra='consignacion'";
            }

            if (tbxVendedor.Text.Length > 0)
            {
                vendedor = " AND v.empleados_id_empleado=" + tbxVendedor.Text;
            }
            else
            {
                tbxNVendedor.Text = "";
            }
            if (tbxCliente.Text.Length > 0)
            {
                cliente = " AND v.clientes_idclientes=" + tbxCliente.Text;
            }
            else
            {
                tbxNCliente.Text = "";
            }
            if (tbxProducto.Text.Length > 0)
            {
                productos = " AND v.articulos_codigo=" + tbxProducto.Text;
            }
            else
            {
                tbxNProducto.Text = "";
            }
            if (cbxCategoria.Text != "Todos")
            {
                tipocliente = " AND v.categorias_idcategorias=" + cbxCategoria.SelectedValue;
            }
            dtgPProductos.Rows.Clear();
            dtgPClientes.Rows.Clear();
            if (rbtnProductos.Checked)
            {
                DataTable tbl = new DataTable();
                cmd = "SELECT v.articulos_codigo, e.nombre as nombreempleado,c.nombre as nombrecategoria,v.tipo_compra, a.descripcion," +
                    "a.valor_medida,um.nombre as nombremedida, v.precio_art,v.cantidad, v.importe, v.comision, v.empleados_id_empleado," +
                    "v.fecha_venta, v.idventas FROM ventas v,categorias c, articulos a, empleados e, unidad_medida um WHERE " +
                "v.categorias_idcategorias=c.idcategorias and v.articulos_codigo = a.codigo AND " +
                "v.empleados_id_empleado = e.id_empleado AND a.unidad_medida_id=um.id AND " +
                "v.fecha_venta BETWEEN '" + dtpFecha.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFecha.Value.ToString("yyyyMMdd235959") + "' " +
                str_depto + vendedor + cliente + productos + tipocliente + str_tipventa + " ORDER BY v.idventas ASC;";

                Conexion.Conectarse();
                Conexion.Ejecutar(cmd, ref tbl);
                Conexion.Desconectarse();

                if (tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        DataRow row = tbl.Rows[i];
                        formato_fecha = DateTime.Parse(row["fecha_venta"].ToString());
                        //fecha = Convert.ToDateTime(lector.GetString(2).ToString());lector.GetString(1), fecha.ToString("dd/MM/yyyy")
                        dtgPProductos.Rows.Add(false, Convert.ToInt32(row["articulos_codigo"]), row["nombreempleado"].ToString(),
                            row["nombrecategoria"].ToString(), row["tipo_compra"].ToString(), row["descripcion"].ToString()
                            + " " + row["valor_medida"].ToString() + " " + row["nombremedida"].ToString(), Convert.ToDouble(row["precio_art"]),
                            Convert.ToDouble(row["cantidad"]), Convert.ToDouble(row["importe"]), Convert.ToDouble(row["comision"]),
                            row["empleados_id_empleado"].ToString(), formato_fecha, row["idventas"].ToString());
                        sumaTotal += Convert.ToDouble(row["importe"]);
                        totalComision += Convert.ToDouble(row["comision"]);
                    }
                }
                dtgPProductos.Rows.Add(false, "", "", "", "", "", "", "Total", sumaTotal, totalComision, "", "", "");
                dtgPProductos[0, dtgPProductos.Rows.Count - 1].ReadOnly = true;
            }
            else if (rbtnClientes.Checked)
            {
                if (cbxCategoria.Text != "Todos")
                {
                    tipocliente = " AND c.categorias_idcategorias=" + cbxCategoria.SelectedValue;
                }
                else
                {
                    tipocliente = "";
                }
                DataTable tbl = new DataTable();
                cmd = "SELECT e.nombre as NombreEmpleado, cat.Nombre as NombreCategoria, c.nombre as NombreCliente," +
                    " sum(v.importe) as Importe,v.tipo_compra,v.fecha_venta as Fecha,v.empleados_id_empleado as EmpleadoID," +
                    " v.clientes_idclientes as ClienteID FROM ventas v, empleados e, clientes c, categorias cat " +
                    " WHERE v.empleados_id_empleado = " + tbxVendedor.Text + " and e.id_empleado=v.empleados_id_empleado and " +
                    " cat.idcategorias=c.categorias_idcategorias and v.clientes_idclientes=c.idclientes and " +
                    " date(v.fecha_venta) = '" + dtpFecha.Value.ToString("yyyyMMdd") + "' " + cliente + tipocliente + str_tipventa + " GROUP BY v.clientes_idclientes,v.tipo_compra order by v.clientes_idclientes;";

                Conexion.Conectarse();
                Conexion.Ejecutar(cmd, ref tbl);
                Conexion.Desconectarse();
                String colTipoVenta = "";
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    DataRow row = tbl.Rows[i];
                    formato_fecha = DateTime.Parse(row["Fecha"].ToString());
                    if (row["tipo_compra"].ToString() == "consignacion")
                    {
                        colTipoVenta = "Consignación";
                    }
                    else if (row["tipo_compra"].ToString() == "contado")
                    {
                        colTipoVenta = "Contado";
                    }
                    else if (row["tipo_compra"].ToString() == "credito")
                    {
                        colTipoVenta = "Crédito";
                    }
                    //fecha = Convert.ToDateTime(lector.GetString(2).ToString());lector.GetString(1), fecha.ToString("dd/MM/yyyy")
                    dtgPClientes.Rows.Add(false, row["nombreempleado"].ToString(), row["nombrecategoria"].ToString(),
                        row["NombreCliente"].ToString(), Convert.ToDouble(row["Importe"]), colTipoVenta,
                        row["Fecha"], row["EmpleadoID"].ToString(), row["ClienteID"].ToString());
                    sumaTotal += Convert.ToDouble(row["Importe"]);
                }
                dtgPClientes.Rows.Add(false, "", "", "Total", sumaTotal, "", "", "", "");
                dtgPClientes[0, dtgPClientes.Rows.Count - 1].ReadOnly = true;
            }
        }

        DialogResult result;
        string cod_art = "", cod_emp, fecha, cantidad, id_ventas, ClienteID, tipoVenta;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean bAllOk = false;
                CorteCajaBO objCorteCajaBO = new CorteCajaBO();
                DateTime objDTUltimoCorte = objCorteCajaBO.ObtenerFechaUltimoCorte();

                result = MessageBox.Show("Se devolverán ventas seleccionadas ¿desea continuar?", "Devoluciones de ventas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    TimeSpan ts = DateTime.Now - dtpFecha.Value;
                    if (ts.Days == 0)
                    {
                        #region ElimacionHoy
                        if (rbtnProductos.Checked)
                        {
                            #region EliminaPProducto

                            List<DataGridViewRow> listaPProductos = new List<DataGridViewRow>();
                            bAllOk = Conexion.Conectarse();
                            Conexion.IniciarTransaccion();
                            foreach (DataGridViewRow row in dtgPProductos.Rows)
                            {                                
                                DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                                if (Convert.ToBoolean(celdaseleccionada.Value))
                                {
                                    listaPProductos.Add(row);
                                    cod_art = row.Cells[1].Value.ToString();
                                    cantidad = row.Cells[7].Value.ToString();
                                    cod_emp = row.Cells[10].Value.ToString();
                                    fecha = Convert.ToDateTime(row.Cells[11].Value).ToString("yyyyMMddHHmmss");
                                    id_ventas = row.Cells[12].Value.ToString();
                                    if (cod_emp != "1" && !sucursal)
                                    {
                                        #region Paravendedores                           
                                       
                                        if (bAllOk)
                                        {
                                            cmd = "delete from abonos where ventas_idventas='" + id_ventas + "'";
                                            Conexion.Ejecutar(cmd);
                                            if (bAllOk)
                                            {
                                                //eliminación de ventas
                                                cmd = "delete from ventas where idventas='" + id_ventas + "'";
                                                bAllOk = Conexion.Ejecutar(cmd);
                                                if (bAllOk)
                                                {
                                                    //Eliminación de entrada
                                                    cmd = "delete from entradas where articulos_codigo='" + cod_art + "' and empleados_id_empleado='" + cod_emp + "' and fecha='" + fecha + "'";
                                                    Conexion.Ejecutar(cmd);
                                                    if (bAllOk)
                                                    {
                                                        DataTable tbl = new DataTable();
                                                        cmd = String.Format("SELECT Cantidad FROM inv_vendedor where articulos_codigo={0} and empleados_id_empleado={1}",
                                                            cod_art,
                                                            cod_emp);
                                                        bAllOk = Conexion.Ejecutar(cmd, ref tbl);
                                                        DataRow row2 = tbl.Rows[0];
                                                        String invDestino = row2["Cantidad"].ToString();
                                                        cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                           " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                           " VALUES({0},{1},'{2}',now(),{3},{4},{5},{6})",
                                           cod_art, cantidad, "Cancelaciones ventas",
                                           invDestino, Convert.ToDouble(invDestino) + Convert.ToDouble(cantidad), cod_emp, UsuarioID);
                                                        bAllOk = Conexion.Ejecutar(cmd);

                                                        //actualización inventario de vendedor
                                                        cmd = "UPDATE inv_vendedor SET cantidad=cantidad+" + cantidad + " WHERE empleados_id_empleado=" + cod_emp + " AND articulos_codigo=" + cod_art;
                                                        bAllOk = Conexion.Ejecutar(cmd);
                                                    }
                                                }
                                            }
                                        }
                              
                                        #endregion
                                    }
                                    else
                                    {
                                        #region ParaSucursal
                                        cmd = "delete from abonos where ventas_idventas='" + id_ventas + "'";
                                        Conexion.Ejecutar(cmd);
                                        //eliminación de ventas
                                        cmd = "delete from ventas where idventas='" + id_ventas + "'";
                                        bAllOk = Conexion.Ejecutar(cmd);
                                        if (bAllOk)
                                        {
                                                //actualización inventario de vendedor
                                            cmd = "UPDATE articulos SET cantidad=cantidad+" + cantidad + " WHERE codigo=" + cod_art;
                                            bAllOk = Conexion.Ejecutar(cmd);
                                        }
                                   
                                        #endregion
                                    }
                                }
                            }
                            Conexion.FinTransaccion(bAllOk);
                            Conexion.Desconectarse();
                            foreach (DataGridViewRow row in listaPProductos)
                            {
                                dtgPProductos.Rows.Remove(row);
                            }
                            #endregion
                        }
                        else if (rbtnClientes.Checked)
                        {
                            #region EliminaPCliente
                            List<DataGridViewRow> listaPCliente = new List<DataGridViewRow>();
                            bAllOk = Conexion.Conectarse();
                            Conexion.IniciarTransaccion();
                            foreach (DataGridViewRow row in dtgPClientes.Rows)
                            {
                                DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                                if (Convert.ToBoolean(celdaseleccionada.Value))
                                {
                                    listaPCliente.Add(row);
                                    if (row.Cells[5].Value.ToString() == "Consignación")
                                    {
                                        tipoVenta = "consignacion";
                                    }
                                    else if (row.Cells[5].Value.ToString() == "Contado")
                                    {
                                        tipoVenta = "contado";
                                    }
                                    else if (row.Cells[5].Value.ToString() == "Crédito")
                                    {
                                        tipoVenta = "credito";
                                    }
                                    fecha = Convert.ToDateTime(row.Cells[6].Value).ToString("yyyyMMdd");
                                    cod_emp = row.Cells[7].Value.ToString();
                                    ClienteID = row.Cells[8].Value.ToString();
                                                                      
                                    
                                    if (cod_emp != "1" && !sucursal)
                                    {
                                        #region paraVendedores
                                       
                                        if (bAllOk)
                                        {
                                            DataTable tbl = new DataTable();
                                            cmd = String.Format("select articulos_codigo, cantidad, idventas " +
                                                "FROM ventas WHERE clientes_idclientes={0} AND date(fecha_venta)='{1}' and " +
                                            "tipo_compra='{2}';",
                                                ClienteID, fecha, tipoVenta);
                                            bAllOk = Conexion.Ejecutar(cmd, ref tbl);
                                            for (int i = 0; i < tbl.Rows.Count; i++)
                                            {
                                                DataRow rows = tbl.Rows[i];
                                                cod_art = rows["articulos_codigo"].ToString();
                                                cantidad = rows["cantidad"].ToString();
                                                id_ventas = rows["idventas"].ToString();

                                                cmd = "delete from abonos where ventas_idventas='" + id_ventas + "'";
                                                Conexion.Ejecutar(cmd);
                                                if (bAllOk)
                                                {
                                                    //eliminación de ventas
                                                    cmd = "delete from ventas where idventas='" + id_ventas + "'";
                                                    bAllOk = Conexion.Ejecutar(cmd);
                                                    if (bAllOk)
                                                    {
                                                        //Eliminación de entrada
                                                        cmd = "delete from entradas where articulos_codigo='" + cod_art + "' and empleados_id_empleado='" + cod_emp + "' and date(fecha)='" + fecha + "'";
                                                        Conexion.Ejecutar(cmd);
                                                        if (bAllOk)
                                                        {
                                                            DataTable tbl2 = new DataTable();
                                                            cmd = String.Format("SELECT Cantidad FROM inv_vendedor where articulos_codigo={0} and empleados_id_empleado={1}",
                                                                cod_art,
                                                                cod_emp);
                                                            bAllOk = Conexion.Ejecutar(cmd, ref tbl2);
                                                            DataRow row2 = tbl2.Rows[0];
                                                            String invDestino = row2["Cantidad"].ToString();
                                                            cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                               " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                               " VALUES({0},{1},'{2}',now(),{3},{4},{5},{6})",
                                               cod_art, cantidad, "Cancelaciones ventas",
                                               invDestino, Convert.ToDouble(invDestino) + Convert.ToDouble(cantidad), cod_emp, UsuarioID);
                                                            bAllOk = Conexion.Ejecutar(cmd);

                                                            //actualización inventario de vendedor
                                                            cmd = "UPDATE inv_vendedor SET cantidad=cantidad+" + cantidad + " WHERE empleados_id_empleado=" + cod_emp + " AND articulos_codigo=" + cod_art;
                                                            bAllOk = Conexion.Ejecutar(cmd);
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                   
                                        #endregion
                                    }
                                    else
                                    {
                                        #region ParaSucursal

                                        DataTable tbl = new DataTable();
                                        cmd = String.Format("select articulos_codigo, cantidad, idventas " +
                                            "FROM ventas WHERE clientes_idclientes={0} AND date(fecha_venta)='{1}' and " +
                                        "tipo_compra='{2}';",
                                            ClienteID, fecha, tipoVenta);
                                        bAllOk = Conexion.Ejecutar(cmd, ref tbl);
                                        for (int i = 0; i < tbl.Rows.Count; i++)
                                        {
                                            DataRow rows = tbl.Rows[i];
                                            cod_art = rows["articulos_codigo"].ToString();
                                            cantidad = rows["cantidad"].ToString();
                                            id_ventas = rows["idventas"].ToString();
                                            cmd = "delete from abonos where ventas_idventas='" + id_ventas + "'";
                                            Conexion.Ejecutar(cmd);
                                            if (bAllOk)
                                            {
                                                //eliminación de ventas
                                                cmd = "delete from ventas where idventas='" + id_ventas + "'";
                                                bAllOk = Conexion.Ejecutar(cmd);
                                                if (bAllOk)
                                                {
                                                    //actualización inventario de vendedor
                                                    cmd = "UPDATE articulos SET cantidad=cantidad+" + cantidad + " WHERE codigo=" + cod_art;
                                                    bAllOk = Conexion.Ejecutar(cmd);
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }
                            Conexion.FinTransaccion(bAllOk);
                            Conexion.Desconectarse();

                            foreach (DataGridViewRow row in listaPCliente)
                            {
                                dtgPClientes.Rows.Remove(row);
                            }
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {                       
                        #region EliminacionDiasAnteriores

                        Boolean bContador = false;
                        string Respuesta = "";
                        string S = ".";
                        inicioSesion id = new inicioSesion(S);
                        DialogResult dr = id.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            Respuesta = id.regresar.valXn;
                        }
                        if (Respuesta != "")
                        {
                            if (Respuesta == "True")
                            {
                                if (rbtnProductos.Checked)
                                {
                                    #region EliminaPProductos
                                    List<DataGridViewRow> list = new List<DataGridViewRow>();
                                    foreach (DataGridViewRow row in dtgPProductos.Rows)
                                    {
                                        DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;
                                        DataGridViewTextBoxCell celdaTipoVenta = row.Cells[4] as DataGridViewTextBoxCell;

                                        if (Convert.ToBoolean(celdaseleccionada.Value) && Convert.ToString(celdaTipoVenta.Value).Trim().ToLower()=="credito")
                                        {
                                            list.Add(row);
                                            cod_art = row.Cells[1].Value.ToString();
                                            cantidad = row.Cells[7].Value.ToString();
                                            cod_emp = row.Cells[10].Value.ToString();
                                            fecha = row.Cells[11].Value.ToString();
                                            id_ventas = row.Cells[12].Value.ToString();

                                            if (cod_emp != "1" && !sucursal)
                                            {
                                                bAllOk = Conexion.Conectarse();
                                                Conexion.IniciarTransaccion();
                                                cmd = "delete from abonos where ventas_idventas='" + id_ventas + "'";
                                                Conexion.Ejecutar(cmd);
                                                if (bAllOk)
                                                {
                                                    //eliminación de ventas
                                                    cmd = "delete from ventas where idventas='" + id_ventas + "'";
                                                    bAllOk = Conexion.Ejecutar(cmd);
                                                    if (bAllOk)
                                                    {
                                                        //Eliminación de entrada
                                                        cmd = "delete from entradas where articulos_codigo='" + cod_art + "' and empleados_id_empleado='" + cod_emp + "' and fecha='" + fecha + "'";
                                                        Conexion.Ejecutar(cmd);
                                                        if (bAllOk)
                                                        {
                                                            DataTable tbl2 = new DataTable();
                                                            cmd = String.Format("SELECT Cantidad FROM inv_vendedor where articulos_codigo={0} and empleados_id_empleado={1}",
                                                                cod_art,
                                                                cod_emp);
                                                            bAllOk = Conexion.Ejecutar(cmd, ref tbl2);
                                                            DataRow row2 = tbl2.Rows[0];
                                                            String invDestino = row2["Cantidad"].ToString();
                                                            cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                               " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                               " VALUES({0},{1},'{2}',now(),{3},{4},{5},{6})",
                                               cod_art, cantidad, "Cancelaciones ventas",
                                               invDestino, Convert.ToDouble(invDestino) + Convert.ToDouble(cantidad), cod_emp, UsuarioID);
                                                            bAllOk = Conexion.Ejecutar(cmd);

                                                            //actualización inventario de vendedor
                                                            cmd = "UPDATE inv_vendedor SET cantidad=cantidad+" + cantidad + " WHERE empleados_id_empleado=" + cod_emp + " AND articulos_codigo=" + cod_art;
                                                            bAllOk = Conexion.Ejecutar(cmd);
                                                        }
                                                    }
                                                }
                                                Conexion.FinTransaccion(bAllOk);
                                                Conexion.Desconectarse();
                                            }
                                            else
                                            {
                                                bAllOk = Conexion.Conectarse();
                                                Conexion.IniciarTransaccion();
                                                cmd = "delete from abonos where ventas_idventas='" + id_ventas + "'";
                                                Conexion.Ejecutar(cmd);
                                                if (bAllOk)
                                                {

                                                    //eliminación de ventas
                                                    cmd = "delete from ventas where idventas='" + id_ventas + "'";
                                                    bAllOk = Conexion.Ejecutar(cmd);
                                                    if (bAllOk)
                                                    {
                                                        cmd = "UPDATE articulos SET cantidad=cantidad+" + cantidad + " WHERE codigo=" + cod_art;
                                                        bAllOk = Conexion.Ejecutar(cmd);
                                                        bContador = true;
                                                    }
                                                }
                                                Conexion.FinTransaccion(bAllOk);
                                                Conexion.Desconectarse();
                                            }
                                        }
                                    }

                                    foreach (DataGridViewRow row in list)
                                    {
                                        dtgPProductos.Rows.Remove(row);
                                    }
                                    dtgPProductos.Rows.Clear();
                                    #endregion
                                }
                                else if (rbtnClientes.Checked)
                                {
                                    #region EliminaPCliente
                                    List<DataGridViewRow> listaPCliente = new List<DataGridViewRow>();
                                    foreach (DataGridViewRow row in dtgPClientes.Rows)
                                    {
                                        DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;
                                        DataGridViewTextBoxCell celdaTipoVenta = row.Cells[5] as DataGridViewTextBoxCell;

                                        if (Convert.ToBoolean(celdaseleccionada.Value) && Convert.ToString(celdaTipoVenta.Value).Trim().ToLower() == "crédito")
                                        {
                                            listaPCliente.Add(row);
                                            if (row.Cells[5].Value.ToString() == "Consignación")
                                            {
                                                tipoVenta = "consignacion";
                                            }
                                            else if (row.Cells[5].Value.ToString() == "Contado")
                                            {
                                                tipoVenta = "contado";
                                            }
                                            else if (row.Cells[5].Value.ToString() == "Crédito")
                                            {
                                                tipoVenta = "credito";
                                            }
                                            fecha = Convert.ToDateTime(row.Cells[6].Value).ToString("yyyyMMdd");
                                            cod_emp = row.Cells[7].Value.ToString();
                                            ClienteID = row.Cells[8].Value.ToString();

                                            if (cod_emp != "1" && !sucursal)
                                            {
                                                #region paraVendedores
                                                bAllOk = Conexion.Conectarse();
                                                Conexion.IniciarTransaccion();
                                                if (bAllOk)
                                                {
                                                    DataTable tbl = new DataTable();
                                                    cmd = String.Format("select articulos_codigo, cantidad, idventas " +
                                                        "FROM ventas WHERE clientes_idclientes={0} AND date(fecha_venta)='{1}' and " +
                                            "tipo_compra='{2}';",
                                                        ClienteID, fecha, tipoVenta);
                                                    bAllOk = Conexion.Ejecutar(cmd, ref tbl);
                                                    for (int i = 0; i < tbl.Rows.Count; i++)
                                                    {
                                                        DataRow rows = tbl.Rows[i];
                                                        cod_art = rows["articulos_codigo"].ToString();
                                                        cantidad = rows["cantidad"].ToString();
                                                        id_ventas = rows["idventas"].ToString();

                                                        cmd = "delete from abonos where ventas_idventas='" + id_ventas + "'";
                                                        Conexion.Ejecutar(cmd);
                                                        if (bAllOk)
                                                        {
                                                            //eliminación de ventas
                                                            cmd = "delete from ventas where idventas='" + id_ventas + "'";
                                                            bAllOk = Conexion.Ejecutar(cmd);
                                                            if (bAllOk)
                                                            {
                                                                //Eliminación de entrada
                                                                cmd = "delete from entradas where articulos_codigo='" + cod_art + "' and empleados_id_empleado='" + cod_emp + "' and date(fecha)='" + fecha + "'";
                                                                Conexion.Ejecutar(cmd);
                                                                if (bAllOk)
                                                                {
                                                                    DataTable tbl2 = new DataTable();
                                                                    cmd = String.Format("SELECT Cantidad FROM inv_vendedor where articulos_codigo={0} and empleados_id_empleado={1}",
                                                                        cod_art,
                                                                        cod_emp);
                                                                    bAllOk = Conexion.Ejecutar(cmd, ref tbl2);
                                                                    DataRow row2 = tbl2.Rows[0];
                                                                    String invDestino = row2["Cantidad"].ToString();
                                                                    cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                                       " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                                       " VALUES({0},{1},'{2}',now(),{3},{4},{5},{6})",
                                                       cod_art, cantidad, "Cancelaciones ventas",
                                                       invDestino, Convert.ToDouble(invDestino) + Convert.ToDouble(cantidad), cod_emp, UsuarioID);
                                                                    bAllOk = Conexion.Ejecutar(cmd);

                                                                    //actualización inventario de vendedor
                                                                    cmd = "UPDATE inv_vendedor SET cantidad=cantidad+" + cantidad + " WHERE empleados_id_empleado=" + cod_emp + " AND articulos_codigo=" + cod_art;
                                                                    bAllOk = Conexion.Ejecutar(cmd);
                                                                    bContador = true;
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                                Conexion.FinTransaccion(bAllOk);
                                                Conexion.Desconectarse();
                                                #endregion
                                            }
                                            else
                                            {
                                                #region ParaSucursal
                                                bAllOk = Conexion.Conectarse();
                                                Conexion.IniciarTransaccion();

                                                DataTable tbl = new DataTable();
                                                cmd = String.Format("select articulos_codigo, cantidad, idventas " +
                                                    "FROM ventas WHERE clientes_idclientes={0} AND date(fecha_venta)='{1}' and " +
                                            "tipo_compra='{2}';",
                                                    ClienteID, fecha, tipoVenta);
                                                bAllOk = Conexion.Ejecutar(cmd, ref tbl);
                                                for (int i = 0; i < tbl.Rows.Count; i++)
                                                {
                                                    DataRow rows = tbl.Rows[i];
                                                    cod_art = rows["articulos_codigo"].ToString();
                                                    cantidad = rows["cantidad"].ToString();
                                                    id_ventas = rows["idventas"].ToString();
                                                    cmd = "delete from abonos where ventas_idventas='" + id_ventas + "'";
                                                    Conexion.Ejecutar(cmd);
                                                    if (bAllOk)
                                                    {
                                                        //eliminación de ventas
                                                        cmd = "delete from ventas where idventas='" + id_ventas + "'";
                                                        bAllOk = Conexion.Ejecutar(cmd);
                                                        if (bAllOk)
                                                        {
                                                            //actualización inventario de vendedor
                                                            cmd = "UPDATE articulos SET cantidad=cantidad+" + cantidad + " WHERE codigo=" + cod_art;
                                                            bAllOk = Conexion.Ejecutar(cmd);
                                                            bContador = true;
                                                        }
                                                    }
                                                }
                                                Conexion.FinTransaccion(bAllOk);
                                                Conexion.Desconectarse();
                                                #endregion
                                            }
                                        }
                                    }

                                    foreach (DataGridViewRow row in listaPCliente)
                                    {
                                        dtgPClientes.Rows.Remove(row);
                                    }
                                    #endregion
                                }
                                dtgPClientes.Rows.Clear();
                                if (bContador)
                                {
                                    MessageBox.Show("Venta eliminada con éxito.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El usuario no tiene permiso necesario para cancelar la venta.");
                            }
                        }
                        
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tblReporteV_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            if (e.RowIndex2 < dtgPProductos.Rows.Count - 1 && e.RowIndex1 < dtgPProductos.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "tblCodigo" && e.RowIndex2 < dtgPProductos.Rows.Count - 1 && e.RowIndex1 < dtgPProductos.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgPProductos.Rows[e.RowIndex1].Cells["tblCodigo"].Value.ToString()),
                    Convert.ToInt32(dtgPProductos.Rows[e.RowIndex2].Cells["tblCodigo"].Value.ToString()));
            }
            if (e.Column.Name == "tblPrecio" && e.RowIndex2 < dtgPProductos.Rows.Count - 1 && e.RowIndex1 < dtgPProductos.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgPProductos.Rows[e.RowIndex1].Cells["tblPrecio"].Value.ToString()),
                    Convert.ToDouble(dtgPProductos.Rows[e.RowIndex2].Cells["tblPrecio"].Value.ToString()));
            }

            if (e.Column.Name == "tblCantidad" && e.RowIndex2 < dtgPProductos.Rows.Count - 1 && e.RowIndex1 < dtgPProductos.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgPProductos.Rows[e.RowIndex1].Cells["tblCantidad"].Value.ToString()),
                    Convert.ToDouble(dtgPProductos.Rows[e.RowIndex2].Cells["tblCantidad"].Value.ToString()));
            }

            if (e.Column.Name == "tblTotal" && e.RowIndex2 < dtgPProductos.Rows.Count - 1 && e.RowIndex1 < dtgPProductos.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgPProductos.Rows[e.RowIndex1].Cells["tblTotal"].Value.ToString()),
                    Convert.ToDouble(dtgPProductos.Rows[e.RowIndex2].Cells["tblTotal"].Value.ToString()));
            }
            if (e.Column.Name == "tblComision" && e.RowIndex2 < dtgPProductos.Rows.Count - 1 && e.RowIndex1 < dtgPProductos.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgPProductos.Rows[e.RowIndex1].Cells["tblComision"].Value.ToString()),
                    Convert.ToDouble(dtgPProductos.Rows[e.RowIndex2].Cells["tblComision"].Value.ToString()));
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

        private void rbtnProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnProductos.Checked)
            {
                dtgPProductos.Visible = true;
                dtgPClientes.Visible = false;
            }
        }

        private void rbtnClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnClientes.Checked)
            {
                dtgPClientes.Visible = true;
                dtgPProductos.Visible = false;
            }
        }

        private void dtgPClientes_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            if (e.RowIndex2 < dtgPClientes.Rows.Count - 1 && e.RowIndex1 < dtgPClientes.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            if (e.Column.Name == "colTotal" && e.RowIndex2 < dtgPClientes.Rows.Count - 1 && e.RowIndex1 < dtgPClientes.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgPClientes.Rows[e.RowIndex1].Cells["colTotal"].Value.ToString()),
                    Convert.ToDouble(dtgPClientes.Rows[e.RowIndex2].Cells["colTotal"].Value.ToString()));
            }

            if (e.Column.Name == "colComision" && e.RowIndex2 < dtgPClientes.Rows.Count - 1 && e.RowIndex1 < dtgPClientes.Rows.Count - 1)
            {
                // e.SortResult = tblReporteV.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  tblReporteV.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgPClientes.Rows[e.RowIndex1].Cells["colComision"].Value.ToString()),
                    Convert.ToDouble(dtgPClientes.Rows[e.RowIndex2].Cells["colComision"].Value.ToString()));
            }

            e.Handled = true;
        }

        private void dtgPClientes_DoubleClick(object sender, EventArgs e)
        {
            if (dtgPClientes.CurrentRow.Index < dtgPClientes.Rows.Count - 1)
            {
                CancelacionesClientes cl = new CancelacionesClientes(Conexion, dtgPClientes.CurrentRow.Cells[8].Value.ToString(),
                    dtpFecha.Value, Convert.ToInt32(UsuarioID), dtgPClientes.CurrentRow.Cells[5].Value.ToString());
                cl.ShowDialog();
            }

        }

        private void ConsultaCancelaVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (tbxCliente.Focused)
            {
                if (e.KeyCode == Keys.F1)
                {


                    BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxCliente.Text = id.regresar.valXn;
                    }
                    tbxCliente.Focus();
                }
            }
            else if (tbxProducto.Focused)
            {
                if (e.KeyCode == Keys.F1)
                {
                    BuscarArticulos id = new BuscarArticulos();
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxProducto.Text = id.regresar.valXn;
                        tbxProducto.Focus();
                    }
                }

            }
            else if (tbxVendedor.Focused)
            {
                if (e.KeyCode == Keys.F1)
                {
                    BuscarVendedor id = new BuscarVendedor();
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxVendedor.Text = id.regresar.valXn;
                    }
                    tbxVendedor.Focus();
                }

            }
        }
    }
}
