using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Game;

public class ArenaHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session) : 
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is GetArena arenaRequest)
        {
            Console.WriteLine("New arena request");
            Console.WriteLine($"Get profiles: {arenaRequest.ReturnUsersProfiles}");
            
            ISerializable arena = MessageController.ProcessMessage(arenaRequest, Client);
            ICommandSerializer? serializer = null;
        
            if (arena is ArenaResult)
                serializer = new ArenaResultBinarySerializer();

            if (arena is ArenaLocked)
                serializer = new ArenaLockedBinarySerializer();

            if (serializer == null)
                throw new Exception("Can't get serializer for GetArena message");
        
            serializer.SerializeCommand(arena, Client.GetStream());
        }


    }
}