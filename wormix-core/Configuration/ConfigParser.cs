using wormix_core.Server;

namespace wormix_core.Configuration;

public class ConfigParser
{
    private Dictionary<string, TcpServer?> _servers = new();
    
    public void Parse(string configData)
    {
        ServersSetupConfig? config = JsonConvert.DeserializeObject<ServersSetupConfig>(configData);
        if(config == null)
            return;

        if (config.ApiUrl == null || string.IsNullOrWhiteSpace(config.ApiUrl))
            throw new Exception("ApiUrl is undefined!");

        Config.Url = config.ApiUrl;
        
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

    public Dictionary<string, TcpServer?> GetServers() => _servers;
    
}