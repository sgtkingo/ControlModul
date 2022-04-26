using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControlModul.Templates;
using ControlModul.Handlers.Loger;

namespace ControlModul.Handlers.Reporter
{
    public class ReportManager : AbstractManager<Report>
    {
        //TODO: Add some methods here
        public delegate void LogReportHandler(Report report);
        public static event LogReportHandler LogReportedEvent;

        public static void LogReport(Report report, bool logReport = true)
        {
            if (report == null)
                return;

            try
            {
                Add(report);

                if( logReport )
                    Loger.Loger.Log(report.ToString());

                //Call event
                LogReportedEvent.Invoke(report);
            }
            catch (Exception ex)
            {
                Loger.Loger.Log(ex);
            }
        }
    }
}
