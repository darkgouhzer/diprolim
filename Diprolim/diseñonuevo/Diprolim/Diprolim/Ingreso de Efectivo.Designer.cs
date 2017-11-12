namespace Diprolim
{
    partial class Ingreso_de_Efectivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ingreso_de_Efectivo));
            this.cbxIm = new System.Windows.Forms.ComboBox();
            this.rdbCLiente = new System.Windows.Forms.RadioButton();
            this.rdbSucursal = new System.Windows.Forms.RadioButton();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbVendedor = new System.Windows.Forms.RadioButton();
            this.dtgIEfectivo = new System.Windows.Forms.DataGridView();
            this.Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSV = new System.Windows.Forms.Button();
            this.btnReporteHistorial = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIEfectivo)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxIm
            // 
            this.cbxIm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIm.FormattingEnabled = true;
            this.cbxIm.Items.AddRange(new object[] {
            "Todo",
            "Solo Totales"});
            this.cbxIm.Location = new System.Drawing.Point(286, 51);
            this.cbxIm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxIm.Name = "cbxIm";
            this.cbxIm.Size = new System.Drawing.Size(136, 24);
            this.cbxIm.TabIndex = 227;
            // 
            // rdbCLiente
            // 
            this.rdbCLiente.AutoSize = true;
            this.rdbCLiente.Location = new System.Drawing.Point(207, 54);
            this.rdbCLiente.Name = "rdbCLiente";
            this.rdbCLiente.Size = new System.Drawing.Size(69, 21);
            this.rdbCLiente.TabIndex = 224;
            this.rdbCLiente.Text = "Cliente";
            this.rdbCLiente.UseVisualStyleBackColor = true;
            this.rdbCLiente.CheckedChanged += new System.EventHandler(this.rdbCLiente_CheckedChanged);
            // 
            // rdbSucursal
            // 
            this.rdbSucursal.AutoSize = true;
            this.rdbSucursal.Location = new System.Drawing.Point(116, 54);
            this.rdbSucursal.Name = "rdbSucursal";
            this.rdbSucursal.Size = new System.Drawing.Size(81, 21);
            this.rdbSucursal.TabIndex = 223;
            this.rdbSucursal.Text = "Sucursal";
            this.rdbSucursal.UseVisualStyleBackColor = true;
            this.rdbSucursal.CheckedChanged += new System.EventHandler(this.rdbSucursal_CheckedChanged);
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(191, 81);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.ReadOnly = true;
            this.tbxNombre.Size = new System.Drawing.Size(299, 23);
            this.tbxNombre.TabIndex = 222;
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.Location = new System.Drawing.Point(77, 81);
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(68, 23);
            this.tbxCodigo.TabIndex = 221;
            this.tbxCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCodigo_KeyDown);
            this.tbxCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCodigo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 220;
            this.label1.Text = "Código:";
            // 
            // rdbVendedor
            // 
            this.rdbVendedor.AutoSize = true;
            this.rdbVendedor.Checked = true;
            this.rdbVendedor.Location = new System.Drawing.Point(18, 54);
            this.rdbVendedor.Name = "rdbVendedor";
            this.rdbVendedor.Size = new System.Drawing.Size(88, 21);
            this.rdbVendedor.TabIndex = 219;
            this.rdbVendedor.TabStop = true;
            this.rdbVendedor.Text = "Vendedor";
            this.rdbVendedor.UseVisualStyleBackColor = true;
            this.rdbVendedor.CheckedChanged += new System.EventHandler(this.rdbVendedor_CheckedChanged);
            // 
            // dtgIEfectivo
            // 
            this.dtgIEfectivo.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtgIEfectivo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgIEfectivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIEfectivo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod,
            this.Descrip,
            this.Column1});
            this.dtgIEfectivo.Location = new System.Drawing.Point(18, 120);
            this.dtgIEfectivo.Margin = new System.Windows.Forms.Padding(5);
            this.dtgIEfectivo.Name = "dtgIEfectivo";
            this.dtgIEfectivo.ReadOnly = true;
            this.dtgIEfectivo.Size = new System.Drawing.Size(619, 405);
            this.dtgIEfectivo.TabIndex = 218;
            // 
            // Cod
            // 
            this.Cod.HeaderText = "Fecha:";
            this.Cod.Name = "Cod";
            this.Cod.ReadOnly = true;
            this.Cod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cod.Width = 150;
            // 
            // Descrip
            // 
            this.Descrip.HeaderText = "Descripción";
            this.Descrip.Name = "Descrip";
            this.Descrip.ReadOnly = true;
            this.Descrip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Descrip.Width = 270;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "-----";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(153, 76);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 226;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // btnReporteHistorial
            // 
            this.btnReporteHistorial.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporteHistorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporteHistorial.Location = new System.Drawing.Point(497, 71);
            this.btnReporteHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporteHistorial.Name = "btnReporteHistorial";
            this.btnReporteHistorial.Size = new System.Drawing.Size(40, 40);
            this.btnReporteHistorial.TabIndex = 225;
            this.btnReporteHistorial.UseVisualStyleBackColor = true;
            this.btnReporteHistorial.Click += new System.EventHandler(this.btnReporteHistorial_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(190, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 231;
            this.label2.Text = "a:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 230;
            this.label3.Text = "De:";
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "d/M/yyyy";
            this.dtpFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(218, 19);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(120, 23);
            this.dtpFin.TabIndex = 228;
            this.dtpFin.Value = new System.DateTime(2014, 7, 19, 0, 0, 0, 0);
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "d/M/yyyy";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(62, 19);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(5);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(120, 23);
            this.dtpInicio.TabIndex = 229;
            this.dtpInicio.Value = new System.DateTime(2014, 7, 19, 0, 0, 0, 0);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(593, 71);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(40, 40);
            this.btnImprimir.TabIndex = 233;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.Location = new System.Drawing.Point(545, 71);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(40, 40);
            this.btnExcel.TabIndex = 232;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Ingreso_de_Efectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(646, 537);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.cbxIm);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.btnReporteHistorial);
            this.Controls.Add(this.rdbCLiente);
            this.Controls.Add(this.rdbSucursal);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.tbxCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbVendedor);
            this.Controls.Add(this.dtgIEfectivo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ingreso_de_Efectivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de efectivo";
            ((System.ComponentModel.ISupportInitialize)(this.dtgIEfectivo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxIm;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.Button btnReporteHistorial;
        private System.Windows.Forms.RadioButton rdbCLiente;
        private System.Windows.Forms.RadioButton rdbSucursal;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbVendedor;
        private System.Windows.Forms.DataGridView dtgIEfectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnExcel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}