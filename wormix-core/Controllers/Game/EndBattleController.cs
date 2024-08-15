using wormix_core.Controllers.Attributes;
using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers.Game;

[ApiPost("game/end_battle")]
public class EndBattleController : GameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        HttpProcessor.PostRequest(Url, gameSerializable, session);
        return null!;
    }
}