using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class UpgradeWeaponResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10086;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is UpgradeWeaponResult)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(command.GetSize() + 16 /*MD5 sum*/);

            byte[] resultPayload = new byte[command.GetSize()];
            using(MemoryStream ms = new MemoryStream(resultPayload))
                command.Serialize(ms);
            
            byte[] hash = SerializeSecurityUtils.Secure(resultPayload);
            
            //Need for work
            byte[] totalPayload = new byte[header.GetLength() + BinaryCommandHeader.HeaderSize];
            using (MemoryStream ms = new MemoryStream(totalPayload))
            {
                header.Write(ms);
                ms.Write(resultPayload);
                ms.Write(hash);
            }
            
            output.Write(totalPayload);
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}