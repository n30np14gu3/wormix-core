using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Service;

public class PingHandler : GameMessageHandler
{
    protected override void Process()
    {
        //Only pong header
        byte[] response = new byte[BinaryCommandHeader.HeaderSize];
        using (MemoryStream ms = new MemoryStream(response))
        {
            PongBinarySerializer pong = new PongBinarySerializer();
            pong.SerializeCommand(new(), ms);
        }
        
        //Sending PONG
        Client?.SessionClient?.Client.Send(response);
    }
}