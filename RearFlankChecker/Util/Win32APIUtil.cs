using System;
using System.Runtime.InteropServices;

namespace RearFlankChecker.Util
{
    class Win32APIUtils
    {
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        const int WS_EX_TRANSPARENT = 0x00000020;
        const int GWL_EXSTYLE = (-20);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);


        public static void DragMove(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        public static void SetWS_EX_TRANSPARENT(IntPtr handle, bool value)
        {
            int origStyle = GetWindowLong(handle, GWL_EXSTYLE);

            int style;
            if (value)
                style = origStyle | WS_EX_TRANSPARENT;
            else
                style = origStyle & ~WS_EX_TRANSPARENT;

            SetWindowLong(handle, GWL_EXSTYLE, style);
        }
    }
}
