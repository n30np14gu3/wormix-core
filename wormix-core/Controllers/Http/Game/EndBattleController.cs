using wormix_core.Controllers.Http.Attributes;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Game;

[ApiPost("game/end_battle")]
public class EndBattleController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
       PostRequest(gameSerializable, session);
        return null!;
    }
}