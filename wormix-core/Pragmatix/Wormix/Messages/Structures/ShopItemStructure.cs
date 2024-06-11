namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct ShopItemStructure()
{
    public const int RealMoney = 0;
    public const int Money = 1;

    public uint Id;
    public int Count = 0;
    public int MoneyType;
    
}