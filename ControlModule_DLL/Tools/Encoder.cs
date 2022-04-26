using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlModul.Tools
{
    /// <summary>
    /// Simple static class to endode text and files
    /// </summary>
    /// <remarks>
    /// Easy encode text and files to most common ways
    /// </remarks>
    public static class Encoder
    {
        public static string Base64FromString(string plainText)
        {
            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Base64FromBinary(byte[] binaryData)
        {
            try
            {
                return Convert.ToBase64String(binaryData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Base64ToString(string base64Text)
        {
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(base64Text));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] Base64ToBinary(string base64Text)
        {
            try
            {
                return Convert.FromBase64String(base64Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
