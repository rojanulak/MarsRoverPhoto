using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MarsRover.Core;
using MarsRover.Data.DTO;
using Newtonsoft.Json;
using Serilog;

namespace MarsRoverDownloadImages.CMD.Service
{
    public class RoverImageArchiver : IRoverImageArchiver
    {
        private readonly IDownloadImageservice _downloadImageservice;
        private readonly IApplicationSettings _applicationSettings;

        public RoverImageArchiver(IDownloadImageservice downloadImageservice, IApplicationSettings applicationSettings)
        {
            _downloadImageservice = downloadImageservice;
            _applicationSettings = applicationSettings;
        }

        public async Task<ExitCode> ArchiveImages(string fileLocation)
        {
            Log.Information($"Reading dates from text file");
            var alldates = GetDatesFromFile(fileLocation);
            Log.Information($"Getting Image Urls using text file for all the rovers");
            var tasklist = alldates.Select(GetAllImageUrls).ToList();
            var allUrls = (await Task.WhenAll(tasklist)).SelectMany(d => d).ToList();
            Log.Information($"Starting to download all Images..");
            await _downloadImageservice.DownloadMultipleFilesAsync(allUrls);
            return ExitCode.Success;
        }

        public async Task<IList<RoverImageDto>> GetAllImageUrls(DateTime inputDate)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri(_applicationSettings.MarsRoverWebApi);
                var response = await client.GetAsync($"api/getimagebydate/{inputDate:yyyy-MM-dd}");

                if (!response.IsSuccessStatusCode) return new List<RoverImageDto>();
                var responseJson = await response.Content.ReadAsStringAsync();
                if (responseJson == "[]") return new List<RoverImageDto>();
                try
                {
                    return JsonConvert.DeserializeObject<List<RoverImageDto>>(responseJson);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"GetAllImageUrls");
                    return new List<RoverImageDto>();
                }
            }
        }

        private IList<DateTime> GetDatesFromFile(string fileLocation)
        {
            var fileContents = File.ReadAllLines(fileLocation);
            return fileContents.Select(ParseDateTime).Where(x => x != DateTime.MinValue).ToList();
        }

        public DateTime ParseDateTime(string date)
        {
            return DateTimeExtension.ParseDateTime(date);
        }
    }

}