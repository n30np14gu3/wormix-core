using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class NeedMoneyResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10008;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is NeedMoneyResult)
        {
            byte[] fullPacket = new byte[BinaryCommandHeader.HeaderSize + command.GetSize()];
            using (MemoryStream ms = new MemoryStream(fullPacket))
            {
                BinaryCommandHeader header = new BinaryCommandHeader();
                header.SetCommandId(GetCommandId());
                header.SetLength(command.GetSize());
                header.Write(ms);
                command.Serialize(ms);
            }
            output.Write(fullPacket);
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not neded
        return null!;
    }
}