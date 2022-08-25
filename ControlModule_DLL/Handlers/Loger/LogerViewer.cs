using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ControlModul.Handlers.Reporter;

namespace ControlModul.Handlers.Loger
{
    public partial class LogerViewer : Form
    {
        int lastFindedIndex = 0;

        public LogerViewer()
        {
            InitializeComponent();
        }

        private void LogerViewer_Load(object sender, EventArgs e)
        {
            Init();
            buttonExBackup.Enabled = LogerManager.HasValidExternalBackupSet;
        }

        private void Init()
        {
            try
            {
                checkedListBoxReports.Items.Clear();
                richTextBoxReport.Clear();
                var reports = LogerManager.Load();

                foreach (var report in reports)
                {
                    var filename = Path.GetFileName(report.Source as string);
                    checkedListBoxReports.Items.Add(filename);
                }
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }

        }

        private Report GetSelectedReport()
        {
            try
            {
                var item = checkedListBoxReports.SelectedItem as string;
                return LogerManager.Reports.First((r) => { return Path.GetFileName(r.Source as string) == item; });
            }
            catch (Exception ex)
            { 
                Loger.Log(ex);
                return null;
            }
        }

        private List<Report> GetCheckedReports()
        {
            var list = new List<Report>();
            try
            {
                foreach (string item in checkedListBoxReports.CheckedItems)
                {
                    var report = LogerManager.Reports.First((r) => { return Path.GetFileName(r.Source as string) == item; });
                    list.Add(report);
                }
            }
            catch (Exception ex)
            {
                Loger.Log(ex);
            }
            return list;
        }

        private void checkedListBoxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            var report = GetSelectedReport();
            if (report == null)
                return;

            richTextBoxReport.Text = $"{report.Source}\n{report.Message}";
            //Reset search
            lastFindedIndex = 0;

            //Set highlights
            if(checkBoxExceptions.Checked)
                FindAllAndHighling("Severity=\"Exception\"", Color.Red);
            if (checkBoxErrors.Checked)
                FindAllAndHighling("Severity=\"Error\"", Color.Orange);
            if (checkBoxWarnings.Checked)
                FindAllAndHighling("Severity=\"Warning\"", Color.Yellow);
            if (checkBoxInfo.Checked)
                FindAllAndHighling("Severity=\"Info\"", Color.LightBlue);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var reports = GetCheckedReports();
                foreach (var report in reports)
                {
                    LogerManager.Delete(report);
                }
                Init();

                Loger.Info("Reports deletion complete!", true);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        private void buttonBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                var reports = GetCheckedReports();
                foreach (var report in reports)
                {
                    LogerManager.Backup(report);
                }

                Loger.Info("Reports backup done!", true);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        private void buttonExBackup_Click(object sender, EventArgs e)
        {
            try
            {
                var reports = GetCheckedReports();
                foreach (var report in reports)
                {
                    LogerManager.ExBackup(report);
                }

                Loger.Info("Reports backup done!", true);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxReports.Items.Count; i++)
            {
                checkedListBoxReports.SetItemChecked(i, checkBoxAll.Checked);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text;
            FindAndHighling(searchText, Color.Green);
        }

        private void FindAndHighling(string searchText, Color color)
        {
            //Autoreset
            if (lastFindedIndex < 0)
                lastFindedIndex = 0;

            lastFindedIndex = richTextBoxReport.Find(searchText, lastFindedIndex + searchText.Length, RichTextBoxFinds.MatchCase);
            HighlightSelection(lastFindedIndex, searchText.Length, color);
        }

        private void FindAllAndHighling(string searchText, Color color)
        {
            int tmpIndex = -1;
            lastFindedIndex = 0;

            while (tmpIndex != lastFindedIndex)
            {
                tmpIndex = lastFindedIndex;
                FindAndHighling(searchText, color);
                if( lastFindedIndex == -1 )
                {
                    break;
                }
            }
        }

        private void HighlightSelection(int start, int lenght, Color color)
        {
            if (start < 0 || start + lenght > richTextBoxReport.Text.Length)
                return;

            richTextBoxReport.SelectionBackColor = Color.Transparent;
            richTextBoxReport.Select(start, lenght);
            richTextBoxReport.SelectionBackColor = color;

            richTextBoxReport.ScrollToCaret();
        }
    }
}
