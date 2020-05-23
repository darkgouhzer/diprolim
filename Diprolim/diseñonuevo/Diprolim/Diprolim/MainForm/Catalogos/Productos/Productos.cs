
using Diprolim.MainForm.Catalogos.Productos;
using ReglasNegocios;
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
    public partial class Productos : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        String cmd = "";
        int dep = 1;
        public Productos(UnicaSQL.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
            unidades();
            CodigoProductoSugerido();
            ObtenerFamilias();
        }
        public void CodigoProductoSugerido()
        {
            DataTable tabla = new DataTable();
            int valor = 0;
            Conexion.Conectarse();
            Conexion.Ejecutar("select * from Articulos", ref tabla);
            if (tabla.Rows.Count > 0)
            {
                Conexion.Ejecutar("select Max(Codigo) from Articulos", ref tabla);
                DataRow fila = tabla.Rows[0];

                valor = Convert.ToInt32(fila[0].ToString()) + 1;
            }
            else
            {
                valor = 1;
            }
            Conexion.Desconectarse();
            tbxCodigo.Text = valor.ToString();
        }
        private void btnSP_Click(object sender, EventArgs e)
        {
            BuscarArticulos id = new BuscarArticulos();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCodigo.Text = id.regresar.valXn;
                tbxCodigo.Focus();
            }
            MetodoID();
        }

        public void unidades()
        {
            DataTable tbl = new DataTable();
            Conexion.Conectarse();
            cmd = "SELECT id, nombre FROM unidad_medida";
            Conexion.Ejecutar(cmd, ref tbl);            
            Conexion.Desconectarse();
            if (tbl.Rows.Count > 0)
            {
                cbxUMedida.DataSource = tbl;
                cbxUMedida.DisplayMember = "nombre";
                cbxUMedida.ValueMember = "ID";
            }
            

        }

        public void ObtenerFamilias()
        {
            ArticuloBO objArticuloBO = new ArticuloBO();
            DataTable tblFamilias = new DataTable();

            tblFamilias = objArticuloBO.ObtenerFamilias();
            if (tblFamilias.Rows.Count > 0)
            {
                cbxFamilia.DataSource = tblFamilias;
                cbxFamilia.DisplayMember = "descripcion";
                cbxFamilia.ValueMember = "idfamilias";
            }


        }
        private void tbxCodigo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MetodoID();            
            }
        }
        public void MetodoID()
        {
            if (tbxCodigo.Text != "")
            {
                unidades();
                
                DataTable tbl=new DataTable();
                cmd = "select * from articulos where codigo=" + tbxCodigo.Text;
                Conexion.Conectarse();
                Conexion.Ejecutar(cmd, ref tbl);
                Conexion.Desconectarse();
                if(tbl.Rows.Count>0)
                {
                    DataRow row = tbl.Rows[0];
                    tbxDesc.Text = row[1].ToString();
                    tbxDesc.Tag = row["iddescripcion"].ToString();
                    if(Convert.ToInt32(tbxDesc.Tag) == 0)
                    {
                        this.tbxDesc.BackColor = Color.LightCoral;
                    }else
                    {
                        this.tbxDesc.BackColor = SystemColors.Control;
                    }
                   
                    tbxVMedida.Text = row[4].ToString();
                    cbxUMedida.SelectedValue = Convert.ToInt32(row[5]);
                    tbxPrecioProduccion.Text = row[2].ToString();


                    if (Convert.ToInt32(row[9]) == 1) { rbProductos.Checked = true; }
                    if (Convert.ToInt32(row[9]) == 2) { rbAccesorios.Checked = true; }
                    if (Convert.ToInt32(row[9]) == 3) { rbPapel.Checked = true; }
                    tbxPCalle.Text = row[6].ToString();
                    tbxPAbarrotes.Text = row[7].ToString();
                    tbxPDistribuidor.Text = row[8].ToString();
                    tbxDescuento.Text = row[10].ToString();
                    tbxComision.Text = row[11].ToString();
                    if (Convert.ToInt32(row[12]) == 1)
                    {
                        chkbxComision.Checked = true;
                    }
                    else
                    {
                        chkbxComision.Checked = false;
                    }

                    cbxFamilia.SelectedValue = Convert.ToInt32(row[13]);
                    tbxCodigo.Enabled = false;
                    btnSP.Enabled = false;
                    tbxDesc.Focus();
                }
                else
                {
                    resetControles();
                }
                tbxCodigo.Focus();
            }
        }
        DialogResult result;
        public void resetControles()
        {
            tbxCodigo.Enabled = true;
            btnSP.Enabled = true;
            tbxDesc.Clear();
            tbxVMedida.Clear();
            tbxPrecioProduccion.Clear();           
            tbxPCalle.Clear();
            tbxPAbarrotes.Clear();
            tbxPDistribuidor.Clear();
            rbProductos.Checked = false;
            rbAccesorios.Checked = false;
            rbPapel.Checked = false;
            tbxComision.Clear();
            tbxDescuento.Clear();
            chkbxComision.Checked = false;
            
        }
        private void btnCambiarP_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Se van a limpiar datos de la ventana para cambiar de artículo. \n¿Desea continuar?", "Cambio de articulo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CodigoProductoSugerido();
                resetControles();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tbxVMedida.Text == "." || tbxPrecioProduccion.Text == "." || tbxPCalle.Text == "." || tbxPDistribuidor.Text == "." || tbxPAbarrotes.Text == "." )
            {
                MessageBox.Show("Verifique datos de valor de medida y precios");
            }
            else
            {
                ArticuloBO objArticuloBO = new ArticuloBO();

                if (tbxCodigo.Text != "" && tbxDesc.Text != "" && tbxVMedida.Text != "" && cbxUMedida.Text != "" && tbxPrecioProduccion.Text != "" &&
                                   tbxPCalle.Text != "" && tbxPAbarrotes.Text != "" && tbxPDistribuidor.Text != "" && (rbProductos.Checked || rbAccesorios.Checked || rbPapel.Checked) &&
                                   cbxFamilia.SelectedValue != null)
                {
                    if (rbProductos.Checked) { dep = 1; }
                    if (rbAccesorios.Checked) { dep = 2; }
                    if (rbPapel.Checked) { dep = 3; }

                    string comisionConsig, descuentoCont;
                    int iAplicaComision = 0;
                    if (chkbxComision.Checked) { iAplicaComision = 1; } else { iAplicaComision = 0; }
                    if (tbxDescuento.Text == "")
                    {
                        descuentoCont = "0";
                    }
                    else
                    {
                        descuentoCont = tbxDescuento.Text;
                    }
                    if (tbxComision.Text == "")
                    {
                        comisionConsig = "0";
                    }
                    else
                    {
                        comisionConsig = tbxComision.Text;
                    }

                    if (Convert.ToInt32(tbxDesc.Tag) != 0)
                    {
                        
                        DataTable tbl = new DataTable();
                        Conexion.Conectarse();
                        cmd = "SELECT * FROM articulos WHERE codigo=" + tbxCodigo.Text;
                        Conexion.Ejecutar(cmd, ref tbl);
                       
                        if (tbl.Rows.Count > 0)
                        {
                            if (!objArticuloBO.ValidarExisteDescripcionAGranel(Convert.ToInt32(tbxDesc.Tag), Convert.ToInt32(cbxUMedida.SelectedValue), Convert.ToInt32(tbxVMedida.Text), "UPDATE"))
                            {
                                cmd = "update articulos set descripcion='" + tbxDesc.Text +
                                        "',precioproduccion=" + tbxPrecioProduccion.Text +
                                        " ,valor_medida=" + tbxVMedida.Text +
                                        " ,unidad_medida_id=" + cbxUMedida.SelectedValue +
                                        " ,precio_calle=" + tbxPCalle.Text +
                                        " ,precio_abarrotes=" + tbxPAbarrotes.Text +
                                        " ,precio_distribuidor=" + tbxPDistribuidor.Text +
                                        " ,departamento=" + dep +
                                        " ,descuento=" + descuentoCont +
                                        " ,comision=" + comisionConsig +
                                        " ,aplicacomision=" + iAplicaComision +
                                        " ,familias_idfamilias=" + cbxFamilia.SelectedValue +
                                        " ,iddescripcion=" + tbxDesc.Tag +
                                    " WHERE codigo=" + tbxCodigo.Text;
                                if (Conexion.Ejecutar(cmd))
                                {
                                    MessageBox.Show("Los datos fueron guardados con éxito");
                                    this.tbxDesc.BackColor = SystemColors.Control;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ya existe un producto con esta presentación.");
                            }
                        }
                        else
                        {
                            if (!objArticuloBO.ValidarExisteDescripcionAGranel(Convert.ToInt32(tbxDesc.Tag), Convert.ToInt32(cbxUMedida.SelectedValue), Convert.ToInt32(tbxVMedida.Text), "INSERT"))
                            {
                                cmd = "INSERT INTO articulos values(" + tbxCodigo.Text + ",'" + tbxDesc.Text +
                                    "'," + tbxPrecioProduccion.Text +
                                    ",0, " + tbxVMedida.Text + ", " + cbxUMedida.SelectedValue + " ," + tbxPCalle.Text +
                                    " , " + tbxPAbarrotes.Text + ", " + tbxPDistribuidor.Text + " , " + dep + ", " + descuentoCont + " , "
                                    + comisionConsig + "," + iAplicaComision + "," + cbxFamilia.SelectedValue + "," + tbxDesc.Tag + ")";
                                if (Conexion.Ejecutar(cmd))
                                {
                                    MessageBox.Show("Los datos fueron guardados con éxito");
                                    this.tbxDesc.BackColor = SystemColors.Control;
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Ya existe un producto con esta presentación.");
                            }

                        }

                        Conexion.Desconectarse();

                    }
                    else
                    {
                        MessageBox.Show("Favor de actualizar la descripción");
                    }

                }
                else
                {
                    MessageBox.Show("Llene todos los campos");
                }


            }

        }

       

        private void tbxVMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxVMedida.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void tbxPrecioProduccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxPrecioProduccion.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {

                e.Handled = true;

            }
        }

        private void tbxPCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxPCalle.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxPAbarrotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxPAbarrotes.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void tbxPDistribuidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxPDistribuidor.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
 
        }

        private void tbxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {

                e.Handled = true;

            }
        }

        private void tbxDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbxVMedida.Focus();

            }
        }

        private void tbxVMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cbxUMedida.Focus();

            }
        }

        private void cbxUMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbxPrecioProduccion.Focus();

            }
        }

       

        private void tbxPCalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbxPAbarrotes.Focus();

            }
        }

        private void tbxPAbarrotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbxPDistribuidor.Focus();

            }
        }

       

        private void tbxPDistribuidor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnGuardar.Focus();

            }
        }

        private void tbxPrecioProduccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbxPCalle.Focus();

            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (tbxCodigo.Text != "")
            {
                if (tbxCodigo.Text == "1")
                {
                    tbxCodigo.Text = "1";
                }
                else
                {
                    tbxCodigo.Text = (Convert.ToInt32(tbxCodigo.Text) - 1).ToString();
                }
                MetodoID();
            }
            else
            {
                tbxCodigo.Text = "1";
                MetodoID();
            }
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            if (tbxCodigo.Text != "")
            {
                tbxCodigo.Text = (Convert.ToInt32(tbxCodigo.Text) + 1).ToString();
                MetodoID();
            }
            else
            {
                tbxCodigo.Text = "1";
                MetodoID();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxCodigo.Text.Length > 0)
                {
                    Boolean bAllOk = false;
                    Conexion.Conectarse();
                    cmd = String.Format("DELETE FROM Articulos WHERE Codigo={0}", tbxCodigo.Text);
                    bAllOk = Conexion.Ejecutar(cmd);
                    Conexion.Desconectarse();
                    if (bAllOk)
                    {
                        MessageBox.Show("Producto eliminado con éxito.");
                        resetControles();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Productos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cbxFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEditDescProducto_Click(object sender, EventArgs e)
        {
            BuscarDescripcion objBuscarDescripcion = new BuscarDescripcion();
           
            DialogResult result = objBuscarDescripcion.ShowDialog();

            if(result == DialogResult.OK)
            {
                ArticuloBO objArticuloBO = new ArticuloBO();
                DataTable tblResult = new DataTable();
                tblResult = objArticuloBO.ObtenerDescripcionesProductosById(objBuscarDescripcion.iCodigo);
                tbxDesc.Text = tblResult.Rows[0]["descripcion"].ToString();
                tbxDesc.Tag = tblResult.Rows[0]["iddescripcion"].ToString();

            }
        }
    }
}
