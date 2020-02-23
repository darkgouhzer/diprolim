using Entidades;
using ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Diprolim
{
    public partial class CancelarAbonos : Form
    {
        AbonosBO objAbonosBO = new AbonosBO();
        EmpleadoBO objEmpleadoBO = new EmpleadoBO();
        CEmpleados objCEmpleados = new CEmpleados();
        ClienteBO objClienteBO = new ClienteBO();
        CClientes objCClientes = new CClientes();
        public CancelarAbonos(String sIDVendedor, Int32 iUsuaarioID)
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            tbxVendedor.Text = sIDVendedor;
            ObtenerVendedor();
        }
        public void ObtenerVendedor()
        {
            if (tbxVendedor.Text.Length > 0)
            {
                objCEmpleados = objEmpleadoBO.ObtenerDatosVendedor(Convert.ToInt32(tbxVendedor.Text));
                tbxNVendedor.Text = String.Format("{0} {1} {2}", objCEmpleados.Nombre, objCEmpleados.ApellidoPaterno,
                    objCEmpleados.ApellidoMaterno);
            }         
        }
        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable dtDatos=new DataTable();
            dtDatos = objAbonosBO.ConsultarAbonos(dtpFecha.Value, tbxVendedor.Text, tbxCliente.Text);
            dtgResultados.DataSource = dtDatos;

            foreach (DataGridViewColumn dc in dtgResultados.Columns)
            {
                if (dc.Index.Equals(0))
                {
                    dc.ReadOnly = false;
                }
                else
                {
                    dc.ReadOnly = true;
                }

                if (dc.Name.ToLower() == "Abono".ToLower())
                {
                    dc.DefaultCellStyle.Format = "C2";
                    dc.DisplayIndex = 4;
                }
                if (dc.Name.ToLower() == "fecha".ToLower())
                {
                    dc.DefaultCellStyle.Format = "dd/MM/yyyy";
                    dc.DisplayIndex = dc.DataGridView.ColumnCount - 1;
                }
                if (dc.Name.ToLower() == "descripcion".ToLower())
                {
                    dc.DisplayIndex = 3;
                    dc.Width = 200;
                }
                if (dc.Name.ToLower() == "nombre".ToLower())
                {
                    dc.DisplayIndex = 3;
                    dc.Width = 250;
                }
            }            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgResultados.Rows.Count > 0)
            {
                CorteCajaBO objCorteCajaBO = new CorteCajaBO();
                DateTime objDTUltimoCorte = objCorteCajaBO.ObtenerFechaUltimoCorte();
                Boolean bAllOK = true;
                CCancelaAbonos objCCancelaAbonos;
                List<CCancelaAbonos> lsCCancelaAbonos = new List<CCancelaAbonos>();
                List<DataGridViewRow> lsGridEliminar = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dtgResultados.Rows)
                {
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                    {
                        objCCancelaAbonos = new CCancelaAbonos();
                        if (row.DataGridView.ColumnCount == 5)
                        {
                            objCCancelaAbonos.ClienteID = Convert.ToInt32(row.Cells["ClienteID"].Value);
                            objCCancelaAbonos.Fecha = Convert.ToDateTime(row.Cells["Fecha"].Value);
                        }
                        else if (row.DataGridView.ColumnCount == 7)
                        {
                            objCCancelaAbonos.IDAbonos = Convert.ToInt32(row.Cells["IDAbonos"].Value);
                            objCCancelaAbonos.Fecha = Convert.ToDateTime(row.Cells["Fecha"].Value);
                        }
                        lsCCancelaAbonos.Add(objCCancelaAbonos);
                        lsGridEliminar.Add(row);

                        //if (objDTUltimoCorte > objCCancelaAbonos.Fecha)
                        //{
                        //    bAllOK = false;
                        //    break;
                        //}
                    }
                   
                }
                //if (bAllOK)
                //{
                foreach (DataGridViewRow row in lsGridEliminar)
                {
                    dtgResultados.Rows.Remove(row);
                }
                if (lsCCancelaAbonos.Count > 0)
                {
                    if (lsCCancelaAbonos[0].Fecha.Date == DateTime.Now.Date)
                    {
                        objAbonosBO.CancelarAbono(lsCCancelaAbonos);
                    }
                    else
                    {
                        MessageBox.Show("No es posible eliminar abonos de días anteriores.");
                    }
                }                   
                //}
                //else
                //{
                //    MessageBox.Show("No es posible eliminar abonos hechos antes del último corte.");
                //}
                
            }
        }

        private void CancelarAbonos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
            else if (tbxCliente.Focused)
            {
                if (e.KeyCode == Keys.F1)
                {
                    BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxCliente.Text = id.regresar.valXn;
                    }
                    tbxCliente.Focus();
                }
            }
            else if (tbxVendedor.Focused)
            {
                if (e.KeyCode == Keys.F1)
                {
                    BuscarVendedor id = new BuscarVendedor();
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxVendedor.Text = id.regresar.valXn;
                    }
                    ObtenerVendedor();
                    tbxVendedor.Focus();
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

        private void tbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (tbxCliente.Text.Length > 0)
                {
                    objClienteBO = new ClienteBO();
                    objCClientes = objClienteBO.ObtenerDatosCliente(Convert.ToInt32(tbxCliente.Text));
                    tbxNCliente.Text = String.Format("{0}", objCClientes.Nombre);
                }
                else
                {
                    tbxNCliente.Clear();
                }
            }
        }

        private void tbxCliente_Leave(object sender, EventArgs e)
        {
            if (tbxCliente.Text.Length > 0)
            {
                objClienteBO = new ClienteBO();
                objCClientes = objClienteBO.ObtenerDatosCliente(Convert.ToInt32(tbxCliente.Text));
                tbxNCliente.Text = String.Format("{0}", objCClientes.Nombre);
            }
            else
            {
                tbxNCliente.Clear();
            }
        }
    }
}
