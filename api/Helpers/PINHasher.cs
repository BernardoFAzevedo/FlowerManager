using System.Security.Cryptography;
using System.Text;

namespace api.Helpers
{
    public static class PINHasher
    {
        public static string HashPIN(string pin)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(pin);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool VerifyPIN(string enteredPIN, string storedHash)
        {
            return HashPIN(enteredPIN) == storedHash;
        }
    }
}
