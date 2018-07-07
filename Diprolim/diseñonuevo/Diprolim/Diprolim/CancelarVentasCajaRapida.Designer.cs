namespace Diprolim
{
    partial class CancelarVentasCajaRapida
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgTicket = new System.Windows.Forms.DataGridView();
            this.tbxFolioTicket = new System.Windows.Forms.TextBox();
            this.lblFolioTicket = new System.Windows.Forms.Label();
            this.btnCancelarTicket = new System.Windows.Forms.Button();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgTicket
            // 
            this.dtgTicket.AllowUserToAddRows = false;
            this.dtgTicket.AllowUserToDeleteRows = false;
            this.dtgTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colDescripcion,
            this.colPrecio,
            this.colCantidad,
            this.colImporte,
            this.colFecha});
            this.dtgTicket.Location = new System.Drawing.Point(16, 73);
            this.dtgTicket.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgTicket.Name = "dtgTicket";
            this.dtgTicket.ReadOnly = true;
            this.dtgTicket.Size = new System.Drawing.Size(905, 285);
            this.dtgTicket.TabIndex = 0;
            // 
            // tbxFolioTicket
            // 
            this.tbxFolioTicket.Location = new System.Drawing.Point(116, 28);
            this.tbxFolioTicket.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxFolioTicket.Name = "tbxFolioTicket";
            this.tbxFolioTicket.Size = new System.Drawing.Size(132, 22);
            this.tbxFolioTicket.TabIndex = 1;
            this.tbxFolioTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFolioTicket_KeyDown);
            this.tbxFolioTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxFolioTicket_KeyPress);
            // 
            // lblFolioTicket
            // 
            this.lblFolioTicket.AutoSize = true;
            this.lblFolioTicket.Location = new System.Drawing.Point(17, 31);
            this.lblFolioTicket.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolioTicket.Name = "lblFolioTicket";
            this.lblFolioTicket.Size = new System.Drawing.Size(91, 16);
            this.lblFolioTicket.TabIndex = 2;
            this.lblFolioTicket.Text = "Folio de ticket";
            // 
            // btnCancelarTicket
            // 
            this.btnCancelarTicket.Location = new System.Drawing.Point(753, 12);
            this.btnCancelarTicket.Name = "btnCancelarTicket";
            this.btnCancelarTicket.Size = new System.Drawing.Size(107, 54);
            this.btnCancelarTicket.TabIndex = 3;
            this.btnCancelarTicket.Text = "Cancelar venta";
            this.btnCancelarTicket.UseVisualStyleBackColor = true;
            this.btnCancelarTicket.Click += new System.EventHandler(this.btnCancelarTicket_Click);
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 80;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 270;
            // 
            // colPrecio
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colImporte
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle5;
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            // 
            // colFecha
            // 
            dataGridViewCellStyle6.Format = "G";
            dataGridViewCellStyle6.NullValue = null;
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle6;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 150;
            // 
            // CancelarVentasCajaRapida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 376);
            this.Controls.Add(this.btnCancelarTicket);
            this.Controls.Add(this.lblFolioTicket);
            this.Controls.Add(this.tbxFolioTicket);
            this.Controls.Add(this.dtgTicket);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CancelarVentasCajaRapida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar venta caja rapida";
            this.Load += new System.EventHandler(this.CancelarVentasCajaRapida_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CancelarVentasCajaRapida_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTicket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgTicket;
        private System.Windows.Forms.TextBox tbxFolioTicket;
        private System.Windows.Forms.Label lblFolioTicket;
        private System.Windows.Forms.Button btnCancelarTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
    }
}