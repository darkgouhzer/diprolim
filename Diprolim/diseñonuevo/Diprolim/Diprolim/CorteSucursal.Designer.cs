namespace Diprolim
{
    partial class CorteSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorteSucursal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnImprimirCr = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Em = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "d/M/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(919, 17);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(102, 23);
            this.dtpFecha.TabIndex = 281;
            this.dtpFecha.Value = new System.DateTime(2014, 4, 4, 0, 0, 0, 0);
            this.dtpFecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFecha_KeyDown);
            this.dtpFecha.Leave += new System.EventHandler(this.dtpFecha_Leave);
            // 
            // btnImprimirCr
            // 
            this.btnImprimirCr.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimirCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirCr.Location = new System.Drawing.Point(977, 335);
            this.btnImprimirCr.Margin = new System.Windows.Forms.Padding(5);
            this.btnImprimirCr.Name = "btnImprimirCr";
            this.btnImprimirCr.Size = new System.Drawing.Size(44, 42);
            this.btnImprimirCr.TabIndex = 2;
            this.btnImprimirCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirCr.UseVisualStyleBackColor = true;
            this.btnImprimirCr.Click += new System.EventHandler(this.btnImprimirCr_Click);
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
            // Tabla
            // 
            this.Tabla.AllowUserToAddRows = false;
            this.Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.empl,
            this.E,
            this.Em,
            this.EMP,
            this.G,
            this.Ef,
            this.Comentarios,
            this.Column3,
            this.Column2});
            this.Tabla.Location = new System.Drawing.Point(13, 107);
            this.Tabla.Margin = new System.Windows.Forms.Padding(4);
            this.Tabla.Name = "Tabla";
            this.Tabla.Size = new System.Drawing.Size(1008, 219);
            this.Tabla.TabIndex = 290;
            this.Tabla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tabla_CellEndEdit);
            this.Tabla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tabla_CellValueChanged);
            this.Tabla.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Tabla_EditingControlShowing);
            this.Tabla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tabla_KeyPress);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Empleado";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 200;
            // 
            // empl
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.empl.DefaultCellStyle = dataGridViewCellStyle1;
            this.empl.HeaderText = "Ventas Totales";
            this.empl.Name = "empl";
            this.empl.ReadOnly = true;
            this.empl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // E
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.E.DefaultCellStyle = dataGridViewCellStyle2;
            this.E.HeaderText = "Iva";
            this.E.Name = "E";
            this.E.ReadOnly = true;
            this.E.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Em
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Em.DefaultCellStyle = dataGridViewCellStyle3;
            this.Em.HeaderText = "Recuperado";
            this.Em.Name = "Em";
            this.Em.ReadOnly = true;
            this.Em.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EMP
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.EMP.DefaultCellStyle = dataGridViewCellStyle4;
            this.EMP.HeaderText = "Fiado";
            this.EMP.Name = "EMP";
            this.EMP.ReadOnly = true;
            this.EMP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // G
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.G.DefaultCellStyle = dataGridViewCellStyle5;
            this.G.HeaderText = "Gastos";
            this.G.Name = "G";
            this.G.ReadOnly = true;
            this.G.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Ef
            // 
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.Ef.DefaultCellStyle = dataGridViewCellStyle6;
            this.Ef.HeaderText = "Efectivo a Entregar";
            this.Ef.Name = "Ef";
            this.Ef.ReadOnly = true;
            this.Ef.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Comentarios
            // 
            this.Comentarios.HeaderText = "Comentarios";
            this.Comentarios.Name = "Comentarios";
            this.Comentarios.ReadOnly = true;
            this.Comentarios.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Comentarios.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CantidadOculta";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 31);
            this.label1.TabIndex = 292;
            this.label1.Text = "CORTE DE CAJA DE SUCURSAL";
            // 
            // CorteSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1034, 384);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImprimirCr);
            this.Controls.Add(this.Tabla);
            this.Controls.Add(this.dtpFecha);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CorteSucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corte de sucursal";
            this.Load += new System.EventHandler(this.CorteSucursal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimirCr;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridView Tabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn empl;
        private System.Windows.Forms.DataGridViewTextBoxColumn E;
        private System.Windows.Forms.DataGridViewTextBoxColumn Em;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn G;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ef;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentarios;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label1;
    }
}