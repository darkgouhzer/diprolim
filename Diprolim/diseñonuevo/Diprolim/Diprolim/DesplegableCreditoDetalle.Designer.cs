namespace Diprolim
{
    partial class DesplegableCreditoDetalle
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
            this.dtgCrTabla = new System.Windows.Forms.DataGridView();
            this.tblFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblAbono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCrTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCrTabla
            // 
            this.dtgCrTabla.AllowUserToAddRows = false;
            this.dtgCrTabla.AllowUserToDeleteRows = false;
            this.dtgCrTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCrTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tblFolio,
            this.tblFecha,
            this.tblDescripcion,
            this.tblCredito,
            this.tblAbono,
            this.tblSaldo,
            this.tblDias});
            this.dtgCrTabla.Location = new System.Drawing.Point(12, 49);
            this.dtgCrTabla.Name = "dtgCrTabla";
            this.dtgCrTabla.ReadOnly = true;
            this.dtgCrTabla.Size = new System.Drawing.Size(956, 383);
            this.dtgCrTabla.TabIndex = 243;
            // 
            // tblFolio
            // 
            this.tblFolio.HeaderText = "Folio";
            this.tblFolio.Name = "tblFolio";
            this.tblFolio.ReadOnly = true;
            this.tblFolio.Width = 80;
            // 
            // tblFecha
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.tblFecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.tblFecha.HeaderText = "Fecha";
            this.tblFecha.Name = "tblFecha";
            this.tblFecha.ReadOnly = true;
            // 
            // tblDescripcion
            // 
            this.tblDescripcion.HeaderText = "Descripción";
            this.tblDescripcion.Name = "tblDescripcion";
            this.tblDescripcion.ReadOnly = true;
            this.tblDescripcion.Width = 300;
            // 
            // tblCredito
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.tblCredito.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblCredito.HeaderText = "Credito";
            this.tblCredito.Name = "tblCredito";
            this.tblCredito.ReadOnly = true;
            // 
            // tblAbono
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.tblAbono.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblAbono.HeaderText = "Abonado";
            this.tblAbono.Name = "tblAbono";
            this.tblAbono.ReadOnly = true;
            // 
            // tblSaldo
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.tblSaldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.tblSaldo.HeaderText = "Saldo";
            this.tblSaldo.Name = "tblSaldo";
            this.tblSaldo.ReadOnly = true;
            // 
            // tblDias
            // 
            this.tblDias.HeaderText = "Días";
            this.tblDias.Name = "tblDias";
            this.tblDias.ReadOnly = true;
            this.tblDias.Width = 60;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 20);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(59, 17);
            this.lblCliente.TabIndex = 244;
            this.lblCliente.Text = "Cliente: ";
            // 
            // DesplegableCreditoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(983, 445);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dtgCrTabla);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DesplegableCreditoDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de ventas a crédito";
            this.Load += new System.EventHandler(this.DesplegableCreditoDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCrTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCrTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblAbono;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblDias;
        private System.Windows.Forms.Label lblCliente;

    }
}