using System;
using System.Windows.Forms;

namespace WorkoutLoggerUI.DataGridViewUserCells.Time
{
    internal class TimeEditingControl : TextBox, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private bool valueChanged;
        private int rowIndex;

        // Здесь будут храниться только цифры
        private string digits = "";

        public TimeEditingControl()
        {
            BorderStyle = BorderStyle.None;
            ShortcutsEnabled = false;

            Cursor = Cursors.IBeam;
        }

        #region IDataGridViewEditingControl

        public object EditingControlFormattedValue
        {
            get
            {
                return Text;
            }
            set
            {
                digits = "";

                if (value != null)
                {
                    if (string.IsNullOrWhiteSpace((string)value))
                    {
                        digits = "";
                        UpdateText();
                        return;
                    }

                    string[] parts = ((string)value).Split(':');

                    if (parts.Length != 3)
                    {
                        digits = "";
                        UpdateText();
                        return;
                    }

                    string hours = parts[0].TrimStart('0');
                    string minutes = parts[1];
                    string seconds = parts[2];

                    if (hours == "")
                        hours = "0";

                    digits = hours + minutes + seconds;

                    // Убираем лишние ведущие нули,
                    // но оставляем хотя бы одну цифру
                    while (digits.Length > 1 && digits[0] == '0')
                        digits = digits.Substring(1);

                    UpdateText();
                }

                UpdateText();
            }
        }

        public void SetTime(string value)
        {
            digits = "";

            if (!string.IsNullOrEmpty(value))
            {
                foreach (char c in value)
                {
                    if (char.IsDigit(c))
                        digits += c;
                }
            }

            UpdateText();
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return Text;
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle style)
        {
            Font = style.Font;
            ForeColor = style.ForeColor;
            BackColor = style.BackColor;
        }

        public int EditingControlRowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return true;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            SelectionStart = Text.Length;
            SelectionLength = 0;
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public DataGridView EditingControlDataGridView
        {
            get { return dataGridView; }
            set { dataGridView = value; }
        }

        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set { valueChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return Cursor; }
        }

        #endregion

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            valueChanged = true;

            if (dataGridView != null)
                dataGridView.NotifyCurrentCellDirty(true);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            SelectionStart = Text.Length;
            SelectionLength = 0;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            SelectionStart = Text.Length;
            SelectionLength = 0;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            SelectionStart = Text.Length;
            SelectionLength = 0;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            SelectionStart = Text.Length;
            SelectionLength = 0;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            SelectionStart = Text.Length;
            SelectionLength = 0;
        }

        private void UpdateText()
        {
            if (digits.Length == 0)
            {
                Text = "00:00:00";
                SelectionStart = Text.Length;
                return;
            }

            string value = digits;

            while (value.Length < 9)
                value = "0" + value;

            string seconds = value.Substring(value.Length - 2);
            string minutes = value.Substring(value.Length - 4, 2);
            string hours = value.Substring(0, value.Length - 4);

            if (hours.Length == 0)
                hours = "0";

            Text = hours + ":" + minutes + ":" + seconds;

            SelectionStart = Text.Length;
            SelectionLength = 0;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // Полностью отключаем стандартный ввод TextBox
            e.Handled = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            MessageBox.Show(digits);

            // Cursor always at the end.
            SelectionStart = Text.Length;
            SelectionLength = 0;

            // Disable keyboard shortcuts Ctrl+?
            if (e.Control)
            {
                e.SuppressKeyPress = true;
                return;
            }

            int maxDigits = 7;
            // Numbers of the top row
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                // Maximum (999:59:59).
                if (digits.Length < maxDigits)
                {
                    digits += (char)('0' + (e.KeyCode - Keys.D0));
                    UpdateText();
                }

                e.SuppressKeyPress = true;
                return;
            }

            // NumPad
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                if (digits.Length < maxDigits)
                {
                    digits += (char)('0' + (e.KeyCode - Keys.NumPad0));
                    UpdateText();
                }

                e.SuppressKeyPress = true;
                return;
            }

            // Delete and Backspace removes the last digit.
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                if (digits.Length > 0)
                {
                    digits = digits.Substring(0, digits.Length - 1);
                    UpdateText();
                }

                e.SuppressKeyPress = true;
                return;
            }

            // Cursor movement restriction.
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                case Keys.Home:
                case Keys.End:
                case Keys.PageUp:
                case Keys.PageDown:
                    e.SuppressKeyPress = true;
                    return;
            }

            // Enter returns to processing in the DataGridView.
            if (e.KeyCode == Keys.Enter)
                return;

            // Disabling the remaining keys.
            e.SuppressKeyPress = true;
        }
    }
}
