using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;

namespace OverlayWindow
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class OverlayGame : Game
    {
        #region DllImports
        [DllImport("kernel32.dll")]
        static extern void SetLastError(uint dwErrCode);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("dwmapi.dll")]
        static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref int[] pMarInset);

        const int GWL_EXSTYLE = -20;
        const int LWA_ALPHA = 0x00000002;
        const int WS_EX_LAYERED = 0x00080000;
        const int WS_EX_TRANSPARENT = 0x00000020;
        const int WS_EX_NOACTIVATE = 0x08000000;
        IntPtr HWND_TOPMOST = (IntPtr)(-1);
        const int SWP_NOMOVE = 0x0002;
        const int SWP_NOSIZE = 0x0001;
        const int S_OK = 0x00000000;
        #endregion

        public OverlayGame()
        {
            Window.IsBorderless = true;

            // Set to layered, transparent window.
            SetLastError(0);
            int ret = SetWindowLong(Window.Handle, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT | WS_EX_NOACTIVATE);
            if (ret == 0 && Marshal.GetLastWin32Error() != 0)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            // Set to top-most window.
            if (!SetWindowPos(Window.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE))
                throw new Win32Exception(Marshal.GetLastWin32Error());

            // Required in order to make layered window visible.
            if (!SetLayeredWindowAttributes(Window.Handle, 0, 255, LWA_ALPHA))
                throw new Win32Exception(Marshal.GetLastWin32Error());

            int[] margins = { -1 };
            if ((ret = DwmExtendFrameIntoClientArea(Window.Handle, ref margins)) != S_OK)
                throw new Win32Exception(ret);
        }
    }
}
