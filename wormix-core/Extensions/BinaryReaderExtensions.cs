﻿using System.Net;
using System.Text;

namespace wormix_core.Extensions;

public static class BinaryReaderExtensions
{
    public static string ReadUTF8(this BinaryReader reader)
    {
        ushort len = reader.ReadUInt16Be();
        if(len != 0) 
            return Encoding.UTF8.GetString(reader.ReadBytes(len));
        return "";
    }

    public static uint ReadUInt32Be(this BinaryReader reader)
    {
        return (uint)IPAddress.HostToNetworkOrder((int)reader.ReadUInt32());
    }
    
    public static ushort ReadUInt16Be(this BinaryReader reader)
    {
        return (ushort)IPAddress.HostToNetworkOrder((short)reader.ReadUInt16());
    }
}