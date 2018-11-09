using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MarsRover.Data.Model.Converter
{
    public static class CustomConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CameraFullNameConverter.Singleton,
                CameraNameConverter.Singleton,
                RoverNameConverter.Singleton,
                StatusConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}