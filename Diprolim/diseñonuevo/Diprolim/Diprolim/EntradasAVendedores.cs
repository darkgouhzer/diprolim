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
    public partial class EntardasAVendedores : Form
    {
        Inventarios.DBMS_Unico Conexion;
        public string sIDUsuario="";
        public EntardasAVendedores(Inventarios.DBMS_Unico server)
        {
            InitializeComponent();
            Conexion = server;
            CargarFolio();
            dtpFecha.Value = DateTime.Now;
        }
        public int CargarFolio()
        {
            int Folio = 0;
            string inicial = "";
            DataTable Tabla = new DataTable();
            Conexion.Conectarse();
            Conexion.Ejecutar("select IdFolios from Folios_Entradas", ref Tabla);
            Conexion.Desconectarse();
            if (Tabla.Rows.Count > 0)
            {
                Folio = Convert.ToInt32(Tabla.Rows[Tabla.Rows.Count - 1][0])+1;
                Tabla.Rows.Clear();
            }

            Conexion.Conectarse();
            Conexion.Ejecutar("Select iniciales from almacenes where origen=true", ref Tabla);
            Conexion.Desconectarse();
            if (Tabla.Rows.Count > 0)
            {
                inicial = Tabla.Rows[0][0].ToString();
                Tabla.Rows.Clear();
            }

            if (Folio == 0)
            {
                Folio = 1;
            }
            tbxFolioDE.Text = inicial + "-" + Folio.ToString();
            return Folio;
        }

        private void tbxVendedor_Leave(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "")
            {
                MetodoVendedor();
            }
        }
        public void MetodoVendedor()
        {
            if (tbxVendedor.Text != "1")
            {
                obtenervendedor();

                if (tbxVendedor.Text != "")
                {
                    tbxProducto.Focus();
                }
            }
            else
            {
                tbxVendedor.Focus();
                tbxVendedor.Clear();
            }

        }

        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxVendedor_Leave(sender, e);
            }
        }
        string NOMBREVENDEDOR = "";
        public void obtenervendedor()
        {

            DataTable Tabla = new DataTable();
            Conexion.Conectarse();
            Conexion.Ejecutar("SELECT * from empleados where id_empleado=" + tbxVendedor.Text, ref Tabla);
            Conexion.Desconectarse();
            if (Tabla.Rows.Count > 0)
            {
                NOMBREVENDEDOR = Tabla.Rows[0][1].ToString();
                tbxNVendedor.Text = Tabla.Rows[0][1].ToString() + " " + Tabla.Rows[0][2].ToString() + " " + Tabla.Rows[0][3].ToString();

            }
            else
            {
                MessageBox.Show("Código de vendedor no existente.");
                tbxVendedor.Clear();
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
                    obtenervendedor();
                    //tbxVendedor.ReadOnly = true;
                    tbxProducto.Focus();
                }

            }
        }

        private void tbxProducto_KeyUp(object sender, KeyEventArgs e)
        {
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
        public void obtenerCantidad()
        {
            if (tbxProducto.Text != "")
            {
                DataTable Tabla = new DataTable();
                Conexion.Conectarse();
                Conexion.Ejecutar(" select cantidad from inv_vendedor where articulos_codigo=" + tbxProducto.Text + " and empleados_id_empleado=" + tbxVendedor.Text, ref Tabla);
                Conexion.Desconectarse();
                if (Tabla.Rows.Count > 0)
                {
                    tbxExistencias.Text = Tabla.Rows[0][0].ToString();
                  
                }
                else
                {
                    tbxProducto.Clear();
                    tbxNProducto.Clear();
                    MessageBox.Show("Articulo incorreco");
                    tbxExistencias.Clear();
                }
            
               
            }
        }
        public void MetodoProducto()
        {

            if (tbxVendedor.Text.Length > 0)
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



        }
        public void checarInventarioVendedor()
        {
            DataTable Tabla = new DataTable();
            Conexion.Conectarse();
            Conexion.Ejecutar("select count(*) from inv_vendedor where cantidad>0 and articulos_codigo=" + tbxProducto.Text + " and empleados_id_empleado=" + tbxVendedor.Text, ref Tabla);
            Conexion.Desconectarse();
            if (Tabla.Rows.Count == 0)
            {
                tbxProducto.Clear();
                tbxNProducto.Clear();
                MessageBox.Show("Articulo incorreco");
                tbxExistencias.Clear();
            }

        }
       
        public void ObtenerP()
        {
            if (tbxProducto.Text != "")
            {
                DataTable Tabla = new DataTable();
                Conexion.Conectarse();
                Conexion.Ejecutar(" SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre, a.cantidad " +
                        "FROM articulos a, unidad_medida u WHERE codigo =" + tbxProducto.Text + " and a.unidad_medida_id=u.id", ref Tabla);
                Conexion.Desconectarse();

                if (Tabla.Rows.Count > 0)
                {
                    tbxNProducto.Text = Tabla.Rows[0][1].ToString() + " " + Tabla.Rows[0][2].ToString() + " " + Tabla.Rows[0][3].ToString();
                   // tbxExistencias.Text = Tabla.Rows[0][4].ToString();
                    tbxCantidad.Focus();
                }
                else
                {
                    MessageBox.Show("Ese producto no existe");
                    tbxProducto.Clear();
                }
            }

        }

        private void tbxProducto_Leave(object sender, EventArgs e)
        {
            if (tbxProducto.Text != "")
            {
                MetodoProducto();
            }
        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxProducto_Leave(sender, e);
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

                        Tabla.Rows.Add(false, tbxProducto.Text, tbxNProducto.Text, tbxCantidad.Text, Convert.ToDouble(tbxExistencias.Text) + Convert.ToDouble(tbxCantidad.Text),tbxExistencias.Text);

                        tbxCantidad.Clear();
                        tbxProducto.Clear();
                        tbxNProducto.Clear();
                        tbxExistencias.Clear();
                        tbxProducto.Focus();
                    }


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

        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxCantidad.Text != "")
            {
                if (tbxCantidad.Text != ".")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        button1.Focus();
                    }
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
            // btnSV.Enabled = true;
        }
        DialogResult result;
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
                    Int32 vendedor = Convert.ToInt32(tbxVendedor.Text);

                    Boolean bAllOk = false;
                    Conexion.Conectarse();
                    Conexion.IniciarTransaccion();
                    for (int i = 0; i < Tabla.Rows.Count; i++)
                    {

                        DataTable tbl = new DataTable();
                        Int32 codigo = Convert.ToInt32(Tabla[1, i].Value.ToString());
                        double cantidad = Convert.ToDouble(Tabla[3, i].Value.ToString());
                        double total2 = Convert.ToDouble(Tabla[4, i].Value.ToString());
                        double CantidadInicial = Convert.ToDouble(Tabla[5, i].Value.ToString());
                        DateTime FechaCon = Convert.ToDateTime(Tabla[6, i].Value);
                       // double CantVendedorIni = Convert.ToDouble(Tabla[7, i].Value);
                        
                        bAllOk = Conexion.Ejecutar("UPDATE inv_vendedor SET cantidad=cantidad+" + cantidad + " WHERE empleados_id_empleado=" + tbxVendedor.Text + " AND articulos_codigo=" + codigo);

                       
                          //bAllOk = Conexion.Ejecutar("UPDATE articulos SET cantidad=cantidad+" + cantidad + " where codigo=" + codigo);
                          bAllOk = Conexion.Ejecutar("INSERT INTO entradasDP (fecha,cantidad,articulos_codigo,Motivo,Comentarios,empleados_id_empleado,folio)" +
                                                        "VALUES('" + dtpFecha.Value.ToString("yyyyMMdd") + "'," + cantidad + "," + codigo + ",'Entrada a vendedores','" + tbxComentarios.Text + "'," + vendedor + ",'" + tbxFolioDE.Text + "') ");





                           
                           string  cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                                    " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                                    " VALUES({0},{1},'{2}','{3}',{4},{5},{6},{7})",
                                    codigo, cantidad, "Entrada a vendedores", dtpFecha.Value.ToString("yyyyMMddHHmmss"),
                                    CantidadInicial, total2, tbxVendedor.Text, sIDUsuario);
                           bAllOk = Conexion.Ejecutar(cmd);
                             
                           bAllOk = Conexion.Ejecutar("INSERT INTO salidas values(null," + cantidad + "," +
                                    dtpFecha.Value.ToString("yyyyMMdd") + "," + tbxVendedor.Text + "," + codigo + "," +
                                    total2 + ",'Entrada a vendedor','" + tbxComentarios.Text + "',null)");
                           bAllOk= Conexion.Ejecutar("INSERT INTO Folios_Entradas values(null)");
                       
                    }
                    Conexion.FinalizarTransaccion(bAllOk);
                    Conexion.Desconectarse();
                    tbxProducto.Clear();
                    tbxVendedor.Clear();
                    tbxCantidad.Clear();
                    tbxExistencias.Clear();
                    tbxNProducto.Clear();
                    tbxComentarios.Clear();
                    tbxVendedor.ReadOnly = false;
                    //btnSV.Enabled = true;
                    CargarFolio();
                    Tabla.Rows.Clear();

                    tbxNVendedor.Clear();
                    MessageBox.Show("Entrada guardada con éxito.");
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
    }
}


