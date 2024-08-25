using System;
using System.Runtime.InteropServices;

public class ConsoleManager
{
    const int SW_HIDE = 0;
    const int SW_SHOW = 5;

    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    public  void HideConsole()
    {
        var handle = GetConsoleWindow();
        ShowWindow(handle, SW_HIDE);
    }

    public void ShowConsole()
    {
        var handle = GetConsoleWindow();
        ShowWindow(handle, SW_SHOW);
    }
}