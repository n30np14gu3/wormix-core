﻿using wormix_core.Controllers.Account;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Account;

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
            IMessage result = new ChangeRaceController().ProcessMessage(changeRace, Client);
            byte[] resultBuffer = new byte[result.GetSize() + BinaryCommandHeader.HeaderSize];
            ChangeRaceResultBinarySerializer resultSerializer = new ChangeRaceResultBinarySerializer();
            using (MemoryStream ms = new MemoryStream(resultBuffer))
                resultSerializer.SerializeCommand(result, ms);
            
            Client?.SessionClient?.Client.Send(resultBuffer);
        }
    }
}