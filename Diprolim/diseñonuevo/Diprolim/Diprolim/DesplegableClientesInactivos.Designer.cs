namespace Diprolim
{
    partial class DesplegableClientesInactivos
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
            this.lblCliente = new System.Windows.Forms.Label();
            this.dtgCrTabla = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.btnExcelCr = new System.Windows.Forms.Button();
            this.btnImprimirCr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCrTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 14);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(59, 17);
            this.lblCliente.TabIndex = 246;
            this.lblCliente.Text = "Cliente: ";
            // 
            // dtgCrTabla
            // 
            this.dtgCrTabla.AllowUserToAddRows = false;
            this.dtgCrTabla.AllowUserToDeleteRows = false;
            this.dtgCrTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCrTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.tblDescripcion,
            this.tblFecha});
            this.dtgCrTabla.Location = new System.Drawing.Point(12, 80);
            this.dtgCrTabla.Name = "dtgCrTabla";
            this.dtgCrTabla.ReadOnly = true;
            this.dtgCrTabla.Size = new System.Drawing.Size(727, 588);
            this.dtgCrTabla.TabIndex = 245;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // tblDescripcion
            // 
            this.tblDescripcion.HeaderText = "Descripción";
            this.tblDescripcion.Name = "tblDescripcion";
            this.tblDescripcion.ReadOnly = true;
            this.tblDescripcion.Width = 300;
            // 
            // tblFecha
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.tblFecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.tblFecha.HeaderText = "Fecha";
            this.tblFecha.Name = "tblFecha";
            this.tblFecha.ReadOnly = true;
            this.tblFecha.Width = 200;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(12, 43);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(71, 17);
            this.lblDireccion.TabIndex = 274;
            this.lblDireccion.Text = "Dirección:";
            // 
            // btnExcelCr
            // 
            this.btnExcelCr.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcelCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcelCr.Location = new System.Drawing.Point(650, 14);
            this.btnExcelCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcelCr.Name = "btnExcelCr";
            this.btnExcelCr.Size = new System.Drawing.Size(40, 40);
            this.btnExcelCr.TabIndex = 273;
            this.btnExcelCr.UseVisualStyleBackColor = true;
            this.btnExcelCr.Click += new System.EventHandler(this.btnExcelCr_Click);
            // 
            // btnImprimirCr
            // 
            this.btnImprimirCr.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimirCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirCr.Location = new System.Drawing.Point(698, 14);
            this.btnImprimirCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimirCr.Name = "btnImprimirCr";
            this.btnImprimirCr.Size = new System.Drawing.Size(40, 40);
            this.btnImprimirCr.TabIndex = 287;
            this.btnImprimirCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirCr.UseVisualStyleBackColor = true;
            this.btnImprimirCr.Click += new System.EventHandler(this.btnImprimirCr_Click);
            // 
            // DesplegableClientesInactivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(751, 680);
            this.Controls.Add(this.btnImprimirCr);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.btnExcelCr);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dtgCrTabla);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DesplegableClientesInactivos";
            this.Text = "Detalles cliente inactivo";
            this.Load += new System.EventHandler(this.DesplegableClientesInactivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCrTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DataGridView dtgCrTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblFecha;
        private System.Windows.Forms.Button btnExcelCr;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Button btnImprimirCr;
    }
}