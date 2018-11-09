using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using MarsRover.Core;
using MarsRover.Data.DTO;
using MarsRover.Data.Model;
using MarsRover.Data.Model.Converter;
using Newtonsoft.Json;
using Serilog;

namespace MarsRover.Service
{
    public class MarsRoverService : IMarsRoverService
    {
        private readonly IApplicationSettings _applicationSettings;

        public MarsRoverService(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public async Task<IList<RoverImageDto>> GetRoverImageByDateAsync(RoverImageInputDto inputDate)
        {
            var roverList = Enum.GetValues(typeof(RoverName)).Cast<RoverName>();
            var tasklist = roverList.Select(item => GetRoverImageByRoverNameAndDateFromCacheAsync(item.ToString(), inputDate)).ToList();
            return (await Task.WhenAll(tasklist)).SelectMany(d => d).ToList();
        }


        public async Task<IList<RoverImageDto>> GetRoverImageByRoverNameAndDateFromCacheAsync(string roverName,
            RoverImageInputDto inputDate)
        {
            //TODO: implement Caching layer
            return Mapper.Map<IList<RoverImageDto>>((await GetRoverImageByRoverNameAndDateAsync(roverName, inputDate.ImageDate)).Photos);
        }

        public virtual async Task<MarsRoverApiResponse> GetRoverImageByRoverNameAndDateAsync(string roverName, DateTime imageDate)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri(_applicationSettings.MarsRoverBaseApiUrl);
                var response = await client.GetAsync($"{roverName}/photos?earth_date={imageDate:yyyy-MM-dd}&api_key={_applicationSettings.MarsRoverApiKey}");

                if (!response.IsSuccessStatusCode) return new MarsRoverApiResponse();
                var responseJson = await response.Content.ReadAsStringAsync();
                if (responseJson == "[]") return new MarsRoverApiResponse();
                try
                {
                    return JsonConvert.DeserializeObject<MarsRoverApiResponse>(responseJson, CustomConverter.Settings);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"GetRoverImageByDate");
                    return new MarsRoverApiResponse();
                }
            }
        }


    }
}