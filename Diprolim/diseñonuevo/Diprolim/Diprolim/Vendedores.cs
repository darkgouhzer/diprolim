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
    public partial class ModificarEmpleado : Form
    {
        Inventarios.DBMS_Unico Conexion;
        public ModificarEmpleado(Inventarios.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
            tiposPuestos();
            SugerirCodigoVendedor();
        }
        public void SugerirCodigoVendedor()
        {
            DataTable tabla = new DataTable();
            int valor = 0;
            Conexion.Conectarse();
            Conexion.Ejecutar("select * from Empleados", ref tabla);
            if (tabla.Rows.Count > 0)
            {
                Conexion.Ejecutar("select Max(id_empleado) from Empleados", ref tabla);
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
        public void tiposPuestos()
        {
            Conexion.Conectarse();
            DataTable tbl = new DataTable();
            Conexion.Ejecutar("select idPuestos, nombre from Puestos", ref tbl);
            if (tbl.Rows.Count > 0)
            {
                cbxPuestos.DataSource = tbl;
                cbxPuestos.DisplayMember = "nombre";
                cbxPuestos.ValueMember = "idPuestos";
            }
            Conexion.Desconectarse();
        }
        int valPuesto = 0;
        private void tbxID_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbxNombre.Focus();
            }
        }
        private void tbxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void tbxNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxAPaterno.Focus();
            }
        }


        private void tbxAPaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxAMaterno.Focus();
            }
        }


        private void tbxAMaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxTelefono.Focus();
            }
        }

        private void cbxSexo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpFNacimiento.Focus();
            }
        }

        private void dtpFNacimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxPuestos.Focus();
            }
        }

        private void tbxPuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               tbxLimite.Focus();
            }
        }

        private void tbxPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            BuscarVendedor id = new BuscarVendedor();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxID.Text = id.regresar.valXn;
            }
            tbxID_Leave(sender, e);
            
        }

        public void resetControles()
        {
            tbxID.Clear();
            tbxID.Enabled = true;
            tbxNombre.Clear();
            tbxAPaterno.Clear();
            tbxAMaterno.Clear();
            btnSV.Enabled = true;
            tbxTelefono.Clear();
            tbxLimite.Clear();
        }
        DialogResult result;
        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {

            Limpiar();
            SugerirCodigoVendedor();
            tbxID_Leave(sender, e);
           
        }

        private void tbxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {

                e.Handled = true;

            }
        }

        private void tbxTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxSexo.Focus();
            }
        }

        private void tbxLimite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxLimiteCredito.Focus();
            }
        }

        private void tbxLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxLimite.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void btnNPuesto_Click(object sender, EventArgs e)
        {
            Puestos pt = new Puestos();
            pt.ShowDialog();
            tiposPuestos();
            cbxPuestos.SelectedValue = valPuesto;
        }

        private void tbxLimiteCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxLimiteCredito.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxLimiteCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
            }
        }
        public void Guardar()
        {
            try
            {
                if (tbxLimite.Text == ".")
                {
                    MessageBox.Show("Verifique el limite de vendedor");
                }
                else
                {
                    string comando = "INSERT INTO Empleados " +
                        "(id_empleado, nombre, apellido_paterno, apellido_materno, sexo, fecha_nacimiento," +
                        " Puestos_idPuestos, limite_inv, limite_credito, Calle, NumExterior," +
                        " NumInterior, Estado, Localidad, Municipio, Telefono, E_Mail, FechaIngreso, Status ) " +
                        " VALUES (" + tbxID.Text + ",'" + tbxNombre.Text
                            + "','" + tbxAPaterno.Text + "' ,'" + tbxAMaterno.Text
                            + "' ,'" + cbxSexo.SelectedIndex
                            + "' ,'" + dtpFNacimiento.Value.ToString("yyyyMMdd")
                            + "' ,'" + cbxPuestos.SelectedValue
                            + "' ,'" + tbxLimite.Text
                            + "' ,'" + tbxLimiteCredito.Text
                            + "' ,'" + tbxCalle.Text
                            + "' ,'" + tbxNumExterior.Text
                            + "' ,'" + tbxNumInterior.Text
                            + "' ,'" + tbxEstado.Text
                            + "' ,'" + tbxLocalidad.Text
                            + "' ,'" + tbxMunicipio.Text
                            + "' ,'" + tbxTelefono.Text
                            + "' ,'" + tbxE_Mail.Text
                            + "' ,'" + dtpFNacimiento.Value.ToString("yyyyMMdd")
                            + "' ,'" + cbxStatus.Text + "')";
                        Conexion.Conectarse();
                        if(Conexion.Ejecutar(comando))
                        {
                            MessageBox.Show("Guardado con éxito");
                        }
                        else
                        {
                            MessageBox.Show("Error!");
                        }
                        Conexion.Desconectarse();
                }
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
                if (tbxLimite.Text == ".")
                {
                    MessageBox.Show("Verifique el limite de vendedor");
                }
                else
                {
                    if (tbxLimite.Text != "" && tbxNombre.Text != "" && tbxAPaterno.Text != "" && tbxAMaterno.Text != "" && tbxTelefono.Text != "" && cbxSexo.Text != "" && dtpFNacimiento.Text != "" && cbxPuestos.Text != "")
                    {
                        Conexion.Conectarse();
                        string comando = string.Format("UPDATE Empleados SET " +
                                         "Nombre='{1}', " +
                                         "apellido_paterno='{2}', " +
                                         "apellido_materno='{3}', " +
                                         "Sexo={4}, " +
                                         "Fecha_Nacimiento='{5}', " +
                                         "Puestos_IdPuestos={6}, " +
                                         "limite_inv='{7}', " +
                                         "limite_credito='{8}', " +
                                         "Calle='{9}', " +
                                         "NumExterior='{10}', " +
                                         "NumInterior='{11}', " +
                                         "Estado='{12}', " +
                                         "Localidad='{13}', " +
                                         "Municipio='{14}', " +
                                         "Telefono='{15}', " +
                                         "E_Mail='{16}', " +
                                         "Status='{17}' " +
                                         "Where Id_Empleado={0} ", tbxID.Text,
                                                         tbxNombre.Text,
                                                         tbxAPaterno.Text,
                                                         tbxAMaterno.Text,
                                                         cbxSexo.SelectedIndex,
                                                         dtpFNacimiento.Value.ToString("yyyyMMdd"),
                                                         cbxPuestos.SelectedValue,
                                                         tbxLimite.Text,
                                                         tbxLimiteCredito.Text,
                                                         tbxCalle.Text,
                                                         tbxNumExterior.Text,
                                                         tbxNumInterior.Text,
                                                         tbxEstado.Text,
                                                         tbxLocalidad.Text,
                                                         tbxMunicipio.Text,
                                                         tbxTelefono.Text,
                                                         tbxE_Mail.Text,
                                                         cbxStatus.Text);
                        if(Conexion.Ejecutar(comando))
                        {
                            MessageBox.Show("Modificado con éxito");
                        }
                        else
                        {
                            MessageBox.Show("Error!");
                        }
                        Conexion.Desconectarse();
                       
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void btnGuardarr_Click(object sender, EventArgs e)
        {
             DataTable Tabla = new DataTable();
                        Conexion.Conectarse();
                        string comando = "Select * from Empleados WHERE Id_empleado="+tbxID.Text;
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
                            SugerirCodigoVendedor();

                        }
        }

        private void tbxID_Leave(object sender, EventArgs e)
        {
            if (tbxID.Text != "")
            {
                Limpiar();
                llenarCampos();
            }
        }
        public Boolean llenarCampos()
        {
            Boolean bAllOk = false;
            try
            {
                        DataTable Tabla = new DataTable();
                        Conexion.Conectarse();
                        string comando = "Select * from Empleados WHERE Id_empleado="+tbxID.Text;
                        Conexion.Ejecutar(comando, ref Tabla);
                        if(Tabla.Rows.Count>0)
                        {
                            DataRow row = Tabla.Rows[0];
                            tbxNombre.Text = row["Nombre"].ToString();
                            tbxNombre.ReadOnly = true;
                            tbxAPaterno.Text = row["Apellido_Paterno"].ToString();
                            tbxAPaterno.ReadOnly = true;
                            tbxAMaterno.Text = row["Apellido_Materno"].ToString();
                            tbxAMaterno.ReadOnly = true;
                            cbxSexo.SelectedIndex = Convert.ToInt32(row["Sexo"]);
                            cbxSexo.Enabled = false;
                            dtpFNacimiento.Value = Convert.ToDateTime(row["Fecha_Nacimiento"]);
                            dtpFNacimiento.Enabled = false;
                            cbxPuestos.SelectedValue = Convert.ToInt32(row["Puestos_IdPuestos"]);
                            tbxLimite.Text = row["Limite_inv"].ToString();
                            tbxLimiteCredito.Text = row["Limite_Credito"].ToString();
                            tbxCalle.Text = row["Calle"].ToString();
                            tbxNumExterior.Text = row["NumExterior"].ToString();
                            tbxNumInterior.Text = row["NumInterior"].ToString();
                            tbxEstado.Text = row["Estado"].ToString();
                            tbxLocalidad.Text = row["Localidad"].ToString();
                            tbxMunicipio.Text = row["Municipio"].ToString();
                            tbxTelefono.Text = row["Telefono"].ToString();
                            tbxE_Mail.Text = row["E_Mail"].ToString();
                            dtpFechaIngreso.Value = Convert.ToDateTime(row["FechaIngreso"]);
                            dtpFechaIngreso.Enabled = false;
                            cbxStatus.Text = row["Status"].ToString();
                            bAllOk = true;
                        }
                        else
                        {
                            tbxNombre.ReadOnly = false;
                            tbxAPaterno.ReadOnly = false;
                            tbxAMaterno.ReadOnly = false;
                            cbxSexo.Enabled = true;
                            dtpFNacimiento.Enabled = true;
                            dtpFechaIngreso.Enabled = true;
                            dtpFechaIngreso.Value = DateTime.Now;
                        }
                        Conexion.Desconectarse();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            return bAllOk;
        }

        private void btnBorar_Click(object sender, EventArgs e)
        {
            try
            {
                   if(tbxID.Text!="")
                   {
                       Boolean bAllOK = false;
                        Conexion.Conectarse();
                        string comando = string.Format("DELETE FROM Empleados WHERE Id_Empleado='{0}' ", tbxID.Text);
                       bAllOK=Conexion.Ejecutar(comando);
                       Conexion.Desconectarse();
                        if (bAllOK)
                        {
                            Limpiar();
                            MessageBox.Show("Eliminado con éxito");
                            tbxID.Clear();
                            tbxID.Focus();
                            SugerirCodigoVendedor();

                        }
                        else
                        {
                            MessageBox.Show("Error!");
                        }
                        
                    
                   }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void Limpiar()
        {
            tbxNombre.Clear();
            tbxAPaterno.Clear(); 
            tbxAMaterno.Clear();
            tbxLimite.Clear();
            tbxLimiteCredito.Clear();
            tbxCalle.Clear();
            tbxNumExterior.Clear();
            tbxNumInterior.Clear();
            tbxEstado.Clear();
            tbxLocalidad.Clear();
            tbxMunicipio.Clear();
            tbxTelefono.Clear();
            tbxE_Mail.Clear();
           
        }

        private void ModificarEmpleado_Load(object sender, EventArgs e)
        {
            cbxStatus.SelectedIndex = 1;
        }
    }
}
