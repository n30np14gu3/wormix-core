using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SendWipeConfirmCodeResponse : ISerializable
{
    public const int Ok = 0;
    public const int DailyLimitExceeded = 1;
    public const int TodayAlreadyWiped = 2;
    public const int WrongMobileNumber = 3;
    public const int Error = 3;

    public byte Result;
    
    public uint GetSize()
    {
        return 1;
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.Write(Result);
    }
}