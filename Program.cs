using System;
using System.Windows.Forms;

namespace csharp_bmfg {
    static class Program {
        public static Editor editor;

        [STAThread]
        static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ---

            editor = new Editor();
            editor.Show();

            while (editor.active) {

                editor.UpdateFrame();

                editor.PreRender();
                editor.Render();
                editor.SwapBuffers();

                Application.DoEvents();
            }

            // ---

            Application.Exit();
        }
    }
}