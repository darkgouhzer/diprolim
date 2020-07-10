using Entidades;
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

namespace Diprolim.MainForm
{
    public partial class Pedidos : Form
    {
        Boolean SelectPedido = false;
        public int FolioPedido = 0;
        public int TipoCompra = 0;
        public Pedidos()
        {
            InitializeComponent();
            ObtenerPedidos();
        }

        public Pedidos(Boolean SelectPedido)
        {
            InitializeComponent();
            this.FolioPedido = 0;
            this.SelectPedido = SelectPedido;
            SeleccionPedido();
            ObtenerPedidos();
        }

        private void SeleccionPedido()
        {
            rbtnPendientes.Visible = rbtnTodos.Visible = rbtnFinalizadas.Visible = btnNuevo.Visible = btnEditar.Visible = !this.SelectPedido;
            btnSelectPedido.Visible = this.SelectPedido;
            panelTipoCompra.Visible = this.SelectPedido;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoPedido objNuevoPedido = new NuevoPedido(0);
            objNuevoPedido.ShowDialog();
            ObtenerPedidos();
        }

        private void Pedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ObtenerPedidos()
        {
            PedidosBO objPedidosBO = new PedidosBO();
            String Status;
            int EmpleadoID, ClienteID;
            DataTable dtPedidos = new DataTable();

            Status = rbtnTodos.Checked ? "T" : (rbtnPendientes.Checked ? "P": "F");
            EmpleadoID = tbxVendedor.Text.Length > 0 ? Convert.ToInt32(tbxVendedor.Text) : 0;
            ClienteID = tbxCliente.Text.Length > 0 ? Convert.ToInt32(tbxCliente.Text) : 0;
            dtPedidos = objPedidosBO.ObtenerPedidos(Status, EmpleadoID, ClienteID);
            String statusrow = "";
            dtgPedidos.Rows.Clear();
            foreach (DataRow row in dtPedidos.Rows)
            {
                statusrow = Convert.ToInt32(row["status"]) == 0 ? "Pendiente" : "Finalizado";
                dtgPedidos.Rows.Add(row["idpedidos"], row["nombrecliente"], row["fecharegistro"], row["fechapedido"], statusrow);
            }

        }

        private void rbtnPendientes_Click(object sender, EventArgs e)
        {
            ObtenerPedidos();
        }

        private void rbtnFinalizadas_Click(object sender, EventArgs e)
        {
            ObtenerPedidos();
        }

        private void rbtnTodos_Click(object sender, EventArgs e)
        {
            ObtenerPedidos();
        }
        
        private void tbxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ObtenerVendedor();
                
            }                
        }

        private void tbxVendedor_Leave(object sender, EventArgs e)
        {
            ObtenerVendedor();
            
        }

        private void ObtenerVendedor()
        {
            if (tbxVendedor.Text.Length > 0)
            {
                CEmpleados objCEmpleados = new CEmpleados();
                EmpleadoBO objEmpleadoBO = new EmpleadoBO();
                objCEmpleados = objEmpleadoBO.ObtenerDatosVendedor(Convert.ToInt32(tbxVendedor.Text));
                tbxNVendedor.Text = String.Format("{0} {1} {2}",objCEmpleados.Nombre, objCEmpleados.ApellidoPaterno, objCEmpleados.ApellidoMaterno);
            }else
            {
                tbxNVendedor.Clear();
            }
            ObtenerPedidos();
        }
        
        private void ObtenerCliente()
        {
            if (tbxCliente.Text.Length > 0)
            {
                CClientes objCClientes = new CClientes();
                ClienteBO objClienteBO = new ClienteBO();
                objCClientes = objClienteBO.ObtenerDatosCliente(Convert.ToInt32(tbxCliente.Text));
                tbxNCliente.Text = String.Format("{0}", objCClientes.Nombre);
            }else
            {
                tbxNCliente.Clear();
            }
            ObtenerPedidos();
        }

        private void tbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ObtenerCliente();
            }
        }

        private void tbxCliente_Leave(object sender, EventArgs e)
        {
            ObtenerCliente();
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

        private void tbxCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbxVendedor_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                BuscarVendedor id = new BuscarVendedor();
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxVendedor.Text = id.regresar.valXn;
                    ObtenerVendedor();
                }
            }
           
        }

        private void tbxCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BuscarClientes id = new BuscarClientes(tbxVendedor.Text);
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCliente.Text = id.regresar.valXn;
                    ObtenerCliente();
                }
            }
        }

        private void dtgPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPedidos.Rows.Count > 0 && e.RowIndex > -1)
            {               
                NuevoPedido objNuevoPedido = this.SelectPedido ? new NuevoPedido(Convert.ToInt32(dtgPedidos.Rows[e.RowIndex].Cells[0].Value), this.SelectPedido) : 
                                                                 new NuevoPedido(Convert.ToInt32(dtgPedidos.Rows[e.RowIndex].Cells[0].Value));
                objNuevoPedido.ShowDialog();
                ObtenerPedidos();
            }
            
        }

        private void btnSelectPedido_Click(object sender, EventArgs e)
        {
            if(dtgPedidos.SelectedCells.Count > 0)
            {
                Int32 selectedrowindex = dtgPedidos.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dtgPedidos.Rows[selectedrowindex];
                this.FolioPedido = Convert.ToInt32(selectedRow.Cells["colPedidoID"].Value);
                this.TipoCompra = rbtContado.Checked ? 1 : 2;
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un pedido.");
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        { 

            if(dtgPedidos.Rows.Count > 0){
                Int32 RowIndex = dtgPedidos.SelectedCells[0].RowIndex;
                if (RowIndex > -1)
                {
                    NuevoPedido objNuevoPedido = this.SelectPedido ? new NuevoPedido(Convert.ToInt32(dtgPedidos.Rows[RowIndex].Cells[0].Value), this.SelectPedido) :
                                                                     new NuevoPedido(Convert.ToInt32(dtgPedidos.Rows[RowIndex].Cells[0].Value));
                    objNuevoPedido.ShowDialog();
                    ObtenerPedidos();
                }
            }
            
        }
    }
}
