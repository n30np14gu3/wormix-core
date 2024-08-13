using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class AchieveLoginBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 3001;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is AchieveLogin achieveLogin)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(achieveLogin.GetSize());
            
            byte[] payload = new byte[BinaryCommandHeader.HeaderSize + achieveLogin.GetSize()];
            using(MemoryStream ms = new MemoryStream(payload))
            {
                //Write header
                header.Write(ms);
                
                //Write AchieveLogin data
                BinaryWriter bw = new BinaryWriter(ms);
                bw.WriteUTF8(achieveLogin.ApplicationId);
                bw.WriteUTF8(achieveLogin.SocialNetworkId);
                bw.WriteUTF8(achieveLogin.Id);
                bw.WriteUTF8(achieveLogin.AuthKey);
                bw.Write(achieveLogin.SendAchievements);
            }
            
            //Send to output stream
            output.Write(payload);
        }
        else
            throw new InvalidCastException($"Invalid object: {command}");
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        AchieveLogin achieveLogin = new AchieveLogin();
        byte[] data = new byte[header.GetLength()];
        var readCount = input.Read(data);
        if (readCount != header.GetLength())
            throw new ArgumentException($"Invalid recv data {readCount} [{header.GetLength()}]");
        using (MemoryStream ms = new MemoryStream(data))
        {
            BinaryReader br = new BinaryReader(ms);
            achieveLogin.ApplicationId = br.ReadUTF8();
            achieveLogin.SocialNetworkId = br.ReadUTF8();
            achieveLogin.Id = br.ReadUTF8();
            achieveLogin.AuthKey = br.ReadUTF8();
            achieveLogin.SendAchievements = br.ReadBoolean();
        }
        return achieveLogin;
    }
}