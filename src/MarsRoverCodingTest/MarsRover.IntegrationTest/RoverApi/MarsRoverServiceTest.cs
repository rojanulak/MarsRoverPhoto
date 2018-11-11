using System;
using System.Threading.Tasks;
using MarsRover.Core;
using MarsRover.Data.DTO;
using MarsRover.Service;
using MarsRover.Unity;
using Shouldly;
using Xunit;

namespace MarsRover.IntegrationTest.RoverApi
{
    [Collection("Our Test Collection #2")]
    public class MarsRoverServiceTest : TestBase
    {
        private readonly IMarsRoverService _marsRoverService;

        public MarsRoverServiceTest()
        {
            Setup();
            _marsRoverService = new MarsRoverService(UnitySetup.Resolve<IApplicationSettings>());
        }

        [Theory]
        [InlineData(2017, 2, 27, 78)]
        [InlineData(2018, 2, 06, 58)]
        public async Task GetRoverImage_Count_Should_Always_BeSame(int year, int month, int day, int resultCount)
        {
            //Arrange

            var input = new RoverImageInputDto()
            {
                ImageDate = new DateTime(year, month, day)
            };
            //Act
            var result = (await _marsRoverService.GetRoverImageByDateAsync(input));
            //Assert
            result.Count.ShouldBe(resultCount);
        }

        [Fact]
        public async Task GetRoverImage_Count_Should_Zero_For_Future()
        {
            //Arrange

            var input = new RoverImageInputDto()
            {
                ImageDate = new DateTime(2200, 1, 1)
            };
            //Act
            var result = (await _marsRoverService.GetRoverImageByDateAsync(input));
            //Assert
            result.Count.ShouldBe(0);
        }

        [Fact]
        public async Task GetRoverImage_Count_Should_Zero_For_Past()
        {
            //Arrange

            var input = new RoverImageInputDto()
            {
                ImageDate = new DateTime(1900, 1, 1)
            };
            //Act
            var result = (await _marsRoverService.GetRoverImageByDateAsync(input));
            //Assert
            result.Count.ShouldBe(0);
        }

    }
}
