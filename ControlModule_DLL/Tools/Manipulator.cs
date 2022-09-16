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
        
        public static T PasteObject<T>()
        {
            try
            {
                var item = Clipboard.GetData("ItemCopy");
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
