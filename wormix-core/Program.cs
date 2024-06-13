using System.Net;
using wormix_core.Configuration;
using wormix_core.Gui;
using wormix_core.Server;

namespace wormix_core;

abstract class Program
{
    static void Main(string[] argv)
    {
        MainServer mainServer;
        DomainPolicyServer policyServer;
        AchievementServer achievementServer;
        PvpServer pvpServer;
        
        GuiProcessor gui = new();
        
        if (argv.Length < 1)
        {
            Console.WriteLine($"Use {Environment.ProcessPath} <config.json>");
            return;
        }
        
        Console.WriteLine("Wormix private server\nParsing configuratin...");
        if (!File.Exists(argv[0]))
        {
            Console.WriteLine($"Can't find file {argv[0]}");
            return;
        }

        ServersSetupConfig? config = new();
        try
        {
            using FileStream fs = new FileStream(argv[0], FileMode.Open, FileAccess.Read);
            using StreamReader sr = new StreamReader(fs);
            string configData = sr.ReadToEnd();
            config = JsonConvert.DeserializeObject<ServersSetupConfig>(configData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Parsing error: {ex.Message}");
        }

        if (config == null)
        {
            Console.WriteLine("Invalid config data");
            return;
        }
        
        try
        {
            Console.WriteLine("Setup servers");
            IPAddress serverAddress = config.Local ? IPAddress.Parse("127.0.0.1") : IPAddress.Parse("0.0.0.0");
            
            foreach (var server in config.Servers)
            {
                switch (server.Key)
                {
                    case "policy":
                        if (server.Value.Enabled)
                        {
                            Console.WriteLine($"Starting domain policy server at {serverAddress}:{server.Value.Port}");
                            policyServer = new DomainPolicyServer(serverAddress, server.Value.Port);
                            policyServer.Start();
                        }
                        break;
                    case "main":
                        if (server.Value.Enabled)
                        {
                            Console.WriteLine($"Starting main server at {serverAddress}:{server.Value.Port}");
                            mainServer = new MainServer(serverAddress, server.Value.Port);
                            mainServer.Start();
                        }
                        break;
                        case "pvp":
                        if (server.Value.Enabled)
                        {
                            Console.WriteLine($"Starting PvP server at {serverAddress}:{server.Value.Port}");
                            pvpServer = new PvpServer(serverAddress, server.Value.Port);
                            pvpServer.Start();
                        }
                        break;
                    case "achieve":
                        if (server.Value.Enabled)
                        {
                            Console.WriteLine($"Starting Achievement server at {serverAddress}:{server.Value.Port}");
                            achievementServer = new AchievementServer(serverAddress, server.Value.Port);
                            achievementServer.Start();
                        }
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Setup servers failed: {ex.Message}");
            Environment.Exit(-1);
        }
        
        Console.WriteLine("Setup completed. Let's rolling...");
        Thread.Sleep(1000);
        Console.Clear();
        gui.GuiLoop();
    }
}