using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    //***A1 CONECTAR CON BD
    public class Conexion
    {
        SqlConnection cconex = new SqlConnection();

        static string servidor ="localhost";
        static string bd ="CajeroAutomatico";
        static string usuario ="sa";
        static string password ="12345678";
        static string puerto= "1433";

        private string connectionString = "Data Source=" + servidor + "," + puerto + ";" + "User ID=" + usuario + ";" + "Password=" + password + ";" + "Initial Catalog=" + bd + ";" + "Persist Security Info=true";

        public SqlConnection getConexion()
        {
            try {
                cconex.ConnectionString = connectionString;
                cconex.Open();
                //MessageBox.Show("Se conecto correctamente a la Base de Datos");
            }
            catch(SqlException e)
            {
                MessageBox.Show("No se pudo realizar la conexion a la Base de Datos" + e.ToString());
            }
            return cconex;
        }



        public void InsertarTarjeta(string numeroTarjeta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Tarjetas (Identificacion) VALUES (@Identificacion)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Identificacion", numeroTarjeta);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarTarjeta(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Tarjetas WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<string> ObtenerTarjetas()
        {
            List<string> tarjetas = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Identificacion FROM Tarjetas";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tarjetas.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return tarjetas;
        }
    }
}





