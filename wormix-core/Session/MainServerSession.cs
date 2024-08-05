using wormix_core.Controllers;
using wormix_core.Controllers.Account;
using wormix_core.Controllers.Game;
using wormix_core.Controllers.Service;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Server;

namespace wormix_core.Session;

public class MainServerSession(TcpServer server) : TcpSession(server)
{    
    
    private readonly Dictionary<uint, GameControllerBehavior> _controllers = new()
    {
        {1, new LoginController()},
        {3, new ShopController()},
        {4, new ArenaController()},
        {6, new BattleController()},
        {16, new PingController()}
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