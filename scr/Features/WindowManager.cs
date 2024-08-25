using System.Runtime.InteropServices;

public static class WindowManager
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    private static IntPtr HWND_TOPMOST = new IntPtr(-1);
    private static IntPtr HWND_NOTOPMOST = new IntPtr(-2);
    private const uint SWP_NOSIZE = 0x0001;
    private const uint SWP_NOMOVE = 0x0002;
    private const uint SWP_SHOWWINDOW = 0x0040;

    private static IntPtr _currentWindowHandle = IntPtr.Zero;
    private static bool _isPinned = false;

    public static void ToggleWindowPin()
    {
        if (!_isPinned)
        {
            _currentWindowHandle = GetForegroundWindow();
            SetWindowPos(_currentWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            _isPinned = true;
        }
        else
        {
            SetWindowPos(_currentWindowHandle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            _isPinned = false;
        }
    }

    public static bool IsPinned() => _isPinned;
}
