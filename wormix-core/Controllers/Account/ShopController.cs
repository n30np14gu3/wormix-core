using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

public class ShopController : IGameController
{
    public IMessage ProcessMessage(IMessage gameMessage, TcpSession? session)
    {
        JObject result = HttpProcessor.PostRequest($"{Config.Url}{GetRoute()}", gameMessage).ToObject<JObject>()!;
        return result["data"]!.ToObject<ShopResult>();
        
        // BuyShopItems items = (BuyShopItems)gameMessage;
        // ShopResult result = new();
        // items.ShopItems.ForEach((x) => result.Weapons.Add(new WeaponStructure()
        // {
        //     Id = x.Id,
        //     Count = x.Count
        // }));
        // result.Result = ShopResult.Success;
        //
        // return result;
    }

    public string GetRoute()
    {
        return "account/buy_items";
    }
}