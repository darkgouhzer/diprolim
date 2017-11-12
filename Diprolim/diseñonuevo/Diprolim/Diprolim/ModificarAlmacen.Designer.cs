namespace Diprolim
{
    partial class ModificarAlmacen
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
            this.tbxID = new System.Windows.Forms.TextBox();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.tbxIniciales = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCambiarVendedor = new System.Windows.Forms.Button();
            this.btnSV = new System.Windows.Forms.Button();
            this.chkbLocal = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxE_Mail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxTelefono = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxRFC = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbxCP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxEstado = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxMunicipio = new System.Windows.Forms.TextBox();
            this.btnGuardarr = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.tbxLocalidad = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxNumInterior = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxNumExterior = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbxCalle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxID
            // 
            this.tbxID.Location = new System.Drawing.Point(129, 20);
            this.tbxID.Margin = new System.Windows.Forms.Padding(5);
            this.tbxID.MaxLength = 20;
            this.tbxID.Name = "tbxID";
            this.tbxID.Size = new System.Drawing.Size(103, 23);
            this.tbxID.TabIndex = 1;
            this.tbxID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxID_KeyDown);
            this.tbxID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxID_KeyPress);
            this.tbxID.Leave += new System.EventHandler(this.tbxID_Leave);
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(129, 53);
            this.tbxNombre.Margin = new System.Windows.Forms.Padding(5);
            this.tbxNombre.MaxLength = 100;
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(316, 23);
            this.tbxNombre.TabIndex = 2;
            // 
            // tbxIniciales
            // 
            this.tbxIniciales.Location = new System.Drawing.Point(129, 86);
            this.tbxIniciales.Margin = new System.Windows.Forms.Padding(5);
            this.tbxIniciales.MaxLength = 3;
            this.tbxIniciales.Name = "tbxIniciales";
            this.tbxIniciales.Size = new System.Drawing.Size(105, 23);
            this.tbxIniciales.TabIndex = 3;
            this.tbxIniciales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxIniciales_KeyPress);
            this.tbxIniciales.Leave += new System.EventHandler(this.tbxIniciales_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(244, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 131;
            this.label5.Text = "Máximo 3 dígitos";
            // 
            // btnCambiarVendedor
            // 
            this.btnCambiarVendedor.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCambiarVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarVendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarVendedor.Location = new System.Drawing.Point(282, 16);
            this.btnCambiarVendedor.Margin = new System.Windows.Forms.Padding(5);
            this.btnCambiarVendedor.Name = "btnCambiarVendedor";
            this.btnCambiarVendedor.Size = new System.Drawing.Size(30, 30);
            this.btnCambiarVendedor.TabIndex = 124;
            this.btnCambiarVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarVendedor.UseVisualStyleBackColor = true;
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(242, 16);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 123;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // chkbLocal
            // 
            this.chkbLocal.AutoSize = true;
            this.chkbLocal.Location = new System.Drawing.Point(331, 19);
            this.chkbLocal.Margin = new System.Windows.Forms.Padding(4);
            this.chkbLocal.Name = "chkbLocal";
            this.chkbLocal.Size = new System.Drawing.Size(114, 21);
            this.chkbLocal.TabIndex = 132;
            this.chkbLocal.Text = "Almacen local";
            this.chkbLocal.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 353);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 16);
            this.label12.TabIndex = 174;
            this.label12.Text = "e-mail";
            // 
            // tbxE_Mail
            // 
            this.tbxE_Mail.Location = new System.Drawing.Point(129, 350);
            this.tbxE_Mail.Name = "tbxE_Mail";
            this.tbxE_Mail.Size = new System.Drawing.Size(202, 23);
            this.tbxE_Mail.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 172;
            this.label11.Text = "Telefono:";
            // 
            // tbxTelefono
            // 
            this.tbxTelefono.Location = new System.Drawing.Point(129, 321);
            this.tbxTelefono.Name = "tbxTelefono";
            this.tbxTelefono.Size = new System.Drawing.Size(202, 23);
            this.tbxTelefono.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 296);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 16);
            this.label13.TabIndex = 170;
            this.label13.Text = "RFC:";
            // 
            // tbxRFC
            // 
            this.tbxRFC.Location = new System.Drawing.Point(129, 292);
            this.tbxRFC.Name = "tbxRFC";
            this.tbxRFC.Size = new System.Drawing.Size(202, 23);
            this.tbxRFC.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(17, 266);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 16);
            this.label14.TabIndex = 168;
            this.label14.Text = "CP:";
            // 
            // tbxCP
            // 
            this.tbxCP.Location = new System.Drawing.Point(129, 263);
            this.tbxCP.Name = "tbxCP";
            this.tbxCP.Size = new System.Drawing.Size(202, 23);
            this.tbxCP.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 237);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 16);
            this.label15.TabIndex = 166;
            this.label15.Text = "Estado:";
            // 
            // tbxEstado
            // 
            this.tbxEstado.Location = new System.Drawing.Point(129, 234);
            this.tbxEstado.Name = "tbxEstado";
            this.tbxEstado.Size = new System.Drawing.Size(202, 23);
            this.tbxEstado.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(17, 208);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 16);
            this.label16.TabIndex = 164;
            this.label16.Text = "Municipio:";
            // 
            // tbxMunicipio
            // 
            this.tbxMunicipio.Location = new System.Drawing.Point(129, 205);
            this.tbxMunicipio.Name = "tbxMunicipio";
            this.tbxMunicipio.Size = new System.Drawing.Size(202, 23);
            this.tbxMunicipio.TabIndex = 8;
            // 
            // btnGuardarr
            // 
            this.btnGuardarr.Location = new System.Drawing.Point(129, 381);
            this.btnGuardarr.Name = "btnGuardarr";
            this.btnGuardarr.Size = new System.Drawing.Size(75, 31);
            this.btnGuardarr.TabIndex = 14;
            this.btnGuardarr.Text = "Guardar";
            this.btnGuardarr.UseVisualStyleBackColor = true;
            this.btnGuardarr.Click += new System.EventHandler(this.btnGuardarr_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(17, 179);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 16);
            this.label17.TabIndex = 159;
            this.label17.Text = "Localidad:";
            // 
            // tbxLocalidad
            // 
            this.tbxLocalidad.Location = new System.Drawing.Point(129, 176);
            this.tbxLocalidad.Name = "tbxLocalidad";
            this.tbxLocalidad.Size = new System.Drawing.Size(202, 23);
            this.tbxLocalidad.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(237, 149);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 16);
            this.label18.TabIndex = 157;
            this.label18.Text = "Número interior:";
            // 
            // tbxNumInterior
            // 
            this.tbxNumInterior.Location = new System.Drawing.Point(345, 146);
            this.tbxNumInterior.Name = "tbxNumInterior";
            this.tbxNumInterior.Size = new System.Drawing.Size(100, 23);
            this.tbxNumInterior.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(17, 149);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 16);
            this.label19.TabIndex = 155;
            this.label19.Text = "Número exterior:";
            // 
            // tbxNumExterior
            // 
            this.tbxNumExterior.Location = new System.Drawing.Point(129, 146);
            this.tbxNumExterior.Name = "tbxNumExterior";
            this.tbxNumExterior.Size = new System.Drawing.Size(100, 23);
            this.tbxNumExterior.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 120);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 17);
            this.label20.TabIndex = 153;
            this.label20.Text = "Calle:";
            // 
            // tbxCalle
            // 
            this.tbxCalle.Location = new System.Drawing.Point(129, 117);
            this.tbxCalle.Name = "tbxCalle";
            this.tbxCalle.Size = new System.Drawing.Size(316, 23);
            this.tbxCalle.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 175;
            this.label3.Text = "Iniciales:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 176;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 177;
            this.label1.Text = "Código:";
            // 
            // ModificarAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(467, 424);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbxE_Mail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxTelefono);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbxRFC);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbxCP);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbxEstado);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tbxMunicipio);
            this.Controls.Add(this.btnGuardarr);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbxLocalidad);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbxNumInterior);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbxNumExterior);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbxCalle);
            this.Controls.Add(this.chkbLocal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxID);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.tbxIniciales);
            this.Controls.Add(this.btnCambiarVendedor);
            this.Controls.Add(this.btnSV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificarAlmacen";
            this.Text = "Almacenes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.TextBox tbxIniciales;
        private System.Windows.Forms.Button btnCambiarVendedor;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkbLocal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxE_Mail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxTelefono;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxRFC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbxCP;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxEstado;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxMunicipio;
        private System.Windows.Forms.Button btnGuardarr;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbxLocalidad;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxNumInterior;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbxNumExterior;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbxCalle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}