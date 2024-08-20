using System.Net.Sockets;
using wormix_core.Extensions;
using wormix_core.Handlers;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Server;

namespace wormix_core.Session;

public class TcpSession
{
    /// <summary>
    /// Server base object
    /// </summary>
    public readonly TcpServer Server;
    
    /// <summary>
    /// Current TcpClient
    /// </summary>
    protected TcpClient? sessionClient { get; private set; }
    
    /// <summary>
    /// Map of commands handlers
    /// </summary>
    protected Dictionary<uint, GameMessageHandler> handlers { get; private set; }
    
    /// <summary>
    /// Session ID
    /// </summary>
    protected Guid Id;

    /// <summary>
    /// Main session thread
    /// </summary>
    private readonly Thread _sessionThread;


    /// <summary>
    /// Session auth token
    /// </summary>
    private string _token;

    public TcpSession(TcpServer server)
    {
        handlers = new();
        _token = string.Empty;
        Server = server;
        _sessionThread = new Thread(MessageLoop);
    }
    
    /// <summary>
    /// Setup client session
    /// </summary>
    /// <param name="id">Session ID</param>
    /// <param name="client">Session TcpCLient object</param>
    public void SetupSession(Guid id, TcpClient client)
    {
        Id = id;
        sessionClient = client;
    }

    /// <summary>
    /// Start session thread
    /// </summary>
    public void StartSession()
    {
        _sessionThread.Start();
    }

    /// <summary>
    /// Close TCP session
    /// </summary>
    public void CloseSession()
    {
        sessionClient?.Client.Close();
    }

    /// <summary>
    /// Stop tcp session & terminate thread
    /// </summary>
    public void StopSession()
    {
        sessionClient?.Close();
        if(_sessionThread.IsAlive) 
            _sessionThread.Interrupt();
        OnDisconnected();
    }

    /// <summary>
    /// Get game session token 
    /// </summary>
    /// <returns>Session key</returns>
    public string GetToken() => _token;
    
    /// <summary>
    /// Set game session token
    /// </summary>
    /// <param name="token">Session key</param>
    /// <returns></returns>

    public string SetToken(string token) => _token = token;
    
    /// <summary>
    /// Send message to server
    /// </summary>
    /// <param name="message"></param>
    public void SendMessage(byte[] message)
    {
        sessionClient?.Client.Send(message);
    }

    /// <summary>
    /// Get client network stream
    /// </summary>
    /// <returns>TcpClient NetworkStream object</returns>
    public NetworkStream GetStream() => sessionClient?.GetStream()!;

    /// <summary>
    /// On TcpClient connected handler
    /// </summary>
    protected virtual void OnConnected()
    {
        //Init game commands handlers
        if (handlers.Count == 0)
            handlers = GetHandlers();
    }

    /// <summary>
    /// TcpClient disconnected handler
    /// </summary>
    protected virtual void OnDisconnected()
    {
        
    }
    
    /// <summary>
    /// TcpClient on message handler
    /// </summary>
    /// <param name="dataStream">TcpClient NetworkStream object</param>
    protected virtual void OnMessage(Stream dataStream)
    {
        
    }

    /// <summary>
    /// Main data receive loop
    /// </summary>
    private void MessageLoop()
    {
        OnConnected();
        while (true)
        {
            if(sessionClient == null)
                break;
                
            try
            {
                // if (SessionClient.Client.Poll(0, SelectMode.SelectRead))
                //     continue;
                
                byte[] peakByte = new byte[1];
                if (sessionClient.Client.Receive(peakByte, SocketFlags.Peek) == 0)
                    break;
            }
            catch
            {
                break;
            }
                
            if(sessionClient.Available == 0)
                continue;
            
            OnMessage(sessionClient.GetStream());
        }
        Server.UnregisterSession(Id);
    }

    
    /// <summary>
    /// Get session GUID
    /// </summary>
    /// <returns>Session GUID</returns>
    public Guid GetSessionId() => Id;
    
    /// <summary>
    /// Return game message handlers map
    /// </summary>
    /// <returns></returns>
    protected virtual Dictionary<uint, GameMessageHandler> GetHandlers()
    {
        return new();
    }

    /// <summary>
    /// Process game message
    /// </summary>
    /// <param name="dataStream">TcpClient NetworkStream object</param>
    /// <param name="log">Log binary data</param>
    protected void ProcessMessage(Stream dataStream, bool log = true)
    {
        try
        {
            BinaryCommandHeader cmd = new BinaryCommandHeader();
            cmd.Read(dataStream);

            if (log)
            {
                ColorPrint.WriteLine($"[{this}] New data: {sessionClient?.Available}", ConsoleColor.Green);
                ColorPrint.WriteLine($"[{this}] CMD ID: {cmd.GetCommandId()}", ConsoleColor.Green);
                ColorPrint.WriteLine($"[{this}] Length: {cmd.GetLength()}", ConsoleColor.Green);
            }

            byte[] data = new byte[cmd.GetLength()];
            if (cmd.GetLength() != 0)
            {
                sessionClient?.Client.Receive(data);
                if(log)
                    ColorPrint.WriteLine($"[{this}] RAW:\n{HexDump.HexDump.Format(data)}", ConsoleColor.Yellow);
            }

            if (handlers.ContainsKey(cmd.GetCommandId()))
            {
                if(log)
                    ColorPrint.WriteLine($"[{this}] Processing via: {handlers[cmd.GetCommandId()]}", ConsoleColor.DarkGreen);
                handlers[cmd.GetCommandId()].Handle(data, cmd);
            }
            else
            {
                if(log)
                    ColorPrint.WriteLine($"[{this}] Unknown CMD ID", ConsoleColor.Red);
            }
                
        }
        catch (ArgumentException ex)
        {
            ColorPrint.WriteLine($"[{this}] Argument exception: {ex.Message}", ConsoleColor.Red);
        }
        catch (Exception ex)
        {
            ColorPrint.WriteLine($"[{this}] Unknown error: {ex.Message}", ConsoleColor.Red);
            ColorPrint.WriteLine($"[{this}] Closing client connection", ConsoleColor.Red);
            sessionClient?.Close();
        }
    }
}