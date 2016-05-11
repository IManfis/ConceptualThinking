using System;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form3();
            nForm.FormClosed += (o, ep) => Close();
            nForm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var context = new ConceptualThinkingContext();
            var user = context.Users;

            var name = textBox1.Text;
            var password = textBox2.Text;

            var admin = user.FirstOrDefault(x => x.Name == name);

            if (admin == null)
            {
                label4.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (admin.Password == password && admin.Group == 0)
            {
                var nForm = new Form13();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
            else
            {
                label4.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
