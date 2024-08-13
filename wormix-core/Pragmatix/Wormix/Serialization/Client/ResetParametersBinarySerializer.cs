using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class ResetParametersBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 15;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        byte[] paload = new byte[header.GetLength()];
        var readed = input.Read(paload);
        if (readed < header.GetLength())
            throw new ArgumentException($"Invalid recv length {readed}<{header.GetLength()}");

        ResetParameters result = new();
        using (MemoryStream ms = new MemoryStream(paload))
        {
            BinaryReader br = new BinaryReader(ms);
            result.MoneyType = (int)br.ReadUInt32Be();
        }

        return result;

    }
}