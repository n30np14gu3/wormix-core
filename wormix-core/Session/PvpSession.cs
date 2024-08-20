using wormix_core.Extensions;
using wormix_core.Handlers;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Server;

namespace wormix_core.Session;

public class PvpSession(TcpServer server) : TcpSession(server)
{
    private Dictionary<uint, GameMessageHandler> _handlers = new();
    
    protected override void OnConnected()
    {
        if (_handlers.Count == 0)
            _handlers = GetHandlers();
        
        Console.WriteLine($"[{Id}] {SessionClient} Connected");
    }

    protected override void OnDisconnected()
    {
        Console.WriteLine($"[{Id}] {SessionClient} Disconnected");
    }

    private Dictionary<uint, GameMessageHandler> GetHandlers()
    {
        return new();
    }

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