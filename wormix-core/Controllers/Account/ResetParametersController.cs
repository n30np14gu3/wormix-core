using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

public class ResetParametersController : IGameController
{
    public IMessage ProcessMessage(IMessage gameMessage, TcpSession? session)
    {
        //TODO: implement
        return new ResetParametersResult()
        {
            Result = (short)ResetParametersResult.Success
        };
    }

    public string GetRoute()
    {
        return "";
    }
}