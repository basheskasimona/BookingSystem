using System.Security.Cryptography;

namespace MockBookingSystem.Services
{
    public interface ICodeGenerator
    {
        public string Generate();
    }

    public class CodeGenerator : ICodeGenerator
    {
        public string Generate()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] id = new char[6];

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = chars[random.Next(chars.Length)];
            }

            return new string(id);
        }
    }
}
