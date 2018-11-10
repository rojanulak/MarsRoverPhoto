using System;
using MarsRover.Data.Model;
using MarsRover.Data.Model.Converter;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace MarsRover.UnitTest.RoverService
{
    [Collection("Our Test Collection #1")]
    public class CameraFullNameDeserializationTest : TestBase
    {
        
        public CameraFullNameDeserializationTest()
        {
            Setup();
        }

        [Fact]
        public void CamerName_For_Rover_Are_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'id':665791,'sol':2224,'camera':{'id':20,'name':'FHAZ','rover_id':5,'full_name':'Front Hazard Avoidance Camera'},'img_src':'http://mars.jpl.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/02224/opgs/edr/fcam/FRA_594936755EDR_F0730550FHAZ00337M_.JPG','earth_date':'2018-11-08','rover':{'id':5,'name':'Curiosity','landing_date':'2012-08-06','launch_date':'2011-11-26','status':'active','max_sol':2224,'max_date':'2018-11-08','total_photos':342460,'cameras':[{'name':'FHAZ','full_name':'Front Hazard Avoidance Camera'},{'name':'NAVCAM','full_name':'Navigation Camera'},{'name':'MAST','full_name':'Mast Camera'},{'name':'CHEMCAM','full_name':'Chemistry and Camera Complex'},{'name':'MAHLI','full_name':'Mars Hand Lens Imager'},{'name':'MARDI','full_name':'Mars Descent Imager'},{'name':'RHAZ','full_name':'Rear Hazard Avoidance Camera'}]}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Rover.Cameras[0].Name.ShouldBe(CameraName.Fhaz);
            marsResponse.Photos[0].Rover.Cameras[0].FullName.ShouldBe(CameraFullName.FrontHazardAvoidanceCamera);

            marsResponse.Photos[0].Rover.Cameras[2].Name.ShouldBe(CameraName.Mast);
            marsResponse.Photos[0].Rover.Cameras[2].FullName.ShouldBe(CameraFullName.MastCamera);
        }

        [Fact]
        public void ChemistryAndCameraComplex_CamerFullName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'full_name':'Chemistry and Camera Complex'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.FullName.ShouldBe(CameraFullName.ChemistryAndCameraComplex);
        }
        [Fact]
        public void MiniatureThermalEmissionSpectrometer_CamerFullName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'full_name':'Miniature Thermal Emission Spectrometer (Mini-TES)'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.FullName.ShouldBe(CameraFullName.MiniatureThermalEmissionSpectrometer);
        }

        [Fact]
        public void EntryDescentAndLandingCamera_CamerFullName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'full_name':'Entry, Descent, and Landing Camera'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.FullName.ShouldBe(CameraFullName.EntryDescentAndLandingCamera);
        }
        [Fact]
        public void PanoramicCamera_CamerFullName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'full_name':'Panoramic Camera'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.FullName.ShouldBe(CameraFullName.PanoramicCamera);
        }

        [Fact]
        public void RearHazardAvoidanceCamera_CamerFullName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'full_name':'Rear Hazard Avoidance Camera'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.FullName.ShouldBe(CameraFullName.RearHazardAvoidanceCamera);
        }

        [Fact]
        public void NavigationCamera_CamerFullName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'full_name':'Navigation Camera'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.FullName.ShouldBe(CameraFullName.NavigationCamera);
        }

        [Fact]
        public void MarsHandLensImager_CamerFullName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'full_name':'Mars Hand Lens Imager'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.FullName.ShouldBe(CameraFullName.MarsHandLensImager);
        }

        [Fact]
        public void MarsDescentImager_CamerFullName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'full_name':'Mars Descent Imager'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.FullName.ShouldBe(CameraFullName.MarsDescentImager);
        }


        [Fact]
        public void FrontHazardAvoidanceCamera_CamerFullName_Correctly_Mapped_To_Enum()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'full_name':'Front Hazard Avoidance Camera'}}]}";

            //Act
            var marsResponse = JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            marsResponse.Photos[0].Camera.FullName.ShouldBe(CameraFullName.FrontHazardAvoidanceCamera);
        }

        
        [Fact]
        public void When_Incorrect_CameraFullName_Are_Returned_Throws_Expcetion()
        {
            //Arrange
            var apiResponse =
                @"{'photos':[{'camera':{'id':20,'name':'FHAZ','rover_id':5,'full_name':'InCorrect CameraxxxXXXNAMAE'},'rover':]}";

            //Act
            void Act() => JsonConvert.DeserializeObject<MarsRoverApiResponse>(apiResponse, CustomConverter.Settings);

            //Assert
            Should.Throw<Exception>((Action)Act)
                .Message.ShouldBe("Cannot unmarshal type CameraFullName");
        }
        
    }
}
