using wormix_core.Extensions;
using wormix_core.Handlers;
using wormix_core.Handlers.Account;
using wormix_core.Handlers.Game;
using wormix_core.Handlers.Service;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Server;

namespace wormix_core.Session;

public class MainServerSession(TcpServer server) : TcpSession(server)
{    
    
    private readonly Dictionary<uint, GameMessageHandler> _handlers = new()
    {
        {1, new LoginHandler()},
        {3, new ShopHandler()},
        {4, new ArenaHandler()},
        {6, new BattleHandler()},
        {15, new ResetParametersHandler()},
        {16, new PingHandler()},
        {25, new SelectStuffHandler()},
        {36, new ChangeRaceHandler()},
        {84, new EndBattleHandler()}
    };
    
    protected override void OnMessage(Stream dataStream)
    {
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
                _handlers[cmd.GetCommandId()].Handle(data, this, cmd);
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