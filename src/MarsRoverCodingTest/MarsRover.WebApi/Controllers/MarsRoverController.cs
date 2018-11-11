using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MarsRover.Core;
using MarsRover.Data.DTO;
using MarsRover.Data.Model;
using MarsRover.Service;

namespace MarsRover.WebApi.Controllers
{
    public class MarsRoverController : BaseController
    {
        private readonly IMarsRoverService _marsRoverService;

        public MarsRoverController(IMarsRoverService marsRoverService)
        {
            _marsRoverService = marsRoverService;
        }


        [Route("api/getimagebydate/{inputdate}")]
        [HttpGet]
        public async Task<IList<RoverImageDto>> GetImageByDate(string inputdate)
        {
            return await _marsRoverService.GetRoverImageByDateAsync(new RoverImageInputDto()
            {
                ImageDate = DateTimeExtension.ParseDateTime(inputdate)
            });
        }
        [Route("api/getimagebyrover/{roverName}/{inputdate}")]
        [HttpGet]
        public async Task<IList<RoverImageDto>> GetImageByRoverNameAndDate(string roverName, string inputdate)
        {
            
            return await _marsRoverService.GetRoverImageByRoverNameAndDateFromCacheAsync(roverName,new RoverImageInputDto()
            {
                ImageDate = DateTimeExtension.ParseDateTime(inputdate),
            });
        }

    }
}