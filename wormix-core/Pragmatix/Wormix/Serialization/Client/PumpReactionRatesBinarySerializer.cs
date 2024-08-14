using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class PumpReactionRatesBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 82;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        PumpReactionRates result = new()
        {
            FriendsIds = new()
        };
        
        BinaryReader br = new BinaryReader(input);
        ushort friendsCount = br.ReadUInt16Be();
        for(int i = 0 ; i < friendsCount; i++)
            result.FriendsIds.Add(br.ReadUInt32Be());

        br.ReadBytes(16); //MD5 checksum
        
        return result;
    }
}