using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using WorkoutLoggerUI.DataGridViewUserCells;

namespace WorkoutLoggerUI.Add
{
    public partial class AddDataForm : Form
    {
        public AddDataForm()
        {
            InitializeComponent();
        }

        #region -==- Buttons -==-

        #region -==- ADD -==-

        private void btn_add_Click(object sender, EventArgs e)
        {
            if(!ValidateSend())
            {
                HelpClass.DoErrorMessage("All fields must be filled in.");
                return;
            }
        }

        private bool ValidateSend()
        {
            bool res = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value is null)
                {
                    res = false;
                }
            }
            return res;
        }

        #endregion

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        #endregion

        #region -==- DataGridView -==-

        private void InitDataGridView()
        {
            // Create name and type characteristics column.
            DataGridViewColumn column1 = new DataGridViewColumn()
            {
                HeaderText = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Resizable = DataGridViewTriState.False,
                ReadOnly = true,
                CellTemplate = new DataGridViewTextBoxCell()
            };
            DataGridViewColumn column2 = new DataGridViewColumn()
            {
                HeaderText = "Type",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Resizable = DataGridViewTriState.False,
                CellTemplate = new DataGridViewTextBoxCell()
            };

            // Add column.
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.AllowUserToAddRows = false;    // Prohibition on adding new lines.
            dataGridView1.RowHeadersVisible = false;    // To remove row headers and accordingly
                                                        // the first unnecessary column.
        }

        private async void AddCharacteristicsInDataGridView(string selectedSport)
        {
            // Get json string from server.
            string json = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                json = await client.GetStringAsync($"http://127.0.0.1:5001/" +
                            $"get_names_characteristics/{selectedSport}");
            }

            // Get Characteristics Array from json.
            string[] characteristics_names = JsonConvert.DeserializeObject<string[]>(json);
            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].ReadOnly = true;

            foreach (string characteristic in characteristics_names)
            {
                dataGridView1.Rows.Add(characteristic);
            }

            using (HttpClient client = new HttpClient())
            {
                json = await client.GetStringAsync($"http://127.0.0.1:5001/" +
                            $"get_type_characteristics/{selectedSport}");
            }

            string[] characteristics_types = JsonConvert.DeserializeObject<string[]>(json);
            for (int i = 0; i < characteristics_types.Length; i++)
            {
                if (characteristics_names[i] == "Time")
                {
                    var cell = new DataGridViewUserCells.Time.DataGridViewTimeCell();
                    //cell.Value = "00:00:00";

                    dataGridView1.Rows[i].Cells[1] = cell;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[1] = new DataGridViewTextBoxCell();
                }
            }
        }

        #endregion

        #region -==- ComboBox -==-

        private async void AddDataInComboBox()
        {
            // Get json string from server.
            string json = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                json = (await client.GetStringAsync("http://127.0.0.1:5001/get_sport"));
            }

            // Get Sports Array from json.
            string[] sports = JsonConvert.DeserializeObject<string[]>(json);

            // Add Sports in ComboBox.
            foreach (string sport in sports)
            {
                cmBoxSport.Items.Add(sport);
                cmBoxSport.SelectedIndex = 0;
            }
        }

        private void cmBoxSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSport = cmBoxSport.SelectedItem.ToString();    // Get Sport from ComboBox.

            AddCharacteristicsInDataGridView(selectedSport);
        }

        #endregion

        #region -==- Initialization -==-

        // Initialization
        private void AddDataForm_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            AddDataInComboBox();
        }

        #endregion

        private void AddDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;    // Cancel Dispose.
            Hide();
        }
    }
}
