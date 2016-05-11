using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Student
{
    public partial class Form12 : Form
    {
        private int _id = 0;
        public Form12()
        {
            InitializeComponent();
            _id = 4;
            WriteToDataGrid(_id);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var nForm = new Form7();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void WriteToDataGrid(int id)
        {
            dataGridView1.Rows.Clear();
            var context = new ConceptualThinkingContext();
            var data = context.Experiment2Result.Where(x => x.IdUser == id);

            var row = 0;
            var points = 0;
            foreach (var result in data)
            {
                dataGridView1.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay;

                var PairNotions = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                PairNotions.Value = result.Experiment2Data.PairNotions;

                var UserAnswer = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                UserAnswer.Value = result.UserAnswer;

                var CorrectAnswer = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[3];
                CorrectAnswer.Value = result.Experiment2Data.CorrectAnswer;

                row++;
                points += result.NumberPoints;
            }

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            }

            label3.Text = points.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new ConceptualThinkingContext();
            var user = context.Users.FirstOrDefault(x => x.Id == _id);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = "~/../";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FileName = user.Name + " Опыт №2";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            var result = new StringBuilder();

            var name = "Имя испытуемого: " + user.Name + "\n";
            var date = "Дата: " + user.Date + "\n";
            var group = "Номер группы: " + user.Group + "\n";

            result.Append(name);
            result.Append(date);
            result.Append(group);
            result.Append(ExperimentResult());

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filename = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(filename, result.ToString());
            }
        }

        private string ExperimentResult()
        {
            var context = new ConceptualThinkingContext();

            var result = new StringBuilder();

            var numberExperiment = "Опыт №2\n\n";
            result.Append(numberExperiment);

            var points = 0;

            foreach (var item in context.Experiment2Result.Where(x => x.IdUser == _id))
            {
                result.Append("Предъявляемая пара понятий: ");
                result.Append(item.Experiment2Data.PairNotions + "\n");
                result.Append("Ответ испытуемого: " + item.UserAnswer + " Правильный ответ: " +
                              item.Experiment2Data.CorrectAnswer + "\n\n");

                points += item.NumberPoints;
            }

            result.Append("Набранное количество балов: " + points);

            return result.ToString();
        }
    }
}
