using System;
using Newtonsoft.Json;

namespace MarsRover.Data.Model
{
        //TODO: use Constant File for all constanst
    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "active")
            {
                return Status.Active;
            }
            if (value == "complete")
            {
                return Status.Complete;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            if (value == Status.Active)
            {
                serializer.Serialize(writer, "active");
                return;
            }
            if (value == Status.Complete)
            {
                serializer.Serialize(writer, "complete");
                return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }
}