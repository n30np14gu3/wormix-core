using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class EndBattleBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 84;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        EndBattle endBattle = new();
        byte[] commandPayload = new byte[header.GetLength()];
        int readed = input.Read(commandPayload);
        if (readed < header.GetLength())
            throw new ArgumentException($"Invalid recv length {readed}<{header.GetLength()}");

        using (MemoryStream ms = new MemoryStream(commandPayload))
        {
            BinaryReader br = new BinaryReader(ms);

            br.ReadUTF8();
            endBattle.Result = (int)br.ReadUInt32Be();

            br.ReadUTF8();
            endBattle.Type = (int)br.ReadUInt32Be();

            br.ReadUTF8();
            endBattle.ExpBonus = (int)br.ReadUInt32Be();

            br.ReadUTF8();
            endBattle.BattleId = (int)br.ReadUInt32Be();
            endBattle.MissionId = (short)br.ReadUInt16Be();

            short weaponsCount = (short)br.ReadUInt16Be();
            endBattle.Items = new();
            for (int i = 0; i < weaponsCount; i++)
            {
                br.ReadUInt16(); //Skip size
                endBattle.Items.Add(new()
                {
                    Id = br.ReadUInt32Be(),
                    Count = (int)br.ReadUInt32Be()
                });
            }

            short signatureLength = (short)br.ReadUInt16Be();
            endBattle.Signature = new();
            for(int i = 0; i < signatureLength; i++)
                endBattle.Signature.Add(br.ReadByte());

            endBattle.BanType = (short)br.ReadUInt16Be();
            endBattle.BanNote = br.ReadUTF8();

            short reagentSize = (short)br.ReadUInt16Be();
            endBattle.CollectedReagents = new();
            for (int i = 0; i < reagentSize; i++)
                endBattle.CollectedReagents.Add(br.ReadByte());

            br.ReadBytes(16); //Hash
        }

        return endBattle;
    }
}