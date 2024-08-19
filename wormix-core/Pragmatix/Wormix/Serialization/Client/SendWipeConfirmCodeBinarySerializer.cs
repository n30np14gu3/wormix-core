using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SendWipeConfirmCodeBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 52;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        SendWipeConfirmCode result = new();

        BinaryReader br = new BinaryReader(input);
        result.Level = (int)br.ReadUInt32Be();
        result.Experience = (int)br.ReadUInt32Be();
        result.Rating = (int)br.ReadUInt32Be();
        
        return result;
    }
}