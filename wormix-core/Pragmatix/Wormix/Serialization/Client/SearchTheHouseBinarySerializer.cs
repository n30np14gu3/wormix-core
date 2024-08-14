using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SearchTheHouseBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 81;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        SearchTheHouse result = new();
        BinaryReader br = new BinaryReader(input);

        result.SessionKey = br.ReadUTF8();
        result.FriendId = br.ReadUInt32Be();
        result.KeyNum = br.ReadByte();
        
        return result;
    }
}