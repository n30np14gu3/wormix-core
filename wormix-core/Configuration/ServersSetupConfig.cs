namespace wormix_core.Configuration;

[Serializable]
public class ServersSetupConfig
{
    public bool Local;
    
    public Dictionary<string, ServerConfig> Servers = new();
    
    public string? ApiUrl;
}