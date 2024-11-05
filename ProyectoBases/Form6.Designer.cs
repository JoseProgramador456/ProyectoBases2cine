namespace ProyectoBases
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbsala = new System.Windows.Forms.ComboBox();
            this.cbpelicula = new System.Windows.Forms.ComboBox();
            this.cbsesion = new System.Windows.Forms.ComboBox();
            this.cbfila = new System.Windows.Forms.ComboBox();
            this.cbnumero = new System.Windows.Forms.ComboBox();
            this.txtcantmanual = new System.Windows.Forms.TextBox();
            this.dgbasientos = new System.Windows.Forms.DataGridView();
            this.bingresar = new System.Windows.Forms.Button();
            this.bpelicula = new System.Windows.Forms.Button();
            this.bsesion = new System.Windows.Forms.Button();
            this.bcantidadmanual = new System.Windows.Forms.Button();
            this.bcomprar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgbasientos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el número de sala:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(16, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione la película";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(16, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seleccione la función:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(16, 218);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ingrese la cantidad de boletos a comprar: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(16, 293);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ingrese la fila del asiento a comprar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(16, 362);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ingrese el número del asiento a comprar:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(393, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "CINEPABLO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 284);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "label8";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cbsala
            // 
            this.cbsala.FormattingEnabled = true;
            this.cbsala.Location = new System.Drawing.Point(19, 52);
            this.cbsala.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbsala.Name = "cbsala";
            this.cbsala.Size = new System.Drawing.Size(98, 21);
            this.cbsala.TabIndex = 8;
            // 
            // cbpelicula
            // 
            this.cbpelicula.FormattingEnabled = true;
            this.cbpelicula.Location = new System.Drawing.Point(19, 116);
            this.cbpelicula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbpelicula.Name = "cbpelicula";
            this.cbpelicula.Size = new System.Drawing.Size(131, 21);
            this.cbpelicula.TabIndex = 9;
            // 
            // cbsesion
            // 
            this.cbsesion.FormattingEnabled = true;
            this.cbsesion.Location = new System.Drawing.Point(18, 179);
            this.cbsesion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbsesion.Name = "cbsesion";
            this.cbsesion.Size = new System.Drawing.Size(203, 21);
            this.cbsesion.TabIndex = 10;
            // 
            // cbfila
            // 
            this.cbfila.FormattingEnabled = true;
            this.cbfila.Location = new System.Drawing.Point(18, 325);
            this.cbfila.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbfila.Name = "cbfila";
            this.cbfila.Size = new System.Drawing.Size(142, 21);
            this.cbfila.TabIndex = 12;
            this.cbfila.SelectedIndexChanged += new System.EventHandler(this.cbfila_SelectedIndexChanged);
            // 
            // cbnumero
            // 
            this.cbnumero.FormattingEnabled = true;
            this.cbnumero.Location = new System.Drawing.Point(18, 392);
            this.cbnumero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbnumero.Name = "cbnumero";
            this.cbnumero.Size = new System.Drawing.Size(142, 21);
            this.cbnumero.TabIndex = 13;
            // 
            // txtcantmanual
            // 
            this.txtcantmanual.Location = new System.Drawing.Point(18, 249);
            this.txtcantmanual.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtcantmanual.Multiline = true;
            this.txtcantmanual.Name = "txtcantmanual";
            this.txtcantmanual.Size = new System.Drawing.Size(84, 22);
            this.txtcantmanual.TabIndex = 14;
            // 
            // dgbasientos
            // 
            this.dgbasientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbasientos.Location = new System.Drawing.Point(302, 52);
            this.dgbasientos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgbasientos.Name = "dgbasientos";
            this.dgbasientos.RowHeadersWidth = 72;
            this.dgbasientos.RowTemplate.Height = 31;
            this.dgbasientos.Size = new System.Drawing.Size(265, 428);
            this.dgbasientos.TabIndex = 15;
            // 
            // bingresar
            // 
            this.bingresar.Location = new System.Drawing.Point(136, 52);
            this.bingresar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bingresar.Name = "bingresar";
            this.bingresar.Size = new System.Drawing.Size(60, 23);
            this.bingresar.TabIndex = 16;
            this.bingresar.Text = "Ingresar";
            this.bingresar.UseVisualStyleBackColor = true;
            this.bingresar.Click += new System.EventHandler(this.bingresar_Click);
            // 
            // bpelicula
            // 
            this.bpelicula.Location = new System.Drawing.Point(161, 116);
            this.bpelicula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bpelicula.Name = "bpelicula";
            this.bpelicula.Size = new System.Drawing.Size(60, 23);
            this.bpelicula.TabIndex = 17;
            this.bpelicula.Text = "Ingresar";
            this.bpelicula.UseVisualStyleBackColor = true;
            this.bpelicula.Click += new System.EventHandler(this.bpelicula_Click);
            // 
            // bsesion
            // 
            this.bsesion.Location = new System.Drawing.Point(225, 179);
            this.bsesion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bsesion.Name = "bsesion";
            this.bsesion.Size = new System.Drawing.Size(60, 23);
            this.bsesion.TabIndex = 18;
            this.bsesion.Text = "Ingresar";
            this.bsesion.UseVisualStyleBackColor = true;
            this.bsesion.Click += new System.EventHandler(this.bsesion_Click);
            // 
            // bcantidadmanual
            // 
            this.bcantidadmanual.Location = new System.Drawing.Point(120, 249);
            this.bcantidadmanual.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bcantidadmanual.Name = "bcantidadmanual";
            this.bcantidadmanual.Size = new System.Drawing.Size(60, 23);
            this.bcantidadmanual.TabIndex = 19;
            this.bcantidadmanual.Text = "Ingresar";
            this.bcantidadmanual.UseVisualStyleBackColor = true;
            this.bcantidadmanual.Click += new System.EventHandler(this.bcantidadmanual_Click);
            // 
            // bcomprar
            // 
            this.bcomprar.Location = new System.Drawing.Point(105, 434);
            this.bcomprar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bcomprar.Name = "bcomprar";
            this.bcomprar.Size = new System.Drawing.Size(87, 46);
            this.bcomprar.TabIndex = 20;
            this.bcomprar.Text = "Comprar";
            this.bcomprar.UseVisualStyleBackColor = true;
            this.bcomprar.Click += new System.EventHandler(this.bcomprar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 493);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 24);
            this.button1.TabIndex = 21;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(583, 522);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bcomprar);
            this.Controls.Add(this.bcantidadmanual);
            this.Controls.Add(this.bsesion);
            this.Controls.Add(this.bpelicula);
            this.Controls.Add(this.bingresar);
            this.Controls.Add(this.dgbasientos);
            this.Controls.Add(this.txtcantmanual);
            this.Controls.Add(this.cbnumero);
            this.Controls.Add(this.cbfila);
            this.Controls.Add(this.cbsesion);
            this.Controls.Add(this.cbpelicula);
            this.Controls.Add(this.cbsala);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form6";
            this.Text = "Venta manual";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgbasientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbsala;
        private System.Windows.Forms.ComboBox cbpelicula;
        private System.Windows.Forms.ComboBox cbsesion;
        private System.Windows.Forms.ComboBox cbfila;
        private System.Windows.Forms.ComboBox cbnumero;
        private System.Windows.Forms.TextBox txtcantmanual;
        private System.Windows.Forms.DataGridView dgbasientos;
        private System.Windows.Forms.Button bingresar;
        private System.Windows.Forms.Button bpelicula;
        private System.Windows.Forms.Button bsesion;
        private System.Windows.Forms.Button bcantidadmanual;
        private System.Windows.Forms.Button bcomprar;
        private System.Windows.Forms.Button button1;
    }
}