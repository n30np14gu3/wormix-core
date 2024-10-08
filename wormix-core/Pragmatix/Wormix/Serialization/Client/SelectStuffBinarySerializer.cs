﻿using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SelectStuffBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 25;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        SelectStuff result = new();
        BinaryReader br = new BinaryReader(input);
        result.StuffId = (short)br.ReadUInt16Be();
        return result;
    }
}