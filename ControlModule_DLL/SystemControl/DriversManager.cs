using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

using ControlModul.Handlers.Loger;

namespace ControlModul.SystemControl.Drivers
{
    public static class DriversManager
    {
        public static bool CheckDriver(string searchFor, string property = "DeviceName", string scope = "Win32_PnPSignedDriver")
        {
            Loger.Log("Searching for driver...");
            try
            {
                SelectQuery query = new SelectQuery(scope);
                query.Condition = $"{property} = '{searchFor}'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                var drivers = searcher.Get();

                return drivers.Count > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool CheckDriver(string condition, string scope = "Win32_PnPSignedDriver")
        {
            Loger.Log("Searching for driver...");
            try
            {
                SelectQuery query = new SelectQuery(scope);
                query.Condition = condition;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                var drivers = searcher.Get();

                return drivers.Count > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ListDrivers(string scope = "Win32_PnPSignedDriver")
        {
            Loger.Log("Listing drivers...");
            try
            {
                SelectQuery query = new SelectQuery(scope);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                var drivers = searcher.Get();
                foreach (var driver in drivers)
                {
                    foreach (var property in driver.Properties)
                    {
                        Console.WriteLine($"{property.Name} = {property.Value}"); 
                    }
                    Console.WriteLine("---------------------------------------------");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
