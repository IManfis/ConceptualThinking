using System;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Student
{
    public partial class Form11 : Form
    {
        private int _number = 1;
        private int _number1 = 1;
        private bool _continue = false;
        private int _id = 0;

        public Form11()
        {
            var context = new ConceptualThinkingContext();
            _number1 = int.Parse(context.Settings.First(x => x.Name == "Предъявлений2").Value);
            InitializeComponent();
            _id = 4;
            label3.Text = _number.ToString();
            label5.Text = _number1.ToString(); 
            OutputWords();
        }

        public Form11(int number, int id)
        {
            var context = new ConceptualThinkingContext();
            _number1 = int.Parse(context.Settings.First(x => x.Name == "Предъявлений2").Value);
            InitializeComponent();
            _number = number;
            _continue = true;
            _id = id;
            label3.Text = _number.ToString();
            label5.Text = _number1.ToString();
            OutputWords();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var nForm = new Form7();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void OutputWords()
        {
            var context = new ConceptualThinkingContext();
            label6.Text = context.Experiment2Data.FirstOrDefault(x => x.Id == _number).PairNotions;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            if (comboBox1.SelectedIndex >= 0)
            {
                if (_number > _number1)
                {
                    button2.Enabled = false;
                    button1.Visible = true;
                }
                else
                {
                    WriteResultToDb();
                    if (_number != _number1)
                    {
                        _number++;
                        OutputWords();
                        label3.Text = _number.ToString();
                        comboBox1.Text = "Выберите тип связи";
                    }
                    else
                    {
                        button2.Enabled = false;
                        button1.Visible = true;
                    }
                }
            }
            else
            {
                label8.Visible = true;
            }
        }

        private void WriteResultToDb()
        {
            var context = new ConceptualThinkingContext();
            var user = context.Users.FirstOrDefault(x => x.Id == _id);
            var expdata = context.Experiment2Data.FirstOrDefault(x => x.Id == _number);

            var points = 0;
            if (expdata.CorrectAnswer == comboBox1.SelectedItem.ToString())
            {
                points += 1;
            }

            context.Experiment2Result.Add(new Experiment2Result
            {
                IdUser = _id,
                IdExpData = _number,
                UserAnswer = comboBox1.SelectedItem.ToString(),
                NumberPoints = points,
                NumberDisplay = _number,
                AllNumberDisplay = _number1,
                Users = user,
                Experiment2Data = expdata
            });
            context.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form10();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}
