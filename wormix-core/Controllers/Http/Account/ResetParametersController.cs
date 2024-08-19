using wormix_core.Controllers.Http.Attributes;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Account;

[ApiPost("account/reset/parameters")]
public class ResetParametersController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameMessage, TcpSession? session)
    {
        //TODO: implement
        return PostRequest(gameMessage, session).ToObject<JObject>()?["data"]?.ToObject<ResetParametersResult>()!;
    }
}