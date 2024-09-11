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
    public partial class FormCajero : Form
    {
        private CuentaCorriente cuenta;
        private double cuentaSaldo;
        private long numCuenta;
        private string cuentaUsuario;
        private int cuentaPin;
        private string cuentaIdentificacion;

        private Retiro retiro;
        public Conexion objetoConexion;

        public FormCajero(string identificacion)
        {
            InitializeComponent();

            cuentaIdentificacion = identificacion;
        }

        private void FormCajero_Load(object sender, EventArgs e)
        {
        }

        private void ButtonConsultaSaldo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"El saldo total de su cuenta es: {cuentaSaldo} €");
        }

        private void ButtonRetirarSaldo_Click(object sender, EventArgs e)
        {
            FormRetirar retirar = new FormRetirar(cuenta,retiro);
            retirar.ShowDialog();
        }

        private void ButtonIngresarSaldo_Click(object sender, EventArgs e)
        {
            FormIngresar ingresar = new FormIngresar(cuenta);
            ingresar.ShowDialog();  
        }

        private void ButtonVerNumCuenta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El numero de cuenta es "+numCuenta);
        }

        private void FormCajero_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void ButtonTransferencias_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cuenta.Transferencias[0]))

            {
                MessageBox.Show($"Las ultimas transferencias son:\n{cuenta.Transferencias[0]}\n{cuenta.Transferencias[1]}\n" +
                $"{cuenta.Transferencias[2]}\n{cuenta.Transferencias[3]}\n{cuenta.Transferencias[4]}");
            }
            else
                MessageBox.Show("No hay ninguna transferencia registrada en esta cuenta");
        }

        private void ButtonCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Cuenta = cuenta;
            formLogin.ShowDialog();
        }

        private void buttonCambiarPIN_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCambioPIN formPIN= new FormCambioPIN(cuentaIdentificacion);
            formPIN.ShowDialog();
        }

        public void consultarCuentaCorriente()
        {
            string query = "SELECT saldo, numCuenta, usuario, pin FROM CuentaCorriente WHERE Identificacion =@Identificacion)";

            try
            {
                objetoConexion = new Conexion();
                using (SqlConnection conexion = objetoConexion.getConexion())
                {
                    MessageBox.Show("paso 1b");
                    // Crear el comando SQL
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("@identificacion", cuentaIdentificacion);

                    MessageBox.Show("paso 2b");
                    // Ejecutar la consulta
                    SqlDataReader reader = command.ExecuteReader();

                    // Leer los resultados
                    if (reader != null && reader.Read())
                    {
                        float saldo = reader.GetFloat(0);
                        long numCuenta = reader.GetInt64(1);
                        string usuario = reader.GetString(2);
                        int pin = reader.GetInt32(3);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
