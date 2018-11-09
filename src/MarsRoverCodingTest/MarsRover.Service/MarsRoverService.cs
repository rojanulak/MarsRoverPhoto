using System;
using System.Collections.Generic;
using MarsRover.Core;
using MarsRover.Data.DTO;

namespace MarsRover.Service
{
    public class MarsRoverService : IMarsRoverService
    {
        private readonly IApplicationSettings _applicationSettings;

        public MarsRoverService(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public IEnumerable<RoverImageDto> GetRoverImageByDate(RoverImageInputDto inputDate)
        {
            throw new NotImplementedException();
        }
    }
}