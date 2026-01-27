namespace csharp_bmfg {
    public partial class Editor : Form {

        public bool active;
        public Editor() {
            InitializeComponent();

            active = true;

            Externs.CallbackDelegate callback = (value) => {
                Log(value);
            };

            view_extern.Init(callback);

            // Enable keyboard events at form level
            KeyPreview = true;

            // Events
            FormClosing += Editor_FormClosing;
            KeyDown += Editor_KeyDown;

            toolStripMenuItem_open.MouseUp += toolStripButton_openFile;
        }

        public void UpdateFrame() {
            view_extern.UpdateFrame();
        }

        public void PreRender() {
            view_extern.PreRender();
        }

        public void Render() {
            view_extern.Render();
        }

        public void SwapBuffers() {
            view_extern.SwapBuffers();
        }

        #region core

        private void LoadTTF(string path) {
            view_extern.LoadAndBakeFont(path, (int)numericUpDown_size.Value);
        }

        #endregion

        #region Log
        public void Log(String text) {
            // Check if form and console are not disposed
            if (!IsDisposed && console != null && !console.IsDisposed) {
                console.Log(text);
            }
        }

        #endregion

        #region Events

        private void Editor_FormClosing(object sender, FormClosingEventArgs e) {
            active = false;
            Application.DoEvents(); // Process remaining messages
            System.Threading.Thread.Sleep(50); // Give loop time to exit
            view_extern.Release();
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e) {
            // Toggle console with tilde key (~) or F1
            if (e.KeyCode == Keys.Oemtilde || e.KeyCode == Keys.F1) {
                console.Visible = !console.Visible;
                e.Handled = true;
            }

            if (e.KeyCode == Keys.O || e.KeyCode == Keys.P) {

            }
        }

        #endregion

        private void view_extern_MouseDown(object sender, MouseEventArgs e) {
            view_extern.mouseClick(e.X, e.Y);
        }

        private void toolStripButton_openFile(object sender, MouseEventArgs e) {
            string path = Utils.OpenFile("");
            string ext = Path.GetExtension(path);

            switch (ext) {

                case ".json":



                    break;

                case ".ttf":

                    LoadTTF(path);

                    break;

                case "":

                    return;

                default:

                    throw new Exception("Invalid file name");
            }
        }
    }
}