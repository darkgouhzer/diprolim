namespace Diprolim
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invCP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invPrecioV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invCostoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invPrecioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxFiltro = new System.Windows.Forms.TextBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDepto = new System.Windows.Forms.ComboBox();
            this.cbxExistencia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabla
            // 
            this.Tabla.AllowUserToAddRows = false;
            this.Tabla.AllowUserToDeleteRows = false;
            this.Tabla.AllowUserToResizeColumns = false;
            this.Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripción,
            this.unidadMedida,
            this.invCantidad,
            this.invCP,
            this.invPrecioV,
            this.invCostoTotal,
            this.invPrecioTotal});
            this.Tabla.Location = new System.Drawing.Point(16, 85);
            this.Tabla.Margin = new System.Windows.Forms.Padding(4);
            this.Tabla.Name = "Tabla";
            this.Tabla.ReadOnly = true;
            this.Tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tabla.Size = new System.Drawing.Size(936, 461);
            this.Tabla.TabIndex = 0;
            this.Tabla.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.Tabla_SortCompare);
            // 
            // Codigo
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Código ";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 70;
            // 
            // Descripción
            // 
            this.Descripción.HeaderText = "Descripción ";
            this.Descripción.Name = "Descripción";
            this.Descripción.ReadOnly = true;
            this.Descripción.Width = 260;
            // 
            // unidadMedida
            // 
            this.unidadMedida.HeaderText = "Unidad de Medida";
            this.unidadMedida.Name = "unidadMedida";
            this.unidadMedida.ReadOnly = true;
            this.unidadMedida.Width = 90;
            // 
            // invCantidad
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.invCantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.invCantidad.HeaderText = "Cantidad";
            this.invCantidad.Name = "invCantidad";
            this.invCantidad.ReadOnly = true;
            this.invCantidad.Width = 80;
            // 
            // invCP
            // 
            dataGridViewCellStyle3.Format = "C2";
            this.invCP.DefaultCellStyle = dataGridViewCellStyle3;
            this.invCP.HeaderText = "Costo producción";
            this.invCP.Name = "invCP";
            this.invCP.ReadOnly = true;
            this.invCP.Width = 90;
            // 
            // invPrecioV
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.invPrecioV.DefaultCellStyle = dataGridViewCellStyle4;
            this.invPrecioV.HeaderText = "Precio venta";
            this.invPrecioV.Name = "invPrecioV";
            this.invPrecioV.ReadOnly = true;
            this.invPrecioV.Width = 80;
            // 
            // invCostoTotal
            // 
            dataGridViewCellStyle5.Format = "C2";
            this.invCostoTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.invCostoTotal.HeaderText = "Total Costo/p";
            this.invCostoTotal.Name = "invCostoTotal";
            this.invCostoTotal.ReadOnly = true;
            this.invCostoTotal.Width = 90;
            // 
            // invPrecioTotal
            // 
            dataGridViewCellStyle6.Format = "C2";
            this.invPrecioTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.invPrecioTotal.HeaderText = "Total Precio/v";
            this.invPrecioTotal.Name = "invPrecioTotal";
            this.invPrecioTotal.ReadOnly = true;
            this.invPrecioTotal.Width = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Descripción:";
            // 
            // tbxFiltro
            // 
            this.tbxFiltro.Location = new System.Drawing.Point(123, 6);
            this.tbxFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFiltro.Name = "tbxFiltro";
            this.tbxFiltro.Size = new System.Drawing.Size(387, 22);
            this.tbxFiltro.TabIndex = 13;
            this.tbxFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFiltro_KeyDown);
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
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 96;
            this.label1.Text = "Departamento:";
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
            this.cbxDepto.Location = new System.Drawing.Point(389, 42);
            this.cbxDepto.Name = "cbxDepto";
            this.cbxDepto.Size = new System.Drawing.Size(121, 24);
            this.cbxDepto.TabIndex = 97;
            // 
            // cbxExistencia
            // 
            this.cbxExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExistencia.FormattingEnabled = true;
            this.cbxExistencia.Items.AddRange(new object[] {
            "Todo",
            "Con existencias",
            "Sin existencias"});
            this.cbxExistencia.Location = new System.Drawing.Point(123, 42);
            this.cbxExistencia.Name = "cbxExistencia";
            this.cbxExistencia.Size = new System.Drawing.Size(121, 24);
            this.cbxExistencia.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 98;
            this.label2.Text = "Existencias:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(818, 31);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(45, 45);
            this.btnImprimir.TabIndex = 95;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Diprolim.Properties.Resources.search48;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(711, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 45);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(765, 31);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 45);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(965, 559);
            this.Controls.Add(this.cbxExistencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxDepto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxFiltro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Tabla);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Inventario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Tabla;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxFiltro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDepto;
        private System.Windows.Forms.ComboBox cbxExistencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn invCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn invCP;
        private System.Windows.Forms.DataGridViewTextBoxColumn invPrecioV;
        private System.Windows.Forms.DataGridViewTextBoxColumn invCostoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn invPrecioTotal;
    }
}