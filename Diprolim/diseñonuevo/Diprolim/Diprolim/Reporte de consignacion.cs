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
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace Diprolim
{
    public partial class Reporte_de_consignacion : Form
    {
        conexion conn = new conexion();
        Inventarios.DBMS_Unico Conexion;
        double TotalDComision = 0;
        double TotalPrecioTotal = 0;
        public Reporte_de_consignacion(Inventarios.DBMS_Unico server)
        {
            InitializeComponent();
            cbxIm.SelectedIndex = 0;
            cbxDias.SelectedIndex = 0;
            Conexion = server;
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            if (rdbVendedor.Checked == true)
            {
                BuscarVendedor id = new BuscarVendedor();
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCodigo.Text = id.regresar.valXn;
                }
                obtenerVendedor();
                btnReporteHistorial.Focus();
            }
            else if (rdbCLiente.Checked == true)
            {
                string S = "";
                BuscarClientes id = new BuscarClientes(S);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCodigo.Text = id.regresar.valXn;
                }
                ObtnerCliente();
                btnReporteHistorial.Focus();
            }
        }

        private void rdbSucursal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSucursal.Checked == true)
            {
                tbxCodigo.Enabled = false;
                tbxCodigo.Clear();
                tbxNombre.Enabled = false;
                tbxNombre.Clear();
                btnSV.Enabled = false;
                dtgConsignacion.Rows.Clear();
            }
        }

        private void rdbCLiente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCLiente.Checked == true)
            {
                tbxCodigo.Enabled = true;
                tbxCodigo.Clear();
                tbxNombre.Enabled = true;
                tbxNombre.Clear();
                btnSV.Enabled = true;
                dtgConsignacion.Rows.Clear();
            }
        }

        private void rdbVendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVendedor.Checked == true)
            {
                tbxCodigo.Enabled = true;
                tbxCodigo.Clear();
                tbxNombre.Enabled = true;
                tbxNombre.Clear();
                btnSV.Enabled = true;
                dtgConsignacion.Rows.Clear();
            }

        }
        Boolean ChecarBien()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select Cantidad from inv_Clientes where clientes_idclientes=" + Cod_Cliente, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            double cantidad = 0;
            while (lector.Read())
            {
                cantidad += lector.GetDouble(0);
            }
            conectar.Close();
            if (cantidad > 0)
            {
                return true;
            }
            else { return false; }
        }
        int cont = 0;
        Boolean ChecarBien2()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select idclientes from clientes where empleados_id_empleado=" + Cod_Vendedor, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            cont = 0;
            while (lector.Read())
            {
                Cod_Cliente = lector.GetInt32(0);
                ChecarBien3();
            }
            conectar.Close();
            if (cont > 0)
            {
                return true;
            }
            else { return false; }
        }
        public void ChecarBien3()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select Cantidad from inv_Clientes where clientes_idclientes=" + Cod_Cliente, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            double Cantiades = 0;
            while (lector.Read())
            {
                Cantiades += lector.GetDouble(0);
            }
            conectar.Close();
            if (Cantiades > 0)
            {
                cont++;
            }
        }
        int contador = 0, contador2 = 0;

        private void btnReporteHistorial_Click(object sender, EventArgs e)
        {
            if (cbxDias.Text == "Todos")
            {
                if (cbxIm.Text == "Todo")
                {
                    cbxIm.Enabled = true;
                    dtgConsignacion.Visible = true;
                    dtgConsignacion2.Visible = false;
                    dataGridView1.Visible = false;
                    dtgConsignacion.Rows.Clear();
                    dtgConsignacion2.Rows.Clear();
                    dataGridView1.Rows.Clear();
                    if (rdbSucursal.Checked == true)
                    {
                        TotalDTodo = 0;
                        TotalPrecioTotal = 0;
                        TotalDComision = 0;
                        BuscarEmpleados();
                    }
                    else if (rdbVendedor.Checked == true)
                    {
                        if (tbxCodigo.Text != "")
                        {
                            BuscarEmpleadosPorCodigo();
                        }
                        else
                        {
                            MessageBox.Show("Inserte código");
                        }
                    }
                    else if (rdbCLiente.Checked == true)
                    {
                        BuscarClientesPorCodigo();
                    }
                }
                else
                {
                    dtgConsignacion.Visible = false;
                    dtgConsignacion2.Visible = true;
                    dataGridView1.Visible = false;
                    dtgConsignacion.Rows.Clear();
                    dtgConsignacion2.Rows.Clear();
                    dataGridView1.Rows.Clear();
                    if (rdbSucursal.Checked == true)
                    {
                        BuscarEmpleados2();
                    }
                    else if (rdbVendedor.Checked == true)
                    {
                        if (tbxCodigo.Text != "")
                        {
                            BuscarEmpleadosPorCodigo2();
                        }
                        else
                        {
                            MessageBox.Show("Inserte código de vendedor");
                        }
                    }
                    else if (rdbCLiente.Checked == true)
                    {
                        BuscarClientesPorCodigo2();
                    }
                }
            }
            else
            {
                if (tbxCodigo.Text != ""||rdbSucursal.Checked==true)
                {
                    cbxIm.Enabled = false;
                    dtgConsignacion.Visible = false;
                    dtgConsignacion2.Visible = false;
                    dataGridView1.Visible = true;
                    dtgConsignacion.Rows.Clear();
                    dtgConsignacion2.Rows.Clear();
                    dataGridView1.Rows.Clear();

                    string MasWhere = "";
                    if (rdbVendedor.Checked == true)
                    {
                        MasWhere = " AND c.empleados_id_empleado=" + tbxCodigo.Text;
                    }
                    else if (rdbCLiente.Checked == true)
                    {
                        MasWhere = " AND inv.clientes_idclientes=" + tbxCodigo.Text;
                    }
                    else if (rdbSucursal.Checked == true)
                    {
                        MasWhere = "";
                    }
                    DataTable Tabla = new DataTable();
                    Conexion.Conectarse();
                    Conexion.Ejecutar("SELECT inv.idinv_Abarrote,inv.Fecha, e.nombre, c.nombre, inv.clientes_idclientes FROM empleados e, clientes c, inv_clientes inv WHERE c.idclientes=inv.clientes_idclientes AND inv.Cantidad>0 AND " +
                                      " e.id_empleado=c.empleados_id_empleado " + MasWhere, ref Tabla);
                    Conexion.Desconectarse();
                    if (Tabla.Rows.Count > 0)
                    {
                        for (int i = 0; i < Tabla.Rows.Count; i++)
                        {

                            if (cbxDias.Text == "Todos")
                            {

                                DateTime fecha = Convert.ToDateTime(Tabla.Rows[i][1]);
                                TimeSpan ts;

                                ts = DateTime.Now.AddDays(1) - fecha;
                                if (VerivicarCliente(Tabla.Rows[i][4].ToString(), fecha))
                                {
                                    dataGridView1.Rows.Add(Tabla.Rows[i][2].ToString(), Tabla.Rows[i][3].ToString(), ts.Days, Tabla.Rows[i][4].ToString(), fecha);

                                }


                            }
                            else if (cbxDias.Text == "Días mayor que")
                            {
                                DateTime fecha = Convert.ToDateTime(Tabla.Rows[i][1]);
                                TimeSpan ts;
                                ts = DateTime.Now.AddDays(1) - fecha;

                                if (tbxDias.Text == "")
                                {
                                    tbxDias.Text = "0";
                                }
                                if (ts.Days > Convert.ToInt32(tbxDias.Text) + 1)
                                {
                                    if (VerivicarCliente(Tabla.Rows[i][4].ToString(), fecha))
                                    {
                                        dataGridView1.Rows.Add(Tabla.Rows[i][2].ToString(), Tabla.Rows[i][3].ToString(), ts.Days, Tabla.Rows[i][4].ToString(), fecha);

                                    }

                                }

                            }
                            else if (cbxDias.Text == "Días menor que")
                            {
                                DateTime fecha = Convert.ToDateTime(Tabla.Rows[i][1]);
                                TimeSpan ts;
                                ts = DateTime.Now.AddDays(1) - fecha;

                                if (tbxDias.Text == "")
                                {
                                    tbxDias.Text = "0";
                                }
                                if (ts.Days < Convert.ToInt32(tbxDias.Text) + 1)
                                {
                                    if (VerivicarCliente(Tabla.Rows[i][4].ToString(), fecha))
                                    {
                                        dataGridView1.Rows.Add(Tabla.Rows[i][2].ToString(), Tabla.Rows[i][3].ToString(), ts.Days, Tabla.Rows[i][4].ToString(), fecha);

                                    }

                                }

                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Inserte código");
                }
            }
        }
        int Cod_Vendedor = 0, Cod_Cliente = 0;
        double PrecioTotal = 0, Comision = 0, Pendientee = 0;
        public void BuscarEmpleados()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from empleados", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cod_Vendedor = lector.GetInt32(0);
                if (Cod_Vendedor != 1)
                {
                    if (ChecarBien2())
                    {
                        if (Cod_Vendedor != 1)
                        {
                            dtgConsignacion.Rows.Add(Cod_Vendedor, lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), "Vendedor", "", "", "", "", "", "");
                        }
                        BuscarClientes();


                    }
                }
            }
            dtgConsignacion.Rows.Add(" ", " ", " ", "Total general:", TotalPrecioTotal, TotalDComision, TotalDTodo, "", "", false, true);
            conectar.Close();
        }
        public bool VerivicarCliente(string IdClienteV,DateTime FechaaV)
        {
            Boolean resssss = false;
            if(dataGridView1.Rows.Count>0)
            {
                for(int i = 0;i<dataGridView1.Rows.Count;i++)
                {
                    string id = dataGridView1[3, i].Value.ToString();
                    DateTime FechaV = Convert.ToDateTime(dataGridView1[4, i].Value);
                    if(id == IdClienteV&&FechaaV.ToString("dd/MM/yyyy")==FechaV.ToString("dd/MM/yyyy"))
                    {
                        resssss = false;
                    }
                    else
                    {
                        resssss = true;
                    }
                }
            }
            else
            {
                resssss = true;
            }
            return resssss;
        }
        public void BuscarEmpleadosPorCodigo()
        {

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from empleados WHERE id_empleado=" + tbxCodigo.Text, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {

                if (tbxCodigo.Text != "1")
                {
                    Cod_Vendedor = Convert.ToInt32(tbxCodigo.Text);
                    if (ChecarBien2())
                    {
                        dtgConsignacion.Rows.Add(tbxCodigo.Text, lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), "Vendedor", "", "", "", "", "", "");
                        BuscarClientes();

                    }
                }
            }
            conectar.Close();


        }
        int CodigoC = 0;
        public void BuscarClientes()
        {
            if (rdbVendedor.Checked == true)
            {
                CodigoC = Convert.ToInt32(tbxCodigo.Text);
            }
            else
            {
                CodigoC = Cod_Vendedor;
            }
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from clientes where empleados_id_empleado=" + CodigoC, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cod_Cliente = lector.GetInt32(0);
                if (ChecarBien())
                {
                    if (Cod_Cliente != 1)
                    {
                        dtgConsignacion.Rows.Add(Cod_Cliente, lector.GetString(1), "Cliente", "", "", "", "", "", "");
                    }

                    BuscarInvCliente();

                }

            }
            conectar.Close();
        }
        public void BuscarClientesPorCodigo()
        {
            if (tbxCodigo.Text.Length > 0)
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("select * from clientes where idclientes=" + tbxCodigo.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Cod_Cliente = lector.GetInt32(0);
                    if (Cod_Cliente != 1)
                    {
                        dtgConsignacion.Rows.Add(Cod_Cliente, lector.GetString(1), "Cliente", "", "", "", "", "", "");
                    }

                    BuscarInvCliente();
                    if (contador == 0)
                    {

                    }

                }
                conectar.Close();
            }
            else
            {
                MessageBox.Show("Agregue un código de clientes");
            }
        }
        Boolean Pasar = false;
        public void BuscarInvCliente()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            //comando = new MySqlCommand("select * from inv_Clientes where clientes_idclientes=" + Cod_Cliente, conectar);
            comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre," +
                          " i.cantidad,i.precio,a.comision,i.fecha From articulos a, unidad_medida u, inv_clientes i" +
                          " WHERE  i.cantidad>0 and clientes_idclientes=" + Cod_Cliente +
                          " and i.articulos_codigo=a.codigo AND a.unidad_medida_id = u.id" +
                          " order by i.fecha asc", conectar);
            // i.fecha BETWEEN '" +
            //dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "' and
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                if (cbxDias.Text == "Todos")
                {
                    TimeSpan ts;
                    DateTime fecha = Convert.ToDateTime(lector.GetString(7));
                    ts = DateTime.Now.AddDays(1) - fecha;

                    PrecioTotal += lector.GetDouble(4) * lector.GetDouble(5);
                    Comision += ((lector.GetDouble(4) * lector.GetDouble(5)) * (lector.GetDouble(6) / 100));
                    Pendientee += (lector.GetDouble(4) * lector.GetDouble(5)) - (((lector.GetDouble(4) * lector.GetDouble(5)) * (lector.GetDouble(6) / 100)));
                    dtgConsignacion.Rows.Add(lector.GetInt32(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), lector.GetDouble(4), lector.GetDouble(5), lector.GetDouble(4) * lector.GetDouble(5), (((lector.GetDouble(4) * lector.GetDouble(5))) * (lector.GetDouble(6) / 100)), (lector.GetDouble(4) * lector.GetDouble(5)) - (((lector.GetDouble(4) * lector.GetDouble(5)) * (lector.GetDouble(6) / 100))), Convert.ToDateTime(lector.GetString(7)).ToString("dd/MM/yyyy"), ts.Days);
                    contador++;
                }
                else if (cbxDias.Text == "Días mayor que")
                {

                    // DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);

                    TimeSpan ts;
                    DateTime fecha = Convert.ToDateTime(lector.GetString(7));
                    ts = DateTime.Now.AddDays(1) - fecha;

                    PrecioTotal += lector.GetDouble(4) * lector.GetDouble(5);
                    Comision += ((lector.GetDouble(4) * lector.GetDouble(5)) * (lector.GetDouble(6) / 100));
                    Pendientee += (lector.GetDouble(4) * lector.GetDouble(5)) - (((lector.GetDouble(4) * lector.GetDouble(5)) * (lector.GetDouble(6) / 100)));

                    if (tbxDias.Text == "")
                    {
                        tbxDias.Text = "0";
                    }
                    if (ts.Days > Convert.ToInt32(tbxDias.Text) + 1)
                    {
                        dtgConsignacion.Rows.Add(lector.GetInt32(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), lector.GetDouble(4), lector.GetDouble(5), lector.GetDouble(4) * lector.GetDouble(5), (((lector.GetDouble(4) * lector.GetDouble(5))) * (lector.GetDouble(6) / 100)), (lector.GetDouble(4) * lector.GetDouble(5)) - (((lector.GetDouble(4) * lector.GetDouble(5)) * (lector.GetDouble(6) / 100))), Convert.ToDateTime(lector.GetString(7)).ToString("dd/MM/yyyy"), ts.Days);

                    }
                    contador++;
                }
                else if (cbxDias.Text == "Días menor que")
                {

                    // DateTime fecha = Convert.ToDateTime(Tabla.Rows[0][3]);

                    TimeSpan ts;
                    DateTime fecha = Convert.ToDateTime(lector.GetString(7));
                    ts = DateTime.Now.AddDays(1) - fecha;

                    PrecioTotal += lector.GetDouble(4) * lector.GetDouble(5);
                    Comision += ((lector.GetDouble(4) * lector.GetDouble(5)) * (lector.GetDouble(6) / 100));
                    Pendientee += (lector.GetDouble(4) * lector.GetDouble(5)) - (((lector.GetDouble(4) * lector.GetDouble(5)) * (lector.GetDouble(6) / 100)));

                    if (tbxDias.Text == "")
                    {
                        tbxDias.Text = "0";
                    }
                    if (ts.Days < Convert.ToInt32(tbxDias.Text) + 1)
                    {
                        dtgConsignacion.Rows.Add(lector.GetInt32(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), lector.GetDouble(4), lector.GetDouble(5), lector.GetDouble(4) * lector.GetDouble(5), (((lector.GetDouble(4) * lector.GetDouble(5))) * (lector.GetDouble(6) / 100)), (lector.GetDouble(4) * lector.GetDouble(5)) - (((lector.GetDouble(4) * lector.GetDouble(5)) * (lector.GetDouble(6) / 100))), Convert.ToDateTime(lector.GetString(7)).ToString("dd/MM/yyyy"), ts.Days);

                    }
                    contador++;

                }


            }
            conectar.Close();
            if (Cod_Cliente != 1)
            {
                dtgConsignacion.Rows.Add(" ", " ", " ", "Totales", PrecioTotal, Comision, Pendientee, "", "");
                TotalDTodo += Pendientee;
                TotalDComision += Comision;
                TotalPrecioTotal += PrecioTotal;
            }
            PrecioTotal = 0;
            Comision = 0;
            Pendientee = 0;
        }
        double TotalDTodo = 0;
        //OTRO
        int Cod_Vendedor2 = 0, Cod_Cliente2 = 0;
        double PrecioTotal2 = 0, Pendientee2 = 0, PrecioTotal3 = 0;
        public void BuscarEmpleados2()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from empleados", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cod_Vendedor2 = lector.GetInt32(0);
                if (Cod_Vendedor2 != 1)
                {
                    Cod_Vendedor = Cod_Vendedor2;
                    if (ChecarBien2())
                    {
                        dtgConsignacion2.Rows.Add(Cod_Vendedor2, lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), "Vendedor", "", "", "", "");
                        BuscarClientes2();
                        if (Cod_Vendedor2 != 1)
                        {
                            dtgConsignacion2.Rows.Add("---", "--------------------------------------------------", "Total", PrecioTotal2, "", "", "");

                        }
                        PrecioTotal2 = 0;

                    }
                }
            }
            conectar.Close();
        }
        public void BuscarEmpleadosPorCodigo2()
        {

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from empleados WHERE id_empleado=" + tbxCodigo.Text, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {

                if (tbxCodigo.Text != "1")
                {
                    dtgConsignacion2.Rows.Add(tbxCodigo.Text, lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), "Vendedor", "", "", "", "");
                }

                BuscarClientes2();
                if (Cod_Vendedor2 != 1)
                {
                    dtgConsignacion2.Rows.Add("---", "--------------------------------------------------", "Total", PrecioTotal2, "", "", "");
                }
                PrecioTotal2 = 0;

            }
            conectar.Close();


        }
        int CodigoC2 = 0;
        public void BuscarClientes2()
        {
            if (rdbVendedor.Checked == true)
            {
                CodigoC2 = Convert.ToInt32(tbxCodigo.Text);
            }
            else
            {
                CodigoC2 = Cod_Vendedor2;
            }
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from clientes where empleados_id_empleado=" + CodigoC2, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cod_Cliente2 = lector.GetInt32(0);
                if (Cod_Cliente2 != 1)
                {
                    Cod_Cliente = Cod_Cliente2;
                    if (ChecarBien())
                    {
                        Pendientee2 = 0;
                        BuscarInvCliente2();
                        PrecioTotal2 += Pendientee2;
                        dtgConsignacion2.Rows.Add(Cod_Cliente2, lector.GetString(1), "Cliente", Pendientee2, "", "", "");
                    }

                }

            }
            conectar.Close();
        }
        public void BuscarClientesPorCodigo2()
        {

            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("select * from clientes where idclientes=" + tbxCodigo.Text, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cod_Cliente2 = lector.GetInt32(0);
                if (Cod_Cliente2 != 1)
                {
                    PrecioTotal2 += Pendientee2;
                    Pendientee2 = 0;
                    BuscarInvCliente2();
                    dtgConsignacion2.Rows.Add(Cod_Cliente2, lector.GetString(1), "Cliente", Pendientee2, "", "", "");
                }

                BuscarInvCliente2();

            }
            conectar.Close();
        }
        public void BuscarInvCliente2()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre," +
                          " i.cantidad,i.precio,a.comision From articulos a, unidad_medida u, inv_clientes i" +
                          " WHERE  i.cantidad>0 and clientes_idclientes=" + Cod_Cliente2 +
                          " and i.articulos_codigo=a.codigo AND a.unidad_medida_id = u.id" +
                          " order by codigo asc", conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                PrecioTotal3 = lector.GetDouble(4) * lector.GetDouble(5);
                //Comision2 += (PrecioTotal2 * (lector.GetDouble(6) / 100));
                Pendientee2 += (PrecioTotal3) - (PrecioTotal3 * (lector.GetDouble(6) / 100));

                //dtgConsignacion.Rows.Add(lector.GetInt32(0), lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3), lector.GetDouble(4), lector.GetDouble(5), lector.GetDouble(4) * lector.GetDouble(5), (PrecioTotal2 * (lector.GetDouble(6) / 100)), (lector.GetDouble(4) * lector.GetDouble(5)) - (PrecioTotal2 * (lector.GetDouble(6) / 100)));

            }
            conectar.Close();

        }

        private void tbxCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxCodigo.Text != "1")
                {
                    if (rdbVendedor.Checked == true)
                    {
                        obtenerVendedor();
                        if (tbxCodigo.Text != "")
                        {
                            btnReporteHistorial.Focus();
                        }
                    }
                    else if (rdbCLiente.Checked == true)
                    {
                        ObtnerCliente();
                        if (tbxCodigo.Text != "")
                        {
                            btnReporteHistorial.Focus();
                        }
                    }
                }
            }
        }
        public void ObtnerCliente()
        {
            if (tbxCodigo.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                //comando = new MySqlCommand("SELECT * FROM clientes WHERE idclientes =" + tbxCCliente.Text, conectar);
                comando = new MySqlCommand("SELECT * from clientes where idclientes=" + tbxCodigo.Text, conectar);

                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    des = lector.GetString(0);
                    tbxNombre.Text = lector.GetString(1);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código del cliente no existente");
                    tbxCodigo.Clear();
                    tbxNombre.Clear();

                }

            }
        }
        public void obtenerVendedor()
        {
            if (tbxCodigo.Text != "")
            {

                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + tbxCodigo.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    tbxNombre.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    des = lector.GetString(0);
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de vendedor no existente");
                    tbxCodigo.Text = "";
                    tbxNombre.Clear();

                }



            }



        }


        private void tbxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (cbxDias.Text == "Todos")
            {
                if (cbxIm.Text == "Todo")
                {
                    AbrirConsultaExcel(dtgConsignacion);
                }
                else if (cbxIm.Text == "Solo Totales")
                {
                    AbrirConsultaExcel(dtgConsignacion2);
                }
            }
            else if (cbxDias.Text == "Días menor que")
            {
                AbrirConsultaExcel(dataGridView1);
            }
            else if (cbxDias.Text == "Días mayor que")
            {
                AbrirConsultaExcel(dataGridView1);
            }
        }
        public void AbrirConsultaExcel(DataGridView dgvConsulta)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;
            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;
                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;
                for (int i = 0; i < dgvConsulta.ColumnCount; i++)
                {
                    oSheet.Cells[1, i + 1] = dgvConsulta.Columns[i].HeaderText;
                }
                //    oSheet.Cells[1, 1] = dgvConsulta.Columns[0].HeaderText;
                //oSheet.Cells[1, 2] = fecha.HeaderText;
                //oSheet.Cells[1, 3] = tblVendedor.HeaderText;
                //oSheet.Cells[1, 4] = tbltipoCliente.HeaderText;
                //oSheet.Cells[1, 5] = tblProducto.HeaderText;
                //oSheet.Cells[1, 6] = tblPrecio.HeaderText;
                //oSheet.Cells[1, 7] = tblCantidad.HeaderText;
                //oSheet.Cells[1, 8] = tblTotal.HeaderText;
                //oSheet.Cells[1, 9] = tblComision.HeaderText;
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "I1").Font.Bold = true;
                oSheet.get_Range("A1", "I1").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "I1").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;
                // Create an array to multiple values at once.
                int fila = dgvConsulta.Rows.Count;
                int colum = dgvConsulta.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        oSheet.Cells[i + 2, j + 1] = dgvConsulta[j, i].Value.ToString();
                    }
                }
                //Fill A2:B6 with an array of values (First and Last Names).
                //oSheet.get_Range("A2", "D6").Value2 = saNames;
                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                // oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";
                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                //oRng = oSheet.get_Range("F:F");
                //oRng.NumberFormat = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \" - \"??_-;_-@_-";
                ////oRng.Formula = "=RAND()*100000";
                //oRng = oSheet.get_Range("H:I");
                //oRng.NumberFormat = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \" - \"??_-;_-@_-";
                //AutoFit columns A:D
                oRng = oSheet.get_Range("A1", "I1");
                oRng.EntireColumn.AutoFit();
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                // MessageBox.Show(errorMessage, "Error");
            }
        }
        int col1, col2, col3, col4, col5, col6, col7, col8, y, i = 0, x, L;
        private void todoDocumentP_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgConsignacion.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width / 10 * 4;
                int an = 0;
                int al = 15;
                x = 100;
                y = 125;
                L = x + 5;
                Font letra = new Font("Arial", 9);
                col1 = dtgConsignacion.Columns[0].Width - an;
                col2 = dtgConsignacion.Columns[1].Width - an;
                col3 = dtgConsignacion.Columns[2].Width - an;
                col4 = dtgConsignacion.Columns[3].Width - an;
                col5 = dtgConsignacion.Columns[4].Width - an;
                col6 = dtgConsignacion.Columns[5].Width - an;
                col7 = dtgConsignacion.Columns[6].Width - an;
                col8 = dtgConsignacion.Columns[7].Width - an;

                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("REPORTE DE CONSIGNACIÓN", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, dtgConsignacion.Rows[0].Height + 15));
                #endregion
                string tiposeleccion = "";
                if (rdbCLiente.Checked)
                {
                    tiposeleccion = "Todo por: " + rdbCLiente.Text;
                }
                else if (rdbSucursal.Checked)
                {
                    tiposeleccion = "Todo por: " + rdbSucursal.Text;
                }
                else if (rdbVendedor.Checked)
                {
                    tiposeleccion = "Todo por: " + rdbVendedor.Text;
                }
                #region NombreVendedor
                e.Graphics.DrawString(tiposeleccion, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 95, 500, dtgConsignacion.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgConsignacion.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, dtgConsignacion.Rows[0].Height + al));

                #endregion

                #region fechaventa

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgConsignacion.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, dtgConsignacion.Rows[0].Height + al));

                #endregion

                #region vendedor

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgConsignacion.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgConsignacion.Rows[0].Height + al));


                #endregion

                #region tipocliente

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, dtgConsignacion.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, dtgConsignacion.Rows[0].Height + al));

                #endregion

                #region producto

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgConsignacion.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgConsignacion.Rows[0].Height + al));
                #endregion

                #region precioVenta

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgConsignacion.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion.Columns[5].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgConsignacion.Rows[0].Height + al));
                #endregion

                #region unidadesVendidas

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgConsignacion.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion.Columns[6].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgConsignacion.Rows[0].Height + al));
                #endregion

                #region Fecha

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, dtgConsignacion.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion.Columns[7].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6 + col7, y, col8, dtgConsignacion.Rows[0].Height + al));
                #endregion

                height = 125 + al;

                while (i < dtgConsignacion.Rows.Count)
                {
                    if (height > e.MarginBounds.Height + 100)
                    {
                        height = 125 + al;
                        e.HasMorePages = true;
                        return;
                    }


                    height += dtgConsignacion.Rows[0].Height;

                    e.Graphics.DrawString(dtgConsignacion.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, dtgConsignacion.Columns[0].Width, dtgConsignacion.Rows[0].Height));

                    e.Graphics.DrawString(dtgConsignacion.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, dtgConsignacion.Columns[1].Width, dtgConsignacion.Rows[0].Height));

                    e.Graphics.DrawString(dtgConsignacion.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgConsignacion.Columns[2].Width, dtgConsignacion.Rows[0].Height));

                    e.Graphics.DrawString(dtgConsignacion.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, dtgConsignacion.Columns[3].Width, dtgConsignacion.Rows[0].Height));

                    e.Graphics.DrawString(dtgConsignacion.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, dtgConsignacion.Columns[4].Width, dtgConsignacion.Rows[0].Height));

                    e.Graphics.DrawString(dtgConsignacion.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, dtgConsignacion.Columns[5].Width, dtgConsignacion.Rows[0].Height));
                    e.Graphics.DrawString(dtgConsignacion.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, dtgConsignacion.Columns[6].Width, dtgConsignacion.Rows[0].Height));

                    e.Graphics.DrawString(dtgConsignacion.Rows[i].Cells[7].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6 + col7, height, dtgConsignacion.Columns[7].Width, dtgConsignacion.Rows[0].Height));

                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cbxDias.Text == "Todos")
            {


                if (cbxIm.Text == "Todo")
                {
                    (todoPrintPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
                    todoPrintPreviewDialog1.PrintPreviewControl.Zoom = 1;
                    todoDocumentP.DefaultPageSettings.Landscape = true;
                    todoPrintPreviewDialog1.ShowDialog();
                }
                else if (cbxIm.Text == "Solo Totales")
                {
                    (soloTotalesprintPreviewDialog as Form).WindowState = FormWindowState.Maximized;
                    soloTotalesprintPreviewDialog.PrintPreviewControl.Zoom = 1.5;
                    //soloTotalesprintDocument.DefaultPageSettings.Landscape = true;
                    soloTotalesprintPreviewDialog.ShowDialog();
                }
            }
            else
            {
                ConsignacionFiltroPorDias Reporte = new ConsignacionFiltroPorDias();

                Reporte.Tabla = GetDataTableFromDGV(dataGridView1);
                Reporte.sMotivo = cbxDias.Text + " " + tbxDias.Text;


                using (ReportPrintTool printTool = new ReportPrintTool(Reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                    printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                }
            }
        }

        private void soloTotalesprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dtgConsignacion2.Rows.Count > 0)
            {
                int height = 0;
                int t = e.MarginBounds.Width / 10 * 5;
                int an = 0;
                int al = 15;
                x = 130;
                y = 125;
                L = x + 5;
                Font letra = new Font("Arial", 9);
                col1 = dtgConsignacion2.Columns[0].Width - an;
                col2 = dtgConsignacion2.Columns[1].Width - an;
                col3 = dtgConsignacion2.Columns[2].Width - an;
                col4 = dtgConsignacion2.Columns[3].Width - an;
                //col5 = dtgConsignacion2.Columns[4].Width - an;
                //col6 = dtgConsignacion2.Columns[5].Width - an;
                //col7 = dtgConsignacion2.Columns[6].Width - an;
                //Logotipo
                Image newImage = (Image)global::Diprolim.Properties.Resources.logoImpresiones512;
                Rectangle destRect1 = new Rectangle(x, 40, 153, 40);
                GraphicsUnit units = GraphicsUnit.Pixel;
                e.Graphics.DrawImage(newImage, destRect1, 0, 0, 521, 146, units);

                #region titulo
                e.Graphics.DrawString("REPORTE DE CONSIGNACIÓN", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Rectangle(t, 50, 500, dtgConsignacion2.Rows[0].Height + 15));
                #endregion
                string tiposeleccion = "";
                if (rdbCLiente.Checked)
                {
                    tiposeleccion = "Solo totales por: " + rdbCLiente.Text;
                }
                else if (rdbSucursal.Checked)
                {
                    tiposeleccion = "Solo totales por: " + rdbSucursal.Text;
                }
                else if (rdbVendedor.Checked)
                {
                    tiposeleccion = "Solo totales por: " + rdbVendedor.Text;
                }
                #region Tiposeleccion
                e.Graphics.DrawString(tiposeleccion, new Font("Arial", 10), Brushes.Black, new Rectangle(x, 95, 500, dtgConsignacion2.Rows[0].Height + 15));
                #endregion

                #region CodigoArticulo

                Pen p = new Pen(Brushes.Black, 1.5f);

                e.Graphics.DrawRectangle(p, new Rectangle(x, y, col1, dtgConsignacion2.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion2.Columns[0].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x, y, col1, dtgConsignacion2.Rows[0].Height + al));

                #endregion

                #region fechaventa

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1, y, col2, dtgConsignacion2.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion2.Columns[1].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1, y, col2, dtgConsignacion2.Rows[0].Height + al));

                #endregion

                #region vendedor

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2, y, col3, dtgConsignacion2.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion2.Columns[2].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2, y, col3, dtgConsignacion2.Rows[0].Height + al));


                #endregion

                #region tipocliente

                e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3, y, col4, dtgConsignacion2.Rows[0].Height + al));
                e.Graphics.DrawString(dtgConsignacion2.Columns[3].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3, y, col4, dtgConsignacion2.Rows[0].Height + al));

                #endregion

                //#region producto

                //e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgConsignacion2.Rows[0].Height + al));
                //e.Graphics.DrawString(dtgConsignacion2.Columns[4].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4, y, col5, dtgConsignacion2.Rows[0].Height + al));
                //#endregion

                //#region precioVenta

                //e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgConsignacion2.Rows[0].Height + al));
                //e.Graphics.DrawString(dtgConsignacion2.Columns[5].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5, y, col6, dtgConsignacion2.Rows[0].Height + al));
                //#endregion

                //#region unidadesVendidas

                //e.Graphics.DrawRectangle(p, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgConsignacion2.Rows[0].Height + al));
                //e.Graphics.DrawString(dtgConsignacion2.Columns[6].HeaderText.ToString(), letra, Brushes.Black, new Rectangle(x + col1 + col2 + col3 + col4 + col5 + col6, y, col7, dtgConsignacion2.Rows[0].Height + al));
                //#endregion

                height = 125 + al;

                while (i < dtgConsignacion2.Rows.Count)
                {
                    if (height > e.MarginBounds.Height + 100)
                    {
                        height = 125 + al;
                        e.HasMorePages = true;
                        return;
                    }


                    height += dtgConsignacion2.Rows[0].Height;

                    e.Graphics.DrawString(dtgConsignacion2.Rows[i].Cells[0].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L, height, dtgConsignacion2.Columns[0].Width, dtgConsignacion2.Rows[0].Height));

                    e.Graphics.DrawString(dtgConsignacion2.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1, height, dtgConsignacion2.Columns[1].Width, dtgConsignacion2.Rows[0].Height));

                    e.Graphics.DrawString(dtgConsignacion2.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2, height, dtgConsignacion2.Columns[2].Width, dtgConsignacion2.Rows[0].Height));

                    e.Graphics.DrawString(dtgConsignacion2.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3, height, dtgConsignacion2.Columns[3].Width, dtgConsignacion2.Rows[0].Height));

                    //e.Graphics.DrawString(dtgConsignacion2.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4, height, dtgConsignacion2.Columns[4].Width, dtgConsignacion2.Rows[0].Height));

                    //e.Graphics.DrawString(dtgConsignacion2.Rows[i].Cells[5].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5, height, dtgConsignacion2.Columns[5].Width, dtgConsignacion2.Rows[0].Height));
                    //e.Graphics.DrawString(dtgConsignacion2.Rows[i].Cells[6].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(L + col1 + col2 + col3 + col4 + col5 + col6, height, dtgConsignacion2.Columns[6].Width, dtgConsignacion2.Rows[0].Height));

                    i++;
                }
                i = 0;
                e.HasMorePages = false;

            }
        }

        private void cbxIm_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgConsignacion.Rows.Clear();
            dtgConsignacion2.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
                DesplegableReporteConsignacion detalleProductos = new DesplegableReporteConsignacion(Conexion);
                detalleProductos.sPalabra = cbxDias.Text;

                detalleProductos.Diass = Convert.ToInt32(tbxDias.Text);

                detalleProductos.sIDCliente = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                detalleProductos.sNombreCliente = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                detalleProductos.FechaaV = Convert.ToDateTime(dataGridView1[4, dataGridView1.CurrentRow.Index].Value);
              
                detalleProductos.ShowDialog();
            
        }

        private void cbxDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDias.Text == "Todos")
            {
                cbxIm.Enabled = true;
            }
            else if(cbxDias.Text=="Días menor que")
            {
                cbxIm.Enabled = false;
            }
            else if (cbxDias.Text == "Días mayor que")
            {
                cbxIm.Enabled = false;
            }
        }

        private void tbxDias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnReporteHistorial_Click(sender,e);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {            
            ConsignacionFiltroPorDias Reporte = new ConsignacionFiltroPorDias();

            Reporte.Tabla = GetDataTableFromDGV(dataGridView1);
            Reporte.sMotivo = cbxDias.Text +" "+ tbxDias.Text;


            using (ReportPrintTool printTool = new ReportPrintTool(Reporte))
            {
                printTool.ShowRibbonPreviewDialog();
                printTool.ShowRibbonPreview(UserLookAndFeel.Default);
            }
        }
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }
    }
}
                       
                    
       