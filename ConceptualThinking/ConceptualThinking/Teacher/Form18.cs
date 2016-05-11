using System;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new ConceptualThinkingContext();
            context.Experiment2Data.Add(new Experiment2Data
            {
                PairNotions = textBox1.Text,
                CorrectAnswer = comboBox1.SelectedItem.ToString()
            });

            context.SaveChanges();
        }
    }
}
