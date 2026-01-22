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
        }

        public void Tick() {

        }

        public void PreRender() {

        }

        public void Render() {

        }

        public void PostRender() {

        }

        #region Log
        public void Log(String text) {

        }

        private void LogCallback(string result) {
            Log(result);
        }

        #endregion
    }
}