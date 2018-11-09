using System;
using Newtonsoft.Json;

namespace MarsRover.Data.Model.Converter
{
        //TODO: use Constant File for all constanst
    internal class CameraFullNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CameraFullName) || t == typeof(CameraFullName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Chemistry and Camera Complex":
                    return CameraFullName.ChemistryAndCameraComplex;
                case "Front Hazard Avoidance Camera":
                    return CameraFullName.FrontHazardAvoidanceCamera;
                case "Mars Descent Imager":
                    return CameraFullName.MarsDescentImager;
                case "Mars Hand Lens Imager":
                    return CameraFullName.MarsHandLensImager;
                case "Mast Camera":
                    return CameraFullName.MastCamera;
                case "Navigation Camera":
                    return CameraFullName.NavigationCamera;
                case "Rear Hazard Avoidance Camera":
                    return CameraFullName.RearHazardAvoidanceCamera;
                case "Panoramic Camera":
                    return CameraFullName.PanoramicCamera;
                case "Miniature Thermal Emission Spectrometer (Mini-TES)":
                    return CameraFullName.MiniatureThermalEmissionSpectrometer;
                case "Entry, Descent, and Landing Camera":
                    return CameraFullName.EntryDescentAndLandingCamera;
            }
            throw new Exception("Cannot unmarshal type CameraFullName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CameraFullName)untypedValue;
            switch (value)
            {
                case CameraFullName.ChemistryAndCameraComplex:
                    serializer.Serialize(writer, "Chemistry and Camera Complex");
                    return;
                case CameraFullName.FrontHazardAvoidanceCamera:
                    serializer.Serialize(writer, "Front Hazard Avoidance Camera");
                    return;
                case CameraFullName.MarsDescentImager:
                    serializer.Serialize(writer, "Mars Descent Imager");
                    return;
                case CameraFullName.MarsHandLensImager:
                    serializer.Serialize(writer, "Mars Hand Lens Imager");
                    return;
                case CameraFullName.MastCamera:
                    serializer.Serialize(writer, "Mast Camera");
                    return;
                case CameraFullName.NavigationCamera:
                    serializer.Serialize(writer, "Navigation Camera");
                    return;
                case CameraFullName.RearHazardAvoidanceCamera:
                    serializer.Serialize(writer, "Rear Hazard Avoidance Camera");
                    return;
                case CameraFullName.PanoramicCamera:
                    serializer.Serialize(writer, "Panoramic Camera");
                    return;
                case CameraFullName.MiniatureThermalEmissionSpectrometer:
                    serializer.Serialize(writer, "Miniature Thermal Emission Spectrometer (Mini-TES)	");
                    return;
                case CameraFullName.EntryDescentAndLandingCamera:
                    serializer.Serialize(writer, "Entry, Descent, and Landing Camera");
                    return;
            }
            throw new Exception("Cannot marshal type CameraFullName");
        }

        public static readonly CameraFullNameConverter Singleton = new CameraFullNameConverter();
    }
}