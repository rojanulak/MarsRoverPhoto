using System;
using Newtonsoft.Json;

namespace MarsRover.Data.Model
{
    public partial class Rover
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public RoverName Name { get; set; }

        [JsonProperty("landing_date")]
        public DateTimeOffset LandingDate { get; set; }

        [JsonProperty("launch_date")]
        public DateTimeOffset LaunchDate { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("max_sol")]
        public long MaxSol { get; set; }

        [JsonProperty("max_date")]
        public DateTimeOffset MaxDate { get; set; }

        [JsonProperty("total_photos")]
        public long TotalPhotos { get; set; }

        [JsonProperty("cameras")]
        public CameraElement[] Cameras { get; set; }
    }
}