using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkoutLoggerUI
{
    public partial class AddSportForm : Form
    {
        public AddSportForm()
        {
            InitializeComponent();
        }

        #region -==- Buttons -==-

        private async void btn_add_Click(object sender, EventArgs e)
        {
            if(!await ValidateAdd())
            {
                MessageBox.Show("Sport has already been added.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int count = dataGridView1.RowCount;
            if(count == 0)
            {
                MessageBox.Show("No characteristics added.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string charasteristics = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value is null || row.Cells[1].Value is null)
                {
                    MessageBox.Show("One of the characteristics or data types is not specified.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                charasteristics += row.Cells[0].Value.ToString() + ":" + row.Cells[1].Value.ToString() + ";";
            }
            charasteristics = charasteristics.Substring(0, charasteristics.Length-1);
            MessageBox.Show(charasteristics);

            using (HttpClient client = new HttpClient())
            {
                string a = await client.GetStringAsync($"http://127.0.0.1:5001/add_sport/{txt_name.Text}/{charasteristics}");
            }
        }

        public async Task<bool> ValidateAdd()
        {
            bool valid = true;

            string code;
            using (HttpClient client = new HttpClient())
            {
                code = await client.GetStringAsync($"http://127.0.0.1:5001/check_sport_availability/{txt_name.Text}");
            }

            if (code == "409")
            {
                valid = false;
            }

            return valid;
        }

        #region -==- Column -==-

        private void btn_addColumn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void btn_deleteColumn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
        }

        #endregion

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region -==- TextBoxName Events -==-

        private void txt_name_Enter(object sender, EventArgs e)
        {
            if(txt_name.Text == "Example: Run")
            {
                txt_name.Text = "";
            }
            txt_name.BackColor = Color.White;
            txt_name.ForeColor = Color.Black;
        }

        private void txt_name_Leave(object sender, EventArgs e)
        {
            if(txt_name.Text == "")
            {
                txt_name.Text = "Example: Run";
                txt_name.BackColor = Color.FromArgb(230, 230, 230);
                txt_name.ForeColor = Color.FromArgb(100, 100, 100);
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txt_name.Text == "Example: Run" || txt_name.Text == "")
            {
                dataGridView1.Enabled = false;
                btn_addColumn.Enabled = false;
                btn_deleteColumn.Enabled = false;
                btn_add.Enabled = false;
            }
            else
            {
                dataGridView1.Enabled = true;
                btn_addColumn.Enabled = true;
                btn_deleteColumn.Enabled = true;
                btn_add.Enabled = true;
            }
        }

        private void AddSportForm_Load(object sender, EventArgs e)
        {
            txt_name_Leave(sender, e);

            DataGridViewComboBoxCell list = new DataGridViewComboBoxCell();
            list.Items.Add("Numeric");
            list.Items.Add("Decimal");
            list.Items.Add("Text");
            list.Items.Add("Time");

            DataGridViewColumn column1 = new DataGridViewColumn() {
                HeaderText = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Resizable = DataGridViewTriState.False,
                CellTemplate = new DataGridViewTextBoxCell()
            };

            DataGridViewColumn column2 = new DataGridViewColumn() {
                HeaderText = "Type",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Resizable = DataGridViewTriState.False,
                CellTemplate = list
            };

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            timer1.Start();

            dataGridView1.Rows.Add("Time", "Time");
            dataGridView1.Rows.Add("Distance", "Decimal");
        }
    }
}
