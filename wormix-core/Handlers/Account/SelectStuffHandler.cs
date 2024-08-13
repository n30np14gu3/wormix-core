using wormix_core.Controllers.Account;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Account;

public class SelectStuffHandler : GameMessageHandler
{
    protected override void Process()
    {
        if (DataPayload == null || Header == null)
            return;

        using (MemoryStream ms = new MemoryStream(DataPayload))
        {
            SelectStuffBinarySerializer serializer = new SelectStuffBinarySerializer();
            if (serializer.DeserializeCommand(ms, Header) is SelectStuff selectStuffRequest)
            {
                IMessage response = new SelectStuffController().ProcessMessage(selectStuffRequest, Client);
                if (response is SelectStuffResult result)
                    new SelectStuffResultBinarySerializer().SerializeCommand(result, Client?.GetStream()!);
            }
        }
        
    }
}