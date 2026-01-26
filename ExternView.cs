using static csharp_bmfg.Externs;

namespace csharp_bmfg {
    public partial class ExternView : UserControl {

        public CallbackDelegate logCallback;
        public bool active = false;

        //private Panel panel_extern;
        private IntPtr sdlWindowHandle = IntPtr.Zero;

        public ExternView() {

            InitializeComponent();

            // ** Events
            MouseClick += MainView_MouseClick;
        }

        // CallbackDelegate callback
        public void Init(CallbackDelegate callback) {

            logCallback = callback;

            if (Externs.InitWithCallback(callback) != 1) {
                MessageBox.Show("Failed to initialize engine", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the SDL window handle
            sdlWindowHandle = Externs.GetWindowHandle();
            if (sdlWindowHandle == IntPtr.Zero) {
                MessageBox.Show("Failed to get SDL window handle", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Remove window border styles to prevent Vista-style frame
            long style = Externs.GetWindowLong(sdlWindowHandle, Externs.GWL_STYLE);
            style &= ~(Externs.WS_CAPTION | Externs.WS_THICKFRAME | Externs.WS_MINIMIZE |
                       Externs.WS_MAXIMIZE | Externs.WS_SYSMENU | Externs.WS_BORDER | Externs.WS_DLGFRAME);
            style |= Externs.WS_CHILD | Externs.WS_VISIBLE;
            Externs.SetWindowLong(sdlWindowHandle, Externs.GWL_STYLE, style);

            // Force window frame refresh to apply style changes
            Externs.SetWindowPos(sdlWindowHandle, IntPtr.Zero, 0, 0, 0, 0,
                Externs.SWP_FRAMECHANGED | Externs.SWP_NOMOVE | Externs.SWP_NOSIZE |
                Externs.SWP_NOZORDER | Externs.SWP_NOACTIVATE);

            // Disable rounded corners (Windows 11) - must be done before SetParent
            int preference = Externs.DWMWCP_DONOTROUND;
            Externs.DwmSetWindowAttribute(sdlWindowHandle, Externs.DWMWA_WINDOW_CORNER_PREFERENCE, ref preference, sizeof(int));

            // Set SDL window as child of panel
            SetParent(sdlWindowHandle, panel_extern.Handle);
            Externs.SetWindowPosition(0, 0);

            // Size the SDL window to match the panel
            Externs.MoveWindow(sdlWindowHandle, 0, 0, panel_extern.Width, panel_extern.Height, true);

            // Load default state (CollisionTestState)
            Externs.LoadState(0);

            //engineInitialized = true;
            //btnRunEngine.Enabled = false;

            // Start delta timer
            //deltaTimer.Start();

            // Start render loop on UI thread - runs continuously
            //renderTimer = new System.Windows.Forms.Timer();
            //renderTimer.Interval = 1; // Run as fast as possible, limited by VSync
            //renderTimer.Tick += RenderFrame;
            //renderTimer.Start();

            active = true;

            //Externs.Init();
            //Externs.InitWithCallback(callback);

            //Externs.CreateWindowFrom(Handle);

            //IntPtr sdlHandle = Externs.GetHandle();

            // ** Get the parent window handle.
            //IntPtr windowHandle = Handle;

            //Externs.SetWindowPos(
            //    sdlHandle,
            //    Handle,
            //    0,
            //    0,
            //    0,
            //    0,
            //    0x0401 // NOSIZE | SHOWWINDOW
            //);

            // Attach the SDL2 window to the panel
            //Externs.SetParent(sdlHandle, Handle);
            //Externs.ShowWindow(sdlHandle, 1); // SHOWNORMAL
            //Externs.SetWindowLongA(sdlHandle, 0, 0x80000000L);
            //Externs.EnableWindow(sdlHandle, true);
        }

        public void Release() {

            if (active == true) {
                Externs.Release();
            }
        }

        public void AddEntity(int id) {

            //Externs.AddEntity(id);
        }

        public void SelectEntity(int id) {

            //Externs.SelectEntity(id);
        }

        public void DeselectEntity() {

            //Externs.DeselectEntity();
        }

        public void UpdateEntity(int id, int x, int y) {

            //Externs.UpdateEntity(id, x, y);
        }

        public void UpdateMap(string hex) {

            //Externs.UpdateMap(hex);
        }

        public void PreRender() {
            //Externs.PreRender();
        }

        public void Render() {
            Externs.Render();
        }

        public void SwapBuffers() {
            Externs.SwapBuffers();
        }

        public void UpdateFrame() {
            Externs.UpdateFrame();
        }

        public void mouseClick(int x, int y) {
            //Externs.OnMouseClick(x, y);
        }

        private void MainView_MouseClick(object sender, MouseEventArgs e) {

            //logCallback?.Invoke("X: " + e.X + " Y: " + e.Y);

            //Externs.OnMouseClick(e.X, e.Y);
        }

        private Panel panel_extern;

        private void InitializeComponent() {
            panel_extern = new Panel();
            SuspendLayout();
            // 
            // panel_extern
            // 
            panel_extern.Dock = DockStyle.Fill;
            panel_extern.Enabled = false;
            panel_extern.Location = new Point(0, 0);
            panel_extern.Name = "panel_extern";
            panel_extern.Size = new Size(150, 150);
            panel_extern.TabIndex = 0;
            // 
            // ExternView
            // 
            Controls.Add(panel_extern);
            Name = "ExternView";
            ResumeLayout(false);
        }

        private void view_Load(object sender, EventArgs e) {

        }
    }
}
