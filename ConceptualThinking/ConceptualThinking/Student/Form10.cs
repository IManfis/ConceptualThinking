using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Student
{
    public partial class Form10 : Form
    {
        private int _number = 1;
        private int _number1 = 1;
        private int _id = 0;

        List<Experiment2Data> List = new List<Experiment2Data>
        {
            new Experiment2Data{PairNotions = "Овца — стадо", CorrectAnswer = "часть — целое"},
            new Experiment2Data{PairNotions = "Малина — ягода", CorrectAnswer = "род — вид"},
            new Experiment2Data{PairNotions = "Море — океан", CorrectAnswer = "степень"},
            new Experiment2Data{PairNotions = "Свет — темнота", CorrectAnswer = "антонимы"},
            new Experiment2Data{PairNotions = "Отравление — смерть", CorrectAnswer = "причина — следствие"},
            new Experiment2Data{PairNotions = "Враг — неприятель", CorrectAnswer = "синонимы"}
        };

        public Form10()
        {
            _number1 = 6;
            InitializeComponent();
            _id = 4;
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
            label6.Text = List[_number - 1].PairNotions;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            label9.Visible = false;
            if (comboBox1.SelectedItem == List[_number - 1].CorrectAnswer)
            {
                label9.Visible = true;
                button2.Enabled = true;
            }
            else
            {
                label7.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            if (comboBox1.SelectedIndex > 0)
            {
                if (_number <= _number1)
                {
                    if (_number != _number1)
                    {
                        _number++;
                        label3.Text = _number.ToString();
                    }
                    else
                    {
                        button1.Visible = true;
                        button2.Enabled = false;
                    }
                    OutputWords();
                }
                label7.Visible = false;
                label9.Visible = false;
                button2.Enabled = false;   
            }
            else
            {
                label8.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form11();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}
