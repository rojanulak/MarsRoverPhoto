using MarsRover.Data.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MarsRover.Data.DTO
{
    public class RoverImageDto
    {
        public string ImageUrl { get; set; }
        public RoverName RoverName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CameraName CameraName { get; set; }
        public string FilePath { get; set; }
    }
}
