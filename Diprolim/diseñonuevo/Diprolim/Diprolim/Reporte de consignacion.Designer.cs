namespace Diprolim
{
    partial class Reporte_de_consignacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte_de_consignacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rdbVendedor = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.rdbSucursal = new System.Windows.Forms.RadioButton();
            this.rdbCLiente = new System.Windows.Forms.RadioButton();
            this.cbxIm = new System.Windows.Forms.ComboBox();
            this.dtgConsignacion = new System.Windows.Forms.DataGridView();
            this.Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comisionn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgConsignacion2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todoDocumentP = new System.Drawing.Printing.PrintDocument();
            this.todoPrintPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.soloTotalesprintDocument = new System.Drawing.Printing.PrintDocument();
            this.soloTotalesprintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.tbxDias = new System.Windows.Forms.TextBox();
            this.cbxDias = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnSV = new System.Windows.Forms.Button();
            this.btnReporteHistorial = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsignacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsignacion2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbVendedor
            // 
            this.rdbVendedor.AutoSize = true;
            this.rdbVendedor.Checked = true;
            this.rdbVendedor.Location = new System.Drawing.Point(15, 39);
            this.rdbVendedor.Name = "rdbVendedor";
            this.rdbVendedor.Size = new System.Drawing.Size(88, 21);
            this.rdbVendedor.TabIndex = 201;
            this.rdbVendedor.TabStop = true;
            this.rdbVendedor.Text = "Vendedor";
            this.rdbVendedor.UseVisualStyleBackColor = true;
            this.rdbVendedor.CheckedChanged += new System.EventHandler(this.rdbVendedor_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 202;
            this.label1.Text = "Código:";
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.Location = new System.Drawing.Point(74, 66);
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(68, 23);
            this.tbxCodigo.TabIndex = 203;
            this.tbxCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCodigo_KeyDown);
            this.tbxCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCodigo_KeyPress);
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(188, 66);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.ReadOnly = true;
            this.tbxNombre.Size = new System.Drawing.Size(350, 23);
            this.tbxNombre.TabIndex = 204;
            // 
            // rdbSucursal
            // 
            this.rdbSucursal.AutoSize = true;
            this.rdbSucursal.Location = new System.Drawing.Point(113, 39);
            this.rdbSucursal.Name = "rdbSucursal";
            this.rdbSucursal.Size = new System.Drawing.Size(81, 21);
            this.rdbSucursal.TabIndex = 205;
            this.rdbSucursal.Text = "Sucursal";
            this.rdbSucursal.UseVisualStyleBackColor = true;
            this.rdbSucursal.CheckedChanged += new System.EventHandler(this.rdbSucursal_CheckedChanged);
            // 
            // rdbCLiente
            // 
            this.rdbCLiente.AutoSize = true;
            this.rdbCLiente.Location = new System.Drawing.Point(204, 39);
            this.rdbCLiente.Name = "rdbCLiente";
            this.rdbCLiente.Size = new System.Drawing.Size(69, 21);
            this.rdbCLiente.TabIndex = 206;
            this.rdbCLiente.Text = "Cliente";
            this.rdbCLiente.UseVisualStyleBackColor = true;
            this.rdbCLiente.CheckedChanged += new System.EventHandler(this.rdbCLiente_CheckedChanged);
            // 
            // cbxIm
            // 
            this.cbxIm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIm.FormattingEnabled = true;
            this.cbxIm.Items.AddRange(new object[] {
            "Todo",
            "Solo Totales"});
            this.cbxIm.Location = new System.Drawing.Point(283, 36);
            this.cbxIm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxIm.Name = "cbxIm";
            this.cbxIm.Size = new System.Drawing.Size(136, 24);
            this.cbxIm.TabIndex = 216;
            this.cbxIm.SelectedIndexChanged += new System.EventHandler(this.cbxIm_SelectedIndexChanged);
            // 
            // dtgConsignacion
            // 
            this.dtgConsignacion.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtgConsignacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgConsignacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsignacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod,
            this.Descrip,
            this.Inv,
            this.Precio,
            this.PrecioT,
            this.Comisionn,
            this.Pen,
            this.Fecha,
            this.Dias});
            this.dtgConsignacion.Location = new System.Drawing.Point(14, 100);
            this.dtgConsignacion.Margin = new System.Windows.Forms.Padding(5);
            this.dtgConsignacion.Name = "dtgConsignacion";
            this.dtgConsignacion.ReadOnly = true;
            this.dtgConsignacion.Size = new System.Drawing.Size(1077, 480);
            this.dtgConsignacion.TabIndex = 200;
            // 
            // Cod
            // 
            this.Cod.HeaderText = "Código";
            this.Cod.Name = "Cod";
            this.Cod.ReadOnly = true;
            this.Cod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cod.Width = 60;
            // 
            // Descrip
            // 
            this.Descrip.HeaderText = "Descripción";
            this.Descrip.Name = "Descrip";
            this.Descrip.ReadOnly = true;
            this.Descrip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Descrip.Width = 270;
            // 
            // Inv
            // 
            this.Inv.HeaderText = "Inv/Abarrote";
            this.Inv.Name = "Inv";
            this.Inv.ReadOnly = true;
            this.Inv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Precio
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle2;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PrecioT
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.PrecioT.DefaultCellStyle = dataGridViewCellStyle3;
            this.PrecioT.HeaderText = "Precio/Total";
            this.PrecioT.Name = "PrecioT";
            this.PrecioT.ReadOnly = true;
            this.PrecioT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Comisionn
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.Comisionn.DefaultCellStyle = dataGridViewCellStyle4;
            this.Comisionn.HeaderText = "% Comision";
            this.Comisionn.Name = "Comisionn";
            this.Comisionn.ReadOnly = true;
            this.Comisionn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pen
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.Pen.DefaultCellStyle = dataGridViewCellStyle5;
            this.Pen.HeaderText = "Pendiente";
            this.Pen.Name = "Pen";
            this.Pen.ReadOnly = true;
            this.Pen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Dias
            // 
            this.Dias.HeaderText = "Dias";
            this.Dias.Name = "Dias";
            this.Dias.ReadOnly = true;
            // 
            // dtgConsignacion2
            // 
            this.dtgConsignacion2.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtgConsignacion2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgConsignacion2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsignacion2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dtgConsignacion2.Location = new System.Drawing.Point(14, 100);
            this.dtgConsignacion2.Margin = new System.Windows.Forms.Padding(5);
            this.dtgConsignacion2.Name = "dtgConsignacion2";
            this.dtgConsignacion2.ReadOnly = true;
            this.dtgConsignacion2.Size = new System.Drawing.Size(892, 480);
            this.dtgConsignacion2.TabIndex = 217;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 270;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Inv/Abarrote";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "Pendiente";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn5.HeaderText = "-----";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn6.HeaderText = "-----";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn7.HeaderText = "-----";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // todoDocumentP
            // 
            this.todoDocumentP.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.todoDocumentP_PrintPage);
            // 
            // todoPrintPreviewDialog1
            // 
            this.todoPrintPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.todoPrintPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.todoPrintPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.todoPrintPreviewDialog1.Document = this.todoDocumentP;
            this.todoPrintPreviewDialog1.Enabled = true;
            this.todoPrintPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("todoPrintPreviewDialog1.Icon")));
            this.todoPrintPreviewDialog1.Name = "todoPrintPreviewDialog1";
            this.todoPrintPreviewDialog1.Visible = false;
            // 
            // soloTotalesprintDocument
            // 
            this.soloTotalesprintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.soloTotalesprintDocument_PrintPage);
            // 
            // soloTotalesprintPreviewDialog
            // 
            this.soloTotalesprintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.soloTotalesprintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.soloTotalesprintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.soloTotalesprintPreviewDialog.Document = this.soloTotalesprintDocument;
            this.soloTotalesprintPreviewDialog.Enabled = true;
            this.soloTotalesprintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("soloTotalesprintPreviewDialog.Icon")));
            this.soloTotalesprintPreviewDialog.Name = "soloTotalesprintPreviewDialog";
            this.soloTotalesprintPreviewDialog.Visible = false;
            // 
            // tbxDias
            // 
            this.tbxDias.Location = new System.Drawing.Point(815, 62);
            this.tbxDias.Name = "tbxDias";
            this.tbxDias.Size = new System.Drawing.Size(53, 23);
            this.tbxDias.TabIndex = 267;
            this.tbxDias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDias_KeyDown);
            // 
            // cbxDias
            // 
            this.cbxDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDias.FormattingEnabled = true;
            this.cbxDias.Items.AddRange(new object[] {
            "Todos",
            "Días menor que",
            "Días mayor que"});
            this.cbxDias.Location = new System.Drawing.Point(688, 62);
            this.cbxDias.Name = "cbxDias";
            this.cbxDias.Size = new System.Drawing.Size(121, 24);
            this.cbxDias.TabIndex = 266;
            this.cbxDias.SelectedIndexChanged += new System.EventHandler(this.cbxDias_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Diass,
            this.idCliente,
            this.F});
            this.dataGridView1.Location = new System.Drawing.Point(14, 101);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1077, 479);
            this.dataGridView1.TabIndex = 269;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Vendedor";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 270;
            // 
            // Diass
            // 
            this.Diass.HeaderText = "Dias";
            this.Diass.Name = "Diass";
            this.Diass.ReadOnly = true;
            // 
            // idCliente
            // 
            this.idCliente.HeaderText = "idCliente";
            this.idCliente.Name = "idCliente";
            this.idCliente.ReadOnly = true;
            // 
            // F
            // 
            this.F.HeaderText = "Fecha";
            this.F.Name = "F";
            this.F.ReadOnly = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(641, 56);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(40, 40);
            this.btnImprimir.TabIndex = 219;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.Location = new System.Drawing.Point(593, 56);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(40, 40);
            this.btnExcel.TabIndex = 218;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(150, 61);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 215;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // btnReporteHistorial
            // 
            this.btnReporteHistorial.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporteHistorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporteHistorial.Location = new System.Drawing.Point(545, 56);
            this.btnReporteHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporteHistorial.Name = "btnReporteHistorial";
            this.btnReporteHistorial.Size = new System.Drawing.Size(40, 40);
            this.btnReporteHistorial.TabIndex = 207;
            this.btnReporteHistorial.UseVisualStyleBackColor = true;
            this.btnReporteHistorial.Click += new System.EventHandler(this.btnReporteHistorial_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(875, 45);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 270;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Reporte_de_consignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1105, 594);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxDias);
            this.Controls.Add(this.cbxDias);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.cbxIm);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.btnReporteHistorial);
            this.Controls.Add(this.rdbCLiente);
            this.Controls.Add(this.rdbSucursal);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.tbxCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbVendedor);
            this.Controls.Add(this.dtgConsignacion);
            this.Controls.Add(this.dtgConsignacion2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Reporte_de_consignacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de consignación";
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsignacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsignacion2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.RadioButton rdbSucursal;
        private System.Windows.Forms.RadioButton rdbCLiente;
        private System.Windows.Forms.Button btnReporteHistorial;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.ComboBox cbxIm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pendiente;
        private System.Windows.Forms.DataGridView dtgConsignacion;
        private System.Windows.Forms.DataGridView dtgConsignacion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnExcel;
        private System.Drawing.Printing.PrintDocument todoDocumentP;
        private System.Windows.Forms.PrintPreviewDialog todoPrintPreviewDialog1;
        private System.Drawing.Printing.PrintDocument soloTotalesprintDocument;
        private System.Windows.Forms.PrintPreviewDialog soloTotalesprintPreviewDialog;
        private System.Windows.Forms.TextBox tbxDias;
        private System.Windows.Forms.ComboBox cbxDias;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diass;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn F;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comisionn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.Button button1;
    }
}