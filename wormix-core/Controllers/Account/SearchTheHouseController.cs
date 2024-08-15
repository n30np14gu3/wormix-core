using wormix_core.Controllers.Attributes;
using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

[ApiPost("house/search")]
public class SearchTheHouseController : GameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        JObject result = HttpProcessor.PostRequest(Url, gameSerializable, session).ToObject<JObject>()!;
        return result["data"]!.ToObject<SearchTheHouseResult>();
    }
}