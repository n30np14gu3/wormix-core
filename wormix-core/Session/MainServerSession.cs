using wormix_core.Controllers.Http.Account;
using wormix_core.Controllers.Http.Game;
using wormix_core.Controllers.Http.Info;
using wormix_core.Controllers.Static.Account;
using wormix_core.Controllers.Static.Service;
using wormix_core.Handlers;
using wormix_core.Handlers.Account;
using wormix_core.Handlers.Game;
using wormix_core.Handlers.Info;
using wormix_core.Handlers.Service;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Server;

namespace wormix_core.Session;

public class MainServerSession(TcpServer server) : TcpSession(server)
{
    private bool _wipeRequested;
    
    public bool WipeRequested() => _wipeRequested;

    public bool SetWipeRequest() => _wipeRequested = true;
    
    protected override Dictionary<uint, GameMessageHandler> GetHandlers()
    {
        return new()
        {
            {1, new LoginHandler(new LoginBinarySerializer(), new LoginController(), this)},
            
            {2, new NeedMoneyHandler(new NeedMoneyBinarySerializer(), new NeedMoneyController(), this)},
            
            {3, new ShopHandler(new BuyShopItemsBinarySerializer(), new ShopController(), this)},
            
            {4, new ArenaHandler(new GetArenaBinarySerializer(), new ArenaController(), this)},
            {6, new StartBattleHandler(new StartBattleBinarySerializer(), new StartBattleController(), this)},
            
            {11, new BuyBattleHandler(new BuyBattleBinarySerializer(), new BuyBattleController(), this)},
            
            {12, new AddToGroupHandler(new AddToGroupBinarySerializer(), new AddToGroupController(), this)},
            {13, new RemoveFromGroupHandler(new RemoveFromGroupBinarySerializer(), new RemoveFromGroupController(), this)},
            
            {14, new DistributePointsHandler(new DistributePointsBinarySerializer(), new DistributePointsController(), this)},
            {15, new ResetParametersHandler(new ResetParametersBinarySerializer(), new ResetParametersController(), this)},
            
            {16, new PingHandler(new PingBinarySerializer(), new PingController(), this)},
            
            {22, new ReorderGroupHandler(new ReorderGroupBinarySerializer(), new ReorderGroupController(), this)},
            
            {25, new SelectStuffHandler(new SelectStuffBinarySerializer(), new SelectStuffController(), this)},
            
            {36, new ChangeRaceHandler(new ChangeRaceSerializer(), new ChangeRaceController(), this)},
            
            {46, new GetWhoPumpedReactionHandler(new GetWhoPumpedReactionBinarySerializer(), new GetWhoPumpedReactionController(), this)},
            
            {48, new WipeHandler(new WipeProfileBinarySerializer(), new WipeProfileController(), this)},
            
            {49, new BuyReactionRateHandler(new BuyReactionRateBinarySerializer(), new BuyReactionRateController(), this)},
            
            
            {52, new WipeHandler(new SendWipeConfirmCodeBinarySerializer(), new SendWipeConfirmCodeController(), this)},
            
            {58, new BuyUnlockMissionHandler(new BuyUnlockMissionBinarySerializer(), new BuyUnlockMissionController(), this)},
            
            {81, new SearchTheHouseHandler(new SearchTheHouseBinarySerializer(), new SearchTheHouseController(), this)},
            {82, new PumpReactionRatesHandler(new PumpReactionRatesBinarySerializer(), new PumpReactionRatesController(), this)},
            {83, new PumpReactionRateHandler(new PumpReactionRateBinarySerializer(), new PumpReactionRateController(), this)},
            
            {84, new EndBattleHandler(new EndBattleBinarySerializer(), new EndBattleController(), this)},
            
            {86, new UpgradeWeaponHandler(new UpgradeWeaponBinarySerializer(), new UpgradeWeaponController(), this)},
            {88, new DowngradeWeaponHandler(new DowngradeWeaponBinarySerializer(), new DowngradeWeaponController(), this)}
        };
    }
    
    protected override void OnMessage(Stream dataStream)
    {
        ProcessMessage(dataStream);
    }
}