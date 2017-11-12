namespace Diprolim
{
    partial class ConsultaCancelaVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtgPProductos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tblCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbltipoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblTipoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblfecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idventas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxNCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.tbxNProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxProducto = new System.Windows.Forms.TextBox();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDepto = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxTipoVenta = new System.Windows.Forms.ComboBox();
            this.rbtnProductos = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.rbtnClientes = new System.Windows.Forms.RadioButton();
            this.dtgPClientes = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClienteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnSC = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.btnSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "d/M/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(582, 15);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 23);
            this.dtpFecha.TabIndex = 131;
            this.dtpFecha.Value = new System.DateTime(2013, 12, 24, 16, 17, 5, 0);
            // 
            // dtgPProductos
            // 
            this.dtgPProductos.AllowUserToAddRows = false;
            this.dtgPProductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtgPProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.tblCodigo,
            this.tblVendedor,
            this.tbltipoCliente,
            this.tblTipoVenta,
            this.tblProducto,
            this.tblPrecio,
            this.tblCantidad,
            this.tblTotal,
            this.tblComision,
            this.id_empleado,
            this.tblfecha,
            this.idventas});
            this.dtgPProductos.Location = new System.Drawing.Point(13, 155);
            this.dtgPProductos.Margin = new System.Windows.Forms.Padding(4);
            this.dtgPProductos.Name = "dtgPProductos";
            this.dtgPProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPProductos.Size = new System.Drawing.Size(1161, 342);
            this.dtgPProductos.TabIndex = 132;
            this.dtgPProductos.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.tblReporteV_SortCompare);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // tblCodigo
            // 
            this.tblCodigo.HeaderText = "Código articulo";
            this.tblCodigo.Name = "tblCodigo";
            this.tblCodigo.ReadOnly = true;
            this.tblCodigo.Width = 80;
            // 
            // tblVendedor
            // 
            this.tblVendedor.HeaderText = "Vendedor";
            this.tblVendedor.Name = "tblVendedor";
            this.tblVendedor.ReadOnly = true;
            this.tblVendedor.Width = 90;
            // 
            // tbltipoCliente
            // 
            this.tbltipoCliente.HeaderText = "Tipo cliente";
            this.tbltipoCliente.Name = "tbltipoCliente";
            this.tbltipoCliente.ReadOnly = true;
            this.tbltipoCliente.Width = 90;
            // 
            // tblTipoVenta
            // 
            this.tblTipoVenta.HeaderText = "Tipo venta";
            this.tblTipoVenta.Name = "tblTipoVenta";
            this.tblTipoVenta.ReadOnly = true;
            this.tblTipoVenta.Width = 80;
            // 
            // tblProducto
            // 
            this.tblProducto.HeaderText = "Producto";
            this.tblProducto.Name = "tblProducto";
            this.tblProducto.ReadOnly = true;
            this.tblProducto.Width = 300;
            // 
            // tblPrecio
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.tblPrecio.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblPrecio.HeaderText = "Precio venta";
            this.tblPrecio.Name = "tblPrecio";
            this.tblPrecio.ReadOnly = true;
            this.tblPrecio.Width = 90;
            // 
            // tblCantidad
            // 
            this.tblCantidad.HeaderText = "Unidades vendidas";
            this.tblCantidad.Name = "tblCantidad";
            this.tblCantidad.ReadOnly = true;
            // 
            // tblTotal
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.tblTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblTotal.HeaderText = "Total";
            this.tblTotal.Name = "tblTotal";
            this.tblTotal.ReadOnly = true;
            this.tblTotal.Width = 110;
            // 
            // tblComision
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.tblComision.DefaultCellStyle = dataGridViewCellStyle4;
            this.tblComision.HeaderText = "Comisión";
            this.tblComision.Name = "tblComision";
            this.tblComision.ReadOnly = true;
            this.tblComision.Width = 90;
            // 
            // id_empleado
            // 
            this.id_empleado.HeaderText = "id_empleado";
            this.id_empleado.Name = "id_empleado";
            this.id_empleado.Visible = false;
            this.id_empleado.Width = 50;
            // 
            // tblfecha
            // 
            this.tblfecha.HeaderText = "fecha";
            this.tblfecha.Name = "tblfecha";
            this.tblfecha.Visible = false;
            this.tblfecha.Width = 50;
            // 
            // idventas
            // 
            this.idventas.HeaderText = "idventas";
            this.idventas.Name = "idventas";
            this.idventas.Visible = false;
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(119, 110);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(132, 24);
            this.cbxCategoria.TabIndex = 146;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(13, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 145;
            this.label5.Text = "Tipo cliente:";
            // 
            // tbxNCliente
            // 
            this.tbxNCliente.Location = new System.Drawing.Point(260, 48);
            this.tbxNCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNCliente.Name = "tbxNCliente";
            this.tbxNCliente.ReadOnly = true;
            this.tbxNCliente.Size = new System.Drawing.Size(248, 23);
            this.tbxNCliente.TabIndex = 143;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(48, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 142;
            this.label4.Text = "Cliente:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Location = new System.Drawing.Point(119, 48);
            this.tbxCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(93, 23);
            this.tbxCliente.TabIndex = 1;
            this.tbxCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCliente_KeyDown);
            this.tbxCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCliente_KeyPress);
            // 
            // tbxNProducto
            // 
            this.tbxNProducto.Location = new System.Drawing.Point(260, 79);
            this.tbxNProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNProducto.Name = "tbxNProducto";
            this.tbxNProducto.ReadOnly = true;
            this.tbxNProducto.Size = new System.Drawing.Size(248, 23);
            this.tbxNProducto.TabIndex = 139;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(33, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 138;
            this.label1.Text = "Producto:";
            // 
            // tbxProducto
            // 
            this.tbxProducto.Location = new System.Drawing.Point(119, 79);
            this.tbxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProducto.Name = "tbxProducto";
            this.tbxProducto.Size = new System.Drawing.Size(93, 23);
            this.tbxProducto.TabIndex = 2;
            this.tbxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxProducto_KeyDown);
            this.tbxProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxProducto_KeyPress);
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Location = new System.Drawing.Point(260, 17);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(248, 23);
            this.tbxNVendedor.TabIndex = 135;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(28, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 134;
            this.label3.Text = "Vendedor:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Location = new System.Drawing.Point(119, 17);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.ReadOnly = true;
            this.tbxVendedor.Size = new System.Drawing.Size(93, 23);
            this.tbxVendedor.TabIndex = 133;
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(516, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 147;
            this.label2.Text = "Fecha:";
            // 
            // cbxDepto
            // 
            this.cbxDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepto.FormattingEnabled = true;
            this.cbxDepto.Items.AddRange(new object[] {
            "Todos",
            "Productos",
            "Accesorios",
            "Papel"});
            this.cbxDepto.Location = new System.Drawing.Point(380, 110);
            this.cbxDepto.Name = "cbxDepto";
            this.cbxDepto.Size = new System.Drawing.Size(132, 24);
            this.cbxDepto.TabIndex = 153;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(258, 113);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 17);
            this.label7.TabIndex = 152;
            this.label7.Text = "Departamento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(516, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 154;
            this.label6.Text = "Tipo venta:";
            // 
            // cbxTipoVenta
            // 
            this.cbxTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoVenta.FormattingEnabled = true;
            this.cbxTipoVenta.Items.AddRange(new object[] {
            "Todos",
            "Contado",
            "Crédito",
            "Consignación"});
            this.cbxTipoVenta.Location = new System.Drawing.Point(613, 110);
            this.cbxTipoVenta.Name = "cbxTipoVenta";
            this.cbxTipoVenta.Size = new System.Drawing.Size(132, 24);
            this.cbxTipoVenta.TabIndex = 155;
            // 
            // rbtnProductos
            // 
            this.rbtnProductos.AutoSize = true;
            this.rbtnProductos.Checked = true;
            this.rbtnProductos.Location = new System.Drawing.Point(582, 49);
            this.rbtnProductos.Name = "rbtnProductos";
            this.rbtnProductos.Size = new System.Drawing.Size(90, 21);
            this.rbtnProductos.TabIndex = 156;
            this.rbtnProductos.TabStop = true;
            this.rbtnProductos.Text = "Productos";
            this.rbtnProductos.UseVisualStyleBackColor = true;
            this.rbtnProductos.CheckedChanged += new System.EventHandler(this.rbtnProductos_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(516, 50);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 17);
            this.label8.TabIndex = 157;
            this.label8.Text = "Por:";
            // 
            // rbtnClientes
            // 
            this.rbtnClientes.AutoSize = true;
            this.rbtnClientes.Location = new System.Drawing.Point(678, 48);
            this.rbtnClientes.Name = "rbtnClientes";
            this.rbtnClientes.Size = new System.Drawing.Size(76, 21);
            this.rbtnClientes.TabIndex = 158;
            this.rbtnClientes.Text = "Clientes";
            this.rbtnClientes.UseVisualStyleBackColor = true;
            this.rbtnClientes.CheckedChanged += new System.EventHandler(this.rbtnClientes_CheckedChanged);
            // 
            // dtgPClientes
            // 
            this.dtgPClientes.AllowUserToAddRows = false;
            this.dtgPClientes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtgPClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgPClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.colTotal,
            this.colTipoVenta,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn10,
            this.colClienteID});
            this.dtgPClientes.Location = new System.Drawing.Point(13, 155);
            this.dtgPClientes.Margin = new System.Windows.Forms.Padding(4);
            this.dtgPClientes.Name = "dtgPClientes";
            this.dtgPClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPClientes.Size = new System.Drawing.Size(1161, 342);
            this.dtgPClientes.TabIndex = 159;
            this.dtgPClientes.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dtgPClientes_SortCompare);
            this.dtgPClientes.DoubleClick += new System.EventHandler(this.dtgPClientes_DoubleClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Vendedor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tipo cliente";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 300;
            // 
            // colTotal
            // 
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 110;
            // 
            // colTipoVenta
            // 
            this.colTipoVenta.HeaderText = "Tipo venta";
            this.colTipoVenta.Name = "colTipoVenta";
            this.colTipoVenta.ReadOnly = true;
            this.colTipoVenta.Width = 90;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewCellStyle7.Format = "G";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn11.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 180;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "EmpleadoID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 50;
            // 
            // colClienteID
            // 
            this.colClienteID.HeaderText = "ClienteID";
            this.colClienteID.Name = "colClienteID";
            this.colClienteID.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(800, 101);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(74, 40);
            this.btnEliminar.TabIndex = 151;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.BackgroundImage = global::Diprolim.Properties.Resources.search_page64;
            this.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporte.Location = new System.Drawing.Point(752, 101);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(40, 40);
            this.btnReporte.TabIndex = 148;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnSC
            // 
            this.btnSC.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSC.Location = new System.Drawing.Point(221, 43);
            this.btnSC.Margin = new System.Windows.Forms.Padding(5);
            this.btnSC.Name = "btnSC";
            this.btnSC.Size = new System.Drawing.Size(30, 30);
            this.btnSC.TabIndex = 144;
            this.btnSC.UseVisualStyleBackColor = true;
            this.btnSC.Click += new System.EventHandler(this.btnSC_Click);
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Location = new System.Drawing.Point(221, 75);
            this.btnSP.Margin = new System.Windows.Forms.Padding(5);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 140;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // btnSV
            // 
            this.btnSV.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSV.Enabled = false;
            this.btnSV.Location = new System.Drawing.Point(221, 13);
            this.btnSV.Margin = new System.Windows.Forms.Padding(5);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(30, 30);
            this.btnSV.TabIndex = 136;
            this.btnSV.UseVisualStyleBackColor = true;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // ConsultaCancelaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1187, 523);
            this.Controls.Add(this.rbtnClientes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rbtnProductos);
            this.Controls.Add(this.cbxTipoVenta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxDepto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCategoria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSC);
            this.Controls.Add(this.tbxNCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxCliente);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.tbxNProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxProducto);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.dtgPProductos);
            this.Controls.Add(this.dtgPClientes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultaCancelaVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas y cancelaciones de ventas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConsultaCancelaVentas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView dtgPProductos;
        private System.Windows.Forms.ComboBox cbxCategoria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSC;
        private System.Windows.Forms.TextBox tbxNCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.TextBox tbxNProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxProducto;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cbxDepto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxTipoVenta;
        private System.Windows.Forms.RadioButton rbtnProductos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbtnClientes;
        private System.Windows.Forms.DataGridView dtgPClientes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClienteID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbltipoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblTipoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblComision;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblfecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn idventas;
    }
}