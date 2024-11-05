namespace ProyectoBases
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.txtAsientosNuevos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAsientosComprados = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdSesionNueva = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtIdSesionActual = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdTrans = new System.Windows.Forms.TextBox();
            this.dgbTodo = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbTodo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAsientosNuevos
            // 
            this.txtAsientosNuevos.Location = new System.Drawing.Point(11, 159);
            this.txtAsientosNuevos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAsientosNuevos.Multiline = true;
            this.txtAsientosNuevos.Name = "txtAsientosNuevos";
            this.txtAsientosNuevos.Size = new System.Drawing.Size(136, 23);
            this.txtAsientosNuevos.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(11, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Asientos Nuevos:";
            // 
            // txtAsientosComprados
            // 
            this.txtAsientosComprados.Location = new System.Drawing.Point(11, 120);
            this.txtAsientosComprados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAsientosComprados.Multiline = true;
            this.txtAsientosComprados.Name = "txtAsientosComprados";
            this.txtAsientosComprados.Size = new System.Drawing.Size(136, 22);
            this.txtAsientosComprados.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(11, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Asientos Comprados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(11, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "ID Sesión nueva:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(11, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID Sesión actual:";
            // 
            // txtIdSesionNueva
            // 
            this.txtIdSesionNueva.Location = new System.Drawing.Point(11, 79);
            this.txtIdSesionNueva.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIdSesionNueva.Multiline = true;
            this.txtIdSesionNueva.Name = "txtIdSesionNueva";
            this.txtIdSesionNueva.Size = new System.Drawing.Size(60, 24);
            this.txtIdSesionNueva.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 235);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Cambio de Asiento";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIdSesionActual
            // 
            this.txtIdSesionActual.Location = new System.Drawing.Point(11, 37);
            this.txtIdSesionActual.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIdSesionActual.Multiline = true;
            this.txtIdSesionActual.Name = "txtIdSesionActual";
            this.txtIdSesionActual.Size = new System.Drawing.Size(60, 24);
            this.txtIdSesionActual.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(385, 419);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 34);
            this.button2.TabIndex = 20;
            this.button2.Text = "Mostrar detalle de sesiones y asientos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(171, 39);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 72;
            this.dgvDatos.RowTemplate.Height = 31;
            this.dgvDatos.Size = new System.Drawing.Size(255, 123);
            this.dgvDatos.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(11, 184);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "ID Transacción:";
            // 
            // txtIdTrans
            // 
            this.txtIdTrans.Location = new System.Drawing.Point(11, 199);
            this.txtIdTrans.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIdTrans.Multiline = true;
            this.txtIdTrans.Name = "txtIdTrans";
            this.txtIdTrans.Size = new System.Drawing.Size(60, 21);
            this.txtIdTrans.TabIndex = 23;
            // 
            // dgbTodo
            // 
            this.dgbTodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbTodo.Location = new System.Drawing.Point(171, 189);
            this.dgbTodo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgbTodo.Name = "dgbTodo";
            this.dgbTodo.RowHeadersWidth = 72;
            this.dgbTodo.RowTemplate.Height = 31;
            this.dgbTodo.Size = new System.Drawing.Size(255, 123);
            this.dgbTodo.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(226, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Datos sobre su transaccion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(212, 169);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Asientos desocupados u Ocupados:";
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgbTodo);
            this.Controls.Add(this.txtIdTrans);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtAsientosNuevos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAsientosComprados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdSesionNueva);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtIdSesionActual);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form8";
            this.Text = "Cambio Asiento";
            this.Load += new System.EventHandler(this.Form8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbTodo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAsientosNuevos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAsientosComprados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdSesionNueva;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIdSesionActual;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdTrans;
        private System.Windows.Forms.DataGridView dgbTodo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}