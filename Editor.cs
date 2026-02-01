using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

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
            KeyUp += Editor_KeyUp;

            // ExternView
            view_extern.MouseDown += view_extern_MouseDown;
            view_extern.MouseUp += view_extern_MouseUp;

            toolStripMenuItem_open.MouseUp += toolStripButton_openFile;
            toolStripMenuItem_export.MouseUp += toolStripButton_export;

            button_rebake.MouseUp += Button_rebake_MouseUp;
        }

        private void Button_rebake_MouseUp(object? sender, MouseEventArgs e) {
            view_extern.RebakeFont((int)numericUpDown_size.Value, 512, 512, 32, 96);
        }

        public void UpdateFrame(float deltaTime) {
            view_extern.UpdateFrame(deltaTime);
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

        private void LoadJson(string path) {
            view_extern.LoadFont(path);
        }

        private void LoadTTF(string path) {
            view_extern.ImportFont(path, (int)numericUpDown_size.Value);
        }

        #endregion

        #region Log
        public void Log(string text) {
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
                return; // Don't pass console toggle to SDL
            }

            // Convert C# KeyCode to SDL Scancode and pass to SDL
            int sdlScancode = KeyMapper.ToSDLScancode(e.KeyCode);
            view_extern.OnKeyboardDown(sdlScancode);
        }

        private void Editor_KeyUp(object sender, KeyEventArgs e) {
            // Convert C# KeyCode to SDL Scancode and pass to SDL
            int sdlScancode = KeyMapper.ToSDLScancode(e.KeyCode);
            view_extern.OnKeyboardUp(sdlScancode);
        }

        #endregion

        private void view_extern_MouseDown(object sender, MouseEventArgs e) {
            int button = MouseButtonMapper.ToSDLMouseButton(e.Button);
            view_extern.OnMouseButtonDown(e.X, e.Y, button);
        }

        private void view_extern_MouseUp(object sender, MouseEventArgs e) {
            int button = MouseButtonMapper.ToSDLMouseButton(e.Button);
            view_extern.OnMouseButtonUp(e.X, e.Y, button);
        }

        private void toolStripButton_openFile(object sender, MouseEventArgs e) {
            string path = Utils.OpenFile("");
            string ext = Path.GetExtension(path);

            switch (ext) {

                case ".json":

                    LoadJson(path);

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

        private void toolStripButton_export(object sender, MouseEventArgs e) {

            string startingPath = System.AppContext.BaseDirectory;
            string name = "default";
            string exten = "json";

            try {
                SaveFileDialog dialog = new SaveFileDialog();

                // Set up file filter based on extension
                dialog.Filter = $"{exten.ToUpper()} Files (*.{exten})|*.{exten}|All Files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.InitialDirectory = startingPath;
                dialog.FileName = name;
                dialog.DefaultExt = exten;
                dialog.AddExtension = true;

                if (dialog.ShowDialog() == DialogResult.OK) {
                    string sFileName = dialog.FileName;

                    // Write the data to the selected file
                    view_extern.ExportFont(sFileName);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error saving file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}