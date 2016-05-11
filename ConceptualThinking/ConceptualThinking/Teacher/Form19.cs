using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private int _id = 0;
        public Form19(int id)
        {
            InitializeComponent();
            _id = id;
            var context = new ConceptualThinkingContext();
            var exp = context.Experiment2Data.FirstOrDefault(x => x.Id == id);
            textBox1.Text = exp.PairNotions;
            comboBox1.SelectedItem = exp.CorrectAnswer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new ConceptualThinkingContext();
            var model = new Experiment2Data()
            {
                Id = _id,
                PairNotions = textBox1.Text,
                CorrectAnswer = comboBox1.SelectedItem.ToString()
            };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
