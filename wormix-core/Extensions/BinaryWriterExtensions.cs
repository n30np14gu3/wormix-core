using System.Net;
using System.Text;

namespace wormix_core.Extensions;

public static class BinaryWriterExtensions
{
    public static void WriteUTF8(this BinaryWriter bw, string str)
    {
        bw.WriteUInt16Be((ushort)Encoding.UTF8.GetBytes(str).Length);
        if(str.Length != 0)
            bw.Write(Encoding.UTF8.GetBytes(str));
    }
    
    public static void WriteUInt32Be(this BinaryWriter bw, uint val)
    {
        bw.Write(BitConverter.GetBytes(val).Reverse().ToArray());
    }
    
    public static void WriteUInt16Be(this BinaryWriter bw, ushort val)
    {
        bw.Write(BitConverter.GetBytes(val).Reverse().ToArray());
    }
}