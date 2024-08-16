using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct UserProfileStructure() : ISerializable
{
    public uint Id;
    public string SocialId;
    
    public uint Money;
    public uint RealMoney;
    
    public int Rating;

    public List<WormStructure> WormsGroup = new();
    public List<WeaponStructure> WeaponRecordList = new();
    
    public List<ushort> Stuff = new();
    
    public int ReactionRate = new();
    
    public List<ushort> Recipes = new();
    public uint GetSize()
    {
        return (uint)(
            4 //Id
            
            + 4 //Money
            + 4 //RealMoney
            
            + 4 // Rating
            
            + 2 //WormGroupLength
            + WormsGroup.Sum(x => x.GetSize()) //WormStructure[]
            
            + 2 //WeaponRecordListLength
            + WeaponRecordList.Sum(x => x.GetSize()) //WeaponStructure[]
            
            + 2 //StuffLength
            + 2 * Stuff.Count //Stuff[]
            
            + 4 //ReactionRate
            
            + 2 + SocialId.Length
            
            + 2 //RecipesLength
            + 2 * Recipes.Count //Recipes[]
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        
        bw.WriteUInt32Be(Id);
        bw.WriteUInt32Be(Money);
        bw.WriteUInt32Be(RealMoney);
        bw.WriteUInt32Be((uint)Rating);
        
        bw.WriteUInt16Be((ushort)WormsGroup.Count);
        WormsGroup.ForEach((x) => x.Serialize(output));
        
        bw.WriteUInt16Be((ushort)WeaponRecordList.Count);
        WeaponRecordList.ForEach((x) => x.Serialize(output));
        
        bw.WriteUInt16Be((ushort)Stuff.Count);
        Stuff.ForEach((x) => bw.WriteUInt16Be(x));
        
        bw.WriteUInt32Be((uint)ReactionRate);
        bw.WriteUTF8(SocialId);
        
        bw.WriteUInt16Be((ushort)Recipes.Count);
        Recipes.ForEach((x) => bw.WriteUInt16Be(x));
    }
}