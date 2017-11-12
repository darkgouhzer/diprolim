namespace Diprolim
{
    partial class ReporteClientesSinMovimientos
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnSC = new System.Windows.Forms.Button();
            this.tbxNCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.btnSP = new System.Windows.Forms.Button();
            this.tbxNProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxProducto = new System.Windows.Forms.TextBox();
            this.btnSV = new System.Windows.Forms.Button();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.dtgClientesInactivos = new System.Windows.Forms.DataGridView();
            this.colClienteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.tbxDias = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesInactivos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(501, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 111;
            this.label2.Text = "Mayor que días";
            // 
            // btnSC
            // 
            this.btnSC.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSC.Location = new System.Drawing.Point(206, 39);
            this.btnSC.Margin = new System.Windows.Forms.Padding(5);
            this.btnSC.Name = "btnSC";
            this.btnSC.Size = new System.Drawing.Size(30, 30);
            this.btnSC.TabIndex = 123;
            this.btnSC.UseVisualStyleBackColor = true;
            // 
            // tbxNCliente
            // 
            this.tbxNCliente.Location = new System.Drawing.Point(245, 44);
            this.tbxNCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCliente.Name = "tbxNCliente";
            this.tbxNCliente.ReadOnly = true;
            this.tbxNCliente.Size = new System.Drawing.Size(248, 23);
            this.tbxNCliente.TabIndex = 122;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(33, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 121;
            this.label4.Text = "Cliente:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Location = new System.Drawing.Point(104, 44);
            this.tbxCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(93, 23);
            this.tbxCliente.TabIndex = 120;
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Location = new System.Drawing.Point(206, 71);
            this.btnSP.Margin = new System.Windows.Forms.Padding(5);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 119;
            this.btnSP.UseVisualStyleBackColor = true;
            // 
            // tbxNProducto
            // 
            this.tbxNProducto.Location = new System.Drawing.Point(245, 75);
            this.tbxNProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNProducto.Name = "tbxNProducto";
            this.tbxNProducto.ReadOnly = true;
            this.tbxNProducto.Size = new System.Drawing.Size(248, 23);
            this.tbxNProducto.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 117;
            this.label1.Text = "Producto:";
            // 
            // tbxProducto
            // 
            this.tbxProducto.Location = new System.Drawing.Point(104, 75);
            this.tbxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProducto.Name = "tbxProducto";
            this.tbxProducto.Size = new System.Drawing.Size(93, 23);
            this.tbxProducto.TabIndex = 116;
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(206, 9);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 115;
            this.btnSV.UseVisualStyleBackColor = true;
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Location = new System.Drawing.Point(245, 13);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(248, 23);
            this.tbxNVendedor.TabIndex = 114;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 113;
            this.label3.Text = "Vendedor:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Location = new System.Drawing.Point(104, 13);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(93, 23);
            this.tbxVendedor.TabIndex = 112;
            // 
            // dtgClientesInactivos
            // 
            this.dtgClientesInactivos.AllowUserToAddRows = false;
            this.dtgClientesInactivos.AllowUserToDeleteRows = false;
            this.dtgClientesInactivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientesInactivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClienteID,
            this.colNombreCliente,
            this.colNombreVendedor,
            this.colEstado});
            this.dtgClientesInactivos.Location = new System.Drawing.Point(12, 108);
            this.dtgClientesInactivos.Name = "dtgClientesInactivos";
            this.dtgClientesInactivos.ReadOnly = true;
            this.dtgClientesInactivos.Size = new System.Drawing.Size(843, 262);
            this.dtgClientesInactivos.TabIndex = 124;
            // 
            // colClienteID
            // 
            this.colClienteID.HeaderText = "Código cliente";
            this.colClienteID.Name = "colClienteID";
            this.colClienteID.ReadOnly = true;
            // 
            // colNombreCliente
            // 
            this.colNombreCliente.HeaderText = "Nombre de cliente";
            this.colNombreCliente.Name = "colNombreCliente";
            this.colNombreCliente.ReadOnly = true;
            this.colNombreCliente.Width = 250;
            // 
            // colNombreVendedor
            // 
            this.colNombreVendedor.HeaderText = "Nombre de vendedor";
            this.colNombreVendedor.Name = "colNombreVendedor";
            this.colNombreVendedor.ReadOnly = true;
            this.colNombreVendedor.Width = 250;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(814, 61);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(40, 40);
            this.btnImprimir.TabIndex = 127;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnReporte
            // 
            this.btnReporte.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporte.Location = new System.Drawing.Point(718, 61);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(40, 40);
            this.btnReporte.TabIndex = 125;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.Location = new System.Drawing.Point(766, 61);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(40, 40);
            this.btnExcel.TabIndex = 126;
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // tbxDias
            // 
            this.tbxDias.Location = new System.Drawing.Point(628, 13);
            this.tbxDias.Margin = new System.Windows.Forms.Padding(4);
            this.tbxDias.Name = "tbxDias";
            this.tbxDias.Size = new System.Drawing.Size(93, 23);
            this.tbxDias.TabIndex = 128;
            // 
            // ReporteClientesSinMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 382);
            this.Controls.Add(this.tbxDias);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dtgClientesInactivos);
            this.Controls.Add(this.btnSC);
            this.Controls.Add(this.tbxNCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxCliente);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.tbxNProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxProducto);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReporteClientesSinMovimientos";
            this.Text = "Reporte de clientes sin movimientos";
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesInactivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSC;
        private System.Windows.Forms.TextBox tbxNCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.TextBox tbxNProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxProducto;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.DataGridView dtgClientesInactivos;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClienteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.TextBox tbxDias;
    }
}