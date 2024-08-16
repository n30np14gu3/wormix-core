using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct BuyBattle(int moneyType = -1) : ISerializable
{
    public const int RealMoney = 0;
    public const int Money = 1;

    public int MoneyType = moneyType;
    
    public uint GetSize()
    {
        return 0;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}
