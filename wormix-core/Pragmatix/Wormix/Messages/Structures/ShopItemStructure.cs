namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

/// <summary>
/// Paste from ru.pragmatix.wormix.messages.structures.ShopItemStructure
/// </summary>
public struct ShopItemStructure
{
    public const int Money = 1;
    public const int RealMoney = 0;

    public int Id;
    public int MoneyType;
    public int Count;

    public override string ToString()
    {
        return $"ShopItemStructure{{id={Id},count={Count},moneyType={MoneyType}}}";
    }
}