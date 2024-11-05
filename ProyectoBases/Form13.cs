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
    public partial class Form13 : Form
    {

        private string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Reportes;Password=Colegio;";

        public Form13()
        {
            InitializeComponent();
            CargarSalas();
        }
        private void CargarSalas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Nombre FROM Sala";

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        MessageBox.Show("No se encontraron salas en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    while (reader.Read())
                    {
                        cmbNombreSala.Items.Add(reader["Nombre"].ToString());
                    }



                    if (cmbNombreSala.Items.Count == 0)
                    {
                        MessageBox.Show("No se cargaron nombres en el ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las salas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de la sala seleccionado por el usuario
            string nombreSala = cmbNombreSala.SelectedItem?.ToString();


            if (string.IsNullOrEmpty(nombreSala))
            {
                MessageBox.Show("Por favor, seleccione el nombre de la sala.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                SELECT 
    sa.Nombre AS Sala,
    YEAR(s.FechaInicio) AS Anio,
    MONTH(s.FechaInicio) AS Mes,
    COUNT(DISTINCT s.IdSesion) AS CantidadSesiones,
    ISNULL(AVG(va.TotalAsientos), 0) AS PromedioAsientosOcupados
FROM 
    Sala sa
JOIN 
    Sesion s ON sa.IdSala = s.IdSala
LEFT JOIN (
    SELECT 
        va.IdSesion, 
        COUNT(va.IdAsiento) AS TotalAsientos
    FROM 
        VentaAsiento va
    GROUP BY 
        va.IdSesion
) AS va ON s.IdSesion = va.IdSesion
WHERE 
    sa.Nombre = @NombreSala AND
    s.FechaInicio >= DATEADD(MONTH, -3, GETDATE())
GROUP BY 
    sa.Nombre, 
    YEAR(s.FechaInicio), 
    MONTH(s.FechaInicio)
ORDER BY 
    Anio DESC, 
    Mes DESC;
";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NombreSala", nombreSala);

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron resultados para la sala seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dgvResultados.DataSource = dt;
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
