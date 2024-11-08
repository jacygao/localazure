using System.Security.Cryptography;

namespace Emulator.Services.KeyVault
{
    public class Utils
    {
        public static string GenerateVersionIdentifier()
        {
            var bytes = new byte[16]; // 16 bytes = 128 bits
            RandomNumberGenerator.Fill(bytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
