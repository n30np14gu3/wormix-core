using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class StartBattleBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 6;
    }

    public void SerializeCommand(object command, Stream output)
    {
        //Not needed
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        StartBattle battle = new StartBattle();
        BinaryReader br = new BinaryReader(input);
        battle.MissionId = br.ReadUInt16Be();
        return battle;
    }
}