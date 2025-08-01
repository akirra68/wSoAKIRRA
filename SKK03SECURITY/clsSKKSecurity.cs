using SHAN04SECURITY;
using System.Security.Cryptography;

namespace SKK03SECURITY
{
    public class clsSKKSecurity
    {
        public string? prop01PrivateKey { get; set; }
        public string? prop02DataEncrypted { get; set; }
        public string? prop03DataEntryPassword { get; set; }

        public void pb01CreateEncryptPassword()
        {
            //**** JANGAN DIUBAH URUTANNYA ****//
            var rsaKey = EncryptProvider.CreateRsaKey();

            var publicKey = rsaKey.PublicKey;
            var privateKey = rsaKey.PrivateKey;

            var encrypted = EncryptProvider.RSAEncrypt(publicKey, prop03DataEntryPassword, RSAEncryptionPadding.Pkcs1);

            prop01PrivateKey = privateKey;
            prop02DataEncrypted = encrypted;
        }

        public string pb02DescryptPassword()
        {
            return EncryptProvider.RSADecrypt(prop01PrivateKey, prop02DataEncrypted, RSAEncryptionPadding.Pkcs1);
        }
    }
}
