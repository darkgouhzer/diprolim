namespace Diprolim
{
    partial class ReporteEntradaV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteEntradaV));
            this.tblEntradas = new System.Windows.Forms.DataGridView();
            this.codigArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rSdescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REInv_anterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repSFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.tbxCV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnSV = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.cbxUnMedida = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblEntradas)).BeginInit();
            this.SuspendLayout();
            // 
            // tblEntradas
            // 
            this.tblEntradas.AllowUserToAddRows = false;
            this.tblEntradas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblEntradas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tblEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblEntradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigArt,
            this.rSdescripcion,
            this.NEntrada,
            this.REInv_anterior,
            this.repSFecha});
            this.tblEntradas.Location = new System.Drawing.Point(12, 116);
            this.tblEntradas.Name = "tblEntradas";
            this.tblEntradas.ReadOnly = true;
            this.tblEntradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblEntradas.Size = new System.Drawing.Size(673, 372);
            this.tblEntradas.TabIndex = 108;
            this.tblEntradas.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.tblEntradas_SortCompare);
            // 
            // codigArt
            // 
            this.codigArt.HeaderText = "Código articulo";
            this.codigArt.Name = "codigArt";
            this.codigArt.ReadOnly = true;
            this.codigArt.Width = 80;
            // 
            // rSdescripcion
            // 
            this.rSdescripcion.HeaderText = "Descripción";
            this.rSdescripcion.Name = "rSdescripcion";
            this.rSdescripcion.ReadOnly = true;
            this.rSdescripcion.Width = 280;
            // 
            // NEntrada
            // 
            this.NEntrada.HeaderText = "Entradas";
            this.NEntrada.Name = "NEntrada";
            this.NEntrada.ReadOnly = true;
            this.NEntrada.Width = 80;
            // 
            // REInv_anterior
            // 
            this.REInv_anterior.HeaderText = "Inventario anterior";
            this.REInv_anterior.Name = "REInv_anterior";
            this.REInv_anterior.ReadOnly = true;
            this.REInv_anterior.Width = 80;
            // 
            // repSFecha
            // 
            this.repSFecha.HeaderText = "Fecha";
            this.repSFecha.Name = "repSFecha";
            this.repSFecha.ReadOnly = true;
            this.repSFecha.Width = 90;
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(284, 49);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.ReadOnly = true;
            this.tbxNombre.Size = new System.Drawing.Size(258, 23);
            this.tbxNombre.TabIndex = 107;
            // 
            // tbxCV
            // 
            this.tbxCV.Location = new System.Drawing.Point(154, 49);
            this.tbxCV.Name = "tbxCV";
            this.tbxCV.Size = new System.Drawing.Size(84, 23);
            this.tbxCV.TabIndex = 106;
            this.tbxCV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCV_KeyDown);
            this.tbxCV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCV_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 105;
            this.label3.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(282, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 104;
            this.label2.Text = "a:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 103;
            this.label1.Text = "De:";
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "d/M/yyyy";
            this.dtpFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(310, 14);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(120, 23);
            this.dtpFin.TabIndex = 101;
            this.dtpFin.Value = new System.DateTime(2013, 10, 19, 0, 0, 0, 0);
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "d/M/yyyy";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(154, 14);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(5);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(120, 23);
            this.dtpInicio.TabIndex = 102;
            this.dtpInicio.Value = new System.DateTime(2013, 10, 19, 0, 0, 0, 0);
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
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(246, 45);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 112;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(645, 70);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(40, 40);
            this.btnImprimir.TabIndex = 111;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporte.Location = new System.Drawing.Point(549, 70);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(40, 40);
            this.btnReporte.TabIndex = 109;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.Location = new System.Drawing.Point(597, 70);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(40, 40);
            this.btnExcel.TabIndex = 110;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // cbxUnMedida
            // 
            this.cbxUnMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnMedida.FormattingEnabled = true;
            this.cbxUnMedida.Location = new System.Drawing.Point(154, 86);
            this.cbxUnMedida.Name = "cbxUnMedida";
            this.cbxUnMedida.Size = new System.Drawing.Size(132, 24);
            this.cbxUnMedida.TabIndex = 139;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(9, 89);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 17);
            this.label7.TabIndex = 138;
            this.label7.Text = "Unidades medida:";
            // 
            // ReporteEntradaV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(699, 500);
            this.Controls.Add(this.cbxUnMedida);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.tblEntradas);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.tbxCV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpInicio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ReporteEntradaV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de ventas vendedor";
            ((System.ComponentModel.ISupportInitialize)(this.tblEntradas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridView tblEntradas;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.TextBox tbxCV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn rSdescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn REInv_anterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn repSFecha;
        private System.Windows.Forms.ComboBox cbxUnMedida;
        private System.Windows.Forms.Label label7;

    }
}