using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers;

public interface IGameController
{
    ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session);

    string GetRoute();
}