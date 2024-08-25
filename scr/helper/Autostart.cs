using System.Diagnostics;
using System.Runtime.InteropServices;

public class AutoStart
{
    public void RegisterInStartup()
    {
        string? exePath = Process.GetCurrentProcess().MainModule?.FileName;

        if (exePath == null)
        {
            return;
        }

        RegisterInStartupWindows(Consts.APP_NAME, exePath);
    }

    private void RegisterInStartupWindows(string appName, string exePath)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // Alternative Implementierung für andere Plattformen
            Console.WriteLine("Autostart wird auf dieser Plattform nicht unterstützt.");
            return;
        }

        using var registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
        registryKey?.SetValue(appName, exePath);
    }
}