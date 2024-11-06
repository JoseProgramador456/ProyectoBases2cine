using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProyectoBases
{
    public partial class Form1 : Form
    {
        public class LoginHelper
        {
            private string connectionString = "Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=Usuario;Password=Comunidad;";

            public bool IniciarSesion(string nombreUsuario, string contraseñaIngresada)
            {
                // Generar el hash de la contraseña ingresada
                string contraseñaIngresadaHash = HashPassword(contraseñaIngresada);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM Usuario WHERE NombreUsuario = @nombreUsuario AND ContraseñaHash = @contraseñaHash";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@contraseñaHash", contraseñaIngresadaHash);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count == 1; // Devuelve true si encontró un usuario que coincida
                }
            }

            private string HashPassword(string password)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        builder.Append(b.ToString("x2")); // Convierte cada byte a hexadecimal
                    }
                    return builder.ToString();
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            txtContrasenia.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //el chavo es mejor que breaking bad
            string usuario = txtUsuario.Text;
            string contraseña= txtContrasenia.Text;
            // Crear una instancia de LoginHelper
            LoginHelper loginHelper = new LoginHelper();

            // Llamar al método IniciarSesion para validar el usuario y la contraseña
            if (loginHelper.IniciarSesion(usuario, contraseña))
            {
                MessageBox.Show("Inicio de sesión exitoso.");

                // Aquí puedes abrir el formulario correspondiente según el rol del usuario
                AbrirFormularioPorRol(usuario);
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }

        } 
        private void AbrirFormularioPorRol(string nombreUsuario)
{
    // Aquí puedes obtener el rol del usuario desde la base de datos y abrir el formulario adecuado
    using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-98VGFST\\SQLEXPRESS;Initial Catalog=ProyectoCine;User ID=" +txtUsuario.Text+";"+"Password="+txtContrasenia.Text+";"))
    {
        connection.Open();
        string query = "SELECT Rol FROM Usuario WHERE NombreUsuario = @nombreUsuario";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

        string rol = command.ExecuteScalar() as string;

        if (rol == "Admin")
        {
            // Abre el formulario para el administrador
            Form4 form4 = new Form4();
                    form4.Show();
        }
        else if (rol == "Cajero")
        {
                    // Abre el formulario para el cajero
                    Form3 Form3= new Form3();
                    Form3.Show();
        }
        else if (nombreUsuario == "Usuario")
        {
                    // Abre el formulario para el usuario
                    Form2 Form2 = new Form2();
                    Form2.Show();
        }
        else if (nombreUsuario == "Reportes")
        {
                    // Abre el formulario para el usuario
                    Form10 Form10 = new Form10();
                    Form10.Show();
        }

        // Ocultar el formulario de inicio de sesión
        this.Hide();
    }
}
    }
}
