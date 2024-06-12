using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class LoginBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 1;
    }

    public void SerializeCommand(object command, Stream output)
    {
        //Not needed
        throw new NotImplementedException();
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        byte[] loginPayload = new byte[header.GetLength()];
        var readed = input.Read(loginPayload);
        if (readed < header.GetLength())
            throw new ArgumentException($"Invalid recv length {readed}<{header.GetLength()}");
        
        Login login = new Login();
        using (MemoryStream ms = new MemoryStream(loginPayload))
        {
            ms.Position = 0;
            BinaryReader br = new BinaryReader(ms);
            login.Id = br.ReadUInt32Be();
            login.ReferrerId = br.ReadUInt32Be();
            login.AuthKey = br.ReadUTF8();
            ushort idsCount = br.ReadUInt16Be();
            for(int i = 0; i < idsCount; i++)
                login.Ids.Add(br.ReadUInt32());

            login.SocialCode = br.ReadByte();
        }
        return login;
    }
}