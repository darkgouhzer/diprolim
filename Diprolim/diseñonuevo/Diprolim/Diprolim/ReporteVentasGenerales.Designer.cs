namespace Diprolim
{
    partial class ReporteVentasGenerales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteVentasGenerales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxNCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.tbxNProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxProducto = new System.Windows.Forms.TextBox();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.tblReporteV = new System.Windows.Forms.DataGridView();
            this.tblCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.cbxDepto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxUnMedida = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tblReporteV2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdbSoloT = new System.Windows.Forms.RadioButton();
            this.rdbTodo = new System.Windows.Forms.RadioButton();
            this.btnSC = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.btnSV = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.printPreviewDialogTotales = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocumentTotales = new System.Drawing.Printing.PrintDocument();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxTipoVenta = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblReporteV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReporteV2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(555, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 51);
            this.label2.TabIndex = 129;
            this.label2.Text = "Rangos\r\n   De\r\nFechas";
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(158, 107);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(132, 24);
            this.cbxCategoria.TabIndex = 128;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(53, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 127;
            this.label5.Text = "Tipo cliente:";
            // 
            // tbxNCliente
            // 
            this.tbxNCliente.Location = new System.Drawing.Point(299, 45);
            this.tbxNCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCliente.Name = "tbxNCliente";
            this.tbxNCliente.ReadOnly = true;
            this.tbxNCliente.Size = new System.Drawing.Size(248, 23);
            this.tbxNCliente.TabIndex = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(88, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 124;
            this.label4.Text = "Cliente:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Location = new System.Drawing.Point(158, 45);
            this.tbxCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(93, 23);
            this.tbxCliente.TabIndex = 123;
            this.tbxCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCliente_KeyDown);
            this.tbxCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCliente_KeyPress);
            // 
            // tbxNProducto
            // 
            this.tbxNProducto.Location = new System.Drawing.Point(299, 76);
            this.tbxNProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNProducto.Name = "tbxNProducto";
            this.tbxNProducto.ReadOnly = true;
            this.tbxNProducto.Size = new System.Drawing.Size(248, 23);
            this.tbxNProducto.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(73, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 120;
            this.label1.Text = "Producto:";
            // 
            // tbxProducto
            // 
            this.tbxProducto.Location = new System.Drawing.Point(158, 76);
            this.tbxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProducto.Name = "tbxProducto";
            this.tbxProducto.Size = new System.Drawing.Size(93, 23);
            this.tbxProducto.TabIndex = 119;
            this.tbxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxProducto_KeyDown);
            this.tbxProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxProducto_KeyPress);
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Location = new System.Drawing.Point(299, 14);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(248, 23);
            this.tbxNVendedor.TabIndex = 116;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(68, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 115;
            this.label3.Text = "Vendedor:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Location = new System.Drawing.Point(158, 14);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(93, 23);
            this.tbxVendedor.TabIndex = 111;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "dd/MMM/yyyy";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(620, 45);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(116, 23);
            this.dtpFin.TabIndex = 110;
            this.dtpFin.Value = new System.DateTime(2013, 10, 19, 0, 0, 0, 0);
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MMM/yyyy";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(620, 14);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(116, 23);
            this.dtpInicio.TabIndex = 109;
            this.dtpInicio.Value = new System.DateTime(2013, 10, 19, 0, 0, 0, 0);
            // 
            // tblReporteV
            // 
            this.tblReporteV.AllowUserToAddRows = false;
            this.tblReporteV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblReporteV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tblReporteV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblReporteV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tblCodigo,
            this.tblProducto,
            this.tblCantidad,
            this.tblTotal});
            this.tblReporteV.Location = new System.Drawing.Point(13, 176);
            this.tblReporteV.Margin = new System.Windows.Forms.Padding(4);
            this.tblReporteV.Name = "tblReporteV";
            this.tblReporteV.ReadOnly = true;
            this.tblReporteV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblReporteV.Size = new System.Drawing.Size(723, 297);
            this.tblReporteV.TabIndex = 114;
            this.tblReporteV.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.tblReporteV_SortCompare);
            // 
            // tblCodigo
            // 
            this.tblCodigo.HeaderText = "Código articulo";
            this.tblCodigo.Name = "tblCodigo";
            this.tblCodigo.ReadOnly = true;
            this.tblCodigo.Width = 80;
            // 
            // tblProducto
            // 
            this.tblProducto.HeaderText = "Producto";
            this.tblProducto.Name = "tblProducto";
            this.tblProducto.ReadOnly = true;
            this.tblProducto.Width = 330;
            // 
            // tblCantidad
            // 
            this.tblCantidad.HeaderText = "Unidades vendidas";
            this.tblCantidad.Name = "tblCantidad";
            this.tblCantidad.ReadOnly = true;
            // 
            // tblTotal
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.tblTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblTotal.HeaderText = "Total";
            this.tblTotal.Name = "tblTotal";
            this.tblTotal.ReadOnly = true;
            this.tblTotal.Width = 120;
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
            // cbxDepto
            // 
            this.cbxDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepto.FormattingEnabled = true;
            this.cbxDepto.Items.AddRange(new object[] {
            "Todos",
            "Productos",
            "Accesorios",
            "Papel"});
            this.cbxDepto.Location = new System.Drawing.Point(418, 107);
            this.cbxDepto.Name = "cbxDepto";
            this.cbxDepto.Size = new System.Drawing.Size(132, 24);
            this.cbxDepto.TabIndex = 131;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(296, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 17);
            this.label6.TabIndex = 130;
            this.label6.Text = "Departamento:";
            // 
            // cbxUnMedida
            // 
            this.cbxUnMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnMedida.FormattingEnabled = true;
            this.cbxUnMedida.Location = new System.Drawing.Point(158, 137);
            this.cbxUnMedida.Name = "cbxUnMedida";
            this.cbxUnMedida.Size = new System.Drawing.Size(132, 24);
            this.cbxUnMedida.TabIndex = 137;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(13, 140);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 17);
            this.label7.TabIndex = 136;
            this.label7.Text = "Unidades medida:";
            // 
            // tblReporteV2
            // 
            this.tblReporteV2.AllowUserToAddRows = false;
            this.tblReporteV2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblReporteV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.tblReporteV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblReporteV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.tblReporteV2.Location = new System.Drawing.Point(13, 176);
            this.tblReporteV2.Margin = new System.Windows.Forms.Padding(4);
            this.tblReporteV2.Name = "tblReporteV2";
            this.tblReporteV2.ReadOnly = true;
            this.tblReporteV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblReporteV2.Size = new System.Drawing.Size(723, 297);
            this.tblReporteV2.TabIndex = 138;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Código ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Vendedor";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "Total";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // rdbSoloT
            // 
            this.rdbSoloT.AutoSize = true;
            this.rdbSoloT.Location = new System.Drawing.Point(572, 102);
            this.rdbSoloT.Name = "rdbSoloT";
            this.rdbSoloT.Size = new System.Drawing.Size(100, 21);
            this.rdbSoloT.TabIndex = 140;
            this.rdbSoloT.Text = "Solo totales";
            this.rdbSoloT.UseVisualStyleBackColor = true;
            this.rdbSoloT.CheckedChanged += new System.EventHandler(this.rdbSoloT_CheckedChanged);
            // 
            // rdbTodo
            // 
            this.rdbTodo.AutoSize = true;
            this.rdbTodo.Checked = true;
            this.rdbTodo.Location = new System.Drawing.Point(572, 75);
            this.rdbTodo.Name = "rdbTodo";
            this.rdbTodo.Size = new System.Drawing.Size(59, 21);
            this.rdbTodo.TabIndex = 139;
            this.rdbTodo.TabStop = true;
            this.rdbTodo.Text = "Todo";
            this.rdbTodo.UseVisualStyleBackColor = true;
            this.rdbTodo.CheckedChanged += new System.EventHandler(this.rdbTodo_CheckedChanged);
            // 
            // btnSC
            // 
            this.btnSC.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSC.Location = new System.Drawing.Point(260, 40);
            this.btnSC.Margin = new System.Windows.Forms.Padding(5);
            this.btnSC.Name = "btnSC";
            this.btnSC.Size = new System.Drawing.Size(30, 30);
            this.btnSC.TabIndex = 126;
            this.btnSC.UseVisualStyleBackColor = true;
            this.btnSC.Click += new System.EventHandler(this.btnSC_Click);
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Location = new System.Drawing.Point(260, 72);
            this.btnSP.Margin = new System.Windows.Forms.Padding(5);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 122;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(260, 10);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 118;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(674, 128);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(40, 40);
            this.btnImprimir.TabIndex = 117;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporte.Location = new System.Drawing.Point(578, 128);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(40, 40);
            this.btnReporte.TabIndex = 112;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.Location = new System.Drawing.Point(626, 128);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(40, 40);
            this.btnExcel.TabIndex = 113;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // printPreviewDialogTotales
            // 
            this.printPreviewDialogTotales.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialogTotales.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialogTotales.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialogTotales.Document = this.printDocumentTotales;
            this.printPreviewDialogTotales.Enabled = true;
            this.printPreviewDialogTotales.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialogTotales.Icon")));
            this.printPreviewDialogTotales.Name = "printPreviewDialogTotales";
            this.printPreviewDialogTotales.Visible = false;
            // 
            // printDocumentTotales
            // 
            this.printDocumentTotales.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentTotales_PrintPage);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(298, 140);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 17);
            this.label8.TabIndex = 142;
            this.label8.Text = "Tipo de venta:";
            // 
            // cbxTipoVenta
            // 
            this.cbxTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoVenta.FormattingEnabled = true;
            this.cbxTipoVenta.Items.AddRange(new object[] {
            "Todos",
            "Contado",
            "Crédito",
            "Consignación"});
            this.cbxTipoVenta.Location = new System.Drawing.Point(418, 137);
            this.cbxTipoVenta.Name = "cbxTipoVenta";
            this.cbxTipoVenta.Size = new System.Drawing.Size(132, 24);
            this.cbxTipoVenta.TabIndex = 141;
            // 
            // ReporteVentasGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(752, 486);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxTipoVenta);
            this.Controls.Add(this.rdbSoloT);
            this.Controls.Add(this.rdbTodo);
            this.Controls.Add(this.cbxUnMedida);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxDepto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCategoria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSC);
            this.Controls.Add(this.tbxNCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxCliente);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.tbxNProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxProducto);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.tblReporteV);
            this.Controls.Add(this.tblReporteV2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ReporteVentasGenerales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte ventas generales";
            ((System.ComponentModel.ISupportInitialize)(this.tblReporteV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReporteV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCategoria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSC;
        private System.Windows.Forms.TextBox tbxNCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.TextBox tbxNProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxProducto;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DataGridView tblReporteV;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ComboBox cbxDepto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxUnMedida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView tblReporteV2;
        private System.Windows.Forms.RadioButton rdbSoloT;
        private System.Windows.Forms.RadioButton rdbTodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogTotales;
        private System.Drawing.Printing.PrintDocument printDocumentTotales;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxTipoVenta;
    }
}