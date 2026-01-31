using System;
using System.Collections.Generic;
namespace csharp_bmfg {
    public partial class Console : UserControl {

        public Console() {
            InitializeComponent();

            button_copy.Click += Button_copy_Click;
        }

        private void Button_copy_Click(object sender, EventArgs e) {
            if (!IsDisposed && !richTextBox_log.IsDisposed && !string.IsNullOrEmpty(richTextBox_log.Text)) {
                Clipboard.SetText(richTextBox_log.Text);
            }
        }

        public void Log(string message) {
            if (!IsDisposed && !richTextBox_log.IsDisposed) {
                richTextBox_log.AppendText(message + Environment.NewLine);
                richTextBox_log.SelectionStart = richTextBox_log.Text.Length;
                richTextBox_log.ScrollToCaret();
            }
        }
    }
}
