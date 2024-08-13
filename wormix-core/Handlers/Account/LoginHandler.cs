using wormix_core.Controllers;
using wormix_core.Controllers.Account;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;

namespace wormix_core.Handlers.Account;

[ControlledBy(typeof(LoginController))]
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


        IMessage result = MessageController!.ProcessMessage(loginData, Client);
        if (result is EnterAccount account) //OK
        {
            Client?.SetToken(account.SessionKey);
            EnterAccountBinarySerializer enterSerializer = new EnterAccountBinarySerializer();
            enterSerializer.SerializeCommand(account, Client?.GetStream()!);
        }
        else //Error
        {
            if (result is LoginError)
            {
                LoginErrorBinarySerializer errorBinarySerializer = new LoginErrorBinarySerializer();
                errorBinarySerializer.SerializeCommand(result, Client?.GetStream()!);
            }
            
            //If login error or banned - sleep & close connection 
            Thread.Sleep(5000);
            Client?.CloseSession();
        }

    }
}