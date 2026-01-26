namespace csharp_bmfg {
    partial class Console {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label_log = new Label();
            richTextBox_log = new RichTextBox();
            SuspendLayout();
            // 
            // label_log
            // 
            label_log.AutoSize = true;
            label_log.Location = new Point(12, 9);
            label_log.Name = "label_log";
            label_log.Size = new Size(27, 15);
            label_log.TabIndex = 0;
            label_log.Text = "Log";
            // 
            // richTextBox_log
            // 
            richTextBox_log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox_log.Location = new Point(3, 36);
            richTextBox_log.Name = "richTextBox_log";
            richTextBox_log.ReadOnly = true;
            richTextBox_log.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox_log.Size = new Size(314, 201);
            richTextBox_log.TabIndex = 1;
            richTextBox_log.Text = "";
            // 
            // Console
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label_log);
            Controls.Add(richTextBox_log);
            Name = "Console";
            Size = new Size(320, 240);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_log;
        private RichTextBox richTextBox_log;
    }
}
