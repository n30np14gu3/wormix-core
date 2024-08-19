using wormix_core.Controllers.Http.Attributes;
using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers.Http;

public abstract class HttpGameController : IGameController
{
    protected readonly string Url = Config.Url;
    
    public HttpGameController()
    {
        var attributes = GetType().GetCustomAttributes(true);
        foreach (var attribute in attributes)
        {
            if (attribute is ApiPost postRequest)
                Url = $"{Config.Url}{postRequest.Route}";
        }
    }

    public abstract ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session);

    protected JToken PostRequest(ISerializable gameMessage, TcpSession? session)
    {
        return HttpProcessor.PostRequest(Url, gameMessage, session);
    }
}