namespace Diprolim
{
    partial class Puestos
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
            this.tbxNombreP = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tblPuestos = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblAplicaComision = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.chkComision = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblPuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxNombreP
            // 
            this.tbxNombreP.Location = new System.Drawing.Point(16, 15);
            this.tbxNombreP.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNombreP.MaxLength = 50;
            this.tbxNombreP.Name = "tbxNombreP";
            this.tbxNombreP.Size = new System.Drawing.Size(255, 23);
            this.tbxNombreP.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = global::Diprolim.Properties.Resources.delete48;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(412, 9);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(35, 35);
            this.btnEliminar.TabIndex = 100;
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Diprolim.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(369, 9);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(35, 35);
            this.btnAgregar.TabIndex = 98;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // tblPuestos
            // 
            this.tblPuestos.AllowUserToAddRows = false;
            this.tblPuestos.AllowUserToDeleteRows = false;
            this.tblPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPuestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.UCodigo,
            this.UNombre,
            this.tblAplicaComision});
            this.tblPuestos.Location = new System.Drawing.Point(16, 52);
            this.tblPuestos.Margin = new System.Windows.Forms.Padding(4);
            this.tblPuestos.Name = "tblPuestos";
            this.tblPuestos.Size = new System.Drawing.Size(474, 278);
            this.tblPuestos.TabIndex = 94;
            // 
            // check
            // 
            this.check.HeaderText = "Guardar";
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Width = 70;
            // 
            // UCodigo
            // 
            this.UCodigo.HeaderText = "Codigo";
            this.UCodigo.Name = "UCodigo";
            this.UCodigo.Visible = false;
            // 
            // UNombre
            // 
            this.UNombre.HeaderText = "Nombre";
            this.UNombre.Name = "UNombre";
            this.UNombre.Width = 250;
            // 
            // tblAplicaComision
            // 
            this.tblAplicaComision.HeaderText = "Aplica comisión";
            this.tblAplicaComision.Name = "tblAplicaComision";
            this.tblAplicaComision.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tblAplicaComision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tblAplicaComision.Width = 70;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(455, 9);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(35, 35);
            this.btnGuardar.TabIndex = 102;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // chkComision
            // 
            this.chkComision.AutoSize = true;
            this.chkComision.Location = new System.Drawing.Point(278, 17);
            this.chkComision.Name = "chkComision";
            this.chkComision.Size = new System.Drawing.Size(84, 21);
            this.chkComision.TabIndex = 103;
            this.chkComision.Text = "Comisión";
            this.chkComision.UseVisualStyleBackColor = true;
            // 
            // Puestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(505, 345);
            this.Controls.Add(this.chkComision);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.tblPuestos);
            this.Controls.Add(this.tbxNombreP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Puestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevos puestos";
            ((System.ComponentModel.ISupportInitialize)(this.tblPuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxNombreP;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView tblPuestos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn UCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tblAplicaComision;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.CheckBox chkComision;
    }
}