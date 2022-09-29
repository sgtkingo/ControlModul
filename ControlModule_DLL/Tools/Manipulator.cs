using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ControlModul.Handlers.Loger;

namespace ControlModul.Tools
{
    public static class Manipulator
    {
        ///<summary>
        ///Copy object to Clipboard
        ///</summary>
        ///<param name="item">
        ///Must implement attribut [Serializable]
        ///</param>
        public static void CopyObject(object item, string itemName = "ItemCopy")
        {
            try
            {
                Clipboard.SetData(itemName, item);
            }
            catch (Exception ex)
            {
                Loger.Log(ex);
            }
        }

        ///<summary>
        ///Paste object from Clipboard
        ///</summary>
        ///<returns>
        ///Object casted to T or default 
        ///</returns>
        public static T PasteObject<T>(bool autoclear = true, string itemName = "ItemCopy")
        {
            try
            {
                var item = Clipboard.GetData(itemName);
                if (autoclear)
                {
                    ClearClipboard();
                }
                return (T)item;
            }
            catch (Exception ex)
            {
                Loger.Log(ex);
                return default(T);
            }
        }

        ///<summary>
        ///Test if object is in the Clipboard
        ///</summary>
        public static bool Exist(string itemName = "ItemCopy")
        {
            try
            {
                return Clipboard.GetData(itemName) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///<summary>
        ///Clear all objects from Clipboard permanently
        ///</summary>
        public static void ClearClipboard()
        {
            Clipboard.Clear();
        } 
    }
}
