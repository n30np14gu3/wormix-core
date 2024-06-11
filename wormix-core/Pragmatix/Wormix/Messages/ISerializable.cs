namespace wormix_core.Pragmatix.Wormix.Messages;

public interface ISerializable
{
    void Serialize(Stream output);
}