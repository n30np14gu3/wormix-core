using wormix_core.Controllers.Http.Attributes;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Account;

[ApiPost("account/select_stuff")]
public class SelectStuffController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameMessage, TcpSession? session)
    {
        JObject result = PostRequest(gameMessage, session).ToObject<JObject>()!;
        return result["data"]!.ToObject<SelectStuffResult>();
    }
}