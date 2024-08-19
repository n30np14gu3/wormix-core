using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class PumpReactionRatesResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10033;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is PumpReactionRatesResult)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(command.GetSize());

            //Need for work
            byte[] result = new byte[command.GetSize() + BinaryCommandHeader.HeaderSize];
            using (MemoryStream ms = new MemoryStream(result))
            {
                header.Write(ms);
                command.Serialize(ms);
            }
            
            output.Write(result);
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}