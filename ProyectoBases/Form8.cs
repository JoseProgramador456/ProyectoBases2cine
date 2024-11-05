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
    public partial class Form8 : Form
    {
        string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Cajero;Password=Marceloco;";

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los IDs de las sesiones actuales y nuevas ingresadas por el usuario
                int idSesionActual = int.Parse(txtIdSesionActual.Text);
                int idSesionNueva = int.Parse(txtIdSesionNueva.Text);
                string[] asientosComprados = txtAsientosComprados.Text.Split(',');
                string[] asientosNuevos = txtAsientosNuevos.Text.Split(',');

                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Validar que la sesión actual no haya comenzado
                    if (!ValidarSesionNoIniciada(connection, idSesionActual))
                    {
                        MessageBox.Show("La sesión actual ya ha comenzado. No se pueden realizar cambios.");
                        return;
                    }

                    // Validar que la sesión nueva no haya comenzado
                    if (!ValidarSesionNoIniciada(connection, idSesionNueva))
                    {
                        MessageBox.Show("La sesión nueva ya ha comenzado. No se pueden realizar cambios.");
                        return;
                    }

                    // Validar que los asientos comprados estén en estado 1
                    if (!ValidarAsientosComprados(connection, idSesionActual, asientosComprados))
                    {
                        return; // Si algún asiento no está en estado 1, se detiene el proceso
                    }

                    // Validar que los asientos nuevos estén en estado 0
                    if (!ValidarAsientosNuevos(connection, idSesionNueva, asientosNuevos))
                    {
                        return; // Si algún asiento no está en estado 0, se detiene el proceso
                    }

                    // Actualizar los asientos comprados a estado 0
                    ActualizarAsientosComprados(idSesionActual, txtAsientosComprados.Text, connection);

                    // Actualizar Transaccion
                    ActualizarTablaTransaccion1(connection);


                    // Actualizar los asientos nuevos a estado 1
                    ActualizarAsientosNuevos(idSesionNueva, txtAsientosNuevos.Text, connection);

                    // Actualizar Transaccion
                    ActualizarTablaTransaccion2(connection);

                    MessageBox.Show("Los asientos han sido actualizados correctamente.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para los IDs de las sesiones.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el cambio de asientos: " + ex.Message);
            }
        }

        // Método para validar que una sesión no haya comenzado
        private bool ValidarSesionNoIniciada(SqlConnection connection, int idSesion)
        {
            // Consulta SQL para obtener la fecha de inicio de la sesión
            string query = "SELECT FechaInicio FROM Sesion WHERE IdSesion = @IdSesion";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Agregar el parámetro de la sesión
                command.Parameters.AddWithValue("@IdSesion", idSesion);

                // Ejecutar la consulta y obtener la fecha de inicio
                DateTime fechaInicio = (DateTime)command.ExecuteScalar();

                // Verificar si la fecha de inicio es menor o igual a la fecha actual
                return fechaInicio > DateTime.Now;
            }
        }

        // Método para validar que los asientos comprados estén en estado 1
        private bool ValidarAsientosComprados(SqlConnection connection, int idSesionActual, string[] asientosComprados)
        {
            foreach (string asiento in asientosComprados)
            {
                string fila = asiento.Substring(0, 1); // Primera letra es la fila
                int numero = int.Parse(asiento.Substring(1)); // Resto es el número

                string query = @"
SELECT COUNT(*)
FROM SesionAsiento
INNER JOIN Asiento ON SesionAsiento.IdAsiento = Asiento.IdAsiento
WHERE Asiento.Fila = @Fila AND Asiento.Numero = @Numero 
AND SesionAsiento.IdSesion = @IdSesionActual AND SesionAsiento.Estado = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Fila", fila);
                    command.Parameters.AddWithValue("@Numero", numero);
                    command.Parameters.AddWithValue("@IdSesionActual", idSesionActual);

                    int count = (int)command.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show($"El asiento {fila}{numero} no está en estado 1.");
                        return false;
                    }
                }
            }
            return true;
        }

        // Método para validar que los asientos nuevos estén en estado 0
        private bool ValidarAsientosNuevos(SqlConnection connection, int idSesionNueva, string[] asientosNuevos)
        {
            foreach (string asiento in asientosNuevos)
            {
                string fila = asiento.Substring(0, 1); // Primera letra es la fila
                int numero = int.Parse(asiento.Substring(1)); // Resto es el número

                string query = @"
SELECT COUNT(*)
FROM SesionAsiento
INNER JOIN Asiento ON SesionAsiento.IdAsiento = Asiento.IdAsiento
WHERE Asiento.Fila = @Fila AND Asiento.Numero = @Numero 
AND SesionAsiento.IdSesion = @IdSesionNueva AND SesionAsiento.Estado = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Fila", fila);
                    command.Parameters.AddWithValue("@Numero", numero);
                    command.Parameters.AddWithValue("@IdSesionNueva", idSesionNueva);

                    int count = (int)command.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show($"El asiento {fila}{numero} no está en estado 0.");
                        return false;
                    }
                }
            }
            return true;
        }

        // Método para actualizar los asientos comprados a estado 0
        private void ActualizarAsientosComprados(int idSesionActual, string asientosCompradosText, SqlConnection connection)
        {
            try
            {
                // Actualizar los asientos comprados a estado 0
                string[] asientosComprados = asientosCompradosText.Split(',');
                foreach (string asiento in asientosComprados)
                {
                    string fila = asiento.Substring(0, 1);
                    int numero = int.Parse(asiento.Substring(1));

                    string queryActualizarComprados = @"
            UPDATE SesionAsiento
            SET Estado = 0
            FROM SesionAsiento with (updlock, holdlock)
            INNER JOIN Asiento ON SesionAsiento.IdAsiento = Asiento.IdAsiento
            WHERE Asiento.Fila = @Fila AND Asiento.Numero = @Numero 
            AND SesionAsiento.IdSesion = @IdSesionActual";

                    using (SqlCommand command = new SqlCommand(queryActualizarComprados, connection))
                    {
                        command.Parameters.AddWithValue("@Fila", fila);
                        command.Parameters.AddWithValue("@Numero", numero);
                        command.Parameters.AddWithValue("@IdSesionActual", idSesionActual);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Los asientos comprados han sido actualizados a estado 0 correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los asientos comprados: " + ex.Message);
            }
        }

        // Método para actualizar los asientos Nuevos a estado 1
        private void ActualizarAsientosNuevos(int idSesionNueva, string asientosNuevosText, SqlConnection connection)
        {
            try
            {
                // Actualizar los asientos nuevos a estado 1
                string[] asientosNuevos = asientosNuevosText.Split(',');
                foreach (string asiento in asientosNuevos)
                {
                    string fila = asiento.Substring(0, 1);
                    int numero = int.Parse(asiento.Substring(1));

                    string queryActualizarNuevos = @"
            UPDATE SesionAsiento
            SET Estado = 1
            FROM SesionAsiento with (updlock, holdlock)
            INNER JOIN Asiento ON SesionAsiento.IdAsiento = Asiento.IdAsiento
            WHERE Asiento.Fila = @Fila AND Asiento.Numero = @Numero 
            AND SesionAsiento.IdSesion = @IdSesionNueva";

                    using (SqlCommand command = new SqlCommand(queryActualizarNuevos, connection))
                    {
                        command.Parameters.AddWithValue("@Fila", fila);
                        command.Parameters.AddWithValue("@Numero", numero);
                        command.Parameters.AddWithValue("@IdSesionNueva", idSesionNueva);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Los asientos nuevos han sido actualizados a estado 1 correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los asientos nuevos: " + ex.Message);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------


        // Método para actualizar la tabla transaccion
        private void ActualizarTablaTransaccion1(SqlConnection connection)
        {
            try
            {
                // Obtener el siguiente ID de Transaccion
                int idTransaccion = ObtenerSiguienteIdTransaccion();

                // Definir el tipo de asignación y la fecha actual
                int idTipoAsignacion = 4; // 4 corresponde a "cambio_boletos"
                string fecha = DateTime.Now.ToString("yyyy-MM-dd"); // Fecha en formato año-mes-día

                // Insertar en la tabla Transaccion
                string queryInsertarTransaccion = @"
        INSERT INTO Transaccion (IdTransaccion, IdTipoAsignacion, Fecha)
        VALUES (@IdTransaccion, @IdTipoAsignacion, @Fecha)";

                using (SqlCommand command = new SqlCommand(queryInsertarTransaccion, connection))
                {
                    command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                    command.Parameters.AddWithValue("@IdTipoAsignacion", idTipoAsignacion);
                    command.Parameters.AddWithValue("@Fecha", fecha);
                    command.ExecuteNonQuery();
                }

                // Ahora, actualizar la tabla Bitacora
                ActualizarTablaBitacora(idTransaccion, connection);

                MessageBox.Show("La transacción y la bitácora han sido actualizadas correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla Transaccion y Bitacora: " + ex.Message);
            }
        }

        // Método para actualizar la tabla transaccion
        private void ActualizarTablaTransaccion2(SqlConnection connection)
        {
            try
            {
                // Obtener el siguiente ID de Transaccion
                int idTransaccion = ObtenerSiguienteIdTransaccion();

                // Definir el tipo de asignación y la fecha actual
                int idTipoAsignacion = 4; // 4 corresponde a "cambio_boletos"
                string fecha = DateTime.Now.ToString("yyyy-MM-dd"); // Fecha en formato año-mes-día

                // Insertar en la tabla Transaccion
                string queryInsertarTransaccion = @"
        INSERT INTO Transaccion (IdTransaccion, IdTipoAsignacion, Fecha)
        VALUES (@IdTransaccion, @IdTipoAsignacion, @Fecha)";

                using (SqlCommand command = new SqlCommand(queryInsertarTransaccion, connection))
                {
                    command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                    command.Parameters.AddWithValue("@IdTipoAsignacion", idTipoAsignacion);
                    command.Parameters.AddWithValue("@Fecha", fecha);
                    command.ExecuteNonQuery();
                }

                // Ahora, actualizar la tabla Bitacora
                ActualizarTablaBitacora2(idTransaccion, connection);

                MessageBox.Show("La transacción y la bitácora han sido actualizadas correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla Transaccion y Bitacora: " + ex.Message);
            }
        }
        // Método para actualizar la tabla Bitacora
        private void ActualizarTablaBitacora(int idTransaccion, SqlConnection connection)
        {
            try
            {
                // Obtener el siguiente ID de Bitacora
                int idBitacora = ObtenerSiguienteIdBitacora(connection);

                // Detalles para insertar en la tabla Bitacora
                DateTime fechaRegistro = DateTime.Now;
                string usuario = "Cajero"; // Cambia esto según el usuario actual
                string accion = "cambio_boletos";

                // Generar las descripciones de DatoViejo y DatoNuevo
                string datoViejo = GenerarDescripcionAsientos(txtAsientosComprados.Text, "ocupados", int.Parse(txtIdSesionActual.Text), connection);
                string datoNuevo = GenerarDescripcionAsientos(txtAsientosComprados.Text, "libres", int.Parse(txtIdSesionActual.Text), connection);

                // Insertar en la tabla Bitacora
                string queryInsertarBitacora = @"
        INSERT INTO BitacoraTransaccion (IdBitacoraTransaccion, IdTransaccion, FechaRegistro, Usuario, Accion, DatoViejo, DatoNuevo)
        VALUES (@IdBitacora, @IdTransaccion, @FechaRegistro, @Usuario, @Accion, @DatoViejo, @DatoNuevo)";

                using (SqlCommand command = new SqlCommand(queryInsertarBitacora, connection))
                {
                    command.Parameters.AddWithValue("@IdBitacora", idBitacora);
                    command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                    command.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Accion", accion);
                    command.Parameters.AddWithValue("@DatoViejo", datoViejo);
                    command.Parameters.AddWithValue("@DatoNuevo", datoNuevo);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("La tabla Bitacora ha sido actualizada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla Bitacora: " + ex.Message);
            }
        }

        private void ActualizarTablaBitacora2(int idTransaccion, SqlConnection connection)
        {
            try
            {
                // Obtener el siguiente ID de Bitacora
                int idBitacora = ObtenerSiguienteIdBitacora(connection);

                // Detalles para insertar en la tabla Bitacora
                DateTime fechaRegistro = DateTime.Now;
                string usuario = "Cajero"; // Cambia esto según el usuario actual
                string accion = "cambio_boletos";

                // Generar las descripciones de DatoViejo y DatoNuevo
                string datoViejo = GenerarDescripcionAsientos(txtAsientosNuevos.Text, "Libres", int.Parse(txtIdSesionNueva.Text), connection);
                string datoNuevo = GenerarDescripcionAsientos(txtAsientosNuevos.Text, "Ocupados", int.Parse(txtIdSesionNueva.Text), connection);

                // Insertar en la tabla Bitacora
                string queryInsertarBitacora = @"
        INSERT INTO BitacoraTransaccion (IdBitacoraTransaccion, IdTransaccion, FechaRegistro, Usuario, Accion, DatoViejo, DatoNuevo)
        VALUES (@IdBitacora, @IdTransaccion, @FechaRegistro, @Usuario, @Accion, @DatoViejo, @DatoNuevo)";

                using (SqlCommand command = new SqlCommand(queryInsertarBitacora, connection))
                {
                    command.Parameters.AddWithValue("@IdBitacora", idBitacora);
                    command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                    command.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Accion", accion);
                    command.Parameters.AddWithValue("@DatoViejo", datoViejo);
                    command.Parameters.AddWithValue("@DatoNuevo", datoNuevo);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("La tabla Bitacora ha sido actualizada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla Bitacora: " + ex.Message);
            }
        }

        // Método corregido para obtener el siguiente IdBitacora
        private int ObtenerSiguienteIdBitacora(SqlConnection connection)
        {
            int siguienteId = 1;
            string query = "SELECT ISNULL(MAX(IdBitacoraTransaccion), 0) + 1 FROM BitacoraTransaccion";

            // Usar la conexión proporcionada
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


        // Método para obtener el siguiente ID de la transaccion
        private int ObtenerSiguienteIdTransaccion()
        {
            int siguienteId = 1; // Por defecto, empezamos desde 1 si no hay registros

            string query = "SELECT ISNULL(MAX(IdTransaccion), 0) + 1 FROM Transaccion";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        siguienteId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el siguiente ID de la transacción: " + ex.Message);
                }
            }

            return siguienteId;
        }


        // Método para generar Descripcion
        private string GenerarDescripcionAsientos(string asientosText, string estado, int idSesion, SqlConnection connection)
        {
            string query = @"
SELECT Pelicula.Nombre
FROM Sesion
INNER JOIN Pelicula ON Sesion.IdPelicula = Pelicula.IdPelicula
WHERE Sesion.IdSesion = @IdSesion";

            string descripcion = "";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdSesion", idSesion);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string tituloPelicula = reader["Nombre"].ToString(); // Cambiado de "Titulo" a "Nombre"
                        descripcion = $"Estado asientos: {asientosText} = {estado}, de la sesión {idSesion}, película {tituloPelicula}";
                    }
                }
            }
            return descripcion;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el IdTransaccion ingresado
                int idTransaccion = int.Parse(txtIdTrans.Text);

                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Obtener información de la sesión y asientos asociados
                    string query = @"
                SELECT Pelicula.Nombre, Sesion.FechaInicio, Asiento.Fila, Asiento.Numero
                FROM VentaAsiento
                INNER JOIN Sesion ON VentaAsiento.IdSesion = Sesion.IdSesion
                INNER JOIN Pelicula ON Sesion.IdPelicula = Pelicula.IdPelicula
                INNER JOIN Asiento ON VentaAsiento.IdAsiento = Asiento.IdAsiento
                WHERE VentaAsiento.IdTransaccion = @IdTransaccion";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Mostrar los datos en el primer DataGridView
                        dgvDatos.DataSource = dataTable;
                    }

                    // Consulta para obtener todos los asientos y su estado
                    string queryAsientos = @"
            SELECT 
                Asiento.Fila,
                Asiento.Numero,
                CASE WHEN SesionAsiento.Estado = 1 THEN 'Ocupado' ELSE 'Disponible' END AS Estado
            FROM 
                SesionAsiento
            INNER JOIN Asiento ON SesionAsiento.IdAsiento = Asiento.IdAsiento
            WHERE 
                SesionAsiento.IdSesion = (
                    SELECT IdSesion FROM VentaAsiento WHERE IdTransaccion = @IdTransaccion
                )";

                    using (SqlCommand commandAsientos = new SqlCommand(queryAsientos, connection))
                    {
                        commandAsientos.Parameters.AddWithValue("@IdTransaccion", idTransaccion);

                        SqlDataAdapter adapterAsientos = new SqlDataAdapter(commandAsientos);
                        DataTable dataTableAsientos = new DataTable();
                        adapterAsientos.Fill(dataTableAsientos);

                        // Mostrar los asientos con su estado en el segundo DataGridView
                        dgbTodo.DataSource = dataTableAsientos;
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese un IdTransaccion válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los detalles de la sesión y los asientos: " + ex.Message);
            }

        }
    }
}
