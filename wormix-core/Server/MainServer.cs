using System.Net;
using System.Net.Sockets;
using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Internals;

namespace wormix_core.Server;

public class MainServer(IPAddress ip, int port) : ServerBehavior(ip, port)
{
    private readonly Dictionary<uint, GameControllerBehavior> _controllers = new()
    {
        
    };
    protected override void OnConnect(TcpClient newClient)
    {
        Console.WriteLine("New client connected");
    }

    protected override void Process(TcpClient client)
    {
        if(client.Available == 0)
            return;

        try
        {
            Console.WriteLine($"New data: {client.Available}");
            BinaryCommandHeader cmd = new BinaryCommandHeader();
            cmd.Read(client.GetStream());

            Console.WriteLine($"CMD ID: {cmd.GetCommandId()}");
            Console.WriteLine($"Length: {cmd.GetLength()}");

            byte[] data = new byte[cmd.GetLength()];
            if (cmd.GetLength() != 0)
            {
                client.Client.Receive(data);
                Console.WriteLine($"RAW:\n{HexDump.HexDump.Format(data)}");
            }

            if (_controllers.ContainsKey(cmd.GetCommandId()))
            {
                Console.WriteLine($"Processing via {_controllers[cmd.GetCommandId()].GetControllerName()}");
                _controllers[cmd.GetCommandId()].Handle(data, client);
            }
                
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid command header");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unknown error: {ex.Message}");
        }
    }
}