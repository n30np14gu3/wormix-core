﻿using wormix_core.Controllers;
using wormix_core.Controllers.Account;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Account;

[ControlledBy(typeof(LoginController))]
public class ChangeRaceHandler : GameMessageHandler
{
    protected override void Process()
    {
        if (DataPayload == null || Header == null)
            return;

        ChangeRaceSerializer serializer = new ChangeRaceSerializer();
        object cmdData;
        using (MemoryStream ms = new MemoryStream(DataPayload))
        {
            cmdData = (ChangeRace)serializer.DeserializeCommand(ms, Header);
        }

        if (cmdData is ChangeRace changeRace)
        {
            IMessage result = MessageController!.ProcessMessage(changeRace, Client);
            ChangeRaceResultBinarySerializer resultSerializer = new ChangeRaceResultBinarySerializer();
            resultSerializer.SerializeCommand(result, Client?.GetStream()!);
        }
    }
}