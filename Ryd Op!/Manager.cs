using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIApp
{
    class Manager
    {

        #region CPU info
        public string[,] CPUInfo()
        {
            CPU processor = new CPU();
            return processor.GetCoreUsage();
        }
        #endregion


        #region User Info
        public string[,] UserInfoTest()
        {
            User pcUser = new User();
            return pcUser.GetUserInfo();

        }
        #endregion


        #region Disk info
        public void DiskInfo(out string[] bootDevice, out string[,] diskMeta, out string diskSerial)
        {
            Disk disk = new Disk();
            bootDevice = disk.BootDevice();
            diskMeta = disk.GetDiskMetadata();
            diskSerial = disk.GetHardDiskSerialNumber();
        }
        #endregion


        #region Memory Info
        public string[] GetMemoryInfo()
        {
            Memory memory = new Memory();
            string[] memInfo = memory.GetMemoryInfo();
            return memInfo;
        }
        #endregion


        #region List of all services
        public ManagementObjectCollection ListAllServices()
        {
            WindowsServices winServices = new WindowsServices();
            return winServices.ListAllServices();
        }

        #endregion
    }
}

