using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Student
{
    public partial class Form9 : Form
    {
        private int _id = 0;
        public Form9()
        {
            InitializeComponent();
            _id = 4;
            WriteToDataGrid(_id);
        }

        public Form9(int id)
        {
            InitializeComponent();
            _id = id;
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
            var data = context.Experiment1Result.Where(x => x.IdUser == id);

            var row = 0;
            var points = 0;
            foreach (var result in data)
            {
                dataGridView1.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay;

                var choice1 = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                choice1.Value = result.Choice1;

                var answer1 = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                answer1.Value = result.Experiment1Data.CorrectWord1;

                var choice2 = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[3];
                choice2.Value = result.Choice2;

                var answer2 = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[4];
                answer2.Value = result.Experiment1Data.CorrectWord2;

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
            saveFileDialog1.FileName = user.Name + " Опыт №1";
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

            var numberExperiment = "Опыт №1\n\n";
            result.Append(numberExperiment);

            var points = 0;

            foreach (var item in context.Experiment1Result.Where(x => x.IdUser == _id))
            {
                result.Append("Предъявляемый набор: ");
                result.Append(item.Experiment1Data.InitialNotion + " " + item.Experiment1Data.SeriesNotion + "\n");
                result.Append("Первое слово выбранное испытуемым: " + item.Choice1 + ". Верный ответ: " +
                              item.Experiment1Data.CorrectWord1 + "\n");
                result.Append("Второе слово выбранное испытуемым: " + item.Choice2 + ". Верный ответ: " +
                              item.Experiment1Data.CorrectWord2 + "\n\n");

                points += item.NumberPoints;
            }

            result.Append("Набранное количество балов: " + points);
         
            return result.ToString();
        }
    }
}
