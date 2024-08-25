using System.Runtime.InteropServices;

public class Uninstaller
{
    public void Execute()
    {
        RemoveFromStartup(Consts.APP_NAME);

        Console.WriteLine("Das Programm wurde erfolgreich deinstalliert.");
    }

    private void RemoveFromStartup(string appName)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.WriteLine("Autostart wird auf dieser Plattform nicht unterstützt.");
            return;
        }

        using var registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
        if (registryKey?.GetValue(appName) != null)
        {
            registryKey.DeleteValue(appName);
            Console.WriteLine("Autostart-Eintrag entfernt.");
        }
        else
        {
            Console.WriteLine("Kein Autostart-Eintrag gefunden.");
        }
    }
}