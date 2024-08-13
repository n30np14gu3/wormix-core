using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class ShopResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10003;
    }

    public void SerializeCommand(object command, Stream output)
    {
        if (command is ShopResult result)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(result.GetSize() + 16 /*MD5 Sum*/);

            byte[] buyResultPayload = new byte[result.GetSize()];
            using (MemoryStream ms = new MemoryStream(buyResultPayload))
                result.Serialize(ms);

            byte[] hash = SerializeSecurityUtils.Secure(buyResultPayload);
            
            header.Write(output);
            output.Write(buyResultPayload);
            output.Write(hash);
        }
        else
            throw new InvalidCastException("Invalid ShopResult struct");
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}