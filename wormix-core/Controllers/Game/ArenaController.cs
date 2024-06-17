using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Messages.Structures;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Controllers.Game;

public class ArenaController : GameControllerBehavior
{
    protected override void Process()
    {
        if(Header == null || DataPayload ==null)
            return;
        
        GetArenaBinarySerializer getArena = new GetArenaBinarySerializer();
        GetArena arenaRequest = new();
        using (MemoryStream ms = new MemoryStream(DataPayload))
        {
            arenaRequest = (GetArena)getArena.DeserializeCommand(ms, Header);
            Console.WriteLine("New arena request");
            Console.WriteLine($"Get profiles: {arenaRequest.ReturnUsersProfiles}");
        }

        ArenaResult arena = new()
        {
            UserProfileStructures = new(),
            BossAvailable = true,
            BattlesCount = 1337,
            CurrentMission = 20
        };

        byte[] response = new byte[BinaryCommandHeader.HeaderSize + arena.GetSize()];
        using (MemoryStream ms = new MemoryStream(response))
        {
            ArenaResultBinarySerializer serializer = new ArenaResultBinarySerializer();
            serializer.SerializeCommand(arena, ms);
        }

        Client?.Client.Send(response);
    }
}