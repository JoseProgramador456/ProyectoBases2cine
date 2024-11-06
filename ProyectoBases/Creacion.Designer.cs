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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Creacion));
            this.OpcionesCreacion = new System.Windows.Forms.TabControl();
            this.Pelicula = new System.Windows.Forms.TabPage();
            this.txtDuracion = new System.Windows.Forms.TextBox();
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
            this.OpcionesCreacion.SuspendLayout();
            this.Pelicula.SuspendLayout();
            this.Sesion.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpcionesCreacion
            // 
            this.OpcionesCreacion.Controls.Add(this.Pelicula);
            this.OpcionesCreacion.Controls.Add(this.Sesion);
            this.OpcionesCreacion.Location = new System.Drawing.Point(9, 8);
            this.OpcionesCreacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpcionesCreacion.Name = "OpcionesCreacion";
            this.OpcionesCreacion.SelectedIndex = 0;
            this.OpcionesCreacion.Size = new System.Drawing.Size(310, 290);
            this.OpcionesCreacion.TabIndex = 0;
            // 
            // Pelicula
            // 
            this.Pelicula.BackColor = System.Drawing.SystemColors.ControlText;
            this.Pelicula.Controls.Add(this.txtDuracion);
            this.Pelicula.Controls.Add(this.txtDescripcionPelicula);
            this.Pelicula.Controls.Add(this.button1);
            this.Pelicula.Controls.Add(this.label4);
            this.Pelicula.Controls.Add(this.label3);
            this.Pelicula.Controls.Add(this.cbClasificacionPelicula);
            this.Pelicula.Controls.Add(this.label2);
            this.Pelicula.Controls.Add(this.txtNombrePelicula);
            this.Pelicula.Controls.Add(this.label1);
            this.Pelicula.Location = new System.Drawing.Point(4, 22);
            this.Pelicula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Pelicula.Name = "Pelicula";
            this.Pelicula.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Pelicula.Size = new System.Drawing.Size(302, 264);
            this.Pelicula.TabIndex = 0;
            this.Pelicula.Text = "Pelicula";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(64, 72);
            this.txtDuracion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(76, 20);
            this.txtDuracion.TabIndex = 11;
            // 
            // txtDescripcionPelicula
            // 
            this.txtDescripcionPelicula.Location = new System.Drawing.Point(4, 115);
            this.txtDescripcionPelicula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescripcionPelicula.Multiline = true;
            this.txtDescripcionPelicula.Name = "txtDescripcionPelicula";
            this.txtDescripcionPelicula.Size = new System.Drawing.Size(188, 116);
            this.txtDescripcionPelicula.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 232);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(4, 99);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(4, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Duracion";
            // 
            // cbClasificacionPelicula
            // 
            this.cbClasificacionPelicula.FormattingEnabled = true;
            this.cbClasificacionPelicula.Location = new System.Drawing.Point(78, 42);
            this.cbClasificacionPelicula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbClasificacionPelicula.Name = "cbClasificacionPelicula";
            this.cbClasificacionPelicula.Size = new System.Drawing.Size(114, 21);
            this.cbClasificacionPelicula.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Clasificacion";
            // 
            // txtNombrePelicula
            // 
            this.txtNombrePelicula.Location = new System.Drawing.Point(57, 11);
            this.txtNombrePelicula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombrePelicula.MaxLength = 100;
            this.txtNombrePelicula.Name = "txtNombrePelicula";
            this.txtNombrePelicula.Size = new System.Drawing.Size(135, 20);
            this.txtNombrePelicula.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // Sesion
            // 
            this.Sesion.BackColor = System.Drawing.SystemColors.ControlText;
            this.Sesion.Controls.Add(this.button3);
            this.Sesion.Controls.Add(this.button2);
            this.Sesion.Controls.Add(this.cbNombrePelicula);
            this.Sesion.Controls.Add(this.label8);
            this.Sesion.Controls.Add(this.label6);
            this.Sesion.Controls.Add(this.dtFechaInicio);
            this.Sesion.Controls.Add(this.cbSala);
            this.Sesion.Controls.Add(this.label5);
            this.Sesion.Location = new System.Drawing.Point(4, 22);
            this.Sesion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Sesion.Name = "Sesion";
            this.Sesion.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Sesion.Size = new System.Drawing.Size(302, 264);
            this.Sesion.TabIndex = 1;
            this.Sesion.Text = "Sesion";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(96, 102);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 26);
            this.button3.TabIndex = 9;
            this.button3.Text = "Cargar CSV";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(96, 228);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 22);
            this.button2.TabIndex = 8;
            this.button2.Text = "Crear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // cbNombrePelicula
            // 
            this.cbNombrePelicula.FormattingEnabled = true;
            this.cbNombrePelicula.Location = new System.Drawing.Point(53, 67);
            this.cbNombrePelicula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbNombrePelicula.Name = "cbNombrePelicula";
            this.cbNombrePelicula.Size = new System.Drawing.Size(114, 21);
            this.cbNombrePelicula.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(4, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Pelicula";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(4, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Fecha y Hora Inicio";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaInicio.Location = new System.Drawing.Point(110, 9);
            this.dtFechaInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(170, 20);
            this.dtFechaInicio.TabIndex = 2;
            this.dtFechaInicio.Value = new System.DateTime(2024, 10, 18, 11, 26, 43, 0);
            // 
            // cbSala
            // 
            this.cbSala.FormattingEnabled = true;
            this.cbSala.Location = new System.Drawing.Point(37, 37);
            this.cbSala.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSala.Name = "cbSala";
            this.cbSala.Size = new System.Drawing.Size(131, 21);
            this.cbSala.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(4, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sala";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Creacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(328, 309);
            this.Controls.Add(this.OpcionesCreacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Creacion";
            this.Text = "Creacion";
            this.Load += new System.EventHandler(this.Creacion_Load);
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