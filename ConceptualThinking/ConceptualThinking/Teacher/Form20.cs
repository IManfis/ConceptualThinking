using System;
using System.Linq;
using System.Windows.Forms;
using ConceptualThinking.Model;

namespace ConceptualThinking.Teacher
{
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
            WriteToDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form13();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void WriteToDataGridView()
        {
            dataGridView1.Rows.Clear();
            var context = new ConceptualThinkingContext();
            var data = context.Users;

            var row = 0;
            foreach (var result in data.Where(result => result.Group != null))
            {
                if (result.Name != "admin")
                {
                    dataGridView1.Rows.Add();
                    var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                    numberDisplay.Value = row + 1;

                    var providedIncentive = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                    providedIncentive.Value = result.Name;

                    var groupNumber = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                    groupNumber.Value = result.Group;

                    var id = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[3];
                    id.Value = result.Id;

                    row++;
                }
            }

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            }
        }

        private void Form20_Activated(object sender, EventArgs e)
        {
            WriteToDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            var context = new ConceptualThinkingContext();
            var model = new Users { Id = id };

            var result = MessageBox.Show("Вы уверены, что хотите удалить данного студента?", "Удаление студента", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                context.Users.Attach(model);
                context.Users.Remove(model);
                context.SaveChanges();

                WriteToDataGridView();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            Form21 d = new Form21(id);
            d.Show();
        }
    }
}
