﻿using wormix_core.Controllers.Http.Attributes;

using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Account;


[ApiPost("account/buy/race")]
public class ChangeRaceController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        JObject result = PostRequest(gameSerializable, session).ToObject<JObject>()!;
        return result["data"]!.ToObject<ChangeRaceResult>();
    }
}