namespace Diprolim
{
    partial class Clientes_inactivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes_inactivos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbxDias = new System.Windows.Forms.TextBox();
            this.cbxDias = new System.Windows.Forms.ComboBox();
            this.tbxCrVendedor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxNCrVendedor = new System.Windows.Forms.TextBox();
            this.tbxCrCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxNCrCliente = new System.Windows.Forms.TextBox();
            this.dtgCrTabla = new System.Windows.Forms.DataGridView();
            this.btnSCrV = new System.Windows.Forms.Button();
            this.btnReporteCr = new System.Windows.Forms.Button();
            this.btnCrRVendedor = new System.Windows.Forms.Button();
            this.btnExcelCr = new System.Windows.Forms.Button();
            this.btnCrRCliente = new System.Windows.Forms.Button();
            this.btnSPCrC = new System.Windows.Forms.Button();
            this.btnImprimirCr = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocCreditos = new System.Drawing.Printing.PrintDocument();
            this.printPreviewCreditos = new System.Windows.Forms.PrintPreviewDialog();
            this.colClienteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCrTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxDias
            // 
            this.tbxDias.Location = new System.Drawing.Point(714, 10);
            this.tbxDias.Name = "tbxDias";
            this.tbxDias.Size = new System.Drawing.Size(53, 23);
            this.tbxDias.TabIndex = 285;
            this.tbxDias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxDias_KeyPress);
            // 
            // cbxDias
            // 
            this.cbxDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDias.FormattingEnabled = true;
            this.cbxDias.Items.AddRange(new object[] {
            "Días mayor que"});
            this.cbxDias.Location = new System.Drawing.Point(587, 10);
            this.cbxDias.Name = "cbxDias";
            this.cbxDias.Size = new System.Drawing.Size(121, 24);
            this.cbxDias.TabIndex = 284;
            this.cbxDias.SelectedIndexChanged += new System.EventHandler(this.cbxDias_SelectedIndexChanged);
            // 
            // tbxCrVendedor
            // 
            this.tbxCrVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCrVendedor.Location = new System.Drawing.Point(111, 14);
            this.tbxCrVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCrVendedor.MaxLength = 9;
            this.tbxCrVendedor.Name = "tbxCrVendedor";
            this.tbxCrVendedor.Size = new System.Drawing.Size(71, 22);
            this.tbxCrVendedor.TabIndex = 269;
            this.tbxCrVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCrVendedor_KeyDown);
            this.tbxCrVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCrVendedor_KeyPress);
            this.tbxCrVendedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxCrVendedor_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 274;
            this.label7.Text = "Vendedor:";
            // 
            // tbxNCrVendedor
            // 
            this.tbxNCrVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNCrVendedor.Location = new System.Drawing.Point(228, 14);
            this.tbxNCrVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCrVendedor.Name = "tbxNCrVendedor";
            this.tbxNCrVendedor.ReadOnly = true;
            this.tbxNCrVendedor.Size = new System.Drawing.Size(303, 22);
            this.tbxNCrVendedor.TabIndex = 275;
            // 
            // tbxCrCliente
            // 
            this.tbxCrCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCrCliente.Location = new System.Drawing.Point(111, 44);
            this.tbxCrCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCrCliente.MaxLength = 9;
            this.tbxCrCliente.Name = "tbxCrCliente";
            this.tbxCrCliente.Size = new System.Drawing.Size(71, 22);
            this.tbxCrCliente.TabIndex = 270;
            this.tbxCrCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCrCliente_KeyDown);
            this.tbxCrCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCrCliente_KeyPress);
            this.tbxCrCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxCrCliente_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 47);
            this.label9.Margin = new System.Windows.Forms.Padding(4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 278;
            this.label9.Text = "Cliente:";
            // 
            // tbxNCrCliente
            // 
            this.tbxNCrCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNCrCliente.Location = new System.Drawing.Point(228, 44);
            this.tbxNCrCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCrCliente.Name = "tbxNCrCliente";
            this.tbxNCrCliente.ReadOnly = true;
            this.tbxNCrCliente.Size = new System.Drawing.Size(303, 22);
            this.tbxNCrCliente.TabIndex = 279;
            // 
            // dtgCrTabla
            // 
            this.dtgCrTabla.AllowUserToAddRows = false;
            this.dtgCrTabla.AllowUserToDeleteRows = false;
            this.dtgCrTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCrTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClienteID,
            this.Nombre,
            this.tblFecha,
            this.Dias});
            this.dtgCrTabla.Location = new System.Drawing.Point(12, 94);
            this.dtgCrTabla.Name = "dtgCrTabla";
            this.dtgCrTabla.ReadOnly = true;
            this.dtgCrTabla.Size = new System.Drawing.Size(755, 420);
            this.dtgCrTabla.TabIndex = 273;
            this.dtgCrTabla.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgCrTabla_CellMouseDoubleClick);
            // 
            // btnSCrV
            // 
            this.btnSCrV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSCrV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSCrV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSCrV.Location = new System.Drawing.Point(190, 10);
            this.btnSCrV.Margin = new System.Windows.Forms.Padding(4);
            this.btnSCrV.Name = "btnSCrV";
            this.btnSCrV.Size = new System.Drawing.Size(30, 30);
            this.btnSCrV.TabIndex = 276;
            this.btnSCrV.UseVisualStyleBackColor = true;
            this.btnSCrV.Click += new System.EventHandler(this.btnSCrV_Click);
            // 
            // btnReporteCr
            // 
            this.btnReporteCr.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporteCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporteCr.Location = new System.Drawing.Point(589, 41);
            this.btnReporteCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporteCr.Name = "btnReporteCr";
            this.btnReporteCr.Size = new System.Drawing.Size(40, 40);
            this.btnReporteCr.TabIndex = 271;
            this.btnReporteCr.UseVisualStyleBackColor = true;
            this.btnReporteCr.Click += new System.EventHandler(this.btnReporteCr_Click);
            // 
            // btnCrRVendedor
            // 
            this.btnCrRVendedor.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCrRVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrRVendedor.FlatAppearance.BorderSize = 0;
            this.btnCrRVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrRVendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrRVendedor.Location = new System.Drawing.Point(539, 10);
            this.btnCrRVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrRVendedor.Name = "btnCrRVendedor";
            this.btnCrRVendedor.Size = new System.Drawing.Size(30, 30);
            this.btnCrRVendedor.TabIndex = 277;
            this.btnCrRVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrRVendedor.UseVisualStyleBackColor = true;
            this.btnCrRVendedor.Click += new System.EventHandler(this.btnCrRVendedor_Click);
            // 
            // btnExcelCr
            // 
            this.btnExcelCr.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcelCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcelCr.Location = new System.Drawing.Point(637, 41);
            this.btnExcelCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcelCr.Name = "btnExcelCr";
            this.btnExcelCr.Size = new System.Drawing.Size(40, 40);
            this.btnExcelCr.TabIndex = 272;
            this.btnExcelCr.UseVisualStyleBackColor = true;
            this.btnExcelCr.Click += new System.EventHandler(this.btnExcelCr_Click);
            // 
            // btnCrRCliente
            // 
            this.btnCrRCliente.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCrRCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrRCliente.FlatAppearance.BorderSize = 0;
            this.btnCrRCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrRCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrRCliente.Location = new System.Drawing.Point(539, 40);
            this.btnCrRCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrRCliente.Name = "btnCrRCliente";
            this.btnCrRCliente.Size = new System.Drawing.Size(30, 30);
            this.btnCrRCliente.TabIndex = 281;
            this.btnCrRCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrRCliente.UseVisualStyleBackColor = true;
            this.btnCrRCliente.Click += new System.EventHandler(this.btnCrRCliente_Click);
            // 
            // btnSPCrC
            // 
            this.btnSPCrC.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSPCrC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSPCrC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSPCrC.Location = new System.Drawing.Point(190, 40);
            this.btnSPCrC.Margin = new System.Windows.Forms.Padding(4);
            this.btnSPCrC.Name = "btnSPCrC";
            this.btnSPCrC.Size = new System.Drawing.Size(30, 30);
            this.btnSPCrC.TabIndex = 280;
            this.btnSPCrC.UseVisualStyleBackColor = true;
            this.btnSPCrC.Click += new System.EventHandler(this.btnSPCrC_Click);
            // 
            // btnImprimirCr
            // 
            this.btnImprimirCr.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimirCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirCr.Location = new System.Drawing.Point(685, 41);
            this.btnImprimirCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimirCr.Name = "btnImprimirCr";
            this.btnImprimirCr.Size = new System.Drawing.Size(40, 40);
            this.btnImprimirCr.TabIndex = 286;
            this.btnImprimirCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirCr.UseVisualStyleBackColor = true;
            this.btnImprimirCr.Click += new System.EventHandler(this.btnImprimirCr_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocCreditos;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewCreditos
            // 
            this.printPreviewCreditos.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewCreditos.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewCreditos.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewCreditos.Document = this.printDocCreditos;
            this.printPreviewCreditos.Enabled = true;
            this.printPreviewCreditos.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewCreditos.Icon")));
            this.printPreviewCreditos.Name = "printPreviewCreditos";
            this.printPreviewCreditos.Visible = false;
            // 
            // colClienteID
            // 
            this.colClienteID.HeaderText = "ClienteID";
            this.colClienteID.Name = "colClienteID";
            this.colClienteID.ReadOnly = true;
            this.colClienteID.Width = 120;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
            // 
            // tblFecha
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.tblFecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.tblFecha.HeaderText = "Fecha/UC";
            this.tblFecha.Name = "tblFecha";
            this.tblFecha.ReadOnly = true;
            // 
            // Dias
            // 
            this.Dias.HeaderText = "Dias/UC";
            this.Dias.Name = "Dias";
            this.Dias.ReadOnly = true;
            // 
            // Clientes_inactivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(781, 534);
            this.Controls.Add(this.btnImprimirCr);
            this.Controls.Add(this.tbxDias);
            this.Controls.Add(this.cbxDias);
            this.Controls.Add(this.tbxCrVendedor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxNCrVendedor);
            this.Controls.Add(this.btnSCrV);
            this.Controls.Add(this.btnReporteCr);
            this.Controls.Add(this.btnCrRVendedor);
            this.Controls.Add(this.btnExcelCr);
            this.Controls.Add(this.tbxCrCliente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbxNCrCliente);
            this.Controls.Add(this.btnCrRCliente);
            this.Controls.Add(this.btnSPCrC);
            this.Controls.Add(this.dtgCrTabla);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Clientes_inactivos";
            this.Text = "Clientes inactivos";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCrTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDias;
        private System.Windows.Forms.ComboBox cbxDias;
        private System.Windows.Forms.TextBox tbxCrVendedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxNCrVendedor;
        private System.Windows.Forms.Button btnSCrV;
        private System.Windows.Forms.Button btnReporteCr;
        private System.Windows.Forms.Button btnCrRVendedor;
        private System.Windows.Forms.Button btnExcelCr;
        private System.Windows.Forms.TextBox tbxCrCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxNCrCliente;
        private System.Windows.Forms.Button btnCrRCliente;
        private System.Windows.Forms.Button btnSPCrC;
        private System.Windows.Forms.DataGridView dtgCrTabla;
        private System.Windows.Forms.Button btnImprimirCr;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocCreditos;
        private System.Windows.Forms.PrintPreviewDialog printPreviewCreditos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClienteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
       

    }
}