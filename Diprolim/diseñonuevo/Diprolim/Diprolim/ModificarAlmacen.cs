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
    public partial class ModificarAlmacen : Form
    {
        conexion conn = new conexion();
        Inventarios.DBMS_Unico Conexion;
        public ModificarAlmacen(Inventarios.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
        }

        private void tbxID_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
               
            }
            
        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
              

            
        }

        private void tbxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            ConsultarAlmacen id = new ConsultarAlmacen(Conexion);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxID.Text = id.valorCodigo;
            }
            tbxID.Focus();
            tbxID_Leave(sender, e);
          
        }

        private void tbxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        private void tbxIniciales_Leave(object sender, EventArgs e)
        {
            tbxIniciales.Text = tbxIniciales.Text.ToUpper();
        }

        private void tbxIniciales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardarr_Click(object sender, EventArgs e)
        {
            DataTable Tabla = new DataTable();
            Conexion.Conectarse();
            string comando = "Select * from Almacenes WHERE IDAlmacen=" + tbxID.Text;
            Conexion.Ejecutar(comando, ref Tabla);
            Conexion.Desconectarse();
            if (Tabla.Rows.Count > 0)
            {
                Actualizar();
            }
            else
            {
                Guardar();
                Limpear();
                tbxID.Clear();
                tbxID.Focus();
            }
        }
        public void Limpear()
        {
            tbxNombre.Clear();
            tbxIniciales.Clear();
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
        public void Guardar()
        {
            try
            {
                Boolean Valor;
                if (chkbLocal.Checked) { Valor = true; } else { Valor = false; }
                string comando = "INSERT INTO Almacenes VALUES (" + tbxID.Text + ",'" + tbxNombre.Text
                    + "','" + tbxIniciales.Text + "' ,'" + Valor
                    + "' ,'" + tbxCalle.Text
                    + "' ,'" + tbxNumExterior.Text
                    + "' ,'" + tbxNumInterior.Text
                    + "' ,'" + tbxEstado.Text
                    + "' ,'" + tbxCP.Text
                    + "' ,'" + tbxLocalidad.Text
                    + "' ,'" + tbxMunicipio.Text
                    + "' ,'" + tbxRFC.Text
                    + "' ,'" + tbxTelefono.Text
                    + "' ,'" + tbxE_Mail.Text + "')";
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
                String Valor;
                if (chkbLocal.Checked) { Valor = "true"; } else { Valor = "false"; }
                Conexion.Conectarse();
                string comando = string.Format("UPDATE Almacenes SET " +
                                 "Nombre='{1}', " +
                                 "Iniciales='{2}', " +
                                 "Origen={3}, " +
                                 "Calle='{4}', " +
                                 "NumExterior='{5}', " +
                                 "NumInterior='{6}', " +
                                 "Estado='{7}', " +
                                 "CP='{8}', " +
                                 "Localidad='{9}', " +
                                 "Municipio='{10}', " +
                                 "RFC='{11}', " +
                                 "Telefono='{12}', " +
                                 "E_Mail='{13}' " +
                                 "Where IDAlmacen={0} ",
                                                        tbxID.Text,
                                                        tbxNombre.Text,
                                                        tbxIniciales.Text,
                                                        Valor,
                                                        tbxCalle.Text,
                                                        tbxNumExterior.Text,
                                                        tbxNumInterior.Text,
                                                        tbxEstado.Text,
                                                        tbxCP.Text,
                                                        tbxLocalidad.Text,
                                                        tbxMunicipio.Text,
                                                        tbxRFC.Text,
                                                        tbxTelefono.Text,
                                                        tbxE_Mail.Text);
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

        private void tbxID_Leave(object sender, EventArgs e)
        {
            if (tbxID.Text != "")
            {
                Limpear();
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
                string comando = "Select * from Almacenes WHERE IDAlmacen=" + tbxID.Text;
                Conexion.Ejecutar(comando, ref Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    DataRow row = Tabla.Rows[0];
                    tbxNombre.Text = row["Nombre"].ToString();
                    tbxIniciales.Text = row["Iniciales"].ToString();
                    if (row["Origen"].ToString() == "True") { chkbLocal.Checked = true; } else { chkbLocal.Checked = false; }
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
                    bAllOk = true;
                }
                Conexion.Desconectarse();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            return bAllOk;
        }
    
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
