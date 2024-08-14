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
        if (command is EnterAccount account)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(account.GetSize() + 16 /*MD5 Sum*/);

            byte[] payload = new byte[account.GetSize()];
            using (MemoryStream ms = new MemoryStream(payload))
                account.Serialize(ms);

            byte[] hash = SerializeSecurityUtils.Secure(payload);
            
            //Need for work
            byte[] result = new byte[payload.Length + hash.Length];
            using (MemoryStream ms = new MemoryStream(result))
            {
                ms.Write(payload);
                ms.Write(hash);
            }
            header.Write(output);
            output.Write(result);
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}