using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public class BdDML
    {
        public Conexion objetoConexion;

        private float saldo;
        private long numCuenta;

        public float ConsultaSaldo(string identificacion)
        {
            string query = "SELECT saldo from CuentaCorriente Where identificacion = @identificacion";

            try
            {
                objetoConexion = new Conexion();
                using (SqlConnection conexion = objetoConexion.getConexion())
                {
                    // Crear el comando SQL
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("@identificacion", identificacion);

                    // Ejecutar la consulta
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Leer los resultados
                        if (reader != null && reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                saldo = Convert.ToSingle(reader.GetDouble(0));
                            }
                        }
                    }           
                }
                return saldo;
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            return 0;
        }

        public long ConsultaNumCuenta (string identificacion)
        {
            string query = "SELECT numCuenta from CuentaCorriente Where identificacion = @identificacion";

            try
            {
                objetoConexion = new Conexion();
                using (SqlConnection conexion = objetoConexion.getConexion())
                {
                    // Crear el comando SQL
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("@identificacion", identificacion);

                    // Ejecutar la consulta
                    SqlDataReader reader = command.ExecuteReader();

                    // Leer los resultados
                    if (reader != null && reader.Read())
                    {
                        numCuenta = reader.GetInt64(0);
                    }
                    return numCuenta;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            return 0;
        }

        public void RetirarSaldo(float cantidad, string identificacion)
        {
            string query = "UPDATE CuentaCorriente set saldo = saldo - @Cantidad WHERE identificacion = @identificacion ";
            try
            {
                objetoConexion = new Conexion();
                using (SqlConnection conexion = objetoConexion.getConexion())
                {
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("@identificacion", identificacion);
                    command.Parameters.AddWithValue("@Cantidad", cantidad);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader != null && reader.Read())
                    {
                        numCuenta = reader.GetInt64(0);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void IngresarSaldo(float cantidad, string identificacion)
        {
            string query = "UPDATE CuentaCorriente set saldo = saldo + @Cantidad WHERE identificacion = @identificacion ";
            try
            {
                objetoConexion = new Conexion();
                using (SqlConnection conexion = objetoConexion.getConexion())
                {
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("@identificacion", identificacion);
                    command.Parameters.AddWithValue("@Cantidad", cantidad);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader != null && reader.Read())
                    {
                        numCuenta = reader.GetInt64(0);
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
