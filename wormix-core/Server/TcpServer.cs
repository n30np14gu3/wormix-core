using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using wormix_core.Session;

namespace wormix_core.Server;

public class TcpServer
{
    /// <summary>
    /// Server ID
    /// </summary>
    public readonly Guid Id;

    /// <summary>
    /// Server listen port
    /// </summary>
    public readonly int Port;
    
    /// <summary>
    /// Server listen endpoint
    /// </summary>
    public readonly EndPoint EndPoint;
    
    /// <summary>
    /// Server listen ip address
    /// </summary>
    public readonly string Address;

    /// <summary>
    /// Server sessions
    /// </summary>
    protected ConcurrentDictionary<Guid, TcpSession> Sessions = new();
    
    
    public bool IsRunning { get; private set; }
    
    /// <summary>
    /// Server TCP listener
    /// </summary>
    private readonly TcpListener _listener;
    
    #region cctors
    /// <summary>
    /// Initialize TCP server with a given IP address and port number
    /// </summary>
    /// <param name="address">IP address</param>
    /// <param name="port">Port number</param>
    public TcpServer(IPAddress address, int port) : this(new IPEndPoint(address, port)) {}
    
    /// <summary>
    /// Initialize TCP server with a given IP address and port number
    /// </summary>
    /// <param name="address">IP address</param>
    /// <param name="port">Port number</param>
    public TcpServer(string address, int port) : this(new IPEndPoint(IPAddress.Parse(address), port)) {}
    
    /// <summary>
    /// Initialize TCP server with a given DNS endpoint
    /// </summary>
    /// <param name="endpoint">DNS endpoint</param>
    public TcpServer(DnsEndPoint endpoint) : this(endpoint, endpoint.Host, endpoint.Port) {}
    
    /// <summary>
    /// Initialize TCP server with a given IP endpoint
    /// </summary>
    /// <param name="endpoint">IP endpoint</param>
    public TcpServer(IPEndPoint endpoint) : this(endpoint, endpoint.Address.ToString(), endpoint.Port) {}
    
    /// <summary>
    /// Initialize TCP server with a given endpoint, address and port
    /// </summary>
    /// <param name="endpoint">Endpoint</param>
    /// <param name="address">Server address</param>
    /// <param name="port">Server port</param>
    private TcpServer(EndPoint endpoint, string address, int port)
    {
        Port = port;
        EndPoint = endpoint;
        Address = address;
        Id = Guid.NewGuid();
        _listener = new TcpListener((IPEndPoint)endpoint);
    }
    #endregion

    public void Start()
    {
        _listener.Start();
        IsRunning = true;
        BeginListen();
    }
    
    public TcpSession? FindSession(Guid id)
    {
        return Sessions.TryGetValue(id, out TcpSession? session) ? session : null;
    }

    public void UnregisterSession(Guid id)
    {
        var session = FindSession(id);
        if(session == null)
            return;
        
        session.StopSession();
        Sessions.TryRemove(id, out TcpSession? _);
    }

    public void BroadcastMessage(byte[] message)
    {
        foreach (var client in Sessions)
            client.Value.SendMessage(message);
        
    }
    
    private async void BeginListen()
    {
        while (IsRunning)
        {
            TcpClient newClient = await _listener.AcceptTcpClientAsync();
            Guid sessionId = Guid.NewGuid();
            Sessions.TryAdd(sessionId, CreateSession());
            
            FindSession(sessionId)?.SetupSession(sessionId, newClient);
            FindSession(sessionId)?.StartSession();
        }
    }
    
    protected virtual TcpSession CreateSession()
    {
        return new TcpSession(this);
    }
}
