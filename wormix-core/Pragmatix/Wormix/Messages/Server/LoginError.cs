using wormix_core.Extensions;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct LoginError : IMessage
{
    public const int ProphylacticWork = 0;
    public const int IncorrectKey = 1;
    public const int AlreadyInGame = 2;
    public const int InternalServerError = 3;
    public const int Ban = 4;

    public int Result;
    
    public uint GetSize()
    {
        return 4; // Result sizeof
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Result);
    }
}