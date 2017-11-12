namespace Diprolim
{
    partial class ReporteSalidasInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteSalidasInventario));
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxMotivo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.tblReporteE = new System.Windows.Forms.DataGridView();
            this.dtArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgNombreArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblComentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.cbxUnMedida = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxFolio = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblReporteE)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(315, 59);
            this.tbxNombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.ReadOnly = true;
            this.tbxNombre.Size = new System.Drawing.Size(243, 23);
            this.tbxNombre.TabIndex = 157;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 16);
            this.label5.TabIndex = 156;
            this.label5.Text = "Codigo del producto:";
            // 
            // tbxProducto
            // 
            this.tbxProducto.Location = new System.Drawing.Point(169, 59);
            this.tbxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProducto.Name = "tbxProducto";
            this.tbxProducto.Size = new System.Drawing.Size(90, 23);
            this.tbxProducto.TabIndex = 155;
            this.tbxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxProducto_KeyDown);
            this.tbxProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxProducto_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-113, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 153;
            this.label4.Text = "Motivo:";
            // 
            // cbxMotivo
            // 
            this.cbxMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMotivo.FormattingEnabled = true;
            this.cbxMotivo.Items.AddRange(new object[] {
            "Todas",
            "Transferencia ",
            "Obsequio",
            "Consumo Interno",
            "Otros"});
            this.cbxMotivo.Location = new System.Drawing.Point(169, 90);
            this.cbxMotivo.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMotivo.Name = "cbxMotivo";
            this.cbxMotivo.Size = new System.Drawing.Size(130, 24);
            this.cbxMotivo.TabIndex = 152;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 151;
            this.label2.Text = "-";
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(352, 27);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFin.MinDate = new System.DateTime(2000, 2, 2, 0, 0, 0, 0);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(154, 23);
            this.dtpFin.TabIndex = 146;
            this.dtpFin.Value = new System.DateTime(2014, 2, 2, 23, 59, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 150;
            this.label1.Text = "Rangos de Fecha:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(169, 27);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicio.MinDate = new System.DateTime(2000, 2, 2, 0, 0, 0, 0);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(154, 23);
            this.dtpInicio.TabIndex = 149;
            this.dtpInicio.Value = new System.DateTime(2014, 2, 2, 0, 0, 0, 0);
            // 
            // tblReporteE
            // 
            this.tblReporteE.AllowUserToAddRows = false;
            this.tblReporteE.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblReporteE.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tblReporteE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblReporteE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtArticulo,
            this.dtgNombreArt,
            this.tblCantidad,
            this.tblFecha,
            this.tblMotivo,
            this.tblComentarios});
            this.tblReporteE.Location = new System.Drawing.Point(11, 122);
            this.tblReporteE.Margin = new System.Windows.Forms.Padding(4);
            this.tblReporteE.Name = "tblReporteE";
            this.tblReporteE.ReadOnly = true;
            this.tblReporteE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblReporteE.Size = new System.Drawing.Size(945, 399);
            this.tblReporteE.TabIndex = 147;
            this.tblReporteE.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblReporteE_CellContentClick);
            this.tblReporteE.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.tblReporteE_SortCompare);
            // 
            // dtArticulo
            // 
            this.dtArticulo.HeaderText = "Código Articulo";
            this.dtArticulo.Name = "dtArticulo";
            this.dtArticulo.ReadOnly = true;
            this.dtArticulo.Width = 70;
            // 
            // dtgNombreArt
            // 
            this.dtgNombreArt.HeaderText = "Nombre Articulo";
            this.dtgNombreArt.Name = "dtgNombreArt";
            this.dtgNombreArt.ReadOnly = true;
            this.dtgNombreArt.Width = 265;
            // 
            // tblCantidad
            // 
            this.tblCantidad.HeaderText = "Cantidad";
            this.tblCantidad.Name = "tblCantidad";
            this.tblCantidad.ReadOnly = true;
            this.tblCantidad.Width = 75;
            // 
            // tblFecha
            // 
            this.tblFecha.HeaderText = "Fecha";
            this.tblFecha.Name = "tblFecha";
            this.tblFecha.ReadOnly = true;
            this.tblFecha.Width = 180;
            // 
            // tblMotivo
            // 
            this.tblMotivo.HeaderText = "Motivo";
            this.tblMotivo.Name = "tblMotivo";
            this.tblMotivo.ReadOnly = true;
            this.tblMotivo.Width = 150;
            // 
            // tblComentarios
            // 
            this.tblComentarios.HeaderText = "Comentarios";
            this.tblComentarios.Name = "tblComentarios";
            this.tblComentarios.ReadOnly = true;
            this.tblComentarios.Width = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 159;
            this.label3.Text = "Motivo:";
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
            // cbxUnMedida
            // 
            this.cbxUnMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnMedida.FormattingEnabled = true;
            this.cbxUnMedida.Location = new System.Drawing.Point(457, 90);
            this.cbxUnMedida.Name = "cbxUnMedida";
            this.cbxUnMedida.Size = new System.Drawing.Size(132, 24);
            this.cbxUnMedida.TabIndex = 165;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(312, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 17);
            this.label7.TabIndex = 164;
            this.label7.Text = "Unidades medida:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(566, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 221;
            this.label6.Text = "Folio:";
            // 
            // tbxFolio
            // 
            this.tbxFolio.Location = new System.Drawing.Point(621, 59);
            this.tbxFolio.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFolio.Name = "tbxFolio";
            this.tbxFolio.Size = new System.Drawing.Size(90, 23);
            this.tbxFolio.TabIndex = 220;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(911, 69);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(45, 45);
            this.btnImprimir.TabIndex = 160;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Location = new System.Drawing.Point(269, 54);
            this.btnSP.Margin = new System.Windows.Forms.Padding(4);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 158;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporte.Location = new System.Drawing.Point(805, 69);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(45, 45);
            this.btnReporte.TabIndex = 154;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(858, 69);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 45);
            this.button2.TabIndex = 148;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(719, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 222;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReporteSalidasInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(967, 535);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxFolio);
            this.Controls.Add(this.cbxUnMedida);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxProducto);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxMotivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tblReporteE);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ReporteSalidasInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de salidas sucursal";
            ((System.ComponentModel.ISupportInitialize)(this.tblReporteE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxProducto;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxMotivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView tblReporteE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImprimir;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgNombreArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblComentarios;
        private System.Windows.Forms.ComboBox cbxUnMedida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxFolio;
        private System.Windows.Forms.Button button1;
    }
}