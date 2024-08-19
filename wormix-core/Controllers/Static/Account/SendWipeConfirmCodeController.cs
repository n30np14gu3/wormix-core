using wormix_core.Controllers.Http;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Static.Account;

public class SendWipeConfirmCodeController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        return new SendWipeConfirmCodeResponse
        {
            Result = 0
        };
    }
}