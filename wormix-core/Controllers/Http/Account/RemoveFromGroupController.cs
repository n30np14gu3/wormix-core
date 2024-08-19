using wormix_core.Controllers.Http.Attributes;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Account;

[ApiPost("team/remove")]
public class RemoveFromGroupController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        return PostRequest(gameSerializable, session).ToObject<JObject>()?["data"]?.ToObject<RemoveFromGroupResult>()!;
    }
}