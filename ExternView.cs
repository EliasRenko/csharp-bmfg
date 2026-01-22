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

            // Set SDL window as child of panel
            SetParent(sdlWindowHandle, panel_extern.Handle);
            Externs.SetWindowPosition(0, 0);

            //MoveWindow(sdlWindowHandle, 0, 0, panel1.Width, panel1.Height, true);

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

        public void PostRender() {
            //Externs.PostRender();
        }

        public void Tick() {
            Externs.UpdateFrame();
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
            panel_extern.BackColor = SystemColors.ControlDark;
            panel_extern.Dock = DockStyle.Fill;
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
