using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class UserIsBannedBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10023;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is UserIsBanned userBan)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(userBan.GetSize());

            byte[] payload = new byte[userBan.GetSize() + BinaryCommandHeader.HeaderSize];
            using (MemoryStream ms = new MemoryStream(payload))
            {
                header.Write(ms);
                BinaryWriter bw = new BinaryWriter(ms);
                bw.WriteUInt32Be((uint)userBan.Reason);
                bw.WriteUInt32Be(userBan.EndDate);
            }
            
            output.Write(payload);
        }
        else
            throw new InvalidCastException("Invalid UserIsBanned object");
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}