namespace wormix_core.Pragmatix.Wormix.Messages;

public interface IMessage
{
    uint GetSize();
    void Serialize(Stream output);
}