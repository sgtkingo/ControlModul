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

using ControlModul.Handlers.Loger;

namespace ControlModul.Handlers.Error
{
    /// <summary>
    /// Useful modul-like form that show Exception error in user friendly format
    /// </summary>
    /// <remarks>
    /// Allow show any Exception in GUI format
    /// 
    /// - Allow report exception
    /// - Run in background
    /// </remarks>
    public partial class ErrorMessager : Form
    {
        Exception Error;

        public ErrorMessager(Exception error)
        {
            InitializeComponent();
            Error = error;
        }

        private void ErrorMessager_Load(object sender, EventArgs e)
        {
            SetForm();
            SetEvents();
        }

        private void SetForm()
        {
            this.Text = "Error: "+Error.Message;
            propertyGrid_Error.SelectedObject = Error;
            rtxt_ErrorDescription.Text = $"{Error.Message} (Source: {Error.Source})";
        }

        #region Mail
        private void ReportAsEmail(Exception error)
        {
            if(Loger.Loger.SendSupportEmail(error))
            {
                MessageBox.Show($"Log file sended to support email: {Loger.Loger.SupportEmail}", "Log send", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Log file sending FAILED! Please, contact your support...", "Logging FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReportAsEmail(Error);
        }

        #endregion
        #region Events
        private void SetEvents()
        {
            btn_Copy.Click += ButtonCopyEfectEvent;
            btn_Send.Click += ButtonCopyEfectEvent;
        }

        private async void ButtonCopyEfectEvent(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var originColor = button.BackColor;

            button.BackColor = Color.LightBlue;
            await Task.Run(() => {
                Thread.Sleep(1000);
            });
            button.BackColor = originColor;
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            var errorDescription = $"{rtxt_ErrorDescription.Text} [{Error.ToString()}]";
            Clipboard.SetText(errorDescription);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
