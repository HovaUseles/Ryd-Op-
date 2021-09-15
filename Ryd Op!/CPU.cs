using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIApp
{
    class CPU
    {
        private string[,] cpuStatistics;
        private Storage storage = new Storage();

        public CPU()
        {
          
        }

        #region Get CPU Core Usage
        public string[,] GetCoreUsage()
        {
            ManagementObjectCollection collection = storage.GetCollection("SELECT * from Win32_PerfFormattedData_PerfOS_Processor");

            // Displays CPU logical threads and the load on each
            int logicProccesses = collection.Count;
            cpuStatistics = new string[logicProccesses, 2];
            int i = 0;
            foreach (ManagementObject obj in collection)
            {
                cpuStatistics[i, 0] = Convert.ToString(obj["Name"]);
                cpuStatistics[i, 1] = Convert.ToString(obj["PercentProcessorTime"]);
                i++;
            }
            return cpuStatistics;
        } 
        #endregion
    }
}
