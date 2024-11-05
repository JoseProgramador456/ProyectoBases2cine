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
    public partial class Form11 : Form
    {
        string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Reportes;Password=Colegio;";
       
        public Form11()
        {
            InitializeComponent();
            LoadSessions();
        }

        private void LoadSessions()
        {
            // Método para cargar sesiones por defecto y obtener las fechas disponibles
            string querySessions = "SELECT s.IdSesion, p.Nombre AS Pelicula, s.FechaInicio, s.FechaFinal, sa.Nombre AS Sala, COUNT(va.IdAsiento) AS AsientosOcupados " +
                                   "FROM Sesion s " +
                                   "JOIN Pelicula p ON s.IdPelicula = p.IdPelicula " +
                                   "JOIN Sala sa ON s.IdSala = sa.IdSala " +
                                   "LEFT JOIN VentaAsiento va ON s.IdSesion = va.IdSesion " +
                                   "GROUP BY s.IdSesion, p.Nombre, s.FechaInicio, s.FechaFinal, sa.Nombre"; // Consulta para obtener todas las sesiones con asientos ocupados

            string queryDates = "SELECT MIN(FechaInicio) AS MinFecha, MAX(FechaFinal) AS MaxFecha FROM Sesion"; // Consulta para obtener fechas mínimas y máximas

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Cargar sesiones
                SqlCommand cmdSessions = new SqlCommand(querySessions, conn);
                SqlDataAdapter adapterSessions = new SqlDataAdapter(cmdSessions);
                DataTable dtSessions = new DataTable();
                adapterSessions.Fill(dtSessions);
                dgvSesiones.DataSource = dtSessions; 

                // Cargar fechas mínimas y máximas
                SqlCommand cmdDates = new SqlCommand(queryDates, conn);
                SqlDataReader reader = cmdDates.ExecuteReader();

                if (reader.Read())
                {
                    DateTime minFecha = reader.IsDBNull(0) ? DateTime.Now : reader.GetDateTime(0); // Fecha mínima
                    DateTime maxFecha = reader.IsDBNull(1) ? DateTime.Now : reader.GetDateTime(1); // Fecha máxima

                    dtpFechaInicio.Value = minFecha; // Establecer fecha de inicio en el DateTimePicker
                    dtpFechaFin.Value = maxFecha; // Establecer fecha de fin en el DateTimePicker
                }
                reader.Close();
            }
        }


        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            // Obtener el rango de fechas y horas del usuario
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;

            // Validar que la fecha de inicio no sea mayor a la fecha de fin
            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Consulta para obtener las sesiones dentro del rango de fechas
            string query = @"
               SELECT s.IdSesion, p.Nombre AS Pelicula, s.FechaInicio, s.FechaFinal, sa.Nombre AS Sala, 
               COUNT(va.IdAsiento) AS AsientosOcupados
               FROM Sesion s
               JOIN Pelicula p ON s.IdPelicula = p.IdPelicula
               JOIN Sala sa ON s.IdSala = sa.IdSala
               LEFT JOIN VentaAsiento va ON s.IdSesion = va.IdSesion
               WHERE s.FechaInicio BETWEEN @FechaInicio AND @FechaFin
               GROUP BY s.IdSesion, p.Nombre, s.FechaInicio, s.FechaFinal, sa.Nombre";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@FechaFin", fechaFin);

                // Ejecutar la consulta y llenar el DataGridView
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dgvSesiones.DataSource = dataTable; // Actualizar el DataGridView con las sesiones filtradas
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }
    }
}
