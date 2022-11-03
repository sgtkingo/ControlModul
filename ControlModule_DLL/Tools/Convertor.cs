using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControlModul.Handlers.Loger;

namespace ControlModul.Tools
{
    /// <summary>
    /// Simple static class that convert any Type to any Type
    /// </summary>
    /// <remarks>
    /// Easy converts variable and objects to other Types
    /// </remarks>
    public static class Convertor
    {
        public static T ConvertTo<T>(object item){
            object convertedItem = null;
            try
            {
                convertedItem = Convert.ChangeType(item, typeof(T));
            }
            catch (Exception e)
            {
                Loger.Log(e);
                return default(T);
            }

            return (T)convertedItem;
        }

        public static string BytesToString(byte[] hashData)
        {
            try
            {
                return BitConverter.ToString(hashData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string BytesToString(byte[] data, string format = "X")
        {
            string s = string.Empty;
            foreach (byte b in data)
            {
                s += b.ToString(format) + " ";
            }
            return s;
        }

        public static byte[] StringToBytes(string plainText)
        {
            try
            {
                return Encoding.UTF8.GetBytes(plainText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
