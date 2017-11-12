namespace Diprolim
{
    partial class Corte_de_Caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Corte_de_Caja));
            this.tbxNVendedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxVendedor = new System.Windows.Forms.TextBox();
            this.tbxVT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxRecuperado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxFiado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxGastos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxConcepto = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.tbxIva = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImprimirCr = new System.Windows.Forms.Button();
            this.btnRegistrarS = new System.Windows.Forms.Button();
            this.btnCambiarVendedor = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxNVendedor
            // 
            this.tbxNVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNVendedor.Location = new System.Drawing.Point(278, 54);
            this.tbxNVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNVendedor.Name = "tbxNVendedor";
            this.tbxNVendedor.ReadOnly = true;
            this.tbxNVendedor.Size = new System.Drawing.Size(375, 22);
            this.tbxNVendedor.TabIndex = 181;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 180;
            this.label1.Text = "Vendedor:";
            // 
            // tbxVendedor
            // 
            this.tbxVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxVendedor.Location = new System.Drawing.Point(147, 57);
            this.tbxVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVendedor.MaxLength = 20;
            this.tbxVendedor.Name = "tbxVendedor";
            this.tbxVendedor.Size = new System.Drawing.Size(85, 22);
            this.tbxVendedor.TabIndex = 0;
            this.tbxVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVendedor_KeyDown);
            this.tbxVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVendedor_KeyPress);
            // 
            // tbxVT
            // 
            this.tbxVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxVT.Location = new System.Drawing.Point(147, 87);
            this.tbxVT.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVT.MaxLength = 9;
            this.tbxVT.Name = "tbxVT";
            this.tbxVT.ReadOnly = true;
            this.tbxVT.Size = new System.Drawing.Size(123, 22);
            this.tbxVT.TabIndex = 176;
            this.tbxVT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxVT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxVT_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 90);
            this.label7.Margin = new System.Windows.Forms.Padding(4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 17);
            this.label7.TabIndex = 178;
            this.label7.Text = "Ventas Totales:";
            // 
            // tbxRecuperado
            // 
            this.tbxRecuperado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRecuperado.Location = new System.Drawing.Point(147, 147);
            this.tbxRecuperado.Margin = new System.Windows.Forms.Padding(4);
            this.tbxRecuperado.MaxLength = 9;
            this.tbxRecuperado.Name = "tbxRecuperado";
            this.tbxRecuperado.ReadOnly = true;
            this.tbxRecuperado.Size = new System.Drawing.Size(123, 22);
            this.tbxRecuperado.TabIndex = 189;
            this.tbxRecuperado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 190;
            this.label5.Text = "Recuperado:";
            // 
            // tbxFiado
            // 
            this.tbxFiado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFiado.Location = new System.Drawing.Point(147, 177);
            this.tbxFiado.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFiado.MaxLength = 9;
            this.tbxFiado.Name = "tbxFiado";
            this.tbxFiado.ReadOnly = true;
            this.tbxFiado.Size = new System.Drawing.Size(123, 22);
            this.tbxFiado.TabIndex = 191;
            this.tbxFiado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 180);
            this.label6.Margin = new System.Windows.Forms.Padding(4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 192;
            this.label6.Text = "Fiado:";
            // 
            // tbxGastos
            // 
            this.tbxGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGastos.Location = new System.Drawing.Point(147, 207);
            this.tbxGastos.Margin = new System.Windows.Forms.Padding(4);
            this.tbxGastos.MaxLength = 20;
            this.tbxGastos.Name = "tbxGastos";
            this.tbxGastos.Size = new System.Drawing.Size(123, 22);
            this.tbxGastos.TabIndex = 1;
            this.tbxGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxGastos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxGastos_KeyDown);
            this.tbxGastos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxGastos_KeyPress);
            this.tbxGastos.Leave += new System.EventHandler(this.tbxGastos_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 209);
            this.label8.Margin = new System.Windows.Forms.Padding(4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 194;
            this.label8.Text = "Gastos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 235);
            this.label9.Margin = new System.Windows.Forms.Padding(4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(260, 17);
            this.label9.TabIndex = 195;
            this.label9.Text = "------------------------------------------";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 256);
            this.label10.Margin = new System.Windows.Forms.Padding(4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 17);
            this.label10.TabIndex = 196;
            this.label10.Text = "Efectivo a entregar: $";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivo.Location = new System.Drawing.Point(188, 256);
            this.lblEfectivo.Margin = new System.Windows.Forms.Padding(4);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(0, 17);
            this.lblEfectivo.TabIndex = 197;
            this.lblEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "d/M/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(551, 15);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(133, 23);
            this.dtpFecha.TabIndex = 202;
            this.dtpFecha.Value = new System.DateTime(2014, 4, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(278, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 204;
            this.label2.Text = "Concepto:";
            // 
            // tbxConcepto
            // 
            this.tbxConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxConcepto.Location = new System.Drawing.Point(278, 206);
            this.tbxConcepto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxConcepto.MaxLength = 100;
            this.tbxConcepto.Name = "tbxConcepto";
            this.tbxConcepto.Size = new System.Drawing.Size(375, 23);
            this.tbxConcepto.TabIndex = 2;
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
            // tbxIva
            // 
            this.tbxIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIva.Location = new System.Drawing.Point(147, 117);
            this.tbxIva.Margin = new System.Windows.Forms.Padding(4);
            this.tbxIva.MaxLength = 9;
            this.tbxIva.Name = "tbxIva";
            this.tbxIva.ReadOnly = true;
            this.tbxIva.Size = new System.Drawing.Size(123, 22);
            this.tbxIva.TabIndex = 205;
            this.tbxIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 206;
            this.label3.Text = "IVA:";
            // 
            // btnImprimirCr
            // 
            this.btnImprimirCr.BackgroundImage = global::Diprolim.Properties.Resources.print;
            this.btnImprimirCr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirCr.Location = new System.Drawing.Point(565, 256);
            this.btnImprimirCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimirCr.Name = "btnImprimirCr";
            this.btnImprimirCr.Size = new System.Drawing.Size(45, 45);
            this.btnImprimirCr.TabIndex = 3;
            this.btnImprimirCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirCr.UseVisualStyleBackColor = true;
            this.btnImprimirCr.Click += new System.EventHandler(this.btnImprimirCr_Click);
            // 
            // btnRegistrarS
            // 
            this.btnRegistrarS.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnRegistrarS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistrarS.Location = new System.Drawing.Point(618, 256);
            this.btnRegistrarS.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrarS.Name = "btnRegistrarS";
            this.btnRegistrarS.Size = new System.Drawing.Size(45, 45);
            this.btnRegistrarS.TabIndex = 4;
            this.btnRegistrarS.UseVisualStyleBackColor = true;
            this.btnRegistrarS.Click += new System.EventHandler(this.btnRegistrarS_Click);
            // 
            // btnCambiarVendedor
            // 
            this.btnCambiarVendedor.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCambiarVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarVendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarVendedor.Location = new System.Drawing.Point(661, 53);
            this.btnCambiarVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiarVendedor.Name = "btnCambiarVendedor";
            this.btnCambiarVendedor.Size = new System.Drawing.Size(30, 30);
            this.btnCambiarVendedor.TabIndex = 198;
            this.btnCambiarVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarVendedor.UseVisualStyleBackColor = true;
            this.btnCambiarVendedor.Click += new System.EventHandler(this.btnCambiarVendedor_Click);
            // 
            // btnB
            // 
            this.btnB.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnB.Location = new System.Drawing.Point(240, 53);
            this.btnB.Margin = new System.Windows.Forms.Padding(4);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(30, 30);
            this.btnB.TabIndex = 182;
            this.btnB.UseVisualStyleBackColor = true;
            this.btnB.Click += new System.EventHandler(this.btnB_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(275, 15);
            this.label15.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(173, 24);
            this.label15.TabIndex = 246;
            this.label15.Text = "CORTE DE CAJA";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Corte_de_Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(718, 314);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbxIva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImprimirCr);
            this.Controls.Add(this.tbxConcepto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRegistrarS);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnCambiarVendedor);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbxGastos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxFiado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxRecuperado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.tbxNVendedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxVendedor);
            this.Controls.Add(this.tbxVT);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Corte_de_Caja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corte de caja";
            this.Load += new System.EventHandler(this.Corte_de_Caja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.TextBox tbxNVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxVendedor;
        private System.Windows.Forms.TextBox tbxVT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxRecuperado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxFiado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxGastos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Button btnCambiarVendedor;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnRegistrarS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxConcepto;
        private System.Windows.Forms.Button btnImprimirCr;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.TextBox tbxIva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
    }
}