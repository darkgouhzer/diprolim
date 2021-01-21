namespace Diprolim
{
    partial class DescuentosPersonalizados
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.tbxNoCompraInicial = new System.Windows.Forms.TextBox();
            this.lblNoComprainicial = new System.Windows.Forms.Label();
            this.tbxMinCompra = new System.Windows.Forms.TextBox();
            this.lblMinCompra = new System.Windows.Forms.Label();
            this.lblPresentaciones = new System.Windows.Forms.Label();
            this.tbxDescuento = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.chbxActiva = new System.Windows.Forms.CheckBox();
            this.lblActiva = new System.Windows.Forms.Label();
            this.dtgPresentaciones = new System.Windows.Forms.DataGridView();
            this.colIDPresentacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPresentaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(16, 31);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(120, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre campaña";
            // 
            // tbxNombre
            // 
            this.tbxNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNombre.Location = new System.Drawing.Point(147, 28);
            this.tbxNombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNombre.MaxLength = 50;
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(214, 23);
            this.tbxNombre.TabIndex = 1;
            // 
            // tbxNoCompraInicial
            // 
            this.tbxNoCompraInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNoCompraInicial.Location = new System.Drawing.Point(147, 63);
            this.tbxNoCompraInicial.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNoCompraInicial.MaxLength = 8;
            this.tbxNoCompraInicial.Name = "tbxNoCompraInicial";
            this.tbxNoCompraInicial.Size = new System.Drawing.Size(111, 23);
            this.tbxNoCompraInicial.TabIndex = 3;
            this.tbxNoCompraInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNoCompraInicial_KeyPress);
            // 
            // lblNoComprainicial
            // 
            this.lblNoComprainicial.AutoSize = true;
            this.lblNoComprainicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoComprainicial.Location = new System.Drawing.Point(16, 66);
            this.lblNoComprainicial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoComprainicial.Name = "lblNoComprainicial";
            this.lblNoComprainicial.Size = new System.Drawing.Size(120, 17);
            this.lblNoComprainicial.TabIndex = 2;
            this.lblNoComprainicial.Text = "No. compra inicial";
            // 
            // tbxMinCompra
            // 
            this.tbxMinCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMinCompra.Location = new System.Drawing.Point(147, 99);
            this.tbxMinCompra.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMinCompra.MaxLength = 8;
            this.tbxMinCompra.Name = "tbxMinCompra";
            this.tbxMinCompra.Size = new System.Drawing.Size(111, 23);
            this.tbxMinCompra.TabIndex = 5;
            this.tbxMinCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxMinCompra_KeyPress);
            // 
            // lblMinCompra
            // 
            this.lblMinCompra.AutoSize = true;
            this.lblMinCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinCompra.Location = new System.Drawing.Point(16, 102);
            this.lblMinCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinCompra.Name = "lblMinCompra";
            this.lblMinCompra.Size = new System.Drawing.Size(112, 17);
            this.lblMinCompra.TabIndex = 4;
            this.lblMinCompra.Text = "Cantidad minima";
            // 
            // lblPresentaciones
            // 
            this.lblPresentaciones.AutoSize = true;
            this.lblPresentaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresentaciones.Location = new System.Drawing.Point(16, 144);
            this.lblPresentaciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPresentaciones.Name = "lblPresentaciones";
            this.lblPresentaciones.Size = new System.Drawing.Size(106, 17);
            this.lblPresentaciones.TabIndex = 7;
            this.lblPresentaciones.Text = "Presentaciones";
            // 
            // tbxDescuento
            // 
            this.tbxDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDescuento.Location = new System.Drawing.Point(147, 416);
            this.tbxDescuento.Margin = new System.Windows.Forms.Padding(4);
            this.tbxDescuento.MaxLength = 8;
            this.tbxDescuento.Name = "tbxDescuento";
            this.tbxDescuento.Size = new System.Drawing.Size(111, 23);
            this.tbxDescuento.TabIndex = 10;
            this.tbxDescuento.TextChanged += new System.EventHandler(this.tbxDescuento_TextChanged);
            this.tbxDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxDescuento_KeyPress);
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(16, 419);
            this.lblDescuento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(92, 17);
            this.lblDescuento.TabIndex = 9;
            this.lblDescuento.Text = "Descuento %";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Location = new System.Drawing.Point(228, 470);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(133, 49);
            this.btnEliminar.TabIndex = 118;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(84, 470);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 49);
            this.btnGuardar.TabIndex = 117;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // chbxActiva
            // 
            this.chbxActiva.AutoSize = true;
            this.chbxActiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxActiva.Location = new System.Drawing.Point(147, 450);
            this.chbxActiva.Margin = new System.Windows.Forms.Padding(4);
            this.chbxActiva.Name = "chbxActiva";
            this.chbxActiva.Size = new System.Drawing.Size(15, 14);
            this.chbxActiva.TabIndex = 120;
            this.chbxActiva.UseVisualStyleBackColor = true;
            // 
            // lblActiva
            // 
            this.lblActiva.AutoSize = true;
            this.lblActiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiva.Location = new System.Drawing.Point(16, 447);
            this.lblActiva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActiva.Name = "lblActiva";
            this.lblActiva.Size = new System.Drawing.Size(109, 17);
            this.lblActiva.TabIndex = 119;
            this.lblActiva.Text = "Campaña activa";
            // 
            // dtgPresentaciones
            // 
            this.dtgPresentaciones.AllowUserToAddRows = false;
            this.dtgPresentaciones.AllowUserToDeleteRows = false;
            this.dtgPresentaciones.AllowUserToResizeColumns = false;
            this.dtgPresentaciones.AllowUserToResizeRows = false;
            this.dtgPresentaciones.BackgroundColor = System.Drawing.Color.White;
            this.dtgPresentaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgPresentaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgPresentaciones.ColumnHeadersVisible = false;
            this.dtgPresentaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIDPresentacion,
            this.colDescripcion,
            this.colValorMedida,
            this.colNombreMedida,
            this.colSimbolo});
            this.dtgPresentaciones.Location = new System.Drawing.Point(147, 144);
            this.dtgPresentaciones.MultiSelect = false;
            this.dtgPresentaciones.Name = "dtgPresentaciones";
            this.dtgPresentaciones.RowHeadersVisible = false;
            this.dtgPresentaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgPresentaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPresentaciones.Size = new System.Drawing.Size(214, 265);
            this.dtgPresentaciones.TabIndex = 121;
            // 
            // colIDPresentacion
            // 
            this.colIDPresentacion.HeaderText = "";
            this.colIDPresentacion.Name = "colIDPresentacion";
            this.colIDPresentacion.Width = 50;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Presentacion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // colValorMedida
            // 
            this.colValorMedida.HeaderText = "ValorMedida";
            this.colValorMedida.Name = "colValorMedida";
            this.colValorMedida.Visible = false;
            // 
            // colNombreMedida
            // 
            this.colNombreMedida.HeaderText = "NombreMedida";
            this.colNombreMedida.Name = "colNombreMedida";
            this.colNombreMedida.Visible = false;
            // 
            // colSimbolo
            // 
            this.colSimbolo.HeaderText = "Simbolo";
            this.colSimbolo.Name = "colSimbolo";
            this.colSimbolo.Visible = false;
            // 
            // DescuentosPersonalizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 533);
            this.Controls.Add(this.dtgPresentaciones);
            this.Controls.Add(this.chbxActiva);
            this.Controls.Add(this.lblActiva);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tbxDescuento);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.lblPresentaciones);
            this.Controls.Add(this.tbxMinCompra);
            this.Controls.Add(this.lblMinCompra);
            this.Controls.Add(this.tbxNoCompraInicial);
            this.Controls.Add(this.lblNoComprainicial);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.lblNombre);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DescuentosPersonalizados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descuentos distribuidor";
            this.Load += new System.EventHandler(this.DescuentosPersonalizados_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DescuentosPersonalizados_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPresentaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.TextBox tbxNoCompraInicial;
        private System.Windows.Forms.Label lblNoComprainicial;
        private System.Windows.Forms.TextBox tbxMinCompra;
        private System.Windows.Forms.Label lblMinCompra;
        private System.Windows.Forms.Label lblPresentaciones;
        private System.Windows.Forms.TextBox tbxDescuento;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.CheckBox chbxActiva;
        private System.Windows.Forms.Label lblActiva;
        private System.Windows.Forms.DataGridView dtgPresentaciones;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIDPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimbolo;
    }
}