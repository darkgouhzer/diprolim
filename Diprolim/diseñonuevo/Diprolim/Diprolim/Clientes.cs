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
    public partial class Clientes : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        string comando;
        int codigoV = 0;
        DialogResult result;
        public Clientes(UnicaSQL.DBMS_Unico svr)
        {
            InitializeComponent();            
            tbxID.Focus();
            Conexion = svr;
            dtpFechaIngreso.Value = DateTime.Now;
            CodigoClienteSugerido();
        }
        public void Ruta()
        {
            try
            {
                Conexion.Conectarse();
                DataTable tabla = new DataTable();
                string comando = "SELECT idRuta, Ruta FROM Rutas";
                Conexion.Ejecutar(comando, ref tabla);
                Conexion.Desconectarse();
                cbxRutas.DataSource = tabla;
                cbxRutas.DisplayMember = "Ruta";
                cbxRutas.ValueMember = "idRuta";
               
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        private void ModificarClientes_Load(object sender, EventArgs e)
        {
            Ruta();
            RefrescarRutas();
            Categorias();
        }
        public void RefrescarRutas()
        {
            Conexion.Conectarse();
            DataTable tabla = new DataTable();
            Conexion.Ejecutar("SELECT idLocalidades, Localidad FROM Localidades  WHERE Rutas_IdRuta='" + cbxRutas.SelectedValue + "' ", ref tabla);
            Conexion.Desconectarse();
            if (tabla.Rows.Count > 0)
            {
                cbxLocalidades.DataSource = tabla;
                cbxLocalidades.DisplayMember = "Localidad";
                cbxLocalidades.ValueMember = "idLocalidades";
            }
            else
            {
                cbxLocalidades.DataSource = tabla;
            }
        }
        public void Categorias()
        {
            try
            {
                Conexion.Conectarse();
                DataTable tabla = new DataTable();
                comando = "select idcategorias, nombre from categorias where clase='a'";
                Conexion.Ejecutar(comando, ref tabla);
                Conexion.Desconectarse();
                cbxCategorias.DataSource = tabla;
                cbxCategorias.DisplayMember = "Nombre";
                cbxCategorias.ValueMember = "idcategorias";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            BuscarClientes id = new BuscarClientes("");
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxID.Text = id.regresar.valXn;
            }
            tbxID.Focus();
            tbxID_Leave(sender,e);
            tbxVendedor_Leave(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxVendedor.Text = id.regresar.valXn;
            }
            tbxVendedor.Focus();
            tbxVendedor_Leave(sender, e);
            if (tbxVendedor.Text != "")
            {

                cbxCategorias.Focus();

            }
        }

        public void NombreVendedor()
        {
            try
            {
                Conexion.Conectarse();
                if (tbxVendedor.Text != "")
                {
                    codigoV = 0;

                    DataTable tabla = new DataTable();
                    comando = "SELECT * FROM empleados WHERE id_empleado=" + tbxVendedor.Text;
                    Conexion.Ejecutar(comando, ref tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        DataRow fila = tabla.Rows[0];
                        tbxNVendedor.Text = fila[1].ToString() + " " + fila[2].ToString() + " " + fila[3].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Código de vendedor no existe");
                        tbxVendedor.Text = "";
                        tbxNVendedor.Text = "";
                        tbxVendedor.Focus();
                    }
                }
                Conexion.Desconectarse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tbxID_KeyDown(object sender, KeyEventArgs e)
        {

        }
      
        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Está cambiando de cliente, todos los cambios no \nguardados se perderán. \n\n ¿Aún así desea continuar?", "Cambio de vendedor", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                tbxNombre.ReadOnly = false;
                dtpFechaIngreso.Enabled = true;
                CodigoClienteSugerido();
                Limpiar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Está cambiando de vendedor, todos los cambios no \nguardados se perderán. \n\n ¿Aún así desea continuar?", "Cambio de vendedor", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
               tbxVendedor.ReadOnly=false;
               tbxVendedor.Focus();
            }
        }
       

        private void tbxNombre_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void tbxDomicilio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxTelefono.Focus();
            }
        }

        private void tbxTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxVendedor.Focus();
            }
        }

        private void cbxCategorias_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        private void tbxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tbxVendedor.Enabled = true;
            tbxVendedor.Clear();
            tbxNVendedor.Clear();
            button2.Enabled = true;
        }

        private void tbxVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            Rutas rut = new Rutas(Conexion);
            rut.ShowDialog();
            RefrescarRutas();
        }

        private void ModificarClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnGuardarr_Click(object sender, EventArgs e)
        {
            cbxCategorias_SelectedIndexChanged(sender, e);
            DataTable Tabla = new DataTable();
            Conexion.Conectarse();
            string comando = "Select * from Clientes WHERE IDClientes=" + tbxID.Text;
            Conexion.Ejecutar(comando, ref Tabla);
            Conexion.Desconectarse();
            if (Tabla.Rows.Count > 0)
            {
                Actualizar();

            }
            else
            {

                Guardar();
                Limpiar();
                tbxID.Clear();
                tbxID.Focus();
            }
        }
        public void Guardar()
        {
            try
            {
                string DerechoADescuento = "";
                if (cheDerechoADescuento.Checked == true) { DerechoADescuento = "1"; } else { DerechoADescuento = "0"; }
                        string comando = "INSERT INTO Clientes VALUES (" + tbxID.Text + ",'" + tbxNombre.Text
                            + "','" + tbxVendedor.Text + "' ,'" + cbxCategorias.SelectedValue
                            + "' ,'" + DerechoADescuento
                            + "' ,'" + tbxCalle.Text
                            + "' ,'" + tbxNumExterior.Text
                            + "' ,'" + tbxNumInterior.Text
                            + "' ,'" + tbxEstado.Text
                            + "' ,'" + tbxCP.Text
                            + "' ,'" + tbxLocalidad.Text
                            + "' ,'" + tbxMunicipio.Text
                            + "' ,'" + tbxRFC.Text
                            + "' ,'" + tbxTelefono.Text
                            + "' ,'" + tbxE_Mail.Text
                            + "' ," + cbxLocalidades.SelectedValue
                            + "  ,'"+DateTime.Now.ToString("yyyyMMdd")+"')";
                        Conexion.Conectarse();
                        if (Conexion.Ejecutar(comando))
                        {
                            MessageBox.Show("Guardado con éxito");
                        }
                        else
                        {
                            MessageBox.Show("Error!");
                        }
                        Conexion.Desconectarse();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void Actualizar()
        {
            try
            {
                 string DerechoADescuento = "";
                if (cheDerechoADescuento.Checked == true) { DerechoADescuento = "1"; } else { DerechoADescuento = "0"; }
                        Conexion.Conectarse();
                        string comando = string.Format("UPDATE Clientes SET " +
                                         "Nombre='{1}', " +
                                         "Empleados_Id_Empleado='{2}', " +
                                         "Categorias_IdCategorias='{3}', " +
                                         "DerechoADescuento={4}, " +
                                        
                                         "Calle='{6}', " +
                                         "NumExterior='{7}', " +
                                         "NumInterior='{8}', " +
                                         "Estado='{9}', " +
                                         "CP='{10}', " +
                                         "Localidad='{11}', " +
                                         "Municipio='{12}', " +
                                         "RFC='{13}', " +
                                         "Telefono='{14}', " +
                                         "E_Mail='{15}' ," +
                                         "Localidades_idLocalidades={16} "+
                                         "Where idclientes={0} ", 
                                                                tbxID.Text,
                                                                tbxNombre.Text,
                                                                tbxVendedor.Text,
                                                                cbxCategorias.SelectedValue,
                                                                DerechoADescuento,
                                                                1,
                                                                tbxCalle.Text,
                                                                tbxNumExterior.Text,
                                                                tbxNumInterior.Text,
                                                                tbxEstado.Text,
                                                                tbxCP.Text,
                                                                tbxLocalidad.Text,
                                                                tbxMunicipio.Text,
                                                                tbxRFC.Text,
                                                                tbxTelefono.Text,
                                                                tbxE_Mail.Text,
                                                                cbxLocalidades.SelectedValue);
                        if (Conexion.Ejecutar(comando))
                        {
                            MessageBox.Show("Modificado con éxito");
                        }
                        else
                        {
                            MessageBox.Show("Error!");
                        }
                        Conexion.Desconectarse();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void CodigoClienteSugerido()
        {
            DataTable tabla = new DataTable();
            int valor = 0;
            Conexion.Conectarse();
            Conexion.Ejecutar("select * from Clientes", ref tabla);
            if (tabla.Rows.Count > 0)
            {
                Conexion.Ejecutar("select Max(IdClientes) from Clientes", ref tabla);
                DataRow fila = tabla.Rows[0];

                valor = Convert.ToInt32(fila[0].ToString()) + 1;
            }
            else
            {
                valor = 1;
            }
            Conexion.Desconectarse();
            tbxID.Text = valor.ToString();
        }
        public void Limpiar()
        {
            tbxNombre.Clear();
            tbxVendedor.Clear();
            tbxNVendedor.Clear();
            tbxCalle.Clear();
            tbxNumExterior.Clear();
            tbxNumInterior.Clear();
            tbxEstado.Clear();
            tbxCP.Clear();
            tbxLocalidad.Clear();
            tbxMunicipio.Clear();
            tbxRFC.Clear();
            tbxTelefono.Clear();
            tbxE_Mail.Clear();
        }

        private void tbxID_Leave(object sender, EventArgs e)
        {
              if (tbxID.Text != "")
            {
                Limpiar();
                llenarCampos();
                tbxVendedor_Leave(sender, e);
                
            }
       
        }
        public Boolean llenarCampos()
        {
            Boolean bAllOk = false;
            try
            {
                DataTable Tabla = new DataTable();
                Conexion.Conectarse();
                string comando = "Select * from Clientes WHERE IDClientes=" + tbxID.Text;
                Conexion.Ejecutar(comando, ref Tabla);
                Conexion.Desconectarse();
                if (Tabla.Rows.Count > 0)
                {
                    DataRow row = Tabla.Rows[0];
                    tbxNombre.Text = row["Nombre"].ToString();
                    tbxVendedor.Text = row["Empleados_ID_Empleado"].ToString();
                    cbxCategorias.SelectedValue = row["Categorias_IDCategorias"].ToString();
                    if (row["DerechoADescuento"].ToString() == "0") { cheDerechoADescuento.Checked = false; } else { cheDerechoADescuento.Checked = true; }
                    //cbxRutas.Text = row["Rutas_Ruta"].ToString();
                    tbxCalle.Text = row["Calle"].ToString();
                    tbxNumExterior.Text = row["NumExterior"].ToString();
                    tbxNumInterior.Text = row["NumInterior"].ToString();
                    tbxEstado.Text = row["Estado"].ToString();
                    tbxCP.Text = row["CP"].ToString();
                    tbxLocalidad.Text = row["Localidad"].ToString();
                    tbxMunicipio.Text = row["Municipio"].ToString();
                    tbxRFC.Text = row["RFC"].ToString();
                    tbxTelefono.Text = row["Telefono"].ToString();
                    tbxE_Mail.Text = row["E_Mail"].ToString();
                    dtpFechaIngreso.Value = Convert.ToDateTime(row["FechaIngreso"]);
                    dtpFechaIngreso.Enabled = false;
                    RefrescarLocalidades(Convert.ToInt32( row["Localidades_idLocalidades"].ToString()));
                    bAllOk = true;
                    
                }
                else
                {
                    tbxNombre.ReadOnly = false;
                    dtpFechaIngreso.Enabled = true;
                }
               
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            return bAllOk;
        }
        public void RefrescarLocalidades(int Localidad)
        {
            Conexion.Conectarse();
            DataTable tabla = new DataTable();
            Conexion.Ejecutar("SELECT r.IdRuta, r.Ruta FROM Localidades l "+
                "join rutas r  on r.IdRuta=l.Rutas_IdRuta WHERE l.idLocalidades='" + Localidad + "' ", ref tabla);
            Conexion.Desconectarse();
            if (tabla.Rows.Count > 0)
            {
                DataRow row=tabla.Rows[0];
                cbxRutas.SelectedValue = Convert.ToInt32(row["IdRuta"]);
                cbxLocalidades.SelectedValue = Localidad;
            }
           
            
        }
        private void tbxVendedor_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxVendedor.Text != "")
                {
                    DataTable Tabla = new DataTable();
                    Conexion.Conectarse();
                    string comando = "Select * from Empleados WHERE ID_Empleado=" + tbxVendedor.Text;
                    Conexion.Ejecutar(comando, ref Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        DataRow row = Tabla.Rows[0];
                        tbxNVendedor.Text = row["Nombre"].ToString() + " " + row["Apellido_Paterno"].ToString() + " " + row["Apellido_Materno"].ToString();
                    }
                    Conexion.Desconectarse();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnBorar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxID.Text != "")
                {
                    Conexion.Conectarse();
                    string comando = string.Format("DELETE FROM Clientes WHERE IDClientes='{0}' ", tbxID.Text);
                    if (Conexion.Ejecutar(comando))
                    {
                        Limpiar();
                        MessageBox.Show("Eliminado con éxito");
                        tbxID.Clear();
                        tbxID.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No es posible eliminar este cliente.");
                    }
                    Conexion.Desconectarse();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxRutas_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarRutas();
        }

        private void cbxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCategorias.Text == "Abarrotes")
            {
                cheDerechoADescuento.Checked = true;
                cheDerechoADescuento.Enabled = true;
            }
            else
            {
                cheDerechoADescuento.Checked = false;
                cheDerechoADescuento.Enabled = false;                
            }
        }

    }
}

