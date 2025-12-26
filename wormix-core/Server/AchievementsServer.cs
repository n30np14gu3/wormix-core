using wormix_core.Session;

namespace wormix_core.Server;

public class AchievementsServer(string address, int port) : TcpServer(address, port)
{
    protected override TcpSession CreateSession()
    {
        return new AchievementsSession(this);
    }
    
}