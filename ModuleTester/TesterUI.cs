using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ControlModul.FileControl;
using ControlModul.Handlers.Loger;
using ControlModul.ProcessControl;
using ControlModul.Protocols.FTP;

using FluentFTP;

namespace ModuleTester
{
    public partial class TesterUI : Form
    {
        public TesterUI()
        {
            InitializeComponent();
        }

        private void TesterUI_Load(object sender, EventArgs e)
        {
            InitTester();
        }

        private void InitTester() 
        {
            try
            {
                LogerManager.Init(@"./log");
                Console.WriteLine($"\t(i) {this}: Tester ready! >P");
                Debug.WriteLine($"\t(i) {this}: Tester ready! >P");
            }
            catch (Exception)
            {
                Close();
                Console.WriteLine($"\t(i) {this}: Tester ERROR! >P");
                Debug.WriteLine($"\t(i) {this}: Tester ERROR! >P");
            }
        }

        #region Buttons
        private void buttonTestFTP_Click(object sender, EventArgs e)
        {
            if( TestFTP() )
            {
                Loger.Info($"{((Control)sender).Text} tests run result: OK!", true);
            }
            else
                Loger.Error($"{((Control)sender).Text} tests run result: FAIL!!!", true);
        }

        private void buttonLogerManagerTest_Click(object sender, EventArgs e)
        {
            if (TestLogerManager())
            {
                Loger.Info($"{((Control)sender).Text} tests run result: OK!", true);
            }
            else
                Loger.Error($"{((Control)sender).Text} tests run result: FAIL!!!", true);
        }

        private void buttonLogViewerTest_Click(object sender, EventArgs e)
        {
            if (TestLogerViewer())
            {
                Loger.Info($"{((Control)sender).Text} tests run result: OK!", true);
            }
            else
                Loger.Error($"{((Control)sender).Text} tests run result: FAIL!!!", true);
        }

        private void buttonDataViewControlTest_Click(object sender, EventArgs e)
        {
            if (TestDataViewControl())
            {
                Loger.Info($"{((Control)sender).Text} tests run result: OK!", true);
            }
            else
                Loger.Error($"{((Control)sender).Text} tests run result: FAIL!!!", true);
        }
        #endregion

        #region Tests
        private bool TestFTP() 
        {
            try
            {
                Uri host = new Uri("ftp://127.0.0.1:21");
                FTPManager.SkipCertificateValidation = true;
                var client = FTPManager.CreateClient(host, "test");
                /*
                FtpClient client = new FtpClient(host,"test", "");

                client.DataConnectionEncryption = true;
                client.EncryptionMode = FtpEncryptionMode.Auto;
                client.ValidateAnyCertificate = true;

                client.ValidateCertificate += FTPManager.ValidatingCertificate;
                // connect to the server and automatically detect working FTP settings
                var profile = client.AutoConnect();
                */
                

                foreach (var item in FTPManager.ListDirectory(client))
                {
                    Debug.WriteLine(item);
                }
                if( FTPManager.UploadFile(client, @".\test.txt") == FtpStatus.Success)
                {
                    Loger.Info("File upload success!", true);
                }
                //client.UploadFile(@".\test.txt", @"\test.txt");

                FTPManager.DiscardClient(client);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
                return false;
            }
            return true;
        }

        private bool TestLogerManager()
        {
            try
            {
                LogerManager.Init(@"./log");
                LogerManager.DoBackup();
                LogerManager.Maintanance();
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
                return false;
            }
            return true;
        }

        private bool TestLogerViewer()
        {
            try
            {
                Uri host = new Uri("ftp://127.0.0.1:21/logs");

                LogerManager.SetExternalBackup(host, "test");
                var form = new LogerViewer();
                form.Show(this);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
                return false;
            }
            return true;
        }

        private bool TestDataViewControl()
        {
            try
            {
                var form = new dgvControlTest();
                form.Show(this);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
                return false;
            }
            return true;
        }
        #endregion

    }
}
