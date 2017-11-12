namespace Diprolim
{
    partial class Cobranza
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.tbxRecuperado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.tbxNCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.tbxFiado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tblVLcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descipcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vsCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.Dias = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnR = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAC = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNVendedor.Location = new System.Drawing.Point(273, 60);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(5);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(337, 22);
            this.tbxNVendedor.TabIndex = 110;
            // 
            // tbxRecuperado
            // 
            this.tbxRecuperado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRecuperado.Location = new System.Drawing.Point(127, 123);
            this.tbxRecuperado.Margin = new System.Windows.Forms.Padding(5);
            this.tbxRecuperado.MaxLength = 20;
            this.tbxRecuperado.Name = "tbxRecuperado";
            this.tbxRecuperado.Size = new System.Drawing.Size(93, 22);
            this.tbxRecuperado.TabIndex = 3;
            this.tbxRecuperado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxRecuperado_KeyDown);
            this.tbxRecuperado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxRecuperado_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 127);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 109;
            this.label7.Text = "Recuperado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 108;
            this.label4.Text = "Vendedor:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxVendedor.Location = new System.Drawing.Point(127, 60);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(5);
            this.tbxVendedor.MaxLength = 9;
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(93, 22);
            this.tbxVendedor.TabIndex = 1;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            // 
            // tbxNCliente
            // 
            this.tbxNCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNCliente.Location = new System.Drawing.Point(273, 92);
            this.tbxNCliente.Margin = new System.Windows.Forms.Padding(5);
            this.tbxNCliente.Name = "tbxNCliente";
            this.tbxNCliente.ReadOnly = true;
            this.tbxNCliente.Size = new System.Drawing.Size(337, 22);
            this.tbxNCliente.TabIndex = 172;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 171;
            this.label1.Text = "Cliente:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCliente.Location = new System.Drawing.Point(127, 92);
            this.tbxCliente.Margin = new System.Windows.Forms.Padding(5);
            this.tbxCliente.MaxLength = 9;
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(94, 22);
            this.tbxCliente.TabIndex = 2;
            this.tbxCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCliente_KeyDown);
            this.tbxCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCliente_KeyPress);
            // 
            // tbxFiado
            // 
            this.tbxFiado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFiado.Location = new System.Drawing.Point(295, 123);
            this.tbxFiado.Margin = new System.Windows.Forms.Padding(5);
            this.tbxFiado.MaxLength = 20;
            this.tbxFiado.Name = "tbxFiado";
            this.tbxFiado.ReadOnly = true;
            this.tbxFiado.Size = new System.Drawing.Size(93, 22);
            this.tbxFiado.TabIndex = 4;
            this.tbxFiado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFiado_KeyDown);
            this.tbxFiado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxFiado_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 175;
            this.label2.Text = "Fiado:";
            // 
            // Tabla
            // 
            this.Tabla.AllowUserToAddRows = false;
            this.Tabla.AllowUserToDeleteRows = false;
            this.Tabla.AllowUserToResizeColumns = false;
            this.Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.tblVLcodigo,
            this.Descipcion,
            this.Preci,
            this.vsCantidad,
            this.Total});
            this.Tabla.Location = new System.Drawing.Point(13, 161);
            this.Tabla.Margin = new System.Windows.Forms.Padding(4);
            this.Tabla.Name = "Tabla";
            this.Tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tabla.Size = new System.Drawing.Size(637, 127);
            this.Tabla.TabIndex = 177;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 20;
            // 
            // tblVLcodigo
            // 
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.tblVLcodigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.tblVLcodigo.HeaderText = "Fecha";
            this.tblVLcodigo.Name = "tblVLcodigo";
            this.tblVLcodigo.ReadOnly = true;
            // 
            // Descipcion
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Descipcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Descipcion.HeaderText = "Adeudo";
            this.Descipcion.Name = "Descipcion";
            this.Descipcion.ReadOnly = true;
            this.Descipcion.Width = 150;
            // 
            // Preci
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Preci.DefaultCellStyle = dataGridViewCellStyle3;
            this.Preci.HeaderText = "Abono";
            this.Preci.Name = "Preci";
            this.Preci.ReadOnly = true;
            // 
            // vsCantidad
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.vsCantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.vsCantidad.HeaderText = "Fiado Nuevo";
            this.vsCantidad.Name = "vsCantidad";
            this.vsCantidad.ReadOnly = true;
            // 
            // Total
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            this.Total.HeaderText = "Pendiente";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(488, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 180;
            this.label5.Text = "Transcurrido:";
            // 
            // Dias
            // 
            this.Dias.AutoSize = true;
            this.Dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dias.Location = new System.Drawing.Point(610, 126);
            this.Dias.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Dias.Name = "Dias";
            this.Dias.Size = new System.Drawing.Size(0, 17);
            this.Dias.TabIndex = 181;
            // 
            // fecha
            // 
            this.fecha.CustomFormat = "dd/MMM/yyyy";
            this.fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecha.Location = new System.Drawing.Point(520, 13);
            this.fecha.Margin = new System.Windows.Forms.Padding(4);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(132, 22);
            this.fecha.TabIndex = 205;
            this.fecha.Value = new System.DateTime(2014, 3, 24, 0, 0, 0, 0);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnRegistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(605, 296);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(45, 45);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnR
            // 
            this.btnR.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnR.FlatAppearance.BorderSize = 0;
            this.btnR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnR.Location = new System.Drawing.Point(620, 87);
            this.btnR.Margin = new System.Windows.Forms.Padding(5);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(30, 30);
            this.btnR.TabIndex = 176;
            this.btnR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnR.UseVisualStyleBackColor = true;
            this.btnR.Click += new System.EventHandler(this.btnR_Click);
            // 
            // btnB
            // 
            this.btnB.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnB.Location = new System.Drawing.Point(233, 87);
            this.btnB.Margin = new System.Windows.Forms.Padding(5);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(30, 30);
            this.btnB.TabIndex = 173;
            this.btnB.UseVisualStyleBackColor = true;
            this.btnB.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(620, 55);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(30, 30);
            this.btnNuevo.TabIndex = 113;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = global::Diprolim.Properties.Resources.delete;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(443, 117);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(35, 35);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAC
            // 
            this.btnAC.BackgroundImage = global::Diprolim.Properties.Resources.plus;
            this.btnAC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAC.Location = new System.Drawing.Point(398, 117);
            this.btnAC.Margin = new System.Windows.Forms.Padding(5);
            this.btnAC.Name = "btnAC";
            this.btnAC.Size = new System.Drawing.Size(35, 35);
            this.btnAC.TabIndex = 5;
            this.btnAC.UseVisualStyleBackColor = true;
            this.btnAC.Click += new System.EventHandler(this.btnAC_Click);
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSP.Location = new System.Drawing.Point(233, 55);
            this.btnSP.Margin = new System.Windows.Forms.Padding(5);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 111;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(267, 12);
            this.label15.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 24);
            this.label15.TabIndex = 246;
            this.label15.Text = "COBRANZA";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Cobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(665, 354);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.Dias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Tabla);
            this.Controls.Add(this.btnR);
            this.Controls.Add(this.tbxFiado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.tbxNCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxCliente);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAC);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.tbxRecuperado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxVendedor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cobranza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobranza";
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAC;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.TextBox tbxRecuperado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.TextBox tbxNCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.TextBox tbxFiado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnR;
        private System.Windows.Forms.DataGridView Tabla;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Dias;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblVLcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descipcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preci;
        private System.Windows.Forms.DataGridViewTextBoxColumn vsCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Label label15;
    }
}