using System.Net;
using System.Net.Sockets;
using wormix_core.Server.Processors;

namespace wormix_core.Server;

public abstract class ServerBehavior(IPAddress ip, int port)
{
    private TcpListener _listener = new TcpListener(ip, port);
    private bool _isRunning;
    
    public async void Start()
    {
        _listener.Start();
        _isRunning = true;
        while (_isRunning)
        {
            var client = await _listener.AcceptTcpClientAsync();
            Thread task = new Thread(() =>
            {
                OnConnect(client);
                Process(client);
                OnClose(client);
            });
            task.Start();

        }
    }

    public void Stop()
    {
        _isRunning = false;
        _listener.Stop();
    }

    protected abstract void OnConnect(TcpClient client);
    protected abstract void Process(TcpClient client);
    protected abstract void OnClose(TcpClient client);
}