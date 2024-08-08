using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ArenaResult() : IMessage
{
    public List<UserProfileStructure> UserProfileStructures = new();
    public int BattlesCount;
    public int CurrentMission;
    public bool BossAvailable;
    
    public uint GetSize()
    {
        return
            (uint)(
                2 + UserProfileStructures.Sum((x) => x.GetSize() + 2) //UserProfileStructures[]
                + 4 //BattlesCount
                + 2 //CurrentMission
                + 1 //BossAvailable
            );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)UserProfileStructures.Count);
        
        UserProfileStructures.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
        
        bw.WriteUInt32Be((uint)BattlesCount);
        bw.WriteUInt16Be((ushort)CurrentMission);
        bw.Write(BossAvailable);
    }
}