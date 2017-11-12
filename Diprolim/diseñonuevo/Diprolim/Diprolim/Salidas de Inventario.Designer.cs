namespace Diprolim
{
    partial class Salidas_de_Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Salidas_de_Inventario));
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxProducto = new System.Windows.Forms.TextBox();
            this.cbxMotivo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxComentarios = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxExistencias = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tbxFolio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.CheckE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codigoE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnAC = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 152;
            this.label2.Text = "Cantidad:";
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.Location = new System.Drawing.Point(170, 150);
            this.tbxCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCantidad.MaxLength = 9;
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.Size = new System.Drawing.Size(87, 23);
            this.tbxCantidad.TabIndex = 4;
            this.tbxCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCantidad_KeyDown);
            this.tbxCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidad_KeyPress);
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(303, 119);
            this.tbxNombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.ReadOnly = true;
            this.tbxNombre.Size = new System.Drawing.Size(342, 23);
            this.tbxNombre.TabIndex = 149;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 16);
            this.label4.TabIndex = 148;
            this.label4.Text = "Código de producto:";
            // 
            // tbxProducto
            // 
            this.tbxProducto.Location = new System.Drawing.Point(170, 119);
            this.tbxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProducto.MaxLength = 9;
            this.tbxProducto.Name = "tbxProducto";
            this.tbxProducto.Size = new System.Drawing.Size(87, 23);
            this.tbxProducto.TabIndex = 3;
            this.tbxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxProducto_KeyDown);
            this.tbxProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxProducto_KeyPress);
            this.tbxProducto.Leave += new System.EventHandler(this.tbxProducto_Leave);
            // 
            // cbxMotivo
            // 
            this.cbxMotivo.DisplayMember = "id";
            this.cbxMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMotivo.FormattingEnabled = true;
            this.cbxMotivo.Items.AddRange(new object[] {
            "Transferencia",
            "Obsequio",
            "Consumo Interno",
            "Otros"});
            this.cbxMotivo.Location = new System.Drawing.Point(170, 87);
            this.cbxMotivo.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMotivo.Name = "cbxMotivo";
            this.cbxMotivo.Size = new System.Drawing.Size(125, 24);
            this.cbxMotivo.TabIndex = 1;
            this.cbxMotivo.ValueMember = "id";
            this.cbxMotivo.SelectedIndexChanged += new System.EventHandler(this.cbxMotivo_SelectedIndexChanged);
            this.cbxMotivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxMotivo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 159;
            this.label1.Text = "Motivo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 375);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 160;
            this.label3.Text = "Comentarios:";
            // 
            // tbxComentarios
            // 
            this.tbxComentarios.Location = new System.Drawing.Point(138, 372);
            this.tbxComentarios.Margin = new System.Windows.Forms.Padding(4);
            this.tbxComentarios.MaxLength = 199;
            this.tbxComentarios.Name = "tbxComentarios";
            this.tbxComentarios.Size = new System.Drawing.Size(507, 23);
            this.tbxComentarios.TabIndex = 5;
            this.tbxComentarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxComentarios_KeyDown);
            this.tbxComentarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxComentarios_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(341, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 163;
            this.label5.Text = "Existencias:";
            // 
            // tbxExistencias
            // 
            this.tbxExistencias.Location = new System.Drawing.Point(433, 150);
            this.tbxExistencias.Margin = new System.Windows.Forms.Padding(4);
            this.tbxExistencias.Name = "tbxExistencias";
            this.tbxExistencias.ReadOnly = true;
            this.tbxExistencias.Size = new System.Drawing.Size(98, 23);
            this.tbxExistencias.TabIndex = 162;
            this.tbxExistencias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxExistencias_KeyPress);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(548, 15);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(97, 23);
            this.dtpFecha.TabIndex = 164;
            this.dtpFecha.Value = new System.DateTime(2014, 2, 2, 0, 0, 0, 0);
            // 
            // tbxFolio
            // 
            this.tbxFolio.BackColor = System.Drawing.SystemColors.Control;
            this.tbxFolio.Location = new System.Drawing.Point(539, 43);
            this.tbxFolio.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFolio.MaxLength = 100;
            this.tbxFolio.Name = "tbxFolio";
            this.tbxFolio.ReadOnly = true;
            this.tbxFolio.Size = new System.Drawing.Size(106, 23);
            this.tbxFolio.TabIndex = 165;
            this.tbxFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(303, 90);
            this.label7.Margin = new System.Windows.Forms.Padding(4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 168;
            this.label7.Text = "Destino:";
            this.label7.Visible = false;
            // 
            // cbxAlmacen
            // 
            this.cbxAlmacen.DisplayMember = "id";
            this.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlmacen.FormattingEnabled = true;
            this.cbxAlmacen.Location = new System.Drawing.Point(383, 87);
            this.cbxAlmacen.Margin = new System.Windows.Forms.Padding(4);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.Size = new System.Drawing.Size(93, 24);
            this.cbxAlmacen.TabIndex = 2;
            this.cbxAlmacen.ValueMember = "id";
            this.cbxAlmacen.Visible = false;
            this.cbxAlmacen.SelectedIndexChanged += new System.EventHandler(this.cbxAlmacen_SelectedIndexChanged);
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
            this.Ex});
            this.Tabla.Location = new System.Drawing.Point(34, 180);
            this.Tabla.Name = "Tabla";
            this.Tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tabla.Size = new System.Drawing.Size(611, 185);
            this.Tabla.TabIndex = 169;
            this.Tabla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tabla_CellContentClick);
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
            this.desE.Width = 310;
            // 
            // cantidadE
            // 
            this.cantidadE.HeaderText = "Cantidad";
            this.cantidadE.Name = "cantidadE";
            this.cantidadE.ReadOnly = true;
            this.cantidadE.Width = 80;
            // 
            // Ex
            // 
            this.Ex.HeaderText = "Existencias";
            this.Ex.Name = "Ex";
            this.Ex.Visible = false;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Diprolim.Properties.Resources.plus;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(265, 146);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Diprolim.Properties.Resources.delete;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(303, 146);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 170;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Location = new System.Drawing.Point(265, 115);
            this.btnSP.Margin = new System.Windows.Forms.Padding(4);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 150;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
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
            // btnAC
            // 
            this.btnAC.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnAC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAC.Location = new System.Drawing.Point(605, 403);
            this.btnAC.Margin = new System.Windows.Forms.Padding(4);
            this.btnAC.Name = "btnAC";
            this.btnAC.Size = new System.Drawing.Size(40, 40);
            this.btnAC.TabIndex = 217;
            this.btnAC.UseVisualStyleBackColor = true;
            this.btnAC.Click += new System.EventHandler(this.btnAC_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(484, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 218;
            this.label6.Text = "Folio:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(217, 9);
            this.label15.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(259, 24);
            this.label15.TabIndex = 246;
            this.label15.Text = "SALIDAS DE INVENTARIO";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Salidas_de_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(684, 449);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAC);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Tabla);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxAlmacen);
            this.Controls.Add(this.tbxFolio);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxExistencias);
            this.Controls.Add(this.tbxComentarios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxMotivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCantidad);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxProducto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Salidas_de_Inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salidas Especiales";
            this.Load += new System.EventHandler(this.Salidas_de_Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxProducto;
        private System.Windows.Forms.ComboBox cbxMotivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxComentarios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxExistencias;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox tbxFolio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxAlmacen;
        private System.Windows.Forms.DataGridView Tabla;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckE;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoE;
        private System.Windows.Forms.DataGridViewTextBoxColumn desE;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ex;
        private System.Windows.Forms.Button btnAC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
    }
}