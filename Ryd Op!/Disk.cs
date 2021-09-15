using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;


namespace WMIApp
{
    class Disk
    {
        private Storage storage = new Storage();
        private string[] bootDevice;
        private string[,] diskMeta;
        private string diskSerial;

        public Disk()
        {
            // default constructor
        }

        #region Get Boot Device
        public string[] BootDevice()
        {

            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = storage.GetCollection("SELECT * FROM Win32_OperatingSystem");
            int i = 0;
            bootDevice = new string[queryCollection.Count];
            //enumerate the collection.
            foreach (ManagementObject obj in queryCollection)
            {
                // access properties of the WMI object
                bootDevice[i] = obj["BootDevice"].ToString();
                i++;

            }
            return bootDevice;
        }
        #endregion

        #region Disk Meta data
        public string[,] GetDiskMetadata()
        {
            ManagementObjectCollection managementObjectCollection = storage.GetCollection("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
            int i = 0;
            diskMeta = new string[managementObjectCollection.Count, 3];
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                diskMeta[i, 0] = managementObject["Name"].ToString();
                diskMeta[i, 1] = (Convert.ToInt64(managementObject["FreeSpace"]) / (1024 * 1024 * 1024)).ToString();
                diskMeta[i, 2] = (Convert.ToInt64(managementObject["Size"]) / (1024 * 1024 * 1024)).ToString();
                i++;

            }
            return diskMeta;
        }
        #endregion

        #region Get Disk serial number
        public string GetHardDiskSerialNumber(string drive = "C")

        {
            // Displays the C drive serial number
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");

            managementObject.Get();

            diskSerial = managementObject["VolumeSerialNumber"].ToString();

            return diskSerial;
        } 
        #endregion
    }
}
