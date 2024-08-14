using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

public class ResetParametersController : IGameController
{
    public ISerializable ProcessMessage(ISerializable gameMessage, TcpSession? session)
    {
        //TODO: implement
        return new ResetParametersResult
        {
            Result = ResetParametersResult.Success
        };
    }

    public string GetRoute()
    {
        return "account/reset/stats";
    }
}