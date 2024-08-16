using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct DistributePoints(int armor, int attack) : ISerializable
{
    public int Armor = armor;
    public int Attack = attack;
    public uint GetSize()
    {
        return 8; //4 - armor + 4 -attack
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}