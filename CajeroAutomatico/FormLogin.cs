using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public partial class FormLogin : Form
    {
        public Usuario usuario, usuario2;
        public CuentaCorriente cuenta, cuenta2;

        public FormLogin()
        {
            InitializeComponent();

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void buttonComprobar_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(textBoxNumTarjeta.Text) || string.IsNullOrEmpty(textBoxPIN.Text))
                {
                    MessageBox.Show("Rellena el numero de tarjeta y el PIN");
                }

                else
                {
                    long numeroTarjetaIngresado = long.Parse(textBoxNumTarjeta.Text);
                    int pinIngresado = int.Parse(textBoxPIN.Text);
                    if (usuario != null && usuario.verificarUsuario(long.Parse(textBoxNumTarjeta.Text),int.Parse(textBoxPIN.Text))|| usuario2 != null && usuario2.verificarUsuario(long.Parse(textBoxNumTarjeta.Text), int.Parse(textBoxPIN.Text)))
                    {
                        this.Hide();
                        FormCajero cajero1 = new FormCajero(new Usuario("Antonio", long.Parse(textBoxNumTarjeta.Text), int.Parse(textBoxNumTarjeta.Text)),
                            new Usuario("Mario", 0001000100010001, 123456),
                            new CuentaCorriente(20000,1234123412341234,usuario,12345678),
                            new CuentaCorriente(50, 0001000100010001, usuario2, 123456),
                            new Retiro());                     
                        cajero1.Show();                

                    }
                    else
                    {
                        MessageBox.Show("El numero de tarjeta o el PIN son incorrectos");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("El numero de tarjeta o el PIN tienen un formato incorrecto: " + ex.Message);
            }
        }
    }
}
