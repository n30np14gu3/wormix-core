namespace wormix_core.Pragmatix.Flox.Serialization.Interfaces;

public interface IStructureSerializer
{
    void SerializeStructure(object structure, Stream output, object param3);
    object DeserializeStructure(Stream input, object param2);
}