namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct PvpChatMessage(uint id = 0, uint battleId = 0, string message = "")
{
    public uint Id = id;
    public uint BattleId = battleId;

    public string Message = message;
}