using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class ChangeRaceSerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 36;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        ChangeRace result = new();
        
        BinaryReader br = new BinaryReader(input);
        result.RaceId = br.ReadByte();
        result.MoneyType = br.ReadByte();
        
        return result;
    }
}