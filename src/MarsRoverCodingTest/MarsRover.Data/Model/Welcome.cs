using Newtonsoft.Json;

namespace MarsRover.Data.Model
{

    public partial class Welcome
    {
        [JsonProperty("photos")]
        public Photo[] Photos { get; set; }
    }
}
