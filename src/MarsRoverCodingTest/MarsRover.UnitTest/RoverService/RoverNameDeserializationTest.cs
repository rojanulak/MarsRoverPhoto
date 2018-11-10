using System;
using MarsRover.Data.Model;
using MarsRover.Data.Model.Converter;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace MarsRover.UnitTest.RoverService
{
    [Collection("Our Test Collection #1")]
    public class RoverNameDeserializationTest : TestBase
    {
        
        public RoverNameDeserializationTest()
        {
            Setup();
        }

        [Fact]
        public void RoverName_Are_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'id':665791,'sol':2224,'camera':{'id':20,'name':'FHAZ','rover_id':5,'full_name':'Front Hazard Avoidance Camera'},'img_src':'http://mars.jpl.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/02224/opgs/edr/fcam/FRA_594936755EDR_F0730550FHAZ00337M_.JPG','earth_date':'2018-11-08','rover':{'id':5,'name':'Curiosity','landing_date':'2012-08-06','launch_date':'2011-11-26','status':'active','max_sol':2224,'max_date':'2018-11-08','total_photos':342460,'cameras':[{'name':'FHAZ','full_name':'Front Hazard Avoidance Camera'},{'name':'NAVCAM','full_name':'Navigation Camera'},{'name':'MAST','full_name':'Mast Camera'}]}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Rover.Name.ShouldBe(RoverName.Curiosity);
        }

        [Fact]
        public void RoverName_Curiosity_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'rover':{'id':5,'name':'Curiosity'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Rover.Name.ShouldBe(RoverName.Curiosity);
        }

        [Fact]
        public void RoverName_Spirit_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'rover':{'id':5,'name':'Spirit'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Rover.Name.ShouldBe(RoverName.Spirit);
        }

        [Fact]
        public void RoverName_Opportunity_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'rover':{'id':5,'name':'Opportunity'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Rover.Name.ShouldBe(RoverName.Opportunity);
        }

        [Fact]
        public void When_Incorrect_RoverName_Are_Returned_Throws_Expcetion()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'id':665791,'sol':2224,'camera':{'id':20,'name':'FHAZ','rover_id':5,'full_name':'Front Hazard Avoidance Camera'},'img_src':'http://mars.jpl.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/02224/opgs/edr/fcam/FRA_594936755EDR_F0730550FHAZ00337M_.JPG','earth_date':'2018-11-08','rover':{'id':5,'name':'WhatCuriosity','landing_date':'2012-08-06','launch_date':'2011-11-26','status':'active','max_sol':2224,'max_date':'2018-11-08','total_photos':342460,'cameras':[]}}]}";

            //Act
            void Act() => JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            Should.Throw<Exception>((Action)Act)
                .Message.ShouldBe("Cannot unmarshal type RoverName");
        }

    }
}
