using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class SearchTheHouseResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10021;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is SearchTheHouseResult)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(command.GetSize() + 16 /*MD5 Sum*/);

            byte[] payload = new byte[command.GetSize()];
            using (MemoryStream ms = new MemoryStream(payload))
                command.Serialize(ms);

            byte[] hash = SerializeSecurityUtils.Secure(payload);
            
            header.Write(output);
            output.Write(payload);
            output.Write(hash);
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        return null!;
    }
}