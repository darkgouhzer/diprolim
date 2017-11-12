namespace Diprolim
{
    partial class PedidosEspeciales
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
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDisponible = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxProducto = new System.Windows.Forms.TextBox();
            this.tblPE = new System.Windows.Forms.DataGridView();
            this.C = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarS = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSV = new System.Windows.Forms.Button();
            this.btnAC = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.tbxTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblPE)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Location = new System.Drawing.Point(219, 48);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(5);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(370, 23);
            this.tbxNVendedor.TabIndex = 176;
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Location = new System.Drawing.Point(94, 48);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(5);
            this.tbxVendedor.MaxLength = 9;
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(76, 23);
            this.tbxVendedor.TabIndex = 174;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            this.tbxVendedor.Leave += new System.EventHandler(this.tbxVendedor_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 48);
            this.label9.Margin = new System.Windows.Forms.Padding(5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 175;
            this.label9.Text = "Vendedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(257, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 173;
            this.label1.Text = "Disponible:";
            // 
            // tbxDisponible
            // 
            this.tbxDisponible.Location = new System.Drawing.Point(354, 116);
            this.tbxDisponible.Margin = new System.Windows.Forms.Padding(5);
            this.tbxDisponible.Name = "tbxDisponible";
            this.tbxDisponible.ReadOnly = true;
            this.tbxDisponible.Size = new System.Drawing.Size(116, 23);
            this.tbxDisponible.TabIndex = 172;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 170;
            this.label2.Text = "Cantidad:";
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.Location = new System.Drawing.Point(94, 116);
            this.tbxCantidad.Margin = new System.Windows.Forms.Padding(5);
            this.tbxCantidad.MaxLength = 9;
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.Size = new System.Drawing.Size(76, 23);
            this.tbxCantidad.TabIndex = 169;
            this.tbxCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCantidad_KeyDown);
            this.tbxCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidad_KeyPress);
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(220, 81);
            this.tbxNombre.Margin = new System.Windows.Forms.Padding(5);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.ReadOnly = true;
            this.tbxNombre.Size = new System.Drawing.Size(369, 23);
            this.tbxNombre.TabIndex = 167;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 166;
            this.label4.Text = "Producto:";
            // 
            // tbxProducto
            // 
            this.tbxProducto.Location = new System.Drawing.Point(94, 82);
            this.tbxProducto.Margin = new System.Windows.Forms.Padding(5);
            this.tbxProducto.MaxLength = 9;
            this.tbxProducto.Name = "tbxProducto";
            this.tbxProducto.Size = new System.Drawing.Size(76, 23);
            this.tbxProducto.TabIndex = 165;
            this.tbxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxProducto_KeyDown);
            this.tbxProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxProducto_KeyPress);
            this.tbxProducto.Leave += new System.EventHandler(this.tbxProducto_Leave);
            // 
            // tblPE
            // 
            this.tblPE.AllowUserToAddRows = false;
            this.tblPE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C,
            this.Co,
            this.Nombre,
            this.Cc,
            this.Dine,
            this.D});
            this.tblPE.Location = new System.Drawing.Point(12, 150);
            this.tblPE.Name = "tblPE";
            this.tblPE.Size = new System.Drawing.Size(662, 201);
            this.tblPE.TabIndex = 178;
            // 
            // C
            // 
            this.C.HeaderText = "";
            this.C.Name = "C";
            this.C.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.C.Width = 20;
            // 
            // Co
            // 
            this.Co.HeaderText = "Código";
            this.Co.Name = "Co";
            this.Co.ReadOnly = true;
            this.Co.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 300;
            // 
            // Cc
            // 
            this.Cc.HeaderText = "Cantidad";
            this.Cc.Name = "Cc";
            // 
            // Dine
            // 
            this.Dine.HeaderText = "$/Dinero";
            this.Dine.Name = "Dine";
            this.Dine.ReadOnly = true;
            // 
            // D
            // 
            this.D.HeaderText = "Disponible";
            this.D.Name = "D";
            this.D.Visible = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "d/M/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(576, 14);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 23);
            this.dtpFecha.TabIndex = 213;
            this.dtpFecha.Value = new System.DateTime(2014, 4, 13, 0, 0, 0, 0);
            // 
            // btnRegistrarS
            // 
            this.btnRegistrarS.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnRegistrarS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistrarS.Location = new System.Drawing.Point(638, 358);
            this.btnRegistrarS.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrarS.Name = "btnRegistrarS";
            this.btnRegistrarS.Size = new System.Drawing.Size(40, 40);
            this.btnRegistrarS.TabIndex = 212;
            this.btnRegistrarS.UseVisualStyleBackColor = true;
            this.btnRegistrarS.Click += new System.EventHandler(this.btnRegistrarS_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = global::Diprolim.Properties.Resources.delete;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(218, 112);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(30, 30);
            this.btnEliminar.TabIndex = 210;
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(179, 44);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 177;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // btnAC
            // 
            this.btnAC.BackgroundImage = global::Diprolim.Properties.Resources.plus;
            this.btnAC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAC.Location = new System.Drawing.Point(179, 112);
            this.btnAC.Margin = new System.Windows.Forms.Padding(5);
            this.btnAC.Name = "btnAC";
            this.btnAC.Size = new System.Drawing.Size(30, 30);
            this.btnAC.TabIndex = 171;
            this.btnAC.UseVisualStyleBackColor = true;
            this.btnAC.Click += new System.EventHandler(this.btnAC_Click);
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Location = new System.Drawing.Point(179, 77);
            this.btnSP.Margin = new System.Windows.Forms.Padding(5);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 168;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // tbxTotal
            // 
            this.tbxTotal.Location = new System.Drawing.Point(553, 367);
            this.tbxTotal.Margin = new System.Windows.Forms.Padding(5);
            this.tbxTotal.MaxLength = 9;
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.ReadOnly = true;
            this.tbxTotal.Size = new System.Drawing.Size(76, 23);
            this.tbxTotal.TabIndex = 214;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(483, 370);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 215;
            this.label3.Text = "Total $:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(222, 13);
            this.label15.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(230, 24);
            this.label15.TabIndex = 246;
            this.label15.Text = "PEDIDOS ESPECIALES";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PedidosEspeciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(691, 404);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnRegistrarS);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.tblPE);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDisponible);
            this.Controls.Add(this.btnAC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCantidad);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxProducto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PedidosEspeciales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedidos especiales";
            ((System.ComponentModel.ISupportInitialize)(this.tblPE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDisponible;
        private System.Windows.Forms.Button btnAC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxProducto;
        private System.Windows.Forms.DataGridView tblPE;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRegistrarS;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn C;
        private System.Windows.Forms.DataGridViewTextBoxColumn Co;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dine;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.TextBox tbxTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
    }
}