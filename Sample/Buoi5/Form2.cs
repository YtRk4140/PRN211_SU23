﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi5
{
    public partial class Form2 : Form
    {
        private string text;
        public Form2(string _text)
        {
            InitializeComponent();
            text = _text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
