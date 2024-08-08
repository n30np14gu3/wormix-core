using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Session;

namespace wormix_core.Controllers;

public interface IGameController
{
    IMessage ProcessMessage(IMessage gameMessage, TcpSession? session);

    string GetRoute();
}