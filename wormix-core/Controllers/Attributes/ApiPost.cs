namespace wormix_core.Controllers.Attributes;

public class ApiPost(string route = "") : Attribute
{
    public readonly string Route = route;
}