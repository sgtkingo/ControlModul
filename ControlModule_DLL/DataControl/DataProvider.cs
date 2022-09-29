using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlModul.DataControl
{
    public class DataProvider : IDataProvider
    {
        public object Data { get; private set; }
        private Func<object> _providerFunction;

        //Constructors
        protected DataProvider(object data) 
        {
            InjectData(data);
        }

        protected DataProvider(string filePath)
        {
            InjectFile(filePath);
        }

        protected DataProvider(Func<object> providerFunction)
        {
            InjectDataProviderFunction(providerFunction);
        }

        //Creators
        public static DataProvider Create(object dataSource) 
        {
            if( dataSource.GetType() == typeof(string))
            {
                return new DataProvider(dataSource as string);
            }
            return new DataProvider(dataSource);
        }

        public static DataProvider Create(Func<object> providerFunction)
        {
            return new DataProvider(providerFunction);
        }

        //Injection methods
        public void InjectData(object data)
        {
            Data = data;
        }

        public void InjectFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public void InjectDataProviderFunction(Func<object> providerFunction)
        {
            _providerFunction = providerFunction;
        }

        public object GetData()
        {
            if( _providerFunction != null )
            {
                return Data = _providerFunction.Invoke();
            }
            else
            {
                return Data;
            }
        }
    }
}
