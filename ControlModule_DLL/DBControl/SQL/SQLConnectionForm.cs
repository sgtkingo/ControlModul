using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlModul.DBControl.SQL
{
    /// <summary>
    /// Useful modul-like form that allow user to easy build and test SQL database connection
    /// </summary>
    /// <remarks>
    /// Easy connect to any SQL DB, simple GUI enviroment  
    /// 
    /// - Auto database servers and databases explorer
    /// - Auto-test mode 
    /// - Possibility to use Trusted Connection (auto/manual username set)
    /// - Possibility to use Direct Link (raw Connection String)
    /// </remarks>
    public partial class SQLConnectionForm : Form
    {
        #region Local Properities
        private bool UseDirectLink { get; set; }
        private bool UseTrustedConnection { get; set; }

        public SQLConnector SQLConnector { get; private set; }

        private bool AutoTestMode;
        #endregion

        #region Status
        private string Status 
        {
            get 
            {
                return l_status.Text;
            }
            set 
            {
                l_status.Text = "Status: "+value;
            }
        }

        private string ActualConnectionString
        {
            get
            {
                return txt_ConnectionString.Text;
            }
            set
            {
                txt_ConnectionString.Text = value;
            }
        }
        #endregion

        #region Constructor and Inicializators
        public SQLConnectionForm(string connectionString = null, bool autoTestMode = false)
        {
            InitializeComponent();

            BindConnectioString(connectionString);
            AutoTestMode = autoTestMode;
        }

        private void SQLConnectionFom_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void BindConnectioString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                return;

            ActualConnectionString = connectionString;
        }

        private void InitForm()
        {
            cbox_DatabaseList.Enabled = false;
            cbox_ServerList.Enabled = false;

            checkBox_TrustedConnection.Checked = true;
            gbox_DirectConnectionString.Enabled = false;

            if( AutoTestMode )
            {
                AutoTestConnectionAsync();
            }
            else ReloadServers();
        }
        #endregion

        #region Explorers
        private async void ReloadServers()
        {
            Status = $"Searching SQL servers...";
            cbox_ServerList.Items.Clear();
            cbox_ServerList.Enabled = false;
            cbox_DatabaseList.Items.Clear();
            cbox_DatabaseList.Enabled = false;

            DataTable table = null;
            try
            {
                await Task.Run(() =>
                {
                    table = DatabaseManager.GetLocalServerIntances();
                });

                foreach (DataRow row in table.Rows)
                {
                    string server = Environment.MachineName + "\\" + row["InstanceName"].ToString();
                    cbox_ServerList.Items.Add(server);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
            }

            cbox_ServerList.Enabled = true;
            Status = $"Idle";
        }

        private async void ReloadDatabases(string serverName)
        {
            Status = $"Searching SQL databases...";
            cbox_DatabaseList.Items.Clear();
            cbox_DatabaseList.Enabled = false;
            DataTable table = new DataTable();

            try
            {
                await Task.Run(() =>
                {
                    table = DatabaseManager.GetServerDatabases(serverName);
                });
                foreach (DataRow row in table.Rows)
                {
                    string database = row["database_name"].ToString();
                    cbox_DatabaseList.Items.Add(database);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
            }

            cbox_DatabaseList.Enabled = true;
            Status = $"Idle";
        }
        private void cbox_ServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (string)cbox_ServerList.SelectedItem;
            if (item == null) {
                return;
            };

            ReloadDatabases(item);
        }
        #endregion

        #region Vizualizators
        private async Task SetColorToForm(Color color, int timeout = 1000)
        {
            Color originColor = this.BackColor;
            this.BackColor = color;

            await Task.Run(() => {
                Thread.Sleep(timeout);
            });
            this.BackColor = originColor;
        }

        private void VizualizeResult(TestState state)
        {
            switch (state)
            {
                case TestState.OK:
                    SetColorToForm(Color.LightGreen);
                    break;
                case TestState.FAIL:
                    SetColorToForm(Color.Red, 2000);
                    break;
                case TestState.NOT_TESTED:
                    SetColorToForm(Color.Yellow, 2000);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Testers and Connectors
        private string BuildConnectionString()
        {
            string connectionString = string.Empty;
            //Direct Link
            if( UseDirectLink )
            {
                connectionString = txt_ConnectionString.Text;
            }
            //Normal 
            else
            {
                if (cbox_DatabaseList.SelectedItem == null || cbox_ServerList.SelectedItem == null)
                {
                    MessageBox.Show("Choose Server and Database, please!", "Wrong setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                try
                {
                    string serverName = cbox_ServerList.SelectedItem.ToString();
                    string databaseName = cbox_DatabaseList.SelectedItem.ToString();

                    //Trusted connection
                    if ( UseTrustedConnection )
                        connectionString = ConnectionStringBuilder.BuildConnectionString_Trusted(serverName, databaseName, txt_Username.Text);
                    else
                        connectionString = ConnectionStringBuilder.BuildConnectionString_Std(serverName, databaseName, txt_Username.Text, txt_Password.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");
                    connectionString = string.Empty;
                }
            }
            //Save as actual
            ActualConnectionString = connectionString;

            return connectionString;
        }
        private async void AutoTestConnectionAsync()
        {
            //If AutoTest then hide this windows
            this.Visible = false;
            await WaitToTesting(ActualConnectionString);
            CheckAndClose();
        }

        private async Task WaitToTesting(string connectionString)
        {
            btn_Test.Enabled = false;
            btn_OK.Enabled = false;

            Status = "Testing connection...";
            try
            {
                SQLConnector = SQLConnector.BuildConnector(connectionString);
                SQLConnector.Connection.InfoMessage += UpdateStatusEventHandler;
                await SQLConnector.TestConnectionAsync();

                Status = SQLConnector.LastTestMessage;
                VizualizeResult(SQLConnector.LastTestResult);
            }
            catch (Exception ex)
            {
                SQLConnector = null;
                Console.WriteLine($"\t(!) {this}: Problem: {ex.Message} | {ex.Source} ");

                Status = ex.Message;
                VizualizeResult(TestState.FAIL);
            }

            btn_Test.Enabled = true;
            btn_OK.Enabled = true;
        }
        #endregion

        #region Form Events
        private void CheckAndClose()
        {
            if (SQLConnector != null)
            {
                if (SQLConnector.LastTestResult == TestState.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                //If error occours, show window
                this.Visible = true;
                btn_Reload.Focus();
                MessageBox.Show("Settings doesnt working...", "Bad settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_OK_Click(object sender, EventArgs e)
        {
            string connectionString = BuildConnectionString();
            await WaitToTesting(connectionString);

            CheckAndClose();
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            string connectionString = BuildConnectionString();
            WaitToTesting(connectionString);
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ReloadServers();
        }

        private void UpdateStatusEventHandler(object sender, EventArgs e)
        {
            Status = $"{SQLConnector.InfoMessage}";
        }

        private void checkBox_TrustedConnection_CheckedChanged(object sender, EventArgs e)
        {
            gbox_Login.Enabled = !checkBox_TrustedConnection.Checked;
            if( checkBox_TrustedConnection.Checked)
            {
                txt_Username.Text = Environment.MachineName+"\\"+Environment.UserName;
            }
            UseTrustedConnection = checkBox_TrustedConnection.Checked;
        }

        private void checkBox_UseDirectLink_CheckedChanged(object sender, EventArgs e)
        {
            gbox_DirectConnectionString.Enabled = checkBox_UseDirectLink.Checked;
            gbox_ServersAndDatabases.Enabled = !checkBox_UseDirectLink.Checked;
            UseDirectLink = checkBox_UseDirectLink.Checked;
        }

        private void txt_ConnectionString_TextChanged(object sender, EventArgs e)
        {
            //Check connection string format?
        }

        private void SQLConnectionFom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if( SQLConnector != null && SQLConnector.LastTestResult == TestState.OK)
            {
                DialogResult = DialogResult.OK;
                SQLConnector.Disconnect();
            }
            else
            {
                if (MessageBox.Show("Your connection was not establishment yet, closing this dialog can cause application error! \nContinue anyway?", "Not tested", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            txt_ConnectionString.UseSystemPasswordChar = !txt_ConnectionString.UseSystemPasswordChar;
        }
    }
}
