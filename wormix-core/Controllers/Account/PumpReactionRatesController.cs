using wormix_core.Controllers.Attributes;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

[ApiPost("house/pump_reactions")]
public class PumpReactionRatesController : GameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        throw new NotImplementedException();
    }
}