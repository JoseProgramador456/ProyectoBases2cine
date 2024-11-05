using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ProyectoBases
{
    public partial class Form6 : Form
    {
        string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Cajero;Password=Marceloco;";

        public Form6()
        {
            InitializeComponent();

            //label
            label2.Visible = false; // Label 6
            label3.Visible = false; // Label 7
            label4.Visible = false; // Label 5
            label5.Visible = false; // label 2
            label6.Visible = false; // Label 3
            label8.Visible = false; // Label 8

            //Botones
            bcomprar.Visible = false;
            bcantidadmanual.Visible = false;
            bpelicula.Visible = false;
            bsesion.Visible = false;

            //ComboBox
            cbfila.Visible = false;
            cbnumero.Visible = false;
            cbpelicula.Visible = false;
            cbsesion.Visible = false;

            //TextoBox
            txtcantmanual.Visible = false;
            
            //Metodo llenar ComboBox
            LlenarComboBoxSalas();
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

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
                    MessageBox.Show("Error al llenar cbpelicula: " + ex.Message);
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
                WHERE S.IdSala = @IdSala AND S.IdPelicula = @IdPelicula";
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

        private int boletosRestantes;

        private void bcantidadmanual_Click(object sender, EventArgs e)
        {
            int cantidadSolicitada;
            if (int.TryParse(txtcantmanual.Text, out cantidadSolicitada) && cantidadSolicitada > 0)
            {
                int idSesion = (int)cbsesion.SelectedValue;

                // Verificar la disponibilidad de asientos
                int asientosDisponibles = ObtenerCantidadAsientosDisponibles(idSesion);
                if (cantidadSolicitada > asientosDisponibles)
                {
                    MessageBox.Show("Error: La cantidad de asientos solicitada supera los disponibles.");
                    return;
                }

                // Si la cantidad es válida, cargar los asientos disponibles en el DataGridView
                CargarAsientosDisponibles(idSesion);
                // Actualizar el contador de boletos restantes
                label8.Text = $"Cantidad de boletos restantes: {cantidadSolicitada}";
                // Hacer visibles los controles adicionales
                label5.Visible = true;
                label6.Visible = true;
                cbfila.Visible = true;
                cbnumero.Visible = true;
                bcomprar.Visible = true;
                label8.Visible = true;
                // Llenar cbfila con las filas disponibles
                LlenarComboBoxFilas(idSesion);
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

        private void CargarAsientosDisponibles(int idSesion)
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
                WHERE SA.IdSesion = @IdSesion AND SA.Estado = 0";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdSesion", idSesion);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Desvincular y volver a vincular el DataSource para forzar la actualización
                    dgbasientos.DataSource = null;  // Desvincular el DataSource temporalmente
                    dgbasientos.DataSource = dataTable;  // Reatachar el DataSource con los datos actualizados
                    dgbasientos.Refresh();  // Forzar el refresco visual
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar asientos disponibles: " + ex.Message);
                }
            }
        }

        private void LlenarComboBoxFilas(int idSesion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT DISTINCT A.Fila
            FROM Asiento A
            JOIN SesionAsiento SA ON A.IdAsiento = SA.IdAsiento
            WHERE SA.IdSesion = @IdSesion AND SA.Estado = 0";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdSesion", idSesion);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                cbfila.DataSource = dataTable;
                cbfila.DisplayMember = "Fila";
                cbfila.ValueMember = "Fila";
                cbfila.SelectedIndex = -1; // No seleccionar nada al inicio

                // Actualizar cbnumero cada vez que cambia la selección de fila
                cbfila.SelectedIndexChanged += cbfila_SelectedIndexChanged;
            }
        }

        private void cbfila_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbfila.SelectedIndex >= 0)
            {
                string filaSeleccionada = cbfila.SelectedValue.ToString();
                int idSesion = (int)cbsesion.SelectedValue;
                LlenarComboBoxNumeros(idSesion, filaSeleccionada);
            }
        }

        private void LlenarComboBoxNumeros(int idSesion, string fila)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT A.Numero
            FROM Asiento A
            JOIN SesionAsiento SA ON A.IdAsiento = SA.IdAsiento
            WHERE SA.IdSesion = @IdSesion AND A.Fila = @Fila AND SA.Estado = 0";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdSesion", idSesion);
                command.Parameters.AddWithValue("@Fila", fila);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                cbnumero.DataSource = dataTable;
                cbnumero.DisplayMember = "Numero";
                cbnumero.ValueMember = "Numero";
                cbnumero.SelectedIndex = -1; // No seleccionar nada al inicio
            }
        }

        private List<(string fila, int numero)> asientosSeleccionados = new List<(string fila, int numero)>();

        private void bcomprar_Click(object sender, EventArgs e)
        {
            if (cbfila.SelectedIndex >= 0 && cbnumero.SelectedIndex >= 0)
            {
                // Determina el tipo de asignación según si es compra manual o automática
                int idTipoAsignacion = 2; // Compra "

                // Registrar la transacción en la tabla Transaccion
                int idTransaccion = RegistrarTransaccion(idTipoAsignacion);
                string filaSeleccionada = cbfila.SelectedValue.ToString();
                int numeroSeleccionado = (int)cbnumero.SelectedValue;
                int idSesion = (int)cbsesion.SelectedValue;
                int idSala = (int)cbsala.SelectedValue;
                List<(string fila, int numero)> asientosComprados = new List<(string fila, int numero)>();
                string nombreSala = cbsala.Text;
                string nombrePelicula = cbpelicula.Text;
                string sesion = cbsesion.Text;
                // Agregar asiento temporalmente a la lista de selección
                asientosSeleccionados.Add((filaSeleccionada, numeroSeleccionado));

                // Verificamos si hemos alcanzado la cantidad solicitada de boletos
                if (asientosSeleccionados.Count == int.Parse(txtcantmanual.Text))
                {
                    // Intentamos realizar la compra de todos los asientos
                    bool compraExitosa = ConfirmarCompra(idSesion, idSala);

                    if (compraExitosa)
                    {
                        MessageBox.Show("Compra realizada con éxito.");
                        // Llamar al método para registrar en la bitácora
                        int idBitacoraTransaccion = ObtenerSiguienteIdBitacora(); // Método para obtener el siguiente ID para la bitácora
                        RegistrarCompraEnBitacora(idBitacoraTransaccion, asientosComprados, idSala, nombreSala, nombrePelicula, sesion, "");

                        // Remover todos los asientos comprados de la vista, incluyendo el último
                        foreach (var asiento in asientosSeleccionados)
                        {
                            RemoverAsientoDeVista(asiento.fila, asiento.numero);
                        }

                        boletosRestantes = 0; // Reiniciamos el contador ya que se completó la compra
                        label8.Text = $"Cantidad de boletos restantes: {boletosRestantes}";

                        // Limpiar la lista después de remover los asientos de la vista
                        asientosSeleccionados.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error en la compra. Ningún boleto fue comprado.");

                        // Recargar todos los asientos disponibles en dgvasientos
                        CargarAsientosDisponibles(idSesion);

                        // Ocultar los controles en caso de error
                        label5.Visible = false;
                        label6.Visible = false;
                        bcomprar.Visible = false;
                        cbfila.Visible = false;
                        cbnumero.Visible = false;
                        label4.Visible = false;
                        txtcantmanual.Visible = false;
                        bcantidadmanual.Visible = false;
                        label2.Visible = false;
                        cbpelicula.Visible = false;
                        label3.Visible = false;
                        cbsesion.Visible = false;
                        bpelicula.Visible = false;
                        bsesion.Visible = false;
                        label8.Visible = false;
                        label8.Text = "";
                        // Limpiar la lista temporal
                        asientosSeleccionados.Clear();


                    }
                }
                else
                {
                    // Remover el asiento de la vista de forma temporal
                    RemoverAsientoDeVista(filaSeleccionada, numeroSeleccionado);

                    // Actualizar el contador en label8 para reflejar la cantidad de boletos restantes
                    label8.Text = $"Cantidad de boletos restantes: {int.Parse(txtcantmanual.Text) - asientosSeleccionados.Count}";
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila y número de asiento válidos.");
            }
        }

        private void ReiniciarEstadoCompleto(int idSesion)
        {
            // Limpiar el DataGridView y recargar asientos disponibles
            CargarAsientosDisponibles(idSesion);

            // Limpiar la lista de asientos seleccionados
            asientosSeleccionados.Clear();  // Asegurarse de limpiar la lista completamente

            // Reiniciar todos los controles de compra
            txtcantmanual.Clear();
            label8.Text = string.Empty;
            boletosRestantes = 0; // Reiniciar el contador de boletos

            // Ocultar los controles relacionados con la compra
            label8.Visible = false;
            label3.Visible = false;
            cbfila.Visible = false;
            cbnumero.Visible = false;
            bcomprar.Visible = false;
            label6.Visible = false;
            cbpelicula.Visible = false;
            cbsesion.Visible = false;
            txtcantmanual.Visible = false;

            // Resetear los ComboBox y establecerlos en su estado inicial
            cbsala.SelectedIndex = -1; // Reiniciar selección de sala
            cbpelicula.DataSource = null; // Limpiar datos de películas
            cbsesion.DataSource = null; // Limpiar datos de sesiones
            cbfila.DataSource = null; // Limpiar datos de filas
            cbnumero.DataSource = null; // Limpiar datos de números de asiento

            // Mostrar solo el campo de ingreso de sala y su etiqueta
            cbsala.Visible = true;
            label1.Visible = true; // Asumiendo que label1 es la etiqueta de "Ingrese el número de sala"

            // Deshabilitar temporalmente el botón de compra hasta que se ingrese una cantidad válida
            bcomprar.Enabled = false;
        }

               
        private bool ConfirmarCompra(int idSesion, int idSala)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var asiento in asientosSeleccionados)
                        {
                            string query = @"
                            UPDATE SA
                            SET SA.Estado = 1
                            FROM SesionAsiento SA with (Updlock, Holdlock)
                            JOIN Asiento A ON SA.IdAsiento = A.IdAsiento
                            JOIN Sesion S ON SA.IdSesion = S.IdSesion
                            WHERE SA.IdSesion = @IdSesion AND S.IdSala = @IdSala AND A.Fila = @Fila AND A.Numero = @Numero AND SA.Estado = 0 and SA.IdSesion = @IdSesion";

                            SqlCommand command = new SqlCommand(query, connection, transaction);
                            command.Parameters.AddWithValue("@IdSesion", idSesion);
                            command.Parameters.AddWithValue("@IdSala", idSala);
                            command.Parameters.AddWithValue("@Fila", asiento.fila);
                            command.Parameters.AddWithValue("@Numero", asiento.numero);


                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected != 1)
                            {
                                // Mensaje específico si el asiento ya está siendo comprado
                                MessageBox.Show($"El asiento {asiento.fila}{asiento.numero} ya está en proceso de compra por otro usuario. Intenta con otro asiento.", "Asiento ocupado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                throw new Exception("Asiento en proceso de compra por otro usuario.");
                            }
                        }

                        // Confirmar la transacción solo si todos los asientos se actualizaron correctamente
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Revertir todos los cambios si ocurre un error
                        MessageBox.Show("Excepción durante la transacción: " + ex.Message);

                        // Reiniciar completamente el estado del formulario para un nuevo intento de compra
                        ReiniciarEstadoCompleto(idSesion);
                        return false;
                    }
                }
            }
        }


        private void RemoverAsientoDeVista(string fila, int numero)
        {
            foreach (DataGridViewRow row in dgbasientos.Rows)
            {
                // Verificar que las celdas no sean nulas
                if (row.Cells["Fila"].Value != null && row.Cells["Numero"].Value != null)
                {
                    if (row.Cells["Fila"].Value.ToString() == fila && (int)row.Cells["Numero"].Value == numero)
                    {
                        dgbasientos.Rows.Remove(row);
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra Form6 y vuelve a mostrar Form1
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private int RegistrarTransaccion(int idTipoAsignacion)
        {
            int nuevoIdTransaccion = 0;

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

                // Crear descripciones detalladas para cada asiento comprado
                string asientosTextoViejo = string.Join(", ", asientosSeleccionados.Select(a => $"{a.fila}{a.numero} = libre"));
                string asientosTextoNuevo = string.Join(", ", asientosSeleccionados.Select(a => $"{a.fila}{a.numero} = ocupado"));

                string datoViejo = $"Estado asientos: {asientosTextoViejo}, de la sala {nombreSala}, película {nombrePelicula}, sesión {sesion}";
                string datoNuevo = $"Estado asientos: {asientosTextoNuevo}, de la sala {nombreSala}, película {nombrePelicula}, sesión {sesion}";

                // Mensaje de depuración para verificar los datos antes de insertar
                MessageBox.Show($"DatoViejo: {datoViejo}\nDatoNuevo: {datoNuevo}", "Valores de DatoViejo y DatoNuevo");

                // Construimos el comando SQL
                string query = @"
        INSERT INTO BitacoraTransaccion (IdBitacoraTransaccion, IdTransaccion, FechaRegistro, Usuario, Accion, DatoViejo, DatoNuevo)
        VALUES (@IdBitacoraTransaccion, @IdTransaccion, @FechaRegistro, @Usuario, @Accion, @DatoViejo, @DatoNuevo)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
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
        private void RegistrarVentaAsientos(int idTransaccion, List<(string fila, int numero)> asientosComprados, int idSesion)
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
                            int idVentaAsiento = ObtenerSiguienteIdVentaAsiento();

                            // Asignar los parámetros
                            command.Parameters.AddWithValue("@IdVentaAsiento", idVentaAsiento);
                            command.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
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

        // Método para obtener el siguiente IdVentaAsiento
        private int ObtenerSiguienteIdVentaAsiento()
        {
            int siguienteId = 1;

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

