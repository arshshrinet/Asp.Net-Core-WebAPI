using Devices.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Devices.Services
{
    public class DeviceService
    {
        private readonly IMongoCollection<ElectricalDevices> _devices;

        public DeviceService(IDeviceDatabaseSettings settings)
        {
            try { 
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _devices = database.GetCollection<ElectricalDevices>(settings.DeviceCollectionName);
            }
            catch(Exception ex)
            {

                throw new Exception("Can not access to MongoDb server.", ex);
            }
        }

       // public List<ElectricalDevices> Get() =>
         //   _devices.Find(electricaldevices => true).ToList();
        public List<ElectricalDevices> Get() 
        {
            return _devices.Find(electricaldevices => true).ToList();
        }
           
        public ElectricalDevices Get(string id) =>
            _devices.Find<ElectricalDevices>(electricaldevices => electricaldevices.Id == id).FirstOrDefault();

        public ElectricalDevices Create(ElectricalDevices electricaldevices)
        {
            _devices.InsertOne(electricaldevices);
            return electricaldevices;
        }

        public void Update(string id, ElectricalDevices electricaldevicesIn) =>
            _devices.ReplaceOne(electricaldevices => electricaldevices.Id == id, electricaldevicesIn);

        public void Remove(ElectricalDevices electricaldevicesIn) =>
            _devices.DeleteOne(electricaldevices => electricaldevices.Id == electricaldevicesIn.Id);

        public void Remove(string id) =>
            _devices.DeleteOne(electricaldevices => electricaldevices.Id == id);
    }

}

