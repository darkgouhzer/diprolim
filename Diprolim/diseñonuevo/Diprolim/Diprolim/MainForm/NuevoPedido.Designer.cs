namespace Diprolim.MainForm
{
    partial class NuevoPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoPedido));
            this.tbxNCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.tbxNProducto = new System.Windows.Forms.TextBox();
            this.tbxProducto = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.dtgProductos = new System.Windows.Forms.DataGridView();
            this.colCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnFinalizarPedido = new System.Windows.Forms.Button();
            this.panelTipoPrecio = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.rbtnGeneral = new System.Windows.Forms.RadioButton();
            this.rbtnAbarrotes = new System.Windows.Forms.RadioButton();
            this.rbtnDistribuidor = new System.Windows.Forms.RadioButton();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos)).BeginInit();
            this.panelTipoPrecio.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxNCliente
            // 
            this.tbxNCliente.Location = new System.Drawing.Point(217, 13);
            this.tbxNCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCliente.Name = "tbxNCliente";
            this.tbxNCliente.ReadOnly = true;
            this.tbxNCliente.Size = new System.Drawing.Size(286, 22);
            this.tbxNCliente.TabIndex = 188;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(23, 16);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(63, 17);
            this.lblCliente.TabIndex = 187;
            this.lblCliente.Text = "Cliente:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Location = new System.Drawing.Point(116, 13);
            this.tbxCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(93, 22);
            this.tbxCliente.TabIndex = 183;
            this.tbxCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCliente_KeyDown);
            this.tbxCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCliente_KeyPress);
            this.tbxCliente.Leave += new System.EventHandler(this.tbxCliente_Leave);
            // 
            // tbxNProducto
            // 
            this.tbxNProducto.Location = new System.Drawing.Point(216, 43);
            this.tbxNProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNProducto.Name = "tbxNProducto";
            this.tbxNProducto.ReadOnly = true;
            this.tbxNProducto.Size = new System.Drawing.Size(286, 22);
            this.tbxNProducto.TabIndex = 185;
            // 
            // tbxProducto
            // 
            this.tbxProducto.Location = new System.Drawing.Point(116, 43);
            this.tbxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProducto.Name = "tbxProducto";
            this.tbxProducto.Size = new System.Drawing.Size(92, 22);
            this.tbxProducto.TabIndex = 184;
            this.tbxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxProducto_KeyDown);
            this.tbxProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxProducto_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.Location = new System.Drawing.Point(23, 46);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(63, 17);
            this.lblCodigo.TabIndex = 182;
            this.lblCodigo.Text = "Código:";
            // 
            // dtgProductos
            // 
            this.dtgProductos.AllowUserToAddRows = false;
            this.dtgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoProducto,
            this.colDescripcion,
            this.colCantidad,
            this.colPrecio,
            this.colTotal,
            this.colTipoPrecio});
            this.dtgProductos.Location = new System.Drawing.Point(12, 106);
            this.dtgProductos.Name = "dtgProductos";
            this.dtgProductos.ReadOnly = true;
            this.dtgProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProductos.Size = new System.Drawing.Size(798, 381);
            this.dtgProductos.TabIndex = 189;
            this.dtgProductos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtgProductos_RowsAdded);
            this.dtgProductos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtgProductos_RowsRemoved);
            // 
            // colCodigoProducto
            // 
            this.colCodigoProducto.HeaderText = "Código";
            this.colCodigoProducto.Name = "colCodigoProducto";
            this.colCodigoProducto.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 300;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colTipoPrecio
            // 
            this.colTipoPrecio.HeaderText = "TipoPrecio";
            this.colTipoPrecio.Name = "colTipoPrecio";
            this.colTipoPrecio.ReadOnly = true;
            this.colTipoPrecio.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(735, 502);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 75);
            this.btnGuardar.TabIndex = 217;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::Diprolim.Properties.Resources.plus;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Location = new System.Drawing.Point(219, 69);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 30);
            this.btnAdd.TabIndex = 219;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.Location = new System.Drawing.Point(116, 73);
            this.tbxCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.Size = new System.Drawing.Size(92, 22);
            this.tbxCantidad.TabIndex = 218;
            this.tbxCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCantidad_KeyDown);
            this.tbxCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidad_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.Location = new System.Drawing.Point(23, 76);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(77, 17);
            this.lblCantidad.TabIndex = 220;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // btnFinalizarPedido
            // 
            this.btnFinalizarPedido.BackColor = System.Drawing.Color.White;
            this.btnFinalizarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarPedido.Location = new System.Drawing.Point(26, 502);
            this.btnFinalizarPedido.Name = "btnFinalizarPedido";
            this.btnFinalizarPedido.Size = new System.Drawing.Size(95, 75);
            this.btnFinalizarPedido.TabIndex = 222;
            this.btnFinalizarPedido.Text = "Finalizar pedido";
            this.btnFinalizarPedido.UseVisualStyleBackColor = false;
            this.btnFinalizarPedido.Click += new System.EventHandler(this.btnFinalizarPedido_Click);
            // 
            // panelTipoPrecio
            // 
            this.panelTipoPrecio.BackColor = System.Drawing.Color.White;
            this.panelTipoPrecio.Controls.Add(this.label11);
            this.panelTipoPrecio.Controls.Add(this.rbtnGeneral);
            this.panelTipoPrecio.Controls.Add(this.rbtnAbarrotes);
            this.panelTipoPrecio.Controls.Add(this.rbtnDistribuidor);
            this.panelTipoPrecio.Location = new System.Drawing.Point(510, 12);
            this.panelTipoPrecio.Name = "panelTipoPrecio";
            this.panelTipoPrecio.Size = new System.Drawing.Size(300, 53);
            this.panelTipoPrecio.TabIndex = 223;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(77, 4);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 16);
            this.label11.TabIndex = 170;
            this.label11.Text = "Tipo de precio";
            // 
            // rbtnGeneral
            // 
            this.rbtnGeneral.AutoSize = true;
            this.rbtnGeneral.Checked = true;
            this.rbtnGeneral.Location = new System.Drawing.Point(6, 24);
            this.rbtnGeneral.Name = "rbtnGeneral";
            this.rbtnGeneral.Size = new System.Drawing.Size(74, 20);
            this.rbtnGeneral.TabIndex = 167;
            this.rbtnGeneral.TabStop = true;
            this.rbtnGeneral.Text = "General";
            this.rbtnGeneral.UseVisualStyleBackColor = true;
            // 
            // rbtnAbarrotes
            // 
            this.rbtnAbarrotes.AutoSize = true;
            this.rbtnAbarrotes.Location = new System.Drawing.Point(193, 24);
            this.rbtnAbarrotes.Name = "rbtnAbarrotes";
            this.rbtnAbarrotes.Size = new System.Drawing.Size(85, 20);
            this.rbtnAbarrotes.TabIndex = 169;
            this.rbtnAbarrotes.Text = "Abarrotes";
            this.rbtnAbarrotes.UseVisualStyleBackColor = true;
            // 
            // rbtnDistribuidor
            // 
            this.rbtnDistribuidor.AutoSize = true;
            this.rbtnDistribuidor.Location = new System.Drawing.Point(93, 24);
            this.rbtnDistribuidor.Name = "rbtnDistribuidor";
            this.rbtnDistribuidor.Size = new System.Drawing.Size(94, 20);
            this.rbtnDistribuidor.TabIndex = 168;
            this.rbtnDistribuidor.Text = "Distribuidor";
            this.rbtnDistribuidor.UseVisualStyleBackColor = true;
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.CustomFormat = "dd/MMMM/yyyy";
            this.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaEntrega.Location = new System.Drawing.Point(632, 73);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(178, 22);
            this.dtpFechaEntrega.TabIndex = 224;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblFechaEntrega.Location = new System.Drawing.Point(507, 78);
            this.lblFechaEntrega.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(118, 17);
            this.lblFechaEntrega.TabIndex = 225;
            this.lblFechaEntrega.Text = "Fecha entrega:";
            // 
            // NuevoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 590);
            this.Controls.Add(this.lblFechaEntrega);
            this.Controls.Add(this.dtpFechaEntrega);
            this.Controls.Add(this.panelTipoPrecio);
            this.Controls.Add(this.btnFinalizarPedido);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbxCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtgProductos);
            this.Controls.Add(this.tbxNCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.tbxCliente);
            this.Controls.Add(this.tbxNProducto);
            this.Controls.Add(this.tbxProducto);
            this.Controls.Add(this.lblCodigo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevoPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Pedido";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NuevoPedido_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos)).EndInit();
            this.panelTipoPrecio.ResumeLayout(false);
            this.panelTipoPrecio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxNCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.TextBox tbxNProducto;
        private System.Windows.Forms.TextBox tbxProducto;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.DataGridView dtgProductos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnFinalizarPedido;
        private System.Windows.Forms.Panel panelTipoPrecio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbtnGeneral;
        private System.Windows.Forms.RadioButton rbtnAbarrotes;
        private System.Windows.Forms.RadioButton rbtnDistribuidor;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoPrecio;
    }
}