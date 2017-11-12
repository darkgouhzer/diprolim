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
    public partial class VentasDLocal : Form
    {
        Inventarios.DBMS_Unico Conexion;
       
        int codigo = 0;
        int departamento;
        double precio = 0;
        double Precio2 = 0;
        double cantidad = 0;
        Double Cantidad = 0;
        double cantidadN = 0;
        double total2 = 0;
        string descripcion = "";
        string descripcion2 = "";
        double costo = 0;
        string UsuarioID = "";
        DialogResult result;
        public VentasDLocal(Inventarios.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
            fecha.Value = DateTime.Now;           
        }
        public VentasDLocal(string Id,Inventarios.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
            fecha.Value = DateTime.Now;
            UsuarioID = Id;
            desactivarcampos();

        }
        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarArticulos id = new BuscarArticulos();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxProducto.Text = id.regresar.valXn;
                obtenerProducto();
            }           
            tbxCantidad.ReadOnly = false;
            tbxCantidad.Focus();
        }
        
        public void obtenerProducto()
        {
            try
            {
                Conexion.Conectarse();
                DataTable tbl=new DataTable();
                string comando = String.Format("select a.descripcion, a.valor_medida, um.nombre,a.cantidad "
                +"from articulos a, unidad_medida um where a.unidad_medida_id=um.id and a.codigo={0}", tbxProducto.Text);
                Conexion.Ejecutar(comando, ref tbl);
                if (tbl.Rows.Count > 0)
                {
                    DataRow fila = tbl.Rows[0];

                    tbxNombre.Text = fila[0].ToString() + " " + fila[1].ToString() + fila[2].ToString();
                    tbxExistencia.Text = fila[3].ToString();

                }
                Conexion.Desconectarse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxProducto.Text != "")
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    obtenerProducto();
                    if (tbxProducto.Text != "" && tbxNombre.Text != "")
                    {
                        tbxCantidad.Enabled = true;
                        tbxCantidad.ReadOnly = false;
                        tbxCantidad.Focus();
                    }
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (Tabla.Rows.Count > 0 || tblCredito.Rows.Count > 0)
                    {
                        tbxEfectivo.Focus();
                    }
                }
            }
        }

        private void tbxUV_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxCantidad.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAC.Focus();
                }
            }
        }
        double suma;
        public void sumaTotal()
        {
            if (rbtContado.Checked)
            {
                suma = 0;
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    suma += Convert.ToDouble(Tabla[6, i].Value);
                }
               
                tbxEfectivo.Text = "";
                tbxCambio.Text = "";
                tbxSubtotal.Text = Math.Round(suma, 2).ToString();
                if (chbxIVa.Checked)
                {
                    suma = suma / 1.16;
                    tbxSubtotal.Text = Math.Round(suma, 2).ToString();
                    tbxIVA.Text = Math.Round(suma*.16, 2).ToString();
                    tbxTotal.Text = Math.Round(suma * 1.16, 2).ToString(); 
                }
                else
                {
                    tbxIVA.Text = "0";
                    tbxTotal.Text =Math.Round((suma + Convert.ToDouble(tbxIVA.Text)),2).ToString();
                }
                
            }
            else if (rbtCredito.Checked)
            {

                double total = 0, abono = 0, pendiente = 0, totaliva = 0;
                for (int i = 0; i < tblCredito.Rows.Count-1; i++)
                {
                    totaliva += (Convert.ToDouble(tblCredito[3, i].Value) * Convert.ToDouble(tblCredito[4, i].Value));
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

                tbxEfectivo.Text = "";
                tbxCambio.Text = "";
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
                    tbxTotal.Text = (totaliva + Convert.ToDouble(tbxIVA.Text)).ToString();
                }
               
            }
        }
        int Categoria = 9;
        public void SacarCategoria()
        {
            if (tbxCCliente.Text != "")
            {
                DataTable tbl = new DataTable();
                Conexion.Conectarse();
                Conexion.Ejecutar("select categorias_idcategorias from clientes where idclientes=" + tbxCCliente.Text, ref tbl);
                if (tbl.Rows.Count > 0)
                {
                    DataRow fila = tbl.Rows[0];
                    Categoria = Convert.ToInt32(fila[0]);
                }
                Conexion.Desconectarse();
            }
        }
        double descArticulo = 0;
        public Boolean aplicaDescuento()
        {
            int n = 0;
            DataTable tbl = new DataTable();
            Conexion.Conectarse();
            Conexion.Ejecutar("select * from clientes where DerechoADescuento=1 and idclientes=" + tbxCCliente.Text,ref tbl);
            n = tbl.Rows.Count;
            Conexion.Desconectarse();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnAC_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            string consulta = "";
            if (rbtContado.Checked)
            {
                #region contado
                String dP = "";
                descuento = 0;
                if (tbxCantidad.Text != "" && tbxProducto.Text != "")
                {
                    if (tbxCantidad.Text == ".")
                    {
                        MessageBox.Show("Verifica la cantidad");
                        tbxCantidad.Focus();
                    }
                    else
                    {
                        if ((Convert.ToDouble(tbxCantidad.Text)) > 0)
                        {
                            SacarCategoria();
                            string Categori = "";
                            if (rbtnGeneral.Checked)
                            {
                                Categori = " a.precio_calle";
                            }
                            else if (rbtnDistribuidor.Checked)
                            {
                                Categori = " a.precio_distribuidor";
                            }
                            else if (rbtnAbarrotes.Checked)
                            {
                                Categori = " a.precio_abarrotes";
                            }
                            
                            Conexion.Conectarse();
                            Conexion.Ejecutar("select a.codigo,a.descripcion, a.valor_medida, um.nombre,a.cantidad," + Categori + ", a.precioproduccion, a.departamento, a.Descuento " +
                                "from articulos a, unidad_medida um where a.unidad_medida_id=um.id and codigo=" + tbxProducto.Text, ref tbl);
                            if (tbl.Rows.Count > 0)
                            {
                                DataRow fila = tbl.Rows[0];
                                codigo = Convert.ToInt32(fila[0]);
                                descripcion = fila[1].ToString() + " " + fila[2] + " " + fila[3];
                                cantidad = Convert.ToDouble(fila[4]);
                                precio = Convert.ToDouble(fila[5]);
                                costo =Convert.ToDouble(fila[6]);
                                departamento = Convert.ToInt32(fila[7]);
                                descArticulo = Convert.ToDouble(fila[8]);
                                //verifica que no se agregue 2 articulos iguales
                                for (int i = 0; i < Tabla.Rows.Count; i++)
                                {
                                    if (Tabla[1, i].Value.ToString() == fila[0].ToString())
                                    {
                                        dP = Tabla[1, i].Value.ToString();
                                    }
                                }
                            }
                            Conexion.Desconectarse();
                            
                            if (rbtnGeneral.Checked)
                            {
                                idCategoria = 9;
                                
                            }
                            else if (rbtnDistribuidor.Checked)
                            {
                                idCategoria = 8;
                            }
                            else if (rbtnAbarrotes.Checked)
                            {
                                idCategoria = 7;
                               
                            }

                            if (dP != codigo.ToString())
                            {
                                if (departamento == 1)
                                {
                                    consulta = "Select Vendedor from categorias where idcategorias=" + idCategoria;
                                }
                                else if (departamento == 2)
                                {
                                    consulta ="Select Vendedor from categorias where idcategorias=6";
                                    idCategoria = 6;
                                }
                                else if (departamento == 3)
                                {
                                    consulta ="Select Vendedor from categorias where idcategorias=10";
                                    idCategoria = 10;
                                }                               
                                Conexion.Conectarse();
                                Conexion.Ejecutar(consulta, ref tbl);
                                DataRow fila = tbl.Rows[0];
                                comisionC = Convert.ToDouble(fila[0]) / 100;
                                Conexion.Desconectarse();
                                if (tbxCCliente.Text.Length > 0)
                                {
                                    if (aplicaDescuento())
                                    {
                                        descuento = Convert.ToDouble(tbxCantidad.Text) * precio * (descArticulo / 100);
                                    }
                                    else
                                    {
                                        descuento = 0;
                                    }
                                }
                                cantidadN = cantidad - (Convert.ToDouble(tbxCantidad.Text));
                                if (cantidadN >= 0)
                                {
                                    if (rbtnDistribuidor.Checked)
                                    {
                                        descuento = 0;
                                    }
                                    total2 = (precio * (Convert.ToDouble(tbxCantidad.Text)))-descuento;
                                    ComisionN = total2 * comisionC;
                                    Tabla.Rows.Add(false, codigo, descripcion, Convert.ToDouble(tbxCantidad.Text), precio, descuento, total2, costo, ComisionN, idCategoria, tbxExistencia.Text);
                                    tbxCantidad.Text = "";
                                    sumaTotal();
                                    tbxProducto.Clear();
                                    tbxNombre.Clear();
                                    tbxCantidad.Clear();
                                    tbxExistencia.Clear();
                                    tbxProducto.Focus();

                                }
                                else
                                {
                                    MessageBox.Show("No tiene suficiente en el inventario para realizar esa venta");
                                    tbxCantidad.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El articulo ya se encuentra en la lista");
                            }

                        }
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
                        idCategoria = 7;
                    }
                    else if (rbtnDistribuidor.Checked)
                    {
                        precio_cliente = "a.precio_distribuidor ";
                        idCategoria = 8;
                    }
                    else if (rbtnGeneral.Checked)
                    {
                        precio_cliente = "a.precio_calle ";
                        idCategoria = 9;
                    }
                    Conexion.Conectarse();
                    consulta = "SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre, a.cantidad," + precio_cliente
                        + ", a.precioproduccion, a.departamento FROM empleados e, articulos a, unidad_medida u" +
                            " WHERE  e.id_empleado =" + tbxVendedor.Text + " and a.codigo=" + tbxProducto.Text +
                            " AND a.unidad_medida_id = u.id" +
                            " order by a.codigo asc";
                    Conexion.Ejecutar(consulta, ref tbl);
                    if (tbl.Rows.Count > 0)
                    {
                        DataRow fila = tbl.Rows[0];
                        if (tbxCantidad.Text != "")
                        {
                            if (tbxCantidad.Text == ".")
                            {
                                MessageBox.Show("Verifica la cantidad de producto a agregar");
                                tbxCantidad.Focus();
                            }
                            else
                            {
                                double existVendedor = Convert.ToDouble(tbxExistencia.Text) - Convert.ToDouble(tbxCantidad.Text);
                                double total = Convert.ToDouble(fila[5]) * Convert.ToDouble(tbxCantidad.Text);
                                if (existVendedor >= 0)
                                {
                                    if (fila[7].ToString() == "2")
                                    {
                                        idCategoria = 6;
                                    }
                                    else if (fila[7].ToString() == "3")
                                    {
                                        idCategoria = 10;
                                    }
                                    tblCredito.Rows.Insert(tblCredito.Rows.Count - 1, false, fila[0].ToString(), fila[1].ToString() + " " +
                                        fila[2].ToString() + " " +fila[3].ToString(), Convert.ToDouble(tbxCantidad.Text), Convert.ToDouble(fila[5]), total, 0, total, tbxVendedor.Text, Convert.ToDouble(fila[6]), Convert.ToDouble(fila[4]), idCategoria);
                                    tbxProducto.Clear();
                                    tbxCantidad.Clear();
                                    tbxNombre.Clear();
                                    tbxExistencia.Clear();
                                    tbxProducto.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("El vendedor no tiene suficiente inventario.");
                                }
                            }
                        }
                    }
                    Conexion.Desconectarse();
                        tbxCantidad.Clear();
                }
                #endregion
                actImpuestos();
                sumaTotal();
            }
        }
        //Método que sirve para actualizar los impuestos de IVA a los productos.
        public void actImpuestos()
        {
            if (tblCredito.Rows.Count > 1 && rbtCredito.Checked)
            {
                for (int i = 0; i < tblCredito.Rows.Count - 1; i++)
                {
                    if (chbxIVa.Checked)
                    {
                        tblCredito[5, i].Value = Convert.ToDouble(tblCredito[3, i].Value) * Convert.ToDouble(tblCredito[4, i].Value) * 1.16;
                    }
                    else
                    {
                        tblCredito[5, i].Value = Convert.ToDouble(tblCredito[3, i].Value) * Convert.ToDouble(tblCredito[4, i].Value);
                    }
                }
            }
        }
        private void tbxEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxEfectivo.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
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
        private void tbxUV_KeyPress(object sender, KeyPressEventArgs e)
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
        public static Boolean aut = false;
        public Boolean AutorizacionCredito()
        {
            Boolean aceptado = false;
            double restoCredito=Convert.ToDouble(tbxCreditoRestante.Text)-Convert.ToDouble(tbxTotal.Text);
            if (restoCredito > 0)
            {
                aceptado = true;
            }
            else
            {
                MessageBox.Show("Ha sobrepasado el límite de crédito permitido, por lo que se requiere autorización especial.");
                Autorizaciones aut=new Autorizaciones("AutorizarCredito",Conexion);
                aut.ShowDialog();
                aceptado = VentasDLocal.aut;

            }
            return aceptado;
        }
        int cod_art = 0;
        double CCantidad = 0, existenciaA = 0, exitencia=0,descuento=0;
        string Operacion = "";
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Conexion.Conectarse();
            Boolean bAllOk = true;
            string consulta = "";
            double iva = 0;
            Conexion.IniciarTransaccion();
            if (tbxCambio.Text!="")
            {
                #region Sucursal
                if (rbtnSucursal.Checked)
                {
                    if (Tabla.Rows.Count > 0)
                    {
                        result = MessageBox.Show("Se va a registrar una venta ¿Desea continuar?", "Registrar venta", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            int i = 0;
                            while (i < Tabla.Rows.Count && bAllOk) 
                            {
                                cod_art = Convert.ToInt32(Tabla[1, i].Value);
                                descripcion2 = Tabla[2, i].Value.ToString();
                                Cantidad = Convert.ToDouble(Tabla[3, i].Value.ToString());
                                Precio2 = Convert.ToDouble(Tabla[4, i].Value.ToString());
                                exitencia = Convert.ToDouble(Tabla[10, i].Value);
                                existenciaA = (Convert.ToDouble(Tabla[10, i].Value) - Cantidad);
                                descuento = Convert.ToDouble(Tabla[5, i].Value.ToString());
                                total2 = Convert.ToDouble(Tabla[6, i].Value.ToString());
                                if (chbxIVa.Checked)
                                {
                                    iva = 0.16 * total2;
                                }
                                consulta = "INSERT INTO ventas (categorias_idcategorias,clientes_idclientes,empleados_id_empleado,articulos_codigo,precio_art,cantidad,importe,fecha_venta,costo_produccion,iva,Descuento)" +
                                                                " VALUES(" + Tabla[9, i].Value.ToString() + "," + 1 + "," + 1 + "," + Tabla[1, i].Value.ToString() + "," +
                                                                Precio2 + "," + Cantidad + "," + total2 + ",'" + fecha.Value.ToString("yyyyMMdd") + "'," + Tabla[7, i].Value.ToString() + "," + iva + "," + descuento + ")";
                                bAllOk = Conexion.Ejecutar(consulta);
                                if (bAllOk)
                                {
                                    consulta ="UPDATE articulos SET cantidad=cantidad-" + Cantidad + " where codigo=" + Tabla[1, i].Value.ToString();
                                    bAllOk = Conexion.Ejecutar(consulta);
                                    if (bAllOk)
                                    {
                                        Operacion = "Venta de Sucursal";
                                        bAllOk = InsertarHistoricoDMovimientos();
                                    }
                                }
                                
                                i++;
                            }
                            MessageBox.Show("Venta registrada con éxito.");
                            chbxIVa.Checked = false;
                            tbxExistencia.Clear();
                            tbxNombre.Clear();
                            tbxProducto.Clear();
                            tbxSubtotal.Clear();
                            tbxEfectivo.Clear();
                            tbxIVA.Clear();
                            tbxTotal.Clear();
                            tbxCambio.Clear();
                            Tabla.Rows.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para registrar una venta es necesario agregar productos.");
                    }
                }
                #endregion Sucursal
                else if (rbtnVendedor.Checked)
                {
                    #region contadoVendedor
                    if (rbtContado.Checked)
                    {
                        if (Tabla.Rows.Count > 0)
                        {
                            result = MessageBox.Show("Se va a registrar una venta ¿Desea continuar?", "Registrar venta", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                int i = 0;
                                while (i < Tabla.Rows.Count && bAllOk)
                                {
                                    cod_art = Convert.ToInt32(Tabla[1, i].Value);
                                    descripcion2 = Tabla[2, i].Value.ToString();
                                    Precio2 = Convert.ToDouble(Tabla[4, i].Value.ToString());
                                    Cantidad = Convert.ToDouble(Tabla[3, i].Value.ToString());
                                    exitencia = Convert.ToDouble(Tabla[10, i].Value);
                                    existenciaA = (Convert.ToDouble(Tabla[10, i].Value) - Cantidad);
                                    descuento = Convert.ToDouble(Tabla[5, i].Value.ToString());
                                    total2 = Convert.ToDouble(Tabla[6, i].Value.ToString());

                                    if (chbxIVa.Checked)
                                    {
                                        iva = 0.16 * total2;
                                    }
                                    consulta = "INSERT INTO ventas (categorias_idcategorias,clientes_idclientes,empleados_id_empleado,articulos_codigo,precio_art,cantidad,importe,fecha_venta,costo_produccion,comision,iva,Descuento)" +
                                                                    " VALUES(" + Tabla[9, i].Value.ToString() + "," + tbxCCliente.Text + "," + tbxVendedor.Text + "," + Tabla[1, i].Value.ToString() + "," + Precio2 + "," + Cantidad + "," + total2 + ",'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "'," + Tabla[7, i].Value.ToString() + "," + Tabla[8, i].Value.ToString() + "," + iva + "," + descuento + ")";
                                    bAllOk = Conexion.Ejecutar(consulta);
                                    if (bAllOk)
                                    {
                                        consulta = "UPDATE articulos SET cantidad=cantidad-" + Cantidad + " where codigo=" + Tabla[1, i].Value.ToString();
                                        bAllOk = Conexion.Ejecutar(consulta); 
                                        Operacion = "Venta de " + NOMBREVENDEDOR;
                                        if (bAllOk)
                                        {
                                            consulta = "INSERT INTO HistoricoDMovimientos  VALUES(null," + cod_art + "," + Cantidad + "," + existenciaA + ",'" + Operacion + "'," + UsuarioID + ",now()," + exitencia + ")";
                                            bAllOk = Conexion.Ejecutar(consulta);
                                        }
                                    }
                                    i++;
                                }                               
                                MessageBox.Show("Venta registrada con éxito.");
                                chbxIVa.Checked = false;
                                tbxExistencia.Clear();
                                tbxNombre.Clear();
                                tbxProducto.Clear();
                                tbxSubtotal.Clear();
                                tbxIVA.Clear();
                                tbxTotal.Clear();
                                tbxEfectivo.Clear();
                                tbxCambio.Clear();
                                Tabla.Rows.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Para registrar una venta es necesario agregar productos.");
                        }
                    }
                    #endregion contadoVendedor
                    else if (rbtCredito.Checked)
                    {
                        #region CreditoVendedor
                        if (tblCredito.Rows.Count > 1)
                        {
                            if (AutorizacionCredito())
                            {
                                result = MessageBox.Show("Se va registrar una venta a crédito ¿Desea continuar?", "Registro de venta a crédito", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    string Fechaa = fecha.Value.ToString("yyyyMMddHHmmss");
                                    int nuevoFolio = 0;
                                    DataTable tbl = new DataTable();
                                    bAllOk = Conexion.Ejecutar("insert into Folios_creditos values(null)");
                                    Conexion.Ejecutar("select max( idFolios_creditos )  from Folios_creditos order by idFolios_creditos desc", ref tbl);
                                    if (tbl.Rows.Count > 0)
                                    {
                                        DataRow fila = tbl.Rows[0];
                                        nuevoFolio = (Int32)fila[0];
                                    }
                                    else
                                    {
                                        nuevoFolio += 1;
                                    }
                                    int i = 0;
                                    while (i < tblCredito.Rows.Count - 1 && bAllOk)
                                    {
                                        cod_arti = tblCredito[1, i].Value.ToString();
                                        string inv_anterior = tblCredito[10, i].Value.ToString();
                                        string n_venta = tblCredito[3, i].Value.ToString();
                                        double costoP = Convert.ToDouble(tblCredito[9, i].Value);
                                        double precio_A = Convert.ToDouble(tblCredito[4, i].Value);
                                        string importe = (Convert.ToDouble(n_venta) * precio_A).ToString();
                                        string abono = tblCredito[6, i].Value.ToString();
                                        string pendiente = tblCredito[7, i].Value.ToString();
                                        existenciaA = (Convert.ToDouble(tblCredito[10, i].Value) - Convert.ToDouble(n_venta));
                                        double existencia = Convert.ToDouble(tblCredito[10, i].Value);

                                        if (Convert.ToDouble(n_venta) > 0)
                                        {
                                            consulta = "UPDATE articulos SET cantidad=cantidad-" + n_venta + " WHERE codigo=" + cod_arti;
                                            bAllOk = Conexion.Ejecutar(consulta);
                                            if (bAllOk)
                                            {
                                                consulta = "SELECT departamento FROM articulos WHERE codigo =" + cod_arti;
                                                Conexion.Ejecutar(consulta, ref tbl);
                                                if (tbl.Rows.Count > 0)
                                                {
                                                    DataRow row = tbl.Rows[0];
                                                    Depa = Convert.ToInt32(row[0]);
                                                }
                                                if (Depa != 1)
                                                {
                                                    string deptos = "";
                                                    if (Depa == 2) { deptos = "Accesorios"; }
                                                    if (Depa == 3) { deptos = "Papel"; }

                                                    consulta = "select Vendedor from categorias where nombre='" + deptos + "'";
                                                    Conexion.Ejecutar(consulta, ref tbl);
                                                    DataRow fila = tbl.Rows[0];
                                                    ComisionN = Convert.ToDouble(fila[0]);
                                                    comisionC = ComisionN;
                                                }
                                                if (tbxVendedor.Text == "1")
                                                {
                                                    comisionC = 0;
                                                }
                                                double comision = ((comisionC / 100) * Convert.ToDouble(abono));
                                                double ivac = 0;
                                                if (chbxIVa.Checked)
                                                {
                                                    ivac = 0.16 * Convert.ToDouble(importe);
                                                }
                                                consulta = string.Format("INSERT INTO ventas values(null,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},'credito',{11},{12},{13})", tbxVendedor.Text,
                                                                                                                                                                                idCliente,
                                                                                                                                                                                tblCredito[11, i].Value,
                                                                                                                                                                                cod_arti,
                                                                                                                                                                                precio_A,
                                                                                                                                                                                n_venta,
                                                                                                                                                                                importe,
                                                                                                                                                                                Fechaa,
                                                                                                                                                                                comision,
                                                                                                                                                                                costoP,
                                                                                                                                                                                ivac, 
                                                                                                                                                                                nuevoFolio,
                                                                                                                                                                                pendiente,
                                                                                                                                                                                0);

                                                //consulta = "INSERT INTO ventas values(null," + tbxVendedor.Text + "," + idCliente + "," + tblCredito[11, i].Value + "," + cod_arti + "," + precio_A + "," + n_venta + "," + importe + "," + Fechaa + "," + comision + "," + costoP + "," + ivac + ",'credito'," + nuevoFolio + "," + pendiente + ",0)";
                                                bAllOk = Conexion.Ejecutar(consulta);
                                                if (bAllOk)
                                                {
                                                    if (Convert.ToDouble(abono) > 0)
                                                    {
                                                        consulta = "INSERT INTO abonos values(null," + nuevoFolio + "," + cod_arti + "," + idCliente + "," + tbxVendedor.Text + "," + tblCredito[5, i].Value + "," + Convert.ToDouble(abono) + "," + pendiente + "," + Fechaa + ",LAST_INSERT_ID())";
                                                        bAllOk = Conexion.Ejecutar(consulta);
                                                    }
                                                    if (bAllOk)
                                                    {
                                                        Operacion = "Venta de " + NOMBREVENDEDOR;
                                                        consulta = "INSERT INTO HistoricoDMovimientos  VALUES(null," + cod_arti + "," + n_venta + "," + existenciaA + ",'" + Operacion + "'," + UsuarioID + ",now()," + existencia + ")";
                                                        bAllOk = Conexion.Ejecutar(consulta);
                                                    }
                                                }
                                            }
                                        }

                                        i++;
                                    }
                                    chbxIVa.Checked = false;

                                    MessageBox.Show("La venta a crédito ha sido registrada exitosamente");
                                    tbxExistencia.Clear();
                                    tbxNombre.Clear();
                                    tbxProducto.Clear();
                                    tbxSubtotal.Clear();
                                    tbxIVA.Clear();
                                    tbxTotal.Clear();
                                    tbxEfectivo.Clear();
                                    tbxCambio.Clear();
                                    tblCredito.Rows.Clear();
                                    tblCredito.Rows.Add(false, "-", "-", "-", "Total", 0, 0, 0, 0, 0, 0);
                                    tblCredito[0, tblCredito.Rows.Count - 1].ReadOnly = true;
                                    tblCredito.Rows[tblCredito.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Autorización cancelada.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Para registrar una venta es necesario agregar productos.");
                        }
                        #endregion CreditoVendedor
                    }
                }                
            }
            else
            {
                MessageBox.Show("Ingrese efectivo");
            }
            Conexion.FinalizarTransaccion(bAllOk);
            Conexion.Desconectarse();
            aut = false;
        }
        string cod_arti = "";
        int Depa = 0;
        public Boolean InsertarHistoricoDMovimientos()
        {
            string consulta = "INSERT INTO HistoricoDMovimientos  VALUES(null," + cod_art + "," + Cantidad + "," + existenciaA + ",'"+Operacion+"'," + UsuarioID + ",now()," + exitencia + ")";
            return Conexion.Ejecutar(consulta);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (rbtContado.Checked)
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
                sumaTotal();
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

        private void tbxEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxEfectivo.Text != "" && tbxTotal.Text != "")
                {
                    if (tbxEfectivo.Text == ".")
                    {
                        MessageBox.Show("Verifica el efectivo");
                        tbxEfectivo.Focus();
                    }
                    else
                    {
                        if (Convert.ToDouble(tbxEfectivo.Text) >= Convert.ToDouble(tbxTotal.Text))
                        {
                            tbxCambio.Text = (Convert.ToDouble(tbxEfectivo.Text) - Convert.ToDouble(tbxTotal.Text)).ToString();
                            btnRegistrar.Focus();
                        }
                        else
                        {
                            MessageBox.Show("El efectivo no es suficiente");
                            tbxEfectivo.Text = "";
                            tbxCambio.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El efectivo no es suficiente");
                    tbxEfectivo.Text = "";
                    tbxCambio.Text = "";
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("¿Desea realizar una nueva venta?", "Nueva venta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                tbxExistencia.Clear();
                Tabla.Rows.Clear();
                tblCredito.Rows.Clear();
                tbxProducto.Clear();
                tbxNombre.Clear();
                tbxCantidad.Clear();
                tbxSubtotal.Clear();
                tbxEfectivo.Clear();
                tbxCambio.Clear();
                btnRegistrar.Enabled = true;
                rbtnGeneral.Checked = true;
                tbxProducto.ReadOnly = false;
           
            }
        }
        public void desactivarcampos()
        {
            tbxVendedor.Enabled = false;
            tbxCCliente.Enabled = false;
            tbxNCliente.Enabled = false;
            tbxNCliente.Enabled = false;
            tbxNVendedor.Enabled = false;
            tbxTotal.Clear();
            tbxIVA.Clear();
            tbxVendedor.Clear();
            tbxCCliente.Clear();
            tbxNCliente.Clear();
            tbxNCliente.Clear();
            tbxNVendedor.Clear();
            tbxProducto.Clear();
            tbxNombre.Clear();
            tbxCantidad.Clear();
            tbxExistencia.Clear();
            tbxSubtotal.Clear();
            tbxEfectivo.Clear();
            tbxCambio.Clear();
            btnSV.Enabled = false;
            btnSC.Enabled = false;
            btnCambiarC.Enabled = false;
            btnCambiarVendedor.Enabled = false;
        }
        private void rbtnSucursal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSucursal.Checked)
            {
                idCategoria = 9;
                rbtnGeneral.Checked = true;
                desactivarcampos();
                tbxProducto.ReadOnly = false;
                tbxCantidad.ReadOnly = false;
                btnSP.Enabled = true;
                Tabla.Rows.Clear();
            }
            else if (rbtnVendedor.Checked)
            {
                inactivosVendedor();
                rbtContado.Enabled = true;
                rbtCredito.Enabled = true;
            }
        }
        public void limpiarTodo()
        {
            rbtContado.Checked = true;
            tbxVendedor.Enabled = true;
            tbxVendedor.ReadOnly = false;
            tbxCCliente.Enabled = true;
            tbxCCliente.ReadOnly = true;
            tbxNCliente.Enabled = true;
            tbxNCliente.Enabled = true;
            tbxNVendedor.Enabled = true;
            tbxIVA.Clear();
            tbxTotal.Clear();
            tbxVendedor.Clear();
            tbxCCliente.Clear();
            tbxNCliente.Clear();
            tbxNCliente.Clear();
            tbxNVendedor.Clear();
            tbxProducto.Clear();
            tbxNombre.Clear();
            tbxCantidad.Clear();
            tbxExistencia.Clear();
            tbxSubtotal.Clear();
            tbxEfectivo.Clear();
            tbxCambio.Clear();
            btnSV.Enabled = true;
            btnSC.Enabled = false;
            btnCambiarC.Enabled = true;
            btnCambiarVendedor.Enabled = true;
            btnSP.Enabled = false;
            tbxProducto.ReadOnly = true;
            tbxCantidad.ReadOnly = true;
            Tabla.Rows.Clear();
            tblCredito.Rows.Clear();
            tbxVendedor.Focus();
        }
        private void rbtnVendedor_CheckedChanged(object sender, EventArgs e)
        {
            rbtnGeneral.Checked = true;
            if (rbtnVendedor.Checked)
            {
                inactivosVendedor();
                rbtContado.Enabled = true;
                rbtCredito.Enabled = true;
                tbxVendedor.Focus();
                limpiarTodo();
                Tabla.Rows.Clear();
            }
            else if(rbtnSucursal.Checked)
            {
                idCategoria = 9;
                rbtnGeneral.Checked = true;
                desactivarcampos();
                tbxProducto.Focus();
                tbxProducto.ReadOnly = false;
                tbxCantidad.ReadOnly = false;
                btnSP.Enabled = true;                
                rbtContado.Checked = true;
                rbtContado.Enabled = false;
                rbtCredito.Enabled = false;
            }
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedor.Text = id.regresar.valXn;
                obtenerVendedor();
            }
            tbxVendedor.ReadOnly = true;
            btnSV.Enabled = false;
            tbxCCliente.ReadOnly = false;
            tbxCCliente.Focus();
            btnSC.Enabled = true;
                
        }

        private void btnSC_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCCliente.Text = id.regresar.valXn;
                ObtnerCliente();
                tbxCCliente.ReadOnly = true;
                btnSC.Enabled = false;
            }
            if (tbxCCliente.Text != ""&&tbxNCliente.Text!="")
            {
                tbxProducto.ReadOnly = false;
                tbxProducto.Focus();
                btnSP.Enabled = true;
            }
        }
        string NOMBREVENDEDOR = "";
        public void obtenerVendedor() {
            DataTable tbl = new DataTable();
            double credito = 0;
            Conexion.Conectarse();
            string consulta = "Select nombre, apellido_paterno, apellido_materno, limite_credito from empleados where id_empleado=" + tbxVendedor.Text;
            Conexion.Ejecutar(consulta,ref tbl);
            if (tbl.Rows.Count > 0)
            {
                DataRow row = tbl.Rows[0];
                NOMBREVENDEDOR = row[0].ToString();
                tbxNVendedor.Text = row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString();
                credito = Convert.ToDouble(row[3]);
                consulta = "select sum(pendiente) from ventas where pendiente>0 and empleados_id_empleado="+tbxVendedor.Text;
                Conexion.Ejecutar(consulta,ref tbl);
                if (tbl.Rows.Count > 0)
                {
                    row = tbl.Rows[0];
                    if (row[0].ToString() != "")
                    {

                        tbxCreditoRestante.Text = (credito - Convert.ToDouble(row[0])).ToString();
                    }
                    else
                    {
                        tbxCreditoRestante.Text = "" + credito;
                    }
                    
                }
                else
                {
                    tbxCreditoRestante.Text = "" + credito;
                }
            }
            else
            {
                tbxVendedor.Clear();
                tbxCreditoRestante.Clear();
            }
            Conexion.Desconectarse();
        }
        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxVendedor.Text != "")
                {
                    obtenerVendedor();
                    if (tbxVendedor.Text != "")
                    {
                        tbxVendedor.ReadOnly = true;
                        btnSV.Enabled = false;
                        tbxCCliente.Enabled = true;
                        tbxCCliente.ReadOnly = false;
                        btnSC.Enabled = true;
                        tbxCCliente.Focus();
                    }
                }
            }
        }
        int idCategoria = 9;
        int idCliente = 0;
        double comisionC = 0;
        double ComisionN = 0;
        public void ObtnerCliente()
        {
            Conexion.Conectarse();
            DataTable tbl = new DataTable();
            if (tbxCCliente.Text != "")
            {
                string consulta = "SELECT a.idclientes, a.nombre, a.categorias_idcategorias, u.Vendedor " +
                            "FROM clientes a, categorias u WHERE a.empleados_id_empleado="+tbxVendedor.Text+" and a.idclientes =" + tbxCCliente.Text + " and a.categorias_idcategorias=u.idcategorias";
                Conexion.Ejecutar(consulta,ref tbl);
                if (tbl.Rows.Count > 0)
                {
                    DataRow row = tbl.Rows[0];
                    idCliente = Convert.ToInt32(row[0]);
                    tbxNCliente.Text = row[1].ToString();
                    idCategoria = Convert.ToInt32(row[2]);
                    comisionC = Convert.ToInt32(row[3]);
                    tbxProducto.Enabled = true;
                    tbxProducto.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("Código de cliente incorrecto.");
                    tbxCCliente.Clear();
                    tbxNCliente.Clear();
                    tbxCCliente.Focus();
                } 
                Conexion.Desconectarse();
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
        private void tbxCCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ObtnerCliente();

                if (tbxCCliente.Text != "")
                {
                    tbxProducto.Focus();
                    tbxCCliente.ReadOnly = true;
                    btnSC.Enabled = false;
                    tbxProducto.ReadOnly = false;
                    btnSP.Enabled = true;
                }

            }
        }

        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        { 
            result = MessageBox.Show("¿Está seguro de cambiar de vendedor? Los cambios no guardados se perderán", "Cambio de vendedor", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {                
                limpiarTodo();
                
            }
        }

        private void btnCambiarC_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text.Length > 0)
            {
                result = MessageBox.Show("¿Está seguro de cambiar de cliente? Los cambios no guardados se perderán", "Cambio de cliente", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    tbxCCliente.Enabled = true;
                    tbxCCliente.ReadOnly = false;
                    tbxNCliente.Enabled = true;
                    tbxNCliente.Enabled = true;
                    tbxNVendedor.Enabled = true;
                    tbxCCliente.Clear();
                    tbxNCliente.Clear();
                    tbxNCliente.Clear();
                    tbxProducto.Clear();
                    tbxNombre.Clear();
                    tbxCantidad.Clear();
                    tbxExistencia.Clear();
                    Tabla.Rows.Clear();
                    tbxSubtotal.Clear();
                    tbxEfectivo.Clear();
                    tbxCambio.Clear();
                    btnSC.Enabled = true;
                    btnCambiarVendedor.Enabled = true;
                    tbxProducto.ReadOnly = true;
                    btnSP.Enabled = false;
                    tbxCantidad.ReadOnly = true;
                }
            }
            else
            {
                MessageBox.Show("Primero es necesario indicar un código de vendedor.");
            }
        }

        private void tbxProducto_Leave(object sender, EventArgs e)
        {
            if (tbxProducto.Text != "")
            {
                obtenerProducto();                   
            }
        }

        private void tbxVendedor_Leave(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "")
            {
                obtenerVendedor();
                if (tbxVendedor.Text != "")
                {
                    tbxVendedor.ReadOnly = true;
                    btnSV.Enabled = false;
                    tbxCCliente.Enabled = true;
                    tbxCCliente.ReadOnly = false;
                    tbxCCliente.Focus();
                    btnSC.Enabled = true;
                }
                else
                {
                    tbxVendedor.Enabled = true;
                    tbxVendedor.Focus();
                    MessageBox.Show("Código de vendedor no existente.");
                }
            }
        }

        private void tbxCCliente_Leave(object sender, EventArgs e)
        {            
        }

        public void inactivosVendedor()
        {
            tbxNombre.ReadOnly = true;
            tbxCantidad.ReadOnly = true;
            tbxCCliente.ReadOnly = true;
            tbxProducto.ReadOnly = true;
            btnSC.Enabled = false;
            btnSP.Enabled = false;

        }
        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void tbxCCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void btnReporteDiario_Click(object sender, EventArgs e)
        {
            if (rbtnSucursal.Checked)
            {
                ConsultaCancelaVentas rdv = new ConsultaCancelaVentas("1",true,Conexion,Convert.ToInt32(UsuarioID));
                rdv.ShowDialog();
            }
            else if (rbtnVendedor.Checked)
            {
                if (tbxVendedor.Text.Length > 0)
                {
                    ConsultaCancelaVentas rdv = new ConsultaCancelaVentas(tbxVendedor.Text, true, Conexion, Convert.ToInt32(UsuarioID));
                    rdv.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Primero indique un código de vendedor.");
                }

            }
        }

        private void rbtContado_CheckedChanged(object sender, EventArgs e)
        {
            tblCredito.Rows.Clear();
            Tabla.Rows.Clear();
            Tabla.Visible = true;
            tblCredito.Visible = false;
            tbxIVA.Clear();
            tbxSubtotal.Clear();
            tbxTotal.Clear();
            tbxEfectivo.Clear();
            tbxCambio.Clear();
            //rbtnDistribuidor.Enabled = true;
        }

        private void rbtCredito_CheckedChanged(object sender, EventArgs e)
        {
            tblCredito.Rows.Clear();
            tblCredito.Rows.Add(false, "-", "-", "-", "Total", 0, 0, 0, 0, 0, 0);
            tblCredito[0, tblCredito.Rows.Count - 1].ReadOnly = true;
            tblCredito.Rows[tblCredito.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
            Tabla.Rows.Clear();            
            tblCredito.Visible = true;
            Tabla.Visible = false;
            //rbtnDistribuidor.Enabled = false;
            //rbtnGeneral.Checked = true;
            tbxIVA.Clear();
            tbxSubtotal.Clear();
            tbxTotal.Clear();
            tbxEfectivo.Clear();
            tbxCambio.Clear();
        }

        private void tblCredito_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tblCredito.Rows[e.RowIndex].ErrorText = String.Empty;
            sumaTotal();
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
        int n;
        private void tblCredito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            n = 0;
            if (tblCredito.Rows.Count > 0)
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
                                tblCredito[7, e.RowIndex].Value = Convert.ToDouble(tblCredito[5, e.RowIndex].Value) - Convert.ToDouble(tblCredito[6, e.RowIndex].Value);

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
            }
            evitar = false;
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
        private void tblCredito_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(tblCredito_KeyPress);
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

        private void tblCredito_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            //if (e.RowIndex2 < tblCredito.Rows.Count - 1 && e.RowIndex1 < tblCredito.Rows.Count - 1)
            //{
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            //}

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "tblCrCodArt")
            {
                e.SortResult = comparar(Convert.ToInt32(tblCredito.Rows[e.RowIndex1].Cells["tblCrCodArt"].Value.ToString()),
                    Convert.ToInt32(tblCredito.Rows[e.RowIndex2].Cells["tblCrCodArt"].Value.ToString()));
            }
            if (e.Column.Name == "tblCrCantidad")
            {
                e.SortResult = comparar(Convert.ToDouble(tblCredito.Rows[e.RowIndex1].Cells["tblCrCantidad"].Value.ToString()),
                    Convert.ToDouble(tblCredito.Rows[e.RowIndex2].Cells["tblCrCantidad"].Value.ToString()));
            }

            if (e.Column.Name == "tblCrPrecio")
            {
                e.SortResult = comparar(Convert.ToDouble(tblCredito.Rows[e.RowIndex1].Cells["tblCrPrecio"].Value.ToString()),
                    Convert.ToDouble(tblCredito.Rows[e.RowIndex2].Cells["tblCrPrecio"].Value.ToString()));
            }

            if (e.Column.Name == "tblCrTotal")
            {
                e.SortResult = comparar(Convert.ToDouble(tblCredito.Rows[e.RowIndex1].Cells["tblCrTotal"].Value.ToString()),
                    Convert.ToDouble(tblCredito.Rows[e.RowIndex2].Cells["tblCrTotal"].Value.ToString()));
            }
            if (e.Column.Name == "tblCrAbono")
            {
                e.SortResult = comparar(Convert.ToDouble(tblCredito.Rows[e.RowIndex1].Cells["tblCrAbono"].Value.ToString()),
                    Convert.ToDouble(tblCredito.Rows[e.RowIndex2].Cells["tblCrAbono"].Value.ToString()));
            }
            if (e.Column.Name == "tblCrPendiente")
            {
                e.SortResult = comparar(Convert.ToDouble(tblCredito.Rows[e.RowIndex1].Cells["tblCrPendiente"].Value.ToString()),
                    Convert.ToDouble(tblCredito.Rows[e.RowIndex2].Cells["tblCrPendiente"].Value.ToString()));
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

        private void chbxIVa_CheckedChanged(object sender, EventArgs e)
        {
            if (Tabla.Rows.Count > 0 && rbtContado.Checked)
            {
                sumaTotal();
            }
            else if (tblCredito.Rows.Count > 0 && rbtCredito.Checked)
            {
                //actImpuestos();
                sumaTotal();
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
                    obtenerVendedor();
                }
                tbxVendedor.ReadOnly = true;
                btnSV.Enabled = false;
                tbxCCliente.ReadOnly = false;
                tbxCCliente.Focus();
                btnSC.Enabled = true;
            }
        }

        private void tbxCCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCCliente.Text = id.regresar.valXn;
                    ObtnerCliente();
                    tbxCCliente.ReadOnly = true;
                    btnSC.Enabled = false;
                }
                if (tbxCCliente.Text != "" && tbxNCliente.Text != "")
                {
                    tbxProducto.ReadOnly = false;
                    tbxProducto.Focus();
                    btnSP.Enabled = true;
                }
            }
        }

        private void tbxProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                BuscarArticulos id = new BuscarArticulos();
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxProducto.Text = id.regresar.valXn;
                    obtenerProducto();
                }
                tbxCantidad.ReadOnly = false;
                tbxCantidad.Focus();
            }
        }

        private void VentasDLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                if(Tabla.Rows.Count>0)
                {
                    DialogResult result = MessageBox.Show("Hay una venta sin finalizar ¿Aun así desea salir?", "Venta pendiente", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
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
}//eran 1698 lineas