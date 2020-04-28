using Newtonsoft.Json;

namespace DakboardKiosk.Models
{
    public partial class Screen
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("is_default")]
        public long IsDefault { get; set; }
    }
}
