using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using ControlModul.Tools;

namespace ControlModul.Security
{
    /// <summary>
    /// Simple static class to hash text and files
    /// </summary>
    /// <remarks>
    /// Easy hash text and files to most common ways
    /// </remarks>
    public static class Hasher
    {
        public static byte[] StringToHash(string plainText, string hashAlgorithm = "SHA-256")
        {
            try
            {
                HashAlgorithm usedHashAlgorithm = HashAlgorithm.Create(hashAlgorithm);
                byte[] myHash = usedHashAlgorithm.ComputeHash(Convertor.StringToBytes(plainText));

                return myHash;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string StringToHashString(string plainText, string hashAlgorithm = "SHA-256")
        {
            try
            {
                HashAlgorithm usedHashAlgorithm = HashAlgorithm.Create(hashAlgorithm);
                byte[] myHash = usedHashAlgorithm.ComputeHash(Convertor.StringToBytes(plainText));

                return Convertor.BytesToString(myHash);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] BytesToHash(byte[] binaryData, string hashAlgorithm = "SHA-256")
        {
            try
            {
                HashAlgorithm usedHashAlgorithm = HashAlgorithm.Create(hashAlgorithm);
                byte[] myHash = usedHashAlgorithm.ComputeHash(binaryData);

                return myHash;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string BytesToHashString(byte[] binaryData, string hashAlgorithm = "SHA-256")
        {
            try
            {
                HashAlgorithm usedHashAlgorithm = HashAlgorithm.Create(hashAlgorithm);
                byte[] myHash = usedHashAlgorithm.ComputeHash(binaryData);

                return Convertor.BytesToString(myHash);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
