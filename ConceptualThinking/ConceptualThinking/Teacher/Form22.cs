using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
            WriteInformation();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nForm = new Form13();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var number = textBox1.Text;
            var context = new ConceptualThinkingContext();
            var model = new Settings() { Id = 1, Name = "Предъявлений1", Value = number };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            textBox1.Text = "";

            WriteInformation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var number = textBox2.Text;
            var context = new ConceptualThinkingContext();
            var model = new Settings() { Id = 2, Name = "Предъявлений2", Value = number };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            textBox2.Text = "";

            WriteInformation();
        }

        private void WriteInformation()
        {
            var context = new ConceptualThinkingContext();
            label12.Text = context.Settings.First(x => x.Name == "Предъявлений1").Value;
            label1.Text = context.Settings.First(x => x.Name == "Предъявлений2").Value;
        }
    }
}
