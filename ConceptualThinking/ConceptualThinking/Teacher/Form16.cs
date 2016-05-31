using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private int _id = 0;
        public Form16(int id)
        {
            InitializeComponent();
            var context = new ConceptualThinkingContext();
            _id = id;
            var line = context.Experiment1Data.FirstOrDefault(x => x.Id == id);

            textBox1.Text = line.InitialNotion;
            textBox2.Text = line.SeriesNotion;
            textBox3.Text = line.CorrectWord1;
            textBox4.Text = line.CorrectWord2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new ConceptualThinkingContext();
            var model = new Experiment1Data()
            {
                Id = _id,
                InitialNotion = textBox1.Text,
                SeriesNotion = textBox2.Text,
                CorrectWord1 = textBox3.Text,
                CorrectWord2 = textBox4.Text
            };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            Close();
        }
    }
}
