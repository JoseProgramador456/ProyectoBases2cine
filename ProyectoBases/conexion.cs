using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ProyectoBases
{
    internal class conexion
    {
        // Definir la cadena de conexión como una constante en la clase
        private string connectionString = "Server=26.168.254.53\\SQLEXPRESS;Database=ProyectoCine;User Id=Pablo;Password=12345;";

        public conexion() { }

        // Método para ejecutar un SP que no devuelve datos
        public bool EjecutarSP(string nombreSP, Dictionary<string, object> parametros)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(nombreSP, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        foreach (var param in parametros)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Si se lanza un error desde el SP (RAISEERROR o THROW), se captura aquí
                    MessageBox.Show($"Error: {ex.Message}");
                    return false;
                }
            }
        }

        // Método para ejecutar un SP que devuelve datos
        public DataTable EjecutarSPConResultado(string nombreSP, Dictionary<string, object> parametros)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(nombreSP, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        foreach (var param in parametros)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Si se lanza un error desde el SP (RAISEERROR o THROW), se captura aquí
                    MessageBox.Show($"Error: {ex.Message}");
                    return null;
                }
            }

        }

    }
}

