using Newtonsoft.Json;

namespace MarsRover.Data.Model
{

    public partial class MarsRoverApiResponse
    {
        [JsonProperty("photos")]
        public Photo[] Photos { get; set; }
    }
}
