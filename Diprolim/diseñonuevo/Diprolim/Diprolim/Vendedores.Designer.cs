namespace Diprolim
{
    partial class ModificarEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarEmpleado));
            this.cbxPuestos = new System.Windows.Forms.ComboBox();
            this.tbxID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxAPaterno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFNacimiento = new System.Windows.Forms.DateTimePicker();
            this.cbxSexo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxAMaterno = new System.Windows.Forms.TextBox();
            this.btnCambiarVendedor = new System.Windows.Forms.Button();
            this.btnSV = new System.Windows.Forms.Button();
            this.tbxLimite = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNPuesto = new System.Windows.Forms.Button();
            this.tbxLimiteCredito = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxE_Mail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxTelefono = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxEstado = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxMunicipio = new System.Windows.Forms.TextBox();
            this.btnBorar = new System.Windows.Forms.Button();
            this.btnGuardarr = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.tbxLocalidad = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxNumInterior = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxNumExterior = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbxCalle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxPuestos
            // 
            this.cbxPuestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPuestos.FormattingEnabled = true;
            this.cbxPuestos.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cbxPuestos.Location = new System.Drawing.Point(154, 219);
            this.cbxPuestos.Name = "cbxPuestos";
            this.cbxPuestos.Size = new System.Drawing.Size(161, 24);
            this.cbxPuestos.TabIndex = 7;
            // 
            // tbxID
            // 
            this.tbxID.Location = new System.Drawing.Point(154, 15);
            this.tbxID.MaxLength = 20;
            this.tbxID.Name = "tbxID";
            this.tbxID.Size = new System.Drawing.Size(113, 23);
            this.tbxID.TabIndex = 0;
            this.tbxID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxID_KeyDown);
            this.tbxID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxID_KeyPress);
            this.tbxID.Leave += new System.EventHandler(this.tbxID_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Código:";
            // 
            // tbxAPaterno
            // 
            this.tbxAPaterno.Location = new System.Drawing.Point(154, 73);
            this.tbxAPaterno.MaxLength = 20;
            this.tbxAPaterno.Name = "tbxAPaterno";
            this.tbxAPaterno.Size = new System.Drawing.Size(314, 23);
            this.tbxAPaterno.TabIndex = 2;
            this.tbxAPaterno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxAPaterno_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre:";
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(154, 44);
            this.tbxNombre.MaxLength = 40;
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(314, 23);
            this.tbxNombre.TabIndex = 1;
            this.tbxNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxNombre_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 222);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Puesto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 165);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Fecha de nacimiento:";
            // 
            // dtpFNacimiento
            // 
            this.dtpFNacimiento.CustomFormat = "dd/MMMM/yyyy";
            this.dtpFNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFNacimiento.Location = new System.Drawing.Point(154, 160);
            this.dtpFNacimiento.Name = "dtpFNacimiento";
            this.dtpFNacimiento.Size = new System.Drawing.Size(158, 23);
            this.dtpFNacimiento.TabIndex = 5;
            this.dtpFNacimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFNacimiento_KeyDown);
            // 
            // cbxSexo
            // 
            this.cbxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSexo.FormattingEnabled = true;
            this.cbxSexo.ItemHeight = 16;
            this.cbxSexo.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cbxSexo.Location = new System.Drawing.Point(154, 189);
            this.cbxSexo.Name = "cbxSexo";
            this.cbxSexo.Size = new System.Drawing.Size(161, 24);
            this.cbxSexo.TabIndex = 6;
            this.cbxSexo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxSexo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 192);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Sexo:";
            // 
            // tbxAMaterno
            // 
            this.tbxAMaterno.Location = new System.Drawing.Point(154, 102);
            this.tbxAMaterno.MaxLength = 20;
            this.tbxAMaterno.Name = "tbxAMaterno";
            this.tbxAMaterno.Size = new System.Drawing.Size(314, 23);
            this.tbxAMaterno.TabIndex = 3;
            this.tbxAMaterno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxAMaterno_KeyDown);
            // 
            // btnCambiarVendedor
            // 
            this.btnCambiarVendedor.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCambiarVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarVendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarVendedor.Location = new System.Drawing.Point(309, 11);
            this.btnCambiarVendedor.Name = "btnCambiarVendedor";
            this.btnCambiarVendedor.Size = new System.Drawing.Size(30, 30);
            this.btnCambiarVendedor.TabIndex = 98;
            this.btnCambiarVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarVendedor.UseVisualStyleBackColor = true;
            this.btnCambiarVendedor.Click += new System.EventHandler(this.btnCambiarVendedor_Click);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Location = new System.Drawing.Point(273, 11);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 88;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // tbxLimite
            // 
            this.tbxLimite.Location = new System.Drawing.Point(154, 452);
            this.tbxLimite.MaxLength = 20;
            this.tbxLimite.Name = "tbxLimite";
            this.tbxLimite.Size = new System.Drawing.Size(217, 23);
            this.tbxLimite.TabIndex = 17;
            this.tbxLimite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxLimite_KeyDown);
            this.tbxLimite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxLimite_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 455);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 16);
            this.label9.TabIndex = 99;
            this.label9.Text = "Limite de Inventario:";
            // 
            // btnNPuesto
            // 
            this.btnNPuesto.BackgroundImage = global::Diprolim.Properties.Resources.plus;
            this.btnNPuesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNPuesto.Location = new System.Drawing.Point(321, 215);
            this.btnNPuesto.Name = "btnNPuesto";
            this.btnNPuesto.Size = new System.Drawing.Size(30, 30);
            this.btnNPuesto.TabIndex = 8;
            this.btnNPuesto.UseVisualStyleBackColor = true;
            this.btnNPuesto.Click += new System.EventHandler(this.btnNPuesto_Click);
            // 
            // tbxLimiteCredito
            // 
            this.tbxLimiteCredito.Location = new System.Drawing.Point(154, 481);
            this.tbxLimiteCredito.MaxLength = 20;
            this.tbxLimiteCredito.Name = "tbxLimiteCredito";
            this.tbxLimiteCredito.Size = new System.Drawing.Size(217, 23);
            this.tbxLimiteCredito.TabIndex = 18;
            this.tbxLimiteCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxLimiteCredito_KeyDown);
            this.tbxLimiteCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxLimiteCredito_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 484);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 16);
            this.label10.TabIndex = 102;
            this.label10.Text = "Limite de Crédito:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 426);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 127;
            this.label12.Text = "e-mail:";
            // 
            // tbxE_Mail
            // 
            this.tbxE_Mail.Location = new System.Drawing.Point(154, 423);
            this.tbxE_Mail.Name = "tbxE_Mail";
            this.tbxE_Mail.Size = new System.Drawing.Size(217, 23);
            this.tbxE_Mail.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 397);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 125;
            this.label11.Text = "Telefono:";
            // 
            // tbxTelefono
            // 
            this.tbxTelefono.Location = new System.Drawing.Point(154, 394);
            this.tbxTelefono.Name = "tbxTelefono";
            this.tbxTelefono.Size = new System.Drawing.Size(217, 23);
            this.tbxTelefono.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 368);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 16);
            this.label15.TabIndex = 119;
            this.label15.Text = "Estado:";
            // 
            // tbxEstado
            // 
            this.tbxEstado.Location = new System.Drawing.Point(154, 365);
            this.tbxEstado.Name = "tbxEstado";
            this.tbxEstado.Size = new System.Drawing.Size(217, 23);
            this.tbxEstado.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(18, 339);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 16);
            this.label16.TabIndex = 117;
            this.label16.Text = "Municipio:";
            // 
            // tbxMunicipio
            // 
            this.tbxMunicipio.Location = new System.Drawing.Point(154, 336);
            this.tbxMunicipio.Name = "tbxMunicipio";
            this.tbxMunicipio.Size = new System.Drawing.Size(217, 23);
            this.tbxMunicipio.TabIndex = 13;
            // 
            // btnBorar
            // 
            this.btnBorar.Location = new System.Drawing.Point(296, 552);
            this.btnBorar.Name = "btnBorar";
            this.btnBorar.Size = new System.Drawing.Size(75, 31);
            this.btnBorar.TabIndex = 21;
            this.btnBorar.Text = "Borrar";
            this.btnBorar.UseVisualStyleBackColor = true;
            this.btnBorar.Click += new System.EventHandler(this.btnBorar_Click);
            // 
            // btnGuardarr
            // 
            this.btnGuardarr.Location = new System.Drawing.Point(215, 552);
            this.btnGuardarr.Name = "btnGuardarr";
            this.btnGuardarr.Size = new System.Drawing.Size(75, 31);
            this.btnGuardarr.TabIndex = 20;
            this.btnGuardarr.Text = "Guardar";
            this.btnGuardarr.UseVisualStyleBackColor = true;
            this.btnGuardarr.Click += new System.EventHandler(this.btnGuardarr_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(18, 310);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 16);
            this.label17.TabIndex = 112;
            this.label17.Text = "Localidad:";
            // 
            // tbxLocalidad
            // 
            this.tbxLocalidad.Location = new System.Drawing.Point(154, 307);
            this.tbxLocalidad.Name = "tbxLocalidad";
            this.tbxLocalidad.Size = new System.Drawing.Size(217, 23);
            this.tbxLocalidad.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(260, 281);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 16);
            this.label18.TabIndex = 110;
            this.label18.Text = "Número interior:";
            // 
            // tbxNumInterior
            // 
            this.tbxNumInterior.Location = new System.Drawing.Point(368, 278);
            this.tbxNumInterior.Name = "tbxNumInterior";
            this.tbxNumInterior.Size = new System.Drawing.Size(100, 23);
            this.tbxNumInterior.TabIndex = 11;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(18, 281);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 16);
            this.label19.TabIndex = 108;
            this.label19.Text = "Número exterior:";
            // 
            // tbxNumExterior
            // 
            this.tbxNumExterior.Location = new System.Drawing.Point(154, 278);
            this.tbxNumExterior.Name = "tbxNumExterior";
            this.tbxNumExterior.Size = new System.Drawing.Size(100, 23);
            this.tbxNumExterior.TabIndex = 10;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(18, 252);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 17);
            this.label20.TabIndex = 106;
            this.label20.Text = "Calle:";
            // 
            // tbxCalle
            // 
            this.tbxCalle.Location = new System.Drawing.Point(154, 249);
            this.tbxCalle.Name = "tbxCalle";
            this.tbxCalle.Size = new System.Drawing.Size(314, 23);
            this.tbxCalle.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 128;
            this.label2.Text = "Apellido paterno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 129;
            this.label3.Text = "Apellido materno:";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.CustomFormat = "dd/MMMM/yyyy";
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(154, 131);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(158, 23);
            this.dtpFechaIngreso.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 136);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 16);
            this.label8.TabIndex = 131;
            this.label8.Text = "Fecha de ingreso:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 513);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 133;
            this.label13.Text = "Status:";
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.ItemHeight = 16;
            this.cbxStatus.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbxStatus.Location = new System.Drawing.Point(154, 510);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(161, 24);
            this.cbxStatus.TabIndex = 19;
            // 
            // ModificarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(483, 599);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpFechaIngreso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbxE_Mail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxTelefono);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbxEstado);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tbxMunicipio);
            this.Controls.Add(this.btnBorar);
            this.Controls.Add(this.btnGuardarr);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbxLocalidad);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbxNumInterior);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbxNumExterior);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbxCalle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.tbxAPaterno);
            this.Controls.Add(this.cbxPuestos);
            this.Controls.Add(this.tbxLimiteCredito);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnNPuesto);
            this.Controls.Add(this.tbxLimite);
            this.Controls.Add(this.tbxAMaterno);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCambiarVendedor);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxSexo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFNacimiento);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificarEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Altas, bajas y modificaciones de vendedores";
            this.Load += new System.EventHandler(this.ModificarEmpleado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFNacimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxSexo;
        private System.Windows.Forms.TextBox tbxAMaterno;
        private System.Windows.Forms.TextBox tbxAPaterno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.Button btnCambiarVendedor;
        private System.Windows.Forms.TextBox tbxLimite;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnNPuesto;
        private System.Windows.Forms.ComboBox cbxPuestos;
        private System.Windows.Forms.TextBox tbxLimiteCredito;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxE_Mail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxTelefono;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxEstado;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxMunicipio;
        private System.Windows.Forms.Button btnBorar;
        private System.Windows.Forms.Button btnGuardarr;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbxLocalidad;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxNumInterior;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbxNumExterior;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbxCalle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxStatus;
    }
}