namespace Diprolim
{
    partial class CobranzaCredito
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CobranzaCredito));
            this.dtgCredito = new System.Windows.Forms.DataGridView();
            this.tblCrFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCrCodArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCrDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCrCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCrPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCrSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCrAbono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCrPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCrIdventa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCrImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxNCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFolio = new System.Windows.Forms.TextBox();
            this.rbtTodos = new System.Windows.Forms.RadioButton();
            this.rbtPendientes = new System.Windows.Forms.RadioButton();
            this.rbtPagados = new System.Windows.Forms.RadioButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnFolio = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnR = new System.Windows.Forms.Button();
            this.btnSC = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSV = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCredito)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgCredito
            // 
            this.dtgCredito.AllowUserToAddRows = false;
            this.dtgCredito.AllowUserToDeleteRows = false;
            this.dtgCredito.AllowUserToResizeColumns = false;
            this.dtgCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCredito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tblCrFolio,
            this.tblCrCodArt,
            this.tblCrDesc,
            this.tblCrCantidad,
            this.tblCrPrecio,
            this.tblCrSaldo,
            this.tblCrAbono,
            this.tblCrPendiente,
            this.tblCrIdventa,
            this.tblCrImporte});
            this.dtgCredito.Location = new System.Drawing.Point(15, 162);
            this.dtgCredito.Margin = new System.Windows.Forms.Padding(4);
            this.dtgCredito.Name = "dtgCredito";
            this.dtgCredito.Size = new System.Drawing.Size(944, 304);
            this.dtgCredito.TabIndex = 223;
            this.dtgCredito.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblCredito_CellEndEdit);
            this.dtgCredito.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.tblCredito_CellValidating);
            this.dtgCredito.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblCredito_CellValueChanged);
            this.dtgCredito.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tblCredito_EditingControlShowing);
            this.dtgCredito.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.tblCredito_SortCompare);
            this.dtgCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tblCredito_KeyPress);
            // 
            // tblCrFolio
            // 
            this.tblCrFolio.HeaderText = "Folio";
            this.tblCrFolio.Name = "tblCrFolio";
            this.tblCrFolio.Width = 80;
            // 
            // tblCrCodArt
            // 
            this.tblCrCodArt.HeaderText = "Código Artículo";
            this.tblCrCodArt.Name = "tblCrCodArt";
            this.tblCrCodArt.ReadOnly = true;
            this.tblCrCodArt.Width = 70;
            // 
            // tblCrDesc
            // 
            this.tblCrDesc.HeaderText = "Descripción";
            this.tblCrDesc.Name = "tblCrDesc";
            this.tblCrDesc.ReadOnly = true;
            this.tblCrDesc.Width = 280;
            // 
            // tblCrCantidad
            // 
            this.tblCrCantidad.HeaderText = "Cantidad";
            this.tblCrCantidad.Name = "tblCrCantidad";
            this.tblCrCantidad.ReadOnly = true;
            this.tblCrCantidad.Width = 80;
            // 
            // tblCrPrecio
            // 
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.tblCrPrecio.DefaultCellStyle = dataGridViewCellStyle6;
            this.tblCrPrecio.HeaderText = "Precio";
            this.tblCrPrecio.MaxInputLength = 9;
            this.tblCrPrecio.Name = "tblCrPrecio";
            this.tblCrPrecio.ReadOnly = true;
            this.tblCrPrecio.Width = 80;
            // 
            // tblCrSaldo
            // 
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.tblCrSaldo.DefaultCellStyle = dataGridViewCellStyle7;
            this.tblCrSaldo.HeaderText = "Saldo";
            this.tblCrSaldo.MaxInputLength = 9;
            this.tblCrSaldo.Name = "tblCrSaldo";
            this.tblCrSaldo.ReadOnly = true;
            this.tblCrSaldo.Width = 80;
            // 
            // tblCrAbono
            // 
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.tblCrAbono.DefaultCellStyle = dataGridViewCellStyle8;
            this.tblCrAbono.HeaderText = "Abono";
            this.tblCrAbono.MaxInputLength = 8;
            this.tblCrAbono.Name = "tblCrAbono";
            this.tblCrAbono.Width = 90;
            // 
            // tblCrPendiente
            // 
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.tblCrPendiente.DefaultCellStyle = dataGridViewCellStyle9;
            this.tblCrPendiente.HeaderText = "Pendiente";
            this.tblCrPendiente.Name = "tblCrPendiente";
            this.tblCrPendiente.ReadOnly = true;
            this.tblCrPendiente.Width = 90;
            // 
            // tblCrIdventa
            // 
            this.tblCrIdventa.HeaderText = "idventa";
            this.tblCrIdventa.Name = "tblCrIdventa";
            this.tblCrIdventa.Visible = false;
            // 
            // tblCrImporte
            // 
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = null;
            this.tblCrImporte.DefaultCellStyle = dataGridViewCellStyle10;
            this.tblCrImporte.HeaderText = "Importe";
            this.tblCrImporte.Name = "tblCrImporte";
            this.tblCrImporte.Visible = false;
            // 
            // tbxNCliente
            // 
            this.tbxNCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNCliente.Location = new System.Drawing.Point(208, 88);
            this.tbxNCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCliente.Name = "tbxNCliente";
            this.tbxNCliente.ReadOnly = true;
            this.tbxNCliente.Size = new System.Drawing.Size(337, 22);
            this.tbxNCliente.TabIndex = 231;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 230;
            this.label1.Text = "Cliente:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCliente.Location = new System.Drawing.Point(107, 88);
            this.tbxCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCliente.MaxLength = 9;
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(94, 22);
            this.tbxCliente.TabIndex = 2;
            this.tbxCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCliente_KeyDown);
            this.tbxCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCliente_KeyPress);
            this.tbxCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxCliente_KeyUp);
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNVendedor.Location = new System.Drawing.Point(208, 56);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(337, 22);
            this.tbxNVendedor.TabIndex = 227;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 226;
            this.label4.Text = "Vendedor:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxVendedor.Location = new System.Drawing.Point(107, 56);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.MaxLength = 9;
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(93, 22);
            this.tbxVendedor.TabIndex = 1;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            this.tbxVendedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(591, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 235;
            this.label2.Text = "Folio";
            // 
            // tbxFolio
            // 
            this.tbxFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFolio.Location = new System.Drawing.Point(642, 56);
            this.tbxFolio.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFolio.MaxLength = 9;
            this.tbxFolio.Name = "tbxFolio";
            this.tbxFolio.Size = new System.Drawing.Size(93, 22);
            this.tbxFolio.TabIndex = 3;
            this.tbxFolio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFolio_KeyDown);
            this.tbxFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxFolio_KeyPress);
            // 
            // rbtTodos
            // 
            this.rbtTodos.AutoSize = true;
            this.rbtTodos.Location = new System.Drawing.Point(697, 89);
            this.rbtTodos.Name = "rbtTodos";
            this.rbtTodos.Size = new System.Drawing.Size(66, 21);
            this.rbtTodos.TabIndex = 5;
            this.rbtTodos.Text = "Todos";
            this.rbtTodos.UseVisualStyleBackColor = true;
            this.rbtTodos.CheckedChanged += new System.EventHandler(this.rbtTodos_CheckedChanged);
            // 
            // rbtPendientes
            // 
            this.rbtPendientes.AutoSize = true;
            this.rbtPendientes.Checked = true;
            this.rbtPendientes.Location = new System.Drawing.Point(594, 89);
            this.rbtPendientes.Name = "rbtPendientes";
            this.rbtPendientes.Size = new System.Drawing.Size(97, 21);
            this.rbtPendientes.TabIndex = 4;
            this.rbtPendientes.TabStop = true;
            this.rbtPendientes.Text = "Pendientes";
            this.rbtPendientes.UseVisualStyleBackColor = true;
            this.rbtPendientes.CheckedChanged += new System.EventHandler(this.rbtPendientes_CheckedChanged);
            // 
            // rbtPagados
            // 
            this.rbtPagados.AutoSize = true;
            this.rbtPagados.Location = new System.Drawing.Point(769, 89);
            this.rbtPagados.Name = "rbtPagados";
            this.rbtPagados.Size = new System.Drawing.Size(82, 21);
            this.rbtPagados.TabIndex = 6;
            this.rbtPagados.Text = "Pagados";
            this.rbtPagados.UseVisualStyleBackColor = true;
            this.rbtPagados.CheckedChanged += new System.EventHandler(this.rbtPagados_CheckedChanged);
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
            // btnFolio
            // 
            this.btnFolio.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnFolio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolio.Location = new System.Drawing.Point(743, 52);
            this.btnFolio.Margin = new System.Windows.Forms.Padding(4);
            this.btnFolio.Name = "btnFolio";
            this.btnFolio.Size = new System.Drawing.Size(30, 30);
            this.btnFolio.TabIndex = 238;
            this.btnFolio.UseVisualStyleBackColor = true;
            this.btnFolio.Click += new System.EventHandler(this.btnFolio_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(56, 23);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(45, 45);
            this.btnImprimir.TabIndex = 237;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnRegistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(109, 23);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(45, 45);
            this.btnRegistrar.TabIndex = 236;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnR
            // 
            this.btnR.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnR.FlatAppearance.BorderSize = 0;
            this.btnR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnR.Location = new System.Drawing.Point(553, 84);
            this.btnR.Margin = new System.Windows.Forms.Padding(4);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(30, 30);
            this.btnR.TabIndex = 233;
            this.btnR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnR.UseVisualStyleBackColor = true;
            this.btnR.Click += new System.EventHandler(this.btnR_Click);
            // 
            // btnSC
            // 
            this.btnSC.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSC.Location = new System.Drawing.Point(208, 84);
            this.btnSC.Margin = new System.Windows.Forms.Padding(4);
            this.btnSC.Name = "btnSC";
            this.btnSC.Size = new System.Drawing.Size(30, 30);
            this.btnSC.TabIndex = 232;
            this.btnSC.UseVisualStyleBackColor = true;
            this.btnSC.Visible = false;
            this.btnSC.Click += new System.EventHandler(this.btnB_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(553, 52);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(30, 30);
            this.btnNuevo.TabIndex = 229;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSV.Location = new System.Drawing.Point(208, 52);
            this.btnSV.Margin = new System.Windows.Forms.Padding(4);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 228;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Visible = false;
            this.btnSV.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(383, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 24);
            this.label5.TabIndex = 239;
            this.label5.Text = "COBRANZA CRÉDITO";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 100);
            this.groupBox1.TabIndex = 240;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.btnRegistrar);
            this.groupBox2.Location = new System.Drawing.Point(798, 473);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 75);
            this.groupBox2.TabIndex = 241;
            this.groupBox2.TabStop = false;
            // 
            // CobranzaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(972, 554);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbtPagados);
            this.Controls.Add(this.rbtPendientes);
            this.Controls.Add(this.rbtTodos);
            this.Controls.Add(this.btnFolio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxFolio);
            this.Controls.Add(this.btnR);
            this.Controls.Add(this.tbxNCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxCliente);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.dtgCredito);
            this.Controls.Add(this.btnSC);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CobranzaCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobranza Crédito";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCredito)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCredito;
        private System.Windows.Forms.Button btnR;
        private System.Windows.Forms.Button btnSC;
        private System.Windows.Forms.TextBox tbxNCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxFolio;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnFolio;
        private System.Windows.Forms.RadioButton rbtTodos;
        private System.Windows.Forms.RadioButton rbtPendientes;
        private System.Windows.Forms.RadioButton rbtPagados;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCrFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCrCodArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCrDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCrCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCrPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCrSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCrAbono;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCrPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCrIdventa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCrImporte;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}