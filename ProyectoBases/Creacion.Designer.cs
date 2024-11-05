using System.Drawing;
using System.Windows.Forms;
using System;

namespace ProyectoBases
{
    partial class Creacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpcionesCreacion = new System.Windows.Forms.TabControl();
            this.Pelicula = new System.Windows.Forms.TabPage();
            this.txtDescripcionPelicula = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClasificacionPelicula = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombrePelicula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Sesion = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbNombrePelicula = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cbSala = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.OpcionesCreacion.SuspendLayout();
            this.Pelicula.SuspendLayout();
            this.Sesion.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpcionesCreacion
            // 
            this.OpcionesCreacion.Controls.Add(this.Pelicula);
            this.OpcionesCreacion.Controls.Add(this.Sesion);
            this.OpcionesCreacion.Location = new System.Drawing.Point(12, 10);
            this.OpcionesCreacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpcionesCreacion.Name = "OpcionesCreacion";
            this.OpcionesCreacion.SelectedIndex = 0;
            this.OpcionesCreacion.Size = new System.Drawing.Size(413, 341);
            this.OpcionesCreacion.TabIndex = 0;
            // 
            // Pelicula
            // 
            this.Pelicula.Controls.Add(this.txtDuracion);
            this.Pelicula.Controls.Add(this.txtDescripcionPelicula);
            this.Pelicula.Controls.Add(this.button1);
            this.Pelicula.Controls.Add(this.label4);
            this.Pelicula.Controls.Add(this.label3);
            this.Pelicula.Controls.Add(this.cbClasificacionPelicula);
            this.Pelicula.Controls.Add(this.label2);
            this.Pelicula.Controls.Add(this.txtNombrePelicula);
            this.Pelicula.Controls.Add(this.label1);
            this.Pelicula.Location = new System.Drawing.Point(4, 25);
            this.Pelicula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pelicula.Name = "Pelicula";
            this.Pelicula.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pelicula.Size = new System.Drawing.Size(405, 312);
            this.Pelicula.TabIndex = 0;
            this.Pelicula.Text = "Pelicula";
            this.Pelicula.UseVisualStyleBackColor = true;
            // 
            // txtDescripcionPelicula
            // 
            this.txtDescripcionPelicula.Location = new System.Drawing.Point(6, 141);
            this.txtDescripcionPelicula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcionPelicula.Multiline = true;
            this.txtDescripcionPelicula.Name = "txtDescripcionPelicula";
            this.txtDescripcionPelicula.Size = new System.Drawing.Size(249, 142);
            this.txtDescripcionPelicula.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 286);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Duracion";
            // 
            // cbClasificacionPelicula
            // 
            this.cbClasificacionPelicula.FormattingEnabled = true;
            this.cbClasificacionPelicula.Location = new System.Drawing.Point(104, 52);
            this.cbClasificacionPelicula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbClasificacionPelicula.Name = "cbClasificacionPelicula";
            this.cbClasificacionPelicula.Size = new System.Drawing.Size(151, 24);
            this.cbClasificacionPelicula.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Clasificacion";
            // 
            // txtNombrePelicula
            // 
            this.txtNombrePelicula.Location = new System.Drawing.Point(76, 14);
            this.txtNombrePelicula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombrePelicula.MaxLength = 100;
            this.txtNombrePelicula.Name = "txtNombrePelicula";
            this.txtNombrePelicula.Size = new System.Drawing.Size(179, 22);
            this.txtNombrePelicula.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // Sesion
            // 
            this.Sesion.Controls.Add(this.button3);
            this.Sesion.Controls.Add(this.button2);
            this.Sesion.Controls.Add(this.cbNombrePelicula);
            this.Sesion.Controls.Add(this.label8);
            this.Sesion.Controls.Add(this.label6);
            this.Sesion.Controls.Add(this.dtFechaInicio);
            this.Sesion.Controls.Add(this.cbSala);
            this.Sesion.Controls.Add(this.label5);
            this.Sesion.Location = new System.Drawing.Point(4, 25);
            this.Sesion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Sesion.Name = "Sesion";
            this.Sesion.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Sesion.Size = new System.Drawing.Size(405, 312);
            this.Sesion.TabIndex = 1;
            this.Sesion.Text = "Sesion";
            this.Sesion.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(128, 126);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Cargar CSV";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 286);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Crear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // cbNombrePelicula
            // 
            this.cbNombrePelicula.FormattingEnabled = true;
            this.cbNombrePelicula.Location = new System.Drawing.Point(71, 82);
            this.cbNombrePelicula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbNombrePelicula.Name = "cbNombrePelicula";
            this.cbNombrePelicula.Size = new System.Drawing.Size(151, 24);
            this.cbNombrePelicula.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Pelicula";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Fecha y Hora Inicio";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaInicio.Location = new System.Drawing.Point(147, 11);
            this.dtFechaInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(226, 22);
            this.dtFechaInicio.TabIndex = 2;
            this.dtFechaInicio.Value = new System.DateTime(2024, 10, 18, 11, 26, 43, 0);
            // 
            // cbSala
            // 
            this.cbSala.FormattingEnabled = true;
            this.cbSala.Location = new System.Drawing.Point(49, 46);
            this.cbSala.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSala.Name = "cbSala";
            this.cbSala.Size = new System.Drawing.Size(173, 24);
            this.cbSala.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sala";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(86, 88);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(100, 22);
            this.txtDuracion.TabIndex = 11;
            // 
            // Creacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 360);
            this.Controls.Add(this.OpcionesCreacion);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Creacion";
            this.Text = "Creacion";
            this.OpcionesCreacion.ResumeLayout(false);
            this.Pelicula.ResumeLayout(false);
            this.Pelicula.PerformLayout();
            this.Sesion.ResumeLayout(false);
            this.Sesion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl OpcionesCreacion;
        private TabPage Pelicula;
        private TabPage Sesion;
        private Label label1;
        private ComboBox cbClasificacionPelicula;
        private Label label2;
        private TextBox txtNombrePelicula;
        private Label label4;
        private Label label3;
        private Button button1;
        private TextBox txtDescripcionPelicula;
        private ComboBox cbSala;
        private Label label5;
        private Label label6;
        private DateTimePicker dtFechaInicio;
        private Button button2;
        private ComboBox cbNombrePelicula;
        private Label label8;
        private Button button3;
        private OpenFileDialog openFileDialog1;
        private TextBox txtDuracion;
    }
}