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

                    // Cambiar el estado de los asientos a 0 en SesionAsiento
                    string queryActualizarAsientos = @"
            UPDATE SesionAsiento
            SET Estado = 0
            FROM SesionAsiento WITH (UPDLOCK, HOLDLOCK)
            INNER JOIN VentaAsiento ON SesionAsiento.IdAsiento = VentaAsiento.IdAsiento
            WHERE VentaAsiento.IdTransaccion = @IdTransaccion AND SesionAsiento.Estado = 1";

                    using (SqlCommand command = new SqlCommand(queryActualizarAsientos, connection))
                    {
                        command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                        command.ExecuteNonQuery();
                    }

                    // Obtener el siguiente IdTransaccion y registrar en la tabla Transaccion
                    int nuevoIdTransaccion = ObtenerSiguienteIdTransaccion(connection);
                    int idTipoAsignacion = 3; // 3 corresponde a "eliminación"
                    DateTime fecha = DateTime.Now;

                    string queryInsertarTransaccion = @"
            INSERT INTO Transaccion (IdTransaccion, IdTipoAsignacion, Fecha)
            VALUES (@IdTransaccion, @IdTipoAsignacion, @Fecha)";

                    using (SqlCommand command = new SqlCommand(queryInsertarTransaccion, connection))
                    {
                        command.Parameters.AddWithValue("@IdTransaccion", nuevoIdTransaccion);
                        command.Parameters.AddWithValue("@IdTipoAsignacion", idTipoAsignacion);
                        command.Parameters.AddWithValue("@Fecha", fecha);
                        command.ExecuteNonQuery();
                    }

                    // Obtener el siguiente IdBitacora y registrar en la tabla Bitacora
                    int idBitacora = ObtenerSiguienteIdBitacora(connection);
                    DateTime fechaRegistro = DateTime.Now;
                    string usuario = "Cajero";
                    string accion = "eliminacion_boletos";
                    string datoViejo = "Estado asientos: (antes de eliminación)";
                    string datoNuevo = "Estado asientos: liberados";

                    string queryInsertarBitacora = @"
            INSERT INTO BitacoraTransaccion 
            (IdBitacoraTransaccion, IdTransaccion, FechaRegistro, Usuario, Accion, DatoViejo, DatoNuevo)
            VALUES (@IdBitacora, @IdTransaccion, @FechaRegistro, @Usuario, @Accion, @DatoViejo, @DatoNuevo)";

                    using (SqlCommand command = new SqlCommand(queryInsertarBitacora, connection))
                    {
                        command.Parameters.AddWithValue("@IdBitacora", idBitacora);
                        command.Parameters.AddWithValue("@IdTransaccion", nuevoIdTransaccion);
                        command.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Accion", accion);
                        command.Parameters.AddWithValue("@DatoViejo", datoViejo);
                        command.Parameters.AddWithValue("@DatoNuevo", datoNuevo);
                        command.ExecuteNonQuery();
                    }

                    // Eliminar la transacción de VentaAsiento
                    string queryEliminarTransaccion = "DELETE FROM VentaAsiento WHERE IdTransaccion = @IdTransaccion";
                    using (SqlCommand command = new SqlCommand(queryEliminarTransaccion, connection))
                    {
                        command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("La transacción ha sido eliminada, los asientos han sido liberados, y la Bitacora ha sido actualizada.");
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
        private int ObtenerSiguienteIdBitacora(SqlConnection connection)
        {
            int siguienteId = 1;
            string query = "SELECT ISNULL(MAX(IdBitacoraTransaccion), 0) + 1 FROM BitacoraTransaccion";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    siguienteId = Convert.ToInt32(result);
                }
            }

            return siguienteId;
        }
        // Método para obtener el siguiente IdTransaccion
        private int ObtenerSiguienteIdTransaccion(SqlConnection connection)
        {
            int siguienteId = 1;
            string query = "SELECT ISNULL(MAX(IdTransaccion), 0) + 1 FROM Transaccion";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    siguienteId = Convert.ToInt32(result);
                }
            }

            return siguienteId;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3  form3= new Form3();
            form3.ShowDialog();
            this.Hide();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
