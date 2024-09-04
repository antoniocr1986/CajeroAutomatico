using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
                    return;
                }

                string numeroIdentificacionIngresado = textBoxIdentificacion.Text;
                int pinIngresado;
                if (!int.TryParse(textBoxPIN.Text, out pinIngresado))
                {
                    MessageBox.Show("El PIN debe ser un número válido");
                    return;
                }

                //Comprobamos si el usuario se conecta con el usuario creado en la clase Program.cs para 
                //trabajar sin base de datos '53313513L' y '12345678'
                if (textBoxIdentificacion.Text == Usuario.Identificacion && int.Parse(textBoxPIN.Text) == Usuario.PIN)
                {
                    MessageBox.Show("Te has logueado con un usuario intento del codigo de la aplicación");
                    this.Hide();
                    FormCajero cajero1 = new FormCajero(Usuario, Cuenta, Retiro);
                    cajero1.Show();
                    return;
                }

                //***A1 Conectar con BD
                Conexion objetoConexion = new Conexion();
                using (SqlConnection conexion = objetoConexion.getConexion())
                {
                    // *** A2: Verificar usuario en la base de datos
                    string query = "SELECT COUNT(*) FROM CuentasClientes WHERE Identificacion = @identificacion AND Pin = @pin";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@identificacion", numeroIdentificacionIngresado);
                    comando.Parameters.AddWithValue("@pin", pinIngresado);

                    int count = (int)comando.ExecuteScalar(); // Retorna el número de coincidencias

                    if (count > 0)
                    {
                        // Usuario y PIN son correctos
                        this.Hide();
                        FormCajero cajero1 = new FormCajero(Usuario, Cuenta, Retiro);
                        cajero1.Show();
                    }
                    else
                    {
                        // Usuario o PIN incorrectos
                        MessageBox.Show("El número de identificación o el PIN son incorrectos");
                    }

                    if (conexion.State != ConnectionState.Open)
                    {
                        MessageBox.Show("No se pudo establecer conexión con la base de datos.");
                        return;
                    }             
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show("El numero de tarjeta o el PIN tienen un formato incorrecto: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error: " + ex.Message);
            }
        }
    }
}
