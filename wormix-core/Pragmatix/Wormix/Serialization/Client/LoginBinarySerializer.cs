using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class LoginBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 1;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        Login login = new();
        
        BinaryReader br = new BinaryReader(input);
        login.Id = br.ReadUInt32Be();
        login.ReferrerId = br.ReadUInt32Be();
        login.AuthKey = br.ReadUTF8();
        ushort idsCount = br.ReadUInt16Be();
        for(int i = 0; i < idsCount; i++)
            login.Ids.Add(br.ReadUInt32());
        login.SocialCode = br.ReadByte();
        
        return login;
    }
}