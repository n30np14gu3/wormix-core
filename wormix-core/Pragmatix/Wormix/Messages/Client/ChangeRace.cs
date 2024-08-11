namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct ChangeRace(byte raceId = 0, byte moneyType = 0) : IMessage
{
    public const byte RealMoney = 0;
    public const byte Money = 1;

    public byte RaceId = raceId;
    public byte MoneyType = moneyType;
    public uint GetSize()
    {
        return 2;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}
