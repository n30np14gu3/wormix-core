using System.Security.Cryptography;
using System.Text;

namespace wormix_core.Pragmatix.Flox.Secure;

public class SerializeSecurityUtils
{
    public static byte[] Secure(byte[] input)
    {
        List<byte> totalBytes = input.ToList();
        totalBytes.AddRange(Encoding.UTF8.GetBytes(SecuritySettings.SecretKey));
        return MD5.Create().ComputeHash(
            totalBytes.ToArray()
            );
    }
}