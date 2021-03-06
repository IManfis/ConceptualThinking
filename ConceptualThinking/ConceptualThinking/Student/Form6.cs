﻿using System;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Student
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            var context = new ConceptualThinkingContext();
            var text = context.Settings.FirstOrDefault(x => x.Name == "Теория").Value;
            richTextBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form4();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nForm = new Form7();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}
