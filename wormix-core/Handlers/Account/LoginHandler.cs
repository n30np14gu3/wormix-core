using wormix_core.Controllers.Account;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Account;

public class LoginHandler : GameMessageHandler
{
    protected override void Process()
    {
        if (DataPayload == null || Header == null)
            return;
        
        LoginBinarySerializer serializer = new LoginBinarySerializer();
        Login loginData;
        using (MemoryStream ms = new MemoryStream(DataPayload))
            loginData = (Login)serializer.DeserializeCommand(ms, Header);

        if (loginData.Id == 0)
            throw new ArgumentException("Invalid login struct");


        IMessage result = new LoginController().ProcessMessage(loginData, Client);
        if (result is EnterAccount account) //OK
        {
            Client?.SetToken(account.SessionKey);
            byte[] response = new byte[BinaryCommandHeader.HeaderSize + account.GetSize() + 16 /*MD5 Sum*/];
            using (MemoryStream ms = new MemoryStream(response))
            {
                EnterAccountBinarySerializer enterSerializer = new EnterAccountBinarySerializer();
                enterSerializer.SerializeCommand(account, ms);
            }
        
            Client?.SessionClient?.Client.Send(response);
        }
        else //Error
        {
            byte[] response = new byte[BinaryCommandHeader.HeaderSize + result.GetSize()];
            
            using (MemoryStream ms = new MemoryStream(response))
            {
                if (result is LoginError)
                {
                    LoginErrorBinarySerializer errorBinarySerializer = new LoginErrorBinarySerializer();
                    errorBinarySerializer.SerializeCommand(result, ms);
                }
            }
            Client?.SessionClient?.Client.Send(response);
            
            //If login error or banned - sleep & close connection 
            Thread.Sleep(5000);
            Client?.SessionClient?.Close();
        }

    }
}