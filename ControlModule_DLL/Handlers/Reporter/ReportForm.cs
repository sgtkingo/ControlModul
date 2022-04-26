using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlModul.Handlers.Reporter
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            SetEvents();
            SetForm();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            BindSources();
        }

        private void BindSources()
        {
            reportsBindingSource.DataSource = ReportManager.Items;
        }

        private void SetEvents()
        {
            ReportManager.LogReportedEvent += (rep) => { reportsBindingSource.ResetBindings(true); };
        }

        private void SetForm()
        {
            //Default: Right corner location
            int X = Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width;
            int Y = Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height;
            this.Location = new Point(X, Y);
        }

        public static ReportForm CreateReporter(Form parentForm = null)
        {
            var form = new ReportForm();

            if (parentForm != null)
                form.Show(parentForm);
            else
                form.Show();

            return form;
        }
    }
}
