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
    public partial class FormCambioPIN : Form
    {
        public string IdentificacionUsuario;

        public FormCambioPIN(string identificacion)
        {
            InitializeComponent();
            IdentificacionUsuario = identificacion;
        }

        private void buttonConfirmarNuevoPIN_Click(object sender, EventArgs e)
        {
            String nuevoPin;

            if (string.IsNullOrWhiteSpace(textBoxNuevoPIN.Text) || (string.IsNullOrWhiteSpace(textBoxNuevoPINbis.Text)))
            {
                MessageBox.Show("Rellena las dos casillas con el nuevo PIN");
                return;
            }
                if (textBoxNuevoPIN.Text != textBoxNuevoPINbis.Text)
            {
                MessageBox.Show("Los PIN introducidos han de coincidir");
                return;
            }

            nuevoPin = textBoxNuevoPIN.Text;
            MessageBox.Show("El nuevo PIN es: " + nuevoPin);

            //Aplicar cambios en la BD

            string query = "UPDATE CuentasClientes SET Pin = @Pin WHERE Identificacion = @Identificacion";
            string query2 = "UPDATE CuentaCorriente SET pin = @Pin WHERE identificacion = @Identificacion";

            Conexion objetoConexion = new Conexion();
            using (SqlConnection conexion = objetoConexion.getConexion())
            {
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@Pin", nuevoPin);
                    MessageBox.Show("Identificacion usuario = " + IdentificacionUsuario);
                    command.Parameters.AddWithValue("@Identificacion", IdentificacionUsuario);

                    try
                    {
                        // Ejecutar la consulta
                        int rowsAffected = command.ExecuteNonQuery();

                        // Informar al usuario sobre el resultado
                        Console.WriteLine($"{rowsAffected} fila(s) actualizada(s).");
                    }
                    catch (Exception ex)
                    {
                        // Manejo de excepciones
                        Console.WriteLine("Error al actualizar la base de datos: " + ex.Message);
                    }
                }

                using (SqlCommand command = new SqlCommand(query2, conexion))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@Pin", nuevoPin);
                    MessageBox.Show("Identificacion usuario = " + IdentificacionUsuario);
                    command.Parameters.AddWithValue("@Identificacion", IdentificacionUsuario);

                    try
                    {
                        // Ejecutar la consulta
                        int rowsAffected = command.ExecuteNonQuery();

                        // Informar al usuario sobre el resultado
                        Console.WriteLine($"{rowsAffected} fila(s) actualizada(s).");
                    }
                    catch (Exception ex)
                    {
                        // Manejo de excepciones
                        Console.WriteLine("Error al actualizar la base de datos: " + ex.Message);
                    }
                }
            }
        }

        private void checkBoxVerPIN_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVerPIN.Checked)
            {
                textBoxNuevoPIN.PasswordChar = '\0';
                textBoxNuevoPINbis.PasswordChar = '\0';
            }
            else
            {
                textBoxNuevoPIN.PasswordChar = '*';
                textBoxNuevoPINbis.PasswordChar = '*';
            }
        }
    }
}
