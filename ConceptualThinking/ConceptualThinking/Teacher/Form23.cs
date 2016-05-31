using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
            var context = new ConceptualThinkingContext();
            var text = context.Settings.FirstOrDefault(x => x.Name == "Теория").Value;
            richTextBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form13();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var text = richTextBox1.Text;

            var context = new ConceptualThinkingContext();
            var model = new Settings()
            {
                Id = 3,
                Name = "Теория",
                Value = text
            };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
