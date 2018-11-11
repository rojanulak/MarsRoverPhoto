using System.Configuration;

namespace MarsRover.Core
{
    public class ApplicationSettings : IApplicationSettings
    {
        public ApplicationSettings()
        {
            MarsRoverBaseApiUrl = ConfigurationManager.AppSettings["MarsRoverBaseApiUrl"];
            MarsRoverApiKey = ConfigurationManager.AppSettings["MarsRoverApiKey"];
            LocalStorageRootPath = ConfigurationManager.AppSettings["LocalStorageRootPath"];
            MarsRoverWebApi = ConfigurationManager.AppSettings["MarsRoverWebApi"];
        }


        public string MarsRoverBaseApiUrl { get; set; }
        public string MarsRoverApiKey { get; set; }
        public string LocalStorageRootPath { get; set; }
        public string MarsRoverWebApi { get; set; }
    }
}
