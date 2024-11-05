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

namespace ProyectoBases
{
    public partial class Form9 : Form
    {
        string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Cajero;Password=Marceloco;";

        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el IdTransaccion ingresado
                int idTransaccion = int.Parse(textBox1.Text);

                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar que la sesión de esta transacción no haya comenzado
                    string queryVerificarSesion = @"
                SELECT Sesion.FechaInicio
                FROM VentaAsiento
                INNER JOIN Sesion ON VentaAsiento.IdSesion = Sesion.IdSesion
                WHERE VentaAsiento.IdTransaccion = @IdTransaccion";

                    DateTime fechaInicio;
                    using (SqlCommand command = new SqlCommand(queryVerificarSesion, connection))
                    {
                        command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            fechaInicio = (DateTime)result;

                            if (fechaInicio <= DateTime.Now)
                            {
                                MessageBox.Show("La sesión ya ha comenzado. No se puede eliminar la transacción.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la transacción.");
                            return;
                        }
                    }

                    // Si la sesión no ha comenzado, eliminar la transacción
                    string queryEliminarTransaccion = "DELETE FROM VentaAsiento WHERE IdTransaccion = @IdTransaccion";

                    using (SqlCommand command = new SqlCommand(queryEliminarTransaccion, connection))
                    {
                        command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                        command.ExecuteNonQuery();
                    }

                    // Cambiar el estado de los asientos a 0 en SesionAsiento
                    string queryActualizarAsientos = @"
                    UPDATE SesionAsiento
                    SET Estado = 0
                    FROM SesionAsiento with (updlock, holdlock)
                    INNER JOIN VentaAsiento ON SesionAsiento.IdAsiento = VentaAsiento.IdAsiento
                    WHERE VentaAsiento.IdTransaccion = @IdTransaccion and SesionAsiento.Estado = 1";

                    using (SqlCommand command = new SqlCommand(queryActualizarAsientos, connection))
                    {
                        command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("La transacción ha sido eliminada y los asientos han sido liberados.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese un IdTransaccion válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la transacción: " + ex.Message);
            }
        }
    }
}
