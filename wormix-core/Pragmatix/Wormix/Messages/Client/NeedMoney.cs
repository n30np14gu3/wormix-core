using wormix_core.Pragmatix.Flox.Model;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct NeedMoney(int value = 0)
{
    public int Value = value;
    public int MoneyType;

    public void SetMoneyType(MoneyType type)
    {
        MoneyType = (int)type;
    }
    
}