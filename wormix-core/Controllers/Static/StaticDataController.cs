using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers.Static;

public abstract class StaticDataController : IGameController
{
    public abstract ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session);
}