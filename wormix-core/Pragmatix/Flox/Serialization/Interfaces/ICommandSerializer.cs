﻿namespace wormix_core.Pragmatix.Flox.Serialization.Interfaces;

public interface ICommandSerializer
{
    uint GetCommandId();
    void SerializeCommand(object comand, Stream output);
    object DeserializeCommand(Stream input, ICommandHeader header);
}