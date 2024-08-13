using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Account;

public class ShopHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session): 
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is BuyShopItems shopItems)
        {
            if (shopItems.ShopItems.Count != 0)
            {
                ShopResult result = (ShopResult)MessageController.ProcessMessage(shopItems, Client);
                ShopResultBinarySerializer serializer = new ShopResultBinarySerializer();
                serializer.SerializeCommand(result, Client.GetStream());

                Console.WriteLine($"Add new {result.Weapons.Count} items");
            }
        }
    }
}