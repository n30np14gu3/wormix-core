using wormix_core.Server;

namespace wormix_core.Configuration;

public class ConfigParser
{
    private Dictionary<string, TcpServer?> _servers = new();
    public void Parse(string configData)
    {
        try
        {
            ServersSetupConfig? config = JsonConvert.DeserializeObject<ServersSetupConfig>(configData);
            if(config == null)
                return;
            
            string serverAddress = config.Local ? "127.0.0.1" : "0.0.0.0";
            foreach (var server in config.Servers)
            {
                if (!server.Value.Enabled)
                    continue;
                
                _servers.TryAdd(server.Key, new Func<TcpServer?>(() =>
                {
                    switch (server.Key)
                    {
                        case "main":
                            return new MainServer(serverAddress, server.Value.Port);
                        case "policy":
                            return new DomainPolicyServer(serverAddress, server.Value.Port);
                    }
                    return null;
                }).Invoke());
            }
        }
        catch
        {
            //
        }
    }

    //SOLID идет тут нахуй
    public void StartServers()
    {
        foreach (var server in _servers)
        {
            if(server.Value == null)
                continue;
            
            Console.WriteLine($"Starting {server.Key} server[{server.Value.Id}] at {server.Value.EndPoint}");
            server.Value.Start();
        }
    }
}