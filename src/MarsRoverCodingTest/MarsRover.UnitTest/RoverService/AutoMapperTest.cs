using System;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Core;
using MarsRover.Data.DTO;
using MarsRover.Data.Model;
using MarsRover.Service;
using MarsRover.Unity;
using Moq;
using Shouldly;
using TestStack.Dossier;
using TestStack.Dossier.DataSources.Picking;
using TestStack.Dossier.Lists;
using Xunit;

namespace MarsRover.UnitTest.RoverService
{
    public class AutoMapperTest : TestBase
    {
        private Mock<MarsRoverService> _mockedService;
        private readonly RoverImageInputDto _roverInput;
        public AutoMapperTest()
        {
            Setup();
            _mockedService = new Mock<MarsRoverService>(UnitySetup.Resolve<IApplicationSettings>()) { CallBase = true };

            _roverInput = new RoverImageInputDto()
            {
                ImageDate = new DateTime(2016, 1, 1)
            };
        }

        [Fact]
        public async Task AutoMap_Correctly_Maps_RoverName()
        {

            //Arrange
            var rovers = Builder<Rover>.CreateListOfSize(3)
                .All().Set(x => x.Name, RoverName.Curiosity)
                .BuildList();
            var curiosityPhotos = Builder<Photo>.CreateListOfSize(5)
                 .All().Set(x => x.Rover, Pick.RepeatingSequenceFrom(rovers).Next)
                .All().Set(x => x.Camera.Name, CameraName.Chemcam)
                .All().Set(x => x.Camera.FullName, CameraFullName.FrontHazardAvoidanceCamera)

                 .BuildList();
            var apiResonse = new MarsRoverApiResponse()
            {
                Photos = curiosityPhotos.ToArray()
            };

            _mockedService.
                Setup(arg => arg.GetRoverImageByRoverNameAndDateAsync(RoverName.Curiosity.ToString(), _roverInput.ImageDate))
                .ReturnsAsync(apiResonse);
            //Act
            var result =
                await _mockedService.Object.GetRoverImageByRoverNameAndDateFromCacheAsync(
                    RoverName.Curiosity.ToString(), _roverInput);
            //Assert
            result.Count().ShouldBe(5);
            result.Count(x => x.RoverName == RoverName.Curiosity).ShouldBe(5);
        }


        [Fact]
        public async Task AutoMap_Correctly_Maps_CamerName()
        {
            //Arrange
            var cameras = Builder<PhotoCamera>.CreateListOfSize(3)
                 .All().Set(x => x.Name, CameraName.Fhaz)
                .BuildList();
            var spiritPhotos = Builder<Photo>.CreateListOfSize(2)
                 .All().Set(x => x.Rover.Name, RoverName.Spirit)
                 .All().Set(x => x.Camera, Pick.RepeatingSequenceFrom(cameras).Next)
                 .All().Set(x => x.Camera.FullName, CameraFullName.FrontHazardAvoidanceCamera)
                 .BuildList();
            var apiResonse = new MarsRoverApiResponse()
            {
                Photos = spiritPhotos.ToArray()
            };

            _mockedService.
                Setup(arg => arg.GetRoverImageByRoverNameAndDateAsync(RoverName.Spirit.ToString(), _roverInput.ImageDate))
                .ReturnsAsync(apiResonse);
            //Act
            var result =
                await _mockedService.Object.GetRoverImageByRoverNameAndDateFromCacheAsync(
                    RoverName.Spirit.ToString(), _roverInput);
            //Assert
            result.Count().ShouldBe(2);
            result.Count(x => x.CameraName == CameraName.Fhaz).ShouldBe(2);
        }
        [Fact]
        public async Task AutoMap_Correctly_Maps_FilePath()
        {
            //Arrange
            var rovers = Builder<Rover>.CreateListOfSize(3)
                .All().Set(x => x.Name, RoverName.Spirit)
                .BuildList();
            var cameras = Builder<PhotoCamera>.CreateListOfSize(3)
                .All().Set(x => x.Name, CameraName.Fhaz)
                .BuildList();
            var spiritPhotos = Builder<Photo>.CreateListOfSize(2)
                .All().Set(x=>x.ImgSrc, new Uri("http://test.com/urt.jpg"))
                .TheFirst(1).Set(x => x.EarthDate, new DateTime(2017, 1, 1))
                .TheNext(1).Set(x => x.EarthDate, new DateTime(2017, 1, 2))
                .All().Set(x => x.Rover, Pick.RepeatingSequenceFrom(rovers).Next)
                .All().Set(x => x.Camera, Pick.RepeatingSequenceFrom(cameras).Next)
                .All().Set(x => x.Camera.FullName, CameraFullName.FrontHazardAvoidanceCamera)
                .BuildList();
            var apiResonse = new MarsRoverApiResponse()
            {
                Photos = spiritPhotos.ToArray()
            };

            _mockedService.
                Setup(arg => arg.GetRoverImageByRoverNameAndDateAsync(RoverName.Spirit.ToString(), _roverInput.ImageDate))
                .ReturnsAsync(apiResonse);
            //Act
            var result =
                await _mockedService.Object.GetRoverImageByRoverNameAndDateFromCacheAsync(
                    RoverName.Spirit.ToString(), _roverInput);
            //Assert
            result.Count().ShouldBe(2);
            result[0].FilePath.ShouldBe("2017-01-01_Spirit_Fhaz_urt.jpg");
        }


    }
}
