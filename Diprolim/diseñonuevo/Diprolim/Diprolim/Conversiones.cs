using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;
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
    public partial class Conversiones : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        String cmd;
        conexion conn = new conexion();
        recuperarCodigo _ui = new recuperarCodigo();
        string descripcion = "";
        string Codigo = "";
        string LIKE = "";
        double ValordeMedida = 0;
        double ValordeMedida2 = 0;
        string UsuarioID = "";

        public Conversiones(string id, UnicaSQL.DBMS_Unico svr)
        {
            InitializeComponent();
            UsuarioID = id;
            Conexion = svr;
        }

        public Conversiones(string s, string id, UnicaSQL.DBMS_Unico svr)
        {
            InitializeComponent();
            LIKE=s;
            UsuarioID = id;
            Conexion = svr;
           obtenerVendedor();

        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        public void obtenerVendedor()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + LIKE, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            string des2 = "";
            while (lector.Read())
            {
                des2 = lector.GetString(1);
                tbxVendedor.Text = lector.GetString(0);
                tbxNVendedor.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                Codigo = lector.GetString(0);
            }
            conectar.Close();

            button3.Enabled = false;
            if (des2 == "")
            {
                MessageBox.Show("Ese vendedor no Existe");
                tbxVendedor.Clear();
                tbxVendedor.Focus();
                tbxVendedor.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

            }
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            if (tbxVendedor.Text != "" &&tbxNVendedor.Text!="")
            {
                BuscarArticuloPVendedor id = new BuscarArticuloPVendedor(Codigo);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxProducto.Text = id.regresar.valXn;
                }
                tbxProducto.Focus();
                MetodoProducto1();
            }
            else
            {
                BuscarArticuloss id = new BuscarArticuloss();
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxProducto.Text = id.regresar.valXn;
                }
                tbxProducto.Focus();
                MetodoProducto1();
            }
        }
        public void obtenerProducto()
        {
            if (tbxProducto.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre, a.cantidad,a.departamento " +
                            "FROM articulos a, unidad_medida u WHERE codigo =" + tbxProducto.Text + " and a.unidad_medida_id=u.id", conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    des = lector.GetString(0);
                    if (lector.GetInt32(5) != 1)
                    {
                        MessageBox.Show("Ese producto no se puede convertir");
                        tbxProducto.Clear();
                        tbxProducto.Focus();
                    }
                    else
                    {
                        //if (lector.GetDouble(2) > 3 || lector.GetString(3) == "A granel")
                        //{
                            descripcion = lector.GetString(1);
                            tbxNombre.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);

                            tbxExistencias.Text = lector.GetString(4);

                            cod_art = lector.GetInt32(0);

                            label8.Text = lector.GetString(3);
                            label9.Text = label8.Text;
                            ValordeMedida = lector.GetDouble(2);
                            btnSP.Enabled = false;
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Imposible convertir");
                        //    tbxProducto.Clear();
                        //}
                        
                    }
                    

                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código de Producto no existente");
                    tbxProducto.Clear();
                    tbxNombre.Clear();
                    tbxProducto.Focus();

                }
              
            }
        }
        public void obtenerProductoPVendedor()
        {
            if (tbxProducto.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("select a.codigo, a.descripcion, a.valor_medida, c.nombre, i.cantidad,a.departamento,i.empleados_id_empleado from articulos a, unidad_medida c, inv_vendedor i where empleados_id_empleado=" + tbxVendedor.Text + " and codigo=" + tbxProducto.Text + " and a.unidad_medida_id=c.id and i.cantidad>0 and  i.articulos_codigo=a.codigo", conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    des = lector.GetString(0);
                    if (lector.GetInt32(5) != 1)
                    {
                        MessageBox.Show("Ese producto no se puede convertir");
                        tbxProducto.Clear();
                        tbxProducto.Focus();
                    }
                    else if(lector.GetDouble(2)>3||lector.GetString(3)=="A granel")
                    {
                        descripcion = lector.GetString(1);
                        tbxNombre.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);

                        tbxExistencias.Text = lector.GetString(4);
                        
                        cod_art = lector.GetInt32(0);
                      
                        label8.Text = lector.GetString(3);
                        label9.Text = label8.Text;
                        ValordeMedida = lector.GetDouble(2);
                        btnSP.Enabled = false;
                        LIKE = lector.GetString(6);
                    }


                }
                conectar.Close();
                if (des == "" || tbxNombre.Text.Length == 0)
                {
                    MessageBox.Show("Favor de verificar artículo a convertir.");
                    tbxProducto.Clear();
                    tbxNombre.Clear();
                    tbxProducto.Focus();
                }
            }
        }
        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoProducto1();
            }
        }
        public void MetodoProducto1()
        {
            if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
            {

                obtenerProductoPVendedor();
                if (tbxProducto.Text != "")
                {

                    tbxCConvertir.Focus();
                    tbxProducto.ReadOnly = true;


                }
            }
            else
            {
                LIKE = "";
                obtenerProducto();
                if (tbxProducto.Text != "")
                {

                    tbxCConvertir.Focus();
                    tbxProducto.ReadOnly = true;


                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reset();
            
        }

        private void tbxCConvertir_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxCConvertir.Text != ""&&tbxProducto.Text!=""&&tbxNombre.Text!="")
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (tbxCConvertir.Text == ".")
                    {
                        MessageBox.Show("Verifique la cantidad a convertir");
                    }
                    else
                    {
                        if (Convert.ToDouble(tbxCConvertir.Text) <= Convert.ToDouble(tbxExistencias.Text))
                        {

                            tbxCodigo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No puede convertir mas de las existencias");
                            tbxCConvertir.Clear();

                        }
                    }
                }
            }
                    
                
            }

        private void button1_Click(object sender, EventArgs e)
        {
            BucarProductoConversion id = new BucarProductoConversion(descripcion,LIKE);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCodigo.Text = id.regresar.valXn;
            }
            tbxCodigo.Focus();
            MetodoProducto2();
        }
        Double ExistenciaInicial2 = 0;
        public void obtenerProducto2()
        {
            if (tbxCodigo.Text != "")
            {
                if (tbxVendedor.Text == "")
                {
                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando;
                    comando = new MySqlCommand("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre, a.cantidad " +
                                "FROM articulos a, unidad_medida u WHERE codigo =" + tbxCodigo.Text + " and a.unidad_medida_id=u.id", conectar);
                    conectar.Open();

                    MySqlDataReader lector;
                    lector = comando.ExecuteReader();
                    string des = "";
                    while (lector.Read())
                    {

                        tbxNProducto.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                        des = lector.GetString(0);
                        ExistenciaInicial2 = lector.GetDouble(4);
                        cod_art2 = lector.GetInt32(0);

                        ValordeMedida2 = lector.GetDouble(2);
                        if (descripcion != lector.GetString(1))
                        {
                            MessageBox.Show("No puede convertir ese producto");
                            tbxCodigo.Clear();
                            tbxNProducto.Clear();
                        }
                    }
                    conectar.Close();
                    if (des == "")
                    {
                        MessageBox.Show("Código de producto no existente");
                        tbxCodigo.Clear();
                        tbxNProducto.Clear();
                        tbxCodigo.Focus();


                    }
                }
                else
                {
                    DataTable tbl = new DataTable();
                    Conexion.Conectarse();
                    cmd = String.Format("SELECT a.codigo, a.descripcion, a.valor_medida, u.nombre, iv.cantidad "+
                        " FROM articulos a, unidad_medida u, inv_vendedor iv WHERE iv.articulos_codigo ={1} and a.unidad_medida_id=u.id"+
                        " and iv.empleados_id_empleado={0} and a.codigo=iv.articulos_codigo;",tbxVendedor.Text,tbxCodigo.Text);
                    Conexion.Ejecutar(cmd,ref tbl);
                    Conexion.Desconectarse();
                    if (tbl.Rows.Count > 0)
                    {
                        DataRow row = tbl.Rows[0];
                        tbxNProducto.Text = row["descripcion"].ToString() + " " + row["valor_medida"].ToString() + " " + row["nombre"].ToString();

                        ExistenciaInicial2 = Convert.ToDouble(row["cantidad"]);
                        tbxExistencias2.Text = row["cantidad"].ToString();
                        cod_art2 = Convert.ToInt32(row["codigo"]);

                        ValordeMedida2 = Convert.ToDouble(row["valor_medida"]);
                        if (descripcion != row["descripcion"].ToString())
                        {
                            MessageBox.Show("No puede convertir ese producto");
                            tbxCodigo.Clear();
                            tbxNProducto.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Código de producto no existente");
                        tbxCodigo.Clear();
                        tbxNProducto.Clear();
                        tbxCodigo.Focus();
                    }
                }
               
            }
        }
       
        private void tbxCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoProducto2();
            }
        }
        public void MetodoProducto2()
        {
            obtenerProducto2();
            if (tbxCodigo.Text != "")
            {

                tbxCCConvertir.Focus();
            }
        }
        double ObtenerCantidadR = 0;
        double ObtenerCantidadR2 = 0;
        double pendiente = 0;
        private string p;
        private void tbxCCConvertir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                Verificar();
                
            }
        }
        public void Verificar()
        {
            if (tbxCConvertir.Text != "" && tbxCCConvertir.Text != ""&&tbxExistencias.Text!="")
            {
                if (Convert.ToDouble(tbxCConvertir.Text) <= Convert.ToDouble(tbxExistencias.Text))
                {
                    if (tbxCCConvertir.Text == ".")
                    {
                        MessageBox.Show("Verifique la cantidad a convertir");
                    }
                    else
                    {
                        ObtenerCantidadR = ValordeMedida * (Convert.ToDouble(tbxCConvertir.Text));
                        ObtenerCantidadR2 = ValordeMedida2 * (Convert.ToDouble(tbxCCConvertir.Text));
                        pendiente = ObtenerCantidadR - ObtenerCantidadR2;
                        if (pendiente < 0)
                        {
                            MessageBox.Show("Imposible convertir");
                            tbxPendiente.Text = pendiente.ToString();
                        }
                        else
                        {
                            tbxPendiente.Text = pendiente.ToString();
                            btnRegistrar.Enabled = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Imposible convertir");
                    tbxPendiente.Clear();
                }
            }
        }
        double cantidad2 = 0, existenciaFinal2 = 0, ExistenciaInicial1=0,cantidad6=0;
        public void Guardado()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            if (tbxVendedor.Text != ""&&tbxNVendedor.Text!="")
            {
                insertar();
                comando = new MySqlCommand("UPDATE inv_vendedor SET cantidad=cantidad-" + tbxCConvertir.Text + " WHERE empleados_id_empleado=" + tbxVendedor.Text + " AND articulos_codigo=" + tbxProducto.Text, conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();
                
                comando = new MySqlCommand("UPDATE inv_vendedor SET cantidad=cantidad+" + tbxCCConvertir.Text + " WHERE empleados_id_empleado=" + tbxVendedor.Text + " AND articulos_codigo=" + tbxCodigo.Text, conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();

                cantidad = Convert.ToDouble(tbxCConvertir.Text);
                cantidad2 = Convert.ToDouble(tbxCCConvertir.Text);
                existenciaFinal2 = (ExistenciaInicial2 + cantidad2);
                existenciaFinal1 = (Convert.ToDouble(tbxExistencias.Text) - cantidad);
                ExistenciaInicial1 = Convert.ToDouble(tbxExistencias.Text);

                Conexion.Conectarse();
                cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                  " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                  " VALUES({0},{1},'{2}','{3}',{4},{5},{6},{7})",
                  cod_art, cantidad, "Conversión", dtpFecha.Value.ToString("yyyyMMddHHmmss"),
                  ExistenciaInicial1, existenciaFinal1, tbxVendedor.Text, UsuarioID);
                Conexion.Ejecutar(cmd);

                cmd = String.Format("INSERT INTO historicovendedores (articulos_codigo,cantidad,Movimiento,Fecha," +
                " Existencia_inicial,Existencia_Final,empleados_id_empleado,Usuarios_id_usuarios) " +
                " VALUES({0},{1},'{2}','{3}',{4},{5},{6},{7})",
                cod_art2, cantidad2, "Conversión", dtpFecha.Value.ToString("yyyyMMddHHmmss"),
                ExistenciaInicial2, existenciaFinal2, tbxVendedor.Text, UsuarioID);
                Conexion.Ejecutar(cmd);
                Conexion.Desconectarse();

                RepConversion Reporte = new RepConversion();
               
                Reporte.sFuente = "Fuente: " + tbxNVendedor.Text;

                Reporte.sFecha = "Fecha: " + dtpFecha.Value.ToString("dd/MM/yyyy");
                Reporte.sCodigo1 = tbxProducto.Text;
                Reporte.sDescripcion1 = tbxNombre.Text;
                Reporte.sCantidad1 = tbxCConvertir.Text;
                Reporte.sCodigo2 = tbxCodigo.Text;
                Reporte.sDescripcion2 = tbxNProducto.Text;
                Reporte.sCantidad2 = tbxCCConvertir.Text;

                using (ReportPrintTool printTool = new ReportPrintTool(Reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                    printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                }
       
                MessageBox.Show("Convertido");
             
            }
            else
            {

                obtenerProducto22();
                //MessageBox.Show("" + cantidad3);
                comando = new MySqlCommand("UPDATE articulos SET cantidad=cantidad-" + tbxCConvertir.Text + " WHERE codigo=" + tbxProducto.Text, conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();


                comando = new MySqlCommand("UPDATE articulos SET cantidad=cantidad+" + tbxCCConvertir.Text + " WHERE codigo=" + tbxCodigo.Text, conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();
               
                
                cantidad = Convert.ToDouble(tbxCConvertir.Text);
                cantidad2 = Convert.ToDouble(tbxCCConvertir.Text);
                existenciaFinal2 = (ExistenciaInicial2 + cantidad2);
                existenciaFinal1 = (Convert.ToDouble(tbxExistencias.Text) - cantidad);
                ExistenciaInicial1 = Convert.ToDouble(tbxExistencias.Text);
                InsertarHistoricoDMovimientos();
                InsertarHistoricoDMovimientos2();
                RepConversion Reporte = new RepConversion();
               
                Reporte.sFuente = "Fuente: Sucursal";
                
                Reporte.sFecha = "Fecha: "+dtpFecha.Value.ToString("dd/MM/yyyy");
                Reporte.sCodigo1 = tbxProducto.Text;
                Reporte.sDescripcion1 = tbxNombre.Text;
                Reporte.sCantidad1 = tbxCConvertir.Text;
                Reporte.sCodigo2 = tbxCodigo.Text;
                Reporte.sDescripcion2 = tbxNProducto.Text;
                Reporte.sCantidad2 = tbxCCConvertir.Text;

                using (ReportPrintTool printTool = new ReportPrintTool(Reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                    printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                }

                MessageBox.Show("Convertido");
            }
            Reset();
        }
        public void obtenerProducto22()
        {
            if (tbxCodigo.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT cantidad FROM articulos WHERE codigo =" + tbxCodigo.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
               
                while (lector.Read())
                {

                    ExistenciaInicial2 = lector.GetDouble(0);
                   
                }
                conectar.Close();
               
            }
        }
        public void insertar()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;
            MySqlDataReader lector;
            comando = new MySqlCommand("select count(*) from inv_vendedor where  empleados_id_empleado=" + tbxVendedor.Text + " and articulos_codigo=" + tbxCodigo.Text, conectar);
            conectar.Open();


            lector = comando.ExecuteReader();

            int i = 0;
            while (lector.Read())
            {
                i = lector.GetInt32(0);
                if (i == 0)
                {
                    InsertarDeVerdad();


                }
            }
            conectar.Close();

        }
        public void InsertarDeVerdad()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando;

            comando = new MySqlCommand("insert into inv_vendedor values(null,0," + tbxVendedor.Text + "," + tbxCodigo.Text + ")", conectar);
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        public void Reset()
        {
            tbxExistencias2.Clear();
            tbxProducto.Clear();
            tbxNombre.Clear();
            tbxCConvertir.Clear();
            tbxExistencias.Clear();
            tbxCodigo.Clear();
            tbxCCConvertir.Clear();
            tbxNProducto.Clear();
            tbxPendiente.Clear();
            btnSP.Enabled = true;
            btnRegistrar.Enabled = false;
            tbxProducto.ReadOnly = false;
        }
        int cod_art = 0, cod_art2=0;
        double cantidad = 0, existenciaFinal1 = 0;
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(tbxProducto.Text!=""&&tbxCConvertir.Text!=""&&tbxCodigo.Text!= ""&& tbxCCConvertir.Text!="")
            {
                if (tbxVendedor.Text != ""&&tbxNVendedor.Text!="")
                {
                    obtenerProductoPVendedor();
                    obtenerProducto2();
                }
                else
                {
                    obtenerProducto();
                    obtenerProducto2();
                }
                Verificar();
                if (tbxProducto.Text != "" && tbxCConvertir.Text != "" && tbxCodigo.Text != "" && tbxCCConvertir.Text != "")
                {
                    if (tbxPendiente.Text == "0")
                    {
                        if (tbxNombre.Text != tbxNProducto.Text)
                        {
                            Guardado();
                        }
                        else
                        {
                            MessageBox.Show("No es necesario convertir el mismo producto");
                        }
                    }
                }
            }
        }
        public void InsertarHistoricoDMovimientos()
        {
            MySqlCommand comando;
            MySqlConnection conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("INSERT INTO HistoricoDMovimientos  VALUES(null," + cod_art + "," + cantidad + "," + existenciaFinal1 + ",'Conversión'," + UsuarioID + ",now(),"+ExistenciaInicial1+")", conectar);
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        public void InsertarHistoricoDMovimientos2()
        {
            MySqlCommand comando;
            MySqlConnection conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("INSERT INTO HistoricoDMovimientos  VALUES(null," + cod_art2 + "," + cantidad2 + "," + existenciaFinal2 + ",'Conversión'," + UsuarioID + ",now(),"+ExistenciaInicial2+")", conectar);
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        private void button3_Click(object sender, EventArgs e)
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
        
        public void veririficarempleado()
        {
            if (tbxVendedor.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand("SELECT * FROM empleados WHERE id_empleado =" + tbxVendedor.Text, conectar);
                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des2 = "";
                while (lector.Read())
                {
                    des2 = lector.GetString(1);
                    tbxNVendedor.Text = lector.GetString(1) + " " + lector.GetString(2) + " " + lector.GetString(3);
                    Codigo = lector.GetString(0);
                }
                conectar.Close();
               
                button3.Enabled = false;
                if (des2 == "")
                {
                    MessageBox.Show("Ese vendedor no existe");
                    tbxVendedor.Clear();
                    tbxVendedor.Focus();
                    tbxVendedor.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;

                }
            }

        }
        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxVendedor.Text != "")
            {

                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    MetodoVendedor();
                }
            }
        }
        public void MetodoVendedor()
        {
            if (tbxVendedor.Text != "1")
            {
                veririficarempleado();
                Reset();
                tbxProducto.Focus();
            }
            else
            {
                MessageBox.Show("Para convertir en la misma sucursal no es necesario poner vendedor ");
                tbxVendedor.Clear();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tbxVendedor.Clear();
            Reset();
            tbxNVendedor.Clear();
            tbxNVendedor.Enabled = true;
            tbxVendedor.Focus();
            button3.Enabled = true;
            tbxVendedor.ReadOnly = false;
        }

        private void tbxCConvertir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxCConvertir.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxCCConvertir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxCCConvertir.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
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

        private void tbxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
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

        private void Conversiones_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
        }

        private void tbxProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                if (tbxVendedor.Text != "" && tbxNVendedor.Text != "")
                {
                    BuscarArticuloPVendedor id = new BuscarArticuloPVendedor(Codigo);
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxProducto.Text = id.regresar.valXn;
                    }
                    tbxProducto.Focus();
                    MetodoProducto1();
                }
                else
                {
                    BuscarArticuloss id = new BuscarArticuloss();
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxProducto.Text = id.regresar.valXn;
                    }
                    tbxProducto.Focus();
                    MetodoProducto1();
                }
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
                }
                tbxVendedor.Focus();
                MetodoVendedor();
            }
        }

        private void tbxCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void tbxCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                BucarProductoConversion id = new BucarProductoConversion(descripcion, LIKE);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCodigo.Text = id.regresar.valXn;
                }
                tbxCodigo.Focus();
                MetodoProducto2();
            }
        }

        private void Conversiones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

