using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        public Form21(int id)
        {
            InitializeComponent();
            WriteToDataGrid1(id);
            WriteToDataGrid2(id);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WriteToDataGrid1(int id)
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

            label5.Text = points.ToString();
        }

        private void WriteToDataGrid2(int id)
        {
            dataGridView2.Rows.Clear();
            var context = new ConceptualThinkingContext();
            var data = context.Experiment2Result.Where(x => x.IdUser == id);

            var row = 0;
            var points = 0;
            foreach (var result in data)
            {
                dataGridView2.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay;

                var PairNotions = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[1];
                PairNotions.Value = result.Experiment2Data.PairNotions;

                var UserAnswer = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[2];
                UserAnswer.Value = result.UserAnswer;

                var CorrectAnswer = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[3];
                CorrectAnswer.Value = result.Experiment2Data.CorrectAnswer;

                row++;
                points += result.NumberPoints;
            }

            if (dataGridView2.RowCount > 0)
            {
                dataGridView2.CurrentCell = dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0];
            }

            label3.Text = points.ToString();
        }
    }
}
