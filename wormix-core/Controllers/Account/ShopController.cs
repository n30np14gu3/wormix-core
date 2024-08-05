using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Messages.Structures;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Controllers.Account;

public class ShopController : GameControllerBehavior
{
    protected override void Process()
    {
        if(Header == null || DataPayload == null)
            return;
        
        BuyShopItems items = new();
        
        using (MemoryStream ms = new MemoryStream(DataPayload))
        {
            BuyShopItemsBinarySerializer shopItems = new BuyShopItemsBinarySerializer();
            items = (BuyShopItems)shopItems.DeserializeCommand(ms, Header);
            Console.WriteLine($"Buy items request [{items.ShopItems.Count}]");
            foreach (var i in items.ShopItems)
            {
                Console.WriteLine($"ID: {i.Id}");
                Console.WriteLine($"Count: {i.Count}");
                Console.WriteLine($"MoneyType: {i.MoneyType}\n");
            }
        }

        if (items.ShopItems.Count != 0)
        {
            //TODO: store to DB
            ShopResult result = new();
            items.ShopItems.ForEach((x) => result.Weapons.Add(new WeaponStructure()
            {
                Id = x.Id,
                Count = x.Count
            }));
            result.Result = ShopResult.Success;

            byte[] response = new byte[BinaryCommandHeader.HeaderSize + result.GetSize() + 16 /*MD5 Sum*/];
            using (MemoryStream ms = new MemoryStream(response))
            {
                ShopResultBinarySerializer serializer = new ShopResultBinarySerializer();
                serializer.SerializeCommand(result, ms);
            }

            Console.WriteLine($"Add new {result.Weapons.Count} items");
            Client?.SessionClient?.Client.Send(response);
        }
    }
}