﻿using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Account;

public class DowngradeWeaponHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session): 
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is DowngradeWeapon)
        {
            new DowngradeWeaponResultBinarySerializer()
                .SerializeCommand(MessageController.ProcessMessage(requestMessage, Client), Client.GetStream());
        }
    }
}