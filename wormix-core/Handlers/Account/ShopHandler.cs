using wormix_core.Controllers.Account;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Account;

public class ShopHandler : GameMessageHandler
{
    protected override void Process()
    {
        if(Header == null || DataPayload == null)
            return;
        
        BuyShopItems items;
        
        using (MemoryStream ms = new MemoryStream(DataPayload))
        {
            BuyShopItemsBinarySerializer shopItems = new BuyShopItemsBinarySerializer();
            items = (BuyShopItems)shopItems.DeserializeCommand(ms, Header);
        }

        if (items.ShopItems.Count != 0)
        {
            ShopResult result = (ShopResult)new ShopController().ProcessMessage(items, Client);
            ShopResultBinarySerializer serializer = new ShopResultBinarySerializer();
            serializer.SerializeCommand(result, Client?.GetStream()!);

            Console.WriteLine($"Add new {result.Weapons.Count} items");
        }
    }
}