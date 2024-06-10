namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct DistributePoints(int armor, int attack)
{
    public int Armor = armor;
    public int Attack = attack;
}