
namespace CajeroAutomatico
{
    partial class FormCajero
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
            this.buttonConsultaSaldo = new System.Windows.Forms.Button();
            this.buttonRetirarSaldo = new System.Windows.Forms.Button();
            this.buttonVerNumCuenta = new System.Windows.Forms.Button();
            this.buttonTransferencias = new System.Windows.Forms.Button();
            this.buttonCerrarSesion = new System.Windows.Forms.Button();
            this.buttonIngresarSaldo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConsultaSaldo
            // 
            this.buttonConsultaSaldo.Location = new System.Drawing.Point(62, 48);
            this.buttonConsultaSaldo.Name = "buttonConsultaSaldo";
            this.buttonConsultaSaldo.Size = new System.Drawing.Size(109, 23);
            this.buttonConsultaSaldo.TabIndex = 0;
            this.buttonConsultaSaldo.Text = "Consulta de saldo";
            this.buttonConsultaSaldo.UseVisualStyleBackColor = true;
            this.buttonConsultaSaldo.Click += new System.EventHandler(this.buttonConsultaSaldo_Click);
            // 
            // buttonRetirarSaldo
            // 
            this.buttonRetirarSaldo.Location = new System.Drawing.Point(62, 104);
            this.buttonRetirarSaldo.Name = "buttonRetirarSaldo";
            this.buttonRetirarSaldo.Size = new System.Drawing.Size(109, 23);
            this.buttonRetirarSaldo.TabIndex = 1;
            this.buttonRetirarSaldo.Text = "Retirar saldo";
            this.buttonRetirarSaldo.UseVisualStyleBackColor = true;
            this.buttonRetirarSaldo.Click += new System.EventHandler(this.buttonRetirarSaldo_Click);
            // 
            // buttonVerNumCuenta
            // 
            this.buttonVerNumCuenta.Location = new System.Drawing.Point(233, 48);
            this.buttonVerNumCuenta.Name = "buttonVerNumCuenta";
            this.buttonVerNumCuenta.Size = new System.Drawing.Size(127, 23);
            this.buttonVerNumCuenta.TabIndex = 2;
            this.buttonVerNumCuenta.Text = "Ver núm. cuenta\r\n";
            this.buttonVerNumCuenta.UseVisualStyleBackColor = true;
            this.buttonVerNumCuenta.Click += new System.EventHandler(this.buttonVerNumCuenta_Click);
            // 
            // buttonTransferencias
            // 
            this.buttonTransferencias.Location = new System.Drawing.Point(233, 104);
            this.buttonTransferencias.Name = "buttonTransferencias";
            this.buttonTransferencias.Size = new System.Drawing.Size(127, 23);
            this.buttonTransferencias.TabIndex = 3;
            this.buttonTransferencias.Text = "Ver transferencias";
            this.buttonTransferencias.UseVisualStyleBackColor = true;
            this.buttonTransferencias.Click += new System.EventHandler(this.buttonTransferencias_Click);
            // 
            // buttonCerrarSesion
            // 
            this.buttonCerrarSesion.Location = new System.Drawing.Point(233, 163);
            this.buttonCerrarSesion.Name = "buttonCerrarSesion";
            this.buttonCerrarSesion.Size = new System.Drawing.Size(127, 23);
            this.buttonCerrarSesion.TabIndex = 4;
            this.buttonCerrarSesion.Text = "Cerrar sesión";
            this.buttonCerrarSesion.UseVisualStyleBackColor = true;
            this.buttonCerrarSesion.Click += new System.EventHandler(this.buttonCerrarSesion_Click);
            // 
            // buttonIngresarSaldo
            // 
            this.buttonIngresarSaldo.Location = new System.Drawing.Point(62, 163);
            this.buttonIngresarSaldo.Name = "buttonIngresarSaldo";
            this.buttonIngresarSaldo.Size = new System.Drawing.Size(109, 23);
            this.buttonIngresarSaldo.TabIndex = 5;
            this.buttonIngresarSaldo.Text = "Ingresar saldo";
            this.buttonIngresarSaldo.UseVisualStyleBackColor = true;
            this.buttonIngresarSaldo.Click += new System.EventHandler(this.buttonIngresarSaldo_Click);
            // 
            // FormCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(415, 216);
            this.Controls.Add(this.buttonIngresarSaldo);
            this.Controls.Add(this.buttonCerrarSesion);
            this.Controls.Add(this.buttonTransferencias);
            this.Controls.Add(this.buttonVerNumCuenta);
            this.Controls.Add(this.buttonRetirarSaldo);
            this.Controls.Add(this.buttonConsultaSaldo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCajero";
            this.Text = "CAJERO AUTOMATICO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCajero_FormClosing);
            this.Load += new System.EventHandler(this.FormCajero_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConsultaSaldo;
        private System.Windows.Forms.Button buttonRetirarSaldo;
        private System.Windows.Forms.Button buttonVerNumCuenta;
        private System.Windows.Forms.Button buttonTransferencias;
        private System.Windows.Forms.Button buttonCerrarSesion;
        private System.Windows.Forms.Button buttonIngresarSaldo;
    }
}