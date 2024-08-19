using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuyShopItemsBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 3;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BuyShopItems shopItems = new BuyShopItems();
        BinaryReader br = new BinaryReader(input);
        ushort count = br.ReadUInt16Be();
        for (ushort i = 0; i < count; i++)
        {
            //Skip size
            br.ReadUInt16Be();
                
            shopItems.ShopItems.Add(
                new()
                {
                    Id = br.ReadUInt32Be(),
                    Count = (int)br.ReadUInt32Be(),
                    MoneyType = (int)br.ReadUInt32Be()
                }
            );
        }
        return shopItems;
    }
}