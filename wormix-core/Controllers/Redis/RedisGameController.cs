using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers.Redis;

public abstract class RedisGameController : IGameController
{
    public abstract ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session);
    
}