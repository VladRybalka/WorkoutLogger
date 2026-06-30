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
        bool isFromOpen = false;

        public AddSportForm()
        {
            InitializeComponent();
        }

        #region -==- Buttons -==-

        private async void btn_add_Click(object sender, EventArgs e)
        {
            // Checking if sport already exists.
            if (!await ValidateSportExists())
            {
                MessageBox.Show("Sport has already been added.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Checking if any features have been added.
            int count = dataGridView1.RowCount;
            if(count == 0)
            {
                MessageBox.Show("No characteristics added.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Creates a set of characteristics that will be passed when adding a sport.
            string charasteristics = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Checking if not all characteristics have name and type.
                if (row.Cells[0].Value is null || row.Cells[1].Value is null)
                {
                    MessageBox.Show("One of the characteristics or data types is not specified.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                charasteristics += row.Cells[0].Value.ToString() + ":" + row.Cells[1].Value.ToString() + ";";
            }
            charasteristics = charasteristics.Substring(0, charasteristics.Length-1);

            // Submitting a request to add a sport.
            using (HttpClient client = new HttpClient())
            {
                string a = await client.GetStringAsync($"http://127.0.0.1:5001/add_sport/{txt_name.Text}/{charasteristics}");
            }

            Close();
            MessageBox.Show("Sport successfully added.");
        }

        // Check if sport already added.
        public async Task<bool> ValidateSportExists()
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

        #region -==- Row -==-

        // Add row
        private void btn_addRow_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        // delete selected row.
        private void btn_deleteRow_Click(object sender, EventArgs e)
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

        private void checkSport_Tick(object sender, EventArgs e)
        {
            if (txt_name.Text == "Example: Run" || txt_name.Text == "")
            {
                dataGridView1.Enabled = false;
                btn_addRow.Enabled = false;
                btn_deleteRow.Enabled = false;
                btn_add.Enabled = false;
            }
            else
            {
                dataGridView1.Enabled = true;
                btn_addRow.Enabled = true;
                btn_deleteRow.Enabled = true;
                btn_add.Enabled = true;
            }
        }

        #region -==- Initialization -==-

        private void AddSportForm_Load(object sender, EventArgs e)
        {
            if (!isFromOpen)
            {
                InitDataGridView();

                isFromOpen = true;
            }
            else
            {
                
                txt_name.Text = "";
                ActiveControl = null;
            }

            txt_name_Leave(sender, e);    // Set Example Style.
            // Start check if the sport name is entered.
            checkSport.Start();
        }

        private void InitDataGridView()
        {
            // Create ComboBoxCell with types.
            DataGridViewComboBoxCell list = new DataGridViewComboBoxCell();
            list.Items.Add("Numeric");
            list.Items.Add("Decimal");
            list.Items.Add("Text");
            list.Items.Add("Time");

            // Create name and type characteristics column.
            DataGridViewColumn column1 = new DataGridViewColumn()
            {
                HeaderText = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Resizable = DataGridViewTriState.False,
                CellTemplate = new DataGridViewTextBoxCell()
            };
            DataGridViewColumn column2 = new DataGridViewColumn()
            {
                HeaderText = "Type",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Resizable = DataGridViewTriState.False,
                CellTemplate = list
            };

            // Add column.
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.AllowUserToAddRows = false;    // Prohibition on adding new lines.
            dataGridView1.RowHeadersVisible = false;    // To remove row headers and accordingly
                                                        // the first unnecessary column.

            // Add default characteristics.
            dataGridView1.Rows.Add("Time", "Time");
            dataGridView1.Rows.Add("Distance", "Decimal");
        }

        #endregion

        private void AddSportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkSport.Stop();
        }
    }
}
