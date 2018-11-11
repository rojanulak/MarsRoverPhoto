using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ManyConsole;
using MarsRover.Core;
using MarsRover.Unity;
using MarsRoverDownloadImages.CMD.Service;
using Serilog;

namespace MarsRoverDownloadImages.CMD
{
    public class DownloadRoverImagesCommand : ConsoleCommand
    {
        public string FileLocation { get; set; }
        public DownloadRoverImagesCommand()
        {
            IsCommand("Run", "Downloads Nasa Rover Images and archives them to local folder");
            HasLongDescription("Downloads Nasa Rover Images and archives them to local folder, based on dates listed on file");
            HasRequiredOption("f|file=", "The full path of the file.", p => FileLocation = p);
        }
        public override int Run(string[] remainingArguments)
        {
            try
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                var roverImageArchiver = UnitySetup.Resolve<IRoverImageArchiver>();
                var task = Task.Run(() =>
                    roverImageArchiver.ArchiveImages(FileLocation));
                task.Wait();
                stopWatch.Stop();
                Log.Information($"Total Elasped Time in sec {stopWatch.Elapsed.TotalSeconds}");
                return (int)task.Result;
            }
            catch (Exception e)
            {
                Log.Error(e, "DownloadRoverImagesCommand.Run");
                return (int)ExitCode.UnknownError;
            }
        }
    }
}