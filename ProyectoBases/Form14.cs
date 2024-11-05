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
    public partial class Form14 : Form
    {

        private string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Reportes;Password=Colegio;";

        public Form14()
        {
            InitializeComponent();
            CargarSalas();
        }

        private void CargarSalas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT IdSala, Nombre FROM Sala";

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
                        cmbNombreSala.Items.Add(new { Id = reader["IdSala"], Nombre = reader["Nombre"] });
                    }

                    cmbNombreSala.DisplayMember = "Nombre"; // Muestra el nombre en el ComboBox
                    cmbNombreSala.ValueMember = "Id"; // Almacena el ID de la sala
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las salas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscarSesiones_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPorcentaje.Text, out decimal porcentaje))
            {
                MessageBox.Show("Por favor, ingrese un porcentaje válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? idSala = chkGeneral.Checked ? (int?)null : (int)((dynamic)cmbNombreSala.SelectedItem).Id; // Obtener el ID de la sala si no es general
            ObtenerSesionesConMenorOcupacion(idSala, porcentaje);
        }

        private void ObtenerSesionesConMenorOcupacion(int? idSala, decimal porcentaje)
        {
            string query = @"
                SELECT 
                    s.IdSesion,
                    s.FechaInicio,
                    s.FechaFinal,
                    COALESCE(va.Ocupacion, 0) AS AsientosOcupados,
                    sa.CantidadAsiento AS TotalAsientos,
                    (COALESCE(va.Ocupacion, 0) * 100.0 / sa.CantidadAsiento) AS PorcentajeOcupacion
                FROM 
                    Sesion s
                JOIN 
                    Sala sa ON s.IdSala = sa.IdSala
                LEFT JOIN (
                    SELECT 
                        IdSesion, 
                        COUNT(*) AS Ocupacion
                    FROM 
                        VentaAsiento
                    GROUP BY 
                        IdSesion
                ) va ON s.IdSesion = va.IdSesion
                WHERE 
                    (s.IdSala = @IdSala OR @IdSala IS NULL) AND 
                    s.FechaInicio >= DATEADD(MONTH, -3, GETDATE()) AND 
                    (COALESCE(va.Ocupacion, 0) * 100.0 / sa.CantidadAsiento) < @Porcentaje
                ORDER BY 
                    s.FechaInicio ASC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdSala", (object)idSala ?? DBNull.Value); // Si es general, pasa null
                cmd.Parameters.AddWithValue("@Porcentaje", porcentaje);

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron sesiones con ocupación menor al porcentaje especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
