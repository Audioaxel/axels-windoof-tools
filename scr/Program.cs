/*
* Run with --deinstall to remove the autostart entry
*/

public class Program
{
    static void Main(string[] args)
    {
        if (args.Contains("--deinstall", StringComparer.OrdinalIgnoreCase))
        {
            Uninstaller uninstaller = new Uninstaller();
            uninstaller.Execute();
            return;
        }

        AutoStart autoStart = new();
        autoStart.RegisterInStartup();


        Console.WriteLine($"Hallo, ich bin das Program {Consts.APP_NAME}.");

        HotKeyManager.RegisterHotKey(Keys.A, KeyModifiers.Alt);
        HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);

        Console.ReadLine();
    }

    static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
    {
        Console.WriteLine("Hit me!");
    }
}