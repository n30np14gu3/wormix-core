using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class ReorderGroupBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 22;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        ReorderGroup result = new();
        BinaryReader br = new BinaryReader(input);
        short wormsCount = (short)br.ReadUInt16Be();
        for(short i = 0; i < wormsCount; i++)
            result.ReorderedWormGroup.Add(br.ReadUInt32Be());
        return result;
    }
}