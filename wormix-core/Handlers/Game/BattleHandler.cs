using wormix_core.Controllers;
using wormix_core.Controllers.Game;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Game;

[ControlledBy(typeof(StartBattleController))]
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

        IMessage result = MessageController!.ProcessMessage(startBattle, Client);
        StartBattleResultBinarySerializer serializer = new StartBattleResultBinarySerializer();
        serializer.SerializeCommand(result, Client?.GetStream()!);
    }
}