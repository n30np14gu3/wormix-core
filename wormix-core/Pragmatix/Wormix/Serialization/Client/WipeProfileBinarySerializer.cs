using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class WipeProfileBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 48;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        WipeProfile result = new();
        BinaryReader br = new BinaryReader(input);
        result.ConfirmCode = br.ReadUTF8();
        return result;
    }
}