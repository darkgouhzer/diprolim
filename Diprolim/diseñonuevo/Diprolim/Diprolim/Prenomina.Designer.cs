namespace Diprolim
{
    partial class Prenomina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prenomina));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblComisiones = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.btnSV = new System.Windows.Forms.Button();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.tbxPuesto = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tblCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblVentaContado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblVentaCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblConsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblAbonos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblEfectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblTotalCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblComisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // tblComisiones
            // 
            this.tblComisiones.AllowUserToAddRows = false;
            this.tblComisiones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblComisiones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tblComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblComisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tblCategoria,
            this.tblTotal,
            this.tblVentaContado,
            this.tblVentaCredito,
            this.tblConsignacion,
            this.tblAbonos,
            this.tblEfectivo,
            this.tblTotalCom,
            this.Porcentaje});
            this.tblComisiones.Location = new System.Drawing.Point(13, 84);
            this.tblComisiones.Margin = new System.Windows.Forms.Padding(4);
            this.tblComisiones.Name = "tblComisiones";
            this.tblComisiones.ReadOnly = true;
            this.tblComisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblComisiones.Size = new System.Drawing.Size(856, 210);
            this.tblComisiones.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(223, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 17);
            this.label3.TabIndex = 150;
            this.label3.Text = "a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 149;
            this.label2.Text = "Rangos:";
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "dd/MMM/yyyy";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(247, 13);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(116, 23);
            this.dtpFin.TabIndex = 148;
            this.dtpFin.Value = new System.DateTime(2013, 10, 19, 0, 0, 0, 0);
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MMM/yyyy";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(99, 13);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(116, 23);
            this.dtpInicio.TabIndex = 147;
            this.dtpInicio.Value = new System.DateTime(2013, 10, 19, 0, 0, 0, 0);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(185, 45);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 154;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Location = new System.Drawing.Point(224, 49);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(315, 23);
            this.tbxNVendedor.TabIndex = 153;
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Location = new System.Drawing.Point(99, 49);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(75, 23);
            this.tbxVendedor.TabIndex = 152;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 151;
            this.label4.Text = "Vendedor:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(781, 40);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(40, 40);
            this.btnImprimir.TabIndex = 157;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporte.Location = new System.Drawing.Point(685, 40);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(40, 40);
            this.btnReporte.TabIndex = 155;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.Location = new System.Drawing.Point(733, 40);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(40, 40);
            this.btnExcel.TabIndex = 156;
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
            // tbxPuesto
            // 
            this.tbxPuesto.Location = new System.Drawing.Point(547, 49);
            this.tbxPuesto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPuesto.Name = "tbxPuesto";
            this.tbxPuesto.ReadOnly = true;
            this.tbxPuesto.Size = new System.Drawing.Size(130, 23);
            this.tbxPuesto.TabIndex = 158;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(829, 40);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(40, 40);
            this.btnLimpiar.TabIndex = 159;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // tblCategoria
            // 
            this.tblCategoria.HeaderText = "Categoría";
            this.tblCategoria.Name = "tblCategoria";
            this.tblCategoria.ReadOnly = true;
            this.tblCategoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tblTotal
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.tblTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblTotal.HeaderText = "Total venta";
            this.tblTotal.Name = "tblTotal";
            this.tblTotal.ReadOnly = true;
            this.tblTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblTotal.Width = 90;
            // 
            // tblVentaContado
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.tblVentaContado.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblVentaContado.HeaderText = "Venta contado";
            this.tblVentaContado.Name = "tblVentaContado";
            this.tblVentaContado.ReadOnly = true;
            this.tblVentaContado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblVentaContado.Width = 90;
            // 
            // tblVentaCredito
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.tblVentaCredito.DefaultCellStyle = dataGridViewCellStyle4;
            this.tblVentaCredito.HeaderText = "Venta crédito";
            this.tblVentaCredito.Name = "tblVentaCredito";
            this.tblVentaCredito.ReadOnly = true;
            this.tblVentaCredito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblVentaCredito.Width = 90;
            // 
            // tblConsignacion
            // 
            dataGridViewCellStyle5.Format = "C2";
            this.tblConsignacion.DefaultCellStyle = dataGridViewCellStyle5;
            this.tblConsignacion.HeaderText = "Consignación";
            this.tblConsignacion.Name = "tblConsignacion";
            this.tblConsignacion.ReadOnly = true;
            this.tblConsignacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tblAbonos
            // 
            dataGridViewCellStyle6.Format = "C2";
            this.tblAbonos.DefaultCellStyle = dataGridViewCellStyle6;
            this.tblAbonos.HeaderText = "Abonos";
            this.tblAbonos.Name = "tblAbonos";
            this.tblAbonos.ReadOnly = true;
            this.tblAbonos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblAbonos.Width = 90;
            // 
            // tblEfectivo
            // 
            dataGridViewCellStyle7.Format = "C2";
            this.tblEfectivo.DefaultCellStyle = dataGridViewCellStyle7;
            this.tblEfectivo.HeaderText = "Total efectivo";
            this.tblEfectivo.Name = "tblEfectivo";
            this.tblEfectivo.ReadOnly = true;
            this.tblEfectivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblEfectivo.Width = 90;
            // 
            // tblTotalCom
            // 
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.tblTotalCom.DefaultCellStyle = dataGridViewCellStyle8;
            this.tblTotalCom.HeaderText = "Comisión";
            this.tblTotalCom.Name = "tblTotalCom";
            this.tblTotalCom.ReadOnly = true;
            this.tblTotalCom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblTotalCom.Width = 90;
            // 
            // Porcentaje
            // 
            this.Porcentaje.HeaderText = "%";
            this.Porcentaje.Name = "Porcentaje";
            this.Porcentaje.ReadOnly = true;
            this.Porcentaje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Porcentaje.Visible = false;
            this.Porcentaje.Width = 40;
            // 
            // Prenomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(885, 307);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.tbxPuesto);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.tblComisiones);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prenomina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prenomina";
            ((System.ComponentModel.ISupportInitialize)(this.tblComisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblComisiones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnExcel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.TextBox tbxPuesto;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblVentaContado;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblVentaCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblConsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblAbonos;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblEfectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblTotalCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje;
    }
}