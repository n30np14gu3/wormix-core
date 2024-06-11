using System.Net;
using System.Net.Sockets;

namespace wormix_core.Server;

public abstract class ServerBehavior(IPAddress ip, int port)
{
    private TcpListener _listener = new TcpListener(ip, port);
    private List<Task> _clients = new();
    
    private bool _isRunning;
    
    public async void Start()
    {
        _listener.Start();
        _isRunning = true;
        while (_isRunning)
        {
            var client = await _listener.AcceptTcpClientAsync();
            OnConnect(client);
            _clients.Add(new Task(() =>
            {
                while (_isRunning) Process(client);
            }));
            _clients.Last().Start();
        }
    }

    public void Stop()
    {
        _isRunning = false;
        _listener.Stop();
    }

    protected abstract void OnConnect(TcpClient newClient);
    protected abstract void Process(TcpClient client);
}