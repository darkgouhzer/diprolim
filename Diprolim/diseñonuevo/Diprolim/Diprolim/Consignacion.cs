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
    public partial class Consignacion : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        double Comision = 0;
        double Preciop = 0;
        String UsuarioID;
        public Consignacion(UnicaSQL.DBMS_Unico sConexion, String ID)
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            Conexion = sConexion;
            refrescarTabla();
            UsuarioID = ID;
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

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCCliente.Text = id.regresar.valXn;
            }
            tbxCCliente.Focus();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text.Length > 0 && tbxCCliente.Text.Length>0)
            {
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
                MessageBox.Show("Primero elija un vendedor y un cliente.");
            }
        }
        public void obtenerVendedor()
        {
            try
            {
                if (tbxVendedor.Text.Length > 0)
                {
                    Conexion.Conectarse();
                    DataTable tbl = new DataTable();
                    Conexion.Ejecutar("select nombre, apellido_paterno, apellido_materno from empleados where id_empleado=" + tbxVendedor.Text, ref tbl);
                    if (tbl.Rows.Count > 0)
                    {
                        DataRow row = tbl.Rows[0];
                        tbxNVendedor.Text = row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString();
                    }
                    else
                    {
                        tbxNVendedor.Clear();
                    }
                    Conexion.Desconectarse();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int categoria = 0;
        public void obtenerCliente()
        {
            try
            {
                if (tbxCCliente.Text.Length > 0)
                {
                    Conexion.Conectarse();
                    DataTable tbl = new DataTable();
                    Conexion.Ejecutar("select nombre, empleados_id_empleado from clientes where idclientes=" + tbxCCliente.Text, ref tbl);
                    if (tbl.Rows.Count > 0)
                    {
                        DataRow row = tbl.Rows[0];
                        tbxNCliente.Text = row[0].ToString();
                        tbxVendedor.Text = row[1].ToString();
                        refrescarTabla();
                        DataTable tbl2 = new DataTable();
                        Conexion.Ejecutar("select i.articulos_codigo,a.descripcion, a.valor_medida, um.nombre,i.cantidad,"+
                            "i.precio, i.fecha, i.idinv_Abarrote, a.Comision,a.departamento,a.precioproduccion from inv_clientes i, articulos a," +
                            "unidad_medida um where i.articulos_codigo=a.codigo and a.unidad_medida_id=um.id and "+
                        "i.cantidad>0 and clientes_idclientes=" + tbxCCliente.Text+" order by i.fecha asc", ref tbl2);
                        if (tbl2.Rows.Count > 0)
                        {
                            for (int i = 0; i < tbl2.Rows.Count; i++)
                            {
                                row = tbl2.Rows[i];
                                if (row[9].ToString() == "1")
                                {
                                    categoria = 7;
                                }
                                else if (row[9].ToString() == "2")
                                {
                                    categoria = 6;
                                }
                                else
                                {
                                    categoria = 10;
                                }
                                TimeSpan ts = DateTime.Now.AddDays(1) - Convert.ToDateTime(row[6]);
                                dtgConsignacion.Rows.Insert(dtgConsignacion.Rows.Count - 1,false,row[0].ToString(),row[1].ToString()+" "+
                                    row[2].ToString()+" "+row[3].ToString(),Convert.ToDouble(row[4]),0,Convert.ToDouble(row[5]),
                                    Convert.ToDouble(row[4]) * Convert.ToDouble(row[5]), (Convert.ToDouble(row[4]) * Convert.ToDouble(row[5])) * (Convert.ToDouble(row[8]) / 100), (Convert.ToDouble(row[4]) * Convert.ToDouble(row[5])) - ((Convert.ToDouble(row[4]) * Convert.ToDouble(row[5])) * (Convert.ToDouble(row[8]) / 100)), Convert.ToDateTime(row[6]).ToString("dd/MM/yyyy"), ts.Days, Convert.ToInt32(row[7]),
                                    Convert.ToDouble(row[8]),categoria,Convert.ToDouble(row[10]));
                                dtgConsignacion[0,dtgConsignacion.Rows.Count - 2].ReadOnly = false;
                                dtgConsignacion.Rows[dtgConsignacion.Rows.Count - 2].DefaultCellStyle.BackColor = Color.AliceBlue;
                            }
                        }
                    }
                    Conexion.Desconectarse();
                    if (tbl.Rows.Count > 0)
                    {
                        obtenerVendedor();
                    }
                    Totales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void refrescarTabla()
        {
            dtgConsignacion.Rows.Clear();
            dtgConsignacion.Rows.Add(false,"","","","","",0,0,0,"","","","");
            dtgConsignacion.Rows[dtgConsignacion.Rows.Count - 1].ReadOnly = false;
            dtgConsignacion.Rows[dtgConsignacion.Rows.Count - 1].DefaultCellStyle.BackColor=Color.LightGray;
        }
        private void tbxVendedor_Leave(object sender, EventArgs e)
        {
            obtenerVendedor();
        }

        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbxCCliente.Focus();
            }
            else if (e.KeyCode == Keys.F1)
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

        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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

        private void tbxCCliente_Leave(object sender, EventArgs e)
        {
            obtenerCliente();
        }
        Double PrecioProduccion;
        public void obtenerProductos()
        {
            try
            {
                if (tbxProducto.Text.Length > 0)
                {
                    PrecioProduccion = 0;
                    Conexion.Conectarse();
                    DataTable tbl = new DataTable();
                    Conexion.Ejecutar("select a.descripcion, a.valor_medida, um.nombre,i.cantidad,a.precio_abarrotes,a.Comision, "
                    + "a.departamento,a.precioproduccion from inv_vendedor i, articulos a, unidad_medida um where i.articulos_codigo=a.codigo and " +
                    "a.unidad_medida_id=um.id and i.empleados_id_empleado="+tbxVendedor.Text+" and "+
                    "i.articulos_codigo=" + tbxProducto.Text, ref tbl);
                    if (tbl.Rows.Count > 0)
                    {
                        DataRow row = tbl.Rows[0];
                        tbxNombre.Text = row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString();
                        tbxExistencias.Text = row[3].ToString();
                        Preciop = Convert.ToDouble(row[4]);
                        Comision = Convert.ToDouble(row[5]);
                        PrecioProduccion = Convert.ToDouble(row[7]);
                        if (row[6].ToString() == "1")
                        {
                            categoria = 7;
                        }
                        else if (row[6].ToString() == "2")
                        {
                            categoria = 6;
                        }
                        else
                        {
                            categoria = 10;
                        }
                    }
                    Conexion.Desconectarse();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {
            limpiarcampos();
        }
        public void limpiarcampos()
        {
            tbxVendedor.Clear();
            tbxNVendedor.Clear();
            tbxCCliente.Clear();
            tbxNCliente.Clear();
            tbxProducto.Clear();
            tbxNombre.Clear();
            tbxCantidad.Clear();
            tbxExistencias.Clear();
            dtgConsignacion.Rows.Clear();   
        }
        int indice = 0;
        public Boolean ProductoAgregado()
        {
            Boolean agregado = false;
            indice = 0;
            for (int i = 0; i < dtgConsignacion.Rows.Count-1; i++)
            {
                if (Convert.ToInt32(dtgConsignacion[11, i].Value) == 0 && dtgConsignacion[1, i].Value.ToString() == tbxProducto.Text)
                {
                    indice = i;
                    agregado = true;
                }
            }
                return agregado;
        }
        double PrecioTotal, TotalComision, TotalPagar;
        public void Totales()
        {
            PrecioTotal = 0; 
            TotalComision = 0; 
            TotalPagar = 0;
            for (int i = 0; i < dtgConsignacion.Rows.Count - 1; i++)
            {
                PrecioTotal += Convert.ToDouble(dtgConsignacion[6, i].Value);
                TotalComision += Convert.ToDouble(dtgConsignacion[7, i].Value);
                TotalPagar += Convert.ToDouble(dtgConsignacion[8, i].Value);
            }
            dtgConsignacion[6, dtgConsignacion.Rows.Count-1].Value = PrecioTotal;
            dtgConsignacion[7, dtgConsignacion.Rows.Count-1].Value = TotalComision;
            dtgConsignacion[8, dtgConsignacion.Rows.Count-1].Value = TotalPagar;
        }
        private void btnAC_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxCantidad.Text.Length > 0)
                {
                    if (tbxProducto.Text.Length > 0)
                    {
                        if (tbxCCliente.Text.Length > 0)
                        {
                            if (Convert.ToDouble(tbxCantidad.Text) <= Convert.ToDouble(tbxExistencias.Text))
                            {
                                if (!ProductoAgregado())
                                {
                                    dtgConsignacion.Rows.Insert(dtgConsignacion.Rows.Count - 1, false, tbxProducto.Text, tbxNombre.Text,
                                        tbxCantidad.Text, 0, Preciop, Convert.ToDouble(tbxCantidad.Text) * Preciop, (Convert.ToDouble(tbxCantidad.Text) * Preciop) * (Comision / 100), (Convert.ToDouble(tbxCantidad.Text) * Preciop) - (Convert.ToDouble(tbxCantidad.Text) * Preciop) * (Comision / 100), DateTime.Now.ToShortDateString(), 1, 0, Comision, categoria, PrecioProduccion);
                                }
                                else if ((Convert.ToDouble(dtgConsignacion[3, indice].Value) + Convert.ToDouble(tbxCantidad.Text))
                                    <= Convert.ToDouble(tbxExistencias.Text))
                                {
                                    dtgConsignacion[3, indice].Value = Convert.ToDouble(dtgConsignacion[3, indice].Value) +
                                        Convert.ToDouble(tbxCantidad.Text);
                                }
                                else
                                {
                                    MessageBox.Show("No puede agregar una cantidad mayor a las existencias del vendedor.");
                                }
                                tbxProducto.Clear();
                                tbxNombre.Clear();
                                tbxCantidad.Clear();
                                tbxExistencias.Clear();
                                tbxProducto.Focus();

                            }
                            else
                            {
                                MessageBox.Show("No puede agregar una cantidad mayor a las existencias del vendedor.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hace falta elegir un cliente.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Primero elija un producto.");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxCCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (dtgConsignacion.Rows.Count > 1)
                {
                    tbxAbono.Focus();
                }
                else
                {
                    tbxProducto.Focus();
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCCliente.Text = id.regresar.valXn;
                }
                tbxCCliente.Focus();
            }
        }

        private void tbxProducto_Leave(object sender, EventArgs e)
        {
            obtenerProductos();
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

        private void dtgConsignacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgConsignacion.CurrentCell.ColumnIndex == 4)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
               
            }
        }

        private void dtgConsignacion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dtgConsignacion_KeyPress);
        }

        private void dtgConsignacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgConsignacion.CurrentCell.ColumnIndex == 4)
                {
                    dtgConsignacion[4, e.RowIndex].Value = Convert.ToDouble(dtgConsignacion[4, e.RowIndex].Value);
                }
            }
            catch (Exception)
            {
                dtgConsignacion[4, e.RowIndex].Value = 0.00;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dtgConsignacion.Rows)
            {
                DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(celdaseleccionada.Value))
                    list.Add(row);
            }
            foreach (DataGridViewRow row in list)
            {
                dtgConsignacion.Rows.Remove(row);
            }
        }

        private void dtgConsignacion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (tbxAbono.Text == "")
            {
                if (dtgConsignacion.Rows.Count > 0)
                {
                    if (e.RowIndex < (dtgConsignacion.Rows.Count - 1))
                    {
                        if (Convert.ToDouble(dtgConsignacion[4, e.RowIndex].Value) <= Convert.ToDouble(dtgConsignacion[3, e.RowIndex].Value))
                        {
                            dtgConsignacion[6, e.RowIndex].Value = Convert.ToDouble(dtgConsignacion[4, e.RowIndex].Value) * Convert.ToDouble(dtgConsignacion[5, e.RowIndex].Value);
                            dtgConsignacion[7, e.RowIndex].Value = Convert.ToDouble(dtgConsignacion[12, e.RowIndex].Value) / 100 * Convert.ToDouble(dtgConsignacion[6, e.RowIndex].Value);
                            dtgConsignacion[8, e.RowIndex].Value = Convert.ToDouble(dtgConsignacion[6, e.RowIndex].Value) - Convert.ToDouble(dtgConsignacion[7, e.RowIndex].Value);

                        }
                        else
                        {
                            dtgConsignacion[4, e.RowIndex].Value = 0;
                        }
                    }
                    Totales();
                }
            }
        }
        Boolean evitar = false;
        //metodo para distribuir abono en diferentes adeudos.
        public void disAbono(double abono)
        {
            double resto = abono;
           // double resto = Convert.ToDouble(dtgConsignacion[8, dtgConsignacion.Rows.Count - 1].Value);
            for (int i = 0; i < dtgConsignacion.Rows.Count - 1; i++)
            {

                if (resto >= Convert.ToDouble(dtgConsignacion[8, i].Value))
                {
                    resto = resto - Convert.ToDouble(dtgConsignacion[8, i].Value);
                    dtgConsignacion[8, i].Value = 0;
                    // dtgConsignacion[7, i].Value = Convert.ToDouble(dtgConsignacion[5, i].Value) - Convert.ToDouble(dtgConsignacion[6, i].Value);
                }

                else if (resto > 0 && resto < Convert.ToDouble(dtgConsignacion[8, i].Value))
                {
                    dtgConsignacion[8, i].Value =Convert.ToDouble(dtgConsignacion[8, i].Value)- resto;
                    // dtgConsignacion[7, i].Value = Convert.ToDouble(dtgConsignacion[5, i].Value) - Convert.ToDouble(dtgConsignacion[6, i].Value);
                    resto = 0;
                }
                if(Convert.ToDouble(dtgConsignacion[8,i].Value)==0)
                {
                    dtgConsignacion[4, i].Value = dtgConsignacion[3, i].Value;
                }
                else
                {
                    if (((Convert.ToDouble(dtgConsignacion[7, i].Value) + Convert.ToDouble(dtgConsignacion[8, i].Value)) == Convert.ToDouble(dtgConsignacion[6, i].Value)))
                    {
                        dtgConsignacion[4, i].Value = 0;
                    }
                    else
                    {
                        double Com = (Convert.ToDouble(dtgConsignacion[7, i].Value) * 100) / Convert.ToDouble(dtgConsignacion[6, i].Value);
                        double PrecioA = 14-((Com / 100) * Convert.ToDouble(dtgConsignacion[5, i].Value));
                        string S = (Convert.ToDouble(dtgConsignacion[3, i].Value)-(Convert.ToDouble(dtgConsignacion[8, i].Value)) / PrecioA).ToString();
                        string[] S1 = S.Split('.');
                        if (S1.Length == 1)
                        {
                            dtgConsignacion[4, i].Value = S1[0];
                        }
                        else
                        {
                            MessageBox.Show("Solo puede hacer abonos equivalentes a articulos enteros");
                            obtenerCliente();
                            tbxAbono.Focus();
                        }
                  
                        
                       
                    }
                }
            }
            tbxAbono.Clear();
            Totales();
        }
        DialogResult result;
        private void btnRegistrarS_Click(object sender, EventArgs e)
        {
            try
            {
                result = MessageBox.Show("Se van a guardar los cambios de consignación ¿Desea continuar?", "Registrar consignación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Boolean bAllOk = false;
                    bAllOk = Conexion.Conectarse();
                    
                    Conexion.IniciarTransaccion();
                    int i = 0;
                    while (i < dtgConsignacion.Rows.Count - 1 && bAllOk)
                    {
                        if (bAllOk)
                        {
                            if (Convert.ToInt32(dtgConsignacion[11, i].Value) == 0)
                            {
                                double invVendedor = 0;
                                DataTable tbl = new DataTable();
                                Conexion.Ejecutar("SELECT Cantidad FROM inv_vendedor WHERE empleados_id_empleado=" +
                                    tbxVendedor.Text + " and articulos_codigo=" + Convert.ToInt32(dtgConsignacion[1, i].Value), ref tbl);
                                if (tbl.Rows.Count > 0)
                                {
                                    DataRow row = tbl.Rows[0];
                                    invVendedor = Convert.ToDouble(row["Cantidad"]);
                                }
                                bAllOk = Conexion.Ejecutar("UPDATE inv_vendedor SET cantidad=cantidad-" +
                                    Convert.ToDouble(dtgConsignacion[3, i].Value) + " WHERE empleados_id_empleado=" + tbxVendedor.Text +
                                    " and articulos_codigo=" + Convert.ToInt32(dtgConsignacion[1, i].Value));
                                if (bAllOk)
                                {
                                    bAllOk = Conexion.Ejecutar("INSERT INTO inv_clientes VALUES(null," +
                                        Convert.ToInt32(dtgConsignacion[1, i].Value) + "," + tbxCCliente.Text + "," +
                                        Convert.ToDouble(dtgConsignacion[3, i].Value) + "," + DateTime.Now.ToString("yyyyMMddHHmmss") + "," + Convert.ToDouble(dtgConsignacion[5, i].Value) + ")");
                                    if (bAllOk)
                                    {

                                        String cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                               " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                               " VALUES({0},{1},'{2}','{3}',{4},{5},{6},{7})",
                               Convert.ToInt32(dtgConsignacion[1, i].Value), Convert.ToDouble(dtgConsignacion[3, i].Value),
                               "Cons. " + tbxNCliente.Text, dtpFecha.Value.ToString("yyyyMMddHHmmss"),
                               invVendedor, invVendedor - Convert.ToDouble(dtgConsignacion[3, i].Value), tbxVendedor.Text, UsuarioID);
                                        bAllOk = Conexion.Ejecutar(cmd);

                                    }
                                }
                            }
                            if (bAllOk)
                            {
                                if (Convert.ToDouble(dtgConsignacion[4, i].Value) > 0)
                                {
                                    if (Convert.ToInt32(dtgConsignacion[11, i].Value) != 0)
                                    {
                                        bAllOk = Conexion.Ejecutar("UPDATE inv_clientes SET cantidad=cantidad-" +
                                                Convert.ToDouble(dtgConsignacion[4, i].Value) + " WHERE idinv_Abarrote=" +
                                            Convert.ToInt32(dtgConsignacion[11, i].Value));
                                    }
                                    else
                                    {
                                        DataTable tbl = new DataTable();
                                        Conexion.Ejecutar("select max(idinv_Abarrote) from inv_clientes", ref tbl);
                                        DataRow row = tbl.Rows[0];
                                        int id = Convert.ToInt32(row[0]);
                                        bAllOk = Conexion.Ejecutar("UPDATE inv_clientes SET cantidad=cantidad-" +
                                                Convert.ToDouble(dtgConsignacion[4, i].Value) + " WHERE idinv_Abarrote=" + id);
                                    }
                                    if (bAllOk)
                                    {

                                        bAllOk = Conexion.Ejecutar("INSERT INTO ventas VALUES(null," + tbxVendedor.Text + "," +
                                            tbxCCliente.Text + "," + Convert.ToInt32(dtgConsignacion[13, i].Value) + ","
                                            + Convert.ToInt32(dtgConsignacion[1, i].Value) + "," +
                                       Convert.ToDouble(dtgConsignacion[8, i].Value) / Convert.ToDouble(dtgConsignacion[4, i].Value)
                                            + "," + Convert.ToDouble(dtgConsignacion[4, i].Value) + "," +
                                            Convert.ToDouble(dtgConsignacion[8, i].Value) + "," +
                                            DateTime.Now.ToString("yyyyMMddHHmmss") + ",0," +
                                            Convert.ToDouble(dtgConsignacion[14, i].Value) + ",0,'consignacion',0,0,0)");
                                    }
                                }
                            }
                        }
                        i++;
                    }
                    Conexion.FinTransaccion(bAllOk);
                    Conexion.Desconectarse();
                    limpiarcampos();
                    refrescarTabla();
                    tbxVendedor.Focus();
                    MessageBox.Show("Datos guardados exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbxCantidad.Focus();
            }
            else if (e.KeyCode == Keys.F1)
            {
                if (tbxVendedor.Text.Length > 0 && tbxCCliente.Text.Length > 0)
                {
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
                    MessageBox.Show("Primero elija un vendedor y un cliente.");
                }
            }
        }
        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnAC.Focus();
            }
        }
        private void dtgConsignacion_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            if (e.RowIndex2 < dtgConsignacion.Rows.Count - 1 && e.RowIndex1 < dtgConsignacion.Rows.Count - 1)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "colCodigo" && e.RowIndex2 < dtgConsignacion.Rows.Count - 1 && e.RowIndex1 < dtgConsignacion.Rows.Count - 1)
            {
                // e.SortResult = dtgConsignacion.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgConsignacion.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgConsignacion.Rows[e.RowIndex1].Cells["colCodigo"].Value.ToString()),
                    Convert.ToInt32(dtgConsignacion.Rows[e.RowIndex2].Cells["colCodigo"].Value.ToString()));
            }
            if (e.Column.Name == "colDias" && e.RowIndex2 < dtgConsignacion.Rows.Count - 1 && e.RowIndex1 < dtgConsignacion.Rows.Count - 1)
            {
                // e.SortResult = dtgConsignacion.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgConsignacion.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToInt32(dtgConsignacion.Rows[e.RowIndex1].Cells["colDias"].Value.ToString()),
                    Convert.ToInt32(dtgConsignacion.Rows[e.RowIndex2].Cells["colDias"].Value.ToString()));
            }

            if (e.Column.Name == "colInvAbarrote" && e.RowIndex2 < dtgConsignacion.Rows.Count - 1 && e.RowIndex1 < dtgConsignacion.Rows.Count - 1)
            {
                // e.SortResult = dtgConsignacion.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgConsignacion.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex1].Cells["colInvAbarrote"].Value.ToString()),
                    Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex2].Cells["colInvAbarrote"].Value.ToString()));
            }
            if (e.Column.Name == "colUV" && e.RowIndex2 < dtgConsignacion.Rows.Count - 1 && e.RowIndex1 < dtgConsignacion.Rows.Count - 1)
            {
                // e.SortResult = dtgConsignacion.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgConsignacion.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex1].Cells["colUV"].Value.ToString()),
                    Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex2].Cells["colUV"].Value.ToString()));
            }
            if (e.Column.Name == "colPrecio" && e.RowIndex2 < dtgConsignacion.Rows.Count - 1 && e.RowIndex1 < dtgConsignacion.Rows.Count - 1)
            {
                // e.SortResult = dtgConsignacion.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgConsignacion.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex1].Cells["colPrecio"].Value.ToString()),
                    Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex2].Cells["colPrecio"].Value.ToString()));
            }
            if (e.Column.Name == "colprecioT" && e.RowIndex2 < dtgConsignacion.Rows.Count - 1 && e.RowIndex1 < dtgConsignacion.Rows.Count - 1)
            {
                // e.SortResult = dtgConsignacion.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgConsignacion.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex1].Cells["colprecioT"].Value.ToString()),
                    Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex2].Cells["colprecioT"].Value.ToString()));
            }
            if (e.Column.Name == "colComision" && e.RowIndex2 < dtgConsignacion.Rows.Count - 1 && e.RowIndex1 < dtgConsignacion.Rows.Count - 1)
            {
                // e.SortResult = dtgConsignacion.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgConsignacion.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex1].Cells["colComision"].Value.ToString()),
                    Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex2].Cells["colComision"].Value.ToString()));
            }
            if (e.Column.Name == "colPagar" && e.RowIndex2 < dtgConsignacion.Rows.Count - 1 && e.RowIndex1 < dtgConsignacion.Rows.Count - 1)
            {
                // e.SortResult = dtgConsignacion.Rows[e.RowIndex1].Cells["Codigo"].Value.ToString().CompareTo((object)(
                //  dtgConsignacion.Rows[e.RowIndex2].Cells["Codigo"].Value.ToString()));
                e.SortResult = comparar(Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex1].Cells["colPagar"].Value.ToString()),
                    Convert.ToDouble(dtgConsignacion.Rows[e.RowIndex2].Cells["colPagar"].Value.ToString()));
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
        DataTable ds;
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            dtgConsignacion[8, 0].Value = Convert.ToDouble(10);
            
        }

        private void dtgConsignacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Consignacion_Load(object sender, EventArgs e)
        {

        }

        private void tbxAbono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxAbono.Text != "")
                {
                    
                    disAbono(Convert.ToDouble(tbxAbono.Text));
                }
            }
        }

        private void tbxAbono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbxVendedor_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void tbxCCliente_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void tbxProducto_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void Consignacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (dtgConsignacion.Rows.Count > 1)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Saliendo de Consignación", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
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

    }
}
