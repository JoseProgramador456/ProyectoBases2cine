namespace ProyectoBases
{
    partial class Form10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnTop5 = new System.Windows.Forms.Button();
            this.btnDatosSesiones = new System.Windows.Forms.Button();
            this.btnSalas = new System.Windows.Forms.Button();
            this.btnTransacciones = new System.Windows.Forms.Button();
            this.btnListadoSesiones = new System.Windows.Forms.Button();
            this.btnmenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(23, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "> REPORTES";
            // 
            // btnLogs
            // 
            this.btnLogs.Location = new System.Drawing.Point(364, 264);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(128, 39);
            this.btnLogs.TabIndex = 12;
            this.btnLogs.Text = "Logs";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnTop5
            // 
            this.btnTop5.Location = new System.Drawing.Point(362, 219);
            this.btnTop5.Name = "btnTop5";
            this.btnTop5.Size = new System.Drawing.Size(130, 39);
            this.btnTop5.TabIndex = 11;
            this.btnTop5.Text = "TOP 5";
            this.btnTop5.UseVisualStyleBackColor = true;
            this.btnTop5.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnDatosSesiones
            // 
            this.btnDatosSesiones.Location = new System.Drawing.Point(363, 174);
            this.btnDatosSesiones.Name = "btnDatosSesiones";
            this.btnDatosSesiones.Size = new System.Drawing.Size(129, 39);
            this.btnDatosSesiones.TabIndex = 10;
            this.btnDatosSesiones.Text = "Datos Sesiones";
            this.btnDatosSesiones.UseVisualStyleBackColor = true;
            this.btnDatosSesiones.Click += new System.EventHandler(this.btnDatosSesiones_Click);
            // 
            // btnSalas
            // 
            this.btnSalas.Location = new System.Drawing.Point(364, 129);
            this.btnSalas.Name = "btnSalas";
            this.btnSalas.Size = new System.Drawing.Size(128, 39);
            this.btnSalas.TabIndex = 9;
            this.btnSalas.Text = "Salas";
            this.btnSalas.UseVisualStyleBackColor = true;
            this.btnSalas.Click += new System.EventHandler(this.btnSalas_Click);
            // 
            // btnTransacciones
            // 
            this.btnTransacciones.Location = new System.Drawing.Point(364, 84);
            this.btnTransacciones.Name = "btnTransacciones";
            this.btnTransacciones.Size = new System.Drawing.Size(128, 39);
            this.btnTransacciones.TabIndex = 8;
            this.btnTransacciones.Text = "Transacciones";
            this.btnTransacciones.UseVisualStyleBackColor = true;
            this.btnTransacciones.Click += new System.EventHandler(this.btnTransacciones_Click);
            // 
            // btnListadoSesiones
            // 
            this.btnListadoSesiones.Location = new System.Drawing.Point(364, 39);
            this.btnListadoSesiones.Name = "btnListadoSesiones";
            this.btnListadoSesiones.Size = new System.Drawing.Size(128, 39);
            this.btnListadoSesiones.TabIndex = 7;
            this.btnListadoSesiones.Text = "Sesiones";
            this.btnListadoSesiones.UseVisualStyleBackColor = true;
            this.btnListadoSesiones.Click += new System.EventHandler(this.btnListadoSesiones_Click);
            // 
            // btnmenu
            // 
            this.btnmenu.Location = new System.Drawing.Point(12, 289);
            this.btnmenu.Name = "btnmenu";
            this.btnmenu.Size = new System.Drawing.Size(67, 25);
            this.btnmenu.TabIndex = 14;
            this.btnmenu.Text = "Regresar";
            this.btnmenu.UseVisualStyleBackColor = true;
            this.btnmenu.Click += new System.EventHandler(this.btnmenu_Click);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(512, 326);
            this.Controls.Add(this.btnmenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.btnTop5);
            this.Controls.Add(this.btnDatosSesiones);
            this.Controls.Add(this.btnSalas);
            this.Controls.Add(this.btnTransacciones);
            this.Controls.Add(this.btnListadoSesiones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form10";
            this.Text = "Reportes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnTop5;
        private System.Windows.Forms.Button btnDatosSesiones;
        private System.Windows.Forms.Button btnSalas;
        private System.Windows.Forms.Button btnTransacciones;
        private System.Windows.Forms.Button btnListadoSesiones;
        private System.Windows.Forms.Button btnmenu;
    }
}