namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct GetFriendListPage(int pageIndex = 1)
{
    public int PageIndex = pageIndex;
}