namespace wormix_core.Controllers.Http.Attributes;

public class ApiPost(string route = "") : Attribute
{
    public readonly string Route = route;
}