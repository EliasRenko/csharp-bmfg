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

            // Events
            this.FormClosing += Form1_FormClosing;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            view_extern.Release();
            active = false;
        }

        #endregion

        private void view_extern_MouseDown(object sender, MouseEventArgs e) {
            view_extern.mouseClick(e.X, e.Y);
        }
    }
}