using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            #region CPUinfo
            Console.WriteLine("Press any key to display CPU info");
            Console.ReadKey();
            string[,] cpuUse = manager.CPUInfo();
            for (int i = 0; i < cpuUse.GetLength(0); i++)
            {
                Console.WriteLine("CPU {0} : {1}", cpuUse[i, 0], cpuUse[i, 1]);
            }
            Console.WriteLine("---------------------------------------------------");
            #endregion

            #region User Info
            Console.WriteLine("Press any key to display User info");
            Console.ReadKey();
            string[,] userInfo = manager.UserInfoTest();
            for (int i = 0; i < userInfo.GetLength(0); i++)
            {
                Console.WriteLine("User:\t{0}", userInfo[i, 0]);
                Console.WriteLine("Org.:\t{0}", userInfo[i, 1]);
                Console.WriteLine("O/S :\t{0}", userInfo[i, 2]);
            }
            Console.WriteLine("---------------------------------------------------");
            #endregion

            #region Get disk info
            string[] bootDevice;
            string[,] diskMeta;
            string diskSerial;
            manager.DiskInfo(out bootDevice, out diskMeta, out diskSerial);
            
            Console.WriteLine("Press any key to display Disk info");
            Console.ReadKey();


            // Display Boot Device
            for (int i = 0; i < bootDevice.Length; i++)
            {
                Console.WriteLine("Boot Device : {0}", bootDevice[i]); 
            }
            Console.WriteLine();

            // Display disk meta data
            for (int i = 0; i < diskMeta.GetLength(0); i++)
            {
                Console.WriteLine("Disk Name : {0}", diskMeta[i, 0]);
                Console.WriteLine("FreeSpace: {0}gb", diskMeta[i, 1]);
                Console.WriteLine("Disk Size: {0}gb", diskMeta[i, 2]); 
            }
            Console.WriteLine();

            // Display disk serial number
            Console.WriteLine("Disk Serial number : {0}", diskSerial);
            Console.WriteLine("---------------------------------------------------");

            #endregion


            #region Get Memory info
            string[] memInfo = manager.GetMemoryInfo();
            Console.WriteLine("Press any key to display Memory info");
            Console.ReadKey();

            Console.WriteLine("Total Visible Memory: {0}KB", memInfo[0]);
            Console.WriteLine("Free Physical Memory: {0}KB", memInfo[1]);
            Console.WriteLine("Total Virtual Memory: {0}KB", memInfo[2]);
            Console.WriteLine("Free Virtual Memory: {0}KB", memInfo[3]);

            Console.WriteLine("---------------------------------------------------");
            #endregion


            #region List All Services
            ManagementObjectCollection services = manager.ListAllServices();
            Console.WriteLine("Press any key to display all running services");
            Console.ReadKey();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("There are {0} Windows services: ", services.Count);
            Console.WriteLine("---------------------------------------");
            manager.ListAllServices();

            // display services
            foreach (ManagementObject windowsService in services)
            {
                Console.WriteLine("Press any key to display next services");
                Console.ReadKey();
                Console.WriteLine("---------------------------------------------------");
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        Console.WriteLine("{0}: {1}", serviceProperty.Name, serviceProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------------------");
                
            }
            #endregion


            Console.ReadKey();

        } // End of Main


    }
}
