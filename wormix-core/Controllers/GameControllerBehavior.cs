﻿using System.Net.Sockets;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers;

public abstract class GameControllerBehavior()
{
    protected byte[]? DataPayload;
    protected TcpSession? Client;
    protected ICommandHeader? Header;
    
    public void Handle(byte[] payload, TcpSession client, ICommandHeader header)
    {
        DataPayload = payload;
        Client = client;
        Header = header;
        Process();
    }

    protected abstract void Process();
    
}