namespace Diprolim
{
    partial class Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Productos));
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precionormalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioproduccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valormedidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadmedidaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.rbPapel = new System.Windows.Forms.RadioButton();
            this.rbAccesorios = new System.Windows.Forms.RadioButton();
            this.rbProductos = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxPCalle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxPDistribuidor = new System.Windows.Forms.TextBox();
            this.tbxPAbarrotes = new System.Windows.Forms.TextBox();
            this.tbxDesc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxPrecioProduccion = new System.Windows.Forms.TextBox();
            this.cbxUMedida = new System.Windows.Forms.ComboBox();
            this.tbxVMedida = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxComision = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDescuento = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkbxComision = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.cbxFamilia = new System.Windows.Forms.ComboBox();
            this.btnAdelante = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnCambiarP = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.btnEditDescProducto = new System.Windows.Forms.Button();
            this.tbxCodEnvase = new System.Windows.Forms.TextBox();
            this.tbxDescripcionEnvase = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxDescuentoEnvase = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // precionormalDataGridViewTextBoxColumn
            // 
            this.precionormalDataGridViewTextBoxColumn.DataPropertyName = "precionormal";
            this.precionormalDataGridViewTextBoxColumn.HeaderText = "precionormal";
            this.precionormalDataGridViewTextBoxColumn.Name = "precionormalDataGridViewTextBoxColumn";
            // 
            // precioproduccionDataGridViewTextBoxColumn
            // 
            this.precioproduccionDataGridViewTextBoxColumn.DataPropertyName = "precioproduccion";
            this.precioproduccionDataGridViewTextBoxColumn.HeaderText = "precioproduccion";
            this.precioproduccionDataGridViewTextBoxColumn.Name = "precioproduccionDataGridViewTextBoxColumn";
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            // 
            // valormedidaDataGridViewTextBoxColumn
            // 
            this.valormedidaDataGridViewTextBoxColumn.DataPropertyName = "valor_medida";
            this.valormedidaDataGridViewTextBoxColumn.HeaderText = "valor_medida";
            this.valormedidaDataGridViewTextBoxColumn.Name = "valormedidaDataGridViewTextBoxColumn";
            // 
            // unidadmedidaidDataGridViewTextBoxColumn
            // 
            this.unidadmedidaidDataGridViewTextBoxColumn.DataPropertyName = "unidad_medida_id";
            this.unidadmedidaidDataGridViewTextBoxColumn.HeaderText = "unidad_medida_id";
            this.unidadmedidaidDataGridViewTextBoxColumn.Name = "unidadmedidaidDataGridViewTextBoxColumn";
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.Location = new System.Drawing.Point(219, 13);
            this.tbxCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(138, 23);
            this.tbxCodigo.TabIndex = 0;
            this.tbxCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCodigo_KeyDown);
            this.tbxCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCodigo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(215, 477);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.TabIndex = 93;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // rbPapel
            // 
            this.rbPapel.AutoSize = true;
            this.rbPapel.Location = new System.Drawing.Point(416, 198);
            this.rbPapel.Name = "rbPapel";
            this.rbPapel.Size = new System.Drawing.Size(62, 21);
            this.rbPapel.TabIndex = 108;
            this.rbPapel.Text = "Papel";
            this.rbPapel.UseVisualStyleBackColor = true;
            // 
            // rbAccesorios
            // 
            this.rbAccesorios.AutoSize = true;
            this.rbAccesorios.Location = new System.Drawing.Point(315, 198);
            this.rbAccesorios.Name = "rbAccesorios";
            this.rbAccesorios.Size = new System.Drawing.Size(95, 21);
            this.rbAccesorios.TabIndex = 107;
            this.rbAccesorios.Text = "Accesorios";
            this.rbAccesorios.UseVisualStyleBackColor = true;
            // 
            // rbProductos
            // 
            this.rbProductos.AutoSize = true;
            this.rbProductos.Location = new System.Drawing.Point(219, 198);
            this.rbProductos.Name = "rbProductos";
            this.rbProductos.Size = new System.Drawing.Size(90, 21);
            this.rbProductos.TabIndex = 106;
            this.rbProductos.Text = "Productos";
            this.rbProductos.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 17);
            this.label8.TabIndex = 105;
            this.label8.Text = "Departamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Precio de calle:          $";
            // 
            // tbxPCalle
            // 
            this.tbxPCalle.Location = new System.Drawing.Point(219, 227);
            this.tbxPCalle.MaxLength = 15;
            this.tbxPCalle.Name = "tbxPCalle";
            this.tbxPCalle.Size = new System.Drawing.Size(138, 23);
            this.tbxPCalle.TabIndex = 11;
            this.tbxPCalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPCalle_KeyDown);
            this.tbxPCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPCalle_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Precio distribuidores: $";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Precio abarrotes:       $";
            // 
            // tbxPDistribuidor
            // 
            this.tbxPDistribuidor.Location = new System.Drawing.Point(219, 289);
            this.tbxPDistribuidor.MaxLength = 15;
            this.tbxPDistribuidor.Name = "tbxPDistribuidor";
            this.tbxPDistribuidor.Size = new System.Drawing.Size(138, 23);
            this.tbxPDistribuidor.TabIndex = 15;
            this.tbxPDistribuidor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPDistribuidor_KeyDown);
            this.tbxPDistribuidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPDistribuidor_KeyPress);
            // 
            // tbxPAbarrotes
            // 
            this.tbxPAbarrotes.Location = new System.Drawing.Point(219, 258);
            this.tbxPAbarrotes.MaxLength = 15;
            this.tbxPAbarrotes.Name = "tbxPAbarrotes";
            this.tbxPAbarrotes.Size = new System.Drawing.Size(138, 23);
            this.tbxPAbarrotes.TabIndex = 13;
            this.tbxPAbarrotes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPAbarrotes_KeyDown);
            this.tbxPAbarrotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPAbarrotes_KeyPress);
            // 
            // tbxDesc
            // 
            this.tbxDesc.Location = new System.Drawing.Point(219, 73);
            this.tbxDesc.Name = "tbxDesc";
            this.tbxDesc.ReadOnly = true;
            this.tbxDesc.Size = new System.Drawing.Size(259, 23);
            this.tbxDesc.TabIndex = 1;
            this.tbxDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDesc_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Descripción:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(182, 17);
            this.label12.TabIndex = 8;
            this.label12.Text = "Precio de Producción: $";
            // 
            // tbxPrecioProduccion
            // 
            this.tbxPrecioProduccion.Location = new System.Drawing.Point(219, 167);
            this.tbxPrecioProduccion.MaxLength = 15;
            this.tbxPrecioProduccion.Name = "tbxPrecioProduccion";
            this.tbxPrecioProduccion.Size = new System.Drawing.Size(138, 23);
            this.tbxPrecioProduccion.TabIndex = 5;
            this.tbxPrecioProduccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPrecioProduccion_KeyDown);
            this.tbxPrecioProduccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPrecioProduccion_KeyPress);
            // 
            // cbxUMedida
            // 
            this.cbxUMedida.DisplayMember = "id";
            this.cbxUMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUMedida.FormattingEnabled = true;
            this.cbxUMedida.Location = new System.Drawing.Point(219, 135);
            this.cbxUMedida.Name = "cbxUMedida";
            this.cbxUMedida.Size = new System.Drawing.Size(138, 24);
            this.cbxUMedida.TabIndex = 3;
            this.cbxUMedida.ValueMember = "id";
            this.cbxUMedida.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxUMedida_KeyDown);
            // 
            // tbxVMedida
            // 
            this.tbxVMedida.Location = new System.Drawing.Point(219, 104);
            this.tbxVMedida.MaxLength = 15;
            this.tbxVMedida.Name = "tbxVMedida";
            this.tbxVMedida.Size = new System.Drawing.Size(138, 23);
            this.tbxVMedida.TabIndex = 2;
            this.tbxVMedida.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVMedida_KeyDown);
            this.tbxVMedida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVMedida_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "Unidad de Medida:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 17);
            this.label14.TabIndex = 9;
            this.label14.Text = "Valor de medida:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 17);
            this.label2.TabIndex = 112;
            this.label2.Text = "Comisión/Consignación %";
            // 
            // tbxComision
            // 
            this.tbxComision.Location = new System.Drawing.Point(219, 351);
            this.tbxComision.MaxLength = 15;
            this.tbxComision.Name = "tbxComision";
            this.tbxComision.Size = new System.Drawing.Size(138, 23);
            this.tbxComision.TabIndex = 111;
            this.tbxComision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxComision_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 17);
            this.label4.TabIndex = 110;
            this.label4.Text = "Descuento/Contado      %";
            // 
            // tbxDescuento
            // 
            this.tbxDescuento.Location = new System.Drawing.Point(219, 320);
            this.tbxDescuento.MaxLength = 15;
            this.tbxDescuento.Name = "tbxDescuento";
            this.tbxDescuento.Size = new System.Drawing.Size(138, 23);
            this.tbxDescuento.TabIndex = 109;
            this.tbxDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxDescuento_KeyPress);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Location = new System.Drawing.Point(323, 477);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 40);
            this.btnEliminar.TabIndex = 116;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 117;
            this.label5.Text = "Comisión:";
            // 
            // chkbxComision
            // 
            this.chkbxComision.AutoSize = true;
            this.chkbxComision.Location = new System.Drawing.Point(219, 385);
            this.chkbxComision.Name = "chkbxComision";
            this.chkbxComision.Size = new System.Drawing.Size(15, 14);
            this.chkbxComision.TabIndex = 118;
            this.chkbxComision.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 438);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 17);
            this.label6.TabIndex = 119;
            this.label6.Text = "Código de envase:";
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamilia.Location = new System.Drawing.Point(12, 46);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(64, 17);
            this.lblFamilia.TabIndex = 122;
            this.lblFamilia.Text = "Familia:";
            // 
            // cbxFamilia
            // 
            this.cbxFamilia.DisplayMember = "id";
            this.cbxFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFamilia.FormattingEnabled = true;
            this.cbxFamilia.Location = new System.Drawing.Point(219, 43);
            this.cbxFamilia.Name = "cbxFamilia";
            this.cbxFamilia.Size = new System.Drawing.Size(259, 24);
            this.cbxFamilia.TabIndex = 121;
            this.cbxFamilia.ValueMember = "id";
            this.cbxFamilia.SelectedIndexChanged += new System.EventHandler(this.cbxFamilia_SelectedIndexChanged);
            // 
            // btnAdelante
            // 
            this.btnAdelante.BackgroundImage = global::Diprolim.Properties.Resources.next24;
            this.btnAdelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdelante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdelante.Location = new System.Drawing.Point(362, 12);
            this.btnAdelante.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdelante.Name = "btnAdelante";
            this.btnAdelante.Size = new System.Drawing.Size(25, 25);
            this.btnAdelante.TabIndex = 115;
            this.btnAdelante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdelante.UseVisualStyleBackColor = true;
            this.btnAdelante.Click += new System.EventHandler(this.btnAdelante_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackgroundImage = global::Diprolim.Properties.Resources.back24;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtras.Location = new System.Drawing.Point(189, 12);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(1);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(25, 25);
            this.btnAtras.TabIndex = 114;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnCambiarP
            // 
            this.btnCambiarP.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCambiarP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarP.Location = new System.Drawing.Point(432, 9);
            this.btnCambiarP.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiarP.Name = "btnCambiarP";
            this.btnCambiarP.Size = new System.Drawing.Size(30, 30);
            this.btnCambiarP.TabIndex = 100;
            this.btnCambiarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarP.UseVisualStyleBackColor = true;
            this.btnCambiarP.Click += new System.EventHandler(this.btnCambiarP_Click);
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Location = new System.Drawing.Point(393, 9);
            this.btnSP.Margin = new System.Windows.Forms.Padding(5);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 89;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // btnEditDescProducto
            // 
            this.btnEditDescProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditDescProducto.BackgroundImage")));
            this.btnEditDescProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditDescProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDescProducto.Location = new System.Drawing.Point(485, 69);
            this.btnEditDescProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditDescProducto.Name = "btnEditDescProducto";
            this.btnEditDescProducto.Size = new System.Drawing.Size(30, 30);
            this.btnEditDescProducto.TabIndex = 123;
            this.btnEditDescProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditDescProducto.UseVisualStyleBackColor = true;
            this.btnEditDescProducto.Click += new System.EventHandler(this.btnEditDescProducto_Click);
            // 
            // tbxCodEnvase
            // 
            this.tbxCodEnvase.Location = new System.Drawing.Point(219, 435);
            this.tbxCodEnvase.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCodEnvase.MaxLength = 10;
            this.tbxCodEnvase.Name = "tbxCodEnvase";
            this.tbxCodEnvase.Size = new System.Drawing.Size(69, 23);
            this.tbxCodEnvase.TabIndex = 124;
            this.tbxCodEnvase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCodEnvase_KeyPress);
            // 
            // tbxDescripcionEnvase
            // 
            this.tbxDescripcionEnvase.Location = new System.Drawing.Point(296, 435);
            this.tbxDescripcionEnvase.Margin = new System.Windows.Forms.Padding(4);
            this.tbxDescripcionEnvase.Name = "tbxDescripcionEnvase";
            this.tbxDescripcionEnvase.ReadOnly = true;
            this.tbxDescripcionEnvase.Size = new System.Drawing.Size(219, 23);
            this.tbxDescripcionEnvase.TabIndex = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 408);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 17);
            this.label7.TabIndex = 127;
            this.label7.Text = "Descuento Envase       %";
            // 
            // tbxDescuentoEnvase
            // 
            this.tbxDescuentoEnvase.Location = new System.Drawing.Point(219, 405);
            this.tbxDescuentoEnvase.MaxLength = 15;
            this.tbxDescuentoEnvase.Name = "tbxDescuentoEnvase";
            this.tbxDescuentoEnvase.Size = new System.Drawing.Size(138, 23);
            this.tbxDescuentoEnvase.TabIndex = 126;
            this.tbxDescuentoEnvase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxDescuentoEnvase_KeyPress);
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(559, 536);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxDescuentoEnvase);
            this.Controls.Add(this.tbxDescripcionEnvase);
            this.Controls.Add(this.tbxCodEnvase);
            this.Controls.Add(this.btnEditDescProducto);
            this.Controls.Add(this.lblFamilia);
            this.Controls.Add(this.cbxFamilia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkbxComision);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAdelante);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxPDistribuidor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbxPCalle);
            this.Controls.Add(this.tbxPAbarrotes);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxPrecioProduccion);
            this.Controls.Add(this.tbxDesc);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbxUMedida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxVMedida);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbxCodigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxComision);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxDescuento);
            this.Controls.Add(this.rbPapel);
            this.Controls.Add(this.rbAccesorios);
            this.Controls.Add(this.rbProductos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCambiarP);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Productos_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precionormalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioproduccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valormedidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadmedidaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCambiarP;
        private System.Windows.Forms.RadioButton rbPapel;
        private System.Windows.Forms.RadioButton rbAccesorios;
        private System.Windows.Forms.RadioButton rbProductos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxPCalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxPDistribuidor;
        private System.Windows.Forms.TextBox tbxPAbarrotes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbxDesc;
        private System.Windows.Forms.TextBox tbxPrecioProduccion;
        private System.Windows.Forms.ComboBox cbxUMedida;
        private System.Windows.Forms.TextBox tbxVMedida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxComision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxDescuento;
        private System.Windows.Forms.Button btnAdelante;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkbxComision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.ComboBox cbxFamilia;
        private System.Windows.Forms.Button btnEditDescProducto;
        private System.Windows.Forms.TextBox tbxCodEnvase;
        private System.Windows.Forms.TextBox tbxDescripcionEnvase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxDescuentoEnvase;
    }
}