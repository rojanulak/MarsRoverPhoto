using System;
using Newtonsoft.Json;

namespace MarsRover.Data.Model
{
    public partial class Photo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("sol")]
        public long Sol { get; set; }

        [JsonProperty("camera")]
        public PhotoCamera Camera { get; set; }

        [JsonProperty("img_src")]
        public Uri ImgSrc { get; set; }

        [JsonProperty("earth_date")]
        public DateTimeOffset EarthDate { get; set; }

        [JsonProperty("rover")]
        public Rover Rover { get; set; }
    }
}