using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ShopResult() : IMessage, ISerializable
{
    public const int Success = 0;
    public const int Error = 1;
    public const int MinRequirementsError = 2;
    public const int NotEnoughMoney = 3;
    public const int ConfirmFailure = 4;

    public int Result = 4;
    public List<WeaponStructure> Weapons = new();
    public List<short> Stuff = new();
    
    
    public uint GetSize()
    {
        return
            (uint)(
                2 //Result
                + 2 + Weapons.Sum((x) => x.GetSize() + 2) //Weapons[]
                + 2 + Weapons.Sum((x) => x.GetSize() + 2) //Stuff[]
                );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        
        bw.WriteUInt16Be((ushort)Result);
        
        bw.WriteUInt16Be((ushort)Weapons.Count);
        Weapons.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
        
        bw.WriteUInt16Be((ushort)Stuff.Count);
        Stuff.ForEach((x) =>  bw.WriteUInt16Be((ushort)x));
    }
}