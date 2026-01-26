using System;
using System.Collections.Generic;
namespace csharp_bmfg {
    public partial class Console : UserControl {

        public Console() {
            InitializeComponent();
        }

        public void Log(string message) {
            richTextBox_log.AppendText(message + Environment.NewLine);
        }
    }
}
