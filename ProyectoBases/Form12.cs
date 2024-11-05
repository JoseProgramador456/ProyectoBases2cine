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
    public partial class Form12 : Form
    {
        string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Reportes;Password=Colegio;";
        public Form12()
        {
            InitializeComponent();
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            string query = @"
    SELECT 
        t.IdTransaccion, 
        t.Fecha, 
        ta.Tipo AS TipoAsignacion,
        s.IdSesion, 
        p.Nombre AS Pelicula, 
        s.FechaInicio, 
        s.FechaFinal, 
        sa.Nombre AS Sala, 
        COUNT(va.IdAsiento) AS AsientosOcupados
    FROM Transaccion t
    LEFT JOIN TipoAsignacion ta ON t.IdTipoAsignacion = ta.IdTipoAsignacion
    LEFT JOIN VentaAsiento va ON t.IdTransaccion = va.IdTransaccion
    LEFT JOIN Sesion s ON va.IdSesion = s.IdSesion
    LEFT JOIN Pelicula p ON s.IdPelicula = p.IdPelicula
    LEFT JOIN Sala sa ON s.IdSala = sa.IdSala
    GROUP BY 
        t.IdTransaccion, 
        t.Fecha, 
        ta.Tipo, 
        s.IdSesion, 
        p.Nombre, 
        s.FechaInicio, 
        s.FechaFinal, 
        sa.Nombre;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtTransactions = new DataTable();
                    adapter.Fill(dtTransactions);
                    dgvTransacciones.DataSource = dtTransactions; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void btnGenerarTransacciones_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Consulta para obtener las transacciones dentro del rango de fechas
            string query = @"
        SELECT 
            t.IdTransaccion, 
            t.Fecha, 
            ta.Tipo AS TipoAsignacion,
            s.IdSesion, 
            p.Nombre AS Pelicula, 
            s.FechaInicio, 
            s.FechaFinal, 
            sa.Nombre AS Sala, 
            COUNT(va.IdAsiento) AS AsientosOcupados
        FROM Transaccion t
        LEFT JOIN TipoAsignacion ta ON t.IdTipoAsignacion = ta.IdTipoAsignacion
        LEFT JOIN VentaAsiento va ON t.IdTransaccion = va.IdTransaccion
        LEFT JOIN Sesion s ON va.IdSesion = s.IdSesion
        LEFT JOIN Pelicula p ON s.IdPelicula = p.IdPelicula
        LEFT JOIN Sala sa ON s.IdSala = sa.IdSala
        WHERE t.Fecha BETWEEN @FechaInicio AND @FechaFin
        GROUP BY 
            t.IdTransaccion, 
            t.Fecha, 
            ta.Tipo, 
            s.IdSesion, 
            p.Nombre, 
            s.FechaInicio, 
            s.FechaFinal, 
            sa.Nombre;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@FechaFin", fechaFin);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dgvTransacciones.DataSource = dataTable;

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron transacciones en el rango de fechas especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message + "\nConsulta: " + query, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
