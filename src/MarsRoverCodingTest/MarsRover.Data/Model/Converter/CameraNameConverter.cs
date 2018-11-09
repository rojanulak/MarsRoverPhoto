using System;
using Newtonsoft.Json;

namespace MarsRover.Data.Model.Converter
{
    internal class CameraNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CameraName) || t == typeof(CameraName?);
        //TODO: use Constant File for all constanst
        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CameraName)untypedValue;
            switch (value)
            {
                case CameraName.Chemcam:
                    serializer.Serialize(writer, "CHEMCAM");
                    return;
                case CameraName.Fhaz:
                    serializer.Serialize(writer, "FHAZ");
                    return;
                case CameraName.Mahli:
                    serializer.Serialize(writer, "MAHLI");
                    return;
                case CameraName.Mardi:
                    serializer.Serialize(writer, "MARDI");
                    return;
                case CameraName.Mast:
                    serializer.Serialize(writer, "MAST");
                    return;
                case CameraName.Navcam:
                    serializer.Serialize(writer, "NAVCAM");
                    return;
                case CameraName.Rhaz:
                    serializer.Serialize(writer, "RHAZ");
                    return;
                case CameraName.PanCam:
                    serializer.Serialize(writer, "PANCAM");
                    return;
                case CameraName.Minties:
                    serializer.Serialize(writer, "MINITES");
                    return;
                case CameraName.Entry:
                    serializer.Serialize(writer, "ENTRY");
                    return;
            }
            throw new Exception("Cannot marshal type CameraName");
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CHEMCAM":
                    return CameraName.Chemcam;
                case "FHAZ":
                    return CameraName.Fhaz;
                case "MAHLI":
                    return CameraName.Mahli;
                case "MARDI":
                    return CameraName.Mardi;
                case "MAST":
                    return CameraName.Mast;
                case "NAVCAM":
                    return CameraName.Navcam;
                case "RHAZ":
                    return CameraName.Rhaz;
                case "PANCAM":
                    return CameraName.PanCam;
                case "MINITES":
                    return CameraName.Minties;
                case "ENTRY":
                    return CameraName.Entry;
            }
            throw new Exception("Cannot unmarshal type CameraName");
        }



        public static readonly CameraNameConverter Singleton = new CameraNameConverter();
    }
}
