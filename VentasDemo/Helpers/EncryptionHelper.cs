

namespace VentasDemo.Helpers
{
    public static class EncrypionHelper
    {
        public static string EncryptPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            return BitConverter.ToString(sha256.ComputeHash(bytes)).Replace("-", "").ToLower();
        }
    }
}