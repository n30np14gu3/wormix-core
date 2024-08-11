using System.Net.Sockets;
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
    protected TcpClient? SessionClient { get; private set; }
    
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
        _token = string.Empty;
        Server = server;
        _sessionThread = new Thread(MessageLoop);
    }
    
    public void SetupSession(Guid id, TcpClient client)
    {
        Id = id;
        SessionClient = client;
    }

    public void StartSession()
    {
        _sessionThread.Start();
    }

    public void CloseSession()
    {
        SessionClient?.Client.Close();
    }

    public void StopSession()
    {
        SessionClient?.Close();
        if(_sessionThread.IsAlive) 
            _sessionThread.Interrupt();
        OnDisconnected();
    }

    public string GetToken() => _token;

    public string SetToken(string token) => _token = token;
    

    public void SendMessage(byte[] message)
    {
        SessionClient?.Client.Send(message);
    }

    public NetworkStream GetStream() => SessionClient?.GetStream()!;

    protected virtual void OnConnected()
    {
        
    }

    protected virtual void OnDisconnected()
    {
        
    }

    protected virtual void OnMessage(Stream dataStream)
    {
        
    }

    private void MessageLoop()
    {
        OnConnected();
        while (true)
        {
            if(SessionClient == null)
                break;
                
            try
            {
                // if (SessionClient.Client.Poll(0, SelectMode.SelectRead))
                //     continue;
                
                byte[] peakByte = new byte[1];
                if (SessionClient.Client.Receive(peakByte, SocketFlags.Peek) == 0)
                    break;
            }
            catch
            {
                break;
            }
                
            if(SessionClient.Available == 0)
                continue;
            
            OnMessage(SessionClient.GetStream());
        }
        Server.UnregisterSession(Id);
    }

    public Guid GetSessionId() => Id;
}