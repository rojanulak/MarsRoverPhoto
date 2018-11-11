using Newtonsoft.Json;

namespace MarsRover.Data.Model
{
    public partial class CameraElement
    {
        [JsonProperty("name")]
        public CameraName Name { get; set; }

        [JsonProperty("full_name")]
        public CameraFullName FullName { get; set; }
    }
}

