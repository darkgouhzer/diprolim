namespace Diprolim
{
    partial class buscarFolios
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
            this.tblFolios = new System.Windows.Forms.DataGridView();
            this.colFolios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxBuscar = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblFolios)).BeginInit();
            this.SuspendLayout();
            // 
            // tblFolios
            // 
            this.tblFolios.AllowUserToAddRows = false;
            this.tblFolios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblFolios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFolios,
            this.colClientes});
            this.tblFolios.Location = new System.Drawing.Point(20, 52);
            this.tblFolios.Margin = new System.Windows.Forms.Padding(4);
            this.tblFolios.Name = "tblFolios";
            this.tblFolios.Size = new System.Drawing.Size(473, 250);
            this.tblFolios.TabIndex = 0;
            this.tblFolios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblFolios_CellDoubleClick);
            // 
            // colFolios
            // 
            this.colFolios.HeaderText = "Folios";
            this.colFolios.Name = "colFolios";
            this.colFolios.Width = 80;
            // 
            // colClientes
            // 
            this.colClientes.HeaderText = "Clientes";
            this.colClientes.Name = "colClientes";
            this.colClientes.Width = 300;
            // 
            // tbxBuscar
            // 
            this.tbxBuscar.Location = new System.Drawing.Point(13, 13);
            this.tbxBuscar.Name = "tbxBuscar";
            this.tbxBuscar.Size = new System.Drawing.Size(385, 23);
            this.tbxBuscar.TabIndex = 1;
            this.tbxBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxBuscar_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.Image = global::Diprolim.Properties.Resources.accept32;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(405, 4);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 40);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // buscarFolios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(506, 320);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tbxBuscar);
            this.Controls.Add(this.tblFolios);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "buscarFolios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "buscarFolios";
            ((System.ComponentModel.ISupportInitialize)(this.tblFolios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblFolios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientes;
        private System.Windows.Forms.TextBox tbxBuscar;
        private System.Windows.Forms.Button btnAceptar;
    }
}