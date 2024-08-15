using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Account;

public class LoginHandler(ICommandSerializer requestSerializer, GameController controller, TcpSession session) : 
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if(requestMessage is Login loginRequest)
        {
            if (loginRequest.Id == 0)
                throw new ArgumentException("Invalid login struct");


            ISerializable result = MessageController.ProcessMessage(loginRequest, Client);
            if (result is EnterAccount account) //OK
            {
                Client.SetToken(account.SessionKey);
                EnterAccountBinarySerializer enterSerializer = new EnterAccountBinarySerializer();
                enterSerializer.SerializeCommand(account, Client.GetStream());
            }
            else //Error
            {
                if (result is LoginError)
                {
                    LoginErrorBinarySerializer errorBinarySerializer = new LoginErrorBinarySerializer();
                    errorBinarySerializer.SerializeCommand(result, Client.GetStream());
                }
            
                //If login error or banned - sleep & close connection 
                Thread.Sleep(5000);
                Client.CloseSession();
            }
        }
    }
}