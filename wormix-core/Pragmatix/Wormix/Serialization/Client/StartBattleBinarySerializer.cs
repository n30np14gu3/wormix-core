using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class StartBattleBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 6;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        StartBattle battle = new StartBattle();
        BinaryReader br = new BinaryReader(input);
        battle.MissionId = (short)br.ReadUInt16Be();
        return battle;
    }
}