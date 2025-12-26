using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.PvP.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BattleLoginBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 1001;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BattleLogin result = new();
        
        BinaryReader br = new BinaryReader(input);
        result.Id = br.ReadUInt32Be();
        result.FirstTurn = br.ReadBoolean();
        result.AuthKey = br.ReadUTF8();

        ushort enemiesCount = br.ReadUInt16Be();
        for(ushort i = 0; i < enemiesCount; i++)
            result.EnemyIds.Add(br.ReadUInt32Be());

        result.MainHost = br.ReadUTF8();
        result.MainPort = (int)br.ReadUInt32Be();
        result.BattleId = br.ReadUInt32Be();
        result.SocialId = br.ReadByte();
        
        return result;
    }
}