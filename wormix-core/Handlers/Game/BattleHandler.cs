using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Game;

public class BattleHandler : GameMessageHandler
{
    protected override void Process()
    {
        if(Header == null || DataPayload ==null)
            return;
        
        StartBattle startBattle;
        using (MemoryStream ms = new MemoryStream(DataPayload))
        {
            StartBattleBinarySerializer startBattleBinarySerializer = new StartBattleBinarySerializer();
            startBattle = (StartBattle)startBattleBinarySerializer.DeserializeCommand(ms, Header);
        }
        
        Console.WriteLine($"Starting battle: {startBattle.MissionId}");

        StartBattleResult result = new()
        {
            BattleId = 1020
        };
        
        StartBattleResultBinarySerializer serializer = new StartBattleResultBinarySerializer();
        serializer.SerializeCommand(result, Client?.GetStream()!);
    }
}