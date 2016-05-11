using System;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Student
{
    public partial class Form8 : Form
    {
        private int _number = 1;
        private int _number1 = 1;
        private bool _continue = false;
        private int _id = 0;
        public Form8()
        {
            var context = new ConceptualThinkingContext();
            _number1 = int.Parse(context.Settings.First(x => x.Name == "Предъявлений1").Value);
            InitializeComponent();
            _id = 4;
            label3.Text = _number.ToString();
            label5.Text = _number1.ToString();
            OutputWords();
        }

        public Form8(int number, int id)
        {
            var context = new ConceptualThinkingContext();
            _number1 = int.Parse(context.Settings.First(x => x.Name == "Предъявлений1").Value);
            InitializeComponent();
            _number = number;
            _continue = true;
            _id = id;
            label3.Text = _number.ToString();
            label5.Text = _number1.ToString();
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
            var words = context.Experiment1Data.FirstOrDefault(x => x.Id == _number);
            label6.Text = words.InitialNotion;
            label7.Text = words.SeriesNotion;

            var stringf = words.SeriesNotion.Trim(new Char[] {'(', ')'});
            stringf = stringf.Replace(" ", string.Empty);
            var items = stringf.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            for (int i = 0; i < items.Count(); i++)
            {
                comboBox1.Items.Add(items[i]);
                comboBox2.Items.Add(items[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            if (comboBox1.SelectedIndex >= 0 && comboBox2.SelectedIndex >= 0)
            {
                if (_number > _number1)
                {
                    button2.Enabled = false;
                    button1.Visible = true;
                }
                else
                {
                    WriteResultToDb();
                    _number++;
                    if (_number != _number1)
                    {
                        OutputWords();
                        label3.Text = _number.ToString();
                        comboBox1.Text = "Выберите первое слово";
                        comboBox2.Text = "Выберите второе слово";    
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


                var points = 0;
                var words = context.Experiment1Data.FirstOrDefault(x => x.Id == _number);
                if (words.CorrectWord1 == comboBox1.SelectedItem.ToString() &&
                    words.CorrectWord2 == comboBox2.SelectedItem.ToString())
                {
                    points = 1;
                }


                context.Experiment1Result.Add(new Experiment1Result
                {
                    IdUser = _id,
                    IdExpData = _number,
                    Choice1 = comboBox1.SelectedItem.ToString(),
                    Choice2 = comboBox2.SelectedItem.ToString(),
                    NumberPoints = points,
                    NumberDisplay = _number,
                    AllNumberDisplay = _number1,
                    Experiment1Data = words,
                    Users = user
                });
                context.SaveChanges();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form9();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}
