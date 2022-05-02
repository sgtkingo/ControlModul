using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ControlModul.Handlers.Loger;

namespace ControlModul.DBControl.SQL
{
    /// <summary>
    /// Useful modul-like form that allow user to easy auto-test SQL database connection
    /// </summary>
    /// <remarks>
    /// Easy auto-test SQL database connection with GUI
    /// 
    /// - Connection String is required!
    /// - Run in background
    /// </remarks>
    public partial class SQLStatuserForm : Form
    {
        SQLConnector SQLConnector;
        string ConnectionString;
        public SQLStatuserForm(string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
        }

        private void SQLStatuser_Load(object sender, EventArgs e)
        {
            processWorkerConnector.BackgroundWorker.RunWorkerCompleted += GetResult;
            processWorkerConnector.RunWorker(RunMethod);
        }

        private void SetStatus(TestState testState)
        {
            if (testState == TestState.OK)
            {
                this.BackColor = Color.LightGreen;
                pictureBoxResult.BackgroundImage = ControlModul.Properties.Resources.plug_connect_icon;
            }
            else
            {
                this.BackColor = Color.Yellow;
                pictureBoxResult.BackgroundImage = ControlModul.Properties.Resources.plug_disconnect_prohibition_icon;
                Loger.Error(SQLConnector.ErrorMessage, true);
            }
        }

        private void RunMethod(DoWorkEventArgs args)
        {
            try
            {
                SQLConnector = SQLConnector.BuildConnector(ConnectionString);

                pictureBoxResult.BackgroundImage = ControlModul.Properties.Resources.plug_arrow_icon;
                SQLConnector.TestConnection();
                args.Cancel = (SQLConnector.LastTestResult != TestState.OK);
            }
            catch (Exception e)
            {
                Loger.LogAndVisualize(e);
            }
        }

        private void GetResult(object sender, RunWorkerCompletedEventArgs e)
        {
            labelStatus.Text = SQLConnector.LastTestMessage;
            labelDatabaseName.Text = $"{SQLConnector.ServerAddress}/{SQLConnector.DatabaseName}";
            SetStatus(SQLConnector.LastTestResult);
        }

        private void buttonRepeat_Click(object sender, EventArgs e)
        {
            processWorkerConnector.StopWorker();
            processWorkerConnector.RunWorker(RunMethod);
        }

        private void SQLStatuserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            processWorkerConnector.StopWorker();
        }
    }
}
