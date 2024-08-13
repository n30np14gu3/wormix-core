using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Client;

namespace wormix_core.Handlers.Game;

public class EndBattleHandler : GameMessageHandler
{
    protected override void Process()
    {
        if(Header == null || DataPayload ==null)
            return;
        
        EndBattleSerializer requestSerializer = new EndBattleSerializer();
        using (MemoryStream ms = new MemoryStream(DataPayload))
        {
            object request = requestSerializer.DeserializeCommand(ms, Header);
            if (request is EndBattle endBattle)
            {
                
            }
        }
    }
}