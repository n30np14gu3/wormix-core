using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Account;


public class NeedMoneyController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        //Simple (not needed)
        return new NeedMoneyResult
        {
            Result = 3,
            Value = 0
        };
    }
}