﻿using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Account;

public class ChangeRaceHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session) : 
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is ChangeRace changeRace)
        {
            IMessage result = MessageController.ProcessMessage(changeRace, Client);
            ChangeRaceResultBinarySerializer resultSerializer = new ChangeRaceResultBinarySerializer();
            resultSerializer.SerializeCommand(result, Client.GetStream());
        }
    }
}