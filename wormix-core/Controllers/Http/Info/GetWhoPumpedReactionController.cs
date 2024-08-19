using wormix_core.Controllers.Http.Attributes;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Info;

[ApiPost("info/pumped_reaction")]
public class GetWhoPumpedReactionController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        JObject result = PostRequest(gameSerializable, session).ToObject<JObject>()!;
        return result["data"]!.ToObject<WhoPumpedReactionResult>();
    }
}