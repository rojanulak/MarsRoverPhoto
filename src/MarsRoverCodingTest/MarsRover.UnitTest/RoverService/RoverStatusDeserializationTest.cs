using System;
using MarsRover.Data.Model;
using MarsRover.Data.Model.Converter;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace MarsRover.UnitTest.RoverService
{
    [Collection("Our Test Collection #1")]
    public class RoverStatusDeserializationTest : TestBase
    {
        public RoverStatusDeserializationTest()
        {
            Setup();
        }

        [Fact]
        public void When_RoverStatus_Are_InCorrectly_Mapped_Throws_Expcetion()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'rover':{'id':5,'name':'Curiosity','status':'deactive'}}]}";

            //Act
            void Act() => JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            Should.Throw<Exception>((Action)Act)
                .Message.ShouldBe("Cannot unmarshal type Status");
        }

        [Fact]
        public void Active_RoverStatus_Are_Correctly_Mapped()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'rover':{'id':5,'name':'Curiosity','status':'active'}}]}";

            //Act
            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Rover.Status.ShouldBe(Status.Active);

        }
        [Fact]
        public void Complete_RoverStatus_Are_Correctly_Mapped()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'rover':{'id':5,'name':'Curiosity','status':'complete'}}]}";

            //Act
            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Rover.Status.ShouldBe(Status.Complete);

        }

    }
}
