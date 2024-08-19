﻿using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct DistributePointsResult : ISerializable
{
    public const int Success = 0;
    public const int Error = 1;
    public const int NotEnoughPoints = 2;
    
    public short Result;

    public uint GetSize()
    {
        return 2;
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
    }
}