using System.Security.Cryptography;
using System.Text;

namespace SHAN04SECURITY
{
    class Contoh
    {
        static void Main(string[] args)
        {
            var aesKey = EncryptProvider.CreateAesKey();
            var key = aesKey.Key;
            var iv = aesKey.IV;

            var plaintext = "Aris Nugroho Joni Prasetyo";
            var encrypted = EncryptProvider.AESEncrypt(plaintext, key, iv);
            var decrypted = EncryptProvider.AESDecrypt(encrypted, key, iv);

            Console.WriteLine("Plaintext to encrypt: " + plaintext);
            Console.WriteLine();

            Console.WriteLine("** AES SecureRandom **");
            Console.WriteLine("Encrypted " + " (Length: " + encrypted.Length + ") " + encrypted);
            Console.WriteLine("Decrypted " + " (Length: " + decrypted.Length + ") " + decrypted);
            Console.WriteLine("Key: {0} IV: {1}", key, iv);

            Console.WriteLine();
            Console.WriteLine("** AES SecureRandom with Byte input/output **");
            byte[] bencrypted = EncryptProvider.AESEncrypt(Encoding.UTF8.GetBytes(plaintext), key, iv);
            byte[] bdecrypted = EncryptProvider.AESDecrypt(bencrypted, key, iv);

            Console.WriteLine("Encrypted " + " (Length: " + bencrypted.Length + ") " + Encoding.UTF8.GetString(bencrypted));
            Console.WriteLine("Decrypted " + " (Length: " + bdecrypted.Length + ") " + Encoding.UTF8.GetString(bdecrypted));
            Console.WriteLine("Key: {0} IV: {1}", key, iv);

            Console.WriteLine();

            Console.WriteLine("** AES Non-SecureRandom **");

            aesKey = EncryptProvider.CreateAesKey();
            key = aesKey.Key;
            iv = aesKey.IV;

            encrypted = EncryptProvider.AESEncrypt(plaintext, key, iv);
            decrypted = EncryptProvider.AESDecrypt(encrypted, key, iv);
            Console.WriteLine("Encrypted " + " (Length: " + encrypted.Length + ") " + encrypted);
            Console.WriteLine("Decrypted " + " (Length: " + decrypted.Length + ") " + decrypted);
            Console.WriteLine("Key: {0} IV: {1}", key, iv);

            Console.WriteLine();
            Console.WriteLine("** SHA **");
            Console.WriteLine("SHA1: " + EncryptProvider.Sha1(plaintext));
            Console.WriteLine("SHA256: " + EncryptProvider.Sha256(plaintext));
            Console.WriteLine("SHA384: " + EncryptProvider.Sha384(plaintext));
            Console.WriteLine("SHA512: " + EncryptProvider.Sha512(plaintext));


            Console.WriteLine();
            Console.WriteLine("***** RSA *****");
            var rsaKey = EncryptProvider.CreateRsaKey();

            var publicKey = rsaKey.PublicKey;
            var privateKey = rsaKey.PrivateKey;

            encrypted = EncryptProvider.RSAEncrypt(publicKey, plaintext, RSAEncryptionPadding.Pkcs1);
            decrypted = EncryptProvider.RSADecrypt(privateKey, encrypted, RSAEncryptionPadding.Pkcs1);

            Console.WriteLine("Encrypted: " + encrypted);
            Console.WriteLine("Decrypted: " + decrypted);
            Console.WriteLine("PublicKey: " + publicKey);
            Console.WriteLine("PrivateKey: " + privateKey);
            Console.WriteLine("***** END - RSA *****");

            rsaKey = EncryptProvider.CreateRsaKey();

            publicKey = rsaKey.PublicKey;
            privateKey = rsaKey.PrivateKey;

            var testStr = "test issues #25 ";

            Console.WriteLine($"Test str:{testStr}");

            var saveDir = AppDomain.CurrentDomain.BaseDirectory;

            var publicKeySavePath = Path.Combine(saveDir, "privateKey.txt");
            if (File.Exists(publicKeySavePath))
            {
                File.Delete(publicKeySavePath);
            }
            using (FileStream fs = new FileStream(publicKeySavePath, FileMode.CreateNew))
            {
                fs.Write(Encoding.UTF8.GetBytes(privateKey));
            }

            var encryptStr = EncryptProvider.RSAEncrypt(publicKey, testStr, RSAEncryptionPadding.Pkcs1);
            Console.WriteLine($"encryped str:{encryptStr}");
            var encryptSavePath = Path.Combine(saveDir, "encrypt.txt");

            if (File.Exists(encryptSavePath))
            {
                File.Delete(encryptSavePath);
            }

            using (FileStream fs = new FileStream(encryptSavePath, FileMode.CreateNew))
            {
                fs.Write(Encoding.UTF8.GetBytes(encryptStr));
            }

            Console.ReadKey();


        }
    }
}
