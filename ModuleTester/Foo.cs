using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTester
{
    [Serializable]
    public class Foo
    {
        public int ID { get; set; }
        public string MyProperty { get; set; }

        public override string ToString()
        {
            return $"{ID} {MyProperty}";
        }
    }
}
