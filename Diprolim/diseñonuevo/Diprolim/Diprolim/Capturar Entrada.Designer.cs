namespace Diprolim
{
    partial class Capturar_Entrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Capturar_Entrada));
            this.lblCodigo = new System.Windows.Forms.Label();
            this.tbxProducto = new System.Windows.Forms.TextBox();
            this.tbxNProducto = new System.Windows.Forms.TextBox();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.tbxComentarios = new System.Windows.Forms.TextBox();
            this.lblComentarios = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.cbxMotivo = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.tbxExistencias = new System.Windows.Forms.TextBox();
            this.lblExistencias = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.tbxFolioDE = new System.Windows.Forms.TextBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.chkImprimir = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCambiarVendedor = new System.Windows.Forms.Button();
            this.btnSV = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CheckE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codigoE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.Location = new System.Drawing.Point(15, 125);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(63, 17);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // tbxProducto
            // 
            this.tbxProducto.Location = new System.Drawing.Point(108, 122);
            this.tbxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProducto.Name = "tbxProducto";
            this.tbxProducto.Size = new System.Drawing.Size(92, 23);
            this.tbxProducto.TabIndex = 4;
            this.tbxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxProducto_KeyDown);
            this.tbxProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tbxNProducto
            // 
            this.tbxNProducto.Location = new System.Drawing.Point(249, 122);
            this.tbxNProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNProducto.Name = "tbxNProducto";
            this.tbxNProducto.ReadOnly = true;
            this.tbxNProducto.Size = new System.Drawing.Size(286, 23);
            this.tbxNProducto.TabIndex = 38;
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.Location = new System.Drawing.Point(108, 153);
            this.tbxCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.Size = new System.Drawing.Size(92, 23);
            this.tbxCantidad.TabIndex = 5;
            this.tbxCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            this.tbxCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.Location = new System.Drawing.Point(15, 156);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(77, 17);
            this.lblCantidad.TabIndex = 39;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // Tabla
            // 
            this.Tabla.AllowUserToAddRows = false;
            this.Tabla.AllowUserToDeleteRows = false;
            this.Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckE,
            this.codigoE,
            this.desE,
            this.cantidadE,
            this.totalE,
            this.a,
            this.Fecha,
            this.colDevInicial,
            this.colDescripcionID,
            this.colValorMedida,
            this.colDescripcionGeneral});
            this.Tabla.Location = new System.Drawing.Point(12, 191);
            this.Tabla.Name = "Tabla";
            this.Tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tabla.Size = new System.Drawing.Size(661, 185);
            this.Tabla.TabIndex = 101;
            // 
            // tbxComentarios
            // 
            this.tbxComentarios.Location = new System.Drawing.Point(113, 384);
            this.tbxComentarios.Margin = new System.Windows.Forms.Padding(5);
            this.tbxComentarios.MaxLength = 199;
            this.tbxComentarios.Name = "tbxComentarios";
            this.tbxComentarios.Size = new System.Drawing.Size(550, 23);
            this.tbxComentarios.TabIndex = 7;
            this.tbxComentarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxComentarios_KeyPress);
            // 
            // lblComentarios
            // 
            this.lblComentarios.AutoSize = true;
            this.lblComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentarios.Location = new System.Drawing.Point(6, 387);
            this.lblComentarios.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(99, 16);
            this.lblComentarios.TabIndex = 164;
            this.lblComentarios.Text = "Comentarios:";
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(15, 62);
            this.lblMotivo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(58, 16);
            this.lblMotivo.TabIndex = 163;
            this.lblMotivo.Text = "Motivo:";
            // 
            // cbxMotivo
            // 
            this.cbxMotivo.DisplayMember = "id";
            this.cbxMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMotivo.FormattingEnabled = true;
            this.cbxMotivo.Items.AddRange(new object[] {
            "Transferencia",
            "Producción",
            "Transferencia de producción",
            "Devolución de Vendedor",
            "Devolución por consignación",
            "Devolucion de Cliente",
            "Entradas a vendedores",
            "Otros"});
            this.cbxMotivo.Location = new System.Drawing.Point(108, 59);
            this.cbxMotivo.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMotivo.Name = "cbxMotivo";
            this.cbxMotivo.Size = new System.Drawing.Size(213, 24);
            this.cbxMotivo.TabIndex = 1;
            this.cbxMotivo.ValueMember = "id";
            this.cbxMotivo.SelectedIndexChanged += new System.EventHandler(this.cbxMotivo_SelectedIndexChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "d/M/yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(530, 13);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(132, 23);
            this.dtpFecha.TabIndex = 171;
            this.dtpFecha.Value = new System.DateTime(2013, 12, 25, 16, 13, 35, 0);
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Location = new System.Drawing.Point(249, 90);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(248, 23);
            this.tbxNVendedor.TabIndex = 179;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblVendedor.Location = new System.Drawing.Point(15, 90);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(83, 17);
            this.lblVendedor.TabIndex = 178;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Enabled = false;
            this.tbxVendedor.Location = new System.Drawing.Point(108, 87);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(93, 23);
            this.tbxVendedor.TabIndex = 3;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            // 
            // tbxExistencias
            // 
            this.tbxExistencias.Location = new System.Drawing.Point(381, 153);
            this.tbxExistencias.Margin = new System.Windows.Forms.Padding(4);
            this.tbxExistencias.Name = "tbxExistencias";
            this.tbxExistencias.ReadOnly = true;
            this.tbxExistencias.Size = new System.Drawing.Size(104, 23);
            this.tbxExistencias.TabIndex = 182;
            this.tbxExistencias.Visible = false;
            // 
            // lblExistencias
            // 
            this.lblExistencias.AutoSize = true;
            this.lblExistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblExistencias.Location = new System.Drawing.Point(287, 156);
            this.lblExistencias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExistencias.Name = "lblExistencias";
            this.lblExistencias.Size = new System.Drawing.Size(86, 17);
            this.lblExistencias.TabIndex = 183;
            this.lblExistencias.Text = "Existencia:";
            this.lblExistencias.Visible = false;
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
            // tbxFolioDE
            // 
            this.tbxFolioDE.Location = new System.Drawing.Point(557, 59);
            this.tbxFolioDE.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFolioDE.MaxLength = 100;
            this.tbxFolioDE.Name = "tbxFolioDE";
            this.tbxFolioDE.ReadOnly = true;
            this.tbxFolioDE.Size = new System.Drawing.Size(106, 23);
            this.tbxFolioDE.TabIndex = 191;
            this.tbxFolioDE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigen.Location = new System.Drawing.Point(329, 62);
            this.lblOrigen.Margin = new System.Windows.Forms.Padding(4);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(58, 16);
            this.lblOrigen.TabIndex = 194;
            this.lblOrigen.Text = "Origen:";
            this.lblOrigen.Visible = false;
            // 
            // cbxAlmacen
            // 
            this.cbxAlmacen.DisplayMember = "id";
            this.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlmacen.FormattingEnabled = true;
            this.cbxAlmacen.Location = new System.Drawing.Point(395, 59);
            this.cbxAlmacen.Margin = new System.Windows.Forms.Padding(4);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.Size = new System.Drawing.Size(93, 24);
            this.cbxAlmacen.TabIndex = 193;
            this.cbxAlmacen.ValueMember = "id";
            this.cbxAlmacen.Visible = false;
            this.cbxAlmacen.SelectedIndexChanged += new System.EventHandler(this.cbxAlmacen_SelectedIndexChanged);
            // 
            // chkImprimir
            // 
            this.chkImprimir.AutoSize = true;
            this.chkImprimir.Location = new System.Drawing.Point(549, 421);
            this.chkImprimir.Name = "chkImprimir";
            this.chkImprimir.Size = new System.Drawing.Size(78, 21);
            this.chkImprimir.TabIndex = 218;
            this.chkImprimir.Text = "Sin total";
            this.chkImprimir.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(469, 422);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 217;
            this.label8.Text = "Impresión:";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolio.Location = new System.Drawing.Point(502, 62);
            this.lblFolio.Margin = new System.Windows.Forms.Padding(4);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(47, 16);
            this.lblFolio.TabIndex = 219;
            this.lblFolio.Text = "Folio:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(202, 12);
            this.label15.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(286, 24);
            this.label15.TabIndex = 246;
            this.label15.Text = "ENTRADAS DE INVENTARIO";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(634, 421);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(40, 40);
            this.btnGuardar.TabIndex = 216;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCambiarVendedor
            // 
            this.btnCambiarVendedor.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCambiarVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarVendedor.Enabled = false;
            this.btnCambiarVendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarVendedor.Location = new System.Drawing.Point(505, 86);
            this.btnCambiarVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiarVendedor.Name = "btnCambiarVendedor";
            this.btnCambiarVendedor.Size = new System.Drawing.Size(30, 30);
            this.btnCambiarVendedor.TabIndex = 181;
            this.btnCambiarVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarVendedor.UseVisualStyleBackColor = true;
            this.btnCambiarVendedor.Click += new System.EventHandler(this.btnCambiarVendedor_Click);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Enabled = false;
            this.btnSV.Location = new System.Drawing.Point(210, 86);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 180;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = global::Diprolim.Properties.Resources.delete;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(249, 149);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(30, 30);
            this.btnEliminar.TabIndex = 100;
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Location = new System.Drawing.Point(211, 118);
            this.btnSP.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 89;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Diprolim.Properties.Resources.plus;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(211, 149);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(333, 416);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 247;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CheckE
            // 
            this.CheckE.HeaderText = "";
            this.CheckE.Name = "CheckE";
            this.CheckE.Width = 30;
            // 
            // codigoE
            // 
            this.codigoE.HeaderText = "Código";
            this.codigoE.Name = "codigoE";
            this.codigoE.ReadOnly = true;
            this.codigoE.Width = 80;
            // 
            // desE
            // 
            this.desE.HeaderText = "Descripción";
            this.desE.Name = "desE";
            this.desE.ReadOnly = true;
            this.desE.Width = 300;
            // 
            // cantidadE
            // 
            this.cantidadE.HeaderText = "Cantidad";
            this.cantidadE.Name = "cantidadE";
            this.cantidadE.ReadOnly = true;
            this.cantidadE.Width = 80;
            // 
            // totalE
            // 
            this.totalE.HeaderText = "Total";
            this.totalE.Name = "totalE";
            this.totalE.ReadOnly = true;
            this.totalE.Width = 80;
            // 
            // a
            // 
            this.a.HeaderText = "anterior";
            this.a.Name = "a";
            this.a.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Visible = false;
            // 
            // colDevInicial
            // 
            this.colDevInicial.HeaderText = "Cantidad Dev inicial vendedor";
            this.colDevInicial.Name = "colDevInicial";
            this.colDevInicial.Visible = false;
            // 
            // colDescripcionID
            // 
            this.colDescripcionID.HeaderText = "DescripcionID";
            this.colDescripcionID.Name = "colDescripcionID";
            this.colDescripcionID.ReadOnly = true;
            this.colDescripcionID.Visible = false;
            // 
            // colValorMedida
            // 
            this.colValorMedida.HeaderText = "ValorMedida";
            this.colValorMedida.Name = "colValorMedida";
            this.colValorMedida.Visible = false;
            // 
            // colDescripcionGeneral
            // 
            this.colDescripcionGeneral.HeaderText = "DescripcionGeneral";
            this.colDescripcionGeneral.Name = "colDescripcionGeneral";
            this.colDescripcionGeneral.Visible = false;
            // 
            // Capturar_Entrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(687, 474);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblFolio);
            this.Controls.Add(this.chkImprimir);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.cbxAlmacen);
            this.Controls.Add(this.tbxFolioDE);
            this.Controls.Add(this.lblExistencias);
            this.Controls.Add(this.tbxExistencias);
            this.Controls.Add(this.btnCambiarVendedor);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.tbxComentarios);
            this.Controls.Add(this.lblComentarios);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.cbxMotivo);
            this.Controls.Add(this.Tabla);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.tbxNProducto);
            this.Controls.Add(this.tbxProducto);
            this.Controls.Add(this.lblCodigo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Capturar_Entrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capturar entrada a inventario sucursal";
            this.Load += new System.EventHandler(this.Capturar_Entrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox tbxProducto;
        private System.Windows.Forms.TextBox tbxNProducto;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView Tabla;
        private System.Windows.Forms.TextBox tbxComentarios;
        private System.Windows.Forms.Label lblComentarios;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.ComboBox cbxMotivo;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnCambiarVendedor;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.TextBox tbxExistencias;
        private System.Windows.Forms.Label lblExistencias;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.TextBox tbxFolioDE;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.ComboBox cbxAlmacen;
        private System.Windows.Forms.CheckBox chkImprimir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckE;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoE;
        private System.Windows.Forms.DataGridViewTextBoxColumn desE;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadE;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalE;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionGeneral;
    }
}