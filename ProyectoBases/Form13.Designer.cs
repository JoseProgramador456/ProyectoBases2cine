namespace ProyectoBases
{
    partial class Form13
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
            this.cmbNombreSala = new System.Windows.Forms.ComboBox();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnmenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbNombreSala
            // 
            this.cmbNombreSala.FormattingEnabled = true;
            this.cmbNombreSala.Location = new System.Drawing.Point(522, 72);
            this.cmbNombreSala.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmbNombreSala.Name = "cmbNombreSala";
            this.cmbNombreSala.Size = new System.Drawing.Size(609, 32);
            this.cmbNombreSala.TabIndex = 15;
            // 
            // dgvResultados
            // 
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(262, 249);
            this.dgvResultados.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.RowHeadersWidth = 72;
            this.dgvResultados.Size = new System.Drawing.Size(942, 500);
            this.dgvResultados.TabIndex = 14;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(900, 142);
            this.btnGenerarReporte.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(235, 59);
            this.btnGenerarReporte.TabIndex = 13;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(334, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre de la Sala:";
            // 
            // btnmenu
            // 
            this.btnmenu.Location = new System.Drawing.Point(1082, 761);
            this.btnmenu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnmenu.Name = "btnmenu";
            this.btnmenu.Size = new System.Drawing.Size(123, 46);
            this.btnmenu.TabIndex = 19;
            this.btnmenu.Text = "Regresar";
            this.btnmenu.UseVisualStyleBackColor = true;
            this.btnmenu.Click += new System.EventHandler(this.btnmenu_Click);
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1467, 831);
            this.Controls.Add(this.btnmenu);
            this.Controls.Add(this.cmbNombreSala);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form13";
            this.Text = "Reportes Salas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNombreSala;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnmenu;
    }
}