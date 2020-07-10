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
    public partial class NuevoPedido : Form
    {

        CArticulos objCArticulos;
        CPedidos objCPedidos = new CPedidos();
        Boolean CambiosPendientes = false, SelectPedido = false;
        
        public NuevoPedido(int PedidoID)
        {
            InitializeComponent();
            objCPedidos.PedidoID = PedidoID;
            btnFinalizarPedido.Visible = PedidoID > 0 ? true : false;
            if (PedidoID > 0)
            {
                ObtenerPedidoEditar(PedidoID);                
            }            
        }

        public NuevoPedido(int PedidoID, Boolean SelectPedido)
        {
            InitializeComponent();
            this.SelectPedido = SelectPedido;
            SeleccionPedido();
            objCPedidos.PedidoID = PedidoID;
            if (PedidoID > 0)
            {
                ObtenerPedidoEditar(PedidoID);
            }
        }

        private void SeleccionPedido()
        {
            this.dtpFechaEntrega.Enabled = this.panelTipoPrecio.Visible = !this.SelectPedido;
            tbxCantidad.ReadOnly = tbxProducto.ReadOnly = tbxCliente.ReadOnly = this.SelectPedido;
            btnFinalizarPedido.Visible = btnGuardar.Visible = false;


        }
        private void ObtenerPedidoEditar(int PedidoID)
        {
            PedidosBO objPedidosBO = new PedidosBO();
            ArticuloBO objArticuloBO = new ArticuloBO();
            objCPedidos = objPedidosBO.ObtenerPedido(PedidoID);

            tbxCliente.Text = objCPedidos.ClienteID.ToString();
            dtpFechaEntrega.Value = objCPedidos.FechaPedido;
            ObtenerCliente();
            tbxCliente.ReadOnly = true;
            dtgProductos.Rows.Clear();
            panelTipoPrecio.Enabled = dtpFechaEntrega.Enabled = btnFinalizarPedido.Enabled = 
                btnGuardar.Enabled = dtgProductos.AllowUserToDeleteRows = this.SelectPedido ? !this.SelectPedido: !objCPedidos.Status;
            tbxCantidad.ReadOnly = tbxProducto.ReadOnly = this.SelectPedido || objCPedidos.Status;
            this.Text = this.SelectPedido ?  "Detalle de pedido" :(objCPedidos.Status ? "Pedido finalizado":"Actualizar pedido"); 
            foreach (CPedidosDetalle obj in objCPedidos.PedidosDetalle)
            {
               
                objCArticulos = new CArticulos();
                objCArticulos = objArticuloBO.ObtenerDatosArticulo(obj.CodigoArticulo);
                Double precio = obj.TipoPrecio == TipoPrecio.Calle.ToString() ? objCArticulos.PrecioCalle :
                                    (obj.TipoPrecio == TipoPrecio.Abarrotes.ToString() ? objCArticulos.PrecioAbarrotes : objCArticulos.PrecioDistribuidor);
                dtgProductos.Rows.Add(obj.CodigoArticulo, objCArticulos.Descripcion, obj.Cantidad, precio, obj.Cantidad * precio, obj.TipoPrecio);
            }
            CambiosPendientes = false;
        }

        private void NuevoPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                if (CambiosPendientes)
                {

                    DialogResult result = MessageBox.Show("¿Desea salir sin guardar los cambios?", "Pedido", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }                
            }
            else if(e.KeyCode == Keys.F1)
            {
                if (tbxCliente.Focused)
                {
                    BuscarClientes id = new BuscarClientes();
                    DialogResult dr = id.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxCliente.Text = id.regresar.valXn;
                    }
                    tbxCliente.Focus();

                }
                else if(tbxProducto.Focused)
                {
                    BuscarArticulos objBuscarArticulos = new BuscarArticulos();
                    DialogResult dlg = objBuscarArticulos.ShowDialog();
                    if (dlg == DialogResult.OK)
                    {
                        tbxProducto.Text = objBuscarArticulos.regresar.valXn;
                    }
                }
             
            }
        }

        private void tbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(tbxCliente.Text.Length > 0)
                {
                    ObtenerCliente();
                }
            }
        }

        private void ObtenerCliente()
        {
            ClienteBO objClienteBO = new ClienteBO();
            CClientes objCClientes = new CClientes();

            objCClientes = objClienteBO.ObtenerDatosCliente(Convert.ToInt32(tbxCliente.Text));
            if(objCClientes.IDClientes != 0)
            {
                tbxNCliente.Text = objCClientes.Nombre;
                tbxProducto.Focus();
            }
            else
            {
                tbxCliente.Clear();
                tbxNCliente.Clear();
                MessageBox.Show("El código de cliente no existe.");
            }

        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (tbxProducto.Text.Length > 0)
                {
                    ArticuloBO objArticuloBO = new ArticuloBO();
                    objCArticulos = new CArticulos();

                    objCArticulos = objArticuloBO.ObtenerDatosArticulo(Convert.ToInt32(tbxProducto.Text));

                    tbxNProducto.Text = objCArticulos.Descripcion;
                    tbxCantidad.Focus();
                }
            }
        }

        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbxCantidad.Text.Length > 0 && tbxProducto.Text.Length > 0 && tbxNProducto.Text.Length > 0)
                {                   
                    AgregarProducto();                   
                }
            }
        }

        private void AgregarProducto()
        {
            if (!ValidarProductoAgregado(objCArticulos.Codigo))
            {
                double PrecioProducto = rbtnGeneral.Checked ? objCArticulos.PrecioCalle :
                          (rbtnAbarrotes.Checked ? objCArticulos.PrecioAbarrotes : objCArticulos.PrecioDistribuidor);
                double Cantidad = Convert.ToDouble(tbxCantidad.Text);
                double Total = Cantidad * PrecioProducto;
                String tipoPrecio = (rbtnGeneral.Checked ? TipoPrecio.Calle :
                               (rbtnAbarrotes.Checked ? TipoPrecio.Abarrotes : TipoPrecio.Distribuidor)).ToString();

                dtgProductos.Rows.Add(objCArticulos.Codigo, objCArticulos.Descripcion, Cantidad, PrecioProducto, Total, tipoPrecio);
                tbxProducto.Focus();
                tbxProducto.Clear();
                tbxNProducto.Clear();
                tbxCantidad.Clear();
            }
            else
            {
                MessageBox.Show("Solo se puede agregar una vez un producto.");
            }
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private Boolean ValidarProductoAgregado(int Codigo)
        {
            Boolean bExiste = false;

            foreach(DataGridViewRow row in dtgProductos.Rows)
            {
                if(Convert.ToInt32(row.Cells["colCodigoProducto"].Value) == Codigo)
                {
                    bExiste = true;
                }
            }

            return bExiste;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PedidosBO objPedidosBO = new PedidosBO();    
         
            if(tbxCliente.Text.Length > 0)
            {
                objCPedidos.ClienteID = Convert.ToInt32(tbxCliente.Text);
                objCPedidos.FechaPedido = dtpFechaEntrega.Value;
                objCPedidos.PedidosDetalle = LPedidosDetalle();
                if (objCPedidos.PedidosDetalle.Count > 0)
                {
                    objPedidosBO.GuardarPedido(objCPedidos);
                    MessageBox.Show("El pedido se ha guardado con éxito.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Favor de agregar uno o mas productos para guardar.");
                }
                
            }
            else
            {
                MessageBox.Show("Favor de agregar un cliente antes de guardar.");
            }
            
        }

        private List<CPedidosDetalle> LPedidosDetalle()
        {
            CPedidosDetalle objCPedidosDetalle = new CPedidosDetalle();
            List<CPedidosDetalle> lCPedidosDetalle = new List<CPedidosDetalle>();

            foreach (DataGridViewRow row in dtgProductos.Rows)
            {
                objCPedidosDetalle = new CPedidosDetalle();
                objCPedidosDetalle.CodigoArticulo = Convert.ToInt32(row.Cells["colCodigoProducto"].Value);
                objCPedidosDetalle.TipoPrecio = row.Cells["colTipoPrecio"].Value.ToString();
                objCPedidosDetalle.Cantidad = Convert.ToDouble(row.Cells["colCantidad"].Value);
                lCPedidosDetalle.Add(objCPedidosDetalle);
            }

            return lCPedidosDetalle;
        }

        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            PedidosBO objPedidosBO = new PedidosBO();
            if(objCPedidos.PedidoID > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea finalizar el pedido?", "Finalizar pedido.", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    objPedidosBO.FinalizarPedido(objCPedidos.PedidoID);
                    MessageBox.Show("El pedido se finalizó correctamente.");
                    this.Close();
                }
            
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

        private void tbxProducto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxCantidad.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void dtgProductos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CambiosPendientes = true;
        }

        private void tbxCliente_Leave(object sender, EventArgs e)
        {
            if (tbxCliente.Text.Length > 0)
            {
                ObtenerCliente();
            }
        }

        private void dtgProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CambiosPendientes = true;
        }
    }
}
 