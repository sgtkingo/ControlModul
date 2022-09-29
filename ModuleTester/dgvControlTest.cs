using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleTester
{
    public partial class dgvControlTest : Form
    {
        public dgvControlTest()
        {
            InitializeComponent();
        }

        private void dgvControlTest_Load(object sender, EventArgs e)
        {
            //var source = new List<Foo> { new Foo() { MyProperty = 1 }, new Foo() { MyProperty = 2 }, new Foo() { MyProperty = 3 } };
            //dataGridViewerControl1.DataSource = source;
            dataGridViewerControl1.BindSources(GetData);
        }

        public static List<Foo> GetData()
        {
            return new List<Foo> { new Foo() { ID = 1, MyProperty="A" }, new Foo() { ID = 2, MyProperty = "B" }, new Foo() { ID = 3, MyProperty = "C" } };
        }
    }
}
