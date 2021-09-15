using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIApp
{
    class User
    {
        private string[,] userStatistics;
        private Storage storage = new Storage();

        #region Get user info
        public string[,] GetUserInfo()
        {
            ManagementObjectCollection collection = storage.GetCollectionNoScope("SELECT * FROM Win32_OperatingSystem");

            // Displaying User, organization and OS information
            userStatistics = new string[collection.Count, 3];
            int i = 0;
            foreach (ManagementObject obj in collection)
            {
                Console.WriteLine(obj["RegisteredUser"]);
                userStatistics[i, 0] = Convert.ToString(obj["RegisteredUser"]);
                userStatistics[i, 0] = (string)obj["RegisteredUser"];
                userStatistics[i, 1] = Convert.ToString(obj["Organization"]);
                userStatistics[i, 2] = Convert.ToString(obj["Name"]);
                i++;
            }
            return userStatistics;
        } 
        #endregion

    }
}
