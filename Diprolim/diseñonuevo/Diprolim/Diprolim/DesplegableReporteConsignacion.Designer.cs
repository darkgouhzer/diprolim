namespace Diprolim
{
    partial class DesplegableReporteConsignacion
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
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnExcelCr = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsignacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 13);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(59, 17);
            this.lblCliente.TabIndex = 289;
            this.lblCliente.Text = "Cliente: ";
            // 
            // btnExcelCr
            // 
            this.btnExcelCr.BackgroundImage = global::Diprolim.Properties.Resources.ico_excel;
            this.btnExcelCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcelCr.Location = new System.Drawing.Point(1050, 13);
            this.btnExcelCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcelCr.Name = "btnExcelCr";
            this.btnExcelCr.Size = new System.Drawing.Size(40, 40);
            this.btnExcelCr.TabIndex = 290;
            this.btnExcelCr.UseVisualStyleBackColor = true;
            this.btnExcelCr.Click += new System.EventHandler(this.btnExcelCr_Click);
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
            this.dtgConsignacion.Location = new System.Drawing.Point(15, 62);
            this.dtgConsignacion.Margin = new System.Windows.Forms.Padding(5);
            this.dtgConsignacion.Name = "dtgConsignacion";
            this.dtgConsignacion.ReadOnly = true;
            this.dtgConsignacion.Size = new System.Drawing.Size(1077, 480);
            this.dtgConsignacion.TabIndex = 293;
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
            // DesplegableReporteConsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1103, 570);
            this.Controls.Add(this.dtgConsignacion);
            this.Controls.Add(this.btnExcelCr);
            this.Controls.Add(this.lblCliente);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DesplegableReporteConsignacion";
            this.Text = "DesplegableReporteConsignacion";
            this.Load += new System.EventHandler(this.DesplegableReporteConsignacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsignacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExcelCr;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DataGridView dtgConsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comisionn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
    }
}