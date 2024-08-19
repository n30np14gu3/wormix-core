using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct ReorderGroup() : ISerializable
{
    public List<uint> ReorderedWormGroup = new();
    
    public uint GetSize()
    {
        return (uint)(
            2 + ReorderedWormGroup.Count * 2
        );
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}