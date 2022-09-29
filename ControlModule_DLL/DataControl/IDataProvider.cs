using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlModul.DataControl
{
    public interface IDataProvider
    {
        /// <summary>
        /// Method for binding object as source .
        /// </summary>
        /// <param name="data">
        /// Support list, table or other data sources.
        /// </param>
        void InjectData(object data);

        /// <summary>
        /// Method for binding file as source .
        /// </summary>
        /// <param name="filePath">
        /// Path to source file, suppport Excel, text and other common file formats.
        /// </param>
        void InjectFile(string filePath);

        /// <summary>
        /// Method for binding source by delegate function.
        /// </summary>
        /// <param name="providerFunction">
        /// MUST return bindable data, support list, table or other data sources.
        /// </param>
        void InjectDataProviderFunction(Func<object> providerFunction);

        object GetData();
    }
}
