using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WorkoutLoggerUI.DataGridViewUserCells.Time
{
    internal class DataGridViewTimeCell : DataGridViewTextBoxCell
    {
        public override Type EditType
        {
            get { return typeof(TimeEditingControl); }
        }

        public override Type ValueType => typeof(string);

        public override object DefaultNewRowValue => "";

        protected override object GetFormattedValue(object value, int rowIndex, 
            ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return "00:00:00";
            //return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
    }
}