using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using ControlModul.Tools;

namespace ControlModul.Security
{
    public enum AesLegalKeySize
    {
        AES_128 = 128,
        AES_196 = 196,
        AES_256 = 256
    }

    /// <summary>
    /// Class that represent tool to encrypt/decrypt messages 
    /// </summary>
    /// <remarks>
    /// Using AES variant as crypto algorithm
    /// </remarks>
    public class SymetricCryptographer
    {
        public Aes AesCryptographer { get; private set; }

        private byte[] IV;
        private byte[] Key;
        private int KeySize;

        public SymetricCryptographer(AesLegalKeySize keySize = AesLegalKeySize.AES_256)
        {
            KeySize = (int)keySize;
            IV = null;
            Key = null;
        }

        public SymetricCryptographer(byte[] key, byte[] iv)
        {
            // Check arguments.
            if (key == null)
                throw new ArgumentNullException("Key");
            // Check arguments.
            if (iv == null)
                throw new ArgumentNullException("IV");

            KeySize = key.Length;
            IV = iv;
            Key = key;
        }

        private Aes InitCryptographer()
        {
            var aes = Aes.Create();
            try
            {
                aes.KeySize = KeySize;

                if (IV == null)
                {
                    aes.GenerateIV();
                    IV = aes.IV;
                }
                if (Key == null)
                {
                    aes.GenerateKey();
                    Key = aes.Key;
                }

                aes.Key = Key;
                aes.IV = IV;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return aes;
        }

        public byte[] EncryptStringToBytes_Aes(string plainText)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");

            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (AesCryptographer = InitCryptographer())
            {
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = AesCryptographer.CreateEncryptor(AesCryptographer.Key, AesCryptographer.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public string DecryptStringFromBytes_Aes(byte[] cipherText)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (AesCryptographer = InitCryptographer())
            {
                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = AesCryptographer.CreateDecryptor(AesCryptographer.Key, AesCryptographer.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
