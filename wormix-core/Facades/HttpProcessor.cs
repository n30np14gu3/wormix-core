using System.Net;
using System.Text;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Session;

namespace wormix_core.Facades;

public class HttpProcessor
{
    public static JToken PostRequest(
        string url, 
        IMessage request,
        TcpSession? session
        )
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("X-TCP-SESSION", session?.GetSessionId().ToString());

            Console.ForegroundColor = ConsoleColor.Green;
            string jsonRequest = JsonConvert.SerializeObject(request);
            Console.WriteLine(jsonRequest);
            
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            if(!string.IsNullOrWhiteSpace(session?.GetToken()))
                client.DefaultRequestHeaders.Add("X-SESSION-KEY", session?.GetToken());
            var response = client.PostAsync(url, content).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Http Request Error [{response.StatusCode}]");

            string result = response.Content.ReadAsStringAsync().Result;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result);

            Console.ForegroundColor = ConsoleColor.Gray;
            return JToken.Parse(result);
        }
    }
}