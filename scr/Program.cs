/*
* Run with --deinstall to remove the autostart entry
*/

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Hallo, ich bin das Program {Consts.APP_NAME}.");

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
        // TODO: Implement IDisposable
        HotKeyManager.RegisterHotKey(Keys.A, KeyModifiers.Alt);
        HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);

        // run
        Application.Run();
    }

    static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
    {
        // show feedback
        WindowManager.ToggleWindowPin();
        MessageBox.Show("Hotkey gedrückt!", "Bestätigung", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}