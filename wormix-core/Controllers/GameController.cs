using wormix_core.Controllers.Attributes;
using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers;

public class GameController
{
    protected readonly string Url = Config.Url;
    
    public GameController()
    {
        var attributes = GetType().GetCustomAttributes(true);
        foreach (var attribute in attributes)
        {
            if (attribute is ApiPost postRequest)
                Url = $"{Config.Url}{postRequest.Route}";
        }
    }

    public virtual ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        //Implementation needed
        return null!;
    }
}