using csharp_bmfg;

namespace csharp_bmfg {
    partial class Editor {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            view_extern = new ExternView();
            console = new Console();
            SuspendLayout();
            // 
            // view_extern
            // 
            view_extern.Dock = DockStyle.Fill;
            view_extern.Location = new Point(0, 0);
            view_extern.Name = "view_extern";
            view_extern.Size = new Size(624, 441);
            view_extern.TabIndex = 0;
            view_extern.MouseDown += view_extern_MouseDown;
            // 
            // console
            // 
            console.Dock = DockStyle.Bottom;
            console.Location = new Point(0, 327);
            console.Name = "console";
            console.Size = new Size(624, 114);
            console.TabIndex = 1;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 441);
            Controls.Add(console);
            Controls.Add(view_extern);
            Name = "Editor";
            Text = "Editor";
            ResumeLayout(false);
        }

        #endregion

        private ExternView view_extern;
        private Console console;
    }
}