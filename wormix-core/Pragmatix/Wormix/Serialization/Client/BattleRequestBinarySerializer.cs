using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.PvP.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BattleRequestBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 1002;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BattleRequest result = new();

        BinaryReader br = new BinaryReader(input);
        result.Host = br.ReadUTF8();
        result.Port = (int)br.ReadUInt32Be();
        result.MapId = br.ReadUInt32Be();
        result.Seed = (int)br.ReadUInt32Be();
        result.EnemyId = br.ReadUTF8();
        
        return result;
    }
}