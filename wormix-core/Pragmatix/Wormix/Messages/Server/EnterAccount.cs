using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct EnterAccount() : ISerializable
{
    public UserProfileStructure UserProfileStructure = new();
    public List<UserProfileStructure> UserProfileStructures = new();
    public DailyBonusStructure DailyBonusStructure = new();
    public int OnlineFriends;
    public int Friends;
    public string SessionKey = "";
    public bool IsBonusDay;
    public BonusDaysStructure BonusDaysStructure = new();
    public int AvailableSearchKeys = new();
    public List<uint> Reagents = new();
    public bool IsSecure = new();
    public uint GetSize()
    {
        return
            (uint)(
                2 + UserProfileStructure.GetSize() //UserProfileStructure
                   + 2 + UserProfileStructures.Sum((x) => x.GetSize() + 2) // UserProfileStructure[]
                   + 2 + DailyBonusStructure.GetSize() // DailyBonusStructure
                   + 2 // OnlineFriends
                   + 2 // Friends
                   + 2 + SessionKey.Length // SessionKey
                   + 1 // IsBonusDay
                   + (IsBonusDay ? + 2 + BonusDaysStructure.GetSize() : 0) //BonusDaysStructure
                   + 1 // AvailableSearchKeys
                   + 2 + 4 * Reagents.Count //Reagents[]
                )
            ;
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        
        bw.WriteUInt16Be((ushort)UserProfileStructure.GetSize());
        UserProfileStructure.Serialize(output);
        
        bw.WriteUInt16Be((ushort)UserProfileStructures.Count);
        UserProfileStructures.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
        
        bw.WriteUInt16Be((ushort)DailyBonusStructure.GetSize());
        DailyBonusStructure.Serialize(output);
        
        bw.WriteUInt16Be((ushort)OnlineFriends);
        bw.WriteUInt16Be((ushort)Friends);
        
        bw.WriteUTF8(SessionKey);
        
        bw.Write(IsBonusDay);

        if (IsBonusDay)
        {
            bw.WriteUInt16Be((ushort)BonusDaysStructure.GetSize());
            BonusDaysStructure.Serialize(output);
        }
        
        bw.Write((byte)AvailableSearchKeys);
        
        bw.WriteUInt16Be((ushort)Reagents.Count);
        Reagents.ForEach((x) => bw.WriteUInt32Be(x));
    }
}