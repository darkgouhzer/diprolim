namespace Diprolim.MainForm
{
    partial class Pedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pedidos));
            this.rbtnPendientes = new System.Windows.Forms.RadioButton();
            this.rbtnFinalizadas = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dtgPedidos = new System.Windows.Forms.DataGridView();
            this.tbxNCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.btnSelectPedido = new System.Windows.Forms.Button();
            this.rbtCredito = new System.Windows.Forms.RadioButton();
            this.rbtContado = new System.Windows.Forms.RadioButton();
            this.panelTipoCompra = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.colPedidoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidos)).BeginInit();
            this.panelTipoCompra.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnPendientes
            // 
            this.rbtnPendientes.AutoSize = true;
            this.rbtnPendientes.Checked = true;
            this.rbtnPendientes.Location = new System.Drawing.Point(12, 12);
            this.rbtnPendientes.Name = "rbtnPendientes";
            this.rbtnPendientes.Size = new System.Drawing.Size(94, 20);
            this.rbtnPendientes.TabIndex = 0;
            this.rbtnPendientes.TabStop = true;
            this.rbtnPendientes.Text = "Pendientes";
            this.rbtnPendientes.UseVisualStyleBackColor = true;
            this.rbtnPendientes.Click += new System.EventHandler(this.rbtnPendientes_Click);
            // 
            // rbtnFinalizadas
            // 
            this.rbtnFinalizadas.AutoSize = true;
            this.rbtnFinalizadas.Location = new System.Drawing.Point(119, 12);
            this.rbtnFinalizadas.Name = "rbtnFinalizadas";
            this.rbtnFinalizadas.Size = new System.Drawing.Size(95, 20);
            this.rbtnFinalizadas.TabIndex = 1;
            this.rbtnFinalizadas.Text = "Finalizados";
            this.rbtnFinalizadas.UseVisualStyleBackColor = true;
            this.rbtnFinalizadas.Click += new System.EventHandler(this.rbtnFinalizadas_Click);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(226, 12);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(66, 20);
            this.rbtnTodos.TabIndex = 2;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.Click += new System.EventHandler(this.rbtnTodos_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(708, 13);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(101, 77);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo pedido";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dtgPedidos
            // 
            this.dtgPedidos.AllowUserToAddRows = false;
            this.dtgPedidos.AllowUserToDeleteRows = false;
            this.dtgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPedidoID,
            this.colClientes,
            this.colFechaRegistro,
            this.colFechaEntrega,
            this.colStatus});
            this.dtgPedidos.Location = new System.Drawing.Point(12, 98);
            this.dtgPedidos.Name = "dtgPedidos";
            this.dtgPedidos.ReadOnly = true;
            this.dtgPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPedidos.Size = new System.Drawing.Size(797, 532);
            this.dtgPedidos.TabIndex = 4;
            this.dtgPedidos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPedidos_CellDoubleClick);
            // 
            // tbxNCliente
            // 
            this.tbxNCliente.Location = new System.Drawing.Point(210, 69);
            this.tbxNCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCliente.Name = "tbxNCliente";
            this.tbxNCliente.ReadOnly = true;
            this.tbxNCliente.Size = new System.Drawing.Size(286, 22);
            this.tbxNCliente.TabIndex = 191;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(16, 72);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(63, 17);
            this.lblCliente.TabIndex = 190;
            this.lblCliente.Text = "Cliente:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Location = new System.Drawing.Point(109, 69);
            this.tbxCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(93, 22);
            this.tbxCliente.TabIndex = 189;
            this.tbxCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCliente_KeyDown);
            this.tbxCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCliente_KeyPress);
            this.tbxCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxCliente_KeyUp);
            this.tbxCliente.Leave += new System.EventHandler(this.tbxCliente_Leave);
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Location = new System.Drawing.Point(210, 39);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(286, 22);
            this.tbxNVendedor.TabIndex = 194;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblVendedor.Location = new System.Drawing.Point(16, 42);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(83, 17);
            this.lblVendedor.TabIndex = 193;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Location = new System.Drawing.Point(109, 39);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(93, 22);
            this.tbxVendedor.TabIndex = 192;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            this.tbxVendedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyUp);
            this.tbxVendedor.Leave += new System.EventHandler(this.tbxVendedor_Leave);
            // 
            // btnSelectPedido
            // 
            this.btnSelectPedido.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSelectPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectPedido.Location = new System.Drawing.Point(640, 13);
            this.btnSelectPedido.Name = "btnSelectPedido";
            this.btnSelectPedido.Size = new System.Drawing.Size(169, 77);
            this.btnSelectPedido.TabIndex = 195;
            this.btnSelectPedido.Text = "Cargar pedido seleccionado";
            this.btnSelectPedido.UseVisualStyleBackColor = false;
            this.btnSelectPedido.Visible = false;
            this.btnSelectPedido.Click += new System.EventHandler(this.btnSelectPedido_Click);
            // 
            // rbtCredito
            // 
            this.rbtCredito.AutoSize = true;
            this.rbtCredito.Location = new System.Drawing.Point(7, 57);
            this.rbtCredito.Name = "rbtCredito";
            this.rbtCredito.Size = new System.Drawing.Size(69, 20);
            this.rbtCredito.TabIndex = 226;
            this.rbtCredito.Text = "Crédito";
            this.rbtCredito.UseVisualStyleBackColor = true;
            // 
            // rbtContado
            // 
            this.rbtContado.AutoSize = true;
            this.rbtContado.Checked = true;
            this.rbtContado.Location = new System.Drawing.Point(7, 28);
            this.rbtContado.Name = "rbtContado";
            this.rbtContado.Size = new System.Drawing.Size(77, 20);
            this.rbtContado.TabIndex = 225;
            this.rbtContado.TabStop = true;
            this.rbtContado.Text = "Contado";
            this.rbtContado.UseVisualStyleBackColor = true;
            // 
            // panelTipoCompra
            // 
            this.panelTipoCompra.BackColor = System.Drawing.SystemColors.Control;
            this.panelTipoCompra.Controls.Add(this.label1);
            this.panelTipoCompra.Controls.Add(this.rbtContado);
            this.panelTipoCompra.Controls.Add(this.rbtCredito);
            this.panelTipoCompra.Location = new System.Drawing.Point(503, 12);
            this.panelTipoCompra.Name = "panelTipoCompra";
            this.panelTipoCompra.Size = new System.Drawing.Size(131, 80);
            this.panelTipoCompra.TabIndex = 227;
            this.panelTipoCompra.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 227;
            this.label1.Text = "Tipo de compra";
            // 
            // colPedidoID
            // 
            this.colPedidoID.HeaderText = "Folio";
            this.colPedidoID.Name = "colPedidoID";
            this.colPedidoID.ReadOnly = true;
            // 
            // colClientes
            // 
            this.colClientes.HeaderText = "Cliente";
            this.colClientes.Name = "colClientes";
            this.colClientes.ReadOnly = true;
            this.colClientes.Width = 300;
            // 
            // colFechaRegistro
            // 
            this.colFechaRegistro.HeaderText = "Fecha Registro";
            this.colFechaRegistro.Name = "colFechaRegistro";
            this.colFechaRegistro.ReadOnly = true;
            // 
            // colFechaEntrega
            // 
            this.colFechaEntrega.HeaderText = "Fecha Entrega";
            this.colFechaEntrega.Name = "colFechaEntrega";
            this.colFechaEntrega.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Estatus";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(601, 13);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(101, 77);
            this.btnEditar.TabIndex = 228;
            this.btnEditar.Text = "Editar pedido";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 642);
            this.Controls.Add(this.panelTipoCompra);
            this.Controls.Add(this.btnSelectPedido);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.tbxNCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.tbxCliente);
            this.Controls.Add(this.dtgPedidos);
            this.Controls.Add(this.rbtnTodos);
            this.Controls.Add(this.rbtnFinalizadas);
            this.Controls.Add(this.rbtnPendientes);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedidos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pedidos_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidos)).EndInit();
            this.panelTipoCompra.ResumeLayout(false);
            this.panelTipoCompra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnPendientes;
        private System.Windows.Forms.RadioButton rbtnFinalizadas;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dtgPedidos;
        private System.Windows.Forms.TextBox tbxNCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Button btnSelectPedido;
        private System.Windows.Forms.RadioButton rbtCredito;
        private System.Windows.Forms.RadioButton rbtContado;
        private System.Windows.Forms.Panel panelTipoCompra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedidoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Button btnEditar;
    }
}