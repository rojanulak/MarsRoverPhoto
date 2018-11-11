using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MarsRover.Core;
using MarsRover.Data.DTO;
using Serilog;

namespace MarsRoverDownloadImages.CMD.Service
{
    public class DownloadImageservice : IDownloadImageservice
    {
        private readonly IApplicationSettings _applicationSettings;

        public DownloadImageservice(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        private async Task DownloadFileAsync(RoverImageDto doc)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    Log.Information($"Downloading {doc.FilePath}");
                    var downloadToDirectory = _applicationSettings.LocalStorageRootPath + doc.FilePath;
                    await webClient.DownloadFileTaskAsync(new Uri(doc.ImageUrl), @downloadToDirectory);
                    Log.Information($"Download complete {doc.FilePath}");

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failed to download File: {doc.FilePath}");
            }
        }

        public async Task DownloadMultipleFilesAsync(List<RoverImageDto> doclist)
        {
            System.IO.Directory.CreateDirectory(_applicationSettings.LocalStorageRootPath);

            await Task.WhenAll(doclist.Select(DownloadFileAsync));
        }
    }
}