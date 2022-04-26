namespace ControlModul.DBControl.ExcelConnectorOLE
{
    /// <summary>
    /// Simple class that can build custom Excel Connection String
    /// </summary>
    /// <remarks>
    /// Easy build custom Excel Connection String with auto-defined default values
    /// - Using Microsoft ACE OLEDB 12.0! (can be changed programally)
    /// </remarks>
    public class ExcelConnectionString
    {
        public string  Provider{ get; set; }
        public string  Data_Source{ get; set; }
        public string  Extended_Properties{ get; set; }
        public string  HDR{ get; set; }
        public string  IMEX{ get; set; }

        public ExcelConnectionString(){ this.DefaultValues(); }

        public override string ToString()
        {
            return $"Provider={this.Provider};Data Source={this.Data_Source};Extended Properties='{this.Extended_Properties};HDR={this.HDR};'{this.IMEX};";
        }

        public void DefaultValues(){ 
            this.Provider = "Microsoft.ACE.OLEDB.12.0";
            this.Data_Source = "";
            this.Extended_Properties = "Excel 12.0 XML";
            this.HDR = "YES";
            this.IMEX = "";
        }
    }
}
