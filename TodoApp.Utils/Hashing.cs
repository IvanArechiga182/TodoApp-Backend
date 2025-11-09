using Konscious.Security.Cryptography;
using System.Text;
namespace TodoApp.Utils
{
    public class Hashing
    {
        public static string HashPassword(string password)
        {
            var salt = Guid.NewGuid().ToByteArray();
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                MemorySize = 65536,
                Iterations = 4
            };

            var hash = argon2.GetBytes(32);
            var fullHash = Convert.ToBase64String(salt.Concat(hash).ToArray());
            return fullHash;
        }

        public static bool VerifyPassword(string password, string hashed)
        {
            var fullBytes = Convert.FromBase64String(hashed);
            var salt = fullBytes.Take(16).ToArray();
            var storedHash = fullBytes.Skip(16).ToArray();

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                MemorySize = 65536,
                Iterations = 4
            };

            var computedHash = argon2.GetBytes(32);
            return storedHash.SequenceEqual(computedHash);
        }
    }
}
