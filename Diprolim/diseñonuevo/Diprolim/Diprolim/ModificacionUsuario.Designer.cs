namespace Diprolim
{
    partial class ModificacionUsuario
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
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxContrasena = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxUsuario = new System.Windows.Forms.TextBox();
            this.btnSP = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCambiarP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbxCodigo.Location = new System.Drawing.Point(136, 23);
            this.tbxCodigo.Margin = new System.Windows.Forms.Padding(5);
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(69, 22);
            this.tbxCodigo.TabIndex = 9;
            this.tbxCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCodigo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(14, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Código Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(14, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // tbxContrasena
            // 
            this.tbxContrasena.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbxContrasena.Location = new System.Drawing.Point(136, 81);
            this.tbxContrasena.Margin = new System.Windows.Forms.Padding(5);
            this.tbxContrasena.Name = "tbxContrasena";
            this.tbxContrasena.PasswordChar = '*';
            this.tbxContrasena.Size = new System.Drawing.Size(243, 22);
            this.tbxContrasena.TabIndex = 7;
            this.tbxContrasena.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxContrasena_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // tbxUsuario
            // 
            this.tbxUsuario.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbxUsuario.Location = new System.Drawing.Point(136, 49);
            this.tbxUsuario.Margin = new System.Windows.Forms.Padding(5);
            this.tbxUsuario.Name = "tbxUsuario";
            this.tbxUsuario.Size = new System.Drawing.Size(243, 22);
            this.tbxUsuario.TabIndex = 1;
            this.tbxUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxUsuario_KeyDown);
            // 
            // btnSP
            // 
            this.btnSP.BackgroundImage = global::Diprolim.Properties.Resources.iconoBuscar;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSP.Location = new System.Drawing.Point(214, 19);
            this.btnSP.Margin = new System.Windows.Forms.Padding(4);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(30, 30);
            this.btnSP.TabIndex = 70;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Diprolim.Properties.Resources.delete;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Location = new System.Drawing.Point(334, 112);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 45);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::Diprolim.Properties.Resources.save;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGuardar.Location = new System.Drawing.Point(281, 112);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(45, 45);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnCambiarP
            // 
            this.btnCambiarP.BackgroundImage = global::Diprolim.Properties.Resources.refresh48;
            this.btnCambiarP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarP.Location = new System.Drawing.Point(252, 19);
            this.btnCambiarP.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiarP.Name = "btnCambiarP";
            this.btnCambiarP.Size = new System.Drawing.Size(30, 30);
            this.btnCambiarP.TabIndex = 101;
            this.btnCambiarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarP.UseVisualStyleBackColor = true;
            this.btnCambiarP.Click += new System.EventHandler(this.btnCambiarP_Click);
            // 
            // ModificacionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(387, 167);
            this.Controls.Add(this.btnCambiarP);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbxCodigo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tbxContrasena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxUsuario);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificacionUsuario";
            this.Text = "ModificacionUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxContrasena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxUsuario;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.Button btnCambiarP;


    }
}