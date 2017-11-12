namespace Diprolim
{
    partial class Salidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Salidas));
            this.tblSalidas = new System.Windows.Forms.DataGridView();
            this.seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvCodArtS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Existencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblSalidasN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Totall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxLimiteA = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbxCSalidas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTotalLimitado = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnRegistrarS = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCambiarVendedor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxFolioDE = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblSalidas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblSalidas
            // 
            this.tblSalidas.AllowUserToAddRows = false;
            this.tblSalidas.AllowUserToDeleteRows = false;
            this.tblSalidas.AllowUserToResizeColumns = false;
            this.tblSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccionar,
            this.dgvCodArtS,
            this.Descripcion,
            this.Existencias,
            this.tblSalidasN,
            this.invVendedor,
            this.cantidadTotal,
            this.Totall,
            this.Precio,
            this.colDepartamento,
            this.valorMedida,
            this.unidadMedida});
            this.tblSalidas.Location = new System.Drawing.Point(13, 133);
            this.tblSalidas.Margin = new System.Windows.Forms.Padding(4);
            this.tblSalidas.Name = "tblSalidas";
            this.tblSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblSalidas.Size = new System.Drawing.Size(981, 352);
            this.tblSalidas.TabIndex = 91;
            this.tblSalidas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblSalidas_CellClick);
            this.tblSalidas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblSalidas_CellEndEdit);
            this.tblSalidas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.tblSalidas_CellValidating);
            this.tblSalidas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblSalidas_CellValueChanged);
            this.tblSalidas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tblSalidas_EditingControlShowing);
            this.tblSalidas.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.tblSalidas_SortCompare);
            this.tblSalidas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tblSalidas_KeyPress);
            // 
            // seleccionar
            // 
            this.seleccionar.HeaderText = "";
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Width = 30;
            // 
            // dgvCodArtS
            // 
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.dgvCodArtS.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCodArtS.HeaderText = "Código Articulo";
            this.dgvCodArtS.Name = "dgvCodArtS";
            this.dgvCodArtS.ReadOnly = true;
            this.dgvCodArtS.Width = 80;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 310;
            // 
            // Existencias
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Existencias.DefaultCellStyle = dataGridViewCellStyle2;
            this.Existencias.HeaderText = "Existencias";
            this.Existencias.Name = "Existencias";
            this.Existencias.ReadOnly = true;
            this.Existencias.Width = 95;
            // 
            // tblSalidasN
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.tblSalidasN.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblSalidasN.HeaderText = "Salidas";
            this.tblSalidasN.MaxInputLength = 9;
            this.tblSalidasN.Name = "tblSalidasN";
            this.tblSalidasN.Width = 90;
            // 
            // invVendedor
            // 
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.invVendedor.DefaultCellStyle = dataGridViewCellStyle4;
            this.invVendedor.HeaderText = "Inventario vendedor";
            this.invVendedor.MinimumWidth = 50;
            this.invVendedor.Name = "invVendedor";
            this.invVendedor.ReadOnly = true;
            this.invVendedor.Width = 95;
            // 
            // cantidadTotal
            // 
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.cantidadTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.cantidadTotal.HeaderText = "Cantidad total";
            this.cantidadTotal.Name = "cantidadTotal";
            this.cantidadTotal.ReadOnly = true;
            this.cantidadTotal.Width = 90;
            // 
            // Totall
            // 
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.Totall.DefaultCellStyle = dataGridViewCellStyle6;
            this.Totall.HeaderText = "Total $";
            this.Totall.Name = "Totall";
            this.Totall.ReadOnly = true;
            this.Totall.Width = 95;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Visible = false;
            this.Precio.Width = 95;
            // 
            // colDepartamento
            // 
            this.colDepartamento.HeaderText = "departamento";
            this.colDepartamento.Name = "colDepartamento";
            this.colDepartamento.ReadOnly = true;
            this.colDepartamento.Visible = false;
            // 
            // valorMedida
            // 
            this.valorMedida.HeaderText = "Valor de medida";
            this.valorMedida.Name = "valorMedida";
            this.valorMedida.ReadOnly = true;
            this.valorMedida.Visible = false;
            // 
            // unidadMedida
            // 
            this.unidadMedida.HeaderText = "Unidad de medida";
            this.unidadMedida.Name = "unidadMedida";
            this.unidadMedida.ReadOnly = true;
            this.unidadMedida.Visible = false;
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Location = new System.Drawing.Point(178, 33);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(5);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(262, 23);
            this.tbxNVendedor.TabIndex = 85;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 34);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 82;
            this.label9.Text = "Vendedor:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Location = new System.Drawing.Point(101, 33);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(5);
            this.tbxVendedor.MaxLength = 9;
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(67, 23);
            this.tbxVendedor.TabIndex = 1;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            this.tbxVendedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyUp);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(482, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 162;
            this.label4.Text = "Limite:   $";
            // 
            // tbxLimiteA
            // 
            this.tbxLimiteA.Location = new System.Drawing.Point(559, 34);
            this.tbxLimiteA.Margin = new System.Windows.Forms.Padding(4);
            this.tbxLimiteA.Name = "tbxLimiteA";
            this.tbxLimiteA.ReadOnly = true;
            this.tbxLimiteA.Size = new System.Drawing.Size(66, 23);
            this.tbxLimiteA.TabIndex = 161;
            this.tbxLimiteA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "d/M/yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(892, 14);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 23);
            this.dtpFecha.TabIndex = 171;
            this.dtpFecha.Value = new System.DateTime(2014, 4, 13, 0, 0, 0, 0);
            // 
            // cbxCSalidas
            // 
            this.cbxCSalidas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCSalidas.FormattingEnabled = true;
            this.cbxCSalidas.Items.AddRange(new object[] {
            "Todas",
            "Con salidas"});
            this.cbxCSalidas.Location = new System.Drawing.Point(734, 550);
            this.cbxCSalidas.Name = "cbxCSalidas";
            this.cbxCSalidas.Size = new System.Drawing.Size(121, 24);
            this.cbxCSalidas.TabIndex = 218;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(656, 553);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 217;
            this.label1.Text = "Imprimir:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(662, 523);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 216;
            this.label3.Text = "Total:  $";
            // 
            // tbxTotal
            // 
            this.tbxTotal.Location = new System.Drawing.Point(734, 520);
            this.tbxTotal.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.ReadOnly = true;
            this.tbxTotal.Size = new System.Drawing.Size(120, 23);
            this.tbxTotal.TabIndex = 215;
            this.tbxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(407, 523);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 220;
            this.label2.Text = "Total limitado:  $";
            // 
            // tbxTotalLimitado
            // 
            this.tbxTotalLimitado.Location = new System.Drawing.Point(534, 520);
            this.tbxTotalLimitado.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTotalLimitado.Name = "tbxTotalLimitado";
            this.tbxTotalLimitado.ReadOnly = true;
            this.tbxTotalLimitado.Size = new System.Drawing.Size(120, 23);
            this.tbxTotalLimitado.TabIndex = 219;
            this.tbxTotalLimitado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(862, 520);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(55, 55);
            this.btnImprimir.TabIndex = 214;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click_1);
            // 
            // btnRegistrarS
            // 
            this.btnRegistrarS.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnRegistrarS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistrarS.Location = new System.Drawing.Point(925, 520);
            this.btnRegistrarS.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrarS.Name = "btnRegistrarS";
            this.btnRegistrarS.Size = new System.Drawing.Size(55, 55);
            this.btnRegistrarS.TabIndex = 213;
            this.btnRegistrarS.UseVisualStyleBackColor = true;
            this.btnRegistrarS.Click += new System.EventHandler(this.btnRegistrarS_Click_1);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Diprolim.Properties.Resources.icono_producto2;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(663, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 170;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnCambiarVendedor
            // 
            this.btnCambiarVendedor.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCambiarVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarVendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarVendedor.Location = new System.Drawing.Point(449, 30);
            this.btnCambiarVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiarVendedor.Name = "btnCambiarVendedor";
            this.btnCambiarVendedor.Size = new System.Drawing.Size(29, 29);
            this.btnCambiarVendedor.TabIndex = 97;
            this.btnCambiarVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarVendedor.UseVisualStyleBackColor = true;
            this.btnCambiarVendedor.Click += new System.EventHandler(this.btnCambiarVendedor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(364, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 24);
            this.label7.TabIndex = 245;
            this.label7.Text = "INVENTARIO VENDEDOR";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxNVendedor);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbxVendedor);
            this.groupBox1.Controls.Add(this.btnCambiarVendedor);
            this.groupBox1.Controls.Add(this.tbxLimiteA);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 78);
            this.groupBox1.TabIndex = 246;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(398, 493);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 100);
            this.groupBox2.TabIndex = 247;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(915, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 253;
            this.label5.Text = "Folio:";
            // 
            // tbxFolioDE
            // 
            this.tbxFolioDE.Location = new System.Drawing.Point(892, 67);
            this.tbxFolioDE.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFolioDE.MaxLength = 100;
            this.tbxFolioDE.Name = "tbxFolioDE";
            this.tbxFolioDE.ReadOnly = true;
            this.tbxFolioDE.Size = new System.Drawing.Size(106, 23);
            this.tbxFolioDE.TabIndex = 252;
            this.tbxFolioDE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Salidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1007, 602);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxFolioDE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxTotalLimitado);
            this.Controls.Add(this.cbxCSalidas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnRegistrarS);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.tblSalidas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Salidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario vendedor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Salidas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tblSalidas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblSalidas;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Button btnCambiarVendedor;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxLimiteA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cbxCSalidas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTotal;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnRegistrarS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxTotalLimitado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCodArtS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Existencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblSalidasN;
        private System.Windows.Forms.DataGridViewTextBoxColumn invVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Totall;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadMedida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxFolioDE;
    }
}