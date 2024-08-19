namespace wormix_core.Pragmatix.Wormix.Messages.Interfaces;

public interface ISerializable
{
    uint GetSize();
    void Serialize(Stream output);
}