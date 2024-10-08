﻿using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct Login() : ISerializable
{
    public uint Id;
    public uint ReferrerId;
    public string AuthKey = "";
    public List<uint> Ids = new();
    public uint SocialCode;


    public uint GetSize()
    {
        return (uint)(
            4 //Id
            + 4 //ReffererId
            + 2 + AuthKey.Length // AuthKey length + AuthKey
            + Ids.Count * 4 // Ids count * Ids[0] size
            + 1 // SocialCode
        );
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}