using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Controllers.Game;

public class BattleController : GameControllerBehavior
{
    protected override void Process()
    {
        if(Header == null || DataPayload ==null)
            return;
        
        StartBattle startBattle = new();
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
        

        byte[] response = new byte[BinaryCommandHeader.HeaderSize + result.GetSize() + 16];
        using (MemoryStream ms = new MemoryStream(response))
        {
            StartBattleResultBinarySerializer serializer = new StartBattleResultBinarySerializer();
            serializer.SerializeCommand(result, ms);
        }

        Client?.SessionClient?.Client.Send(response);
    }
}