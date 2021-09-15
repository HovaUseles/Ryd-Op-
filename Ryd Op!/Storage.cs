using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIApp
{
    class Storage
    {
        private ManagementScope scope;
        private ObjectQuery query;
        private ManagementObjectSearcher searcher;
        private ManagementObjectCollection results;

        public Storage()
        {
            // default constructor
        }

        public ManagementObjectCollection GetCollection(string queryTag, string scopePath = "\\\\.\\ROOT\\cimv2")
        {
            scope = new ManagementScope(scopePath);
            query = new ObjectQuery(queryTag);
            searcher = new ManagementObjectSearcher(scope, query);
            results = searcher.Get();
            return results;
        }
        public ManagementObjectCollection GetCollectionNoScope(string queryTag)
        {
            query = new ObjectQuery(queryTag);
            searcher = new ManagementObjectSearcher(scope, query);
            results = searcher.Get();
            return results;
        }

    }
}
