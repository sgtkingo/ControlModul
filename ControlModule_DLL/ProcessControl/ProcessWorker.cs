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

namespace ControlModul.ProcessControl
{
    public enum ProccessStatus
    {
        Ready = 0,
        Running = 1,
        Done = 100,
        Canceled = 400
    }

    /// <summary>
    /// Async worker with GUI
    /// </summary>
    public partial class ProcessWorker : UserControl
    {
        const int SHORT_TIME = 1000;
        const int LONG_TIME = 2500;

        [DisplayName("WorkerTaskCompleted"), Category("Events"), Description("Call everytime when backgroud worker completed the routine.")]
        public event RunWorkerCompletedEventHandler WorkerCompleted;

        [DisplayName("Status"), Category("Parameters")]
        public ProccessStatus WorkerStatus { get; private set; }

        [Category("Hide")]
        public object Result { get; private set; }
        [Category("Hide")]
        public Exception Error { get; private set; }

        [DisplayName("Friendly Name"), Category("Parameters")]
        public string WorkerName
        {
            get
            {
                return l_workerName.Text;
            }
            set
            {
                l_workerName.Text = value;
            }
        }

        public ProcessWorker()
        {
            InitializeComponent();
            InitializeWorkerUnit();
        }

        private void InitializeWorkerUnit()
        {
            this.Result = null;
            this.Error = null;

            WorkerCompleted += WorkerCompletedDefaultMethod;
            SetStatus((int)ProccessStatus.Ready);
        }

        private void SetStatus(ProccessStatus proccessStatus)
        {
            WorkerStatus = proccessStatus;
            switch (WorkerStatus)
            {
                case ProccessStatus.Ready:
                    l_status.Text = "READY!";
                    pictureBox_Progress.Image = ControlModul.Properties.Resources.loading_ready;
                    break;
                case ProccessStatus.Running:
                    l_status.Text = "Running...";
                    pictureBox_Progress.Image = ControlModul.Properties.Resources.loading_classic;
                    break;
                case ProccessStatus.Done:
                    l_status.Text = "Done!";
                    pictureBox_Progress.Image = ControlModul.Properties.Resources.loading_done;
                    break;
                case ProccessStatus.Canceled:
                    l_status.Text = "Canceled...";
                    pictureBox_Progress.Image = ControlModul.Properties.Resources.loading_canceled;
                    break;
                default:
                    l_status.Text = "Unknown...";
                    break;
            }
        }

        private async void ResetStatusTimerAsync(int timeMs = SHORT_TIME)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(timeMs);
            });
            SetStatus(ProccessStatus.Ready);
        }

        public void RunWorker(Action<DoWorkEventArgs> actionMethod, bool WaitToReady = false)
        {
            //Wait to complete ?
            while( BackgroundWorker.IsBusy & WaitToReady );

            if (!BackgroundWorker.IsBusy)
            {
                BackgroundWorker.RunWorkerAsync(actionMethod);
            }
        }

        public void StopWorker()
        {
            BackgroundWorker.CancelAsync();
        }

        private void RunTheMethod(Action<DoWorkEventArgs> methodToRun, DoWorkEventArgs e)
        {
            try
            {
                methodToRun(e);
            }
            catch (Exception ex)
            {

                Loger.LogAndVisualize(ex);
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker.ReportProgress((int)ProccessStatus.Running);
                RunTheMethod((Action<DoWorkEventArgs>)e.Argument, e);
                BackgroundWorker.ReportProgress((int)ProccessStatus.Done);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == (int)ProccessStatus.Running)
            {
                SetStatus(ProccessStatus.Running);
            }
        }

        private void WorkerCompletedDefaultMethod(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                SetStatus(ProccessStatus.Canceled);
                Result = null;

                //Reset status
                ResetStatusTimerAsync(LONG_TIME);
            }
            else
            {
                SetStatus(ProccessStatus.Done);
                Result = e.Result;

                //Reset status
                ResetStatusTimerAsync();
            }
            //Handle error
            Error = e.Error;
            if ( Error != null)
            {
                throw Error;
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                WorkerCompleted.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }
    }
}
