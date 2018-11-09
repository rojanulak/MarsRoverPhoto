using Newtonsoft.Json;

namespace MarsRover.Data.Model
{
    public partial class PhotoCamera
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public CameraName Name { get; set; }

        [JsonProperty("rover_id")]
        public long RoverId { get; set; }

        [JsonProperty("full_name")]
        public CameraFullName FullName { get; set; }
    }
}