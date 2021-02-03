using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Devices.Model
{
    public class ElectricalDevices
    {
        [BsonId]
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string DeviceName { get; set; }

        [Required]
        [BsonElement("Brand")]
        [JsonProperty("Brand")]
        public string BrandName { get; set; }

        [Required]
        [BsonElement("Model")]
        [JsonProperty("Model")]
        public string ModelName { get; set; }

        [Required]
        [BsonElement("Price")]
        [JsonProperty("Price")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Must be Numeric")]
        public string PriceValue { get; set; }

        [Required]
        [BsonElement("OS")]
        [JsonProperty("OS")]
        public string OperatingSystem { get; set; }

    }
}
