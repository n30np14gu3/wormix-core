using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

public class PumpReactionRatesController : IGameController
{
    public ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        throw new NotImplementedException();
    }

    public string GetRoute()
    {
        return "house/pump_reactions";
    }
}