using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkoutLoggerUI
{
    internal class HelpClass
    {
        public static void DoErrorMessage(string message, string caption = "Error")
            => MessageBox.Show(message, caption, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

        public static void DoInfoMessage(string message, string caption = "Information")
            => MessageBox.Show(message, caption, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
    }
}
