using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoBases
{
    public partial class Creacion : Form
    {
        conexion conexion = new conexion();

        Dictionary<string, object> parametros = new Dictionary<string, object>();
        public Creacion()
        {
            InitializeComponent();

            parametros.Add("@BANDERA", "DATOSPELICULA");

            DataTable resultadoPelicula = conexion.EjecutarSPConResultado("SP_OBTENERDATOSVENTANAS", parametros);

            cbClasificacionPelicula.Items.Clear();
            cbNombrePelicula.Items.Clear();
            cbSala.Items.Clear();
            parametros.Clear();

            foreach (DataRow item in resultadoPelicula.Rows)
            {
                cbNombrePelicula.Items.Add(item["Nombre"].ToString());


                string clasificacion = item["TipoClasificacion"].ToString();
                if (!cbClasificacionPelicula.Items.Contains(clasificacion))
                {
                    cbClasificacionPelicula.Items.Add(clasificacion);
                }
            }

            parametros.Add("@BANDERA", "DATOSSALA");

            DataTable resultadoSala = conexion.EjecutarSPConResultado("SP_OBTENERDATOSVENTANAS", parametros);

            foreach (DataRow item in resultadoSala.Rows)
            {
                cbSala.Items.Add(item["Nombre"].ToString());
            }

            if (cbClasificacionPelicula.Items.Count > 0) cbClasificacionPelicula.SelectedIndex = 0;
            if (cbNombrePelicula.Items.Count > 0) cbNombrePelicula.SelectedIndex = 0;
            if (cbSala.Items.Count > 0) cbSala.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private bool LeerYRegistrarCSV(string rutaCSV)
        {
            try
            {
                using (var reader = new StreamReader(rutaCSV))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    // Leer la primera fila como encabezado
                    if (csv.Read())
                    {
                        csv.ReadHeader();
                    }
                    while (csv.Read())
                    {
                        // Lee cada columna del CSV y asúmelo a tus campos de base de datos
                        var columna1 = csv.GetField<string>("FechaHoraInicio");
                        var columna2 = csv.GetField<string>("Sala");
                        var columna3 = csv.GetField<string>("Pelicula");

                        parametros.Clear();

                        parametros.Add("@FECHAINICIODOC", columna1);
                        parametros.Add("@IDSALADOC", columna2);
                        parametros.Add("@IDPELICULADOC", columna3);

                        bool sp = conexion.EjecutarSP("SP_CREARSESIONCSV", parametros);

                        if (!sp)
                        {
                            MessageBox.Show("Se obtuvo un error en la inserción");
                            return false;
                        }
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Se obtuvo un error al leer el archivo");
                return false;
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string validacion = txtDuracion.Text;            
            string pattern = @"^\d+$";

            try
            {
                if (string.IsNullOrWhiteSpace(txtNombrePelicula.Text) || string.IsNullOrWhiteSpace(txtDescripcionPelicula.Text))
                {
                    MessageBox.Show("Error: Se necesita llenar toda la informacion");
                    return;
                }
                if (!Regex.IsMatch(validacion, pattern))
                {
                    MessageBox.Show("La entrada no es válida. Solo se permiten números");
                    return;
                }
                int DuracionPelicula = Convert.ToInt32(txtDuracion.Text);                
                if (DuracionPelicula <= 1 || DuracionPelicula >= 300)
                {
                    MessageBox.Show("Error: La duración de la película debe ser mayor a 1 minuto y menor a 5 horas");
                    return;
                }

                parametros.Clear();

                string NombrePelicula = txtNombrePelicula.Text;
                string ClasifiacionPelicula = cbClasificacionPelicula.Text;
                string Duracion = txtDuracion.Text;
                string Descripcion = txtDescripcionPelicula.Text;

                parametros.Add("@NOMBRE", NombrePelicula);
                parametros.Add("@NOMBRECLASIFICACION", ClasifiacionPelicula);
                parametros.Add("@DURACION", Duracion);
                parametros.Add("@DESCRIPCION", Descripcion);

                bool sp = conexion.EjecutarSP("SP_CREACIONPELICULA", parametros);

                if (sp)
                {
                    MessageBox.Show("Se creo correctamente la pelicula");
                    txtNombrePelicula.Text = "";
                    txtDescripcionPelicula.Text = "";                    
                    this.Close();
                   
                    Creacion nuevoFormulario = new Creacion();
                    nuevoFormulario.Show();
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la accion del boton");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            try
            {
                DateTime fechaSeleccionada = dtFechaInicio.Value;

                if (fechaSeleccionada < DateTime.Now)
                {
                    MessageBox.Show("La fecha seleccionada no puede ser anterior al día de hoy.");
                    return;
                }

                parametros.Clear();

                string NombrePelicula = cbNombrePelicula.Text;
                string NombreSala = cbSala.Text;

                parametros.Add("@FECHAINICIO", fechaSeleccionada);
                parametros.Add("@NOMBRESALA", NombreSala);
                parametros.Add("@NOMBREPELICULA", NombrePelicula);

                bool sp = conexion.EjecutarSP("SP_CREARSESION", parametros);

                if (!sp)
                {
                    MessageBox.Show("Se creo correctamente la sesion");
                    return;
                }
                else
                {
                    MessageBox.Show("Se creo correctamente la sesion");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error en la accion del boton");
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.Title = "Seleccione un archivo CSV";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaCSV = openFileDialog.FileName;

                if (LeerYRegistrarCSV(rutaCSV))
                {
                    MessageBox.Show("Archivo procesado y registrado en la base de datos.");
                }
                else
                {
                    MessageBox.Show("Error: Archivo no procesado en la base de datos.");
                }
            }
        }

        private void Creacion_Load(object sender, EventArgs e)
        {

        }
    }
}
