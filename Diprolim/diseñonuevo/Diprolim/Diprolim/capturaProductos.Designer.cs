namespace Diprolim
{
    partial class capturaProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(capturaProductos));
            this.cbxUMedida = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPrecioProduccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDesc = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxVMedida = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPCalle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxPAbarrotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxPDistribuidor = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.rbProductos = new System.Windows.Forms.RadioButton();
            this.rbAccesorios = new System.Windows.Forms.RadioButton();
            this.rbPapel = new System.Windows.Forms.RadioButton();
            this.tbxDescuento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxComision = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxUMedida
            // 
            this.cbxUMedida.DisplayMember = "id";
            this.cbxUMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUMedida.FormattingEnabled = true;
            this.cbxUMedida.Location = new System.Drawing.Point(195, 69);
            this.cbxUMedida.Name = "cbxUMedida";
            this.cbxUMedida.Size = new System.Drawing.Size(159, 24);
            this.cbxUMedida.TabIndex = 3;
            this.cbxUMedida.ValueMember = "id";
            this.cbxUMedida.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxUMedida_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Unidad de Medida:";
            // 
            // tbxPrecioProduccion
            // 
            this.tbxPrecioProduccion.Location = new System.Drawing.Point(195, 102);
            this.tbxPrecioProduccion.Name = "tbxPrecioProduccion";
            this.tbxPrecioProduccion.Size = new System.Drawing.Size(118, 23);
            this.tbxPrecioProduccion.TabIndex = 4;
            this.tbxPrecioProduccion.Tag = "";
            this.tbxPrecioProduccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPrecioProduccion_KeyDown);
            this.tbxPrecioProduccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPrecioProduccion_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Precio de Producción: $";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción:";
            // 
            // tbxDesc
            // 
            this.tbxDesc.Location = new System.Drawing.Point(195, 3);
            this.tbxDesc.Name = "tbxDesc";
            this.tbxDesc.Size = new System.Drawing.Size(159, 23);
            this.tbxDesc.TabIndex = 1;
            this.tbxDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDesc_KeyDown);
            this.tbxDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxDesc_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.4819F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.5181F));
            this.tableLayoutPanel1.Controls.Add(this.tbxDesc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbxPrecioProduccion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxUMedida, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxVMedida, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(359, 132);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tbxVMedida
            // 
            this.tbxVMedida.Location = new System.Drawing.Point(195, 36);
            this.tbxVMedida.Name = "tbxVMedida";
            this.tbxVMedida.Size = new System.Drawing.Size(159, 23);
            this.tbxVMedida.TabIndex = 2;
            this.tbxVMedida.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVMedida_KeyDown_1);
            this.tbxVMedida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVMedida_KeyPress_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Valor de medida:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(214, 345);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(85, 39);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.Location = new System.Drawing.Point(305, 345);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 39);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Precio de calle:          $";
            // 
            // tbxPCalle
            // 
            this.tbxPCalle.Location = new System.Drawing.Point(195, 3);
            this.tbxPCalle.Name = "tbxPCalle";
            this.tbxPCalle.Size = new System.Drawing.Size(118, 23);
            this.tbxPCalle.TabIndex = 6;
            this.tbxPCalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPCalle_KeyDown);
            this.tbxPCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPCalle_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Precio abarrotes:       $";
            // 
            // tbxPAbarrotes
            // 
            this.tbxPAbarrotes.Location = new System.Drawing.Point(195, 32);
            this.tbxPAbarrotes.Name = "tbxPAbarrotes";
            this.tbxPAbarrotes.Size = new System.Drawing.Size(118, 23);
            this.tbxPAbarrotes.TabIndex = 7;
            this.tbxPAbarrotes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPAbarrotes_KeyDown);
            this.tbxPAbarrotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPAbarrotes_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Precio distribuidores: $";
            // 
            // tbxPDistribuidor
            // 
            this.tbxPDistribuidor.Location = new System.Drawing.Point(195, 61);
            this.tbxPDistribuidor.Name = "tbxPDistribuidor";
            this.tbxPDistribuidor.Size = new System.Drawing.Size(118, 23);
            this.tbxPDistribuidor.TabIndex = 8;
            this.tbxPDistribuidor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPDistribuidor_KeyDown);
            this.tbxPDistribuidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPDistribuidor_KeyPress);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.4819F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.5181F));
            this.tableLayoutPanel2.Controls.Add(this.tbxPCalle, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbxPDistribuidor, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbxPAbarrotes, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 175);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(359, 88);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Departamento:";
            // 
            // rbProductos
            // 
            this.rbProductos.AutoSize = true;
            this.rbProductos.Checked = true;
            this.rbProductos.Location = new System.Drawing.Point(180, 148);
            this.rbProductos.Name = "rbProductos";
            this.rbProductos.Size = new System.Drawing.Size(90, 21);
            this.rbProductos.TabIndex = 5;
            this.rbProductos.TabStop = true;
            this.rbProductos.Text = "Productos";
            this.rbProductos.UseVisualStyleBackColor = true;
            // 
            // rbAccesorios
            // 
            this.rbAccesorios.AutoSize = true;
            this.rbAccesorios.Location = new System.Drawing.Point(276, 148);
            this.rbAccesorios.Name = "rbAccesorios";
            this.rbAccesorios.Size = new System.Drawing.Size(95, 21);
            this.rbAccesorios.TabIndex = 5;
            this.rbAccesorios.Text = "Accesorios";
            this.rbAccesorios.UseVisualStyleBackColor = true;
            // 
            // rbPapel
            // 
            this.rbPapel.AutoSize = true;
            this.rbPapel.Location = new System.Drawing.Point(377, 148);
            this.rbPapel.Name = "rbPapel";
            this.rbPapel.Size = new System.Drawing.Size(62, 21);
            this.rbPapel.TabIndex = 5;
            this.rbPapel.Text = "Papel";
            this.rbPapel.UseVisualStyleBackColor = true;
            // 
            // tbxDescuento
            // 
            this.tbxDescuento.Location = new System.Drawing.Point(214, 272);
            this.tbxDescuento.Name = "tbxDescuento";
            this.tbxDescuento.Size = new System.Drawing.Size(111, 23);
            this.tbxDescuento.TabIndex = 18;
            this.tbxDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDescuento_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Descuento/Contado      %";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 304);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Comisión/Consignación %";
            // 
            // tbxComision
            // 
            this.tbxComision.Location = new System.Drawing.Point(214, 304);
            this.tbxComision.Name = "tbxComision";
            this.tbxComision.Size = new System.Drawing.Size(111, 23);
            this.tbxComision.TabIndex = 20;
            this.tbxComision.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxComision_KeyDown);
            this.tbxComision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxComision_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Diprolim.Properties.Resources.dIPROLIMa;
            this.pictureBox1.Location = new System.Drawing.Point(-75, 390);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(590, 28);
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            // 
            // capturaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(446, 413);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbxComision);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbxDescuento);
            this.Controls.Add(this.rbPapel);
            this.Controls.Add(this.rbAccesorios);
            this.Controls.Add(this.rbProductos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "capturaProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captura nuevo producto";
            this.Load += new System.EventHandler(this.capturaProductos_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxUMedida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPrecioProduccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDesc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbxVMedida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPCalle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxPAbarrotes;
        private System.Windows.Forms.TextBox tbxPDistribuidor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbProductos;
        private System.Windows.Forms.RadioButton rbAccesorios;
        private System.Windows.Forms.RadioButton rbPapel;
        private System.Windows.Forms.TextBox tbxDescuento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxComision;
        private System.Windows.Forms.PictureBox pictureBox1;


    }
}