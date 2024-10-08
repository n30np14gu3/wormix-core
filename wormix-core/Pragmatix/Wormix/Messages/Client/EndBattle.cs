﻿using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct EndBattle(int result = 0, int type = 0) : ISerializable
{
    public const int ResultWinner = 1;
    public const int ResultNotWinner = -1;

    public const int TypeMyLevel = 0;
    public const int TypeHighLevel = 1;
    public const int TypeLowLevel = 2;
    public const int TypePvpGame = 3;

    public int Result = result;
    public int Type = type;

    public int ExpBonus;
    
    public int BattleId;
    public int MissionId;

    public List<WeaponStructure> Items = new();
    public List<byte> Signature = new();

    public short BanType = 0;
    public string BanNote = "";

    public List<int> CollectedReagents = new();
    public uint GetSize()
    {
        return 0; //Not needed
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}