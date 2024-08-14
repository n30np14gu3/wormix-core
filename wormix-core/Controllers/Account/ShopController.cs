using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

public class ShopController : IGameController
{
    public ISerializable ProcessMessage(ISerializable gameMessage, TcpSession? session)
    {
        JObject result = HttpProcessor.PostRequest($"{Config.Url}{GetRoute()}", gameMessage, session).ToObject<JObject>()!;
        return result["data"]!.ToObject<ShopResult>();
    }

    public string GetRoute()
    {
        return "account/buy/items";
    }
}