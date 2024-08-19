using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct AddToGroup(uint profileId = 0, short moneyType = 0) : ISerializable
{
    public const int RealMoney = 0;
    public const short Money = 1;

    public uint ProfileId = profileId;
    public int MoneyType = moneyType;
    
    public uint GetSize()
    {
        return 4 //ProfileId
               + 2; //MoneyType
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}
