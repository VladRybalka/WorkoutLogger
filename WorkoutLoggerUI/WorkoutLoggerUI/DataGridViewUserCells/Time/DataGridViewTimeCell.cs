using System;
using System.Windows.Forms;
using WorkoutLoggerUI.DataGridViewUserCells.Time;

namespace WorkoutLoggerUI.DataGridViewUserCells
{
    internal class DataGridViewTimeCell : DataGridViewTextBoxCell
    {
        public override Type EditType
        {
            get
            {
                return typeof(TimeEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return "00:00:00";
            }
        }

        public override void InitializeEditingControl(int rowIndex,
                object initialFormattedValue,
                DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(
                rowIndex,
                initialFormattedValue,
                dataGridViewCellStyle);

            TimeEditingControl ctl =
                DataGridView.EditingControl as TimeEditingControl;

            if (ctl == null)
                return;

            if (Value == null || Value == DBNull.Value)
                ctl.SetTime("00:00:00");
            else
                ctl.SetTime(Value.ToString());
        }
    }
}
