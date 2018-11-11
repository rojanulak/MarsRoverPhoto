using System.Collections.Generic;
using System.Threading.Tasks;
using MarsRover.Core;
using MarsRover.Data.DTO;

namespace MarsRover.Service
{
    public interface IMarsRoverService : ISingletonDependency
    {
        Task<IList<RoverImageDto>> GetRoverImageByDateAsync(RoverImageInputDto inputDate);

        Task<IList<RoverImageDto>> GetRoverImageByRoverNameAndDateFromCacheAsync(string roverName,
           RoverImageInputDto inputDate);
    }
}


