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
        // CuentaCorriente Cuenta { get; set; }


        public Retiro Retiro { get; set; }

        Conexion objetoConexion = new Conexion();

        public FormLogin()
        {
            InitializeComponent();
            this.Retiro = new Retiro();
        }

        public FormLogin(Usuario usuario)
        {
            InitializeComponent();

            this.Retiro = new Retiro();
            this.Usuario = usuario;
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

                //***A1 Conectar con BD
                objetoConexion = new Conexion();
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

                        CuentaCorriente cuenta = new CuentaCorriente();

                        comprobarCuentaUsuarioBD(conexion, cuenta, pinIngresado);
                       

                        /*FormCajero cajero1 = new FormCajero(Usuario, cuenta, Retiro);*/
                        FormCajero cajero1 = new FormCajero(numeroIdentificacionIngresado);
                        cajero1.Show();

                        MessageBox.Show("Creando FormCajero"+
                            "\nUsuario = " + cuenta.Identificacion+
                            "\nCuenta = " + cuenta+
                            "\nRetiro = " + Retiro);
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

        public void comprobarCuentaUsuarioBD(SqlConnection conexion, CuentaCorriente cuenta, int pin)
        {
            string query = "SELECT saldo, numCuenta, usuario, pin, identificacion FROM CuentaCorriente WHERE pin = @Pin";

            try
            {
                // Crear el comando SQL
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@Pin", pin);

                // Ejecutar la consulta
                SqlDataReader reader = command.ExecuteReader();

                // Leer los resultados
                if (reader != null && reader.Read())
                {
                    cuenta.Saldo = reader.GetDouble(reader.GetOrdinal("saldo"));
                    cuenta.Identificacion = reader.GetString(reader.GetOrdinal("identificacion"));
                    cuenta.PIN = reader.GetInt32(reader.GetOrdinal("pin"));
                    cuenta.NumCuenta = reader.GetInt64(reader.GetOrdinal("numCuenta"));

                    // Aquí ya tienes los datos en la propiedad de cuenta
                    MessageBox.Show("ComprobarCuentaUsuario BD"+
                        "\nSaldo: " + cuenta.Saldo+
                        "\nUsuario: " + cuenta.Identificacion+
                        "\nPIN: " + cuenta.PIN+
                        "\nNumCuenta: " + cuenta.NumCuenta);
                }
                else
                {
                    MessageBox.Show("No se encontró la cuenta.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
