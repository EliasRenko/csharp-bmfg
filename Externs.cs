using System;
using System.Runtime.InteropServices;

namespace csharp_bmfg {
    public class Externs
    {
        public const string DLL = "BMFG_Export-debug.dll";

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackDelegate([MarshalAs(UnmanagedType.LPStr)] string message);


        [DllImport(DLL, EntryPoint = "init")]
        public static extern int Init();


        [DllImport(DLL, EntryPoint = "loadTexture", CharSet = CharSet.Ansi)]
        public static extern void LoadTexture(string filepath, int tileSize, string id);


        [DllImport(DLL, EntryPoint = "release")]
        public static extern void Release();

        [DllImport(DLL, EntryPoint = "initWithCallback")]
        public static extern int InitWithCallback(CallbackDelegate callback);

        [DllImport(DLL, EntryPoint = "updateFrame")]
        public static extern void UpdateFrame();

        [DllImport(DLL, EntryPoint = "preRender")]
        public static extern void PreRender();

        [DllImport(DLL, EntryPoint = "render")]
        public static extern void Render();

        [DllImport(DLL, EntryPoint = "postRender")]
        public static extern void PostRender();

        [DllImport(DLL, EntryPoint = "swapBuffers")]
        public static extern void SwapBuffers();

        // --- States

        [DllImport(DLL, EntryPoint = "loadState")]
        public static extern void LoadState(int id);

        // ---

        [DllImport(DLL, EntryPoint = "addEntity")]
        public static extern void AddEntity(int id);

        [DllImport(DLL, EntryPoint = "selectEntity")]
        public static extern void SelectEntity(int id);

        [DllImport(DLL, EntryPoint = "deselectEntity")]
        public static extern void DeselectEntity();

        [DllImport(DLL, EntryPoint = "updateEntity")]
        public static extern void UpdateEntity(int id, int x, int y);

        [DllImport(DLL, EntryPoint = "updateMap")]
        public static extern void UpdateMap(string hex);

        [DllImport(DLL, EntryPoint = "update")]
        public static extern void Update();


        // Window
        [DllImport(DLL, EntryPoint = "getWindowHandle")]
        public static extern IntPtr GetWindowHandle();

        [DllImport(DLL, EntryPoint = "createWindowFrom")]
        public static extern void CreateWindowFrom(IntPtr handle);

        [DllImport(DLL, EntryPoint = "setWindowPosition")]
        public static extern void SetWindowPosition(int x, int y);

        [DllImport(DLL, EntryPoint = "Add", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int Add(int a, int b, string input, CallbackDelegate callback);

        [DllImport(DLL, EntryPoint = "setLogDispacher", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void SetLogDispacher(CallbackDelegate callback);

        [DllImport(DLL, EntryPoint = "onMouseClick")]
        public static extern void OnMouseClick(int x, int y);

        #region WinAPI Entry Points

        [DllImport("user32.dll") ]
        public static extern IntPtr SetWindowPos(
            IntPtr handle,
            IntPtr handleAfter,
            int x,
            int y,
            int cx,
            int cy,
            uint flags
        );

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr child, IntPtr newParent);

        [DllImport("user32.dll")]
        public static extern IntPtr ShowWindow(IntPtr handle, int command);

        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongA")]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongA")]
        public static extern long SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

        [DllImport("user32.dll")]
        public static extern long SetWindowLongA(IntPtr hWnd, int nIndex, long dwNewLong);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        // DWM constants
        public const int DWMWA_WINDOW_CORNER_PREFERENCE = 33;
        public const int DWMWCP_DONOTROUND = 1;

        // Window style constants
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;
        public const long WS_CAPTION = 0x00C00000L;
        public const long WS_THICKFRAME = 0x00040000L;
        public const long WS_MINIMIZE = 0x20000000L;
        public const long WS_MAXIMIZE = 0x01000000L;
        public const long WS_SYSMENU = 0x00080000L;
        public const long WS_BORDER = 0x00800000L;
        public const long WS_DLGFRAME = 0x00400000L;
        public const long WS_CHILD = 0x40000000L;
        public const long WS_VISIBLE = 0x10000000L;
        
        // Extended window styles
        public const long WS_EX_CLIENTEDGE = 0x00000200L;
        public const long WS_EX_WINDOWEDGE = 0x00000100L;
        public const long WS_EX_STATICEDGE = 0x00020000L;
        public const long WS_EX_DLGMODALFRAME = 0x00000001L;
        
        // SetWindowPos flags
        public const uint SWP_FRAMECHANGED = 0x0020;
        public const uint SWP_NOMOVE = 0x0002;
        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_NOZORDER = 0x0004;
        public const uint SWP_NOACTIVATE = 0x0010;

        #endregion
    }
}
