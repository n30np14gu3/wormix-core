namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct SelectStuff(int stuffId = 0)
{
    public int StuffId = stuffId;
}