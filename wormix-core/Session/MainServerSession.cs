using wormix_core.Controllers.Http.Account;
using wormix_core.Controllers.Http.Game;
using wormix_core.Controllers.Http.Info;
using wormix_core.Controllers.Http.Service;
using wormix_core.Extensions;
using wormix_core.Handlers;
using wormix_core.Handlers.Account;
using wormix_core.Handlers.Game;
using wormix_core.Handlers.Info;
using wormix_core.Handlers.Service;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Server;

namespace wormix_core.Session;

public class MainServerSession(TcpServer server) : TcpSession(server)
{
    private Dictionary<uint, GameMessageHandler> _handlers = new();
    
    private Dictionary<uint, GameMessageHandler> GetHandlers()
    {
        return new()
        {
            {1, new LoginHandler(new LoginBinarySerializer(), new LoginController(), this)},
            
            {3, new ShopHandler(new BuyShopItemsBinarySerializer(), new ShopController(), this)},
            
            {4, new ArenaHandler(new GetArenaBinarySerializer(), new ArenaController(), this)},
            {6, new StartBattleHandler(new StartBattleBinarySerializer(), new StartBattleController(), this)},
            
            {15, new ResetParametersHandler(new ResetParametersBinarySerializer(), new ResetParametersController(), this)},
            
            {16, new PingHandler(new PingBinarySerializer(), new PingController(), this)},
            
            {25, new SelectStuffHandler(new SelectStuffBinarySerializer(), new SelectStuffController(), this)},
            
            {36, new ChangeRaceHandler(new ChangeRaceSerializer(), new ChangeRaceController(), this)},
            
            {46, new GetWhoPumpedReactionHandler(new GetWhoPumpedReactionBinarySerializer(), new GetWhoPumpedReactionController(), this)},
            
            {81, new SearchTheHouseHandler(new SearchTheHouseBinarySerializer(), new SearchTheHouseController(), this)},
            {82, new PumpReactionRatesHandler(new PumpReactionRatesBinarySerializer(), new PumpReactionRatesController(), this)},
            {83, new PumpReactionRateHandler(new PumpReactionRateBinarySerializer(), new PumpReactionRateController(), this)},
            
            {84, new EndBattleHandler(new EndBattleBinarySerializer(), new EndBattleController(), this)}
        };
    }
    protected override void OnMessage(Stream dataStream)
    {
        if (_handlers.Count == 0)
            _handlers = GetHandlers();
        
        try
        {
            BinaryCommandHeader cmd = new BinaryCommandHeader();
            cmd.Read(dataStream);

            ColorPrint.WriteLine($"New data: {SessionClient?.Available}", ConsoleColor.Green);
            ColorPrint.WriteLine($"CMD ID: {cmd.GetCommandId()}", ConsoleColor.Green);
            ColorPrint.WriteLine($"Length: {cmd.GetLength()}", ConsoleColor.Green);

            byte[] data = new byte[cmd.GetLength()];
            if (cmd.GetLength() != 0)
            {
                SessionClient?.Client.Receive(data);
                ColorPrint.WriteLine($"RAW:\n{HexDump.HexDump.Format(data)}", ConsoleColor.Yellow);
            }

            if (_handlers.ContainsKey(cmd.GetCommandId()))
            {
                ColorPrint.WriteLine($"Processing via: {_handlers[cmd.GetCommandId()]}", ConsoleColor.DarkGreen);
                _handlers[cmd.GetCommandId()].Handle(data, cmd);
            }
            else
                ColorPrint.WriteLine("Unknown CMD ID", ConsoleColor.Red);
                
        }
        catch (ArgumentException ex)
        {
            ColorPrint.WriteLine($"Argument exception: {ex.Message}", ConsoleColor.Red);
        }
        catch (Exception ex)
        {
            ColorPrint.WriteLine($"Unknown error: {ex.Message}", ConsoleColor.Red);
            ColorPrint.WriteLine("Closing client connection", ConsoleColor.Red);
            SessionClient?.Close();
        }
    }
}