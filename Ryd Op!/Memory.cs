using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIApp
{
    class Memory
    {
        private Storage storage = new Storage();
        private string[] memoryInfo;

        public Memory()
        {
            // Default Constructor
        }

        #region Get memory info
        public string[] GetMemoryInfo()
        {
  
            ManagementObjectCollection results = storage.GetCollection("SELECT * FROM Win32_OperatingSystem");
            memoryInfo = new string[4];
            foreach (ManagementObject obj in results)
            {
                memoryInfo[0] = obj["TotalVisibleMemorySize"].ToString();
                memoryInfo[1] = obj["FreePhysicalMemory"].ToString();
                memoryInfo[2] = obj["TotalVirtualMemorySize"].ToString();
                memoryInfo[3] = obj["FreeVirtualMemory"].ToString();
            }

            return memoryInfo;
        }
        #endregion
    }
}
