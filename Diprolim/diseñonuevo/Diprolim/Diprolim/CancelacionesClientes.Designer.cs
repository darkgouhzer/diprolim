namespace Diprolim
{
    partial class CancelacionesClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgClientesProductos = new System.Windows.Forms.DataGridView();
            this.colSeleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSC = new System.Windows.Forms.Button();
            this.tbxNCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.btnSV = new System.Windows.Forms.Button();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxTipoVenta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgClientesProductos
            // 
            this.dtgClientesProductos.AllowUserToAddRows = false;
            this.dtgClientesProductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtgClientesProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgClientesProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientesProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccion,
            this.colCodigo,
            this.tblProducto,
            this.colPrecio,
            this.colCantidad,
            this.colTotal,
            this.colComision,
            this.colIDVenta});
            this.dtgClientesProductos.Location = new System.Drawing.Point(13, 79);
            this.dtgClientesProductos.Margin = new System.Windows.Forms.Padding(4);
            this.dtgClientesProductos.Name = "dtgClientesProductos";
            this.dtgClientesProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgClientesProductos.Size = new System.Drawing.Size(872, 402);
            this.dtgClientesProductos.TabIndex = 66;
            this.dtgClientesProductos.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dtgClientesProductos_SortCompare);
            // 
            // colSeleccion
            // 
            this.colSeleccion.HeaderText = "";
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.Width = 50;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código articulo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 70;
            // 
            // tblProducto
            // 
            this.tblProducto.HeaderText = "Producto";
            this.tblProducto.Name = "tblProducto";
            this.tblProducto.ReadOnly = true;
            this.tblProducto.Width = 250;
            // 
            // colPrecio
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPrecio.HeaderText = "Precio venta";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Unidades vendidas";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colTotal
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 110;
            // 
            // colComision
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.colComision.DefaultCellStyle = dataGridViewCellStyle4;
            this.colComision.HeaderText = "Comisión";
            this.colComision.Name = "colComision";
            this.colComision.ReadOnly = true;
            this.colComision.Width = 90;
            // 
            // colIDVenta
            // 
            this.colIDVenta.HeaderText = "IDVenta";
            this.colIDVenta.Name = "colIDVenta";
            this.colIDVenta.ReadOnly = true;
            this.colIDVenta.Visible = false;
            // 
            // btnSC
            // 
            this.btnSC.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSC.Location = new System.Drawing.Point(206, 40);
            this.btnSC.Margin = new System.Windows.Forms.Padding(5);
            this.btnSC.Name = "btnSC";
            this.btnSC.Size = new System.Drawing.Size(30, 30);
            this.btnSC.TabIndex = 152;
            this.btnSC.UseVisualStyleBackColor = true;
            this.btnSC.Click += new System.EventHandler(this.btnSC_Click);
            // 
            // tbxNCliente
            // 
            this.tbxNCliente.Location = new System.Drawing.Point(245, 44);
            this.tbxNCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCliente.Name = "tbxNCliente";
            this.tbxNCliente.ReadOnly = true;
            this.tbxNCliente.Size = new System.Drawing.Size(248, 23);
            this.tbxNCliente.TabIndex = 151;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(13, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 150;
            this.label4.Text = "Cliente:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Location = new System.Drawing.Point(104, 44);
            this.tbxCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(93, 23);
            this.tbxCliente.TabIndex = 149;
            this.tbxCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCliente_KeyDown);
            this.tbxCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCliente_KeyPress);
            this.tbxCliente.Leave += new System.EventHandler(this.tbxCliente_Leave);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Enabled = false;
            this.btnSV.Location = new System.Drawing.Point(206, 9);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 160;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Visible = false;
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Location = new System.Drawing.Point(245, 13);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(248, 23);
            this.tbxNVendedor.TabIndex = 159;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 158;
            this.label5.Text = "Vendedor:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Location = new System.Drawing.Point(104, 13);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.ReadOnly = true;
            this.tbxVendedor.Size = new System.Drawing.Size(93, 23);
            this.tbxVendedor.TabIndex = 157;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(511, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 162;
            this.label6.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "d/M/yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(577, 11);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 23);
            this.dtpFecha.TabIndex = 161;
            this.dtpFecha.Value = new System.DateTime(2013, 12, 24, 16, 17, 5, 0);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(750, 35);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 40);
            this.btnEliminar.TabIndex = 164;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(511, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 166;
            this.label1.Text = "Tipo venta:";
            // 
            // tbxTipoVenta
            // 
            this.tbxTipoVenta.Location = new System.Drawing.Point(609, 46);
            this.tbxTipoVenta.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTipoVenta.Name = "tbxTipoVenta";
            this.tbxTipoVenta.ReadOnly = true;
            this.tbxTipoVenta.Size = new System.Drawing.Size(134, 23);
            this.tbxTipoVenta.TabIndex = 165;
            // 
            // CancelacionesClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(898, 494);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxTipoVenta);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.btnSC);
            this.Controls.Add(this.tbxNCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxCliente);
            this.Controls.Add(this.dtgClientesProductos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CancelacionesClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelaciones clientes";
            this.Load += new System.EventHandler(this.CancelacionesClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgClientesProductos;
        private System.Windows.Forms.Button btnSC;
        private System.Windows.Forms.TextBox tbxNCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComision;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxTipoVenta;
    }
}