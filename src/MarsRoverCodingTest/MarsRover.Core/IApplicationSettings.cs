namespace MarsRover.Core
{
    public interface IApplicationSettings : ISingletonDependency
    {
         string MarsRoverBaseApiUrl { get; set; }
         string MarsRoverApiKey { get; set; }
         string LocalStorageRootPath { get; set; }

    }
}
