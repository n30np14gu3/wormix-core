using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class ChangeRaceSerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 36;
    }

    public void SerializeCommand(object command, Stream output)
    {
        
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        byte[] changeRacePayload = new byte[header.GetLength()];
        var readed = input.Read(changeRacePayload);
        if (readed < header.GetLength())
            throw new ArgumentException($"Invalid recv length {readed}<{header.GetLength()}");

        ChangeRace result = new();
        using (MemoryStream ms = new MemoryStream(changeRacePayload))
        {
            BinaryReader br = new BinaryReader(ms);
            result.RaceId = br.ReadByte();
            result.MoneyType = br.ReadByte();
        }

        return result;
    }
}