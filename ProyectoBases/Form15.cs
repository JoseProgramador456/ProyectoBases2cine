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
    public partial class Form15 : Form
    {

        private string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Reportes;Password=Colegio;";

        public Form15()
        {
            InitializeComponent();
        }

        private void btnBuscarTop5_Click(object sender, EventArgs e)
        {
            ObtenerTop5Peliculas();
        }
        private void ObtenerTop5Peliculas()
        {
            string query = @"
        SELECT TOP 5 
            p.IdPelicula,
            p.Nombre AS Titulo,
            AVG(COALESCE(va.Ocupacion, 0)) AS PromedioAsientosVendidos
        FROM 
            Pelicula p
        JOIN 
            Sesion s ON p.IdPelicula = s.IdPelicula
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
            s.FechaInicio >= DATEADD(MONTH, -3, GETDATE())
        GROUP BY 
            p.IdPelicula, p.Nombre
        ORDER BY 
            PromedioAsientosVendidos DESC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron datos para el último trimestre.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvResultados.DataSource = dt;
                    }
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
