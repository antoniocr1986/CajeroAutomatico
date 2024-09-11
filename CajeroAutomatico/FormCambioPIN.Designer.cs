namespace CajeroAutomatico
{
    partial class FormCambioPIN
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
            this.textBoxNuevoPIN = new System.Windows.Forms.TextBox();
            this.textBoxNuevoPINbis = new System.Windows.Forms.TextBox();
            this.lblNuevoPIN = new System.Windows.Forms.Label();
            this.lbl_RepitaNuevoPIN = new System.Windows.Forms.Label();
            this.buttonConfirmarNuevoPIN = new System.Windows.Forms.Button();
            this.checkBoxVerPIN = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxNuevoPIN
            // 
            this.textBoxNuevoPIN.Location = new System.Drawing.Point(84, 66);
            this.textBoxNuevoPIN.Name = "textBoxNuevoPIN";
            this.textBoxNuevoPIN.PasswordChar = '*';
            this.textBoxNuevoPIN.Size = new System.Drawing.Size(100, 20);
            this.textBoxNuevoPIN.TabIndex = 0;
            // 
            // textBoxNuevoPINbis
            // 
            this.textBoxNuevoPINbis.Location = new System.Drawing.Point(84, 139);
            this.textBoxNuevoPINbis.Name = "textBoxNuevoPINbis";
            this.textBoxNuevoPINbis.PasswordChar = '*';
            this.textBoxNuevoPINbis.Size = new System.Drawing.Size(100, 20);
            this.textBoxNuevoPINbis.TabIndex = 1;
            // 
            // lblNuevoPIN
            // 
            this.lblNuevoPIN.AutoSize = true;
            this.lblNuevoPIN.Location = new System.Drawing.Point(42, 29);
            this.lblNuevoPIN.Name = "lblNuevoPIN";
            this.lblNuevoPIN.Size = new System.Drawing.Size(122, 13);
            this.lblNuevoPIN.TabIndex = 2;
            this.lblNuevoPIN.Text = "Introduzca el nuevo PIN";
            // 
            // lbl_RepitaNuevoPIN
            // 
            this.lbl_RepitaNuevoPIN.AutoSize = true;
            this.lbl_RepitaNuevoPIN.Location = new System.Drawing.Point(42, 111);
            this.lbl_RepitaNuevoPIN.Name = "lbl_RepitaNuevoPIN";
            this.lbl_RepitaNuevoPIN.Size = new System.Drawing.Size(103, 13);
            this.lbl_RepitaNuevoPIN.TabIndex = 3;
            this.lbl_RepitaNuevoPIN.Text = "Repita el nuevo PIN";
            // 
            // buttonConfirmarNuevoPIN
            // 
            this.buttonConfirmarNuevoPIN.Location = new System.Drawing.Point(45, 208);
            this.buttonConfirmarNuevoPIN.Name = "buttonConfirmarNuevoPIN";
            this.buttonConfirmarNuevoPIN.Size = new System.Drawing.Size(206, 23);
            this.buttonConfirmarNuevoPIN.TabIndex = 4;
            this.buttonConfirmarNuevoPIN.Text = "CONFIRMAR NUEVO PIN";
            this.buttonConfirmarNuevoPIN.UseVisualStyleBackColor = true;
            this.buttonConfirmarNuevoPIN.Click += new System.EventHandler(this.buttonConfirmarNuevoPIN_Click);
            // 
            // checkBoxVerPIN
            // 
            this.checkBoxVerPIN.AutoSize = true;
            this.checkBoxVerPIN.Location = new System.Drawing.Point(214, 68);
            this.checkBoxVerPIN.Name = "checkBoxVerPIN";
            this.checkBoxVerPIN.Size = new System.Drawing.Size(63, 17);
            this.checkBoxVerPIN.TabIndex = 5;
            this.checkBoxVerPIN.Text = "Ver PIN";
            this.checkBoxVerPIN.UseVisualStyleBackColor = true;
            this.checkBoxVerPIN.CheckedChanged += new System.EventHandler(this.checkBoxVerPIN_CheckedChanged);
            // 
            // FormCambioPIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.checkBoxVerPIN);
            this.Controls.Add(this.buttonConfirmarNuevoPIN);
            this.Controls.Add(this.lbl_RepitaNuevoPIN);
            this.Controls.Add(this.lblNuevoPIN);
            this.Controls.Add(this.textBoxNuevoPINbis);
            this.Controls.Add(this.textBoxNuevoPIN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCambioPIN";
            this.Text = "FormCambioPIN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCambioPIN_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNuevoPIN;
        private System.Windows.Forms.TextBox textBoxNuevoPINbis;
        private System.Windows.Forms.Label lblNuevoPIN;
        private System.Windows.Forms.Label lbl_RepitaNuevoPIN;
        private System.Windows.Forms.Button buttonConfirmarNuevoPIN;
        private System.Windows.Forms.CheckBox checkBoxVerPIN;
    }
}