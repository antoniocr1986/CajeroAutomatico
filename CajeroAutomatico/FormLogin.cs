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
        public Usuario Usuario {get;set;}
        public CuentaCorriente Cuenta { get; set; }

        public Retiro Retiro { get; set; }

        /*static Usuario usuario = new Usuario("Antonio", 1234123412341234, 12345678);
        static CuentaCorriente cuenta = new CuentaCorriente(20000, 1234123412341234, usuario, 12345678);
        static Retiro retiro = new Retiro();*/

        public FormLogin(Usuario usuario)
        {
            InitializeComponent();

            this.Retiro = new Retiro();
            this.Usuario = usuario;
            FormCajero cajero1 = new FormCajero(this.Usuario, this.Cuenta, this.Retiro);
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void ButtonComprobar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxIdentificacion.Text) || string.IsNullOrEmpty(textBoxPIN.Text))
                {
                    MessageBox.Show("Rellena el numero de tarjeta y el PIN");
                }

                else
                {
                    //***A1 Conectar con BD
                    /*Conexion objetoConexion = new Conexion();
                    objetoConexion.getConexion();*/
                    string numeroIdentificacionIngresado = textBoxIdentificacion.Text;
                    int pinIngresado = int.Parse(textBoxPIN.Text);
                    if (Usuario != null && Usuario.VerificarUsuario(textBoxIdentificacion.Text,int.Parse(textBoxPIN.Text)))
                    {
                        this.Hide();
                        FormCajero cajero1 = new FormCajero(Usuario, Cuenta, Retiro);     
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
