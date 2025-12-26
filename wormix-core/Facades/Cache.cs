using wormix_core.Session;

namespace wormix_core.Facades;

public static class Cache
{
    public static void InitCache(TcpSession session)
    {
        ClearCache(session);
        session.Cache.StringSet(session.GetSessionId().ToString(), "{}");
    }
    
    public static void ClearCache(TcpSession session)
    {
        session.Cache.KeyDelete(session.GetSessionId().ToString());
    }

    public static JObject GetCacheObject(TcpSession session)
    {
        var result = session.Cache.StringGet(session.GetSessionId().ToString());
        return !result.HasValue ? new JObject() : JObject.Parse(result.ToString());
    }
}