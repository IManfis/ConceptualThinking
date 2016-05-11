using System;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
            WriteToDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form13();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide(); 
        }

        private void WriteToDataGrid()
        {
            dataGridView1.Rows.Clear();
            var context = new ConceptualThinkingContext();
            var data = context.Experiment2Data;

            var row = 0;
            foreach (var result in data)
            {
                dataGridView1.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                numberDisplay.Value = row + 1;

                var InitialNotion = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                InitialNotion.Value = result.PairNotions;

                var id = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                id.Value = result.Id;

                row++;
            }

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            }
        }

        private void Form17_Activated(object sender, EventArgs e)
        {
            WriteToDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());

            var context = new ConceptualThinkingContext();
            var model = new Experiment2Data { Id = id };

            var result = MessageBox.Show("Вы уверены, что хотите удалить данный набор?", "Удаление набора", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                context.Experiment2Data.Attach(model);
                context.Experiment2Data.Remove(model);
                context.SaveChanges();

                WriteToDataGrid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form18 d = new Form18();
            d.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            Form19 d = new Form19(id);
            d.Show();
        }
    }
}
