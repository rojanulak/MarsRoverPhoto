using System.Collections.Generic;
using MarsRover.Core;
using MarsRover.Data.DTO;

namespace MarsRover.Service
{
    public interface IMarsRoverService: ISingletonDependency
    {
        IEnumerable<RoverImageDto> GetRoverImageByDate(RoverImageInputDto inputDate);
    }
}


 