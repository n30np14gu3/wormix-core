﻿using wormix_core.Controllers.Attributes;
using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

[ApiPost("login")]
public class LoginController : GameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        JObject result = HttpProcessor.PostRequest(Url, gameSerializable, session).ToObject<JObject>()!;
        switch (result["type"]!.ToString())
        {
            case "EnterAccount":
                if (!string.IsNullOrWhiteSpace(result["old_session"]?.ToString()))
                {
                    var oldSession = session!.Server.FindSession(Guid.Parse(result["old_session"]!.ToString()));
                    oldSession?.StopSession();
                }
                return result["data"]!.ToObject<EnterAccount>();
            case "LoginError":
                return result["data"]!.ToObject<LoginError>();
                
        }
        
        return new LoginError
        {
            Result = LoginError.InternalServerError
        };
    }
}