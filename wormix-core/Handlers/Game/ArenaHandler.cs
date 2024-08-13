using wormix_core.Controllers;
using wormix_core.Controllers.Game;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Game;

[ControlledBy(typeof(ArenaController))]
public class ArenaHandler : GameMessageHandler
{
    protected override void Process()
    {
        if(Header == null || DataPayload ==null)
            return;
        
        GetArenaBinarySerializer getArenaSerializer = new GetArenaBinarySerializer();
        GetArena arenaRequest;
        using (MemoryStream ms = new MemoryStream(DataPayload))
        {
            arenaRequest = (GetArena)getArenaSerializer.DeserializeCommand(ms, Header);
            Console.WriteLine("New arena request");
            Console.WriteLine($"Get profiles: {arenaRequest.ReturnUsersProfiles}");
        }

        IMessage arena = MessageController!.ProcessMessage(arenaRequest, Client);
        ICommandSerializer? serializer = null;
        
        if (arena is ArenaResult)
            serializer = new ArenaResultBinarySerializer();

        if (arena is ArenaLocked)
            serializer = new ArenaLockedBinarySerializer();

        if (serializer == null)
            throw new Exception("Can't get serializer for GetArena message");
        
        serializer.SerializeCommand(arena, Client?.GetStream()!);
    }
}