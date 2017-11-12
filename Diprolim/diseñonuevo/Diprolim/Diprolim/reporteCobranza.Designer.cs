namespace Diprolim
{
    partial class reporteCobranza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reporteCobranza));
            this.dtgCrTabla = new System.Windows.Forms.DataGridView();
            this.tblFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblClientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblAbono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgHistTabla = new System.Windows.Forms.DataGridView();
            this.tblHFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblHAdeudo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblHAbono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblHFiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btlHPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblHDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.btnImprimirHistorial = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.btnReporteHistorial = new System.Windows.Forms.Button();
            this.btnRVendedor = new System.Windows.Forms.Button();
            this.btnExcelHistorial = new System.Windows.Forms.Button();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxNCliente = new System.Windows.Forms.TextBox();
            this.btnRCliente = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxFolio = new System.Windows.Forms.TextBox();
            this.rbtTodas = new System.Windows.Forms.RadioButton();
            this.dtpInicioC = new System.Windows.Forms.DateTimePicker();
            this.rbtInactivas = new System.Windows.Forms.RadioButton();
            this.tbxCrVendedor = new System.Windows.Forms.TextBox();
            this.rbtActivas = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxNCrVendedor = new System.Windows.Forms.TextBox();
            this.btnImprimirCr = new System.Windows.Forms.Button();
            this.btnSCrV = new System.Windows.Forms.Button();
            this.btnReporteCr = new System.Windows.Forms.Button();
            this.btnCrRVendedor = new System.Windows.Forms.Button();
            this.btnExcelCr = new System.Windows.Forms.Button();
            this.tbxCrCliente = new System.Windows.Forms.TextBox();
            this.dtpFinC = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxNCrCliente = new System.Windows.Forms.TextBox();
            this.btnCrRCliente = new System.Windows.Forms.Button();
            this.btnSPCrC = new System.Windows.Forms.Button();
            this.printDocHistorial = new System.Drawing.Printing.PrintDocument();
            this.printPreviewHistorial = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocCreditos = new System.Drawing.Printing.PrintDocument();
            this.printPreviewCreditos = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCrTabla)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistTabla)).BeginInit();
            this.tabPage2.SuspendLayout();
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
            this.tblClientes,
            this.tblCredito,
            this.tblAbono,
            this.tblSaldo,
            this.tblDias});
            this.dtgCrTabla.Location = new System.Drawing.Point(46, 121);
            this.dtgCrTabla.Name = "dtgCrTabla";
            this.dtgCrTabla.ReadOnly = true;
            this.dtgCrTabla.Size = new System.Drawing.Size(940, 374);
            this.dtgCrTabla.TabIndex = 242;
            this.dtgCrTabla.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dtgCrTabla_SortCompare);
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
            // tblClientes
            // 
            this.tblClientes.HeaderText = "Cliente";
            this.tblClientes.Name = "tblClientes";
            this.tblClientes.ReadOnly = true;
            this.tblClientes.Width = 300;
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
            this.tblAbono.HeaderText = "Abono";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1038, 549);
            this.tabControl1.TabIndex = 244;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtgHistTabla);
            this.tabPage1.Controls.Add(this.dtpInicio);
            this.tabPage1.Controls.Add(this.tbxVendedor);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbxNVendedor);
            this.tabPage1.Controls.Add(this.btnImprimirHistorial);
            this.tabPage1.Controls.Add(this.btnSP);
            this.tabPage1.Controls.Add(this.btnReporteHistorial);
            this.tabPage1.Controls.Add(this.btnRVendedor);
            this.tabPage1.Controls.Add(this.btnExcelHistorial);
            this.tabPage1.Controls.Add(this.tbxCliente);
            this.tabPage1.Controls.Add(this.dtpFin);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbxNCliente);
            this.tabPage1.Controls.Add(this.btnRCliente);
            this.tabPage1.Controls.Add(this.btnB);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1030, 520);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Historial";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgHistTabla
            // 
            this.dtgHistTabla.AllowUserToAddRows = false;
            this.dtgHistTabla.AllowUserToDeleteRows = false;
            this.dtgHistTabla.AllowUserToResizeColumns = false;
            this.dtgHistTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tblHFecha,
            this.tblHAdeudo,
            this.tblHAbono,
            this.tblHFiado,
            this.btlHPendiente,
            this.tblHDias});
            this.dtgHistTabla.Location = new System.Drawing.Point(197, 121);
            this.dtgHistTabla.Margin = new System.Windows.Forms.Padding(4);
            this.dtgHistTabla.Name = "dtgHistTabla";
            this.dtgHistTabla.ReadOnly = true;
            this.dtgHistTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHistTabla.Size = new System.Drawing.Size(642, 374);
            this.dtgHistTabla.TabIndex = 183;
            // 
            // tblHFecha
            // 
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.tblHFecha.DefaultCellStyle = dataGridViewCellStyle5;
            this.tblHFecha.HeaderText = "Fecha";
            this.tblHFecha.Name = "tblHFecha";
            this.tblHFecha.ReadOnly = true;
            // 
            // tblHAdeudo
            // 
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.tblHAdeudo.DefaultCellStyle = dataGridViewCellStyle6;
            this.tblHAdeudo.HeaderText = "Adeudo";
            this.tblHAdeudo.Name = "tblHAdeudo";
            this.tblHAdeudo.ReadOnly = true;
            // 
            // tblHAbono
            // 
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.tblHAbono.DefaultCellStyle = dataGridViewCellStyle7;
            this.tblHAbono.HeaderText = "Abono";
            this.tblHAbono.Name = "tblHAbono";
            this.tblHAbono.ReadOnly = true;
            // 
            // tblHFiado
            // 
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.tblHFiado.DefaultCellStyle = dataGridViewCellStyle8;
            this.tblHFiado.HeaderText = "Fiado Nuevo";
            this.tblHFiado.Name = "tblHFiado";
            this.tblHFiado.ReadOnly = true;
            // 
            // btlHPendiente
            // 
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.btlHPendiente.DefaultCellStyle = dataGridViewCellStyle9;
            this.btlHPendiente.HeaderText = "Pendiente";
            this.btlHPendiente.Name = "btlHPendiente";
            this.btlHPendiente.ReadOnly = true;
            // 
            // tblHDias
            // 
            this.tblHDias.HeaderText = "Dias";
            this.tblHDias.Name = "tblHDias";
            this.tblHDias.ReadOnly = true;
            this.tblHDias.Width = 60;
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MMM/yyyy";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(251, 21);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(116, 23);
            this.dtpInicio.TabIndex = 208;
            this.dtpInicio.Value = new System.DateTime(2013, 10, 19, 0, 0, 0, 0);
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxVendedor.Location = new System.Drawing.Point(251, 52);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.MaxLength = 9;
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(71, 22);
            this.tbxVendedor.TabIndex = 0;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(371, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 241;
            this.label2.Text = "a";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(160, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 186;
            this.label4.Text = "Vendedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(160, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 240;
            this.label3.Text = "De:";
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNVendedor.Location = new System.Drawing.Point(368, 52);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(303, 22);
            this.tbxNVendedor.TabIndex = 187;
            // 
            // btnImprimirHistorial
            // 
            this.btnImprimirHistorial.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimirHistorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirHistorial.Location = new System.Drawing.Point(813, 73);
            this.btnImprimirHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimirHistorial.Name = "btnImprimirHistorial";
            this.btnImprimirHistorial.Size = new System.Drawing.Size(40, 40);
            this.btnImprimirHistorial.TabIndex = 4;
            this.btnImprimirHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirHistorial.UseVisualStyleBackColor = true;
            this.btnImprimirHistorial.Click += new System.EventHandler(this.btnImprimirHistorial_Click);
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSP.Location = new System.Drawing.Point(330, 48);
            this.btnSP.Margin = new System.Windows.Forms.Padding(4);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 188;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // btnReporteHistorial
            // 
            this.btnReporteHistorial.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporteHistorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporteHistorial.Location = new System.Drawing.Point(717, 73);
            this.btnReporteHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporteHistorial.Name = "btnReporteHistorial";
            this.btnReporteHistorial.Size = new System.Drawing.Size(40, 40);
            this.btnReporteHistorial.TabIndex = 2;
            this.btnReporteHistorial.UseVisualStyleBackColor = true;
            this.btnReporteHistorial.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnRVendedor
            // 
            this.btnRVendedor.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnRVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRVendedor.FlatAppearance.BorderSize = 0;
            this.btnRVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRVendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRVendedor.Location = new System.Drawing.Point(679, 48);
            this.btnRVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnRVendedor.Name = "btnRVendedor";
            this.btnRVendedor.Size = new System.Drawing.Size(30, 30);
            this.btnRVendedor.TabIndex = 189;
            this.btnRVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRVendedor.UseVisualStyleBackColor = true;
            this.btnRVendedor.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnExcelHistorial
            // 
            this.btnExcelHistorial.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcelHistorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcelHistorial.Location = new System.Drawing.Point(765, 73);
            this.btnExcelHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcelHistorial.Name = "btnExcelHistorial";
            this.btnExcelHistorial.Size = new System.Drawing.Size(40, 40);
            this.btnExcelHistorial.TabIndex = 3;
            this.btnExcelHistorial.UseVisualStyleBackColor = true;
            this.btnExcelHistorial.Click += new System.EventHandler(this.btnExcelHistorial_Click);
            // 
            // tbxCliente
            // 
            this.tbxCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCliente.Location = new System.Drawing.Point(251, 82);
            this.tbxCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCliente.MaxLength = 9;
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(71, 22);
            this.tbxCliente.TabIndex = 1;
            this.tbxCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCliente_KeyDown);
            this.tbxCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCliente_KeyPress);
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "dd/MMM/yyyy";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(396, 21);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(116, 23);
            this.dtpFin.TabIndex = 209;
            this.dtpFin.Value = new System.DateTime(2014, 3, 23, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 194;
            this.label1.Text = "Cliente:";
            // 
            // tbxNCliente
            // 
            this.tbxNCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNCliente.Location = new System.Drawing.Point(368, 82);
            this.tbxNCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCliente.Name = "tbxNCliente";
            this.tbxNCliente.ReadOnly = true;
            this.tbxNCliente.Size = new System.Drawing.Size(303, 22);
            this.tbxNCliente.TabIndex = 195;
            // 
            // btnRCliente
            // 
            this.btnRCliente.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnRCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRCliente.FlatAppearance.BorderSize = 0;
            this.btnRCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRCliente.Location = new System.Drawing.Point(679, 78);
            this.btnRCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnRCliente.Name = "btnRCliente";
            this.btnRCliente.Size = new System.Drawing.Size(30, 30);
            this.btnRCliente.TabIndex = 197;
            this.btnRCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRCliente.UseVisualStyleBackColor = true;
            this.btnRCliente.Click += new System.EventHandler(this.btnR_Click);
            // 
            // btnB
            // 
            this.btnB.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnB.Location = new System.Drawing.Point(330, 78);
            this.btnB.Margin = new System.Windows.Forms.Padding(4);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(30, 30);
            this.btnB.TabIndex = 196;
            this.btnB.UseVisualStyleBackColor = true;
            this.btnB.Click += new System.EventHandler(this.btnB_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbxFolio);
            this.tabPage2.Controls.Add(this.rbtTodas);
            this.tabPage2.Controls.Add(this.dtpInicioC);
            this.tabPage2.Controls.Add(this.rbtInactivas);
            this.tabPage2.Controls.Add(this.tbxCrVendedor);
            this.tabPage2.Controls.Add(this.rbtActivas);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbxNCrVendedor);
            this.tabPage2.Controls.Add(this.btnImprimirCr);
            this.tabPage2.Controls.Add(this.btnSCrV);
            this.tabPage2.Controls.Add(this.btnReporteCr);
            this.tabPage2.Controls.Add(this.btnCrRVendedor);
            this.tabPage2.Controls.Add(this.btnExcelCr);
            this.tabPage2.Controls.Add(this.tbxCrCliente);
            this.tabPage2.Controls.Add(this.dtpFinC);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tbxNCrCliente);
            this.tabPage2.Controls.Add(this.btnCrRCliente);
            this.tabPage2.Controls.Add(this.btnSPCrC);
            this.tabPage2.Controls.Add(this.dtgCrTabla);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1030, 520);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Creditos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(746, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 263;
            this.label5.Text = "Folio:";
            // 
            // tbxFolio
            // 
            this.tbxFolio.Location = new System.Drawing.Point(801, 20);
            this.tbxFolio.Name = "tbxFolio";
            this.tbxFolio.Size = new System.Drawing.Size(52, 23);
            this.tbxFolio.TabIndex = 262;
            // 
            // rbtTodas
            // 
            this.rbtTodas.AutoSize = true;
            this.rbtTodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtTodas.Location = new System.Drawing.Point(673, 20);
            this.rbtTodas.Name = "rbtTodas";
            this.rbtTodas.Size = new System.Drawing.Size(66, 21);
            this.rbtTodas.TabIndex = 3;
            this.rbtTodas.Text = "Todas";
            this.rbtTodas.UseVisualStyleBackColor = true;
            // 
            // dtpInicioC
            // 
            this.dtpInicioC.CustomFormat = "dd/MMM/yyyy";
            this.dtpInicioC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicioC.Location = new System.Drawing.Point(251, 21);
            this.dtpInicioC.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicioC.Name = "dtpInicioC";
            this.dtpInicioC.Size = new System.Drawing.Size(116, 23);
            this.dtpInicioC.TabIndex = 255;
            this.dtpInicioC.Value = new System.DateTime(2013, 10, 19, 0, 0, 0, 0);
            // 
            // rbtInactivas
            // 
            this.rbtInactivas.AutoSize = true;
            this.rbtInactivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtInactivas.Location = new System.Drawing.Point(590, 20);
            this.rbtInactivas.Name = "rbtInactivas";
            this.rbtInactivas.Size = new System.Drawing.Size(81, 21);
            this.rbtInactivas.TabIndex = 2;
            this.rbtInactivas.Text = "Inactivas";
            this.rbtInactivas.UseVisualStyleBackColor = true;
            // 
            // tbxCrVendedor
            // 
            this.tbxCrVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCrVendedor.Location = new System.Drawing.Point(251, 52);
            this.tbxCrVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCrVendedor.MaxLength = 9;
            this.tbxCrVendedor.Name = "tbxCrVendedor";
            this.tbxCrVendedor.Size = new System.Drawing.Size(71, 22);
            this.tbxCrVendedor.TabIndex = 5;
            this.tbxCrVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCrVendedor_KeyDown);
            this.tbxCrVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCrVendedor_KeyPress);
            // 
            // rbtActivas
            // 
            this.rbtActivas.AutoSize = true;
            this.rbtActivas.Checked = true;
            this.rbtActivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtActivas.Location = new System.Drawing.Point(519, 20);
            this.rbtActivas.Name = "rbtActivas";
            this.rbtActivas.Size = new System.Drawing.Size(71, 21);
            this.rbtActivas.TabIndex = 1;
            this.rbtActivas.TabStop = true;
            this.rbtActivas.Text = "Activas";
            this.rbtActivas.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(371, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 261;
            this.label6.Text = "a";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(160, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 246;
            this.label7.Text = "Vendedor:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(160, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 17);
            this.label8.TabIndex = 260;
            this.label8.Text = "De:";
            // 
            // tbxNCrVendedor
            // 
            this.tbxNCrVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNCrVendedor.Location = new System.Drawing.Point(368, 52);
            this.tbxNCrVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCrVendedor.Name = "tbxNCrVendedor";
            this.tbxNCrVendedor.ReadOnly = true;
            this.tbxNCrVendedor.Size = new System.Drawing.Size(303, 22);
            this.tbxNCrVendedor.TabIndex = 247;
            // 
            // btnImprimirCr
            // 
            this.btnImprimirCr.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimirCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirCr.Location = new System.Drawing.Point(813, 73);
            this.btnImprimirCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimirCr.Name = "btnImprimirCr";
            this.btnImprimirCr.Size = new System.Drawing.Size(40, 40);
            this.btnImprimirCr.TabIndex = 9;
            this.btnImprimirCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirCr.UseVisualStyleBackColor = true;
            this.btnImprimirCr.Click += new System.EventHandler(this.btnImprimirCr_Click);
            // 
            // btnSCrV
            // 
            this.btnSCrV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSCrV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSCrV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSCrV.Location = new System.Drawing.Point(330, 48);
            this.btnSCrV.Margin = new System.Windows.Forms.Padding(4);
            this.btnSCrV.Name = "btnSCrV";
            this.btnSCrV.Size = new System.Drawing.Size(30, 30);
            this.btnSCrV.TabIndex = 248;
            this.btnSCrV.UseVisualStyleBackColor = true;
            this.btnSCrV.Click += new System.EventHandler(this.btnSCrV_Click);
            // 
            // btnReporteCr
            // 
            this.btnReporteCr.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporteCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporteCr.Location = new System.Drawing.Point(717, 73);
            this.btnReporteCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporteCr.Name = "btnReporteCr";
            this.btnReporteCr.Size = new System.Drawing.Size(40, 40);
            this.btnReporteCr.TabIndex = 7;
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
            this.btnCrRVendedor.Location = new System.Drawing.Point(679, 48);
            this.btnCrRVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrRVendedor.Name = "btnCrRVendedor";
            this.btnCrRVendedor.Size = new System.Drawing.Size(30, 30);
            this.btnCrRVendedor.TabIndex = 249;
            this.btnCrRVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrRVendedor.UseVisualStyleBackColor = true;
            this.btnCrRVendedor.Click += new System.EventHandler(this.btnCrRVendedor_Click);
            // 
            // btnExcelCr
            // 
            this.btnExcelCr.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcelCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcelCr.Location = new System.Drawing.Point(765, 73);
            this.btnExcelCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcelCr.Name = "btnExcelCr";
            this.btnExcelCr.Size = new System.Drawing.Size(40, 40);
            this.btnExcelCr.TabIndex = 8;
            this.btnExcelCr.UseVisualStyleBackColor = true;
            this.btnExcelCr.Click += new System.EventHandler(this.btnExcelCr_Click);
            // 
            // tbxCrCliente
            // 
            this.tbxCrCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCrCliente.Location = new System.Drawing.Point(251, 82);
            this.tbxCrCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCrCliente.MaxLength = 9;
            this.tbxCrCliente.Name = "tbxCrCliente";
            this.tbxCrCliente.Size = new System.Drawing.Size(71, 22);
            this.tbxCrCliente.TabIndex = 6;
            this.tbxCrCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCrCliente_KeyDown);
            this.tbxCrCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCrCliente_KeyPress);
            // 
            // dtpFinC
            // 
            this.dtpFinC.CustomFormat = "dd/MMM/yyyy";
            this.dtpFinC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinC.Location = new System.Drawing.Point(396, 21);
            this.dtpFinC.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFinC.Name = "dtpFinC";
            this.dtpFinC.Size = new System.Drawing.Size(116, 23);
            this.dtpFinC.TabIndex = 256;
            this.dtpFinC.Value = new System.DateTime(2014, 3, 23, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(160, 85);
            this.label9.Margin = new System.Windows.Forms.Padding(4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 251;
            this.label9.Text = "Cliente:";
            // 
            // tbxNCrCliente
            // 
            this.tbxNCrCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNCrCliente.Location = new System.Drawing.Point(368, 82);
            this.tbxNCrCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCrCliente.Name = "tbxNCrCliente";
            this.tbxNCrCliente.ReadOnly = true;
            this.tbxNCrCliente.Size = new System.Drawing.Size(303, 22);
            this.tbxNCrCliente.TabIndex = 252;
            // 
            // btnCrRCliente
            // 
            this.btnCrRCliente.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCrRCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrRCliente.FlatAppearance.BorderSize = 0;
            this.btnCrRCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrRCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrRCliente.Location = new System.Drawing.Point(679, 78);
            this.btnCrRCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrRCliente.Name = "btnCrRCliente";
            this.btnCrRCliente.Size = new System.Drawing.Size(30, 30);
            this.btnCrRCliente.TabIndex = 254;
            this.btnCrRCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrRCliente.UseVisualStyleBackColor = true;
            this.btnCrRCliente.Click += new System.EventHandler(this.btnCrRCliente_Click);
            // 
            // btnSPCrC
            // 
            this.btnSPCrC.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSPCrC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSPCrC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSPCrC.Location = new System.Drawing.Point(330, 78);
            this.btnSPCrC.Margin = new System.Windows.Forms.Padding(4);
            this.btnSPCrC.Name = "btnSPCrC";
            this.btnSPCrC.Size = new System.Drawing.Size(30, 30);
            this.btnSPCrC.TabIndex = 253;
            this.btnSPCrC.UseVisualStyleBackColor = true;
            this.btnSPCrC.Click += new System.EventHandler(this.btnSPCrC_Click);
            // 
            // printDocHistorial
            // 
            this.printDocHistorial.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocHistorial_PrintPage);
            // 
            // printPreviewHistorial
            // 
            this.printPreviewHistorial.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewHistorial.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewHistorial.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewHistorial.Document = this.printDocHistorial;
            this.printPreviewHistorial.Enabled = true;
            this.printPreviewHistorial.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewHistorial.Icon")));
            this.printPreviewHistorial.Name = "printPreviewHistorial";
            this.printPreviewHistorial.Visible = false;
            this.printPreviewHistorial.Load += new System.EventHandler(this.printPreviewHistorial_Load);
            // 
            // printDocCreditos
            // 
            this.printDocCreditos.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocCreditos_PrintPage);
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
            this.printPreviewCreditos.Load += new System.EventHandler(this.printPreviewCreditos_Load);
            // 
            // reporteCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 573);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "reporteCobranza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de cobranza";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCrTabla)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistTabla)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCrTabla;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dtgHistTabla;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Button btnImprimirHistorial;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.Button btnReporteHistorial;
        private System.Windows.Forms.Button btnRVendedor;
        private System.Windows.Forms.Button btnExcelHistorial;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxNCliente;
        private System.Windows.Forms.Button btnRCliente;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dtpInicioC;
        private System.Windows.Forms.TextBox tbxCrVendedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxNCrVendedor;
        private System.Windows.Forms.Button btnImprimirCr;
        private System.Windows.Forms.Button btnSCrV;
        private System.Windows.Forms.Button btnReporteCr;
        private System.Windows.Forms.Button btnCrRVendedor;
        private System.Windows.Forms.Button btnExcelCr;
        private System.Windows.Forms.TextBox tbxCrCliente;
        private System.Windows.Forms.DateTimePicker dtpFinC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxNCrCliente;
        private System.Windows.Forms.Button btnCrRCliente;
        private System.Windows.Forms.Button btnSPCrC;
        private System.Windows.Forms.RadioButton rbtTodas;
        private System.Windows.Forms.RadioButton rbtInactivas;
        private System.Windows.Forms.RadioButton rbtActivas;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblHFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblHAdeudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblHAbono;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblHFiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn btlHPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblHDias;
        private System.Drawing.Printing.PrintDocument printDocHistorial;
        private System.Windows.Forms.PrintPreviewDialog printPreviewHistorial;
        private System.Drawing.Printing.PrintDocument printDocCreditos;
        private System.Windows.Forms.PrintPreviewDialog printPreviewCreditos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblAbono;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblDias;
    }
}