namespace CajeroAutomatico
{
    partial class FormRetirar
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
            this.buttonConfirmarRetiro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRetirar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonConfirmarRetiro
            // 
            this.buttonConfirmarRetiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirmarRetiro.Location = new System.Drawing.Point(70, 84);
            this.buttonConfirmarRetiro.Name = "buttonConfirmarRetiro";
            this.buttonConfirmarRetiro.Size = new System.Drawing.Size(128, 43);
            this.buttonConfirmarRetiro.TabIndex = 0;
            this.buttonConfirmarRetiro.Text = "CONFIRMAR";
            this.buttonConfirmarRetiro.UseVisualStyleBackColor = true;
            this.buttonConfirmarRetiro.Click += new System.EventHandler(this.ButtonConfirmarRetiro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Retirar";
            // 
            // textBoxRetirar
            // 
            this.textBoxRetirar.Location = new System.Drawing.Point(93, 39);
            this.textBoxRetirar.Name = "textBoxRetirar";
            this.textBoxRetirar.Size = new System.Drawing.Size(182, 20);
            this.textBoxRetirar.TabIndex = 2;
            this.textBoxRetirar.TextChanged += new System.EventHandler(this.textBoxRetirar_TextChanged);
            // 
            // FormRetirar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(295, 159);
            this.Controls.Add(this.textBoxRetirar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConfirmarRetiro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormRetirar";
            this.Text = "RETIRAR DINERO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirmarRetiro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRetirar;
    }
}