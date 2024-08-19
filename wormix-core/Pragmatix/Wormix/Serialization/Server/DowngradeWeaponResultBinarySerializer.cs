using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class DowngradeWeaponResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 1088;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is DowngradeWeaponResult)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(command.GetSize() + 16 /*MD5 checksum*/);

            byte[] responseBytes = new byte[command.GetSize()];
            using(MemoryStream ms = new MemoryStream(responseBytes))
                command.Serialize(ms);

            byte[] hash = SerializeSecurityUtils.Secure(responseBytes);

            //Need for work
            byte[] response = new byte[BinaryCommandHeader.HeaderSize + header.GetLength()];
            using (MemoryStream ms = new MemoryStream(response))
            {
                header.Write(ms);
                ms.Write(responseBytes);
                ms.Write(hash);
            }
            
            output.Write(responseBytes);
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}