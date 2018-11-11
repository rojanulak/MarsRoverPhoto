using System.Threading.Tasks;
using MarsRover.Core;

namespace MarsRoverDownloadImages.CMD.Service
{
    public interface IRoverImageArchiver:ISingletonDependency
    {
        Task<ExitCode> ArchiveImages(string fileLocation);
    }
}