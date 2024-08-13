using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct BuyShopItems() : ISerializable
{
    public List<ShopItemStructure> ShopItems = new();
    
    public uint GetSize()
    {
        return (uint)(
            2 + //ShopItemsSize
            2 + ShopItems.Sum((x) => x.GetSize() + 2) //ShopItems[]
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)ShopItems.Count);
        ShopItems.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
    }
}