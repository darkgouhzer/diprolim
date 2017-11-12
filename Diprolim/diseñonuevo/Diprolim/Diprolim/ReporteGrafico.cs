using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diprolim
{
    public partial class ReporteGrafico : Form
    {
        conexion conn = new conexion();
        MySqlCommand comando;
        MySqlConnection conectar;
        MySqlDataReader lector;
        public ReporteGrafico()
        {
            InitializeComponent();
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
            categorias();
            cbxDepto.SelectedIndex = 0;
        }
        public void categorias()
        {
            List<sourceUnidadesMedida> lista = new List<sourceUnidadesMedida>();
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand("select idcategorias, nombre from categorias where clase='a'", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            sourceUnidadesMedida datos = new sourceUnidadesMedida();
            datos.ID = 0;
            datos.nombre = "Todos";
            lista.Add(datos);

            while (lector.Read())
            {
                datos = new sourceUnidadesMedida();
                datos.ID = lector.GetInt32(0);
                datos.nombre = lector.GetString(1);
                lista.Add(datos);

            }
            conectar.Close();
            cbxCategoria.DataSource = lista;
            cbxCategoria.DisplayMember = "nombre";
            cbxCategoria.ValueMember = "ID";

        }
        string fechaG = "", vendedor = "", cliente = "", tipocliente = "", str_depto="";
        int x=0;
        private void btnGrafica_Click(object sender, EventArgs e)
        {
            chartGrafica.Series[0].Points.Clear();
            
            conectar = conn.ObtenerConexion();

            if (cbxDepto.Text == "Todos")
            {
                str_depto = "";
            }
            else if (cbxDepto.Text == "Productos")
            {
                str_depto = "a.departamento=1 and ";
            }
            else if (cbxDepto.Text == "Accesorios")
            {
                str_depto = "a.departamento=2 and ";
            }
            else if (cbxDepto.Text == "Papel")
            {
                str_depto = "a.departamento=3 and ";
            }

            if (cbxCategoria.Text != "Todos")
            {
                tipocliente = "v.categorias_idcategorias=" + cbxCategoria.SelectedValue + " and";
            }
            else
            {
                tipocliente = "";
            }
            if (rbtDia.Checked)
            {
                fechaG = "day(v.fecha_venta)";
            }
            else if (rbtSem.Checked)
            {
                fechaG = "week(v.fecha_venta)";
            }
            else if (rbtMes.Checked)
            {
                fechaG = "month(v.fecha_venta)";
            }
            else if (rbtAnio.Checked)
            {
                fechaG = "year(v.fecha_venta)";               
            }
            if (tbxVendedor.Text.Length > 0)
            {
                vendedor = "v.empleados_id_empleado=" + tbxVendedor.Text + " and";
            }
            else
            {
                vendedor = "";
                tbxNVendedor.Text = "";
            }

            if (tbxCliente.Text.Length > 0)
            {
                cliente = "v.clientes_idclientes="+tbxCliente.Text+" and";
            }
            else
            {
                cliente="";
                tbxNCliente.Text = "";
            }

            comando = new MySqlCommand("select sum(v.importe) as ganancias,v.fecha_venta, week(v.fecha_venta,6), day(v.fecha_venta) from ventas v, articulos a where "+str_depto+" "+tipocliente+" "+cliente+" "+vendedor+" v.fecha_venta BETWEEN '" +
             dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "' AND v.articulos_codigo=a.codigo group by " + fechaG + " order by v.fecha_venta asc;", conectar);
           
            DateTime fecha;
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                fecha = DateTime.Parse(lector.GetString(1));
                if (rbtDia.Checked)
                {
                    
                    chartGrafica.Series[0].Points.AddXY(fecha.Date.ToString("dd-MMMM-yyyy"), lector.GetDouble(0));
                }
                else if (rbtSem.Checked)
                {
                    chartGrafica.Series[0].Points.AddXY("Semana "+lector.GetString(2)+" de "+fecha.Date.ToString("MMMM") , lector.GetDouble(0));            
                }
                else if (rbtMes.Checked)
                {
                    chartGrafica.Series[0].Points.AddXY(fecha.Date.ToString("MMMM-yyyy"), lector.GetDouble(0));
                }
                else if (rbtAnio.Checked)
                {
                    chartGrafica.Series[0].Points.AddXY(fecha.Date.ToString("yyyy"), lector.GetDouble(0));
                }               
            }
            conectar.Close();
        }
        Boolean validacion;
        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoVendedor();
            }
        }
        public void MetodoVendedor()
        {
            validacion = false;

            if (tbxVendedor.Text.Length == 0)
            {
                
                    tbxCliente.Focus();
                
                tbxNVendedor.Text = "";
            }
            else
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
                            tbxNVendedor.Clear();
                            tbxVendedor.Clear();
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
                            tbxNVendedor.Text = lector.GetString(0).ToString() + " " + lector.GetString(1).ToString() + " " + lector.GetString(2).ToString();

                        }
                        conectar.Close();
                    }
                
                if (validacion)
                {
                   
                        tbxCliente.Focus();
                    
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
                MetodoCliente();
            }
        }
        public void MetodoCliente()
        {
            validacion = false;

            if (tbxCliente.Text.Length == 0)
            {
                
                    btnGrafica.Focus();
                
                tbxNCliente.Text = "";
            }
            else
            {
                
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("select count(*) from clientes where idclientes=" + tbxCliente.Text, conectar);
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
                            MessageBox.Show("Código de cliente no existe");
                            tbxNCliente.Clear();
                            tbxCliente.Clear();
                        }
                    }

                    conectar.Close();
                    if (validacion)
                    {

                        comando = new MySqlCommand("select nombre from clientes where idclientes=" + tbxCliente.Text, conectar);
                        conectar.Open();

                        lector = comando.ExecuteReader();

                        while (lector.Read())
                        {
                            tbxNCliente.Text = lector.GetString(0).ToString();

                        }
                        conectar.Close();
                    }
                
                if (validacion)
                {
                   
                        btnGrafica.Focus();
                    
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
            BuscarClientes id = new BuscarClientes("");
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCliente.Text = id.regresar.valXn;
            }
            tbxCliente.Focus();
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
            MetodoVendedor();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //Logotipo
            Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
            Rectangle destRect1 = new Rectangle(150, 40, 161, 45);
            GraphicsUnit units = GraphicsUnit.Pixel;
            e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);
            // Create and initialize print font 
            System.Drawing.Font printFont = new System.Drawing.Font("Arial", 16,FontStyle.Bold);
            // Create Rectangle structure, used to set the position of the chart Rectangle 
            Rectangle myRec = new Rectangle(100, 150, e.MarginBounds.Width, e.MarginBounds.Height);
            // Draw a line of text, followed by the chart, and then another line of text 
            e.Graphics.DrawString("REPORTE GRÁFICO DE VENTAS", printFont, Brushes.Black, e.MarginBounds.Width/2-100, 50);
            if (tbxNVendedor.Text.Length > 0)
            {
                e.Graphics.DrawString("Vendedor: " + tbxNVendedor.Text, new Font("Arial", 10), Brushes.Black, 100, 110);
            }
            if (tbxNCliente.Text.Length > 0)
            {
                e.Graphics.DrawString("Cliente: "+tbxNCliente.Text, new Font("Arial",10), Brushes.Black, 100, 130);
            }
            e.Graphics.DrawString("Fechas: " + dtpInicio.Value.ToString("dd/MMMM/yyyy")+" - "+dtpFin.Value.ToString("dd/MMMM/yyyy") , new Font("Arial", 10), Brushes.Black, e.MarginBounds.Width-200, 110);
            chartGrafica.Printing.PrintPaint(e.Graphics,myRec);
            //ev.Graphics.DrawString("Line after chart", printFont, Brushes.Black, 10, 200);
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printDocument1.DefaultPageSettings.Landscape = true;
         //   printDocument1.Print();
            printPreviewDialog1.ShowDialog();
        }
    }
}
