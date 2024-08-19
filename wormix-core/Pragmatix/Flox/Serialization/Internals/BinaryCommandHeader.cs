using System.Net;
using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;

namespace wormix_core.Pragmatix.Flox.Serialization.Internals;

public class BinaryCommandHeader : ICommandHeader
{
    /// <summary>
    /// 1 byte - flag<br/>
    /// 2 bytes - CommandId<br/>
    /// 4 bytes - Length
    /// </summary>
    public const int HeaderSize = 7;
    
    private const uint CleanCommandId = 32767;
    private const uint CleanLength = 1073741823;
    
    private const uint EFlag = 8;
    private const uint DFlag = 32;
    private const uint BFlag = 128;
    private const int ConstFlags = 87;
    
    private const uint MaxLengthValue = 1073741823;
    private const uint MaxCommandIdValue = 32767;
    
    private const uint BSync = 32768;
    private const uint DSync = 1073741824;
    private const uint ESync = 2147483648;
    
    private const string IllegalVarValues = "Недопустимые значения переменных";
    private const string IllegalCommandHeader = "Недопустимый заголовок команды";
    
    private uint _commandId;
    private uint _rawCommandId;
    
    private uint _flags;
    
    private uint _length;
    private uint _rawLength;
    
    private bool _isValid;


    public uint GetCommandId() => _commandId;
    public uint GetLength() => _length;
    public bool GetIsValid() => _isValid;

    public void SetLength(uint length) => _length = length;
    public void SetCommandId(uint commandId) => _commandId = commandId;
    
    
    public ICommandHeader Read(Stream input)
    {
        FillRawsFromStream(input);
        if (Validate())
        {
            Parse();
            return this;
        }
        Console.WriteLine("Error");
        throw new ArgumentException(IllegalCommandHeader);
    }

    public void Write(Stream output)
    {
        if (CheckValues())
        {
            BuildHeaderInRaws();
            WriteRaws(output);
            return;
        }
        
        throw new ArgumentException(IllegalVarValues);
    }

    private void FillRawsFromStream(Stream stream)
    {
        BinaryReader br = new BinaryReader(stream);
        _flags = br.ReadByte();
        _rawCommandId = (uint)IPAddress.HostToNetworkOrder(br.ReadInt16());
        _rawLength = (uint)IPAddress.HostToNetworkOrder(br.ReadInt32());
    }

    private bool Validate()
    {
        _isValid = Check1() && CheckB() && CheckD() && CheckE();
        return _isValid;
    }

    private bool Check1()
    {
        return (_flags & ConstFlags) == ConstFlags;
    }

    private bool CheckB()
    {
        return Convert.ToBoolean(_flags & BFlag) != Convert.ToBoolean(_rawCommandId & BSync);
    }

    private bool CheckD()
    {
        return Convert.ToBoolean(_flags & DFlag) != Convert.ToBoolean(_rawLength & DSync);
    }
    
    private bool CheckE()
    {
        return Convert.ToBoolean(_flags & EFlag) != Convert.ToBoolean(_rawLength & ESync);
    }

    private bool CheckValues()
    {
        return _commandId <= MaxCommandIdValue && _length <= MaxLengthValue;
    }

    private void Parse()
    {
        _commandId = _rawCommandId & CleanCommandId;
        _length = _rawLength & CleanLength;
    }

    private void BuildHeaderInRaws()
    {
        Random rn = new Random((int)DateTime.Now.Ticks);
        
        _rawCommandId = _commandId;
        _flags = ConstFlags;
        _rawLength = _length;

        if (rn.Next(0, 2) % 2 == 0)
            _flags |= 128;
        else
            _rawCommandId |= 32768;
        
        if (rn.Next(0, 2) % 2 == 0)
            _flags |= 32;
        else
            _rawLength |= 1073741824;
        
        if (rn.Next(0, 2) % 2 == 0)
            _flags |= 8;
        else
            _rawLength |=  2147483648;
    }

    private void WriteRaws(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.Write((byte)_flags);
        bw.WriteUInt16Be((ushort)_rawCommandId);
        bw.WriteUInt32Be(_rawLength);
    }
}