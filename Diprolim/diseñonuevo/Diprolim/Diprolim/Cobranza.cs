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
    public partial class Cobranza : Form
    {
        conexion conn = new conexion();
        MySqlCommand comando;
        public Cobranza()
        {
            InitializeComponent();
            fecha.Value = DateTime.Now;
        }

        public Cobranza(string vendedor)
        {
            InitializeComponent();
            tbxVendedor.Text = vendedor;
            obtenerVendedor();
            tbxVendedor.Enabled= false;
            btnSP.Enabled = false;            
            fecha.Value = DateTime.Now;
            tbxCliente.Focus();
        }
        public Cobranza(string vendedor, string cliente)
        {
            InitializeComponent();
            tbxVendedor.Text = vendedor;
            tbxCliente.Text = cliente;
            obtenerVendedor();
            ObtnerCliente();
            tbxVendedor.Enabled = false;
            btnSP.Enabled = false;
            tbxCliente.Enabled = false;
            btnB.Enabled = false;
            tbxRecuperado.Focus();
            fecha.Value = DateTime.Now;
            
        }
        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedor.Text = id.regresar.valXn;
                obtenerVendedor();
            }
            tbxVendedor.ReadOnly = true;
            btnSP.Enabled = false;
          
                tbxCliente.Focus();
            
        }
            
        public void obtenerVendedor()
        {
            if (tbxVendedor.Text != "")
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("Select nombre, apellido_paterno, apellido_materno from empleados where id_empleado=" + tbxVendedor.Text, conectar);
                conectar.Open();
                MySqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tbxNVendedor.Text = lector.GetString(0) + " " + lector.GetString(1) + " " + lector.GetString(2);
                }

                conectar.Close();
            }
        }
        public void ObtnerCliente()
        {
            if (tbxCliente.Text != "")
            {
               
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                //comando = new MySqlCommand("SELECT * FROM clientes WHERE idclientes =" + tbxCCliente.Text, conectar);
                comando = new MySqlCommand("SELECT a.idclientes, a.nombre, a.categorias_idcategorias, u.Vendedor, a.empleados_id_empleado " +
                            "FROM clientes a, categorias u WHERE idclientes =" + tbxCliente.Text + " and a.categorias_idcategorias=u.idcategorias", conectar);

                conectar.Open();

                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                string des = "";
                while (lector.Read())
                {
                    if (lector.GetString(4) == tbxVendedor.Text)
                    {                       
                        tbxNCliente.Text = lector.GetString(1);
                        des = lector.GetString(0);
                        tbxCliente.ReadOnly = true;
                        btnB.Enabled = false;
                        tbxRecuperado.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El cliente no pertenece a este vendedor");
                        des = ":p";
                        tbxCliente.Clear();
                        tbxNCliente.Clear();
                        tbxCliente.Focus();
                    }
                }
                conectar.Close();
                if (des == "")
                {
                    MessageBox.Show("Código del cliente no existente");
                    tbxCliente.Clear();
                    tbxNCliente.Clear();
                    tbxCliente.Focus();
                }
                ChecarAdeudos();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCliente.Text = id.regresar.valXn;
                ObtnerCliente();
                tbxCliente.ReadOnly = true;
                btnB.Enabled = false;
            }
            tbxRecuperado.Focus();
        }

        private void rbtnGeneral_CheckedChanged(object sender, EventArgs e)
        {
            tbxCliente.Enabled = false;
            tbxNCliente.Enabled = false;
            tbxCliente.Clear();
            tbxNCliente.Clear();
            btnB.Enabled = false;
            btnR.Enabled = false;
        }

        private void rbtnPCliente_CheckedChanged(object sender, EventArgs e)
        {
            tbxCliente.Enabled = true;
            tbxCliente.ReadOnly = false;
            tbxNCliente.Enabled = true;
            btnB.Enabled = true;
            btnR.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tbxVendedor.Clear();
            btnSP.Enabled = true;
            tbxNVendedor.Clear();
            tbxCliente.Clear();
            tbxNCliente.Clear();
            tbxRecuperado.Clear();
            tbxFiado.Clear();
            tbxVendedor.ReadOnly = false;
            tbxVendedor.Enabled = true;
            Tabla.Rows.Clear();

        }

        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxVendedor.Text != "")
                {
                    obtenerVendedor();
                    tbxVendedor.ReadOnly = true;
                    btnSP.Enabled = false;
                   
                        tbxCliente.Focus();
                    
                }
            }
        }

        private void tbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ObtnerCliente();
              
            }
        }

        private void tbxRecuperado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                tbxFiado.Focus();
            }
        }

        private void tbxFiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                btnAC.Focus();
            }
        }
        int count = 0, count2=0;
        TimeSpan ts;
        DateTime fechaN;
        public void ChecarAdeudos()
        {
            try
            {
                if (tbxCliente.Text != "")
                {
                    string cliente = "";
                    cliente = Convert.ToString(tbxCliente.Text);

                    MySqlConnection conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("select count(*) from adeudos where saldo>0 and clientes_idclientes=" + cliente + " and empleados_id_empleado=" + tbxVendedor.Text, conectar);
                    conectar.Open();

                    MySqlDataReader lector;
                    count = Convert.ToInt32(comando.ExecuteScalar());

                    conectar.Close();
                    if (count == 0)
                    {
                        Dias.Text = "" + 1;
                    }
                    else
                    {
                        comando = new MySqlCommand("select min(Fecha) from adeudos where saldo>0 and clientes_idclientes=" + cliente + " and empleados_id_empleado=" + tbxVendedor.Text + "", conectar);
                        conectar.Open();
                        lector = comando.ExecuteReader();
                        while (lector.Read())
                        {
                                fechaN = lector.GetDateTime(0);                          
                        }
                        conectar.Close();
                           ts = DateTime.Now.AddDays(1) - fechaN;
                            Dias.Text = "" + ts.Days;                      
                    }

                    comando = new MySqlCommand("select count(*) from cobranza where clientes_idclientes=" + cliente + " and empleados_id_empleado=" + tbxVendedor.Text, conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        count2 = lector.GetInt32(0);
                    }
                    conectar.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        double credito = 0;
        public void ObtenerAdeudo()
        {
            MySqlConnection conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select credito from adeudos where credito>0 and clientes_idclientes=" + cliente, conectar);
            conectar.Open();

            MySqlDataReader lector;
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                credito = lector.GetDouble(0);
            }
            conectar.Close();
        }
        int cliente = 0;
        private void btnAC_Click(object sender, EventArgs e)
        {
            try
            {
                double pendiente = 0, recuperado = 0, fiado = 0, pendiente2 = 0;
                if (Tabla.Rows.Count == 1)
                {
                    MessageBox.Show("No se puede agregar más de 1 registro a la vez");
                }
                else
                {
                    cliente = Convert.ToInt32(tbxCliente.Text);

                    //ChecarAdeudos(); verifica si hay adeudos pendientes
                    ChecarAdeudos();
                    if (tbxRecuperado.Text == ".")
                    {
                        MessageBox.Show("Verifica la cantidad");
                        tbxRecuperado.Focus();
                    }
                    else if (tbxFiado.Text == ".")
                    {
                        MessageBox.Show("Verifica la cantidad");
                        tbxFiado.Focus();
                    }
                    else
                    {   //count y count2 sirven para verificar si hay adeudos pendiendes
                        if (count == 0 && count2 == 0)
                        {
                            if (tbxFiado.Text != "")
                            {
                                fiado = (Convert.ToDouble(tbxFiado.Text));
                            }
                            else
                            {
                                fiado = 0;
                            }

                            if (fiado != 0)
                            {
                                Tabla.Rows.Add(false, fecha.Value.ToString("dd/MMM/yyyy"), 0, 0, fiado, fiado);
                            }
                            if (tbxRecuperado.Text != "")
                            {
                                MessageBox.Show("No puede abonar sin deber");
                                tbxRecuperado.Clear();
                            }
                            tbxFiado.Clear();
                        }
                        else
                        {
                            MySqlConnection conectar = conn.ObtenerConexion();
                            comando = new MySqlCommand("select count(*) from adeudos where saldo>0 and empleados_id_empleado=" + tbxVendedor.Text + " and clientes_idclientes=" + cliente, conectar);
                            conectar.Open();
                            pendiente2 = Convert.ToDouble(comando.ExecuteScalar());
                            conectar.Close();
                            if (pendiente2 > 0)
                            {
                                //Verificar esta linea de si en realidad obtiene el ultimo registro agregado
                                comando = new MySqlCommand("select sum(saldo) from adeudos where saldo>0 and empleados_id_empleado=" + tbxVendedor.Text + " and clientes_idclientes=" + cliente, conectar);
                                conectar.Open();
                                pendiente2 = Convert.ToDouble(comando.ExecuteScalar());
                                conectar.Close();
                            }
                                if (tbxFiado.Text != "" && tbxRecuperado.Text != "")
                                {
                                    pendiente = pendiente2 - Convert.ToDouble(tbxRecuperado.Text) + Convert.ToDouble(tbxFiado.Text);
                                    recuperado = Convert.ToDouble(tbxRecuperado.Text);
                                    fiado = Convert.ToDouble(tbxFiado.Text);
                                }
                                else if (tbxFiado.Text != "")
                                {
                                    pendiente = pendiente2 + Convert.ToDouble(tbxFiado.Text);
                                    recuperado = 0;
                                    fiado = Convert.ToDouble(tbxFiado.Text);
                                }
                                else if (tbxRecuperado.Text != "")
                                {
                                    pendiente = pendiente2 - Convert.ToDouble(tbxRecuperado.Text);
                                    fiado = 0;
                                    recuperado = Convert.ToDouble(tbxRecuperado.Text);
                                }
                                if (pendiente < 0)
                                {
                                    pendiente = 0;
                                }
                                if (recuperado > (pendiente2+fiado))
                                {
                                    MessageBox.Show("No es posible abonar una cantidad mayor a lo que se debe");
                                }
                                else
                                {

                                    Tabla.Rows.Add(false, fecha.Value.ToString("dd/MMM/yyyy"), pendiente2, recuperado, fiado, pendiente);
                                    tbxRecuperado.Clear();
                                    tbxFiado.Clear();
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            tbxCliente.Clear();
            tbxNCliente.Clear();
            btnB.Enabled = true;
            tbxCliente.ReadOnly = false;
            tbxCliente.Enabled = true;
            Tabla.Rows.Clear();
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
     
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Tabla.Rows.Count > 0)
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando;
                MySqlDataReader lector;
                double adeudo = 0, abono = 0, FD = 0, Pendiente = 0;
                adeudo = Convert.ToDouble(Tabla[2, 0].Value);
                abono = Convert.ToDouble(Tabla[3, 0].Value);
                FD = Convert.ToDouble(Tabla[4, 0].Value);
                Pendiente = Convert.ToDouble(Tabla[5, 0].Value);

                
                //insertando nuevo fiado en la tabla adeudos primero se verifica si hay adeudos por agregar con la variable FD
                if (FD > 0)
                {
                    //comando = new MySqlCommand("INSERT INTO Adeudos values(null," + cliente + ",'" + fecha.Value.ToString("yyyyMMddHHmmss") + "'," + FD +","+FD+"," + tbxVendedor.Text + ")", conectar);
                    comando = new MySqlCommand("INSERT INTO Adeudos values(null," + cliente + ",'" + fecha.Value
                        
                        .ToString("yyyyMMddHHmmss") + "'," + FD + "," + FD + "," + tbxVendedor.Text + ",0)", conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                //se inserta nuevo registro en la tabla cobranza que servirá para la generación de reportes
                comando = new MySqlCommand("INSERT INTO cobranza values(null," + tbxVendedor.Text + "," + cliente + "," + adeudo + "," + abono + "," + FD + "," + Pendiente + ",'" + fecha.Value.ToString("yyyyMMddHHmmss") + "',"+Dias.Text+")", conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();

                if (abono > 0)
                {
                    int cont = 0, idadeudo = 0;
                    double Saldo = 0, resto = 1;

                    while (resto > 0)
                    {
                        //Consulta para verificar si el cliente tiene deudas con saldo mayor a 0
                        comando = new MySqlCommand("Select count(*) from Adeudos where Saldo>0 and clientes_idclientes=" + cliente + " and empleados_id_empleado=" + tbxVendedor.Text + "", conectar);
                        conectar.Open();
                        cont = Convert.ToInt32(comando.ExecuteScalar());                     
                        conectar.Close();
                        if (cont > 0)
                        {
                            DateTime DiasF=DateTime.Now;
                            comando = new MySqlCommand("Select min(fecha), Saldo, idAdeudos from Adeudos where Saldo>0 and clientes_idclientes=" + cliente + " and empleados_id_empleado=" + tbxVendedor.Text + "", conectar);
                            conectar.Open();
                            lector = comando.ExecuteReader();
                            while (lector.Read())
                            {
                                DiasF = lector.GetDateTime(0);
                                Saldo = lector.GetDouble(1);
                                idadeudo = lector.GetInt32(2);
                            }
                            conectar.Close();
                            TimeSpan ts = DateTime.Now.AddDays(1) - DiasF;
                            int diasT = ts.Days;
                            resto = Saldo - abono;
                            if (resto <= 0)
                            {
                                comando = new MySqlCommand("UPDATE adeudos SET Saldo=0, Dias=" + diasT + " WHERE idAdeudos=" + idadeudo + "", conectar);
                                conectar.Open();
                                comando.ExecuteNonQuery();
                                conectar.Close();
                                abono = Math.Abs(resto);
                                resto = abono;
                            }
                            else
                            {
                                comando = new MySqlCommand("UPDATE Adeudos SET Saldo=" + resto + ", Dias=" + diasT + " WHERE idAdeudos=" + idadeudo + "", conectar);
                                conectar.Open();
                                comando.ExecuteNonQuery();
                                conectar.Close();
                                resto = 0;
                            }
                        }
                        else
                        {
                            resto = 0;
                        }
                    }
                }
                MessageBox.Show("La cobranza ha sido registrada exitosamente");

                Tabla.Rows.Clear();
            }
        }

        private void tbxRecuperado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxRecuperado.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void tbxFiado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxFiado.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
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
        }

        private void tbxCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        

        }
    }

