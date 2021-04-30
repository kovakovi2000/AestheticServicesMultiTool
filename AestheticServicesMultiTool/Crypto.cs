using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AestheticServicesMultiTool
{
    internal static class Crypto
    {
        internal static class OpenSSL_CBC
        {
            private static string password = "AestheticServicesMultiTool2021ByKova";
            private static byte[] iv = { 0x49, 0x20, 0x6c, 0x69, 0x6b, 0x65, 0x20, 0x4d, 0x65, 0x5f, 0x77, 0x61, 0x61, 0x20, 0x3a, 0x33 };
            //static byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            private static byte[] key;
            static OpenSSL_CBC()
            {
                SHA256 mySHA256 = SHA256Managed.Create();
                key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));
            }
            internal static string EncryptString(string plainText)
            {
                // Instantiate a new Aes object to perform string symmetric encryption
                Aes encryptor = Aes.Create();

                encryptor.Mode = CipherMode.CBC;
                //encryptor.KeySize = 256;
                //encryptor.BlockSize = 128;
                //encryptor.Padding = PaddingMode.Zeros;

                // Set key and IV
                encryptor.Key = key.Take(32).ToArray();
                encryptor.IV = iv;

                // Instantiate a new MemoryStream object to contain the encrypted bytes
                MemoryStream memoryStream = new MemoryStream();

                // Instantiate a new encryptor from our Aes object
                ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();

                // Instantiate a new CryptoStream object to process the data and write it to the 
                // memory stream
                CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

                // Convert the plainText string into a byte array
                byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);

                // Encrypt the input plaintext string
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);

                // Complete the encryption process
                cryptoStream.FlushFinalBlock();

                // Convert the encrypted data from a MemoryStream to a byte array
                byte[] cipherBytes = memoryStream.ToArray();

                // Close both the MemoryStream and the CryptoStream
                memoryStream.Close();
                cryptoStream.Close();

                // Convert the encrypted byte array to a base64 encoded string
                string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

                // Return the encrypted data as a string
                return cipherText;
            }

            internal static string DecryptString(string cipherText)
            {
                // Instantiate a new Aes object to perform string symmetric encryption
                Aes encryptor = Aes.Create();

                encryptor.Mode = CipherMode.CBC;
                //encryptor.KeySize = 256;
                //encryptor.BlockSize = 128;
                //encryptor.Padding = PaddingMode.Zeros;

                // Set key and IV
                encryptor.Key = key.Take(32).ToArray();
                encryptor.IV = iv;

                // Instantiate a new MemoryStream object to contain the encrypted bytes
                MemoryStream memoryStream = new MemoryStream();

                // Instantiate a new encryptor from our Aes object
                ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();

                // Instantiate a new CryptoStream object to process the data and write it to the 
                // memory stream
                CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

                // Will contain decrypted plaintext
                string plainText = String.Empty;

                try
                {
                    // Convert the ciphertext string into a byte array
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);

                    // Decrypt the input ciphertext string
                    cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);

                    // Complete the decryption process
                    cryptoStream.FlushFinalBlock();

                    // Convert the decrypted data from a MemoryStream to a byte array
                    byte[] plainBytes = memoryStream.ToArray();

                    // Convert the decrypted byte array to string
                    plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
                }
                finally
                {
                    // Close both the MemoryStream and the CryptoStream
                    memoryStream.Close();
                    cryptoStream.Close();
                }

                // Return the decrypted data as a string
                return plainText;
            }
        }

        internal static class OrderedShuffle
        {
            private static List<char> oKey = "ABCDEFGHIKLMNOPQRSTVWXYZJUabcdefghiklmnopqrstvwxyzju0123456789_=/-+ ".ToList();
            private static List<char> eKey = "74iHAB_CbDFmGwLMo+NOPQRST-j5YZJUac def=ghkXlnpqIrsVtv/xKyzuW0123689E".ToList();

            static OrderedShuffle()
            {
                if (oKey.Count != eKey.Count)
                    throw new Exception("Incorrect CryptoKeys length");

                for (int i = 0; i < oKey.Count; i++)
                    if (oKey[i] == eKey[i]) 
                        throw new Exception("Incorrect CryptoKeys");
            }

            internal static string EncryptString(string text)
            {
                string output = string.Empty;
                foreach (char letter in text)
                    output += eKey[oKey.IndexOf(letter)];
                return output;
            }
            internal static string DecryptString(string text)
            {
                string output = string.Empty;
                foreach (char letter in text)
                    output += oKey[eKey.IndexOf(letter)];
                return output;
            }
        }
    }
}
