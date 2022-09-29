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
        public static void CopyObject(object item)
        {
            try
            {
                Clipboard.SetData("ItemCopy", item);
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
        public static T PasteObject<T>(bool autoclear = true)
        {
            try
            {
                var item = Clipboard.GetData("ItemCopy");
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

        public static void ClearClipboard()
        {
            Clipboard.Clear();
        } 
    }
}
