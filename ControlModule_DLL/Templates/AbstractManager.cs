using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlModul.Templates
{
    public abstract class AbstractManager<T> where T:class
    {
        public static List<T> Items { get; protected set; } = new List<T>();

        public static void Add(T item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
            Items.Add(item);
        }

        public static void Remove(T item)
        {
            Items.Remove(item);
        }
    }
}
