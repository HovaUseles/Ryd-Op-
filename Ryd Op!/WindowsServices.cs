using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIApp
{
    class WindowsServices
    {
        private Storage storage = new Storage();
        private ManagementObjectCollection services;

        public WindowsServices()
        {
            // Default constructor
        }

        #region List all services
        public ManagementObjectCollection ListAllServices()
        {
            services = storage.GetCollection("select * from Win32_Service");

            return services;
        } 
        #endregion
    }
}
