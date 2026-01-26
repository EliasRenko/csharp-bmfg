using csharp_bmfg;

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

        #region Log
        public void Log(String text) {

        }

        private void LogCallback(string result) {
            Log(result);
        }

        #endregion

        #region Events

        private void Editor_FormClosing(object sender, FormClosingEventArgs e) {
            view_extern.Release();
            active = false;
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e) {
            // Toggle console with tilde key (~) or F1
            if (e.KeyCode == Keys.Oemtilde || e.KeyCode == Keys.F1) {
                console.Visible = !console.Visible;
                e.Handled = true;
            }
        }

        #endregion

        private void view_extern_MouseDown(object sender, MouseEventArgs e) {
            view_extern.mouseClick(e.X, e.Y);
        }
    }
}