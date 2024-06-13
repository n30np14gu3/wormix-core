﻿using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Messages.Structures;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Controllers.Account;

public class LoginController : GameControllerBehavior
{
    protected override void Process()
    {
        if (DataPayload == null || Header == null)
            return;
        
        LoginBinarySerializer serializer = new LoginBinarySerializer();
        Login loginData;
        using (MemoryStream ms = new MemoryStream(DataPayload))
        {
            loginData = (Login)serializer.DeserializeCommand(ms, Header);
            Console.WriteLine("New Login request");
            Console.WriteLine($"ID: {loginData.Id}");
            Console.WriteLine($"ReferrerId: {loginData.ReferrerId}");
            Console.WriteLine($"AuthKey: {loginData.AuthKey}");
            Console.WriteLine($"SocialCode: {loginData.SocialCode}");
        }

        if (loginData.Id == 0)
            throw new ArgumentException("Invalid login struct");
        
        //Senging test Login data
        EnterAccount enter = new EnterAccount
        {
            UserProfileStructure = new UserProfileStructure
            {
                Id = 1,
                Money = 133700,
                Rating = 2337,
                ReactionRate = 3337,
                RealMoney = 433700,
                SocialId = "1",
                WormsGroup = new List<WormStructure>
                {
                    new WormStructure
                    {
                        OwnerId = 1,
                        SocialOwnerId = "1",
                        Armor = 4,
                        Attack = 4,
                        Experience = 4,
                        Level = 4,
                        Hat = 0
                    }
                },
                WeaponRecordList = new()
                {
                    new() { Id = 1, Count = -1 },
                    new() { Id = 2, Count = -1 },
                    new() { Id = 4, Count = -1 },
                }
            },
            AvailableSearchKeys = 0,
            Friends = 0,
            OnlineFriends = 0,
            IsBonusDay = false,
            DailyBonusStructure = new DailyBonusStructure
            {
                DailyBonusType = 0,
                DailyBonusCount = 0,
                LoginSequence = 0
            },
            BonusDaysStructure = new BonusDaysStructure
            {
                BattlesCount = 0,
                BonusMessage = "",
                RealMoney = 0,
                Money = 0
            },
            SessionKey = "session_key",
        };

        byte[] response = new byte[BinaryCommandHeader.HeaderSize + enter.GetSize() + 16 /*MD5 Sum*/];
        using (MemoryStream ms = new MemoryStream(response))
        {
            EnterAccountBinarySerializer EnterSerializer = new EnterAccountBinarySerializer();
            EnterSerializer.SerializeCommand(enter, ms);
        }
        
        Console.WriteLine($"Sending:\n{HexDump.HexDump.Format(response)}");
        
        Client?.Client.Send(response);
    }
}