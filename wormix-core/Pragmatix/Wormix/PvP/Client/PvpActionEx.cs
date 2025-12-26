namespace wormix_core.Pragmatix.Wormix.PvP.Client;

public class PvpActionEx : PvpCommand
{
    public uint FirstFrame;
    public uint LastFrame;
    public object ActionsByFrame = new();
}