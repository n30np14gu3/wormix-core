using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class StartBattleResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10006;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is StartBattleResult result)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(result.GetSize() + 16 /*MD5 Hash*/);

            byte[] resultPayload = new byte[result.GetSize()];
            using(MemoryStream ms = new MemoryStream(resultPayload))
                result.Serialize(ms);

            byte[] hash = SerializeSecurityUtils.Secure(resultPayload);
            
            header.Write(output);
            output.Write(resultPayload);
            output.Write(hash);
        }
        else
            throw new InvalidCastException("Invalid StartBattleResult object");
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        return null!;
    }
}