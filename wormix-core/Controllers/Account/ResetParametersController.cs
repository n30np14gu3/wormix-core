using wormix_core.Controllers.Attributes;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

[ApiPost("account/reset/stats")]
public class ResetParametersController : GameController
{
    public override ISerializable ProcessMessage(ISerializable gameMessage, TcpSession? session)
    {
        //TODO: implement
        return new ResetParametersResult
        {
            Result = ResetParametersResult.Success
        };
    }
}