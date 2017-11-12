namespace Diprolim
{
    partial class transferenciasInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(transferenciasInventario));
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.tbxNVendedorD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxVendedorD = new System.Windows.Forms.TextBox();
            this.tbxNProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxExistencias = new System.Windows.Forms.TextBox();
            this.btnSP = new System.Windows.Forms.Button();
            this.btnSPD = new System.Windows.Forms.Button();
            this.btnSV = new System.Windows.Forms.Button();
            this.btnTransferencias = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCambiarVendedor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Location = new System.Drawing.Point(294, 16);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(248, 23);
            this.tbxNVendedor.TabIndex = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(11, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 99;
            this.label3.Text = "Vendedor origen:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Location = new System.Drawing.Point(153, 16);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(93, 23);
            this.tbxVendedor.TabIndex = 98;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            // 
            // tbxNVendedorD
            // 
            this.tbxNVendedorD.Location = new System.Drawing.Point(294, 109);
            this.tbxNVendedorD.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedorD.Name = "tbxNVendedorD";
            this.tbxNVendedorD.ReadOnly = true;
            this.tbxNVendedorD.Size = new System.Drawing.Size(248, 23);
            this.tbxNVendedorD.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 103;
            this.label1.Text = "Vendedor destino:";
            // 
            // tbxVendedorD
            // 
            this.tbxVendedorD.Location = new System.Drawing.Point(153, 109);
            this.tbxVendedorD.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedorD.Name = "tbxVendedorD";
            this.tbxVendedorD.Size = new System.Drawing.Size(93, 23);
            this.tbxVendedorD.TabIndex = 102;
            this.tbxVendedorD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedorD_KeyDown);
            this.tbxVendedorD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedorD_KeyPress);
            // 
            // tbxNProducto
            // 
            this.tbxNProducto.Location = new System.Drawing.Point(294, 47);
            this.tbxNProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNProducto.Name = "tbxNProducto";
            this.tbxNProducto.ReadOnly = true;
            this.tbxNProducto.Size = new System.Drawing.Size(248, 23);
            this.tbxNProducto.TabIndex = 108;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(67, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 107;
            this.label2.Text = "Producto:";
            // 
            // tbxProducto
            // 
            this.tbxProducto.Location = new System.Drawing.Point(153, 47);
            this.tbxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProducto.Name = "tbxProducto";
            this.tbxProducto.Size = new System.Drawing.Size(93, 23);
            this.tbxProducto.TabIndex = 106;
            this.tbxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxProducto_KeyDown);
            this.tbxProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxProducto_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(67, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 111;
            this.label4.Text = "Cantidad:";
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.Location = new System.Drawing.Point(153, 78);
            this.tbxCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.Size = new System.Drawing.Size(93, 23);
            this.tbxCantidad.TabIndex = 110;
            this.tbxCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCantidad_KeyDown);
            this.tbxCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidad_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(254, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 113;
            this.label5.Text = "Existencias:";
            // 
            // tbxExistencias
            // 
            this.tbxExistencias.Location = new System.Drawing.Point(356, 78);
            this.tbxExistencias.Margin = new System.Windows.Forms.Padding(4);
            this.tbxExistencias.Name = "tbxExistencias";
            this.tbxExistencias.ReadOnly = true;
            this.tbxExistencias.Size = new System.Drawing.Size(93, 23);
            this.tbxExistencias.TabIndex = 112;
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Location = new System.Drawing.Point(255, 43);
            this.btnSP.Margin = new System.Windows.Forms.Padding(5);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 109;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // btnSPD
            // 
            this.btnSPD.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSPD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSPD.Location = new System.Drawing.Point(255, 105);
            this.btnSPD.Margin = new System.Windows.Forms.Padding(5);
            this.btnSPD.Name = "btnSPD";
            this.btnSPD.Size = new System.Drawing.Size(30, 30);
            this.btnSPD.TabIndex = 105;
            this.btnSPD.UseVisualStyleBackColor = true;
            this.btnSPD.Click += new System.EventHandler(this.btnSPD_Click);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(255, 12);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 101;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // btnTransferencias
            // 
            this.btnTransferencias.BackgroundImage = global::Diprolim.Properties.Resources.Transfer;
            this.btnTransferencias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTransferencias.Location = new System.Drawing.Point(255, 144);
            this.btnTransferencias.Margin = new System.Windows.Forms.Padding(4);
            this.btnTransferencias.Name = "btnTransferencias";
            this.btnTransferencias.Size = new System.Drawing.Size(40, 40);
            this.btnTransferencias.TabIndex = 158;
            this.btnTransferencias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransferencias.UseVisualStyleBackColor = true;
            this.btnTransferencias.Click += new System.EventHandler(this.btnTransferencias_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::Diprolim.Properties.Resources.delete;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(303, 144);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(40, 40);
            this.btnCancelar.TabIndex = 159;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCambiarVendedor
            // 
            this.btnCambiarVendedor.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCambiarVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarVendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarVendedor.Location = new System.Drawing.Point(550, 12);
            this.btnCambiarVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiarVendedor.Name = "btnCambiarVendedor";
            this.btnCambiarVendedor.Size = new System.Drawing.Size(30, 30);
            this.btnCambiarVendedor.TabIndex = 160;
            this.btnCambiarVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarVendedor.UseVisualStyleBackColor = true;
            this.btnCambiarVendedor.Click += new System.EventHandler(this.btnCambiarVendedor_Click);
            // 
            // transferenciasInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(596, 201);
            this.Controls.Add(this.btnCambiarVendedor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTransferencias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxExistencias);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxCantidad);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.tbxNProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxProducto);
            this.Controls.Add(this.btnSPD);
            this.Controls.Add(this.tbxNVendedorD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxVendedorD);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxVendedor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "transferenciasInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferir inventario de vendedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Button btnSPD;
        private System.Windows.Forms.TextBox tbxNVendedorD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxVendedorD;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.TextBox tbxNProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxExistencias;
        private System.Windows.Forms.Button btnTransferencias;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCambiarVendedor;
    }
}