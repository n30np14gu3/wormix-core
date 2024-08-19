using wormix_core.Configuration;
using wormix_core.Gui;

namespace wormix_core;

abstract class Program
{
    /// <summary>
    /// Main entry point
    /// </summary>
    /// <param name="argv">argv[0] - path to json config</param>
    static void Main(string[] argv)
    {
        //Gui processor
        GuiProcessor gui = new();
        
        
        if (argv.Length < 1)
        {
            Console.WriteLine($"Use {Environment.ProcessPath} <config.json>");
            return;
        }
        
        Console.WriteLine("Wormix private server\nParsing configuration...");
        if (!File.Exists(argv[0]))
        {
            Console.WriteLine($"Can't find file {argv[0]}");
            return;
        }

        string configData;
        
        try
        {
            using FileStream fs = new FileStream(argv[0], FileMode.Open, FileAccess.Read);
            using StreamReader sr = new StreamReader(fs);
            configData = sr.ReadToEnd();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Read config exception. Error: {ex.Message}");
            return;
        }


        //Config parser
        ConfigParser parser = new();
        
        try
        {
            parser.Parse(configData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Parsing & setup exception. Error: {ex.Message}");
            return;
        }

        try
        {
            Console.WriteLine("Starting servers...");
            foreach (var server in parser.GetServers())
            {
                if(server.Value == null)
                    continue;
                Console.WriteLine($"Starting {server.Key} server at {server.Value.EndPoint}");
                server.Value.Start();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Starting servers exception. Error: {ex.Message}");
            return;
        }
        
        Console.WriteLine("Setup completed. Let's rolling...");
        Thread.Sleep(3000);
        Console.Clear();
        gui.GuiLoop();
    }
}