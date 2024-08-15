﻿using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Account;

public class ChangeRaceHandler(ICommandSerializer requestSerializer, GameController controller, TcpSession session) : 
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is ChangeRace changeRace)
        {
            ISerializable result = MessageController.ProcessMessage(changeRace, Client);
            ChangeRaceResultBinarySerializer resultSerializer = new ChangeRaceResultBinarySerializer();
            resultSerializer.SerializeCommand(result, Client.GetStream());
        }
    }
}