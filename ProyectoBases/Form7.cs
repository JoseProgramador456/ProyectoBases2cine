using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace ProyectoBases
{
    public partial class Form7 : Form
    {
        string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Cajero;Password=Marceloco;";

        public Form7()
        {
            InitializeComponent();


            label4.Visible = false; // label5
            label2.Visible = false; // label6
            label3.Visible = false; // label7
            label5.Visible = false; // label1


            cbsesion.Visible = false;
            bpelicula.Visible = false;
            bsesion.Visible = false;
            bcomprar.Visible = false;
            dgbcompraauto.Visible = false;
            LlenarComboBoxSalas();
            txtcantmanual.Visible = false;
            bcantidadmanual.Visible = false;
            cbpelicula.Visible = false;

        }

        private void LlenarComboBoxSalas()
        {
            // Creamos la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT IdSala, Nombre FROM Sala";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Establecemos los datos en el ComboBox
                    cbsala.DataSource = dataTable;
                    cbsala.DisplayMember = "Nombre"; // El campo que quieres mostrar
                    cbsala.ValueMember = "IdSala"; // El campo que usarás como valor
                    cbsala.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void bingresar_Click(object sender, EventArgs e)
        {
            if (cbsala.SelectedIndex >= 0) // Asegurarse de que el usuario haya seleccionado una sala válida
            {
                int idSala = (int)cbsala.SelectedValue;
                LlenarComboBoxPeliculas(idSala);

                // Hacer visible label6 y cbpelicula
                label2.Visible = true;
                cbpelicula.Visible = true;
                bpelicula.Visible = true;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una sala válida.");
            }
        }

        private void LlenarComboBoxPeliculas(int idSala)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT DISTINCT P.IdPelicula, P.Nombre 
                FROM Pelicula P
                JOIN Sesion S ON P.IdPelicula = S.IdPelicula
                WHERE S.IdSala = @IdSala";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdSala", idSala);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Establecemos los datos en el ComboBox
                    cbpelicula.DataSource = dataTable;
                    cbpelicula.DisplayMember = "Nombre"; // Campo que se muestra
                    cbpelicula.ValueMember = "IdPelicula"; // Campo de valor

                    // Seleccionar la opción vacía para que el ComboBox aparezca vacío inicialmente
                    cbpelicula.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No hay sesiones con películas disponibles para la sala seleccionada: " + ex.Message);
                }
            }
        }

        private void bpelicula_Click(object sender, EventArgs e)
        {
            if (cbpelicula.SelectedIndex >= 0) // Verificar que el usuario haya seleccionado una película válida
            {
                int idSala = (int)cbsala.SelectedValue;
                int idPelicula = (int)cbpelicula.SelectedValue;
                LlenarComboBoxSesiones(idSala, idPelicula);

                // Hacer visibles label7, cbsesion, y bsesion
                label3.Visible = true;
                cbsesion.Visible = true;
                bsesion.Visible = true;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una película válida.");
            }
        }

        private void LlenarComboBoxSesiones(int idSala, int idPelicula)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                    SELECT DISTINCT S.IdSesion, CONCAT(S.FechaInicio, ' - ', S.FechaFinal) AS Sesion
                    FROM Sesion S
                    WHERE S.IdSala = @IdSala AND S.IdPelicula = @IdPelicula AND estado = 0";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdSala", idSala);
                    command.Parameters.AddWithValue("@IdPelicula", idPelicula);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Establecemos los datos en el ComboBox
                    cbsesion.DataSource = dataTable;
                    cbsesion.DisplayMember = "Sesion"; // Campo que se muestra
                    cbsesion.ValueMember = "IdSesion"; // Campo de valor

                    // Seleccionar la opción vacía para que el ComboBox aparezca vacío inicialmente
                    cbsesion.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al llenar cbsesion: " + ex.Message);
                }
            }
        }

        private void bsesion_Click(object sender, EventArgs e)
        {
            if (cbsesion.SelectedIndex >= 0) // Verificar que el usuario haya seleccionado una sesión válida
            {
                // Hacer visibles label5, txtcantmanual y bcantidadmanual
                label4.Visible = true;
                txtcantmanual.Visible = true;
                bcantidadmanual.Visible = true;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una sesión válida.");
            }
        }

        private void bcantidadmanual_Click(object sender, EventArgs e)
        {
            bcomprar.Visible = true;
            int cantidadSolicitada;
            if (int.TryParse(txtcantmanual.Text, out cantidadSolicitada) && cantidadSolicitada > 0)
            {
                int idSesion = (int)cbsesion.SelectedValue;
                int idSala = (int)cbsala.SelectedValue; // Obtenemos el IdSala seleccionado en el ComboBox
                // Verificar la disponibilidad de asientos
                int asientosDisponibles = ObtenerCantidadAsientosDisponibles(idSesion);
                if (cantidadSolicitada > asientosDisponibles)
                {
                    MessageBox.Show("Error: La cantidad de asientos solicitada supera los disponibles.");
                    return;
                }

                // Si la cantidad es válida, cargar los asientos disponibles en el DataGridView
                CargarAsientosDisponibles(idSala, idSesion);
                // Actualizar el contador de boletos restantes

            }
            else
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida de asientos.");
            }
        }

        private int ObtenerCantidadAsientosDisponibles(int idSesion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM SesionAsiento WHERE IdSesion = @IdSesion AND Estado = 0";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdSesion", idSesion);
                return (int)command.ExecuteScalar();
            }
        }

        private void CargarAsientosDisponibles(int idSala, int idSesion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                    SELECT A.Fila, A.Numero 
                    FROM Asiento A
                    JOIN SesionAsiento SA ON A.IdAsiento = SA.IdAsiento
                    JOIN Sesion S ON SA.IdSesion = S.IdSesion
                    WHERE S.IdSala = @IdSala 
                    AND S.IdSesion = @IdSesion
                    AND SA.Estado = 0;";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdSala", idSala);
                    command.Parameters.AddWithValue("@IdSesion", idSesion);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgbasientos.DataSource = dataTable; // Asumiendo que este es el DataGridView que muestra los asientos
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los asientos disponibles: " + ex.Message);
                }
            }
        }

        private void bcomprar_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            dgbcompraauto.Visible = true;
            // Verificar si el usuario ingresó una cantidad válida de boletos
            if (int.TryParse(txtcantmanual.Text, out int cantidadBoletos) && cantidadBoletos > 0)
            {
                // Determina el tipo de asignación según si es compra manual o automática
                int idTipoAsignacion = 1; // Compra Automatica"

                // Registrar la transacción en la tabla Transaccion
                int idTransaccion = RegistrarTransaccion(idTipoAsignacion);
                // Obtén los datos necesarios para la compra
                int idSala = (int)cbsala.SelectedValue;
                string nombreSala = cbsala.Text;
                string nombrePelicula = cbpelicula.Text;
                string sesion = cbsesion.Text;
                int idSesion = (int)cbsesion.SelectedValue;
                List<(string fila, int numero)> asientosComprados = new List<(string fila, int numero)>();
                // Lista para almacenar los asientos comprados en orden
                List<DataGridViewRow> filasARemover = new List<DataGridViewRow>();

                // Iterar sobre las filas de dgbasientos para encontrar los primeros asientos disponibles en orden
                foreach (DataGridViewRow row in dgbasientos.Rows)
                {
                    if (row.Cells["Fila"].Value != null && row.Cells["Numero"].Value != null)
                    {
                        string fila = row.Cells["Fila"].Value.ToString();
                        int numero = (int)row.Cells["Numero"].Value;

                        // Agregar el asiento a la lista de asientos comprados
                        asientosComprados.Add((fila, numero));

                        // Agregar la fila a la lista de filas a remover
                        filasARemover.Add(row);

                        // Disminuir el contador de boletos necesarios
                        cantidadBoletos--;

                        // Verificar si ya se compraron todos los boletos necesarios
                        if (cantidadBoletos == 0)
                            break;
                    }
                }

                // Verificar si se compraron todos los boletos requeridos
                if (cantidadBoletos > 0)
                {
                    MessageBox.Show("No hay suficientes asientos disponibles.");
                    return;
                }

                // Remover las filas seleccionadas del dgbasientos
                foreach (var fila in filasARemover)
                {
                    dgbasientos.Rows.Remove(fila);
                }
                // Verificar y agregar columnas si no existen
                if (dgbcompraauto.Columns.Count == 0)
                {
                    dgbcompraauto.Columns.Add("Fila", "Fila");
                    dgbcompraauto.Columns.Add("Numero", "Numero");
                }
                // Mostrar los asientos comprados en dgbcompraauto
                foreach (var asiento in asientosComprados)
                {
                    dgbcompraauto.Rows.Add(asiento.fila, asiento.numero);
                }

                // Actualizar la base de datos para marcar los asientos como comprados
                ActualizarAsientosComprados(asientosComprados);

                MessageBox.Show("Compra automática realizada con éxito.");
                // Llamar al método para registrar en la bitácora
                int idBitacoraTransaccion = ObtenerSiguienteIdBitacora(); // Método para obtener el siguiente ID para la bitácora
                RegistrarCompraEnBitacora(idBitacoraTransaccion, asientosComprados, idSala, nombreSala, nombrePelicula, sesion);
                RegistrarVentaAsientos(nuevoIdTransaccion, asientosComprados, idSesion, siguienteId);
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida de boletos.");
            }
        }

        private void ActualizarAsientosComprados(List<(string fila, int numero)> asientosComprados)
        {
            int idSesion = (int)cbsesion.SelectedValue; // Obtén el IdSesion seleccionado
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var asiento in asientosComprados)
                        {
                            string query = @"UPDATE SesionAsiento
                                     SET Estado = 1
                                     FROM SesionAsiento WITH (UPDLOCK, HOLDLOCK)
                                     INNER JOIN Asiento ON SesionAsiento.IdAsiento = Asiento.IdAsiento
                                     WHERE Asiento.Fila = @Fila AND Asiento.Numero = @Numero AND SesionAsiento.IdSesion = @IdSesion";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Transaction = transaction; // Asigna la transacción al comando
                                command.Parameters.AddWithValue("@Fila", asiento.fila);
                                command.Parameters.AddWithValue("@Numero", asiento.numero);
                                command.Parameters.AddWithValue("@IdSesion", idSesion); // Pasa idSesion como parámetro

                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit(); // Confirma la transacción si todo salió bien
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Revertir todos los cambios si ocurre un error
                        MessageBox.Show("Excepción durante la transacción: " + ex.Message);

                        // Reiniciar completamente el estado del formulario para un nuevo intento de compra
                        label1.Visible = false;
                        cbsala.Visible = false;
                        bingresar.Visible = false;
                        label2.Visible = false;
                        cbpelicula.Visible = false;
                        bpelicula.Visible = false;
                        label3.Visible = false;
                        cbsesion.Visible = false;
                        bsesion.Visible = false;
                        label4.Visible = false;
                        txtcantmanual.Visible = false;
                        bcantidadmanual.Visible = false;
                        bcomprar.Visible = false;
                        label6.Visible = false;
                        dgbcompraauto.Visible = false;
                        dgbasientos.DataSource = null;
                    }
                }
            }
        }


        int nuevoIdTransaccion = 0;
        // Método para insertar una transacción en la tabla Transaccion y obtener el nuevo IdTransaccion
        private int RegistrarTransaccion(int idTipoAsignacion)
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Obtener el siguiente IdTransaccion
                    string queryId = "SELECT ISNULL(MAX(IdTransaccion), 0) + 1 FROM Transaccion";
                    SqlCommand commandId = new SqlCommand(queryId, connection);
                    nuevoIdTransaccion = (int)commandId.ExecuteScalar();

                    // Insertar la nueva transacción
                    string queryInsert = @"
                INSERT INTO Transaccion (IdTransaccion, IdTipoAsignacion, Fecha)
                VALUES (@IdTransaccion, @IdTipoAsignacion, @Fecha)";

                    SqlCommand commandInsert = new SqlCommand(queryInsert, connection);
                    commandInsert.Parameters.AddWithValue("@IdTransaccion", nuevoIdTransaccion);
                    commandInsert.Parameters.AddWithValue("@IdTipoAsignacion", idTipoAsignacion);
                    commandInsert.Parameters.AddWithValue("@Fecha", DateTime.Now.Date);

                    commandInsert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la transacción: " + ex.Message);
                }
            }

            return nuevoIdTransaccion;
        }

        // Método para registrar en la BitacoraTransaccion
        private void RegistrarCompraEnBitacora(int idTransaccion, List<(string fila, int numero)> asientosComprados, int idSala, string nombreSala, string nombrePelicula, string sesion, string usuario = "Cajero")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Formatear datos para los campos DatoViejo y DatoNuevo
                string asientosTexto = string.Join(", ", asientosComprados.Select(a => $"{a.fila}{a.numero}"));
                string datoViejo = $"Estado asientos: {asientosTexto} = libres, de la sala {nombreSala}, película {nombrePelicula}, sesión {sesion}";
                string datoNuevo = $"Estado asientos: {asientosTexto} = ocupados, de la sala {nombreSala}, película {nombrePelicula}, sesión {sesion}";

                // Construimos el comando SQL para BitacoraTransaccion
                string query = @"
            INSERT INTO BitacoraTransaccion (IdBitacoraTransaccion, IdTransaccion, FechaRegistro, Usuario, Accion, DatoViejo, DatoNuevo)
            VALUES (@IdBitacoraTransaccion, @IdTransaccion, @FechaRegistro, @Usuario, @Accion, @DatoViejo, @DatoNuevo)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Obtener el siguiente IdBitacoraTransaccion
                    int idBitacoraTransaccion = ObtenerSiguienteIdBitacora();

                    // Asignar los parámetros
                    command.Parameters.AddWithValue("@IdBitacoraTransaccion", idBitacoraTransaccion);
                    command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                    command.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Accion", "compra_boletos");
                    command.Parameters.AddWithValue("@DatoViejo", datoViejo);
                    command.Parameters.AddWithValue("@DatoNuevo", datoNuevo);

                    // Ejecutar el comando
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para obtener el siguiente IdBitacoraTransaccion
        private int ObtenerSiguienteIdBitacora()
        {
            int siguienteId = 1; // Por defecto, empezamos desde 1 si no hay registros

            string query = "SELECT ISNULL(MAX(IdBitacoraTransaccion), 0) + 1 FROM BitacoraTransaccion";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutamos la consulta y obtenemos el resultado
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        siguienteId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el siguiente ID de la bitácora: " + ex.Message);
                }
            }

            return siguienteId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra Form7 y vuelve a mostrar Form1
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }
         private List<(string fila, int numero)> asientosSeleccionados = new List<(string fila, int numero)>();
        private void RegistrarVentaAsientos(int idTransaccion, List<(string fila, int numero)> asientosComprados, int idSesion, int idventaasiento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO VentaAsiento (IdVentaAsiento, IdTransaccion, IdSesion, IdAsiento)
                VALUES (@IdVentaAsiento, @IdTransaccion, @IdSesion, @IdAsiento)";

                connection.Open();

                foreach (var asiento in asientosComprados)
                {
                    int idAsiento = ObtenerIdAsiento(asiento.fila, asiento.numero, idSesion);

                    if (idAsiento != -1) // Verificar que el asiento existe
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Obtener el siguiente IdVentaAsiento
                            int idVentaAsiento = ObtenerSiguienteIdVentaAsiento();

                            // Asignar los parámetros
                            command.Parameters.AddWithValue("@IdVentaAsiento", siguienteId);
                            command.Parameters.AddWithValue("@IdTransaccion", nuevoIdTransaccion);
                            command.Parameters.AddWithValue("@IdSesion", idSesion);
                            command.Parameters.AddWithValue("@IdAsiento", idAsiento);

                            // Ejecutar la inserción
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"El asiento {asiento.fila}{asiento.numero} no existe en la sesión {idSesion}.");
                    }
                }
            }
        }
        int siguienteId = 5;
        // Método para obtener el siguiente IdVentaAsiento
        private int ObtenerSiguienteIdVentaAsiento()
        {


            string query = "SELECT ISNULL(MAX(IdVentaAsiento), 0) + 1 FROM VentaAsiento";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    siguienteId = Convert.ToInt32(result);
                }
            }

            return siguienteId;
        }

        // Método para obtener el Id del Asiento basado en la fila y el número
        private int ObtenerIdAsiento(string fila, int numero, int idSesion)
        {
            int idAsiento = -1;

            string query = @"
        SELECT a.IdAsiento
        FROM Asiento a
        INNER JOIN SesionAsiento sa ON a.IdAsiento = sa.IdAsiento
        WHERE a.Fila = @Fila AND a.Numero = @Numero AND sa.IdSesion = @IdSesion";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Fila", fila);
                command.Parameters.AddWithValue("@Numero", numero);
                command.Parameters.AddWithValue("@IdSesion", idSesion);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    idAsiento = Convert.ToInt32(result);
                }
            }

            return idAsiento;
        }

    }
}
