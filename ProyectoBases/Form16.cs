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
    public partial class Form16 : Form
    {

        private string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Reportes;Password=Colegio;";

        public Form16()
        {
            InitializeComponent();
        }

        private void btnCargarLogs_Click(object sender, EventArgs e)
        {
            //holandita
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llama a la función para obtener logs de transacciones
            ObtenerLogTransacciones(fechaInicio, fechaFin);
           
        }

        private void ObtenerLogTransacciones(DateTime fechaInicio, DateTime fechaFin)
        {
            string query = @"
    SELECT 
        va.IdVentaAsiento AS IdVenta,
        va.IdSesion,
        t.Fecha AS FechaTransaccion, -- Usar la fecha de la tabla Transaccion
        s.FechaInicio,
        s.FechaFinal,
        p.Nombre AS TituloPelicula,
        p.Duracion,
        COUNT(va.IdAsiento) AS CantidadAsientos
    FROM 
        VentaAsiento va
    JOIN 
        Sesion s ON va.IdSesion = s.IdSesion
    JOIN 
        Pelicula p ON s.IdPelicula = p.IdPelicula
    JOIN 
        Transaccion t ON va.IdTransaccion = t.IdTransaccion -- Unir con la tabla Transaccion
    WHERE 
        t.Fecha >= @FechaInicio AND t.Fecha <= @FechaFin -- Filtrar por la fecha de la transacción
    GROUP BY 
        va.IdVentaAsiento, va.IdSesion, t.Fecha, s.FechaInicio, s.FechaFinal, p.Nombre, p.Duracion
    ORDER BY 
        t.Fecha DESC;"; // Ordenar por la fecha de la transacción

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron registros de transacciones para las fechas seleccionadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvResultados.DataSource = dt;
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error en la base de datos: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos de las transacciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
