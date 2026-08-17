using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkoutLoggerUI.DataGridViewUserCells.Time
{
    internal class TimeEditingControl : DataGridViewTextBoxEditingControl
    {
        // Flag: is text changing.
        private bool _isChanged;

        // Mask.
        private string _mask = "";

        // User digits.
        private string _digits = "";

        // number of digits.
        private int _lenght = 6;

        public TimeEditingControl()
        {
            for(int i = 0; i < _lenght; i++)
            {
                _mask += "0";
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b' && _digits.Length != 0)
            {
                _digits = _digits.Substring(0, _digits.Length - 1);
            }
            else if (_digits.Length == _lenght)
            {
                e.Handled = true;
                return;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                _digits += e.KeyChar;
            }
            else
            {
                SelectionStart = _lenght;
                e.Handled = true;
                return;
            }

            base.OnKeyPress(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (_isChanged) return;

            _isChanged = true;

            Text = GetText();
            SelectionStart = _lenght + 2;

            _isChanged = false;

            base.OnTextChanged(e);
        }

        private string GetText()
        {
            StringBuilder sb = new StringBuilder(_mask);
            for (int i = _digits.Length - 1; i >= 0; i--)
            {
                sb[_mask.Length - 1 - i] = _digits[_digits.Length - 1 - i];
            }
            sb.Insert(_mask.Length - 2, ":");
            sb.Insert(_mask.Length - 4, ":");

            return sb.ToString();
        }
    }
}