using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Flox.Serialization.Interfaces;

public interface ICommandSerializer
{
    uint GetCommandId();
    void SerializeCommand(ISerializable command, Stream output);
    ISerializable DeserializeCommand(Stream input, ICommandHeader header);
}