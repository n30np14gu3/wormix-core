using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuyShopItemsBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 3;
    }

    public void SerializeCommand(object command, Stream output)
    {
        //Not needed
        throw new NotImplementedException();
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        byte[] buyPayload = new byte[header.GetLength()];
        var readed = input.Read(buyPayload);
        if (readed < header.GetLength())
            throw new ArgumentException($"Invalid recv length {readed}<{header.GetLength()}");

        BuyShopItems shopItems = new BuyShopItems();
        using (MemoryStream ms = new MemoryStream(buyPayload))
        {
            BinaryReader br = new BinaryReader(ms);
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
        }

        return shopItems;
    }
}