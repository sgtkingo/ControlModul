using ControlModul.DBControl.SQL;
using ControlModul.FileControl;
using ControlModul.Handlers.Loger;
using ControlModul.Handlers.Reporter;
using ControlModul.Security;
using ControlModul.Tools;

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
using System.Configuration;

namespace ModuleTester
{
    public partial class TesterForm : Form
    {
        public TesterForm()
        {
            InitializeComponent();
        }

        private void TesterForm_Load(object sender, EventArgs e)
        {
            LogerManager.Init(@"./log");
            Console.WriteLine($"\t(i) {this}: Tester ready! >P");
        }

        #region Buttons click events
        private void btn_TestAll_Click(object sender, EventArgs e)
        {
            TestAll();
        }

        private void btn_TestSQLConnector_Click(object sender, EventArgs e)
        {
            TestSQLConnector(@"Data Source=NTB-DELL-LATIDU\SQLEXPRESS;Initial Catalog=betotech_is_test;Integrated Security=True");
        }
        private void btn_TestErrorLog_Click(object sender, EventArgs e)
        {
            Exception exception = null;
            try
            {
                try
                {
                    try
                    {
                        int[] arr = new int[1];
                        arr[2] = 5;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        throw ex;
                    }
                }
                catch (ApplicationException ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            TestErrorMessager(exception);
        }

        private void btn_TestSQLStatuser_Click(object sender, EventArgs e)
        {
            TestSQLStatuser(@"Data Source=NTB-DELL-LATIDU\SQLEXPRESS;Initial Catalog=betotech_is;Integrated Security=True");
        }

        private void button_TestProcessWorker_Click(object sender, EventArgs e)
        {
            var form = new ProccesWorkerTestForm();
            form.ShowDialog();
        }

        private void btn_TestLogger_Click(object sender, EventArgs e)
        {
            TestLogger();
        }

        private void btn_TestLogerManager_Click(object sender, EventArgs e)
        {
            TestLogerManager();
        }

        private void btn_TestReporter_Click(object sender, EventArgs e)
        {
            TestReporter();
        }

        private void buttonTestCrypto_Click(object sender, EventArgs e)
        {
            TestSymetricCryptographer("Crytograph Test!");
        }
        #endregion

        #region Test Methods
        private void TestAll()
        {
            try
            {
                //Code here
                string filePath = @"../../../sources/test.txt";

                VirtualFile virtualFile = new VirtualFile(filePath);
                virtualFile.AddData(DateTime.Now.ToString("f"));
                virtualFile.AddData("Baf", true);
                virtualFile.SaveFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
            }

            try
            {
                //Code here
                string filePath = @"../../../sources/test.txt";
                string data = FileManager.LoadFile(filePath);
                Console.WriteLine(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
            }

            try
            {
                var res_BadFormat= DatabaseManager.FastTestConnectionString("ggg");
                Console.WriteLine($"{nameof(res_BadFormat)}:{res_BadFormat}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
            }

            try
            {
                var res_Empty = DatabaseManager.FastTestConnectionString("");
                Console.WriteLine($"{nameof(res_Empty)}:{res_Empty}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
            }

            try
            {
                var res_BadConnection = DatabaseManager.FastTestConnectionString(@"Data Source=NTB-DELL-LATIDU\SQLEXPRESS;Initial Catalog=BLABLABLA;Integrated Security=True");
                Console.WriteLine($"{nameof(res_BadConnection)}:{res_BadConnection}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
            }

            try
            {
                var res_GoodConnection = DatabaseManager.FastTestConnectionString(@"Data Source=NTB-DELL-LATIDU\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
                Console.WriteLine($"{nameof(res_GoodConnection)}:{res_GoodConnection}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
            }
        }
        private void TestSQLConnector(string param = null)
        {
            try
            {
                //autotest
                //var form = new SQLConnectionFom(param, true);

                var form = new SQLConnectionForm(param);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
            }
        }

        private void TestSQLStatuser(string connectionString)
        {
            try
            {
                var form = new SQLStatuserForm(connectionString);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
            }
        }

        private void TestErrorMessager(Exception exception)
        {
            string email = ConfigurationSettings.AppSettings.Get("supportEmail") ?? "NA";
            string pass = ConfigurationSettings.AppSettings.Get("supportEmailPswd") ?? "NA";
            string host = "smtp.gmail.com";
            Loger.SetSupportEmail(email,pass,host);
            Loger.LogAndVisualize(exception);
        }


        private void TestLogger()
        {
            Loger.Info("Baf!", true);
            Loger.Error("Baf!", true);
            Loger.Warning("Baf!", true);
            Loger.Log(new Exception());
            Loger.Info("Baf!2");
            Loger.Error("Baf!2");
            Loger.Warning("Baf!2");
        }

        private void TestLogerManager()
        {
            /*
            foreach (var report in LogerManager.Load())
            {
                Debug.WriteLine(report);
            }
            */
            //LogerManager.DoBackup();
            //LogerManager.Maintanance();

            var form = new LogerViewer();
            form.ShowDialog(this);
        }

        private void TestReporter()
        {
            ReportForm.CreateReporter(this);
            var report = new Report(this, "Hello");
            ReportManager.LogReport(report);
        }

        private void TestSymetricCryptographer(string message)
        {
            try
            {
                var aes = new SymetricCryptographer();
                var c_as_bytes = aes.EncryptStringToBytes_Aes(message);
                var d_as_string = aes.DecryptStringFromBytes_Aes(c_as_bytes);

                Debug.WriteLine($"Original Message: {message}");
                Debug.WriteLine($"Crypted Message: {Convertor.BytesToString(c_as_bytes)}");
                Debug.WriteLine($"Decrypted Message: {d_as_string}");

                var hashMessage = Hasher.StringToHashString(message);
                Debug.WriteLine($"Hash Message: {hashMessage}");

                var base64Message = ControlModul.Tools.Encoder.Base64FromString(message);
                Debug.WriteLine($"BASE64 Message: {base64Message}");
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }
        #endregion
    }
}
