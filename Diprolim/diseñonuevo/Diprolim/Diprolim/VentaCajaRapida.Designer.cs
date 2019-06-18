namespace Diprolim
{
    partial class VentaCajaRapida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentaCajaRapida));
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.tbxSubtotal = new System.Windows.Forms.TextBox();
            this.tbxIVA = new System.Windows.Forms.TextBox();
            this.tbxTotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dtgVenta = new System.Windows.Forms.DataGridView();
            this.colCódigoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxDescripcion = new System.Windows.Forms.TextBox();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblExistencias = new System.Windows.Forms.Label();
            this.tbxExistencias = new System.Windows.Forms.TextBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnCancelaVenta = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnCorteCaja = new System.Windows.Forms.Button();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVenta)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCodigo.Location = new System.Drawing.Point(97, 53);
            this.tbxCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(67, 23);
            this.tbxCodigo.TabIndex = 0;
            this.tbxCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCodigo_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(18, 55);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(58, 17);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Código";
            // 
            // tbxSubtotal
            // 
            this.tbxSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSubtotal.Location = new System.Drawing.Point(558, 450);
            this.tbxSubtotal.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSubtotal.Name = "tbxSubtotal";
            this.tbxSubtotal.ReadOnly = true;
            this.tbxSubtotal.Size = new System.Drawing.Size(141, 23);
            this.tbxSubtotal.TabIndex = 3;
            this.tbxSubtotal.Text = "$0.00";
            // 
            // tbxIVA
            // 
            this.tbxIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIVA.Location = new System.Drawing.Point(558, 481);
            this.tbxIVA.Margin = new System.Windows.Forms.Padding(4);
            this.tbxIVA.Name = "tbxIVA";
            this.tbxIVA.ReadOnly = true;
            this.tbxIVA.Size = new System.Drawing.Size(141, 23);
            this.tbxIVA.TabIndex = 4;
            this.tbxIVA.Text = "$0.00";
            // 
            // tbxTotal
            // 
            this.tbxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTotal.Location = new System.Drawing.Point(558, 512);
            this.tbxTotal.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.ReadOnly = true;
            this.tbxTotal.Size = new System.Drawing.Size(141, 23);
            this.tbxTotal.TabIndex = 5;
            this.tbxTotal.Text = "$0.00";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(491, 452);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(65, 16);
            this.lblSubtotal.TabIndex = 6;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA.Location = new System.Drawing.Point(491, 483);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(32, 16);
            this.lblIVA.TabIndex = 7;
            this.lblIVA.Text = "IVA";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(491, 514);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 16);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Total";
            // 
            // dtgVenta
            // 
            this.dtgVenta.AllowUserToAddRows = false;
            this.dtgVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgVenta.ColumnHeadersHeight = 40;
            this.dtgVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCódigoArticulo,
            this.colDescripcion,
            this.colCantidad,
            this.colPrecio,
            this.colDescuento,
            this.colTotal});
            this.dtgVenta.Location = new System.Drawing.Point(18, 118);
            this.dtgVenta.Name = "dtgVenta";
            this.dtgVenta.ReadOnly = true;
            this.dtgVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVenta.Size = new System.Drawing.Size(839, 325);
            this.dtgVenta.TabIndex = 2;
            this.dtgVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVenta_CellContentClick);
            // 
            // colCódigoArticulo
            // 
            this.colCódigoArticulo.FillWeight = 64.65517F;
            this.colCódigoArticulo.HeaderText = "Código";
            this.colCódigoArticulo.Name = "colCódigoArticulo";
            this.colCódigoArticulo.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FillWeight = 173.7397F;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 250;
            // 
            // colCantidad
            // 
            this.colCantidad.FillWeight = 69.88499F;
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colPrecio
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPrecio.FillWeight = 82.3207F;
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colDescuento
            // 
            this.colDescuento.FillWeight = 93.03726F;
            this.colDescuento.HeaderText = "Descuento";
            this.colDescuento.Name = "colDescuento";
            this.colDescuento.ReadOnly = true;
            // 
            // colTotal
            // 
            dataGridViewCellStyle3.Format = "C2";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotal.FillWeight = 116.3622F;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // tbxDescripcion
            // 
            this.tbxDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDescripcion.Location = new System.Drawing.Point(172, 53);
            this.tbxDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.tbxDescripcion.Name = "tbxDescripcion";
            this.tbxDescripcion.ReadOnly = true;
            this.tbxDescripcion.Size = new System.Drawing.Size(283, 23);
            this.tbxDescripcion.TabIndex = 9;
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCantidad.Location = new System.Drawing.Point(97, 88);
            this.tbxCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.Size = new System.Drawing.Size(67, 23);
            this.tbxCantidad.TabIndex = 10;
            this.tbxCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidad_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(18, 90);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(72, 17);
            this.lblCantidad.TabIndex = 11;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblExistencias
            // 
            this.lblExistencias.AutoSize = true;
            this.lblExistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExistencias.Location = new System.Drawing.Point(171, 90);
            this.lblExistencias.Name = "lblExistencias";
            this.lblExistencias.Size = new System.Drawing.Size(89, 17);
            this.lblExistencias.TabIndex = 12;
            this.lblExistencias.Text = "Existencias";
            // 
            // tbxExistencias
            // 
            this.tbxExistencias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxExistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxExistencias.Location = new System.Drawing.Point(267, 88);
            this.tbxExistencias.Margin = new System.Windows.Forms.Padding(4);
            this.tbxExistencias.Name = "tbxExistencias";
            this.tbxExistencias.ReadOnly = true;
            this.tbxExistencias.Size = new System.Drawing.Size(67, 23);
            this.tbxExistencias.TabIndex = 13;
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panelContainer.Controls.Add(this.btnNuevaVenta);
            this.panelContainer.Controls.Add(this.btnCorteCaja);
            this.panelContainer.Controls.Add(this.btnCancelaVenta);
            this.panelContainer.Controls.Add(this.btnCobrar);
            this.panelContainer.Controls.Add(this.label1);
            this.panelContainer.Controls.Add(this.lblSubtotal);
            this.panelContainer.Controls.Add(this.tbxSubtotal);
            this.panelContainer.Controls.Add(this.tbxIVA);
            this.panelContainer.Controls.Add(this.lblCodigo);
            this.panelContainer.Controls.Add(this.tbxTotal);
            this.panelContainer.Controls.Add(this.dtgVenta);
            this.panelContainer.Controls.Add(this.lblIVA);
            this.panelContainer.Controls.Add(this.tbxCodigo);
            this.panelContainer.Controls.Add(this.lblTotal);
            this.panelContainer.Controls.Add(this.tbxExistencias);
            this.panelContainer.Controls.Add(this.tbxDescripcion);
            this.panelContainer.Controls.Add(this.tbxCantidad);
            this.panelContainer.Controls.Add(this.lblExistencias);
            this.panelContainer.Controls.Add(this.lblCantidad);
            this.panelContainer.Location = new System.Drawing.Point(12, 12);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(878, 570);
            this.panelContainer.TabIndex = 15;
            // 
            // btnCancelaVenta
            // 
            this.btnCancelaVenta.BackColor = System.Drawing.Color.DimGray;
            this.btnCancelaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelaVenta.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancelaVenta.Location = new System.Drawing.Point(18, 449);
            this.btnCancelaVenta.Name = "btnCancelaVenta";
            this.btnCancelaVenta.Size = new System.Drawing.Size(141, 86);
            this.btnCancelaVenta.TabIndex = 17;
            this.btnCancelaVenta.Text = "Cancelar ventas";
            this.btnCancelaVenta.UseVisualStyleBackColor = false;
            this.btnCancelaVenta.Click += new System.EventHandler(this.btnCancelaVenta_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCobrar.Location = new System.Drawing.Point(716, 449);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(141, 86);
            this.btnCobrar.TabIndex = 16;
            this.btnCobrar.Text = "Cobrar [F5]";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "CAJA RÁPIDA";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnCorteCaja
            // 
            this.btnCorteCaja.BackColor = System.Drawing.Color.Teal;
            this.btnCorteCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorteCaja.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCorteCaja.Location = new System.Drawing.Point(165, 449);
            this.btnCorteCaja.Name = "btnCorteCaja";
            this.btnCorteCaja.Size = new System.Drawing.Size(141, 86);
            this.btnCorteCaja.TabIndex = 18;
            this.btnCorteCaja.Text = "Corte de caja";
            this.btnCorteCaja.UseVisualStyleBackColor = false;
            this.btnCorteCaja.Click += new System.EventHandler(this.btnCorteCaja_Click);
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaVenta.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNuevaVenta.Location = new System.Drawing.Point(312, 449);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(141, 86);
            this.btnNuevaVenta.TabIndex = 19;
            this.btnNuevaVenta.Text = "Nueva Venta [F2]";
            this.btnNuevaVenta.UseVisualStyleBackColor = false;
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            // 
            // VentaCajaRapida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 594);
            this.Controls.Add(this.panelContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentaCajaRapida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentaCajaRapida";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VentaCajaRapida_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VentaCajaRapida_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VentaCajaRapida_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVenta)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox tbxSubtotal;
        private System.Windows.Forms.TextBox tbxIVA;
        private System.Windows.Forms.TextBox tbxTotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dtgVenta;
        private System.Windows.Forms.TextBox tbxDescripcion;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblExistencias;
        private System.Windows.Forms.TextBox tbxExistencias;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCódigoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnCancelaVenta;
        private System.Windows.Forms.Button btnCorteCaja;
        private System.Windows.Forms.Button btnNuevaVenta;
    }
}