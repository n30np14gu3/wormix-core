using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SelectStuffBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 25;
    }

    public void SerializeCommand(object command, Stream output)
    {
        //Not needed
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        SelectStuff result = new();
        byte[] selectStuffPayload = new byte[header.GetLength()];
        var readed = input.Read(selectStuffPayload);
        if (readed < header.GetLength())
            throw new ArgumentException($"Invalid recv length {readed}<{header.GetLength()}");

        BuyShopItems shopItems = new BuyShopItems();
        using (MemoryStream ms = new MemoryStream(selectStuffPayload))
        {
            BinaryReader br = new BinaryReader(ms);
            result.StuffId = (short)br.ReadUInt16Be();
        }

        return result;
    }
}