using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct PumpReactionTheHouseResult : ISerializable
{
    public const byte Ok = 0;
    public const byte TodayAlreadyPumped = 1;
    public const byte Error = 2;
    public const byte DayLimitPump = 3;

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