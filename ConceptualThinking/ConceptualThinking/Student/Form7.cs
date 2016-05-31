using System;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Student
{
    public partial class Form7 : Form
    {
        private int _id = 0;
        public Form7()
        {
            InitializeComponent();
            var context = new ConceptualThinkingContext();
            var count = context.Users.Count();
            var user = context.Users.ToList();
            var id = user[count - 1].Id;
            _id = id;

            if (context.Experiment1Result.Any(x => x.IdUser == id))
            {
                button3.Enabled = true;
            }
            if (context.Experiment2Result.Any(x => x.IdUser == id))
            {
                button5.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form6();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var context = new ConceptualThinkingContext();

            if (context.Experiment1Result.Any(x => x.IdUser == _id))
            {
                label3.Visible = true;
            }
            else
            {
                var nForm = new Form8();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nForm = new Form9(_id);
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var context = new ConceptualThinkingContext();

            if (context.Experiment2Result.Any(x => x.IdUser == _id))
            {
                label4.Visible = true;
            }
            else
            {
                var nForm = new Form10();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var nForm = new Form12(_id);
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}
