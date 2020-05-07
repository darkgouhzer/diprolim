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
    public partial class PedidosEspeciales : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        string ID = "";
        string Vendedor = "";
        public PedidosEspeciales()
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
        }
        public PedidosEspeciales(string id, string LIKE)
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            ID = id;
            Vendedor = LIKE;
            tbxVendedor.Text = Vendedor.ToString();
            obtenervendedor();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarArticulos id = new BuscarArticulos("Especial");
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxProducto.Text = id.regresar.valXn;
            }
            tbxProducto.Focus();
        }
        double Precio=0;
        public void obtenerProductos()
        {
            if (tbxProducto.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
               
                comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre, a.cantidad,a.precio_calle " +
                            "FROM articulos a, unidad_medida u WHERE (a.valor_medida>=4 or a.unidad_medida_id=7) and codigo =" + tbxProducto.Text + " and a.unidad_medida_id=u.id", conectar);
                conectar.Open();

                
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    tbxDisponible.Text = lector.GetString(4);
                    tbxNombre.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    des = lector.GetString(0);
                    Precio = lector.GetDouble(5);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de producto incorrecto.");
                    tbxProducto.Clear();
                    tbxNombre.Clear();
                    tbxProducto.Focus();
                    tbxDisponible.Clear();

                }
                else
                {
                    tbxCantidad.Focus();
                }
            }
        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxProducto.Text != "")
                {
                    obtenerProductos();
                }
            }
        }

        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxVendedor.Text != "")
                {
                    obtenervendedor();
                }
            }
        }
        public void obtenervendedor()
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("SELECT * from empleados where id_empleado=" + Vendedor, conectar);
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
                MessageBox.Show("Vendedor no existente.");
                tbxVendedor.Clear();
                tbxNVendedor.Clear();


            }
            else
            {
                tbxProducto.Focus();
                tbxVendedor.ReadOnly = true;
                btnSV.Enabled = false;
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

        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {
            tbxVendedor.Focus();
            tbxVendedor.ReadOnly = false;
            btnSV.Enabled = true;
            tbxVendedor.Clear();
            tbxNVendedor.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbxProducto.Focus();
            tbxProducto.ReadOnly = false;
            btnSP.Enabled = true;
            tbxProducto.Clear();
            tbxNombre.Clear();
            tbxDisponible.Clear();
            tbxCantidad.Clear();
        }

        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxCantidad.Text != ""&& tbxDisponible.Text!="")
                {
                    if (Convert.ToDouble(tbxCantidad.Text) <= (Convert.ToDouble(tbxDisponible.Text)))
                    {
                        btnAC.Focus();
                    }
                }
            }
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "" && tbxNVendedor.Text!=""&& tbxProducto.Text != ""&& tbxNombre.Text!="")
            {
                if (tbxCantidad.Text != ".")
                {
                    string dP = "";
                    //verifica que no se agregue 2 articulos iguales
                    for (int i = 0; i < tblPE.Rows.Count; i++)
                    {
                        if (tblPE[1, i].Value.ToString() == tbxProducto.Text)
                        {
                            dP = tblPE[1, i].Value.ToString();
                        }
                    }
                    if (dP == "")
                    {
                        if (Convert.ToDouble(tbxCantidad.Text) <= (Convert.ToDouble(tbxDisponible.Text)))
                        {
                            tblPE.Rows.Add(false, tbxProducto.Text, tbxNombre.Text, tbxCantidad.Text, Convert.ToDouble(tbxCantidad.Text) * Precio, tbxDisponible.Text);
                            suma();
                            tbxCantidad.Clear();
                            tbxProducto.Clear();
                            tbxNombre.Clear();
                            tbxDisponible.Clear();
                            tbxProducto.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Existencias insuficientes");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede agregar dos veces el mismo producto.");
                    }
                }
                else
                {
                    MessageBox.Show("Verifique bien la cantidad a agregar.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in tblPE.Rows)
            {
                DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(celdaseleccionada.Value))
                    list.Add(row);
            }
            foreach (DataGridViewRow row in list)
            {
                tblPE.Rows.Remove(row);
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

        recuperarCodigo _lis = new recuperarCodigo();
        public recuperarCodigo regresar
        {
            get
            {
                return (_lis);
            }
        }
        private void btnRegistrarS_Click(object sender, EventArgs e)
        {
            List<sourceUnidadesMedida> lis = new List<sourceUnidadesMedida>();
            sourceUnidadesMedida li = new sourceUnidadesMedida();
            double[,] arr=new double[tblPE.Rows.Count,2];
            for (int i = 0; i < tblPE.Rows.Count;i++)
            {
                arr[i,0]= Convert.ToDouble(tblPE[1, i].Value);
                arr[i, 1] = Convert.ToDouble(tblPE[3, i].Value);
                
            }
            
            this.DialogResult = DialogResult.OK;
            _lis.valLis = arr;
            MessageBox.Show("Productos agregados con éxito.");
            this.Close();
        }

        private void tbxVendedor_Leave(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "")
            {
                obtenervendedor();
            }
        }

        private void tbxProducto_Leave(object sender, EventArgs e)
        {
            if (tbxProducto.Text != "")
            {
                obtenerProductos();
            }
        }
        double sumatoria;
        public void suma()
        {
            sumatoria = 0;
            foreach (DataGridViewRow row in tblPE.Rows)
            {
                sumatoria += Convert.ToDouble(row.Cells[4].Value);
            }
            tbxTotal.Text = sumatoria.ToString();
        }
      
    }
}
