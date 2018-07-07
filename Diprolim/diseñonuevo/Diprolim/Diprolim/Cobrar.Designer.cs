namespace Diprolim
{
    partial class Cobrar
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
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.tbxEfectivo = new System.Windows.Forms.TextBox();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.tbxCambio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTerminarVenta = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivo.Location = new System.Drawing.Point(29, 85);
            this.lblEfectivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(98, 29);
            this.lblEfectivo.TabIndex = 0;
            this.lblEfectivo.Text = "Efectivo";
            // 
            // tbxEfectivo
            // 
            this.tbxEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEfectivo.Location = new System.Drawing.Point(164, 82);
            this.tbxEfectivo.Margin = new System.Windows.Forms.Padding(4);
            this.tbxEfectivo.Name = "tbxEfectivo";
            this.tbxEfectivo.Size = new System.Drawing.Size(132, 35);
            this.tbxEfectivo.TabIndex = 1;
            this.tbxEfectivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxEfectivo_KeyDown);
            this.tbxEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxEfectivo_KeyPress);
            this.tbxEfectivo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxEfectivo_KeyUp);
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lblTotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenta.ForeColor = System.Drawing.Color.Green;
            this.lblTotalVenta.Location = new System.Drawing.Point(167, 9);
            this.lblTotalVenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(119, 46);
            this.lblTotalVenta.TabIndex = 2;
            this.lblTotalVenta.Text = "$0.00";
            // 
            // tbxCambio
            // 
            this.tbxCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCambio.Location = new System.Drawing.Point(164, 125);
            this.tbxCambio.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCambio.Name = "tbxCambio";
            this.tbxCambio.ReadOnly = true;
            this.tbxCambio.Size = new System.Drawing.Size(132, 35);
            this.tbxCambio.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Su cambio";
            // 
            // btnTerminarVenta
            // 
            this.btnTerminarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminarVenta.Location = new System.Drawing.Point(312, 82);
            this.btnTerminarVenta.Name = "btnTerminarVenta";
            this.btnTerminarVenta.Size = new System.Drawing.Size(142, 78);
            this.btnTerminarVenta.TabIndex = 5;
            this.btnTerminarVenta.Text = "Finalizar venta [F1]";
            this.btnTerminarVenta.UseVisualStyleBackColor = true;
            this.btnTerminarVenta.Click += new System.EventHandler(this.btnTerminarVenta_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(30, 23);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(92, 29);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "TOTAL";
            // 
            // Cobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 178);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnTerminarVenta);
            this.Controls.Add(this.tbxCambio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalVenta);
            this.Controls.Add(this.tbxEfectivo);
            this.Controls.Add(this.lblEfectivo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrar";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cobrar_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.TextBox tbxEfectivo;
        private System.Windows.Forms.Label lblTotalVenta;
        private System.Windows.Forms.TextBox tbxCambio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTerminarVenta;
        private System.Windows.Forms.Label lblTotal;
    }
}