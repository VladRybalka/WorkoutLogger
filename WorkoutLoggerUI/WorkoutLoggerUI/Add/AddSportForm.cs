using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void btn_add_Click(object sender, EventArgs e)
        {

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

            DataGridViewColumn column1 = new DataGridViewColumn();
            column1.HeaderText = "Name";
            column1.Width = dataGridView1.Width / 2 - 10;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            DataGridViewColumn column2 = new DataGridViewColumn();
            column2.HeaderText = "Characteristics";
            column2.Width = dataGridView1.Width / 2 - 10;
            column2.CellTemplate = list;
            

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            timer1.Start();
        }

        
    }
}
