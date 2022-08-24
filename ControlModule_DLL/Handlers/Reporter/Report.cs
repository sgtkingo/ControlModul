using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ControlModul.Handlers.Reporter
{
    public class Report
    {
        [DisplayName("Date & Time")]
        public DateTime CreateDate { get; private set; } = DateTime.Now;

        public string Message { get; private set; } = String.Empty;

        public object Source { get; private set; }

        public Report(object source) : base()
        {
            Source = source;
        }

        public Report(object source, string message) : base()
        {
            Message = message;
            Source = source;
        }

        public Report(object source, string message, DateTime date) : base()
        {
            Message = message;
            Source = source;
            CreateDate = date;
        }

        public void AppendMessage(string text)
        {
            Message = text;
        }

        public void AppendException(Exception exception)
        {
            Message = $"Exception occours! {exception.Message}|({exception.Source})";
        }

        public override string ToString()
        {
            return $"{Message}({Source}) [{CreateDate}]";
        }
    }
}
