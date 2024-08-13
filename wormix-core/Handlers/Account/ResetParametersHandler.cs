using wormix_core.Controllers.Account;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Account;

public class ResetParametersHandler : GameMessageHandler
{
    protected override void Process()
    {
        if (DataPayload == null || Header == null)
            return;

        using (MemoryStream ms = new MemoryStream(DataPayload))
        {
            object requestObject = new ResetParametersBinarySerializer().DeserializeCommand(ms, Header);
            if (requestObject is ResetParameters resetRequest)
            {
                IMessage result = new ResetParametersController().ProcessMessage(resetRequest, Client);
                new ResetParametersResultBinarySerializer().SerializeCommand(result, Client?.GetStream()!);
            }
        }
    }
}