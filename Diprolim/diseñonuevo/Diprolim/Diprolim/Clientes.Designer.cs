namespace Diprolim
{
    partial class Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes));
            this.tbxID = new System.Windows.Forms.TextBox();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.cbxCategorias = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCambiarVendedor = new System.Windows.Forms.Button();
            this.btnSV = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cheDerechoADescuento = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRutas = new System.Windows.Forms.Button();
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
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnGuardarr = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.tbxLocalidad = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxNumInterior = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxNumExterior = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbxCalle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxRutas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxLocalidades = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // tbxID
            // 
            this.tbxID.Location = new System.Drawing.Point(158, 13);
            this.tbxID.Margin = new System.Windows.Forms.Padding(4);
            this.tbxID.MaxLength = 20;
            this.tbxID.Name = "tbxID";
            this.tbxID.Size = new System.Drawing.Size(121, 23);
            this.tbxID.TabIndex = 1;
            this.tbxID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxID_KeyDown);
            this.tbxID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxID_KeyPress);
            this.tbxID.Leave += new System.EventHandler(this.tbxID_Leave);
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(158, 46);
            this.tbxNombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNombre.MaxLength = 40;
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(431, 23);
            this.tbxNombre.TabIndex = 2;
            this.tbxNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxNombre_KeyDown);
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNVendedor.Location = new System.Drawing.Point(233, 81);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(280, 22);
            this.tbxNVendedor.TabIndex = 107;
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxVendedor.Location = new System.Drawing.Point(158, 81);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.MaxLength = 9;
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(67, 22);
            this.tbxVendedor.TabIndex = 3;
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            this.tbxVendedor.Leave += new System.EventHandler(this.tbxVendedor_Leave);
            // 
            // cbxCategorias
            // 
            this.cbxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategorias.FormattingEnabled = true;
            this.cbxCategorias.Location = new System.Drawing.Point(158, 115);
            this.cbxCategorias.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCategorias.Name = "cbxCategorias";
            this.cbxCategorias.Size = new System.Drawing.Size(130, 24);
            this.cbxCategorias.TabIndex = 4;
            this.cbxCategorias.SelectedIndexChanged += new System.EventHandler(this.cbxCategorias_SelectedIndexChanged);
            this.cbxCategorias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCategorias_KeyDown);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(521, 77);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 108;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCambiarVendedor
            // 
            this.btnCambiarVendedor.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCambiarVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarVendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarVendedor.Location = new System.Drawing.Point(328, 9);
            this.btnCambiarVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiarVendedor.Name = "btnCambiarVendedor";
            this.btnCambiarVendedor.Size = new System.Drawing.Size(30, 30);
            this.btnCambiarVendedor.TabIndex = 103;
            this.btnCambiarVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarVendedor.UseVisualStyleBackColor = true;
            this.btnCambiarVendedor.Click += new System.EventHandler(this.btnCambiarVendedor_Click);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(290, 9);
            this.btnSV.Margin = new System.Windows.Forms.Padding(4);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 102;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(559, 77);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 110;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cheDerechoADescuento
            // 
            this.cheDerechoADescuento.AutoSize = true;
            this.cheDerechoADescuento.Location = new System.Drawing.Point(158, 218);
            this.cheDerechoADescuento.Name = "cheDerechoADescuento";
            this.cheDerechoADescuento.Size = new System.Drawing.Size(15, 14);
            this.cheDerechoADescuento.TabIndex = 7;
            this.cheDerechoADescuento.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 16);
            this.label5.TabIndex = 112;
            this.label5.Text = "Derecho a descuento:";
            // 
            // btnRutas
            // 
            this.btnRutas.BackgroundImage = global::Diprolim.Properties.Resources.plus;
            this.btnRutas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRutas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRutas.Location = new System.Drawing.Point(559, 149);
            this.btnRutas.Margin = new System.Windows.Forms.Padding(4);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Size = new System.Drawing.Size(30, 30);
            this.btnRutas.TabIndex = 117;
            this.btnRutas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRutas.UseVisualStyleBackColor = true;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 475);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 16);
            this.label12.TabIndex = 151;
            this.label12.Text = "E-mail:";
            // 
            // tbxE_Mail
            // 
            this.tbxE_Mail.Location = new System.Drawing.Point(158, 472);
            this.tbxE_Mail.Name = "tbxE_Mail";
            this.tbxE_Mail.Size = new System.Drawing.Size(208, 23);
            this.tbxE_Mail.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 446);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 149;
            this.label11.Text = "Telefono:";
            // 
            // tbxTelefono
            // 
            this.tbxTelefono.Location = new System.Drawing.Point(158, 443);
            this.tbxTelefono.Name = "tbxTelefono";
            this.tbxTelefono.Size = new System.Drawing.Size(208, 23);
            this.tbxTelefono.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 417);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 16);
            this.label13.TabIndex = 147;
            this.label13.Text = "RFC:";
            // 
            // tbxRFC
            // 
            this.tbxRFC.Location = new System.Drawing.Point(158, 414);
            this.tbxRFC.Name = "tbxRFC";
            this.tbxRFC.Size = new System.Drawing.Size(208, 23);
            this.tbxRFC.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 388);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 16);
            this.label14.TabIndex = 145;
            this.label14.Text = "Código postal:";
            // 
            // tbxCP
            // 
            this.tbxCP.Location = new System.Drawing.Point(158, 385);
            this.tbxCP.Name = "tbxCP";
            this.tbxCP.Size = new System.Drawing.Size(100, 23);
            this.tbxCP.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 359);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 16);
            this.label15.TabIndex = 143;
            this.label15.Text = "Estado:";
            // 
            // tbxEstado
            // 
            this.tbxEstado.Location = new System.Drawing.Point(158, 356);
            this.tbxEstado.Name = "tbxEstado";
            this.tbxEstado.Size = new System.Drawing.Size(208, 23);
            this.tbxEstado.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 328);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 16);
            this.label16.TabIndex = 141;
            this.label16.Text = "Municipio:";
            // 
            // tbxMunicipio
            // 
            this.tbxMunicipio.Location = new System.Drawing.Point(158, 325);
            this.tbxMunicipio.Name = "tbxMunicipio";
            this.tbxMunicipio.Size = new System.Drawing.Size(208, 23);
            this.tbxMunicipio.TabIndex = 12;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(264, 501);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(100, 40);
            this.btnBorrar.TabIndex = 19;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorar_Click);
            // 
            // btnGuardarr
            // 
            this.btnGuardarr.Location = new System.Drawing.Point(158, 501);
            this.btnGuardarr.Name = "btnGuardarr";
            this.btnGuardarr.Size = new System.Drawing.Size(100, 40);
            this.btnGuardarr.TabIndex = 18;
            this.btnGuardarr.Text = "Guardar";
            this.btnGuardarr.UseVisualStyleBackColor = true;
            this.btnGuardarr.Click += new System.EventHandler(this.btnGuardarr_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 299);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 16);
            this.label17.TabIndex = 136;
            this.label17.Text = "Localidad:";
            // 
            // tbxLocalidad
            // 
            this.tbxLocalidad.Location = new System.Drawing.Point(158, 296);
            this.tbxLocalidad.Name = "tbxLocalidad";
            this.tbxLocalidad.Size = new System.Drawing.Size(208, 23);
            this.tbxLocalidad.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(264, 270);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 16);
            this.label18.TabIndex = 134;
            this.label18.Text = "Número interior:";
            // 
            // tbxNumInterior
            // 
            this.tbxNumInterior.Location = new System.Drawing.Point(372, 265);
            this.tbxNumInterior.Name = "tbxNumInterior";
            this.tbxNumInterior.Size = new System.Drawing.Size(100, 23);
            this.tbxNumInterior.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 268);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 16);
            this.label19.TabIndex = 132;
            this.label19.Text = "Númerp Exterior:";
            // 
            // tbxNumExterior
            // 
            this.tbxNumExterior.Location = new System.Drawing.Point(158, 267);
            this.tbxNumExterior.Name = "tbxNumExterior";
            this.tbxNumExterior.Size = new System.Drawing.Size(100, 23);
            this.tbxNumExterior.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 241);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 17);
            this.label20.TabIndex = 130;
            this.label20.Text = "Calle:";
            // 
            // tbxCalle
            // 
            this.tbxCalle.Location = new System.Drawing.Point(158, 238);
            this.tbxCalle.Name = "tbxCalle";
            this.tbxCalle.Size = new System.Drawing.Size(314, 23);
            this.tbxCalle.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 153;
            this.label7.Text = "Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 154;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 155;
            this.label2.Text = "Vendedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 156;
            this.label3.Text = "Categoria:";
            // 
            // cbxRutas
            // 
            this.cbxRutas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRutas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRutas.FormattingEnabled = true;
            this.cbxRutas.Location = new System.Drawing.Point(158, 150);
            this.cbxRutas.Margin = new System.Windows.Forms.Padding(4);
            this.cbxRutas.Name = "cbxRutas";
            this.cbxRutas.Size = new System.Drawing.Size(130, 24);
            this.cbxRutas.TabIndex = 5;
            this.cbxRutas.SelectedIndexChanged += new System.EventHandler(this.cbxRutas_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 157;
            this.label4.Text = "Rutas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 158;
            this.label6.Text = "Localidades:";
            // 
            // cbxLocalidades
            // 
            this.cbxLocalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLocalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLocalidades.FormattingEnabled = true;
            this.cbxLocalidades.Location = new System.Drawing.Point(390, 153);
            this.cbxLocalidades.Margin = new System.Windows.Forms.Padding(4);
            this.cbxLocalidades.Name = "cbxLocalidades";
            this.cbxLocalidades.Size = new System.Drawing.Size(161, 24);
            this.cbxLocalidades.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 17);
            this.label8.TabIndex = 165;
            this.label8.Text = "Fecha de ingreso:";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.CustomFormat = "dd/MMMM/yyyy";
            this.dtpFechaIngreso.Enabled = false;
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(158, 183);
            this.dtpFechaIngreso.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(156, 23);
            this.dtpFechaIngreso.TabIndex = 164;
            this.dtpFechaIngreso.Value = new System.DateTime(2014, 2, 1, 0, 0, 0, 0);
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(602, 557);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpFechaIngreso);
            this.Controls.Add(this.cbxLocalidades);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
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
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnGuardarr);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbxLocalidad);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbxNumInterior);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbxNumExterior);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbxCalle);
            this.Controls.Add(this.btnRutas);
            this.Controls.Add(this.cbxRutas);
            this.Controls.Add(this.cheDerechoADescuento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxID);
            this.Controls.Add(this.cbxCategorias);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCambiarVendedor);
            this.Controls.Add(this.btnSV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Clientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModificarClientes_FormClosing);
            this.Load += new System.EventHandler(this.ModificarClientes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCambiarVendedor;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbxCategorias;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cheDerechoADescuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRutas;
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
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnGuardarr;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbxLocalidad;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxNumInterior;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbxNumExterior;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbxCalle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxRutas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxLocalidades;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
    }
}