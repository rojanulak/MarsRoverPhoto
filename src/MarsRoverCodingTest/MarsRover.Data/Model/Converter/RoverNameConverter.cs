using System;
using MarsRover.Core;
using Newtonsoft.Json;

namespace MarsRover.Data.Model.Converter
{
    internal class RoverNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RoverName) || t == typeof(RoverName?);


        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == MarsRoverConstant.Curiosity)
            {
                return RoverName.Curiosity;
            }
            if (value == MarsRoverConstant.Spirit)
            {
                return RoverName.Spirit;
            }
            if (value == MarsRoverConstant.Opportunity)
            {
                return RoverName.Opportunity;
            }
            throw new Exception("Cannot unmarshal type RoverName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (RoverName)untypedValue;
            if (value == RoverName.Curiosity)
            {
                serializer.Serialize(writer, MarsRoverConstant.Curiosity);
                return;
            }
            if (value == RoverName.Spirit)
            {
                serializer.Serialize(writer, MarsRoverConstant.Spirit);
                return;
            }
            if (value == RoverName.Opportunity)
            {
                serializer.Serialize(writer, MarsRoverConstant.Opportunity);
                return;
            }
            throw new Exception("Cannot marshal type RoverName");
        }

        public static readonly RoverNameConverter Singleton = new RoverNameConverter();
    }
}