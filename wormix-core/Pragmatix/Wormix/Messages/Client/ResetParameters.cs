namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct ResetParameters(int moneyType = -1) : IMessage
{
    public const int RealMoney = 0;
    public const int Money = 1;

    public int MoneyType = moneyType;
    public uint GetSize()
    {
        return 4; //Money type
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}