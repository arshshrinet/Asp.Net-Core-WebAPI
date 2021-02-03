using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devices.Model
{
    public class DeviceDatabaseSettings:IDeviceDatabaseSettings
    {
        public string DeviceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
    public interface IDeviceDatabaseSettings
    {
        public string DeviceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
