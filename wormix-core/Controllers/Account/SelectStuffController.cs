using wormix_core.Controllers.Attributes;
using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

[ApiPost("account/select_stuff")]
public class SelectStuffController : GameController
{
    public override ISerializable ProcessMessage(ISerializable gameMessage, TcpSession? session)
    {
        JObject result = HttpProcessor.PostRequest(Url, gameMessage, session).ToObject<JObject>()!;
        return result["data"]!.ToObject<SelectStuffResult>();
    }
}