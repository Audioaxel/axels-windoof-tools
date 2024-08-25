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

        AutoStart autoStart = new AutoStart();
        autoStart.RegisterInStartup();

        Console.WriteLine($"Hallo, ich bin das Program {Consts.APP_NAME}.");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}