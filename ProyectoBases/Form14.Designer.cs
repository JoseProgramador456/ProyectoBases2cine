namespace ProyectoBases
{
    partial class Form14
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form14));
            this.chkGeneral = new System.Windows.Forms.CheckBox();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.cmbNombreSala = new System.Windows.Forms.ComboBox();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnBuscarSesiones = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnmenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // chkGeneral
            // 
            this.chkGeneral.AutoSize = true;
            this.chkGeneral.ForeColor = System.Drawing.SystemColors.Control;
            this.chkGeneral.Location = new System.Drawing.Point(283, 67);
            this.chkGeneral.Name = "chkGeneral";
            this.chkGeneral.Size = new System.Drawing.Size(95, 17);
            this.chkGeneral.TabIndex = 23;
            this.chkGeneral.Text = "Ver en general";
            this.chkGeneral.UseVisualStyleBackColor = true;
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(282, 90);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(196, 20);
            this.txtPorcentaje.TabIndex = 22;
            // 
            // cmbNombreSala
            // 
            this.cmbNombreSala.FormattingEnabled = true;
            this.cmbNombreSala.Location = new System.Drawing.Point(282, 40);
            this.cmbNombreSala.Name = "cmbNombreSala";
            this.cmbNombreSala.Size = new System.Drawing.Size(334, 21);
            this.cmbNombreSala.TabIndex = 21;
            // 
            // dgvResultados
            // 
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(148, 140);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.Size = new System.Drawing.Size(505, 271);
            this.dgvResultados.TabIndex = 20;
            // 
            // btnBuscarSesiones
            // 
            this.btnBuscarSesiones.Location = new System.Drawing.Point(488, 78);
            this.btnBuscarSesiones.Name = "btnBuscarSesiones";
            this.btnBuscarSesiones.Size = new System.Drawing.Size(128, 32);
            this.btnBuscarSesiones.TabIndex = 19;
            this.btnBuscarSesiones.Text = "Generar Reporte";
            this.btnBuscarSesiones.UseVisualStyleBackColor = true;
            this.btnBuscarSesiones.Click += new System.EventHandler(this.btnBuscarSesiones_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(179, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre de la Sala:";
            // 
            // btnmenu
            // 
            this.btnmenu.Location = new System.Drawing.Point(721, 413);
            this.btnmenu.Name = "btnmenu";
            this.btnmenu.Size = new System.Drawing.Size(67, 25);
            this.btnmenu.TabIndex = 24;
            this.btnmenu.Text = "Regresar";
            this.btnmenu.UseVisualStyleBackColor = true;
            this.btnmenu.Click += new System.EventHandler(this.btnmenu_Click);
            // 
            // Form14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnmenu);
            this.Controls.Add(this.chkGeneral);
            this.Controls.Add(this.txtPorcentaje);
            this.Controls.Add(this.cmbNombreSala);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.btnBuscarSesiones);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form14";
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkGeneral;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.ComboBox cmbNombreSala;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnBuscarSesiones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnmenu;
    }
}