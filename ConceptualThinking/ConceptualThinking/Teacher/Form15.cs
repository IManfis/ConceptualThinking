using System;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var words = textBox1.Text;
            var line = textBox2.Text;
            var answer1 = textBox3.Text;
            var answer2 = textBox4.Text;

            var context = new ConceptualThinkingContext();
            context.Experiment1Data.Add(new Experiment1Data
            {
                InitialNotion = words,
                SeriesNotion = "(" + line + ")",
                CorrectWord1 = answer1,
                CorrectWord2 = answer2
            });

            context.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
