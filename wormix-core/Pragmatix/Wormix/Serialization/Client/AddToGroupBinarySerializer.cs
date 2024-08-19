using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class AddToGroupBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 12;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        AddToGroup result = new();
        BinaryReader br = new BinaryReader(input);
        result.ProfileId = br.ReadUInt32Be();
        result.MoneyType = (short)br.ReadUInt16Be();
        return result;
    }
}