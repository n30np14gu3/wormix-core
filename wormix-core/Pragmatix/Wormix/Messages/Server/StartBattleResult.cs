using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct StartBattleResult() : IMessage, ISerializable
{
    public List<WeaponStructure> Awards = new();
    public uint BattleId;
    public List<byte> ReagentForBattle = new();
    public uint GetSize()
    {
        return
            (uint)(
                2 + Awards.Sum((x) => x.GetSize() + 2) //Awards[]
                + 4 //BattleId
                + 2 + ReagentForBattle.Count //ReagentForBattle
            );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Awards.Count);
        
        Awards.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
        
        bw.WriteUInt32Be(BattleId);
        
        bw.WriteUInt16Be((ushort)ReagentForBattle.Count);
        ReagentForBattle.ForEach((x) => bw.Write(x));
    }
}