using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class SelectStuffResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10022;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is SelectStuffResult result)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(result.GetSize() + 16 /*MD5 Sum*/);

            byte[] payload = new byte[result.GetSize()];
            using (MemoryStream ms = new MemoryStream(payload))
                result.Serialize(ms);

            byte[] hash = SerializeSecurityUtils.Secure(payload);
            
            header.Write(output);
            output.Write(payload);
            output.Write(hash);
        }
        else
            throw new InvalidCastException("Invalid EnterAccount struct");
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}