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
    public partial class Form2 : Form
    {
        string connectionString = $"Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Usuario;Password=Comunidad;";
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = comboBox1.SelectedItem.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    conn.Open();

                    // Consultar los datos de la tabla seleccionada
                    string query = $"SELECT * FROM {selectedTable}";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Mostrar los datos en el DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Manejar errores, como nombres de tablas incorrectos o problemas de conexión
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
