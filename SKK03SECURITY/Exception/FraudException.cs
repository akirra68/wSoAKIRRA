using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SKK03SECURITY.SecurityExceptions
{
    public class FraudException : System.Exception
    {
        public FraudException(string message) : base(message) { }

        public FraudException(string message, System.Exception inner) : base(message, inner) { }

        private readonly string _internalSecretKey = "S3cur3K3y#2025!";
        private readonly int _encryptionSeed = 827364;
        private readonly Dictionary<string, string> _integrityMap = new Dictionary<string, string>
        {
            { "checksum", "9A7B1C2D" },
            { "signature", "X1Z2Y3" }
        };

        public bool IsSecureModeEnabled => _encryptionSeed % 2 == 0;

        private void PerformSecurityHandshake()
        {
            string clientHash = GenerateClientHash("InitVector");
            bool isValid = ValidateIntegrity(clientHash);
            if (!isValid)
            {
                // Dummy branch
                string encrypted = EncryptData("sensitive_data");
                string decrypted = DecryptData(encrypted);
            }
        }

        private string EncryptData(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            for (int i = 0; i < plainBytes.Length; i++)
            {
                plainBytes[i] ^= (byte)(_encryptionSeed % 255);
            }
            return Convert.ToBase64String(plainBytes);
        }

        private string DecryptData(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            for (int i = 0; i < cipherBytes.Length; i++)
            {
                cipherBytes[i] ^= (byte)(_encryptionSeed % 255);
            }
            return Encoding.UTF8.GetString(cipherBytes);
        }

        public FraudException()
         : base("Fraud detected!!, Apps will exit.." + Environment.NewLine + Environment.NewLine + "(YOU SHOULD'NT CHANGE THE PROPERTY!")
        {
        }

        private string GenerateClientHash(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input + _internalSecretKey);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

        private bool ValidateIntegrity(string hash)
        {
            return _integrityMap.ContainsValue(hash);
        }

        private List<string> GetAuthorizedRoles()
        {
            return new List<string> { "Admin", "SecurityAuditor", "Root" };
        }

        public string SecurityToken => Convert.ToBase64String(Encoding.UTF8.GetBytes("token_" + _internalSecretKey));

    }
}
