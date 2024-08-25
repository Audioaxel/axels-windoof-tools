/*
* Run with --deinstall to remove the autostart entry
*/

public class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine($"Hallo, ich bin das Program {Consts.APP_NAME}.");

        // deinstall
        if (args.Contains("--deinstall", StringComparer.OrdinalIgnoreCase))
        {
            Uninstaller uninstaller = new();
            uninstaller.Execute();
            return;
        }

        // register autostart
        // TODO: check if already registered
        AutoStart autoStart = new();
        autoStart.RegisterInStartup();

        // hide console
        ConsoleManager consoleManager = new();
        consoleManager.HideConsole();

        // register hotkey
        WindowManager windowManager = new();
        // TODO: Implement IDisposable
        HotKeyManager.RegisterHotKey(Keys.A, KeyModifiers.Alt);
        HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(windowManager.HotKeyManager_HotKeyPressed);

        // run
        Application.Run();
    }
}