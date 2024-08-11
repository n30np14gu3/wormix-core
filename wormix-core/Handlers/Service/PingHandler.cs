using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Service;

public class PingHandler : GameMessageHandler
{
    protected override void Process()
    {
        //Sending PONG
        PongBinarySerializer pong = new PongBinarySerializer();
        pong.SerializeCommand(new(), Client?.GetStream()!);
    }
}