using System;
using MarsRover.Data.Model;
using MarsRover.Data.Model.Converter;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace MarsRover.UnitTest.RoverService
{
    [Collection("Our Test Collection #1")]
    public class CameraNameDeserializationTest : TestBase
    {
     

        public CameraNameDeserializationTest()
        {
            Setup();
        }

      
        [Fact]
        public void CamerName_Are_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'id':665791,'sol':2224,'camera':{'id':20,'name':'FHAZ','rover_id':5,'full_name':'Front Hazard Avoidance Camera'},'img_src':'http://mars.jpl.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/02224/opgs/edr/fcam/FRA_594936755EDR_F0730550FHAZ00337M_.JPG','earth_date':'2018-11-08','rover':{'id':5,'name':'Curiosity','landing_date':'2012-08-06','launch_date':'2011-11-26','status':'active','max_sol':2224,'max_date':'2018-11-08','total_photos':342460,'cameras':[{'name':'FHAZ','full_name':'Front Hazard Avoidance Camera'},{'name':'NAVCAM','full_name':'Navigation Camera'},{'name':'MAST','full_name':'Mast Camera'},{'name':'CHEMCAM','full_name':'Chemistry and Camera Complex'},{'name':'MAHLI','full_name':'Mars Hand Lens Imager'},{'name':'MARDI','full_name':'Mars Descent Imager'},{'name':'RHAZ','full_name':'Rear Hazard Avoidance Camera'}]}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.Fhaz);
            marsResponse.Photos[0].Camera.FullName.ShouldBe(CameraFullName.FrontHazardAvoidanceCamera);
        }

        [Fact]
        public void When_Incorrect_CameraName_Are_Returned_Throws_Expcetion()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'WHATTTTTTTT','rover_id':5,'full_name':'Front Hazard Avoidance Camera'},'rover':]}";

            //Act
            void Act() => JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            Should.Throw<Exception>((Action)Act)
                .Message.ShouldBe("Cannot unmarshal type CameraName");
        }

        [Fact]
        public void FHAZ_CamerName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'FHAZ'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.Fhaz);
        }

        [Fact]
        public void CHEMCAM_CamerName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'CHEMCAM'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.Chemcam);
        }

        [Fact]
        public void MAHLI_CamerName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'MAHLI'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.Mahli);
        }
        
        [Fact]
        public void MARDI_CamerName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'MARDI'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.Mardi);
        }

        [Fact]
        public void MAST_CamerName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'MAST'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.Mast);
        }

        [Fact]
        public void NAVCAM_CamerName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'NAVCAM'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.Navcam);
        }

        [Fact]
        public void RHAZ_CamerName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'RHAZ'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.Rhaz);
        }

        [Fact]
        public void PANCAM_CamerName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'PANCAM'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.PanCam);
        }

        [Fact]
        public void MINITES_CamerName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'MINITES'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.Minties);
        }

        [Fact]
        public void ENTRY_CamerName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'ENTRY'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.Name.ShouldBe(CameraName.Entry);
        }

        
    }
}
