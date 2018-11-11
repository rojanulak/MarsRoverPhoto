using System;
using MarsRover.Core;
using MarsRover.Data.Model;
using MarsRover.Data.Model.Converter;
using MarsRoverDownloadImages.CMD;
using MarsRoverDownloadImages.CMD.Service;
using Moq;
using Newtonsoft.Json;
using Shouldly;
using Xunit;
namespace MarsRover.UnitTest.RoverImageArchiver
{
    [Collection("Our Test Collection #1")]
    public class RoverImageArchiverTest : TestBase
    {
        private readonly MarsRoverDownloadImages.CMD.Service.RoverImageArchiver imageArchiver;
        public RoverImageArchiverTest()
        {
            Setup();
            imageArchiver = new MarsRoverDownloadImages.CMD.Service.RoverImageArchiver(new Mock<IDownloadImageservice>().Object,
                new Mock<IApplicationSettings>().Object
                );
        }


        [Theory]
        [InlineData(2017, 2, 27, "02/27/17")]
        [InlineData(2018, 6, 2, "June 2, 2018")]
        [InlineData(2016, 7, 13, "Jul-13-2016")]
        [InlineData(2016, 7, 13, "2016-07-13")]
        public void StringDate_Must_Be_Correctly_Mapped(int year, int month, int day, string inputDate)
        {
            //Arrange
            var output = new DateTime(year, month, day);
            //Act

            var result = imageArchiver.ParseDateTime(inputDate);

            //Assert
            output.ShouldBe(result);
        }
        [Theory]
        [InlineData("27/27/17")]
        [InlineData("June 299, 2018")]
        [InlineData("Jul-103-2016")]
        [InlineData("April 31, 2018")]
        public void Incorrect_StringDate_Returns_MinValue(string inputDate)
        {
            //Arrange
            var output = DateTime.MinValue;
            //Act

            var result = imageArchiver.ParseDateTime(inputDate);

            //Assert
            output.ShouldBe(result);
        }
    }
}
