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
    public partial class Main : Form
    {
        AddSportForm addSportForm = new AddSportForm();

        public Main()
        {
            InitializeComponent();
        }

        #region -==- ADD -==-

        private void btn_addSport_Click(object sender, EventArgs e)
        {
            addSportForm.ShowDialog();
        }

        private void btn_addData_Click(object sender, EventArgs e)
        {

        }

        private void btn_addColumn_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private async void Main_Load(object sender, EventArgs e)
        {
            
            // Makes a request to initialize the database.
            #if DEBUG

            using (HttpClient httpClient = new HttpClient())
            {
                string res = await httpClient.GetStringAsync("http://127.0.0.1:5001/start");
            }

            #endif
        }
    }
}
