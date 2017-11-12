namespace Diprolim
{
    partial class comisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(comisiones));
            this.label1 = new System.Windows.Forms.Label();
            this.tblComisiones = new System.Windows.Forms.DataGridView();
            this.btnGuarda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblComisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 17);
            this.label1.TabIndex = 102;
            this.label1.Text = "Asignación de comisiones:";
            // 
            // tblComisiones
            // 
            this.tblComisiones.AllowUserToAddRows = false;
            this.tblComisiones.AllowUserToDeleteRows = false;
            this.tblComisiones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tblComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblComisiones.Location = new System.Drawing.Point(13, 30);
            this.tblComisiones.Margin = new System.Windows.Forms.Padding(4);
            this.tblComisiones.Name = "tblComisiones";
            this.tblComisiones.Size = new System.Drawing.Size(322, 140);
            this.tblComisiones.TabIndex = 103;
            // 
            // btnGuarda
            // 
            this.btnGuarda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuarda.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnGuarda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuarda.Location = new System.Drawing.Point(292, 178);
            this.btnGuarda.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuarda.Name = "btnGuarda";
            this.btnGuarda.Size = new System.Drawing.Size(45, 45);
            this.btnGuarda.TabIndex = 104;
            this.btnGuarda.UseVisualStyleBackColor = true;
            this.btnGuarda.Click += new System.EventHandler(this.btnGuarda_Click);
            // 
            // comisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(350, 227);
            this.Controls.Add(this.btnGuarda);
            this.Controls.Add(this.tblComisiones);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "comisiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comisiones";
            ((System.ComponentModel.ISupportInitialize)(this.tblComisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tblComisiones;
        private System.Windows.Forms.Button btnGuarda;

    }
}