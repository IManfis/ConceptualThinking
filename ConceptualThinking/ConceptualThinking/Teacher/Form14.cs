using System;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form14 : Form
    {
        public Form14()
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
            var data = context.Experiment1Data;

            var row = 0;
            foreach (var result in data)
            {
                    dataGridView1.Rows.Add();
                    var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                    numberDisplay.Value = row + 1;

                    var InitialNotion = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                    InitialNotion.Value = result.InitialNotion;

                    var id = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                    id.Value = result.Id;

                    row++;
            }

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());

            var context = new ConceptualThinkingContext();
            var model = new Experiment1Data { Id = id };

            var result = MessageBox.Show("Вы уверены, что хотите удалить данный набор?", "Удаление набора", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                context.Experiment1Data.Attach(model);
                context.Experiment1Data.Remove(model);
                context.SaveChanges();

                WriteToDataGrid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form15 d = new Form15();
            d.Show();
        }

        private void Form14_Activated(object sender, EventArgs e)
        {
            WriteToDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            Form16 d = new Form16(id);
            d.Show();
        }
    }
}
