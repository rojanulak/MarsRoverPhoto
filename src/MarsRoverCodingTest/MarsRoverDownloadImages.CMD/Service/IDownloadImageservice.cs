using System.Collections.Generic;
using System.Threading.Tasks;
using MarsRover.Core;
using MarsRover.Data.DTO;

namespace MarsRoverDownloadImages.CMD.Service
{
    public interface IDownloadImageservice : ISingletonDependency
    {
        Task DownloadMultipleFilesAsync(List<RoverImageDto> doclist);
    }
}