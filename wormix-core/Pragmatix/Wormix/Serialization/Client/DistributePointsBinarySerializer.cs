using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class DistributePointsBinarySerializer :  ICommandSerializer
{
    public uint GetCommandId()
    {
        return 14;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        DistributePoints result = new();
        
        BinaryReader br = new BinaryReader(input);
        result.Armor = (int)br.ReadUInt32Be();
        result.Attack = (int)br.ReadUInt32Be();

        return result;
    }
}