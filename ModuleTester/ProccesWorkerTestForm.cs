using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleTester
{
    public partial class ProccesWorkerTestForm : Form
    {
        public ProccesWorkerTestForm()
        {
            InitializeComponent();
            //By GUI
            //processWorker.WorkerName = "My worker";
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            processWorker.RunWorker(MyTestMethod);
        }

        public void MyTestMethod(DoWorkEventArgs e)
        {
            Thread.Sleep(1500);
            e.Result = "BAF!";
            //e.Cancel = true;
        }

    }
}
