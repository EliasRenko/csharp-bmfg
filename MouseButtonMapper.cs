using System.Windows.Forms;

namespace csharp_bmfg {
    public static class MouseButtonMapper {
        /// <summary>
        /// Converts Windows Forms MouseButtons to SDL mouse button values
        /// Based on SDL3 mouse button constants
        /// </summary>
        public static int ToSDLMouseButton(MouseButtons button) {
            // SDL mouse button values
            switch (button) {
                case MouseButtons.Left:
                    return 1; // SDL_BUTTON_LEFT
                case MouseButtons.Middle:
                    return 2; // SDL_BUTTON_MIDDLE
                case MouseButtons.Right:
                    return 3; // SDL_BUTTON_RIGHT
                case MouseButtons.XButton1:
                    return 4; // SDL_BUTTON_X1
                case MouseButtons.XButton2:
                    return 5; // SDL_BUTTON_X2
                default:
                    return 0; // Unknown
            }
        }
    }
}
