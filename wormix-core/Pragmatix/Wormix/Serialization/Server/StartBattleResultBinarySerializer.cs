using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class StartBattleResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10006;
    }

    public void SerializeCommand(object command, Stream output)
    {
        if (command is StartBattleResult result)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(result.GetSize() + 16);

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

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        throw new NotImplementedException();
    }
}