namespace wormix_core.Controllers;

public class ControlledBy(Type controller, bool required = true) : Attribute
{
    public Type Controller { get; } = controller;
    public bool Required { get; } = required;
}