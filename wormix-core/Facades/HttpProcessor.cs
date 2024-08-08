using System.Net;
using System.Text;
using wormix_core.Pragmatix.Wormix.Messages;

namespace wormix_core.Facades;

public class HttpProcessor
{
    public static JToken PostRequest(
        string url, 
        IMessage request,
        string token = ""
        )
    {
        using (HttpClient client = new HttpClient())
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            if(!string.IsNullOrWhiteSpace(token))
                client.DefaultRequestHeaders.Add("X-SESSION-KEY", token);
            var response = client.PostAsync(url, content).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Http Request Error [{response.StatusCode}]");

            return JToken.Parse(response.Content.ReadAsStringAsync().Result);
        }
    }
}