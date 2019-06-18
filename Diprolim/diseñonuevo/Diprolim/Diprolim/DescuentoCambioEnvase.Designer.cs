namespace Diprolim
{
    partial class DescuentoCambioEnvase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtgDescuentoCambioEnvase = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLitros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDescuentoCambioEnvase)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(331, 196);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(45, 45);
            this.btnGuardar.TabIndex = 107;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // dtgDescuentoCambioEnvase
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDescuentoCambioEnvase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDescuentoCambioEnvase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDescuentoCambioEnvase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colLitros,
            this.colPorcentaje});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDescuentoCambioEnvase.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgDescuentoCambioEnvase.Location = new System.Drawing.Point(12, 12);
            this.dtgDescuentoCambioEnvase.Name = "dtgDescuentoCambioEnvase";
            this.dtgDescuentoCambioEnvase.Size = new System.Drawing.Size(364, 177);
            this.dtgDescuentoCambioEnvase.TabIndex = 106;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colLitros
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colLitros.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLitros.HeaderText = "Litros";
            this.colLitros.Name = "colLitros";
            // 
            // colPorcentaje
            // 
            dataGridViewCellStyle3.NullValue = "0";
            this.colPorcentaje.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPorcentaje.HeaderText = "Descuento %";
            this.colPorcentaje.Name = "colPorcentaje";
            this.colPorcentaje.Width = 150;
            // 
            // DescuentoCambioEnvase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 255);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtgDescuentoCambioEnvase);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DescuentoCambioEnvase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descuento por cambio de envase";
            ((System.ComponentModel.ISupportInitialize)(this.dtgDescuentoCambioEnvase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dtgDescuentoCambioEnvase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLitros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorcentaje;
    }
}