namespace Diprolim
{
    partial class VentasProductosClientesDetalle
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
            this.tblReporteV = new System.Windows.Forms.DataGridView();
            this.tblCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblReporteV)).BeginInit();
            this.SuspendLayout();
            // 
            // tblReporteV
            // 
            this.tblReporteV.AllowUserToAddRows = false;
            this.tblReporteV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblReporteV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.tblReporteV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblReporteV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tblCodigo,
            this.fecha,
            this.tblProducto,
            this.tblPrecio,
            this.tblCantidad,
            this.tblTotal,
            this.tblComision});
            this.tblReporteV.Location = new System.Drawing.Point(13, 39);
            this.tblReporteV.Margin = new System.Windows.Forms.Padding(4);
            this.tblReporteV.Name = "tblReporteV";
            this.tblReporteV.ReadOnly = true;
            this.tblReporteV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblReporteV.Size = new System.Drawing.Size(911, 342);
            this.tblReporteV.TabIndex = 65;
            // 
            // tblCodigo
            // 
            this.tblCodigo.HeaderText = "Código articulo";
            this.tblCodigo.Name = "tblCodigo";
            this.tblCodigo.ReadOnly = true;
            this.tblCodigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblCodigo.Width = 70;
            // 
            // fecha
            // 
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.fecha.DefaultCellStyle = dataGridViewCellStyle7;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tblProducto
            // 
            this.tblProducto.HeaderText = "Producto";
            this.tblProducto.Name = "tblProducto";
            this.tblProducto.ReadOnly = true;
            this.tblProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblProducto.Width = 250;
            // 
            // tblPrecio
            // 
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.tblPrecio.DefaultCellStyle = dataGridViewCellStyle8;
            this.tblPrecio.HeaderText = "Precio venta";
            this.tblPrecio.Name = "tblPrecio";
            this.tblPrecio.ReadOnly = true;
            this.tblPrecio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tblCantidad
            // 
            this.tblCantidad.HeaderText = "Unidades vendidas";
            this.tblCantidad.Name = "tblCantidad";
            this.tblCantidad.ReadOnly = true;
            this.tblCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tblTotal
            // 
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.tblTotal.DefaultCellStyle = dataGridViewCellStyle9;
            this.tblTotal.HeaderText = "Total";
            this.tblTotal.Name = "tblTotal";
            this.tblTotal.ReadOnly = true;
            this.tblTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblTotal.Width = 110;
            // 
            // tblComision
            // 
            dataGridViewCellStyle10.Format = "C2";
            this.tblComision.DefaultCellStyle = dataGridViewCellStyle10;
            this.tblComision.HeaderText = "Comisión";
            this.tblComision.Name = "tblComision";
            this.tblComision.ReadOnly = true;
            this.tblComision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblComision.Width = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 17);
            this.label1.TabIndex = 66;
            this.label1.Text = "DETALLE DE LA VENTA";
            // 
            // VentasProductosClientesDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(941, 389);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tblReporteV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentasProductosClientesDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle";
            this.Load += new System.EventHandler(this.VentasProductosClientesDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblReporteV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblReporteV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblComision;
    }
}