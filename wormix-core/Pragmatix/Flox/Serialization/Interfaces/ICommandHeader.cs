namespace wormix_core.Pragmatix.Flox.Serialization.Interfaces;

public interface ICommandHeader
{
    uint GetCommandId();
    uint GetLength();
    ICommandHeader Read(Stream input);
}