﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBases
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra Form5 y vuelve a mostrar Form1
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra Form5 y vuelve a mostrar Form1
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra Form5 y vuelve a mostrar Form1
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
