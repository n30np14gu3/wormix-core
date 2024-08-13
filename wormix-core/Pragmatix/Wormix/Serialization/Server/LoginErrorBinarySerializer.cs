using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public struct LoginErrorBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10002;
    }

    public void SerializeCommand(object command, Stream output)
    {
        if (command is LoginError error)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(error.GetSize());
            
            header.Write(output);
            error.Serialize(output);
        }
        else
            throw new InvalidCastException("Invalid LoginError struct");
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}