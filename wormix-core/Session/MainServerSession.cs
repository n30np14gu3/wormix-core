using wormix_core.Handlers;
using wormix_core.Handlers.Account;
using wormix_core.Handlers.Game;
using wormix_core.Handlers.Service;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Server;

namespace wormix_core.Session;

public class MainServerSession(TcpServer server) : TcpSession(server)
{    
    
    private readonly Dictionary<uint, GameMessageHandler> _controllers = new()
    {
        {1, new LoginHandler()},
        {3, new ShopHandler()},
        {4, new ArenaHandler()},
        {6, new BattleHandler()},
        {16, new PingHandler()},
        {36, new ChangeRaceHandler()}
    };
    
    protected override void OnMessage(Stream dataStream)
    {
        try
        {
            Console.WriteLine($"New data: {SessionClient?.Available}");
            BinaryCommandHeader cmd = new BinaryCommandHeader();
            cmd.Read(dataStream);

            Console.WriteLine($"CMD ID: {cmd.GetCommandId()}");
            Console.WriteLine($"Length: {cmd.GetLength()}");

            byte[] data = new byte[cmd.GetLength()];
            if (cmd.GetLength() != 0)
            {
                SessionClient?.Client.Receive(data);
                Console.WriteLine($"RAW:\n{HexDump.HexDump.Format(data)}");
            }
            
            if (_controllers.ContainsKey(cmd.GetCommandId()))
                _controllers[cmd.GetCommandId()].Handle(data, this, cmd);
            else
                Console.WriteLine("Unknown CMD ID");
                
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Argument exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unknown error: {ex.Message}");
            Console.WriteLine("Closing client connection");
            SessionClient?.Close();
        }
    }
}