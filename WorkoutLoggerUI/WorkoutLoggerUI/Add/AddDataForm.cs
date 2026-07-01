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

namespace WorkoutLoggerUI.Add
{
    public partial class AddDataForm : Form
    {
        public AddDataForm()
        {
            InitializeComponent();
        }

        // Initialization 
        private void AddDataForm_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            AddDataInComboBox();
        }

        private void InitDataGridView()
        {
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
                CellTemplate = new DataGridViewTextBoxCell()
            };

            // Add column.
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.AllowUserToAddRows = false;    // Prohibition on adding new lines.
            dataGridView1.RowHeadersVisible = false;    // To remove row headers and accordingly
                                                        // the first unnecessary column.
        }

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
            foreach (string sport in sports) {
                cmBoxSport.Items.Add(sport);
                cmBoxSport.SelectedIndex = 0;
            }
        }

        private async void cmBoxSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSport = cmBoxSport.SelectedItem.ToString();    // Get Sport from ComboBox.

            // Get json string from server.
            string json = string.Empty;
            using(HttpClient client = new HttpClient())
            {
                json = await client.GetStringAsync($"http://127.0.0.1:5001/get_characteristics/{selectedSport}");
            }

            // Get Characteristics Array from json.
            string[] characteristics = JsonConvert.DeserializeObject<string[]>(json);

            dataGridView1.Rows.Clear();

            foreach(string characteristic in characteristics)
            {
                dataGridView1.Rows.Add(characteristic);
            }
        }
    }
}
