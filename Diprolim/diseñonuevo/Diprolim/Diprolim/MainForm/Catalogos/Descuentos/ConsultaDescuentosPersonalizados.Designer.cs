namespace Diprolim.MainForm.Catalogos.Descuentos
{
    partial class Consulta_descuentos_personalizados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta_descuentos_personalizados));
            this.rbtnTodas = new System.Windows.Forms.RadioButton();
            this.rbtnActivas = new System.Windows.Forms.RadioButton();
            this.rbtnInactivas = new System.Windows.Forms.RadioButton();
            this.btnNueva = new System.Windows.Forms.Button();
            this.dtgCampana = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreCampana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCampana)).BeginInit();
            this.SuspendLayout();
            // 
            // rbtnTodas
            // 
            this.rbtnTodas.AutoSize = true;
            this.rbtnTodas.Location = new System.Drawing.Point(102, 32);
            this.rbtnTodas.Name = "rbtnTodas";
            this.rbtnTodas.Size = new System.Drawing.Size(66, 21);
            this.rbtnTodas.TabIndex = 1;
            this.rbtnTodas.Text = "Todas";
            this.rbtnTodas.UseVisualStyleBackColor = true;
            this.rbtnTodas.Click += new System.EventHandler(this.rbtnTodas_Click);
            // 
            // rbtnActivas
            // 
            this.rbtnActivas.AutoSize = true;
            this.rbtnActivas.Checked = true;
            this.rbtnActivas.Location = new System.Drawing.Point(25, 32);
            this.rbtnActivas.Name = "rbtnActivas";
            this.rbtnActivas.Size = new System.Drawing.Size(71, 21);
            this.rbtnActivas.TabIndex = 0;
            this.rbtnActivas.TabStop = true;
            this.rbtnActivas.Text = "Activas";
            this.rbtnActivas.UseVisualStyleBackColor = true;
            this.rbtnActivas.Click += new System.EventHandler(this.rbtnActivas_Click);
            // 
            // rbtnInactivas
            // 
            this.rbtnInactivas.AutoSize = true;
            this.rbtnInactivas.Location = new System.Drawing.Point(174, 32);
            this.rbtnInactivas.Name = "rbtnInactivas";
            this.rbtnInactivas.Size = new System.Drawing.Size(81, 21);
            this.rbtnInactivas.TabIndex = 2;
            this.rbtnInactivas.Text = "Inactivas";
            this.rbtnInactivas.UseVisualStyleBackColor = true;
            this.rbtnInactivas.Click += new System.EventHandler(this.rbtnInactivas_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNueva.Image = ((System.Drawing.Image)(resources.GetObject("btnNueva.Image")));
            this.btnNueva.Location = new System.Drawing.Point(368, 12);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(101, 77);
            this.btnNueva.TabIndex = 3;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // dtgCampana
            // 
            this.dtgCampana.AllowUserToAddRows = false;
            this.dtgCampana.AllowUserToDeleteRows = false;
            this.dtgCampana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCampana.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombreCampana});
            this.dtgCampana.Location = new System.Drawing.Point(25, 95);
            this.dtgCampana.Name = "dtgCampana";
            this.dtgCampana.ReadOnly = true;
            this.dtgCampana.Size = new System.Drawing.Size(444, 355);
            this.dtgCampana.TabIndex = 4;
            this.dtgCampana.DoubleClick += new System.EventHandler(this.dtgCampana_DoubleClick);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(261, 12);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(101, 77);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Visible = false;
            // 
            // colNombreCampana
            // 
            this.colNombreCampana.HeaderText = "Nombre de campaña";
            this.colNombreCampana.Name = "colNombreCampana";
            this.colNombreCampana.ReadOnly = true;
            this.colNombreCampana.Width = 350;
            // 
            // Consulta_descuentos_personalizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 463);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtgCampana);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.rbtnInactivas);
            this.Controls.Add(this.rbtnActivas);
            this.Controls.Add(this.rbtnTodas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Consulta_descuentos_personalizados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar descuentos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Consulta_descuentos_personalizados_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCampana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnTodas;
        private System.Windows.Forms.RadioButton rbtnActivas;
        private System.Windows.Forms.RadioButton rbtnInactivas;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.DataGridView dtgCampana;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCampana;
    }
}