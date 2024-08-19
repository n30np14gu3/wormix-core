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

    public static bool IsSecure(byte[] input)
    {
        byte[] calculated = Secure(input.Take(input.Length - 16).ToArray());
        byte[] hash = input.Skip(input.Length - 16).ToArray();

        return calculated.SequenceEqual(hash);
    }
}