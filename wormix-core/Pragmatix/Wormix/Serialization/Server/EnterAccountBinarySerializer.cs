using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class EnterAccountBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10001;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is EnterAccount)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(command.GetSize() + 16 /*MD5 Sum*/);

            byte[] payload = new byte[command.GetSize()];
            using (MemoryStream ms = new MemoryStream(payload))
                command.Serialize(ms);

            byte[] hash = SerializeSecurityUtils.Secure(payload);
            
            //Need for work
            byte[] result = new byte[payload.Length + hash.Length + BinaryCommandHeader.HeaderSize];
            using (MemoryStream ms = new MemoryStream(result))
            {
                header.Write(ms);
                ms.Write(payload);
                ms.Write(hash);
            }

            output.Write(result);
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}