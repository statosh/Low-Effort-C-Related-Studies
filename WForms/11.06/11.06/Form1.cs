﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._06 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show("🦐 " + textBox1.Text + "!");
        }

        private void Form1_Load(object sender, EventArgs e) {
            BackColor = Color.GreenYellow;
        }

        private void button2_Click(object sender, EventArgs e) {
            Form2 fne = new Form2();
            fne.Show();
        }
    }
}
