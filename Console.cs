using System;
using System.Collections.Generic;
namespace csharp_bmfg {
    public partial class Console : UserControl {

        public Console() {
            InitializeComponent();
        }

        public void Log(string message) {
            if (!IsDisposed && !richTextBox_log.IsDisposed) {
                richTextBox_log.AppendText(message + Environment.NewLine);
            }
        }
    }
}
