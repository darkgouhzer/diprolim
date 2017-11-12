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
    public partial class CancelacionesClientes : Form
    {
        Inventarios.DBMS_Unico Conexion;
        String cmd;
        String UsuarioID;
        String tipoVenta;
        public CancelacionesClientes(Inventarios.DBMS_Unico svr, String ClienteID,DateTime Fecha, int id,String tv)
        {
            InitializeComponent();
            Conexion = svr;
            tbxCliente.Text = ClienteID;
            dtpFecha.Value = Fecha;
            UsuarioID = id.ToString();
            tbxTipoVenta.Text = tv;
            if (tv == "Consignación")
            {
                tipoVenta = "consignacion";
            }
            else if (tv == "Contado")
            {
               tipoVenta = "contado";
            }
            else if (tv == "Crédito")
            {
                tipoVenta = "credito";
            }
        }

        public void ObtenerVendedor(String EmpleadoID)
        {
            try
            {
                tbxVendedor.Text = EmpleadoID;
                DataTable tbl = new DataTable();
                cmd = String.Format("SELECT nombre, apellido_paterno, apellido_materno FROM Empleados WHERE id_empleado={0}",
                    EmpleadoID);
                Conexion.Conectarse();
                Conexion.Ejecutar(cmd, ref tbl);
                Conexion.Desconectarse();
                if (tbl.Rows.Count > 0)
                {
                    DataRow row = tbl.Rows[0];
                    tbxNVendedor.Text = row["nombre"].ToString() + " " + row["apellido_paterno"].ToString() + 
                        " " + row["apellido_materno"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tbxCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable tbl = new DataTable();
                cmd = String.Format("SELECT nombre,empleados_id_empleado FROM Clientes WHERE idclientes={0}", tbxCliente.Text);
                Conexion.Conectarse();
                Conexion.Ejecutar(cmd, ref tbl);
                Conexion.Desconectarse();
                if (tbl.Rows.Count > 0)
                {
                    DataRow row=tbl.Rows[0];
                    tbxNCliente.Text = row["nombre"].ToString();
                    ObtenerVendedor(row["empleados_id_empleado"].ToString());
                    ObtenerProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ObtenerProductos()
        {
            try
            {
                DataTable tbl = new DataTable();
                dtgClientesProductos.Rows.Clear();
                cmd = String.Format("select v.articulos_codigo, a.descripcion, a.valor_medida, um.nombre, v.precio_art,v.cantidad,"+
                    " v.importe, v.Comision,v.idventas FROM ventas v, articulos a, unidad_medida um "+
                    " WHERE v.clientes_idclientes={0} AND date(v.fecha_venta)='{1}' and v.articulos_codigo=a.codigo "+
                    "and um.id=a.unidad_medida_id and tipo_compra='{2}';", 
                    tbxCliente.Text,
                    dtpFecha.Value.ToString("yyyyMMdd"),
                    tipoVenta);
                Conexion.Conectarse();
                Conexion.Ejecutar(cmd, ref tbl);
                Conexion.Desconectarse();
                if (tbl.Rows.Count > 0)
                {
                    double sumaTotal = 0, sumaComision = 0;
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        DataRow row = tbl.Rows[i];
                        dtgClientesProductos.Rows.Add(false, row["articulos_codigo"], row["descripcion"] + " " + row["valor_medida"] + " " + row["nombre"],
                            row["precio_art"], row["cantidad"], row["importe"], row["Comision"], row["idventas"]);
                        sumaTotal += Convert.ToDouble(row["importe"]);
                        sumaComision += Convert.ToDouble(row["Comision"]);
                    }
                    dtgClientesProductos.Rows.Add(false,"", "","", "Total", sumaTotal, sumaComision, "");
                    dtgClientesProductos[0, dtgClientesProductos.Rows.Count - 1].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CancelacionesClientes_Load(object sender, EventArgs e)
        {
            tbxCliente_Leave(sender, e);
        }

        private void tbxCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void dtgClientesProductos_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            if (e.RowIndex2 < dtgClientesProductos.Rows.Count - 1 && e.RowIndex1 < dtgClientesProductos.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            if (e.Column.Name == "colCodigo" && e.RowIndex2 < dtgClientesProductos.Rows.Count - 1 && e.RowIndex1 < dtgClientesProductos.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgClientesProductos.Rows[e.RowIndex1].Cells["colCodigo"].Value.ToString()),
                    Convert.ToDouble(dtgClientesProductos.Rows[e.RowIndex2].Cells["colCodigo"].Value.ToString()));
            }
            if (e.Column.Name == "colPrecio" && e.RowIndex2 < dtgClientesProductos.Rows.Count - 1 && e.RowIndex1 < dtgClientesProductos.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgClientesProductos.Rows[e.RowIndex1].Cells["colPrecio"].Value.ToString()),
                    Convert.ToDouble(dtgClientesProductos.Rows[e.RowIndex2].Cells["colPrecio"].Value.ToString()));
            }

            if (e.Column.Name == "colCantidad" && e.RowIndex2 < dtgClientesProductos.Rows.Count - 1 && e.RowIndex1 < dtgClientesProductos.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgClientesProductos.Rows[e.RowIndex1].Cells["colCantidad"].Value.ToString()),
                    Convert.ToDouble(dtgClientesProductos.Rows[e.RowIndex2].Cells["colCantidad"].Value.ToString()));
            }

            if (e.Column.Name == "colTotal" && e.RowIndex2 < dtgClientesProductos.Rows.Count - 1 && e.RowIndex1 < dtgClientesProductos.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgClientesProductos.Rows[e.RowIndex1].Cells["colTotal"].Value.ToString()),
                    Convert.ToDouble(dtgClientesProductos.Rows[e.RowIndex2].Cells["colTotal"].Value.ToString()));
            }
            if (e.Column.Name == "colComision" && e.RowIndex2 < dtgClientesProductos.Rows.Count - 1 && e.RowIndex1 < dtgClientesProductos.Rows.Count - 1)
            {
                e.SortResult = comparar(Convert.ToDouble(dtgClientesProductos.Rows[e.RowIndex1].Cells["colComision"].Value.ToString()),
                    Convert.ToDouble(dtgClientesProductos.Rows[e.RowIndex2].Cells["colComision"].Value.ToString()));
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

        private void btnSC_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCliente.Text = id.regresar.valXn;
                tbxCliente_Leave(sender, e);
            }

        }

        private void tbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxCliente_Leave(sender, e);
            }
        }
        DialogResult result;
        string cod_art = "", cod_emp, fecha, cantidad, id_ventas, ClienteID;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean bAllOk = false;
                result = MessageBox.Show("Se devolverán ventas seleccionadas ¿desea continuar?", "Devoluciones de ventas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    TimeSpan ts = DateTime.Now - dtpFecha.Value;
                    if (ts.Days == 0)
                    {
                        #region ElimacionHoy
                
                            #region EliminaPProducto
                        
                            List<DataGridViewRow> listaPProductos = new List<DataGridViewRow>();
                            foreach (DataGridViewRow row in dtgClientesProductos.Rows)
                            {
                                DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                                if (Convert.ToBoolean(celdaseleccionada.Value))
                                {
                                    listaPProductos.Add(row);
                                    cod_art = row.Cells[1].Value.ToString();
                                    cantidad = row.Cells[4].Value.ToString();
                                    cod_emp = tbxVendedor.Text;
                                    fecha = dtpFecha.Value.ToString("yyyyMMdd");
                                    id_ventas = row.Cells[7].Value.ToString();

                                    if (cod_emp != "1")
                                    {
                                        #region Paravendedores
                                        Conexion.Conectarse();
                                        Conexion.IniciarTransaccion();
                                        if (bAllOk)
                                        {
                                            cmd = "delete from abonos where ventas_idventas='" + id_ventas + "'";
                                            Conexion.Ejecutar(cmd);
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
                                                    Conexion.Ejecutar(cmd, ref tbl2);
                                                    DataRow row2 = tbl2.Rows[0];
                                                    String invDestino = row2["Cantidad"].ToString();
                                                    cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                       " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                       " VALUES({0},{1},'{2}',now(),{3},{4},{5},{6})",
                                       cod_art, cantidad, "Cancelaciones ventas",
                                       invDestino, Convert.ToDouble(invDestino) + Convert.ToDouble(cantidad), cod_emp, UsuarioID);
                                                    Conexion.Ejecutar(cmd);
                                                    //actualización inventario de vendedor
                                                    cmd = "UPDATE inv_vendedor SET cantidad=cantidad+" + cantidad + " WHERE empleados_id_empleado=" + cod_emp + " AND articulos_codigo=" + cod_art;
                                                    bAllOk = Conexion.Ejecutar(cmd);
                                                }
                                            }
                                        }
                                        Conexion.FinalizarTransaccion(bAllOk);
                                        Conexion.Desconectarse();
                                        MessageBox.Show("Venta cancelada con éxito.");
                                        #endregion
                                    }
                                    else
                                    {
                                        #region ParaSucursal
                                        Conexion.Conectarse();
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
                                                //actualización inventario de vendedor
                                                cmd = "UPDATE articulos SET cantidad=cantidad+" + cantidad + " WHERE codigo=" + cod_art;
                                                bAllOk = Conexion.Ejecutar(cmd);
                                            }
                                        }
                                        Conexion.FinalizarTransaccion(bAllOk);
                                        Conexion.Desconectarse();
                                        MessageBox.Show("Venta cancelada con éxito.");
                                        #endregion
                                    }
                                }
                            }

                            foreach (DataGridViewRow row in listaPProductos)
                            {
                                dtgClientesProductos.Rows.Remove(row);
                            }
                            #endregion
                   
                        #endregion
                    }
                    else
                    {
                        #region EliminacionDiasAnteriores
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
                                #region EliminaPProductos
                                    List<DataGridViewRow> list = new List<DataGridViewRow>();
                                    List<String> list2 = new List<string>();
                                    foreach (DataGridViewRow row in dtgClientesProductos.Rows)
                                    {
                                        DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                                        if (Convert.ToBoolean(celdaseleccionada.Value))
                                        {
                                            list.Add(row);
                                            cod_art = row.Cells[1].Value.ToString();
                                            cantidad = row.Cells[4].Value.ToString();
                                            cod_emp = tbxVendedor.Text;
                                            fecha = dtpFecha.Value.ToString("yyyyMMdd");
                                            id_ventas = row.Cells[7].Value.ToString();

                                            if (cod_emp != "1")
                                            {
                                                Conexion.Conectarse();
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
                                                        cmd = "delete from entradas where articulos_codigo='" + cod_art + "' and empleados_id_empleado='" + cod_emp + "' and date(fecha)='" + fecha + "'";
                                                        Conexion.Ejecutar(cmd);
                                                        if (bAllOk)
                                                        {
                                                            DataTable tbl2 = new DataTable();
                                                            cmd = String.Format("SELECT Cantidad FROM inv_vendedor where articulos_codigo={0} and empleados_id_empleado={1}",
                                                                cod_art,
                                                                cod_emp);
                                                            Conexion.Ejecutar(cmd, ref tbl2);
                                                            DataRow row2 = tbl2.Rows[0];
                                                            String invDestino = row2["Cantidad"].ToString();
                                                            cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                               " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                               " VALUES({0},{1},'{2}',now(),{3},{4},{5},{6})",
                                               cod_art, cantidad, "Cancelaciones ventas",
                                               invDestino, Convert.ToDouble(invDestino) + Convert.ToDouble(cantidad), cod_emp, UsuarioID);
                                                            Conexion.Ejecutar(cmd);
                                                            //actualización inventario de vendedor
                                                            cmd = "UPDATE inv_vendedor SET cantidad=cantidad+" + cantidad + " WHERE empleados_id_empleado=" + cod_emp + " AND articulos_codigo=" + cod_art;
                                                            bAllOk = Conexion.Ejecutar(cmd);
                                                        }
                                                    }
                                                }
                                                Conexion.FinalizarTransaccion(bAllOk);
                                                Conexion.Desconectarse();
                                                MessageBox.Show("Venta cancelada con éxito.");
                                            }
                                            else
                                            {
                                                Conexion.Conectarse();
                                                Conexion.IniciarTransaccion();
                                                cmd = "delete from abonos where ventas_idventas='" + id_ventas + "'";
                                                Conexion.Ejecutar(cmd);
                                                if (bAllOk)
                                                {
                                                    //eliminación de ventas
                                                    cmd = "delete from ventas where idventas='" + id_ventas + "'";
                                                    Conexion.Ejecutar(cmd);
                                                    if (bAllOk)
                                                    {
                                                        cmd = "UPDATE articulos SET cantidad=cantidad+" + cantidad + " WHERE codigo=" + cod_art;
                                                        bAllOk = Conexion.Ejecutar(cmd);
                                                    }
                                                }
                                                Conexion.FinalizarTransaccion(bAllOk);
                                                Conexion.Desconectarse();
                                                MessageBox.Show("Venta cancelada con éxito.");
                                            }
                                        }
                                    }

                                    foreach (DataGridViewRow row in list)
                                    {
                                        dtgClientesProductos.Rows.Remove(row);
                                    }
                                    dtgClientesProductos.Rows.Clear();
                                    #endregion
  
                            }
                            else
                            {
                                MessageBox.Show("El usuario no tiene permiso necesario para cancelar la venta.");
                            }
                        }
                        //MessageBox.Show("No puede cancelar ventas de dias anteriores.");
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}