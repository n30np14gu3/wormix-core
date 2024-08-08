using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Account;

public class LoginController : IGameController
{
    public IMessage ProcessMessage(IMessage gameMessage, TcpSession? session)
    {
        JObject result = HttpProcessor.PostRequest($"{Config.Url}{GetRoute()}", gameMessage).ToObject<JObject>()!;
        switch (result["type"]!.ToString())
        {
            case "EnterAccount":
                if(result["old_session"]?.ToString() != null)
                    session!.Server.FindSession(Guid.Parse(result["old_session"]!.ToString()))?.StopSession();
                return result["data"]!.ToObject<EnterAccount>();
            case "LoginError":
                return result["data"]!.ToObject<LoginError>();
                
        }
        return new LoginError()
        {
            Result = LoginError.InternalServerError
        };
        // EnterAccount result = new EnterAccount
        // {
        //     UserProfileStructure = new UserProfileStructure
        //     {
        //         Id = 1,
        //         Money = 450,
        //         Rating = 0,
        //         ReactionRate = 0,
        //         RealMoney = 3,
        //         SocialId = "1",
        //         WormsGroup = new List<WormStructure>
        //         {
        //             new WormStructure
        //             {
        //                 OwnerId = 1,
        //                 SocialOwnerId = "1",
        //                 Armor = 1,
        //                 Attack = 1,
        //                 Experience = 0,
        //                 Level = 2,
        //                 Hat = 0,
        //             }
        //         },
        //         WeaponRecordList = new()
        //         {
        //             new() { Id = 1, Count = -1 },
        //             new() { Id = 2, Count = -1 },
        //             new() { Id = 4, Count = -1 },
        //         },
        //         Stuff = new()
        //     },
        //     AvailableSearchKeys = 0,
        //     Friends = 0,
        //     OnlineFriends = 0,
        //     IsBonusDay = false,
        //     DailyBonusStructure = new DailyBonusStructure
        //     {
        //         DailyBonusType = 0,
        //         DailyBonusCount = 0,
        //         LoginSequence = 0
        //     },
        //     SessionKey = "session_key",
        // };
        //
        // return result;
    }
    
    public string GetRoute()
    {
        return "login";
    }
}