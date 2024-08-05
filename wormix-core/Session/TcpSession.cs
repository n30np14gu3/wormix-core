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
    public TcpClient? SessionClient { get; protected set; }
    
    /// <summary>
    /// Session ID
    /// </summary>
    protected Guid Id;

    /// <summary>
    /// Main session thread
    /// </summary>
    private readonly Thread _sessionThread;

    public TcpSession(TcpServer server)
    {
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

    public void StopSession()
    {
        SessionClient?.Close();
        if(_sessionThread.IsAlive) 
            _sessionThread.Interrupt();
        OnDisconnected();
    }

    public void SendMessage(byte[] message)
    {
        SessionClient?.Client.Send(message);
    }

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
}