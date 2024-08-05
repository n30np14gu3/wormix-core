namespace wormix_core.Configuration;

public class ProviderProps(JObject props)
{
    private JObject _props = props;

    public JToken? GetProps(string name) => _props.GetValue(name);
}