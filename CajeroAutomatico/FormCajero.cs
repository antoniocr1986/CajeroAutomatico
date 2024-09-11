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
        BdDML bdDMl = new BdDML();

        private CuentaCorriente cuenta;
        private float CuentaSaldo;
        private long CuentaNumCuenta;
        private string CuentaUsuario;
        private int CuentaPin;
        private string CuentaIdentificacion;
        private int CuentaContador;
        private string[] Transferencias = new string[5];

        private Retiro retiro;
        public Conexion objetoConexion;

        public FormCajero(string identificacion)
        {
            InitializeComponent();

            CuentaIdentificacion = identificacion;
        }

        private void FormCajero_Load(object sender, EventArgs e)
        {
        }

        private void ButtonConsultaSaldo_Click(object sender, EventArgs e)
        {
            CuentaSaldo = bdDMl.ConsultaSaldo(CuentaIdentificacion);
            MessageBox.Show($"El saldo total de su cuenta es: {CuentaSaldo} €");
        }

        private void ButtonRetirarSaldo_Click(object sender, EventArgs e)
        {
            CuentaSaldo = bdDMl.ConsultaSaldo(CuentaIdentificacion);
            FormRetirar retirar = new FormRetirar(CuentaSaldo, CuentaIdentificacion, retiro);
            retirar.ShowDialog();
        }

        private void ButtonIngresarSaldo_Click(object sender, EventArgs e)
        {
            CuentaSaldo = bdDMl.ConsultaSaldo(CuentaIdentificacion);
            FormIngresar ingresar = new FormIngresar(CuentaSaldo, CuentaNumCuenta, CuentaUsuario, CuentaPin, CuentaIdentificacion, CuentaContador, Transferencias);
            ingresar.ShowDialog();  
        }

        private void ButtonVerNumCuenta_Click(object sender, EventArgs e)
        {
            CuentaNumCuenta = bdDMl.ConsultaNumCuenta(CuentaIdentificacion);
            MessageBox.Show("El numero de cuenta es "+ CuentaNumCuenta);
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
            try
            {
                if (!string.IsNullOrWhiteSpace(Transferencias[0]))

                {
                    MessageBox.Show($"Las ultimas transferencias son:\n{Transferencias[0]}\n{Transferencias[1]}\n" +
                    $"{Transferencias[2]}\n{Transferencias[3]}\n{Transferencias[4]}");
                }
                else
                    MessageBox.Show("No hay ninguna transferencia registrada en esta cuenta");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Excepcion: " + ex);
            }     
        }

        private void ButtonCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Cuenta.Transferencias = Transferencias;
            formLogin.ShowDialog();
        }

        private void buttonCambiarPIN_Click(object sender, EventArgs e)
        {
            FormCambioPIN formPIN= new FormCambioPIN(CuentaIdentificacion);
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
                    // Crear el comando SQL
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("@identificacion", CuentaIdentificacion);

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
